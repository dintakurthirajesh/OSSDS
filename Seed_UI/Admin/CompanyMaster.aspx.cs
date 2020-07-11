using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;

public partial class Admin_CompanyMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objvalid = new Validate();
    string UserName = "";
    DataTable dt1;
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void Page_Load(object sender, EventArgs e)
    {
        //Htpp Referer Check
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
        UserName = Session["UsrName"].ToString();
        lblUsrName.Text = Session["Role"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (!IsPostBack)
        {
            this.txt_Date.Text = DateTime.Today.ToString("dd/MM/yyyy");
            viewdata();
            btn_Update.Visible = false;
        }
    }
    private void viewdata()
    {
        dt1 = new DataTable();
        dt1 = objDist.GetCompany();
        if (dt1.Rows.Count > 0)
        {
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (txt_Date.Text == "")
            {
                objCommon.ShowAlertMessage("Please Select From Date");
                return;
            }
            else
            {
                if (!objvalid.IsDate(txt_Date.Text.Trim()))
                {
                    objCommon.ShowAlertMessage("Please Enter Valid date");
                    return;
                }
            }
            if (txtcmnyName.Text == "")
            {
                objCommon.ShowAlertMessage("Enter Company Name");
                return;
            }
            int ActiveSt = (rbnSn.Checked ? 0 : (rbnSy.Checked ? 1 : 0));
            DateTime date = DateTime.Parse(txt_Date.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
            dt1 = new DataTable();
            dt1 = objDist.InsertCompany(txtcmnyName.Text.Trim(), date, ActiveSt, UserName);
            if (dt1.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt1.Rows[0][0].ToString());
                txtcmnyName.Text = "";
                viewdata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        viewdata();
    }
    protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        viewdata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dlt")
        {
            DataTable dt = new DataTable();
            UserName = Session["UsrName"].ToString();
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            txtcmnyName.Text = ((Label)(gvrow.FindControl("lblCpnm"))).Text;
            lblcompnycode.Text = ((Label)(gvrow.FindControl("lblcompcode"))).Text;
            dt = objDist.DeleteCompany(lblcompnycode.Text);
            if (dt.Rows.Count > 0)
            {
                string aa = "Deleted Successfully";
                objCommon.ShowAlertMessage(aa);
                viewdata();
            }
            else
            {
                string aa = "Deleted Failure";
                objCommon.ShowAlertMessage(aa);
            }            
        }
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            txtcmnyName.Text = ((Label)(gvrow.FindControl("lblCpnm"))).Text;
            lblcompnycode.Text = ((Label)(gvrow.FindControl("lblcompcode"))).Text;
            string status = ((Label)(gvrow.FindControl("lblstatus"))).Text;
            txt_Date.Text = ((Label)(gvrow.FindControl("lbleffdate"))).Text;
            if (status == "Yes")
            {
                rbnSy.Checked = true;
                rbnSn.Checked = false;
            }
            if (status == "No")
            {
                rbnSn.Checked = true;
                rbnSy.Checked = false;
            }
            txt_Date.Enabled = true;
            btn_Update.Visible = true;
            btn_Save.Visible = false;
        }
        viewdata();
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UserName = Session["UsrName"].ToString();
        DataTable dt = new DataTable();
        try
        {
            int ActiveSt = (rbnSn.Checked ? 0 : (rbnSy.Checked ? 1 : 0));
        DateTime date = DateTime.Parse(txt_Date.Text.Trim(), provider, System.Globalization.DateTimeStyles.NoCurrentDateDefault).Date;
        dt = objDist.UpdateCompany(txtcmnyName.Text.Trim(), date, ActiveSt, lblcompnycode.Text, UserName);
            if (dt.Rows.Count > 0)
            {
                string aa = "Updated Successfully";
                objCommon.ShowAlertMessage(aa);
                btn_Save.Visible = true;                    
                btn_Update.Visible = false;
            }
            else
            {
                string aa = "Updated Failed";
                objCommon.ShowAlertMessage(aa);
            }            
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }


   
}