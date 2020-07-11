using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
using Microsoft.Reporting.WebForms;
using System.IO;
public partial class Admin_DistrbutionDetails : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    DataTable dt = new DataTable();
    ReportsBL rprt = new ReportsBL();
    MasterBAL objcrop = new MasterBAL();
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
            BindCrops();
           
        }
    }
    public void BindCrops()
    {
        dt = objcrop.GetCrops();
        cf.BindDropDownLists(ddlcrop, dt, "CropName", "CropCode", "Select Crop Name");
    }
    protected void GetData(object sender, EventArgs e)
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
        if (ddlcrop.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Please select Crop");
            ddlcrop.Focus();
            return;
        }
        else
            GetReport();
    }
    protected void ddlyear_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridviewdistrictwise.Visible = false;
    }
    protected void seasons_SelectedIndexChanged(object sender, EventArgs e)
    {
        gridviewdistrictwise.Visible = false;
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
            cell1.Text = "Number of Farmers";
            cell1.HorizontalAlign = HorizontalAlign.Center;
            cell1.ColumnSpan = 8;
            cell1.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
            cell1.ForeColor = System.Drawing.Color.White;

            TableCell cell2 = new TableCell();
            cell2.Text = "Quantity of Seed Purchased (in Qtls)";
            cell2.HorizontalAlign = HorizontalAlign.Center;
            cell2.ColumnSpan =8;
            cell2.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
            cell2.ForeColor = System.Drawing.Color.White;

            gvrow1.Cells.Add(cell0);
            gvrow1.Cells.Add(sldistrict);
            gvrow1.Cells.Add(cell1);
            gvrow1.Cells.Add(cell2);
           
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
            cell23.Text = "Category";
            // cell23.Width = 80;
            cell23.HorizontalAlign = HorizontalAlign.Center;
            cell23.ColumnSpan = 5;
            cell23.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
            cell23.ForeColor = System.Drawing.Color.White;

            TableCell HeaderCell4 = new TableCell();
            HeaderCell4.Text = "Gender";
            HeaderCell4.HorizontalAlign = HorizontalAlign.Center;
            HeaderCell4.ColumnSpan = 3;
            HeaderCell4.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
            HeaderCell4.ForeColor = System.Drawing.Color.White;

            TableCell qtyCategory = new TableCell();
            qtyCategory.Text = "Category";
            qtyCategory.HorizontalAlign = HorizontalAlign.Center;
            qtyCategory.ColumnSpan = 5;
            qtyCategory.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
            qtyCategory.ForeColor = System.Drawing.Color.White;


            TableCell qtyGender = new TableCell();
            qtyGender.Text = "Gender";
            qtyGender.HorizontalAlign = HorizontalAlign.Center;
            qtyGender.ColumnSpan = 3;
            qtyGender.BackColor = System.Drawing.ColorTranslator.FromHtml("#007DC1");
            qtyGender.ForeColor = System.Drawing.Color.White;

           
            secondrow.Cells.Add(cell21);
            secondrow.Cells.Add(cell22);
            secondrow.Cells.Add(cell23);
           secondrow.Cells.Add(HeaderCell4);
           secondrow.Cells.Add(qtyCategory);
           secondrow.Cells.Add(qtyGender);
            

            //Adding the Row at the 1st position (first row) in the Grid
            gridviewdistrictwise.Controls[0].Controls.AddAt(1, secondrow);

        }
    }
    protected void GetReport()
    {
        try
        {
            dt = new DataTable();
            dt = rprt.GetDistributionDetailsDistWs(ddlyear.SelectedValue, seasons.SelectedValue,ddlcrop.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                gridviewdistrictwise.Visible = true;
                //Rept.LocalReport.DataSources.Clear();
                //Rept.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
                // OR Set Report Path  
                //Rept.LocalReport.ReportPath = HttpContext.Current.Server.MapPath("~/RDLCReports/DistrbutionDetailDistWs.rdlc");
                //Rept.ShowPrintButton = true;
                //// Refresh and Display Report  
                //Rept.LocalReport.Refresh();
                Session["distdata"] = dt;
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
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void linknfsc_Click(object sender, EventArgs e)
    {
        try
        {           
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;

            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
                Session["Backurl"] = this.AppRelativeVirtualPath;
                Session["Backlogurl"] = this.AppRelativeVirtualPath;
                Session["casttype"] = null;
                Session["districtcd"] = null;
                Session["yearcd"] = null;
                Session["season"] = null;
                Session["crop"] = null;
                Session["gender"] = null;
                Session["casttype"] = "sc";
                Session["gender"] = "";
                Session["districtcd"] = districtcd;
                Session["yearcd"] = ddlyear.SelectedValue;
                Session["season"] = seasons.SelectedValue;
                Session["crop"] = ddlcrop.SelectedValue;
                Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");    

        }
        catch
        {
          
        }
    }
    protected void linknfst_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;

            Session["Backurl"] = this.AppRelativeVirtualPath;
            Session["Backlogurl"] = this.AppRelativeVirtualPath;
             Session["casttype"]  =null;
             Session["districtcd"]=null;
             Session["yearcd"]    =null;
             Session["season"]    =null;
             Session["crop"] = null;
             Session["gender"] = null;
            Session["casttype"]   = "st";
            Session["gender"] = "";
            Session["districtcd"] = districtcd;
            Session["yearcd"]     = ddlyear.SelectedValue;
            Session["season"]     = seasons.SelectedValue;
              Session["crop"]     = ddlcrop.SelectedValue;
              Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");            

        }
        catch
        {

        }
    }
    protected void linknfbc_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;

            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            Session["Backurl"] = this.AppRelativeVirtualPath;
            Session["Backlogurl"] = this.AppRelativeVirtualPath;
            Session["casttype"] = null;
            Session["districtcd"] = null;
            Session["yearcd"] = null;
            Session["season"] = null;
            Session["crop"] = null;
            Session["gender"] = null;
            Session["casttype"] = "bc";
            Session["gender"] = "";
            Session["districtcd"] = districtcd;
            Session["yearcd"] = ddlyear.SelectedValue;
            Session["season"] = seasons.SelectedValue;
            Session["crop"] = ddlcrop.SelectedValue;
            Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");          

        }
        catch
        {

        }
    }
    protected void linknfothers_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;

            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            Session["Backurl"] = this.AppRelativeVirtualPath;
            Session["Backlogurl"] = this.AppRelativeVirtualPath;
            Session["casttype"] = null;
            Session["districtcd"] = null;
            Session["yearcd"] = null;
            Session["season"] = null;
            Session["crop"] = null;
            Session["gender"] = null;
            Session["casttype"] = "others";
            Session["gender"] = "";
            Session["districtcd"] = districtcd;
            Session["yearcd"] = ddlyear.SelectedValue;
            Session["season"] = seasons.SelectedValue;
            Session["crop"] = ddlcrop.SelectedValue;
            Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");         

        }
        catch
        {

        }
    }
    protected void linknftotal_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            Session["Backurl"] = this.AppRelativeVirtualPath;
            Session["Backlogurl"] = this.AppRelativeVirtualPath;
            Session["casttype"] = null;
            Session["districtcd"] = null;
            Session["yearcd"] = null;
            Session["season"] = null;
            Session["crop"] = null;
            Session["gender"] = null;
            Session["casttype"] = "all";
            Session["gender"] = "";
            Session["districtcd"] = districtcd;
            Session["yearcd"] = ddlyear.SelectedValue;
            Session["season"] = seasons.SelectedValue;
            Session["crop"] = ddlcrop.SelectedValue;
            Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");          

        }
        catch
        {

        }
    }
    protected void linknfm_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            Session["Backurl"] = this.AppRelativeVirtualPath;
            Session["Backlogurl"] = this.AppRelativeVirtualPath;
            Session["casttype"] = null;
            Session["districtcd"] = null;
            Session["yearcd"] = null;
            Session["season"] = null;
            Session["crop"] = null;
            Session["gender"] = null;
            Session["casttype"] = "";
            Session["gender"] = "m";
            Session["districtcd"] = districtcd;
            Session["yearcd"] = ddlyear.SelectedValue;
            Session["season"] = seasons.SelectedValue;
            Session["crop"] = ddlcrop.SelectedValue;
            Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");          

        }
        catch
        {

        }
    }
    protected void linknff_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            Session["Backurl"] = this.AppRelativeVirtualPath;
            Session["Backlogurl"] = this.AppRelativeVirtualPath;
            Session["casttype"] = null;
            Session["districtcd"] = null;
            Session["yearcd"] = null;
            Session["season"] = null;
            Session["crop"] = null;
            Session["gender"] = null;
            Session["casttype"] = "";
            Session["gender"] = "f";
            Session["districtcd"] = districtcd;
            Session["yearcd"] = ddlyear.SelectedValue;
            Session["season"] = seasons.SelectedValue;
            Session["crop"] = ddlcrop.SelectedValue;
            Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");

        }
        catch
        {

        }
    }
    protected void linkdist_Click(object sender, EventArgs e)
    {
        GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
        string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
        string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
        Session["yearcd"] = ddlyear.SelectedValue;
        Session["season"] = seasons.SelectedValue;
        Session["crop"] = ddlcrop.SelectedValue;
        Session["districtname"] = districtname;
        Session["districtcd"] = districtcd;
        Response.Redirect("~/Admin/DistrbutionDetailsMandalwise.aspx");
    }
    protected void linknffm_Click(object sender, EventArgs e)
    {
        try
        {
            GridViewRow gvr = (GridViewRow)((LinkButton)sender).NamingContainer;
            string districtcd = ((Label)gvr.FindControl("lbldistrictcode")).Text;
            string districtname = ((LinkButton)gvr.FindControl("linkdistrictname")).Text;
            Session["districtname"] = districtname;
            Session["Backurl"] = this.AppRelativeVirtualPath;
           // Session["Backlogurl"] = this.AppRelativeVirtualPath;
            Session["casttype"] = null;
            Session["districtcd"] = null;
            Session["yearcd"] = null;
            Session["season"] = null;
            Session["crop"] = null;
            Session["gender"] = null;
            Session["casttype"] = "";
            Session["gender"] = "";
            Session["districtcd"] = districtcd;
            Session["yearcd"] = ddlyear.SelectedValue;
            Session["season"] = seasons.SelectedValue;
            Session["crop"] = ddlcrop.SelectedValue;
            Response.Redirect("~/Admin/DistrbutionDetailsdrilltofarmerdetails.aspx");

        }
        catch
        {

        }
    }
    protected void gridviewdistrictwise_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        { 
        
        
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            DataTable dtfootercount = (DataTable)Session["distdata"];

            Label lblnftsc = (Label)e.Row.FindControl("lblnftsc");
            Label lblnftst = (Label)e.Row.FindControl("lblnftst");
            Label lblnftbc = (Label)e.Row.FindControl("lblnftbc");
            Label lblnftother = (Label)e.Row.FindControl("lblnftother");
            Label lblnftot = (Label)e.Row.FindControl("lblnftot");
            Label lblnfm = (Label)e.Row.FindControl("lblnftm");
            Label lblnff = (Label)e.Row.FindControl("lblnftf");
            Label lblnfmftot = (Label)e.Row.FindControl("lblnfttotmf");

            Label lblqtsc = (Label)e.Row.FindControl("lblqtsc");
            Label lblqtst = (Label)e.Row.FindControl("lblqtst");
            Label lblqtbc = (Label)e.Row.FindControl("lblqtbc");
            Label lblqtothers = (Label)e.Row.FindControl("lblqtothers");
            Label lblqttot = (Label)e.Row.FindControl("lblqttot");
            Label lblqtm = (Label)e.Row.FindControl("lblqtm");
            Label lblqtf = (Label)e.Row.FindControl("lblqtf");
            Label lblqtmfm = (Label)e.Row.FindControl("lblqtmfm");



            if (dtfootercount.Rows.Count > 0)
            {
                int sumsc = Convert.ToInt32(dtfootercount.Compute("SUM(sc)", string.Empty));
                int sumst = Convert.ToInt32(dtfootercount.Compute("SUM(st)", string.Empty));
                int sumbc = Convert.ToInt32(dtfootercount.Compute("SUM(bc)", string.Empty));
                int sumother = Convert.ToInt32(dtfootercount.Compute("SUM(OTHER)", string.Empty));
                int sumtot = Convert.ToInt32(dtfootercount.Compute("SUM(totFarmers)", string.Empty));
                int summale = Convert.ToInt32(dtfootercount.Compute("SUM(MALE)", string.Empty));
                int sumfemale = Convert.ToInt32(dtfootercount.Compute("SUM(FEMALE)", string.Empty));
                int sumfmtot = Convert.ToInt32(dtfootercount.Compute("SUM(total)", string.Empty));

                lblnftsc.Text = sumsc.ToString();
                lblnftst.Text = sumst.ToString();
                lblnftbc.Text = sumbc.ToString();
                lblnftother.Text = sumother.ToString();
                lblnftot.Text = sumtot.ToString();
                lblnfm.Text = summale.ToString();
                lblnff.Text = sumfemale.ToString();
                lblnfmftot.Text = sumfmtot.ToString();

                int qtsumsc = Convert.ToInt32(dtfootercount.Compute("SUM(SC_QTY)", string.Empty));
                int qtsumst = Convert.ToInt32(dtfootercount.Compute("SUM(ST_QTY)", string.Empty));
                int qtsumbc = Convert.ToInt32(dtfootercount.Compute("SUM(BC_QTY)", string.Empty));
                int qtsumother = Convert.ToInt32(dtfootercount.Compute("SUM(Other_QTY)", string.Empty));
                int qtsumtot = Convert.ToInt32(dtfootercount.Compute("SUM(totQty)", string.Empty));
                int qtsummale = Convert.ToInt32(dtfootercount.Compute("SUM(M_QTY)", string.Empty));
                int qtsumfemale = Convert.ToInt32(dtfootercount.Compute("SUM(F_QTY)", string.Empty));
                int qtsumfmtot = Convert.ToInt32(dtfootercount.Compute("SUM(totalQty)", string.Empty));

                lblqtsc.Text = qtsumsc.ToString();
                lblqtst.Text = qtsumst.ToString();
                lblqtbc.Text = qtsumbc.ToString();
                lblqtothers.Text = qtsumother.ToString();
                lblqttot.Text = qtsumtot.ToString();
                lblqtm.Text = qtsummale.ToString();
                lblqtf.Text = qtsumfemale.ToString();
                lblqtmfm.Text = qtsumfmtot.ToString();

            }
        }
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
        Response.AddHeader("content-disposition", "attachment;filename=SeedDistributionDetails.xls");
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
}