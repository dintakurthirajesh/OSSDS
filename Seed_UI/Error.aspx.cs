﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (Session["dept"] != null)
        {
            if (Session["dept"].ToString() == "N")
            {
                Response.Redirect("~/nfsm/NFSMLogin.aspx");
            }
        }
        else {
            Response.Redirect("~/MSP/login.aspx");
        }
    }
}