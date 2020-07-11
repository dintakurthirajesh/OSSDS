using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;

public partial class Admin_AddSeedRequirement : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
    DataTable ddt;
    ListItem li;
    CommonFuncs objCommon = new CommonFuncs();
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
        lblUsrName.Text = Session["Role"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        if (!IsPostBack)
        {
            btnUpdate.Visible = false;
            ddt = objDist.viewdCropBAL();
            ddlcrop.Items.Clear();
            ddlcrop.Items.Add("Select ");
            for (int i = 0; i <= ddt.Rows.Count - 1; i++)
            {
                li = new ListItem();
                li.Text = ddt.Rows[i][1].ToString();
                li.Value = ddt.Rows[i][0].ToString();
                ddlcrop.Items.Add(li);
            }
        }
    }
    protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddt = objDist.viewdCroplistBAL(ddlcrop.SelectedValue);
        seeds.Items.Clear();
        seeds.Items.Add("Select ");
        for (int i = 0; i <= ddt.Rows.Count - 1; i++)
        {
            li = new ListItem();
            li.Text = ddt.Rows[i][1].ToString() + "/" + ddt.Rows[i][2].ToString();
            li.Value = ddt.Rows[i][0].ToString();
            seeds.Items.Add(li);
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnUpdate_Click1(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}