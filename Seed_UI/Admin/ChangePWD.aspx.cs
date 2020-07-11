using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;

public partial class Admin_ChangePWD : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
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
            Random _rand = new Random();
            ViewState["keyGen"] = _rand.Next().ToString();
        }
    }
   

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            LoginBAL objLogin = new LoginBAL();
            DataTable dtLogin = objLogin.getLoginDetailsBAL(Session["UsrName"].ToString());
            if (dtLogin.Rows.Count > 0)
            {
                string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["keyGen"].ToString(), "SHA1");
                string password = dtLogin.Rows[0]["Password"].ToString();
                string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                if (password.ToLower() != txtNewPwdHash.Value)
                {
                    if (txtOldPwdHash.Value == value.ToLower())
                    {
                        DataTable dt = new DataTable();
                        dt = objLogin.updatePWDBAL(Session["UsrName"].ToString(), txtNewPwdHash.Value, Session["UsrName"].ToString());
                        if (dt.Rows.Count > 0)                        
                           cf.ShowAlertMessage(dt.Rows[0][0].ToString());
                       
                        else
                        {
                            txtOldPwdHash.Value = "";
                            txtNewPwdHash.Value = "";
                            cf.ShowAlertMessage("Invalid Password ");
                        }
                    }
                }
                else                
                    cf.ShowAlertMessage("New Password should not be same as old password");                
            }
            else            
                cf.ShowAlertMessage("New Password should not be same as old password");            
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UserId"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");

        }

    }
    
}