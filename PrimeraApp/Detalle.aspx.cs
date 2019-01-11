using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeraApp
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string path = Path.GetTempFileName();
            imgDetails.ImageUrl = "~/Images/" + Request["Nombre"];

            
        // FileInfo fi1 = new FileInfo(Request["ruta"]);
        FileInfo fi1 = new FileInfo(Server.MapPath("~/Images/") + Request["Nombre"]);
            lblNombre.Text = fi1.Name;
  
          lblSize.Text = fi1.Length.ToString();
        }
    }
}