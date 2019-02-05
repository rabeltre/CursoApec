using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PrimeraApp
{
    /// <summary>
    /// Summary description for MyWebServicies
    /// </summary>
    [WebService(Namespace = "http://google.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MyWebServicies : System.Web.Services.WebService
    {

        [WebMethod]
        public int Sumar(int num1, int num2)
        {
            return num1 + num2;
        }

        [WebMethod]
        public List<tblPost> getPost()
        {
            mydataEntities mydataEntities = new mydataEntities();
            
             List<tblPost> record = mydataEntities.tblPosts.OrderByDescending(x => x.Id).ToList(); ;
            return record;
        }

        [WebMethod]
        public tblPost getPostById(int id)
        {
            mydataEntities mydataEntities = new mydataEntities();
            tblPost record = mydataEntities.tblPosts.First(x => x.Id == id);
            return record;
        }

    }
}
