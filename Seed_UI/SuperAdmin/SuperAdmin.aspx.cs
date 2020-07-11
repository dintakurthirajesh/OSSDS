using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SuperAdmin_SuperAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
            if (Session["UsrName"] == null || Session["UsrName"].ToString() != "SuperAdmin")
            {
                Response.Redirect("~/Error.aspx");
            }
            if (!IsPostBack)
            {
                lblUsrName.Text = Session["Role"].ToString();
                lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

            }
        }
    }
}