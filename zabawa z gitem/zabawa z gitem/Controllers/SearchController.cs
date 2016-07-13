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

            if (model.SerachString!= null)
            {
                foreach (var file in Db.TextFiles)
                {

                    //wydobycie calego tekstu z pliku
                    try
                    {
                        using (StreamReader sr = new StreamReader(Path.Combine(Server.MapPath("~/Data"), Path.GetFileName(file.Name))))
                        {
                            text = sr.ReadToEnd().ToString();
                        }
                    }
                    catch (Exception e)
                    {
                        //Nie mozna otowrzyc pliku
                        Response.Write("Some Error");
                    }

                    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! tylko jeden string narazie
                    //przypisanie 
                    pattern = model.SerachString;

                    pattern = pattern.ToLower();
                    text = text.ToLower();

                    var collectionOfBeginningStrings = search.searchPattern(text, pattern); //szukam danego stringa w teksie
                    int countOfString = collectionOfBeginningStrings.Count();

                    if (countOfString > 0)
                    {
                        model.SearchResuts.Add(new SearchReslutModel() { Name = file.Name, NumberOfStrings = new Dictionary<string, int>() { { pattern, countOfString } } });
                    }
                }
            }

            return View(model);
        }
    }
}