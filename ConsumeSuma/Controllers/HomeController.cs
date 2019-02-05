using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumeSuma.Controllers
{
    public class HomeController : Controller
    {

 
        public ActionResult Index()
        {
            ViewBag.Respuesta = 0;
            return View();
        }

        // GET: Home
        [HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            WSOnline.CalculatorSoapClient calculatorSoapClient = new WSOnline.CalculatorSoapClient();
            WsSuma.MyWebServiciesSoapClient myWebServiciesSoapClient = new WsSuma.MyWebServiciesSoapClient();
            string valor1 = formCollection["num1"];
            string valor2 = formCollection["num2"];
            int resultado = calculatorSoapClient.Multiply(int.Parse(valor1), int.Parse(valor2));
            ViewBag.Respuesta = resultado;
            return View();
        }
    }
}