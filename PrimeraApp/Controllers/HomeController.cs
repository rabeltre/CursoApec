using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrimeraApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Mensaje = "Hola desde el controller";
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection form) {
            ViewBag.Mensaje = form["valor"];
            return View();
        }

        public ActionResult Sumar()
        {
            ViewBag.resultado = 0;
            return View();
        }
        [HttpPost]
        public ActionResult Sumar(FormCollection form)
        {
            int num1 = int.Parse(form["num1"]);
            int num2 = int.Parse(form["num2"]);
            ViewBag.resultado = num1 + num2;
            return View();
        }
    }
}