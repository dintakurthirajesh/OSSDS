using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BL;

public partial class DAO_home : System.Web.UI.Page
{
    CommonFuncs cmnfn = new CommonFuncs();
    DataTable dt = new DataTable();
    AOBAL objAO = new AOBAL();
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

        if (Session["UsrName"] == null )
        {
            Response.Redirect("~/Error.aspx");
        }

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lbld.Text = Session["district"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            BindCropsGrid();
        }
    }

    public void BindCropsGrid()
    {
        dt = objAO.GetSeedAllotmentDistrict(DateTime.Now.Year.ToString(), "Kharif", Session["distCode"].ToString());
        KharifGrid.DataSource = dt;
        KharifGrid.DataBind();

        dt = objAO.GetSeedAllotmentDistrict(DateTime.Now.Year.ToString(), "Rabi", Session["distCode"].ToString());
        RabiGrid.DataSource = dt;
        RabiGrid.DataBind();
    }

    protected void AllotSeed(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        string arguments = b.CommandArgument;
        string[] args = arguments.Split(',');
        Session["year"] = args[0].ToString();
        Session["season"] = args[1].ToString();
        Session["cropNm"] = args[2].ToString();
        Session["crop"] = args[3].ToString();
        //Session["cropvNm"] = args[4].ToString();
       // Session["cropv"] = args[5].ToString();
        Session["qty"] = args[4].ToString();
        Session["Aid"] = args[5].ToString();
        Session["qtyLeft"] = args[6].ToString(); 
        Response.Redirect("SeedAllotment.aspx", false);       
    }

}