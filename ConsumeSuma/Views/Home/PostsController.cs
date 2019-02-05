using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsumeSuma.Views.Home
{
    public class PostsController : Controller
    {
        // GET: TblPost
        public ActionResult Index()
        {
            WsSuma.MyWebServiciesSoapClient myWebServiciesSoapClient = new WsSuma.MyWebServiciesSoapClient();
            var tb = myWebServiciesSoapClient.getPost();
            return View(tb.ToList());
        }
    }
}