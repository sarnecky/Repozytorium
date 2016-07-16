using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zabawa_z_gitem.Models;

namespace zabawa_z_gitem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //walidacja po stronie serwera, na podstawie danych ktore przyszly z widoku(po binodowaniu)
            //podwojna walidacja ze wzgledu na mozliwosc wylaczenia js po stronie klienta
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

       
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            //walidacja po stronie serwera, na podstawie danych ktore przyszly z widoku(po binodowaniu)
            //podwojna walidacja ze wzgledu na mozliwosc wylaczenia js po stronie klienta
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}