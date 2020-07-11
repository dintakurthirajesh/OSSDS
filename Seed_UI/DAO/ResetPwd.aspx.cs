using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Seed_BL;
using Seed_BE;

public partial class DAO_ResetPwd : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL(); 
    DataTable ddt = new DataTable();
    CommonFuncs objCommon = new CommonFuncs();
    LoginBAL objlogin = new LoginBAL();
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
        }
    }
    public void BindMandals()
    {
        ddt = objDist.GetNewMandals(Session["distCode"].ToString());
        objCommon.BindDropDownLists(ddlMand, ddt, "MandName", "MandCode", "Select Mandal");
    }
    protected void ddlMand_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddt = objlogin.getUsers(Session["StateCode"].ToString(), Session["distCode"].ToString(), ddlMand.SelectedValue,"4");
        objCommon.BindDropDownLists(ddlusers, ddt, "UserName", "UserName", "select");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ddt = objlogin.ResetPwd(ddlusers.SelectedValue);
        if (ddt.Rows.Count > 0)
            objCommon.ShowAlertMessage(ddt.Rows[0][0].ToString());
        else
            objCommon.ShowAlertMessage("Unable to reset password");
    }
    
}