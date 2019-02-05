using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Index(HttpPostedFileBase File1) {

            if (File1 != null && File1.ContentLength > 0 )
            {
                var file = Path.GetFileName(File1.FileName);
                var path = Path.Combine(Server.MapPath("~/Images/"), file);
                File1.SaveAs(path);
                ViewBag.Mensaje = "Archivo guardado";
                return View();
            }
            ViewBag.Mensaje = "Archivo no guardado";
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