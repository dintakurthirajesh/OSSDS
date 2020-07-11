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

public partial class SalesPoint_Default : System.Web.UI.Page
{
   string strConnectionString = null;
    int intResult = 0;
    
    SqlCommand cmd;
    SqlDataAdapter adapt;

    public SalesPoint_Default()
    {
        //Used to get connection string by using KRCCClassLib dll file
        strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];//ConfigurationManager.AppSettings["ConnectionString"];
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //Htpp Referer Check
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
        if (Session["UsrName"] == null)
        {
            Response.Redirect("~/Error.aspx");
        }
        
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

        }
        Binddist();
        Bindmandal();
    }
    private void Binddist()
    {
        DataSet ds = new DataSet();
        
        string cmdstr = "select *from  Mst_District";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = strConnectionString;
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_dist.DataSource = ds.Tables[0];
            ddl_dist.DataTextField = "DistName";
            ddl_dist.DataValueField = "DistCode";
            ddl_dist.DataBind();
        }
       
    }
    protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindvillage();
    }
    private void Bindmandal()
    {
        DataSet ds = new DataSet();
        string dist = ddl_dist.SelectedIndex.ToString();
        string cmdstr = "select *from  Mst_Mandal";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = strConnectionString;
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_mandal.DataSource = ds.Tables[0];
            ddl_mandal.DataTextField = "MandName";
            ddl_mandal.DataValueField = "MandCode";
            ddl_mandal.DataBind();
        }

    }
    protected void ddl_dist_SelectedIndexChanged(object sender, EventArgs e)
    {
       // Bindmandal();
    }
    private void Bindvillage()
    {
        DataSet ds = new DataSet();
        string dist = ddl_dist.SelectedIndex.ToString();
        string cmdstr = "select *from  Mst_Village";
        SqlConnection con = new SqlConnection();
        con.ConnectionString = strConnectionString;
        SqlDataAdapter adp = new SqlDataAdapter(cmdstr, con);
        adp.Fill(ds);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_vill.DataSource = ds.Tables[0];
            ddl_vill.DataTextField = "VillName";
            ddl_vill.DataValueField = "VillCode";
            ddl_vill.DataBind();
        }

    }
    public DataSet CreateDataSet<T>(List<T> list)
    {
        //list is nothing or has nothing, return nothing (or add exception handling)
        if (list == null || list.Count == 0) { return null; }

        //get the type of the first obj in the list
        var obj = list[0].GetType();

        //now grab all properties
        var properties = obj.GetProperties();

        //make sure the obj has properties, return nothing (or add exception handling)
        if (properties.Length == 0) { return null; }

        //it does so create the dataset and table
        var dataSet = new DataSet();
        var dataTable = new DataTable();

        //now build the columns from the properties
        var columns = new DataColumn[properties.Length];
        for (int i = 0; i < properties.Length; i++)
        {
            columns[i] = new DataColumn(properties[i].Name, properties[i].PropertyType);
        }

        //add columns to table
        dataTable.Columns.AddRange(columns);

        //now add the list values to the table
        foreach (var item in list)
        {
            //create a new row from table
            var dataRow = dataTable.NewRow();

            //now we have to iterate thru each property of the item and retrieve it's value for the corresponding row's cell
            var itemProperties = item.GetType().GetProperties();

            for (int i = 0; i < itemProperties.Length; i++)
            {
                dataRow[i] = itemProperties[i].GetValue(item, null);
            }

            //now add the populated row to the table
            dataTable.Rows.Add(dataRow);
        }

        //add table to dataset
        dataSet.Tables.Add(dataTable);

        //return dataset
        return dataSet;
    }
    protected void ddl_vill_SelectedIndexChanged(object sender, EventArgs e)
    {
             

        WsPahaniWebService.WSPahani obj = new WsPahaniWebService.WSPahani();
        WsPahaniWebService.Survey_No_str[] SurveyNosList = new WsPahaniWebService.Survey_No_str[] { };
        List<WsPahaniWebService.Survey_No_str> ResSet = new List<WsPahaniWebService.Survey_No_str>();

        SurveyNosList = obj.GetSurveyNumberDetails(ddl_dist.SelectedValue, ddl_mandal.SelectedValue,ddl_vill.SelectedValue, 2015);

        ResSet = SurveyNosList.ToList();

        DataSet ds = CreateDataSet(ResSet);
        int tablesCnt = ds.Tables.Count;
        ddlSurveyNos.DataSource = ds.Tables[0];
        ddlSurveyNos.DataTextField = "survey_No";
        ddlSurveyNos.DataValueField = "survey_No";
        ddlSurveyNos.DataBind();  
    }
    protected void getlr_Click(object sender, EventArgs e)
    {
        WsCropsInfo.CropsService obj= new WsCropsInfo.CropsService();
        WsCropsInfo.Crops[] CropsList = new WsCropsInfo.Crops[] { };
        List<WsCropsInfo.Crops> ResSet = new List<WsCropsInfo.Crops>();

        CropsList = obj.GetCropsInformation(Convert.ToInt32(ddl_dist.SelectedValue), Convert.ToInt32(ddl_mandal.SelectedValue), Convert.ToInt32(ddl_vill.SelectedValue), 2015, ddlSurveyNos.SelectedValue, "ws_land", "en3rgy5tar");
        ResSet = CropsList.ToList();

        DataSet ds = CreateDataSet(ResSet);
        int tablesCnt = ds.Tables.Count;


        GvPopUpFarmerdata.DataSource = ds.Tables[0];        
        GvPopUpFarmerdata.DataBind();  

    }
}