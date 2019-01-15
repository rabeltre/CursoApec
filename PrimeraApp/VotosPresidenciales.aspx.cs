using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrimeraApp
{
    public partial class VotosPresidenciales : System.Web.UI.Page
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\CETA\Desktop\CursoApec-master\CursoApec-master\PrimeraApp\App_Data\mydata.mdf;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            actulizarGrafico();
        }

        protected void cmdPld_Click1(object sender, EventArgs e)
        {


            validarCookies(1);
        }


        private void validarCookies(int id) {
            if (controlVotoSession())
            {
                ejercerVoto(id);
            }
        }
        public bool controlVotoSession() {
            if (Request.Cookies["userStates"] != null)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertMessage", "alert('Lo sentimos, no puede votar mas de una vez por usuario.');", true);
                return false;
            }
            else
            {
                Response.Cookies["UserStates"].Value = true.ToString();
                return true;
            }

        }

        private void ejercerVoto(int id) {
            actualizar(id);
            actulizarGrafico();
        }

        private void actulizarGrafico() {
            MyDataSetTableAdapters.tblVotosTableAdapter tblVotosTableAdapter = new MyDataSetTableAdapters.tblVotosTableAdapter();


            chartVoto.DataSource = tblVotosTableAdapter.GetData().ToList();
            chartVoto.Series[0].XValueMember = "NombrePartido";
            chartVoto.Series[0].YValueMembers = "Cantidad_Votos";
            chartVoto.Series[0].Label = "#VALX ---- #VALY POR #PERCENT";
            chartVoto.DataBind();
        }

        private void actualizar(int id) {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("update tblVotos set Cantidad_Votos=Cantidad_Votos+1 where id=@id", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        protected void cmdPrd_Click(object sender, EventArgs e)
        {
            validarCookies(2);
        }

        protected void cmdPrsc_Click(object sender, EventArgs e)
        {
            validarCookies(3);
        }

    
    }
}