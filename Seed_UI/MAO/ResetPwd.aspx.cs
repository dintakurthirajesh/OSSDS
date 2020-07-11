using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
public partial class MAO_ResetPwd : System.Web.UI.Page
{
    DataTable ddt = new DataTable();
    CommonFuncs cf = new CommonFuncs();
    LoginBAL objlogin = new LoginBAL();
    SeedAllotBL seedObj = new SeedAllotBL();
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
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            GetSalepoints();
        }
    }
    private void GetSalepoints()
    {
        DataTable dt = new DataTable();
        dt = seedObj.GetSalepoints(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
        cf.BindDropDownLists(ddlsp, dt, "SalePtName", "SalePtCode", "select sale point");
    }
    protected void ddlsp_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddt = objlogin.getUsers(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString(), "2");
        cf.BindDropDownLists(ddlusers, ddt, "UserName", "UserName", "select");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ddt = objlogin.ResetPwd(ddlusers.SelectedValue);
        if (ddt.Rows.Count > 0)
            cf.ShowAlertMessage(ddt.Rows[0][0].ToString());
        else
            cf.ShowAlertMessage("Unable to reset password");
    }
}