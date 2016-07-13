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

namespace zabawa_z_gitem.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext Db = new StoreContext();
        // GET: Home
        public ActionResult Index()
        {
            //TextFile TextFile = new TextFile {Name = "ako.pdf", AddedDateTime = DateTime.Now, Size = 178};
            IEnumerable<TextFile> userFiles;
            userFiles = Db.TextFiles.ToArray();
            //utowrzenie plikus
            return View(userFiles);
            //jakas tam edycja
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var fileSize = file.ContentLength;
                var path = Path.Combine(Server.MapPath("~/Data"), fileName);
                file.SaveAs(path); 

                TextFile newTextFile = new TextFile() {Name = fileName, Size = fileSize, AddedDateTime = DateTime.Now, TypeId = 1};
                Db.TextFiles.AddOrUpdate(newTextFile);
                Db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}