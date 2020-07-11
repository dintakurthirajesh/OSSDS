using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;


public partial class Master_DistMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    string INSERT, UPDATE;
    string StateCode = "";
    string UserName = "";

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
        lblUsrName.Text = Session["UsrName"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        if (!IsPostBack)
        {

            viewdata();
           // lblDcode.Visible = false;
            btn_Update.Visible = false;


        }

    }


    protected void btn_Save_Click(object sender, EventArgs e)
    {
        StateCode = Session["StateCode"].ToString();
        INSERT = "I";
        UserName = Session["UsrName"].ToString();

        DataTable dt = new DataTable();
        try
        {
            dt = objDist.getInsertDistBAL(StateCode, txtDcode.Text, txtDistName.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Inserted Successfully";
                    objCommon.ShowAlertMessage(aa);
                    txtDcode.Text = "";
                    txtDistName.Text = "";

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

        }
        finally
        {

        }


    }
    private void viewdata()
    {
        DataTable dt1 = new DataTable();
        string StateCode = Session["StateCode"].ToString();
        dt1 = objDist.viewdataBAL(StateCode);

        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

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
            StateCode = Session["StateCode"].ToString();
            UserName = Session["UsrName"].ToString();
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lbldistcode = (Label)gvrow.FindControl("lbldcode");
            Label lbldistname = (Label)gvrow.FindControl("lbldnm");
            dt = objDist.DeletedistrictBAL(StateCode, lbldistcode.Text, lbldistname.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Deleted Successfully";
                    objCommon.ShowAlertMessage(aa);
                    txtDcode.Text = "";
                    txtDistName.Text = "";
                    viewdata();

                }
                else
                {
                    string aa = "Deleted Failure";
                    objCommon.ShowAlertMessage(aa);
                    txtDcode.Text = "";
                    txtDistName.Text = "";

                }
            }

        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        viewdata();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        viewdata();
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;

        txtDcode.Text = ((Label)(gRow.FindControl("lbldcode"))).Text;


        txtDistName.Text = ((Label)(gRow.FindControl("lbldnm"))).Text;

        btn_Update.Visible = true;
        btn_Save.Visible = false;

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        StateCode = Session["StateCode"].ToString();
        UserName = Session["UsrName"].ToString();
        UPDATE = "U";

        DataTable dt = new DataTable();
        try
        {
            dt = objDist.UpdateDistBAL(StateCode, txtDcode.Text, txtDistName.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Updated Successfully";
                    objCommon.ShowAlertMessage(aa);

                    btn_Save.Visible = true;

                    txtDistName.Text = "";
                    txtDcode.Text = "";

                    btn_Update.Visible = false;

                }
                else
                {
                    string aa = "Updated Fai";
                    objCommon.ShowAlertMessage(aa);

                }
            }
            viewdata();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
}