using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;

public partial class Login : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            /*Random No*/
            Random _rand = new Random();
            ViewState["KeyGenerator"] = _rand.Next();
            txtUname.Focus();
        }
    }
    protected bool CheckCaptcha()
    {
        //if (this.txtimgcode.Text == this.Session["CaptchaImageText"].ToString())
        //{
        //    return true;
        //}
        //else
        //{
        //    lblmsg.Text = "image code is not valid.";
        //    txtimgcode.Text = "";
        //    return false;
        //}
        return true;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (CheckCaptcha())
        {
            LoginBAL objLogin = new LoginBAL();
            DataTable dtLogin = objLogin.getLoginDetailsBAL(txtUname.Text);
            if (dtLogin.Rows.Count > 0)
            {
                string password = dtLogin.Rows[0]["Password"].ToString();
                string StateCode = dtLogin.Rows[0]["StateCode"].ToString();
                string DistCode = dtLogin.Rows[0]["DistCode"].ToString();
                string MandCode = dtLogin.Rows[0]["MandCode"].ToString();
                string SPCode = dtLogin.Rows[0]["code"].ToString();
                string district = dtLogin.Rows[0]["DistName"].ToString();
                string mandal = dtLogin.Rows[0]["MandName"].ToString();
                string roleNm = dtLogin.Rows[0]["role_name"].ToString();

                string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                if (txtPwdHash.Value == value.ToLower())
                {
                    //if (password == "2dc5671c5e7258aec039b20ceb4d4c8a8c3683eb")
                    //{
                    //    Session["Role"] = roleNm;
                    //    Session["UsrName"] = txtUname.Text;
                    //    Session["StateCode"] = StateCode;
                    //    Session["SpCode"] = SPCode;
                    //    Session["distCode"] = DistCode;
                    //    Session["mandcode"] = MandCode;
                    //    Session["district"] = district;
                    //    Session["mandal"] = mandal;
                    //    Response.Redirect("ChangePWD.aspx");
                    //}

                    if (dtLogin.Rows[0]["Role"].ToString() == "2")
                    {
                        Session["Role"] = roleNm;
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["SpCode"] = SPCode;
                        Session["distCode"] = DistCode;
                        Session["mandcode"] = MandCode;
                        Session["district"] = district;
                        Session["mandal"] = mandal;
                        Response.Redirect("~/SalesPoint/StockEntry.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "1")
                    {
                        Session["Role"] = roleNm;
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Response.Redirect("~/Admin/Admin.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "0")
                    {
                        Session["Role"] = roleNm;
                        Session["Rolecode"] = dtLogin.Rows[0]["Role"].ToString();
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Response.Redirect("~/lg/DistMaster_lg.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "3")
                    {
                        Session["Role"] = roleNm;
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["distCode"] = DistCode;
                        Session["district"] = district;
                        Response.Redirect("~/DAO/home.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "4")
                    {
                        Session["Role"] = roleNm;
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["distCode"] = DistCode;
                        Session["district"] = district;
                        Session["mandcode"] = MandCode;
                        Session["mandal"] = mandal;
                        Response.Redirect("~/MAO/home.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "5")
                    {
                        Session["Role"] = roleNm;
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["distCode"] = DistCode;
                        Session["district"] = district;
                        Session["mandcode"] = MandCode;
                        Session["mandal"] = mandal;
                        Session["repid"] = dtLogin.Rows[0]["code"].ToString();
                        Response.Redirect("~/Rep/home.aspx");
                    }
                }
                else
                {
                    string error = "Invalid Username & Password";
                    objCommon.ShowAlertMessage(error);
                }
            }
        }
    }
}