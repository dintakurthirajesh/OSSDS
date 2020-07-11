using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;
public partial class DAO_TransferToMandal : System.Web.UI.Page
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
            lblmandnm.Text = Session["spnm"].ToString();
            lblcrop.Text = Session["cropnm"].ToString();
            lblqty.Text = Session["stkleft"].ToString();
            lblnob.Text = Session["bagsleft"].ToString();
            BindMandals();
        }
    }
    protected void BindMandals()
    {
        try
        {
            dt = new DataTable();
            dt = st.GetMandals(Session["distCode"].ToString(), Session["mandcode"].ToString());
            if (dt.Rows.Count > 0)
            {
                cf.BindDropDownLists(ddlMand, dt, "MandName", "MandCode", "Select Mandal");
                txtqty.Enabled = true;
            }           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        dt = new DataTable();
        dt = st.MandalToMandalTrnsfer(Session["year"].ToString(), Session["season"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString(), ddlMand.SelectedValue, Session["crop"].ToString());
        if (dt.Rows.Count > 0)
        {
            cf.ShowAlertMessage(dt.Rows[0][0].ToString());
          //  BindGrid();
        }
        else
        {
            cf.ShowAlertMessage("Transferred to Salepoint");
         //   BindGrid();
        }
    }
    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        if (Convert.ToInt32(lblnob.Text) < Convert.ToInt32(txtqty.Text))
        {
            cf.ShowAlertMessage("Cannot Transfer more than available ");
            txtqty.Text = "";
        }
    }
}