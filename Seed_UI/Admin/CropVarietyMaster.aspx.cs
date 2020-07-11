using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;


public partial class Master_CropMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    DataTable ddt;
    ListItem li;
    CommonFuncs objCommon = new CommonFuncs();
    string INSERT, UPDATE;
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
        lblUsrName.Text = Session["Role"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        if (!IsPostBack)
        {          
            btn_Update.Visible = false;
            ddt = objDist.GetCrops();
            objCommon.BindDropDownLists(ddl_CropNm, ddt, "CropName", "CropCode", "Select");
            BindComapnies();
        }
    }
    protected void BindComapnies()
    {
        ddt = new DataTable();
        ddt = objDist.GetCompany();
        objCommon.BindDropDownLists(ddlcomapnies, ddt, "company_name", "company_code", "Select Company");
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //  string StateCode = Session["StateCode"].ToString();
        INSERT = "I";
        string UserName = Session["UsrName"].ToString();
        DataTable dt = new DataTable();
        try
        {
            dt = objDist.getInsertCropVBAL(ddl_CropNm.SelectedValue,txtCropVName.Text.Trim(),Session["UsrName"].ToString(),Convert.ToInt16(ddlcomapnies.SelectedValue), INSERT);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Inserted Successfully";
                    objCommon.ShowAlertMessage(aa);
                    txtCropVName.Text = "";
                }
                else
                {
                    string aa = dt.Rows[0][0].ToString();
                    objCommon.ShowAlertMessage(aa);
                }
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
        finally
        {

        }
    }
    private void viewdata()
    {
        DataTable dt1 = new DataTable();
        // string StateCode = Session["StateCode"].ToString();
        dt1 = objDist.viewCroplistCompanyWise(ddl_CropNm.SelectedValue,ddlcomapnies.SelectedValue);
        if (dt1.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            //txtCropVcode.Text = "";
            txtCropVName.Text = "";
            btn_Update.Visible = false;
            btn_Save.Visible = true;
        }
        else
        {
            GridView1.Visible = false;
            objCommon.ShowAlertMessage("No Data Found");
           // txtCropVcode.Text = "";
            txtCropVName.Text = "";
            btn_Update.Visible = false;
            btn_Save.Visible = true;

        }

    }


    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        viewdata();
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblCpVnmTel = (Label)gvrow.FindControl("lblCpVnmTel");
            Label lblCpVnm = (Label)gvrow.FindControl("lblCpVnm");
            Label company = (Label)gvrow.FindControl("lblcompcode");
            txtCropVName.Text = lblCpVnm.Text;
            ddlcomapnies.SelectedValue = company.Text;
            // txtCropVcode.Text = lblcode.Text;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
        }
        if (e.CommandName == "Dlt")
        {
            string Delete = "D";
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblCpVcode = (Label)gvrow.FindControl("lblCpVcode");
            Label lblCpVnm = (Label)gvrow.FindControl("lblCpVnm");
            ddt = objDist.DeleteCropVBAL(lblCpVcode.Text, lblCpVnm.Text, Delete);
            if (ddt.Rows.Count > 0)
            {
                if (ddt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Deleted Successfully";
                    objCommon.ShowAlertMessage(aa);
                    //txtCropVcode.Text = "";
                    txtCropVName.Text = "";
                    viewdata();
                }
                else
                {
                    string aa = "Deleted Failure";
                    objCommon.ShowAlertMessage(aa);
                    //txtCropVcode.Text = "";
                    txtCropVName.Text = "";
                }
            }
        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        cropVcode.Text = ((Label)(gRow.FindControl("lblCpVcode"))).Text;
        txtCropVName.Text = ((Label)(gRow.FindControl("lblCpVnm"))).Text;
        btn_Update.Visible = true;
        btn_Save.Visible = false;
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        // string StateCode = Session["StateCode"].ToString();
        string UserName = Session["UsrName"].ToString();
        UPDATE = "U";
        DataTable dt = new DataTable();
        try
        {
            dt = objDist.UpdateCropVBAL(ddl_CropNm.SelectedValue, cropVcode.Text, txtCropVName.Text.Trim(),UserName,Convert.ToInt16(ddlcomapnies.SelectedValue) , UPDATE);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Updated Successfully";
                    objCommon.ShowAlertMessage(aa);
                    btn_Save.Visible = true;
                    txtCropVName.Text = "";
                    btn_Update.Visible = false;
                }
                else
                {
                    string aa = "Updated Failure";
                    objCommon.ShowAlertMessage(aa);
                }
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
        finally
        {

        }
    }
    protected void ddl_CropNm_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_CropNm.SelectedIndex > 0)
        {
           // viewdata();
        }
        else
        {
            cropVcode.Text = "";
            txtCropVName.Text = "";
            GridView1.Visible = false;        
        }
    }
    protected void ddlcomapnies_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_CropNm.SelectedIndex > 0)
        {
           viewdata();
        }
    }
}