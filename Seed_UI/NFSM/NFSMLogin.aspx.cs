using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;
using System.Configuration;

public partial class Login : System.Web.UI.Page
{
    CommonFuncs objCommon = new CommonFuncs();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            /*Random No*/
            Session["constr"] = ConfigurationManager.ConnectionStrings["seedsubsidyConnectionString"].ToString(); 
            Random _rand = new Random();
            ViewState["KeyGenerator"] = _rand.Next();
            txtUname.Focus();
          
        }
    }
    protected bool CheckCaptcha()
    {
        if (this.txtimgcode.Text == this.Session["CaptchaImageText"].ToString())
        {
            return true;
        }
        else
        {
            lblmsg.Text = "image code is not valid.";
            txtimgcode.Text = "";
            return false;
        }
        return true;
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUname.Text == "")
        {
            objCommon.ShowAlertMessage("Please Enter User Name");
            return;
        }
        if (txtPwd.Text == "")
        {
            objCommon.ShowAlertMessage("Please Enter Password");
            return;
        }
       
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
                Session["userid"] = dtLogin.Rows[0]["Sno"].ToString();
                Session["dept"] = "N";
                string myval = FormsAuthentication.HashPasswordForStoringInConfigFile(ViewState["KeyGenerator"].ToString(), "SHA1");
                string value = FormsAuthentication.HashPasswordForStoringInConfigFile(password.ToLower() + myval.ToLower(), "SHA1");
                if (txtPwdHash.Value != value.ToLower())
                {
                   

                    if (dtLogin.Rows[0]["Role"].ToString() == "9")
                    {
                      
                        Session["Role"] = roleNm;
                        Session["Rolecode"] = dtLogin.Rows[0]["Role"].ToString();
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["agencycode"] = SPCode;
                        Session["distCode"] = DistCode;
                        Session["mandcode"] = MandCode;
                        Session["district"] = district;
                        Session["mandal"] = mandal;
                        Response.Redirect("~/nfsm/agency/agencyHome.aspx");
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
                        Response.Redirect("~/nfsm/Admin/AdminHome.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "8")
                    {
                        Session["Rolecode"] = dtLogin.Rows[0]["Role"].ToString();
                        Session["Role"] = roleNm;
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["distCode"] = DistCode;
                        Session["district"] = district;
                        Response.Redirect("~/NFSM/DAO/DAohome.aspx");
                       
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "6")
                    {
                        Session["Role"] = roleNm;
                       
                        Session["Rolecode"] = dtLogin.Rows[0]["Role"].ToString();
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["distCode"] = DistCode;
                        Session["district"] = district;
                        Session["mandcode"] = MandCode;
                        Session["mandal"] = mandal;
                        Response.Redirect("~/NFSM/MAO/maohome.aspx");
                    }
                    if (dtLogin.Rows[0]["Role"].ToString() == "7")
                    {
                        Session["Role"] = roleNm;
                        Session["Rolecode"] = dtLogin.Rows[0]["Role"].ToString();
                        Session["UsrName"] = txtUname.Text;
                        Session["StateCode"] = StateCode;
                        Session["distCode"] = DistCode;
                        Session["district"] = district;
                        Session["mandcode"] = MandCode;
                        Session["mandal"] = mandal;
                        Session["repid"] = dtLogin.Rows[0]["code"].ToString();
                        Response.Redirect("~/nfsm/ado/adohome.aspx");
                    }
                }
                else
                {
                    string error = "Invalid Username & Password";
                    objCommon.ShowAlertMessage(error);
                }
            }
            else
            {
                string error = "Invalid Username & Password";
                objCommon.ShowAlertMessage(error);
            }
        }
    }
