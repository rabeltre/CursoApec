using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeraApp
{
    public partial class WebDataReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           ReportViewer1.LocalReport.Refresh();
        }

        protected void cmdGeneraReporte_Click(object sender, EventArgs e)
        {
            Warning[] warning;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            MyDataSetTableAdapters.CustomersTableAdapter customersTableAdapter = new MyDataSetTableAdapters.CustomersTableAdapter();

            ReportViewer1.LocalReport.DataSources.Clear();

           ReportDataSource rds = new ReportDataSource("MyDataCurso", (object) customersTableAdapter.GetData().Where(x => x.Country == txtCiudad.Text).ToList());

            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();

            byte[] bytes = ReportViewer1.LocalReport.Render(
                "PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warning);

            using (FileStream fs = new FileStream(Server.MapPath("output.pdf"), FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            };
            Response.Redirect("output.pdf");
        }
    }
}