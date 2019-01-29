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
        public ActionResult Index(HttpPostedFileBase file) {

            if (file != null && file.ContentLength > 0 )
            {
                var fileName = System.IO.Path.GetFileName(file.FileName);
                var path = System.IO.Path.Combine(Server.MapPath("~/Images/"), fileName);
                file.SaveAs(path);
            }
            ViewBag.Mensaje = "Archivo guardado";
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