using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_DL;
using System.Data;
using System.Web.Security;
using Seed_BE;
public partial class SoilHealthCardSearch : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    LocationBE objinsert = new LocationBE();
    SmsText_DL smsobj = new SmsText_DL();
    DataTable ddt;
    ListItem li;
    string StateCode = "", Flag_IUP, UserName = "";
    string INSERT;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/Soil_Health/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/Soil_Health/Error.aspx");
                }
            }
            if (Session["Rolecode"].ToString() == null || Session["Rolecode"].ToString() != "0")
           
            {
                Response.Redirect("~/Soil_Health/Error.aspx");
            }
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            if (!IsPostBack)
            {
              
                StateCode = Session["StateCode"].ToString();
                UserName = Session["UsrName"].ToString();
                getDistrictDtls();
                ddl_mandal_code.Items.Clear();
                ddl_mandal_code.Items.Insert(0, new ListItem("Select Mandal", "0"));
                ddlvillage.Items.Clear();
                ddlvillage.Items.Insert(0, new ListItem("Select Village", "0"));
               // Viewdata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Soil_Health/Error.aspx");

        }
    }

    protected void getDistrictDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Dis";
        objinsert.statecd = Session["StateCode"].ToString();
        dtDistricts = objDist.Getlocationdet(objinsert);
        dtDistricts.DefaultView.Sort = " DistName Asc ";
        objCommon.BindDropDownLists(ddl_dist_code, dtDistricts, "DistName", "DistCode_Lg", "Select District");

    }
    protected void getMandalDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Man";
        objinsert.statecd = Session["StateCode"].ToString();
        objinsert.distlgcd = ddl_dist_code.SelectedValue;
        dtDistricts = objDist.Getlocationdet(objinsert);
        dtDistricts.DefaultView.Sort = " MandName Asc ";
        objCommon.BindDropDownLists(ddl_mandal_code, dtDistricts, "MandName", "MandCode_LG", "Select Mandal");
    }
    protected void getVillageDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Vil";
        objinsert.statecd = Session["StateCode"].ToString();
        objinsert.distlgcd = ddl_dist_code.SelectedValue;
        objinsert.mandallgcd = ddl_mandal_code.SelectedValue;
        dtDistricts = objDist.Getlocationdet(objinsert);
        dtDistricts.DefaultView.Sort = " Villname Asc ";
        objCommon.BindDropDownLists(ddlvillage, dtDistricts, "Villname", "VillCode_LG", "Select Village");

    }   

    

    protected bool Validate()
    {


        if (ddl_dist_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select District");
            ddl_dist_code.Focus();
            return false;
        }
        if (ddl_mandal_code.SelectedValue == "0")
        {
            objCommon.ShowAlertMessage("Select Mandal ");
         
            return false;
        }
       
      

        return true;
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

                            Viewdata();


        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Soil_Health/Error.aspx");

        }


    }
    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        if (ddl_dist_code.SelectedIndex > 0)
        {
            getMandalDtls();
            ddlvillage.Items.Clear();
            ddlvillage.Items.Insert(0, new ListItem("Select Village", "0"));
            Viewdata();
        }
        else
            objCommon.ShowAlertMessage("Select District");   

    }
    public void LoadVillagedata()
    {
        try
        {
            DataTable dt = new DataTable();
            Flag_IUP = "R";
            dt = objDist.GetVillages(ddl_dist_code.SelectedValue, ddl_mandal_code.SelectedValue, Flag_IUP);
            objCommon.BindDropDownLists(ddlvillage, dt, "VillName", "VillCode_LG", "Select Village");
            
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Soil_Health/Error.aspx");

        }
    }
    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            objinsert = new LocationBE();
            if (ddl_dist_code.SelectedValue != "" && ddl_dist_code.SelectedValue != "0")
            {
                objinsert.distcd = ddl_dist_code.SelectedValue;
            }
            if (ddl_mandal_code.SelectedValue != "" && ddl_mandal_code.SelectedValue != "0")
            {
                objinsert.mandalcd = ddl_mandal_code.SelectedValue;
            }
            if (ddlvillage.SelectedValue != "" && ddlvillage.SelectedValue != "0")
            {
                objinsert.mandalcd = ddlvillage.SelectedValue;
            }
            Flag_IUP = "R";
            dt1 = objDist.GetSoilhealthAdvisor(objinsert, Flag_IUP);
            if (dt1.Rows.Count > 0)
            {
                Gvsendsms.Visible = true;
                Gvsendsms.DataSource = dt1;
                Gvsendsms.DataBind();
                btnsendsms.Visible = true;
            }
            else
            {
                objCommon.ShowAlertMessage("No data found");
                Gvsendsms.Visible = false;
                btnsendsms.Visible = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Soil_Health/Error.aspx");

        }
    }

   
  
    protected void ddl_mandal_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mandal_code.SelectedIndex > 0)
        {
            Viewdata();
            getVillageDtls();
        }
        else
        {
            Gvsendsms.Visible = false;

        }

       
       
        btn_Save.Visible = true;
     
    }
    protected void btnsendsms_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow gr in Gvsendsms.Rows)
        {
            if (((CheckBox)gr.FindControl("chkselect")).Checked == true)
            {

                string mobilno = ((Label)gr.FindControl("lblMobile_No")).Text.Trim();
                smsobj.BroadcastSMS(mobilno.Trim(), "T", "testdata");
               
            }
        }
    }
    protected void sellectAll(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)Gvsendsms.HeaderRow.FindControl("chkall");
        foreach (GridViewRow row in Gvsendsms.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
    }
}
