using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.Controllers
{
    public class SearchController : Controller
    {
        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Index(SearchModel model)
        {
            //nasz algorytm szukania pdf
            model.SearchResuts = new List<SearchReslutModel>()
            {
                new SearchReslutModel() {Name = "afasf", NumberOfStrings =new Dictionary<string, int>() { {"film",12}, { "zjebany", 15 } } }
            };
            return View(model);
        }
    }
}