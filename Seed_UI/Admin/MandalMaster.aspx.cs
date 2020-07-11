using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;


public partial class EVHMS_UI_Admin_MandalMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    CommonFuncs objCommon = new CommonFuncs();
    DataTable ddt;
    ListItem li;
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

            StateCode = Session["StateCode"].ToString();
            UserName = Session["UsrName"].ToString();
            BindDist(StateCode);
            btn_Update.Visible = false;
        }
    }

    public void BindDist(string StateCode)
    {

        ddt = objDist.getdist(StateCode);
        ddl_dist_code.Items.Clear();
        ddl_dist_code.DataSource = ddt;
        ddl_dist_code.DataTextField = "DistName";
        ddl_dist_code.DataValueField = "DistCode";
        ddl_dist_code.DataBind();
        ddl_dist_code.Items.Insert(0, "Select District");

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Viewdata();
    }
    protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        //GridView1.EditIndex = -1;


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dlt")
        {
            DataTable dt = new DataTable();
            StateCode = Session["StateCode"].ToString();
            UserName = Session["UsrName"].ToString();
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            HiddenField hdndistcode = (HiddenField)gvrow.FindControl("hdndistcode");
            Label lblMCode = (Label)gvrow.FindControl("lblMCode");
            Label lblMName = (Label)gvrow.FindControl("lblMName");
            dt = objDist.DeletemandalBAL(hdndistcode.Value, lblMCode.Text, lblMName.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Deleted Successfully";
                    objCommon.ShowAlertMessage(aa);
                    txtMcode.Text = "";
                    txtMandalName.Text = "";
                    Viewdata();

                }
                else
                {
                    string aa = "Deleted Failure";
                    objCommon.ShowAlertMessage(aa);
                    txtMcode.Text = "";
                    txtMandalName.Text = "";


                }
            }

        }

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        // GridView1.EditIndex = e.NewEditIndex;

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {

        string StateCode = Session["StateCode"].ToString();
        INSERT = "I";
        string UserName = Session["UsrName"].ToString();

        DataTable dt = new DataTable();
        try
        {
            dt = objDist.InsertMandalBAL(ddl_dist_code.SelectedValue.ToString(), txtMcode.Text, txtMandalName.Text.Trim(), INSERT);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string message = "Inserted Successfully";
                    objCommon.ShowAlertMessage(message);
                    txtMcode.Text = "";
                    txtMandalName.Text = "";



                }
                else
                {
                    string message = dt.Rows[0][0].ToString();
                    objCommon.ShowAlertMessage(message);

                }
            }
            Viewdata();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }


    }
    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_dist_code.SelectedIndex > 0)
        {
            Viewdata();
        }
        else
        {

            txtMcode.Text = "";
            txtMandalName.Text = "";
            GridView1.Visible = false;
        }
    }
    public void Viewdata()
    {
        DataTable dt1 = new DataTable();

        dt1 = objDist.viewDistdataBAL(ddl_dist_code.SelectedValue.ToString());

        if (dt1.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt1;
            GridView1.DataBind();
            txtMcode.Text = "";
            txtMandalName.Text = "";
            btn_Update.Visible = false;
            btn_Save.Visible = true;
        }
        else
        {
            objCommon.ShowAlertMessage("No Data Found");
            GridView1.Visible = false;
            txtMcode.Text = "";
            txtMandalName.Text = "";
            btn_Update.Visible = false;
            btn_Save.Visible = true;

        }
    }

    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;

        txtMcode.Text = ((Label)(gRow.FindControl("lblMCode"))).Text;
        txtMandalName.Text = ((Label)(gRow.FindControl("lblMName"))).Text;

      
        btn_Update.Visible = true;
        btn_Save.Visible = false;

    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {
        StateCode = Session["StateCode"].ToString();
        UPDATE = "U";
        UserName = Session["UsrName"].ToString();

        DataTable dt = new DataTable();
        try
        {
            dt = objDist.UpdateMandalBAL(ddl_dist_code.SelectedValue.ToString(), txtMcode.Text, txtMandalName.Text.Trim(), UPDATE);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string message = "Update Successfully";
                    objCommon.ShowAlertMessage(message);
                    txtMcode.Text = "";
                    txtMandalName.Text = "";


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "error", "alert('Update Fail')", true);
                }
            }
            Viewdata();
        }
        catch (Exception ex)
        {

        }
        finally
        {

        }
    }
}
