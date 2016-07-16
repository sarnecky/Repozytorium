using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zabawa_z_gitem.DAL;
using zabawa_z_gitem.Models;
using zabawa_z_gitem.SearchEngine;

namespace zabawa_z_gitem.Controllers
{
    public class SearchController : Controller
    {
        private StoreContext Db = new StoreContext();
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(SearchModel model)
        {
            string text="", pattern="";
            model.SearchResuts = new List<SearchReslutModel>();

            RabinKarpSearch search = new RabinKarpSearch();
            FileToString fileToString = null;
            StringFromFile changer = null;
            //DI
            //unikamy instancjonowania określonych klas w różnych miejscach aplikacji i skupiamy się bardziej na abstrakcji
            //majac pewna klase wstrzykujemy w nia zalzeznosc, przez wykonanie na jej konstruktorze konstruktora z docelowego obiektu
            //dana klasa nie bedzie wiedziec na jakim obiekcie pracuje, wiec kazdy bierze odpowiedzialnosc za siebie
            if (model.SerachString!= null)
            {
               
                foreach (var file in Db.TextFiles)
                {
                    switch (file.Type.Name)
                    {
                        case ".txt":
                            fileToString = new TxtToString();
                            break;
                        case ".pdf":
                            fileToString = new PdfToString();
                            break;
                        case ".docx":
                            fileToString = new DocxToString();
                            break;
                        default:
                            fileToString = null;
                            break;
                    }

                    if (fileToString != null)
                    {
                        changer = new StringFromFile(fileToString);
                        //wydobycie calego tekstu z pliku
                        text = changer.GetStringFormFile(file,
                            Path.Combine(Server.MapPath("~/Data"), Path.GetFileName(file.Name)));
                    }
                    //przypisanie 
                    string[] patterns = model.SerachString.Split(new[] { ',', ' ' });
                    pattern = pattern.ToLower();
                    text = text.ToLower();

                    bool findAnyPattern = false;
                    var numberOfStrings = new Dictionary<string, int>();
                    foreach (var s in patterns)
                    {
                        var collectionOfBeginningStrings = search.searchPattern(text, s); //szukam danego stringa w teksie
                        int countOfString = collectionOfBeginningStrings.Count();
                        if (countOfString > 0)
                        {
                            numberOfStrings.Add(s,countOfString);
                            findAnyPattern = true;
                        }
                    }

                    if (findAnyPattern)
                    {
                        model.SearchResuts.Add(new SearchReslutModel() { Name = file.Name, NumberOfStrings = numberOfStrings});
                    }
                }
            }

            return View(model);
        }
    }
}