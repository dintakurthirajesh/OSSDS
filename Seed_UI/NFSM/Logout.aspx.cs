using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["UsrName"] = null;
        Session["UsrType"] = null;
        Session.Abandon();
        Session.Clear();
        Session.RemoveAll();
    }
}