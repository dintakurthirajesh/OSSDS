using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;

public partial class DAO_StockTransfer : System.Web.UI.Page
{
    CommonFuncs cf = new CommonFuncs();
    MasterBAL objDist = new MasterBAL();
    StockTransfer_BL st = new StockTransfer_BL();
    DataTable dt;
   
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
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCrop();
        }
    }
    protected void BindCrop()
    {
        try
        {
            dt = new DataTable();
            dt = objDist.GetCrops();
            cf.BindDropDownLists(ddlcrop, dt, "CropName", "CropCode", "Select");
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            dt = new DataTable();
            dt = st.GetStockPositionMandWise(ddlyear.SelectedValue, seasons.SelectedValue, Session["distCode"].ToString(),ddlcrop.SelectedValue, ddlvareity.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                StkGrid.DataSource = dt;
                StkGrid.DataBind();
            }
            else
            {
                StkGrid.DataSource = null;
                StkGrid.DataBind();
                cf.ShowAlertMessage("No Data");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void Trnsfer_to_Mand(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        string arguments = b.CommandArgument;
        string[] args = arguments.Split(',');

        Session["MandCode"] = args[0].ToString();
        Session["MandName"] = args[1].ToString();
        Session["cropnm"] = args[2].ToString();
        Session["stkleft"] = args[3].ToString();
        Session["bagsleft"] = args[4].ToString();
        Session["weight"] = args[5].ToString();

        Session["crop"] = ddlcrop.SelectedValue;
        Session["year"] = ddlyear.SelectedValue;
        Session["season"] = seasons.SelectedValue;
        Response.Redirect("TransferToMandal.aspx");
    }
    protected void Trnsfer_to_Dist(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        string arguments = b.CommandArgument;
        string[] args = arguments.Split(',');

        Session["MandCode"] = args[0].ToString();
        Session["MandName"] = args[1].ToString();
        Session["cropnm"] = args[2].ToString();
        Session["stkleft"] = args[3].ToString();
        Session["bagsleft"] = args[4].ToString();
        Session["weight"] = args[5].ToString();

        Session["crop"] = ddlcrop.SelectedValue;
        Session["year"] = ddlyear.SelectedValue;
        Session["season"] = seasons.SelectedValue;
        Response.Redirect("TransferToDistrct.aspx");
    }
    protected void ddlcrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt = objDist.viewdCroplistBAL(ddlcrop.SelectedValue);
        cf.BindDropDownLists(ddlvareity, dt, "CropVName", "CropVCode", "Select Crop Variety");
    }
}