using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeraApp
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "Func()", true);
            ImageFoto.ImageUrl = "/Images/1.jpg";
            var ced = txtMensaje.Text;
            if (ced == "40224151056")
            {
                ImageFoto.ImageUrl = "/Images/1.jpg";
                lblResult.Text = "Rafael Beltre";
            }else if (ced == "2")
            {
                ImageFoto.ImageUrl = "/Images/2.jpg";
                lblResult.Text = "Manolo Albarez";
            }
            else if (ced == "3")
            {
                ImageFoto.ImageUrl = "/Images/3.jpg";
                lblResult.Text = "Jualia Alvarez";
            }

            else
            {
                lblResult.Text = "Registro no encontrado";
                ImageFoto.ImageUrl = "";
            }
        }
    }
}