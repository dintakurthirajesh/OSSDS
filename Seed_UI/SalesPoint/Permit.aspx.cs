using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text;
using Seed_BL;

public partial class SalesPoint_Permit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblpnm.Text = Request.QueryString["Pnm"];
        lblpfnm.Text = Request.QueryString["Pfnm"];
        lblkhata.Text = Request.QueryString["Khata"];
    }
}