using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;

public partial class DAO_SalePoint : System.Web.UI.Page
{
    CommonFuncs cmnfn = new CommonFuncs();
    DataTable dt = new DataTable();
    MasterBAL obj = new MasterBAL();
    LoginBAL objLogin = new LoginBAL();
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
        //clear Caching 
        PrevBrowCache.enforceNoCache();

        if (Session["UsrName"] == null)
        {
            Response.Redirect("~/Error.aspx");
        }

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindMandals();
            btn_Update.Visible = false;
        }
    }
    protected void BindMandals()
    {
        dt = obj.GetNewMandals(Session["distCode"].ToString());
        cmnfn.BindDropDownLists(ddl_Mandal, dt, "MandName", "MandCode", "Select Mandal");
    }
    protected bool ValidatePage()
    {
        if (ddl_Mandal.SelectedValue == "")
        {
            cmnfn.ShowAlertMessage("Select Mandal");
            ddl_Mandal.Focus();
            return false;
        }
        if (txtSalePName.Text == "")
        {
            cmnfn.ShowAlertMessage("Enter Salepoint Name");
            txtSalePName.Focus();
            return false;
        }
        if (txtinchrgAgri.Text == "")
        {
            cmnfn.ShowAlertMessage("Enter Salepoint Incharge (Agriculture)");
            txtinchrgAgri.Focus();
            return false;
        }
        if (txtinchrgSocty.Text == "")
        {
            cmnfn.ShowAlertMessage("Enter Salepoint Incharge (Society)");
            txtinchrgSocty.Focus();
            return false;
        }
        if (txtmobile.Text == "")
        {
            cmnfn.ShowAlertMessage("Enter Mobile Number");
            txtmobile.Focus();
            return false;
        }
        if (txtuser.Text == "")
        {
            cmnfn.ShowAlertMessage("Enter User Name");
            txtuser.Focus();
            return false;
        }
        return true;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        if (ValidatePage())
        {
            int active = 0;
            active = Convert.ToInt32(rblActive.SelectedValue);
            DataTable dt = new DataTable();
            try
            {
                dt = obj.InsertSalePointBAL(Session["StateCode"].ToString(), Session["distCode"].ToString(), ddl_Mandal.SelectedValue,
                    txtSalePName.Text.Trim(), "I", Session["UsrName"].ToString(), active, txtinchrgAgri.Text.Trim(), txtmobile.Text.Trim(), txtinchrgSocty.Text.Trim(), txtuser.Text);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string message = "Inserted Successfully";
                        cmnfn.ShowAlertMessage(message);
                        txtSalePName.Text = "";
                        rblActive.ClearSelection();
                    }
                    else
                    {
                        string message = "Sales Point Name  Already Exist";
                        txtSalePName.Focus();
                        cmnfn.ShowAlertMessage(message);
                    }
                }
                ViewSalePoint();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    public void ViewSalePoint()
    {
        DataTable dt1 = new DataTable();

        dt1 = obj.GetSalepoints(Session["StateCode"].ToString(), Session["distCode"].ToString(),ddl_Mandal.SelectedValue);
        if (dt1.Rows.Count > 0)
        {
            GridView1.Visible = true;
            GridView1.DataSource = dt1;
            GridView1.DataBind();
        }
        else
        {
            txtSalePName.Text = "";
            GridView1.Visible = false;
            cmnfn.ShowAlertMessage("No Data Found");
        }
    }
    protected void ddl_Mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Mandal.SelectedIndex == 0)
            cmnfn.ShowAlertMessage("select Mandal");
        else
            ViewSalePoint();
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        btn_Update.Visible = true;
        btn_Save.Visible = false;
    }
    protected void btn_Update_Click(object sender, EventArgs e)
    {        
        int active = Convert.ToInt32(rblActive.SelectedValue);
        DataTable dt = new DataTable();
        try
        {
            dt = obj.UpdateSalepoint(Session["StateCode"].ToString(), Session["distCode"].ToString(), ddl_Mandal.SelectedValue, txtSalePName.Text.Trim(),
                Session["UsrName"].ToString(), active, "U", hdnspcode.Value, txtinchrgAgri.Text.Trim(), txtmobile.Text.Trim(), txtinchrgSocty.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string message = "Updated Successfully";
                    cmnfn.ShowAlertMessage(message);
                    txtSalePName.Text = "";
                    rblActive.ClearSelection();
                    btn_Update.Visible = false;
                    btn_Save.Visible = true;
                    ViewSalePoint();
                }
                else
                {
                    string message = "Active Status Updated";
                    cmnfn.ShowAlertMessage(message);
                    rblActive.ClearSelection();
                    txtSalePName.Text = "";
                    btn_Update.Visible = false;
                    btn_Save.Visible = true;
                    ViewSalePoint();
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblactive = (Label)e.Row.FindControl("lblActive");
            if (lblactive.Text == "True")
            {
                lblactive.Text = "Yes";
            }
            else
            {
                lblactive.Text = "No";
            }
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edt")
        {
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            txtSalePName.Text = ((Label)gvrow.FindControl("lblSPName")).Text;
            txtinchrgAgri.Text = ((Label)gvrow.FindControl("lblagrinch")).Text;
            txtinchrgSocty.Text = ((Label)gvrow.FindControl("lblagriSoc")).Text;
            txtmobile.Text = ((Label)gvrow.FindControl("lblmobile")).Text;
            Label lblactive = (Label)gvrow.FindControl("lblActive");
            txtuser.Text = ((Label)gvrow.FindControl("lbluser")).Text;
            txtuser.Enabled = false;
            if (lblactive.Text == "Yes")
            {
                rblActive.SelectedIndex = 0;
            }
            else
            {
                rblActive.SelectedIndex = 1;
            }
            hdnspcode.Value = ((Label)gvrow.FindControl("lblspcode")).Text;
            btn_Save.Visible = false;
            btn_Update.Visible = true;
        }
        if (e.CommandName == "Dlt")
        {
            try
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lblspcd = (Label)gvrow.FindControl("lblspcode");
                string flag = "D";
                dt = obj.DltSalesPoint(lblspcd.Text, flag);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        string aa = "Deleted Successfully";
                        cmnfn.ShowAlertMessage(aa);
                        txtSalePName.Text = "";
                    }
                    else
                    {
                        string aa = "Deleted Failure";
                        cmnfn.ShowAlertMessage(aa);
                        txtSalePName.Text = "";
                    }
                }
                ViewSalePoint();
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void txtuser_TextChanged(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt = objLogin.CheckUser(txtuser.Text.Trim());
            if (dt.Rows.Count > 0)
            {
                cmnfn.ShowAlertMessage("User Name Already Exists");
                txtuser.Text = "";
            }
        }       
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        ViewSalePoint();
    }
}