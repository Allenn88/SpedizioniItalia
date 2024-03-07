using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpedizioniItalia.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult AddCliente()
        {
            return View();
        }
        public ActionResult AddAzienda()
        {
            return View();
        }
        public ActionResult AddSpedizioni()
        {
            return View();
        }
        public ActionResult ViewSpedizioni()
        {
            return View();
        }
    }
}