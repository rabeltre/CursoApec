using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace PrimeraApp
{
    public partial class testCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            Actualizar();
            lblCantidad.Text = string.Format("{0} ---- Usuarios Conectados", Application["CantidadUsuarios"]);
        }

        protected void btnCalendario_Click(object sender, EventArgs e)
        {
            lblFecha.Text = calCita.SelectedDate.ToLongDateString();
            if (cboAceptar.Checked)
            {
                lblFecha.Text += " -Confirmado";
            }
          
            foreach(ListItem li in cblLista.Items)
            {
                if (li.Selected)
                {
                    lblFecha.Text += "-"  + li.Text;
                }
            }

            lblFecha.Text += ddlCuenta.SelectedValue;

        }

        protected void cboAceptar_CheckedChanged(object sender, EventArgs e)
        {

        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\RA Beltre\Documents\Proyect\CursoApec\PrimeraApp\App_Data\mydata.mdf;Integrated Security=True");

        protected void btnGuardarImage_Click(object sender, EventArgs e)
        {
            if (fuImagen.HasFiles)
            {
                //SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\CETA\Desktop\Rafael\CursoApec\PrimeraApp\App_Data\mydata.mdf;Integrated Security=True");

                //sqlConnection.Open();
                mydataEntities mydataEntities = new mydataEntities();
                foreach (HttpPostedFile  archivo in fuImagen.PostedFiles) {

                    archivo.SaveAs(Server.MapPath("~/Images/") + System.IO.Path.GetFileName(archivo.FileName));

                    /*Segunda forma
                    MyDataSetTableAdapters.tblPostsTableAdapter tblPostsTableAdapter = new MyDataSetTableAdapters.tblPostsTableAdapter();
                    tblPostsTableAdapter.Insert(txtNombreImagen.Text, archivo.FileName.Split('\\')[4], DateTime.Now, 0,0);
                    */
                 
                      tblPost tblPost = new tblPost();
                    tblPost.Imagen = System.IO.Path.GetFileName(archivo.FileName);
                    tblPost.Detalle = txtNombreImagen.Text;
                    tblPost.Likes = 0;
                    tblPost.Views = 0;
                    tblPost.Fecha = DateTime.Now;
                    mydataEntities.tblPosts.Add(tblPost);


                   /*Primera forma
                    SqlCommand sqlCommand = new SqlCommand("insert into tblPosts(detalle, imagen) values (@detalle, @imagen)", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@detalle", txtNombreImagen.Text);
                    sqlCommand.Parameters.AddWithValue("@imagen", archivo.FileName.Split('\\')[4]);

                    sqlCommand.ExecuteNonQuery();
                    */
                   //  imgImagenCargada.ImageUrl = "/Images/" + archivo.FileName;



                }
                mydataEntities.SaveChanges();
                //sqlConnection.Close();
                Actualizar();
                
            }
          
        }

        private void Actualizar() {
            /*Primera forma
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("select * from tblPosts order by id desc", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

    */

            mydataEntities mydataEntities = new mydataEntities();

            /*Segunda forma
            MyDataSetTableAdapters.tblPostsTableAdapter tblPostsTableAdapter = new MyDataSetTableAdapters.tblPostsTableAdapter();
           dliImages.DataSource = tblPostsTableAdapter.GetData().OrderByDescending(x => x.Id).ToList();
           */
           dliImages.DataSource = mydataEntities.tblPosts.OrderByDescending(x => x.Id).ToList();
            dliImages.DataBind();
           // sqlConnection.Close();
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                Button btn = (Button)sender;
                
                SqlCommand sqlCommand = new SqlCommand("update tblPosts set Likes=Likes + 1 where Id =@id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(btn.CommandArgument));
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand("insert into tblLikes(PostID, Operacion) values (@id, 0)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(btn.CommandArgument));
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();
                

            }
            catch (Exception)
            {

                sqlTransaction.Rollback();
            }
            finally
            {
                sqlConnection.Close();
            }



        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
            try
            {
                /*
                SqlCommand sqlCommand = new SqlCommand("update tblPosts set Likes=Likes - 1 where Id =@id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(btn.CommandArgument));
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();

                sqlCommand = new SqlCommand("insert into tblLikes(PostID, Operacion) values (@id, 1)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(btn.CommandArgument));
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();

                */
                Button btn = (Button)sender;
                SqlCommand sqlCommand = new SqlCommand("spiAumentaLikes", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@id", int.Parse(btn.CommandArgument));
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Transaction = sqlTransaction;
                sqlCommand.ExecuteNonQuery();

                sqlTransaction.Commit();


            }
            catch (Exception)
            {

                sqlTransaction.Rollback();
            }
            finally
            {
                sqlConnection.Close();
            }

        }
    }
    }
