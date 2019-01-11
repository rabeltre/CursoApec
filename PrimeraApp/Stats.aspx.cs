using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimeraApp
{
    public partial class Stats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MyDataSetTableAdapters.tblPostsTableAdapter tblPostsTableAdapter = new MyDataSetTableAdapters.tblPostsTableAdapter();


            chartLike.DataSource = tblPostsTableAdapter.GetData().ToList();
            chartLike.Series[0].XValueMember = "Detalle";
            chartLike.Series[0].YValueMembers = "Likes";
            chartLike.Series[0].Label = "#VALX ---- #VALY POR #PERCENT";

       


            Color[] myColores = new Color[3] { Color.Green,  Color.Red, Color.Yellow};
            chartLike.Palette = System.Web.UI.DataVisualization.Charting.ChartColorPalette.None;
            chartLike.PaletteCustomColors = myColores;

            chartLike.DataBind();
        }
    }
}