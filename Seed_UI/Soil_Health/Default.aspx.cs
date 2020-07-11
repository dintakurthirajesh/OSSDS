using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using Seed_DL;
using System.Data;
using System.Configuration;
using System.Drawing;
public partial class _Default : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                /*SINCE PUBLIC PAGE STATE CODE IS HARDCODED TO 36 - TELANGANA*/
                // DashBoard("36", "ALL", "ALL");
               
                GethitcountNote();

            }
            catch (Exception ex)
            {
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    public void GethitcountNote()
    {

        DataTable dt = new DataTable();
        try
        {
            dt = objDist.GetLGHitCount("Nfsm");
            lblhitcount.ForeColor = Color.Red;
            lblhitcount.Text = "Hit Count : "+dt.Rows[0][0].ToString();
        }
        catch { }
    }
    public void DashBoard(string StateCode, string DistCode, string MandCode)
    {
        try
        {
          
        }
        catch (Exception ex)
        {
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void LnkBtnMoreInfo_Click(object sender, EventArgs e)
    {
        

    }
}