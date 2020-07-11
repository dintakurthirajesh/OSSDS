using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using System.IO;
using Microsoft.Reporting.WebForms;
public partial class Admin_DistWiseDistribution : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    DataTable dt = new DataTable();
    ReportsBL rprt = new ReportsBL();
    MasterBAL objcrop = new MasterBAL();
    MasterBAL mastbal = new MasterBAL();
    decimal gntsallot = 0, gntspost = 0, gntssales = 0, gnhaallot = 0, gnhapost = 0, gnhasales = 0, gntshaallot = 0, gntshapost = 0, gntshasales = 0, bgtsallot = 0, bgtspost = 0, bgtssales = 0,
           bghaallot = 0, bghapost = 0, bghasales = 0, bgnsallot = 0, bgnspost = 0, bgnssales = 0, bgtshansallot = 0, bgtshanspost = 0, bgtshanssales = 0, pdtsallot = 0, pdtspost = 0, pdtssales = 0
           , jwtsallot = 0, jwtspost = 0, jwtssales = 0, mztsallot = 0, mztspost = 0, mztssales = 0, bggtsallot = 0, bggtspost = 0, bggtssales = 0, gggtsallot = 0, gggtspost = 0, gggtssales = 0
           , rgtsallot = 0, rgtspost = 0, rgtssales = 0, sstsallot = 0, sstspost = 0, sstssales = 0, sftsallot = 0, sftspost = 0, sftssales = 0, dntsallot = 0, dntspost = 0, dntssales = 0
           , shtsallot = 0, shtspost = 0, shtssales = 0, rabiallot = 0, rabipost = 0, rabisales = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "Admin")
        {
            Response.Redirect("~/Error.aspx");
        }
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            
        }
    }
  
    protected void GetData(object sender, EventArgs e)
    {
        try
        {
            if (ddlyear.SelectedIndex == 0)
            {
                cf.ShowAlertMessage("Please select Year");
                ddlyear.Focus();
                return;
            }
            if (seasons.SelectedIndex == 0)
            {
                cf.ShowAlertMessage("Please select Season");
                seasons.Focus();
                return;
            }
           
            dt = new DataTable();
            dt = rprt.GetDistWsAllReport(ddlyear.SelectedValue, seasons.SelectedValue);
            Session["dtdata"] = dt;
            dt = new DataTable();
            dt = mastbal.GetNewDitricts(Session["StateCode"].ToString());
            if (dt.Rows.Count > 0)
            {
                gridviewdistrictwise.DataSource = dt;
                gridviewdistrictwise.DataBind();
            }
            else
            {
                cf.ShowAlertMessage("No data found");
            }
        }
        catch (Exception ex)
        {
          //  ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            //Response.Redirect("~/Error.aspx");
        }
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void seasons_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {

        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";

        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("content-disposition", "attachment;filename=DailySeedDistributionDetails.xls");
        gridviewdistrictwise.GridLines = GridLines.Both;
        gridviewdistrictwise.HeaderStyle.Font.Bold = true;
        gridviewdistrictwise.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void gridviewdistrictwise_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // Adding a column manually once the header created
        if (e.Row.RowType == DataControlRowType.Header) // If header created
        {
            GridView ProductGrid = (GridView)sender;

            // Creating a Row
                GridViewRow gvrow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell cell0 = new TableCell();
                cell0.Text = "Sl.No";
                cell0.HorizontalAlign = HorizontalAlign.Center;
                cell0.ColumnSpan = 1;
                cell0.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell0.ForeColor = System.Drawing.Color.White;
                TableCell sldistrict = new TableCell();
                sldistrict.Text = "District";
                sldistrict.HorizontalAlign = HorizontalAlign.Center;
                sldistrict.ColumnSpan = 1;
                sldistrict.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                sldistrict.ForeColor = System.Drawing.Color.White;
                TableCell cell1 = new TableCell();
                cell1.Text = "Ground nut";
                cell1.HorizontalAlign = HorizontalAlign.Center;
                cell1.ColumnSpan = 9;
         
                cell1.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell1.ForeColor = System.Drawing.Color.White;
                TableCell cell2 = new TableCell();
                cell2.Text = "Bengal gram";
                cell2.HorizontalAlign = HorizontalAlign.Center;
                cell2.ColumnSpan = 12;
                cell2.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell2.ForeColor = System.Drawing.Color.White;

                TableCell cell3 = new TableCell();
                cell3.Text = "Paddy ";
                cell3.HorizontalAlign = HorizontalAlign.Center;
                cell3.ColumnSpan = 3;
                cell3.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell3.ForeColor = System.Drawing.Color.White;
            
                TableCell cell4 = new TableCell();
                cell4.Text = "Jowar";
                cell4.HorizontalAlign = HorizontalAlign.Center;
                cell4.ColumnSpan = 3;
                cell4.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell4.ForeColor = System.Drawing.Color.White;

                TableCell cell5= new TableCell();
                cell5.Text = "Maize";
                cell5.HorizontalAlign = HorizontalAlign.Center;
                cell5.ColumnSpan = 3;
                cell5.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell5.ForeColor = System.Drawing.Color.White;
                TableCell cell6 = new TableCell();
                cell6.Text = "Black Gram";
                cell6.HorizontalAlign = HorizontalAlign.Center;
                cell6.ColumnSpan = 3;
                cell6.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell6.ForeColor = System.Drawing.Color.White;
                TableCell cell7 = new TableCell();
                cell7.Text = "Green Gram";
                cell7.HorizontalAlign = HorizontalAlign.Center;
                cell7.ColumnSpan = 3;
                cell7.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell7.ForeColor = System.Drawing.Color.White;
                TableCell cell8 = new TableCell();
                cell8.Text = "Red Gram";
                cell8.HorizontalAlign = HorizontalAlign.Center;
                cell8.ColumnSpan = 3;
                cell8.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell8.ForeColor = System.Drawing.Color.White;
                TableCell cell9 = new TableCell();
                cell9.Text = "Sesamum";
                cell9.HorizontalAlign = HorizontalAlign.Center;
                cell9.ColumnSpan = 3;
                cell9.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell9.ForeColor = System.Drawing.Color.White;
                TableCell cell10 = new TableCell();
                cell10.Text = "Sun Flower";
                cell10.HorizontalAlign = HorizontalAlign.Center;
                cell10.ColumnSpan = 3;
                cell10.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell10.ForeColor = System.Drawing.Color.White;

                TableCell cell11 = new TableCell();
                cell11.Text = "Dhai Ncha";
                cell11.HorizontalAlign = HorizontalAlign.Center;
                cell11.ColumnSpan = 3;
                cell11.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell11.ForeColor = System.Drawing.Color.White;
                TableCell cell12 = new TableCell();
                cell12.Text = "Sun Hemp";
                cell12.HorizontalAlign = HorizontalAlign.Center;
                cell12.ColumnSpan = 3;
                cell12.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell12.ForeColor = System.Drawing.Color.White;

                TableCell cell13 = new TableCell();
                cell13.Text = "Rabi Total Fin.Year " + ddlyear.SelectedValue + "";
                cell13.HorizontalAlign = HorizontalAlign.Center;
                cell13.ColumnSpan = 3;
                cell13.RowSpan = 3;
                cell13.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell13.ForeColor = System.Drawing.Color.White;
                gvrow1.Cells.Add(cell0);
                gvrow1.Cells.Add(sldistrict);
                gvrow1.Cells.Add(cell1);
                gvrow1.Cells.Add(cell2);
               gvrow1.Cells.Add(cell3);
               gvrow1.Cells.Add(cell4);
               gvrow1.Cells.Add(cell5);
               gvrow1.Cells.Add(cell6);
               gvrow1.Cells.Add(cell7);
               gvrow1.Cells.Add(cell8);
               gvrow1.Cells.Add(cell9);
               gvrow1.Cells.Add(cell10);
               gvrow1.Cells.Add(cell11);
               gvrow1.Cells.Add(cell12);
               gvrow1.Cells.Add(cell13);  

                //second Row forming
                gridviewdistrictwise.Controls[0].Controls.AddAt(0, gvrow1);


                GridViewRow secondrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell cell21 = new TableCell();
                cell21.Text = "";
                cell21.HorizontalAlign = HorizontalAlign.Center;
                cell21.ColumnSpan = 1;
                cell21.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell21.ForeColor = System.Drawing.Color.White;
                TableCell cell22 = new TableCell();
                cell22.Text = "";
                cell22.HorizontalAlign = HorizontalAlign.Center;
                cell22.ColumnSpan = 1;            
                cell22.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell22.ForeColor = System.Drawing.Color.White;
                TableCell cell23 = new TableCell();
                cell23.Text = "K-6 and other var";
               // cell23.Width = 80;
                cell23.HorizontalAlign = HorizontalAlign.Center;
                cell23.ColumnSpan = 9;
                cell23.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell23.ForeColor = System.Drawing.Color.White;


                //Bengal gram
                TableCell Bengalgram01 = new TableCell();
                Bengalgram01.Text = "JG-11 and other var";
                Bengalgram01.HorizontalAlign = HorizontalAlign.Center;
                Bengalgram01.ColumnSpan = 12;
                Bengalgram01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Bengalgram01.ForeColor = System.Drawing.Color.White;
                //Paddy
                TableCell Paddycell = new TableCell();
                Paddycell.Text = "MTU-1010/ MTU-1001/ RNR-15048/ JG-L18047 /KNM-118 and other var";
                Paddycell.HorizontalAlign = HorizontalAlign.Center;
                Paddycell.ColumnSpan = 3;
            
                Paddycell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Paddycell.ForeColor = System.Drawing.Color.White;

                //Jowar		
                TableCell Jowarcell = new TableCell();
                Jowarcell.Text = "Hybrids and Var";
                Jowarcell.HorizontalAlign = HorizontalAlign.Center;
                Jowarcell.ColumnSpan = 3;
            
                Jowarcell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Jowarcell.ForeColor = System.Drawing.Color.White;

                //Maize		
                TableCell Maizecell = new TableCell();
                Maizecell.Text = "Hybrids and Var";
                Maizecell.HorizontalAlign = HorizontalAlign.Center;
                Maizecell.ColumnSpan = 3;
          
                Maizecell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Maizecell.ForeColor = System.Drawing.Color.White;

                //Black  gram		
                TableCell Blackgramcell = new TableCell();
                Blackgramcell.Text = "PU-31/ LBG-752 and other var";
                Blackgramcell.HorizontalAlign = HorizontalAlign.Center;
                Blackgramcell.ColumnSpan = 3;          
                Blackgramcell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Blackgramcell.ForeColor = System.Drawing.Color.White;

           
                //Green  gram		
                TableCell Greengramcell = new TableCell();
                Greengramcell.Text = "MGG-295 and other var";
                Greengramcell.HorizontalAlign = HorizontalAlign.Center;
                Greengramcell.ColumnSpan = 3;         
                Greengramcell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Greengramcell.ForeColor = System.Drawing.Color.White;
                //Red  gram		
                TableCell Redgramcell = new TableCell();
                Redgramcell.Text = "LRG-41/ICPL-87119/ICPH-2740";
                Redgramcell.HorizontalAlign = HorizontalAlign.Center;
                Redgramcell.ColumnSpan = 3;           
                Redgramcell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Redgramcell.ForeColor = System.Drawing.Color.White;


                //Sesamum		
                TableCell Sesamumcell = new TableCell();
                Sesamumcell.Text = "Swetha and other var";
                Sesamumcell.HorizontalAlign = HorizontalAlign.Center;
                Sesamumcell.ColumnSpan = 3;
                Sesamumcell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Sesamumcell.ForeColor = System.Drawing.Color.White;

                //Sun Flower		
                TableCell SunFlowercell = new TableCell();
                SunFlowercell.Text = "Hybrids and Var";
                SunFlowercell.HorizontalAlign = HorizontalAlign.Center;
                SunFlowercell.ColumnSpan = 3;
                SunFlowercell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                SunFlowercell.ForeColor = System.Drawing.Color.White;


                //Dhai ncha		
                TableCell Dhainchacell = new TableCell();
                Dhainchacell.Text = "T/L";
                Dhainchacell.HorizontalAlign = HorizontalAlign.Center;
                Dhainchacell.ColumnSpan = 3;
                Dhainchacell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Dhainchacell.ForeColor = System.Drawing.Color.White;


                //Sun hemp		
                TableCell Sunhempcell = new TableCell();
                Sunhempcell.Text = "T/L";
                Sunhempcell.HorizontalAlign = HorizontalAlign.Center;
                Sunhempcell.ColumnSpan = 3;
                Sunhempcell.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Sunhempcell.ForeColor = System.Drawing.Color.White;


                secondrow.Cells.Add(cell21);
                secondrow.Cells.Add(cell22);
                secondrow.Cells.Add(cell23);
                secondrow.Cells.Add(Bengalgram01);
                secondrow.Cells.Add(Paddycell);
                secondrow.Cells.Add(Jowarcell);
                secondrow.Cells.Add(Maizecell);
                secondrow.Cells.Add(Blackgramcell);
                secondrow.Cells.Add(Greengramcell);
                secondrow.Cells.Add(Redgramcell);
                secondrow.Cells.Add(Sesamumcell);
                secondrow.Cells.Add(SunFlowercell);
                secondrow.Cells.Add(Dhainchacell);
                secondrow.Cells.Add(Sunhempcell);
           

                //Adding the Row at the 1st position (first row) in the Grid
                gridviewdistrictwise.Controls[0].Controls.AddAt(1, secondrow);
                GridViewRow thirdrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell cell31 = new TableCell();
                cell31.Text = "";
                cell31.HorizontalAlign = HorizontalAlign.Center;
                cell31.ColumnSpan = 1;
                cell31.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell31.ForeColor = System.Drawing.Color.White;
                TableCell cell32 = new TableCell();
                cell32.Text = "";
                cell32.HorizontalAlign = HorizontalAlign.Center;
                cell32.ColumnSpan = 1;
                cell32.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                cell32.ForeColor = System.Drawing.Color.White;
                TableCell third31 = new TableCell();
                third31.Text = "TSSDC";
                third31.HorizontalAlign = HorizontalAlign.Center;
                third31.ColumnSpan = 3;
                third31.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third31.ForeColor = System.Drawing.Color.White;
                TableCell third32 = new TableCell();
                third32.Text = "HACA";
                third32.HorizontalAlign = HorizontalAlign.Center;
                third32.ColumnSpan = 3;
                third32.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third32.ForeColor = System.Drawing.Color.White;
                TableCell third33 = new TableCell();
                third33.Text = "Total";
                third33.HorizontalAlign = HorizontalAlign.Center;
                third33.ColumnSpan = 3;
                third33.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third33.ForeColor = System.Drawing.Color.White;


                //Bengal gram
                TableCell third311 = new TableCell();
                third311.Text = "TSSDC";
                third311.HorizontalAlign = HorizontalAlign.Center;
                third311.ColumnSpan = 3;
                third311.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third311.ForeColor = System.Drawing.Color.White;
                TableCell third312 = new TableCell();
                third312.Text = "HACA";
                third312.HorizontalAlign = HorizontalAlign.Center;
                third312.ColumnSpan = 3;
                third312.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third312.ForeColor = System.Drawing.Color.White;
                TableCell third313 = new TableCell();
                third313.Text = "NSC";
                third313.HorizontalAlign = HorizontalAlign.Center;
                third313.ColumnSpan = 3;
                third313.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third313.ForeColor = System.Drawing.Color.White;
                TableCell third314 = new TableCell();
                third314.Text = "Total";
                third314.HorizontalAlign = HorizontalAlign.Center;
                third314.ColumnSpan = 3;
                third314.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                third314.ForeColor = System.Drawing.Color.White;
                //Paddy
                TableCell Paddycell01 = new TableCell();
                Paddycell01.Text = "TSSDC";
                Paddycell01.HorizontalAlign = HorizontalAlign.Center;
                Paddycell01.ColumnSpan = 3;
                Paddycell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Paddycell01.ForeColor = System.Drawing.Color.White;
                //Jowar
                TableCell Jowarcell01 = new TableCell();
                Jowarcell01.Text = "TSSDC";
                Jowarcell01.HorizontalAlign = HorizontalAlign.Center;
                Jowarcell01.ColumnSpan = 3;
                Jowarcell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Jowarcell01.ForeColor = System.Drawing.Color.White;
                //Maize
                TableCell Maizecell01 = new TableCell();
                Maizecell01.Text = "TSSDC";
                Maizecell01.HorizontalAlign = HorizontalAlign.Center;
                Maizecell01.ColumnSpan = 3;
                Maizecell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Maizecell01.ForeColor = System.Drawing.Color.White;

                //Black  gram
                TableCell Blackgreamcell01 = new TableCell();
                Blackgreamcell01.Text = "TSSDC";
                Blackgreamcell01.HorizontalAlign = HorizontalAlign.Center;
                Blackgreamcell01.ColumnSpan = 3;
                Blackgreamcell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Blackgreamcell01.ForeColor = System.Drawing.Color.White;

                //Green  gram
                TableCell Greengreamcell01 = new TableCell();
                Greengreamcell01.Text = "TSSDC";
                Greengreamcell01.HorizontalAlign = HorizontalAlign.Center;
                Greengreamcell01.ColumnSpan = 3;
                Greengreamcell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Greengreamcell01.ForeColor = System.Drawing.Color.White;
                //Red  gram
                TableCell Redgreamcell01 = new TableCell();
                Redgreamcell01.Text = "TSSDC";
                Redgreamcell01.HorizontalAlign = HorizontalAlign.Center;
                Redgreamcell01.ColumnSpan = 3;
                Redgreamcell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Redgreamcell01.ForeColor = System.Drawing.Color.White;

                //Sesamum
                TableCell Sesamumcell01 = new TableCell();
                Sesamumcell01.Text = "TSSDC";
                Sesamumcell01.HorizontalAlign = HorizontalAlign.Center;
                Sesamumcell01.ColumnSpan = 3;
                Sesamumcell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Sesamumcell01.ForeColor = System.Drawing.Color.White;

                //Sun Flower
                TableCell Sunflowercell01 = new TableCell();
                Sunflowercell01.Text = "TSSDC";
                Sunflowercell01.HorizontalAlign = HorizontalAlign.Center;
                Sunflowercell01.ColumnSpan = 3;
                Sunflowercell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Sunflowercell01.ForeColor = System.Drawing.Color.White;

                //Dhai ncha
                TableCell Dhainchacell01 = new TableCell();
                Dhainchacell01.Text = "TSSDC";
                Dhainchacell01.HorizontalAlign = HorizontalAlign.Center;
                Dhainchacell01.ColumnSpan = 3;
                Dhainchacell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Dhainchacell01.ForeColor = System.Drawing.Color.White;
               // Sun hemp
                TableCell Sunhempcell01 = new TableCell();
                Sunhempcell01.Text = "TSSDC";
                Sunhempcell01.HorizontalAlign = HorizontalAlign.Center;
                Sunhempcell01.ColumnSpan = 3;
                Sunhempcell01.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
                Sunhempcell01.ForeColor = System.Drawing.Color.White;

                thirdrow.Cells.Add(cell31);
                thirdrow.Cells.Add(cell32);
                thirdrow.Cells.Add(third31);
                thirdrow.Cells.Add(third32);
                thirdrow.Cells.Add(third33);
                thirdrow.Cells.Add(third311);
                thirdrow.Cells.Add(third312);
                thirdrow.Cells.Add(third313);
                thirdrow.Cells.Add(third314);
                thirdrow.Cells.Add(Paddycell01);
                thirdrow.Cells.Add(Jowarcell01);
                thirdrow.Cells.Add(Maizecell01);
                thirdrow.Cells.Add(Blackgreamcell01);
                thirdrow.Cells.Add(Greengreamcell01);
                thirdrow.Cells.Add(Redgreamcell01);
                thirdrow.Cells.Add(Sesamumcell01);
                thirdrow.Cells.Add(Sunflowercell01);
                thirdrow.Cells.Add(Dhainchacell01);
                thirdrow.Cells.Add(Sunhempcell01);

                gridviewdistrictwise.Controls[0].Controls.AddAt(2, thirdrow);


        }
    }
    protected void gridviewdistrictwise_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dtaction = (DataTable)Session["dtdata"];
            Label lbldistrictcode = (Label)e.Row.FindControl("lbldistrictcode");
            //Ground nut:36
            //tssdc code:1
            Label lblgttsalloct = (Label)e.Row.FindControl("lblgntsallowat");
            Label lblgttspos = (Label)e.Row.FindControl("lblgntsPositioned");
            Label lblgttssales = (Label)e.Row.FindControl("lblgntsSales");

            DataRow[] result = dtaction.Select("crop='36' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result)
            {
                lblgttsalloct.Text = row[6].ToString();
                lblgttspos.Text = row[7].ToString();
                lblgttssales.Text = row[9].ToString();

                gntsallot += Convert.ToDecimal(row[6].ToString());
                gntspost += Convert.ToDecimal(row[7].ToString());
                gntssales += Convert.ToDecimal(row[9].ToString());
             
            }
            //Haca code:4
            Label lblgthatsalloct = (Label)e.Row.FindControl("lblgnhacallowat");
            Label lblgthatspos = (Label)e.Row.FindControl("lblgnhacPositioned");
            Label lblgthatssales = (Label)e.Row.FindControl("lblhactsSales");
            DataRow[] result1 = dtaction.Select("crop='36' AND agency_code = '4' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result1)
            {
                lblgthatsalloct.Text = row[6].ToString();
                lblgthatspos.Text = row[7].ToString();
                lblgthatssales.Text = row[9].ToString();
                gnhaallot += Convert.ToDecimal(row[6].ToString());
                gnhapost += Convert.ToDecimal(row[7].ToString());
                gnhasales += Convert.ToDecimal(row[9].ToString());
            }
            //Ground nut total
            Label lblgttotsalloct = (Label)e.Row.FindControl("lblgntotallowat");
            Label lblgttotspos = (Label)e.Row.FindControl("lblgntotPositioned");
            Label lblgttotssales = (Label)e.Row.FindControl("lbltotSales");
            lblgttotsalloct.Text = (Convert.ToDecimal(lblgttsalloct.Text) + Convert.ToDecimal(lblgthatsalloct.Text)).ToString();
            lblgttotspos.Text = (Convert.ToDecimal(lblgthatspos.Text) + Convert.ToDecimal(lblgttspos.Text)).ToString();
            lblgttotssales.Text = (Convert.ToDecimal(lblgttssales.Text) + Convert.ToDecimal(lblgthatssales.Text)).ToString();

            gntshaallot += Convert.ToDecimal(lblgttotsalloct.Text);
            gntshapost += Convert.ToDecimal(lblgttotspos.Text);
            gntshasales += Convert.ToDecimal(lblgttotssales.Text);
            //Bengal gram
            //Bengal gram TSSDC

            Label lblbgtsallowat = (Label)e.Row.FindControl("lblbgtsallowat");
            Label lblbgtsPositioned = (Label)e.Row.FindControl("lblbgtsPositioned");
            Label lblbgtsSales = (Label)e.Row.FindControl("lblbgtsSales");

            DataRow[] result2 = dtaction.Select("crop='34' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result2)
            {
                lblbgtsallowat.Text = row[6].ToString();
                lblbgtsPositioned.Text = row[7].ToString();
                lblbgtsSales.Text = row[9].ToString();
                bgtsallot += Convert.ToDecimal(row[6].ToString());
                bgtspost += Convert.ToDecimal(row[7].ToString());
                bgtssales += Convert.ToDecimal(row[9].ToString());
               
            }

            //Bengal gram HACA

            Label lblbghacallowat = (Label)e.Row.FindControl("lblbghacallowat");
            Label lblbghacPositioned = (Label)e.Row.FindControl("lblbghacPositioned");
            Label lblbghacSales = (Label)e.Row.FindControl("lblbghacSales");

            DataRow[] result3 = dtaction.Select("crop='34' AND agency_code = '4' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result3)
            {
                lblbghacallowat.Text = row[6].ToString();
                lblbghacPositioned.Text = row[7].ToString();
                lblbghacSales.Text = row[9].ToString();

                bghaallot += Convert.ToDecimal(row[6].ToString());
                bghapost += Convert.ToDecimal(row[7].ToString());
                bghasales += Convert.ToDecimal(row[9].ToString());
            }
            //Bengal gram NSC

            Label lblbgnscallowat = (Label)e.Row.FindControl("lblbgnscallowat");
            Label lblbgnscPositioned = (Label)e.Row.FindControl("lblbgnscPositioned");
            Label lblbgnscSales = (Label)e.Row.FindControl("lblbgnscSales");

            DataRow[] result4 = dtaction.Select("crop='34' AND agency_code = '3' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result4)
            {
                lblbgnscallowat.Text = row[6].ToString();
                lblbgnscPositioned.Text = row[7].ToString();
                lblbgnscSales.Text = row[9].ToString();
                bgnsallot += Convert.ToDecimal(row[6].ToString());
                bgnspost += Convert.ToDecimal(row[7].ToString());
                bgnssales += Convert.ToDecimal(row[9].ToString());
            }

            //Bengal gram tottal

            Label lblbgtotallowat = (Label)e.Row.FindControl("lblbgtotallowat");
            Label lblbgtotPositioned = (Label)e.Row.FindControl("lblbgtotPositioned");
            Label lblbgtotSales = (Label)e.Row.FindControl("lblbgtotSales");

            lblbgtotallowat.Text = (Convert.ToDecimal(lblbgtsallowat.Text) + Convert.ToDecimal(lblbghacallowat.Text) + Convert.ToDecimal(lblbgnscallowat.Text)).ToString();
            lblbgtotPositioned.Text = (Convert.ToDecimal(lblbgtsPositioned.Text) + Convert.ToDecimal(lblbghacPositioned.Text) + Convert.ToDecimal(lblbgnscPositioned.Text)).ToString();
            lblbgtotSales.Text = (Convert.ToDecimal(lblbgtsSales.Text) + Convert.ToDecimal(lblbghacSales.Text) + Convert.ToDecimal(lblbgnscSales.Text)).ToString();

            bgtshansallot += Convert.ToDecimal(lblbgtotallowat.Text);
            bgtshanspost += Convert.ToDecimal(lblbgtotPositioned.Text);
            bgtshanssales += Convert.ToDecimal(lblbgtotSales.Text);
            //Paddy tssdc
            Label lblpdtsallowat = (Label)e.Row.FindControl("lblpdtsallowat");
            Label lblpdtsPositioned = (Label)e.Row.FindControl("lblpdtsPositioned");
            Label lblpdtsSales = (Label)e.Row.FindControl("lblpdtsSales");

            DataRow[] result5 = dtaction.Select("crop='25' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result5)
            {
                lblpdtsallowat.Text = row[6].ToString();
                lblpdtsPositioned.Text = row[7].ToString();
                lblpdtsSales.Text = row[9].ToString();
                pdtsallot += Convert.ToDecimal(row[6].ToString());
                pdtspost += Convert.ToDecimal(row[7].ToString());
                pdtssales += Convert.ToDecimal(row[9].ToString());
            }
            //Jowar TSSDC
            Label lbljwtsallowat = (Label)e.Row.FindControl("lbljwtsallowat");
            Label lbljwtsPositioned = (Label)e.Row.FindControl("lbljwtsPositioned");
            Label lbljwtsSales = (Label)e.Row.FindControl("lbljwtsSales");

            DataRow[] result6 = dtaction.Select("crop='26' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result6)
            {
                lbljwtsallowat.Text = row[6].ToString();
                lbljwtsPositioned.Text = row[7].ToString();
                lbljwtsSales.Text = row[9].ToString();
                jwtsallot += Convert.ToDecimal(row[6].ToString());
                jwtspost += Convert.ToDecimal(row[7].ToString());
                jwtssales += Convert.ToDecimal(row[9].ToString());
            }
            //MAize TSSDC
            Label lblmztsallowat = (Label)e.Row.FindControl("lblmztsallowat");
            Label lblmztsPositioned = (Label)e.Row.FindControl("lblmztsPositioned");
            Label lblmztsSales = (Label)e.Row.FindControl("lblmztsSales");

            DataRow[] result7 = dtaction.Select("crop='28' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result7)
            {
                lblmztsallowat.Text = row[6].ToString();
                lblmztsPositioned.Text = row[7].ToString();
                lblmztsSales.Text = row[9].ToString();
               mztsallot += Convert.ToDecimal(row[6].ToString());
                mztspost += Convert.ToDecimal(row[7].ToString());
               mztssales += Convert.ToDecimal(row[9].ToString());
            }

            //Black Gram TSSDC
            Label lblbggtsallowat = (Label)e.Row.FindControl("lblbggtsallowat");
            Label lblbggtsPositioned = (Label)e.Row.FindControl("lblbggtsPositioned");
            Label lblbggtsSales = (Label)e.Row.FindControl("lblbggtsSales");

            DataRow[] result8 = dtaction.Select("crop='33' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result8)
            {
                lblbggtsallowat.Text = row[6].ToString();
                lblbggtsPositioned.Text = row[7].ToString();
                lblbggtsSales.Text = row[9].ToString();
                bggtsallot += Convert.ToDecimal(row[6].ToString());
                bggtspost += Convert.ToDecimal(row[7].ToString());
                bggtssales += Convert.ToDecimal(row[9].ToString());
            }


            //Green Gram TSSDC
            Label lblggtsallowat = (Label)e.Row.FindControl("lblggtsallowat");
            Label lblggtsPositioned = (Label)e.Row.FindControl("lblggtsPositioned");
            Label lblggtsSales = (Label)e.Row.FindControl("lblggtsSales");

            DataRow[] result9 = dtaction.Select("crop='32' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result9)
            {
                lblggtsallowat.Text = row[6].ToString();
                lblggtsPositioned.Text = row[7].ToString();
                lblggtsSales.Text = row[9].ToString();
                gggtsallot += Convert.ToDecimal(row[6].ToString());
                gggtspost += Convert.ToDecimal(row[7].ToString());
               gggtssales += Convert.ToDecimal(row[9].ToString());
            }
            //Red Gram TSSDC
            Label lblrgtsallowat = (Label)e.Row.FindControl("lblrgtsallowat");
            Label lblrgtsPositioned = (Label)e.Row.FindControl("lblrgtsPositioned");
            Label lblrgtsSales = (Label)e.Row.FindControl("lblrgtsSales");

            DataRow[] result10 = dtaction.Select("crop='31' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result10)
            {
                lblrgtsallowat.Text = row[6].ToString();
                lblrgtsPositioned.Text = row[7].ToString();
                lblrgtsSales.Text = row[9].ToString();
                rgtsallot += Convert.ToDecimal(row[6].ToString());
               rgtspost += Convert.ToDecimal(row[7].ToString());
                rgtssales += Convert.ToDecimal(row[9].ToString());
            }
            //Sesamum TSSDC
            Label lblsmtsallowat = (Label)e.Row.FindControl("lblsmtsallowat");
            Label lblsmtsPositioned = (Label)e.Row.FindControl("lblsmtsPositioned");
            Label lblsmtsSales = (Label)e.Row.FindControl("lblsmtsSales");

            DataRow[] result11 = dtaction.Select("crop='38' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result11)
            {
                lblsmtsallowat.Text = row[6].ToString();
                lblsmtsPositioned.Text = row[7].ToString();
                lblsmtsSales.Text = row[9].ToString();
                sstsallot += Convert.ToDecimal(row[6].ToString());
                sstspost += Convert.ToDecimal(row[7].ToString());
                sstssales += Convert.ToDecimal(row[9].ToString());
            }
            //Sun Flower TSSDC
            Label lblsftsallowat = (Label)e.Row.FindControl("lblsftsallowat");
            Label lblsftsPositioned = (Label)e.Row.FindControl("lblsftsPositioned");
            Label lblsftsSales = (Label)e.Row.FindControl("lblsftsSales");

            DataRow[] result12 = dtaction.Select("crop='39' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result12)
            {
                lblsftsallowat.Text = row[6].ToString();
                lblsftsPositioned.Text = row[7].ToString();
                lblsftsSales.Text = row[9].ToString();
                sftsallot += Convert.ToDecimal(row[6].ToString());
                sftspost += Convert.ToDecimal(row[7].ToString());
                sftssales += Convert.ToDecimal(row[9].ToString());
            }

            //Dhai ncha TSSDC
            Label lbldntsallowat = (Label)e.Row.FindControl("lbldntsallowat");
            Label lbldntsPositioned = (Label)e.Row.FindControl("lbldntsPositioned");
            Label lbldntsSales = (Label)e.Row.FindControl("lbldntsSales");

            DataRow[] result13 = dtaction.Select("crop='42' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result13)
            {
                lbldntsallowat.Text = row[6].ToString();
                lbldntsPositioned.Text = row[7].ToString();
                lbldntsSales.Text = row[9].ToString();
                dntsallot += Convert.ToDecimal(row[6].ToString());
                dntspost += Convert.ToDecimal(row[7].ToString());
               dntssales += Convert.ToDecimal(row[9].ToString());
            }

            //Sunhemp TSSDC
            Label lblshtsallowat = (Label)e.Row.FindControl("lblshtsallowat");
            Label lblshtsPositioned = (Label)e.Row.FindControl("lblshtsPositioned");
            Label lblshtsSales = (Label)e.Row.FindControl("lblshtsSales");

            DataRow[] result14 = dtaction.Select("crop='43' AND agency_code = '1' and districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result14)
            {
                lblshtsallowat.Text = row[6].ToString();
                lblshtsPositioned.Text = row[7].ToString();
                lblshtsSales.Text = row[9].ToString();
               shtsallot += Convert.ToDecimal(row[6].ToString());
                shtspost += Convert.ToDecimal(row[7].ToString());
                shtssales += Convert.ToDecimal(row[9].ToString());
            }
            decimal ALLOT=0;
            decimal POSI = 0;
            decimal SALES = 0;
            DataRow[] result15 = dtaction.Select("districtcode='" + lbldistrictcode.Text + "'");
            foreach (DataRow row in result15)
            {
                if (row[6].ToString() != "")
                {
                    ALLOT +=Convert.ToDecimal(row[6].ToString());
                    rabiallot+=Convert.ToDecimal(row[6].ToString());
                }
                if (row[7].ToString() != "")
                {
                    POSI += Convert.ToDecimal(row[7].ToString());
                    rabipost += Convert.ToDecimal(row[7].ToString());
                }
                if (row[9].ToString() != "")
                {
                    SALES += Convert.ToDecimal(row[9].ToString());
                   rabisales +=Convert.ToDecimal(row[9].ToString());
                }
              
            }
            Label lblrabiallowat = (Label)e.Row.FindControl("lblrabiallowat");
            Label lblrabiPositioned = (Label)e.Row.FindControl("lblrabiPositioned");
            Label lblrabiSales = (Label)e.Row.FindControl("lblrabiSales");
            lblrabiallowat.Text = ALLOT.ToString();
            lblrabiPositioned.Text = POSI.ToString();
            lblrabiSales.Text = SALES.ToString();

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblgttsalloctf = (Label)e.Row.FindControl("lblgntsallowatf");
            Label lblgttsposf = (Label)e.Row.FindControl("lblgntsPositionedf");
            Label lblgttssalesf = (Label)e.Row.FindControl("lblgntsSalesf");
            lblgttsalloctf.Text = gntsallot.ToString();
            lblgttsposf.Text = gntspost.ToString();
            lblgttssalesf.Text = gntssales.ToString();
            Label lblgthatsalloctf = (Label)e.Row.FindControl("lblgnhacallowatf");
            Label lblgthatsposf = (Label)e.Row.FindControl("lblgnhacPositionedf");
            Label lblgthatssalesf = (Label)e.Row.FindControl("lblhactsSalesf");

            lblgthatsalloctf.Text = gnhaallot.ToString();
            lblgthatsposf.Text = gnhapost.ToString();
            lblgthatssalesf.Text = gnhasales.ToString();

            Label lblgttotsalloctf = (Label)e.Row.FindControl("lblgntotallowatf");
            Label lblgttotsposf = (Label)e.Row.FindControl("lblgntotPositionedf");
            Label lblgttotssalesf = (Label)e.Row.FindControl("lbltotSalesf");

            lblgttotsalloctf.Text = gntshaallot.ToString();
            lblgttotsposf.Text = gntshapost.ToString();
            lblgttotssalesf.Text = gntshasales.ToString();

            Label lblbgtsallowatf = (Label)e.Row.FindControl("lblbgtsallowatf");
            Label lblbgtsPositionedf = (Label)e.Row.FindControl("lblbgtsPositionedf");
            Label lblbgtsSalesf = (Label)e.Row.FindControl("lblbgtsSalesf");
            lblbgtsallowatf.Text = bgtsallot.ToString();
            lblbgtsPositionedf.Text = bgtspost.ToString();
            lblbgtsSalesf.Text = bgtssales.ToString();

            Label lblbghacallowatf = (Label)e.Row.FindControl("lblbghacallowatf");
            Label lblbghacPositionedf = (Label)e.Row.FindControl("lblbghacPositionedf");
            Label lblbghacSalesf = (Label)e.Row.FindControl("lblbghacSalesf");

            lblbghacallowatf.Text = bghaallot.ToString();
            lblbghacPositionedf.Text = bghapost.ToString();
            lblbghacSalesf.Text = bghasales.ToString();
            Label lblbgnscallowatf = (Label)e.Row.FindControl("lblbgnscallowatf");
            Label lblbgnscPositionedf = (Label)e.Row.FindControl("lblbgnscPositionedf");
            Label lblbgnscSalesf = (Label)e.Row.FindControl("lblbgnscSalesf");

            lblbgnscallowatf.Text = bgnsallot.ToString();
            lblbgnscPositionedf.Text = bgnspost.ToString();
            lblbgnscSalesf.Text = bgnssales.ToString();

            Label lblbgtotallowatf = (Label)e.Row.FindControl("lblbgtotallowatf");
            Label lblbgtotPositionedf = (Label)e.Row.FindControl("lblbgtotPositionedf");
            Label lblbgtotSalesf = (Label)e.Row.FindControl("lblbgtotSalesf");
            lblbgtotallowatf.Text = bgtshansallot.ToString();
            lblbgtotPositionedf.Text = bgtshanspost.ToString();
            lblbgtotSalesf.Text = bgtshanssales.ToString();
            //paddy
            Label lblpdtsallowatf = (Label)e.Row.FindControl("lblpdtsallowatf");
            Label lblpdtsPositionedf = (Label)e.Row.FindControl("lblpdtsPositionedf");
            Label lblpdtsSalesf = (Label)e.Row.FindControl("lblpdtsSalesf");
            lblpdtsallowatf.Text = pdtsallot.ToString();
            lblpdtsPositionedf.Text = pdtspost.ToString();
            lblpdtsSalesf.Text = pdtssales.ToString();
            //Jowar TSSDC
            Label lbljwtsallowatf = (Label)e.Row.FindControl("lbljwtsallowatf");
            Label lbljwtsPositionedf = (Label)e.Row.FindControl("lbljwtsPositionedf");
            Label lbljwtsSalesf = (Label)e.Row.FindControl("lbljwtsSalesf");

            lbljwtsallowatf.Text = jwtsallot.ToString();
            lbljwtsPositionedf.Text = jwtspost.ToString();
            lbljwtsSalesf.Text = jwtssales.ToString();
            //MAize TSSDC
            Label lblmztsallowatf = (Label)e.Row.FindControl("lblmztsallowatf");
            Label lblmztsPositionedf = (Label)e.Row.FindControl("lblmztsPositionedf");
            Label lblmztsSalesf = (Label)e.Row.FindControl("lblmztsSalesf");
            lblmztsallowatf.Text = mztsallot.ToString();
            lblmztsPositionedf.Text = mztspost.ToString();
            lblmztsSalesf.Text = mztssales.ToString();
            //Black Gram TSSDC
            Label lblbggtsallowatf = (Label)e.Row.FindControl("lblbggtsallowatf");
            Label lblbggtsPositionedf = (Label)e.Row.FindControl("lblbggtsPositionedf");
            Label lblbggtsSalesf = (Label)e.Row.FindControl("lblbggtsSalesf");

            lblbggtsallowatf.Text = bggtsallot.ToString();
            lblbggtsPositionedf.Text = bggtspost.ToString();
            lblbggtsSalesf.Text = bggtssales.ToString();
            //Green Gram TSSDC
            Label lblggtsallowatf = (Label)e.Row.FindControl("lblggtsallowatf");
            Label lblggtsPositionedf = (Label)e.Row.FindControl("lblggtsPositionedf");
            Label lblggtsSalesf = (Label)e.Row.FindControl("lblggtsSalesf");
            lblggtsallowatf.Text = gggtsallot.ToString();
            lblggtsPositionedf.Text = gggtspost.ToString();
            lblggtsSalesf.Text = gggtssales.ToString();
            //Red Gram TSSDC
            Label lblrgtsallowatf = (Label)e.Row.FindControl("lblrgtsallowatf");
            Label lblrgtsPositionedf = (Label)e.Row.FindControl("lblrgtsPositionedf");
            Label lblrgtsSalesf = (Label)e.Row.FindControl("lblrgtsSalesf");
            lblrgtsallowatf.Text = rgtsallot.ToString();
            lblrgtsPositionedf.Text = rgtspost.ToString();
            lblrgtsSalesf.Text = rgtssales.ToString();

            //Sesamum TSSDC
            Label lblsmtsallowatf = (Label)e.Row.FindControl("lblsmtsallowatf");
            Label lblsmtsPositionedf = (Label)e.Row.FindControl("lblsmtsPositionedf");
            Label lblsmtsSalesf = (Label)e.Row.FindControl("lblsmtsSalesf");
            lblsmtsallowatf.Text = sstsallot.ToString();
            lblsmtsPositionedf.Text = sstspost.ToString();
            lblsmtsSalesf.Text = sstssales.ToString();
            //Sun Flower TSSDC
            Label lblsftsallowatf = (Label)e.Row.FindControl("lblsftsallowatf");
            Label lblsftsPositionedf = (Label)e.Row.FindControl("lblsftsPositionedf");
            Label lblsftsSalesf = (Label)e.Row.FindControl("lblsftsSalesf");
            lblsftsallowatf.Text = sftsallot.ToString();
            lblsftsPositionedf.Text = sftspost.ToString();
            lblsftsSalesf.Text = sftssales.ToString();
            //Dhai ncha TSSDC
            Label lbldntsallowatf = (Label)e.Row.FindControl("lbldntsallowatf");
            Label lbldntsPositionedf = (Label)e.Row.FindControl("lbldntsPositionedf");
            Label lbldntsSalesf = (Label)e.Row.FindControl("lbldntsSalesf");
            lbldntsallowatf.Text = dntsallot.ToString();
            lbldntsPositionedf.Text = dntspost.ToString();
            lbldntsSalesf.Text = dntssales.ToString();
            //Sunhemp TSSDC
            Label lblshtsallowatf = (Label)e.Row.FindControl("lblshtsallowatf");
            Label lblshtsPositionedf = (Label)e.Row.FindControl("lblshtsPositionedf");
            Label lblshtsSalesf = (Label)e.Row.FindControl("lblshtsSalesf");
            lblshtsallowatf.Text = shtsallot.ToString();
            lblshtsPositionedf.Text = shtspost.ToString();
            lblshtsSalesf.Text = shtssales.ToString();
            Label lblrabiallowatf = (Label)e.Row.FindControl("lblrabiallowatf");
            Label lblrabiPositionedf = (Label)e.Row.FindControl("lblrabiPositionedf");
            Label lblrabiSalesf = (Label)e.Row.FindControl("lblrabiSalesf");
             lblrabiallowatf.Text = rabiallot.ToString();
            lblrabiPositionedf.Text = rabipost.ToString();
            lblrabiSalesf.Text = rabisales.ToString();
        }
    }
   
}
