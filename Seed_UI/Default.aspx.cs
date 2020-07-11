using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_BL;
using System.Drawing;
using System.Web.UI.DataVisualization.Charting;


public partial class _Default : System.Web.UI.Page
{
    DataTable dt = new DataTable();
    ReportsBL objr = new ReportsBL();
    protected void Page_Load(object sender, EventArgs e)
    {
        // no. of Permits
        dt = objr.GetCount("Id");
        lbldaypermits.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Iw");
        lblweekpermits.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Im");
        lblmntpermits.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Iy");
        lblyearpermits.Text = dt.Rows[0][0].ToString();

        //No of Farmers purchased
        dt = objr.GetCount("Dd");
        lblfrmrday.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Dw");
        lblfrmrweek.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Dm");
        lblfrmrmnth.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Dy");
        lblfrmryear.Text = dt.Rows[0][0].ToString();

        //stock received by sale points
        dt = objr.GetCount("Sd");
        lblstockday.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Sw");
        lblstockweek.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Sm");
        lblstockmonth.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Sy");
        lblstockyear.Text = dt.Rows[0][0].ToString();


        //Qty of Seed Purchased
        dt = objr.GetCount("Qd");
        lblseedday.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Qw");
        lblseedweek.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Qm");
        lblseedmnth.Text = dt.Rows[0][0].ToString();

        dt = objr.GetCount("Qy");
        lblseedyear.Text = dt.Rows[0][0].ToString();


        //Amount Paid
        //dt = objr.GetCount("Ad");
        //lblamtday.Text = dt.Rows[0][0].ToString();

        //dt = objr.GetCount("Aw");
        //lblamtweek.Text = dt.Rows[0][0].ToString();

        //dt = objr.GetCount("Am");
        //lblamtmnth.Text = dt.Rows[0][0].ToString();

        //dt = objr.GetCount("Ay");
        //lblamtyear.Text = dt.Rows[0][0].ToString();

        //Farmers Registered
        //dt = objr.GetCount("Fd");
        //farmerday.Text = dt.Rows[0][0].ToString();

        //dt = objr.GetCount("Fw");
        //farmerweek.Text = dt.Rows[0][0].ToString();

        //dt = objr.GetCount("Fm");
        //farmermnth.Text = dt.Rows[0][0].ToString();

        //dt = objr.GetCount("Fy");
        //farmeryear.Text = dt.Rows[0][0].ToString();

        //LoadChart();
    }

    protected void LoadChart()
    {
        //dt = objr.GetCount("CH");
        //Chart1.DataSource = dt;
        //Chart1.DataBind();

        //using (SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
        //{
        //    using (DataSet result = new DataSet())
        //    {
        //        result.Tables.Add(dt);
        //        result.Load(dr, LoadOption.OverwriteChanges, dt);

        //        if (result.Tables[0].Rows.Count > 0)
        //        {
        //            Chart1.BorderSkin.SkinStyle = BorderSkinStyle.FrameThin3;
        //            Chart1.BackColor = Color.Teal;


        //            Chart1.ChartAreas.Add("chtArea");
        //            Chart1.ChartAreas[0].AxisX.Title = "Village";
        //            Chart1.ChartAreas[0].AxisX.Interval = 1;
        //            Chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
        //            Chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        //            Chart1.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);
        //            Chart1.ChartAreas[0].AxisY.Title = "Anemia Level";
        //            Chart1.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Verdana", 8, System.Drawing.FontStyle.Bold);

        //            Chart1.Series.Add("Mild");
        //            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.Column;
        //            Chart1.Series[0].Points.DataBindXY(result.Tables[0].DefaultView, "vlg_name_hindi", result.Tables[0].DefaultView, "anemic");
        //            Chart1.Series[0].IsVisibleInLegend = true;
        //            Chart1.Series[0].IsValueShownAsLabel = true;
        //            Chart1.Series[0].ToolTip = "#VALY{G}";
        //            Chart1.Series[0]["PixelPointWidth"] = "20";
        //            Chart1.Series[0].Color = Color.Goldenrod;

        //            Chart1.Legends.Add("Anemia Level");
        //            Chart1.Legends[0].LegendStyle = LegendStyle.Table;
        //            Chart1.Legends[0].TableStyle = LegendTableStyle.Wide;
        //            Chart1.Legends[0].Docking = Docking.Bottom;
        //        }
        //    }

        //}
    }


}