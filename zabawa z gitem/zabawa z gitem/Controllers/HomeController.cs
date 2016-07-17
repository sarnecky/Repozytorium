using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zabawa_z_gitem.DAL;
using zabawa_z_gitem.Models;
using zabawa_z_gitem.SearchEngine;
using System.Reflection;
using Microsoft.AspNet.Identity;

namespace zabawa_z_gitem.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext Db = new StoreContext();
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<TextFile> userFiles; //czyli pliki jednak beda musialy miec nazwe posiadacza, chyba ze wjedziesz do folderu zwrocisz nazwy plikow i wyszukasz
            userFiles = Db.TextFiles.ToArray();
            //utowrzenie pliku
            return View(userFiles);
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        { 
            TextFile newTextFile = null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fileSize = file.ContentLength;
                var path = Path.Combine(Server.MapPath(string.Concat("~/Data/",User.Identity.GetUserName())), fileName);
                file.SaveAs(path);
                string ext = Path.GetExtension(file.FileName);

                int type = GetType(ext);
                
                if(type!=0)
                    newTextFile = new TextFile() {Name = fileName, Size = fileSize, AddedDateTime = DateTime.Now, TypeId = type};

                if (newTextFile != null)
                {
                    Db.TextFiles.AddOrUpdate(newTextFile);
                    Db.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }

        private int GetType(string ext)
        {
            ext = ext.Remove(0, 1); //usuniecie kropki
            int i = 1;
            //wykorzystuje refleksję do utworzenia konkretnego enuma
           System.Type myenum = System.Type.GetType("zabawa_z_gitem.SearchEngine.TypesOfFiles");

            foreach (var t in Enum.GetValues(myenum))
            {
                if (t.ToString().ToLower() == ext)
                    return i;
                i++;
            }

            return 0;
        }

        public ActionResult RemoveFile(int fileId)
        {
            var textFile = Db.TextFiles.FindTextFileWithId(fileId);
            var result = new RemovedViewModel();

            if (textFile != null)
            {
                Db.TextFiles.Remove(textFile);
                Db.SaveChanges();
                var fileName = Path.GetFileName(textFile.Name);
                var filePath = Path.Combine(Server.MapPath("~/Data"), fileName);
                System.IO.File.Delete(filePath);

                result.Removed = true;
            }
            else
            {
                result.Removed = false;
            }

            return Json(result);
        }
    }
}