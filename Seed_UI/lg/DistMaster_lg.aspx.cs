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

public partial class DistMaster : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();
    LocationBE objinsert = new LocationBE();
    Validate objValidate = new Validate();
    string INSERT, UPDATE;
    string  Flag_IUP, UserName = "";
 
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {

            if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
            {
                Response.Redirect("~/lg/Error.aspx");
            }
            else
            {
                string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
                string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
                int len = http_hos.Length;
                if (http_ref.IndexOf(http_hos, 0) < 0)
                {
                    Response.Redirect("~/lg/Error.aspx");
                }
            }
            if (Session["Rolecode"].ToString() == null || Session["Rolecode"].ToString() != "0")
          
            {
                Response.Redirect("~/lg/Error.aspx");
            }
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            if (!IsPostBack)
            {
                BindStates();
              
                lblDcode.Visible = false;
                btn_Update.Visible = false;
              
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }
    protected void GetDistCode()
    {
        DataTable dt = new DataTable();
        dt = objDist.GetMaxCode();
        lblDcode.Text = dt.Rows[0][0].ToString();
        lblDcode.Enabled = false;
    }
    protected void BindStates()
    {
        DataTable dt = new DataTable();
        dt = objDist.getStates();
        objCommon.BindDropDownLists(ddlstate, dt, "StateName", "StateCode", "Select State");
    }
    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        getDistrictDtls();
    }
    protected bool ValidateForm()
    {
       
        if (txtDistName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter District Name");
            txtDistName.Focus();
            return false;
        }
      
        return true;
    }
    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (ValidateForm())
            {
              
                INSERT = "I";
                UserName = Session["UsrName"].ToString();
               
          DataTable dt = new DataTable();

            

                objinsert.statecd = ddlstate.SelectedValue; ;
                if (txtDistCodelg.Text != "")
                {
                    objinsert.distlgcd = txtDistCodelg.Text;
                }
                else
                {
                    objinsert.distlgcd = "";
                }
                GetDistCode();
                objinsert.distcd = lblDcode.Text;
                objinsert.distname = txtDistName.Text;
         
                objinsert.userid = UserName;
             
                objinsert.Flage = INSERT;
              
                dt = objDist.insertDistDAL(objinsert);
                if (dt.Rows.Count > 0)                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());                 
                    txtDistName.Text = "";
                    lblDcode.Text = "";
                    txtDistCodelg.Text = "";                  
                }
                getDistrictDtls();
                GetDistCode();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }


    protected void getDistrictDtls()
    {
        DataTable dtDistricts = new DataTable();
        dtDistricts = objDist.viewdataDALlg(ddlstate.SelectedValue);
        GvDistricts.DataSource = dtDistricts;
        GvDistricts.DataBind();
    }

    protected void GvDistricts_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            GvDistricts.PageIndex = e.NewPageIndex;
            getDistrictDtls();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }

    protected void GvDistricts_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                UserName = Session["UsrName"].ToString();
                Flag_IUP = "D";
          
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label lbldistcode = (Label)gvrow.FindControl("lbldcode");
                Label lbldistlgcode = (Label)gvrow.FindControl("lbllgdcode");
                Label lbldistname = (Label)gvrow.FindControl("lbldnm");
                  objinsert.statecd = ddlstate.SelectedValue;
                  objinsert.distlgcd = lbldistlgcode.Text;
                objinsert.distcd = lbldistcode.Text;
                objinsert.distname = lbldistname.Text;
            
                objinsert.Flage = Flag_IUP;
            
                dt = objDist.insertDistDAL(objinsert);

         
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
              
                    txtDistName.Text = "";
                    btn_Save.Visible = true;
                    btn_Update.Visible = false;
                 
                    getDistrictDtls();
                    GetDistCode();
                }
            }
            else  if (e.CommandName == "Edt")
                {
                    GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                    txtDistName.Text = ((Label)(gvrow.FindControl("lbldnm"))).Text;
                    lblDcode.Text = ((Label)(gvrow.FindControl("lbldcode"))).Text;
                    txtDistCodelg.Text = ((Label)(gvrow.FindControl("lbllgdcode"))).Text;
                  
                    btn_Update.Visible = true;
                    btn_Save.Visible = false;
                }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        try
        {
            LinkButton btnsubmit = sender as LinkButton;
            GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
            string status = ((Label)(gRow.FindControl("lblstatus"))).Text;
       
            txtDistName.Text = ((Label)(gRow.FindControl("lbldnm"))).Text;
           
            btn_Update.Visible = true;
            btn_Save.Visible = false;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }

    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        
      
        try
        {
            if (ValidateForm())
            {
               
               
                UserName = Session["UsrName"].ToString();
              
                DataTable dt = new DataTable();

                objinsert.statecd = ddlstate.SelectedValue;
                objinsert.distlgcd = txtDistCodelg.Text;
                objinsert.distcd = lblDcode.Text;
                objinsert.distname = txtDistName.Text;
              
                objinsert.userid = UserName;
           
                objinsert.Flage = "U";
             
                dt = objDist.insertDistDAL(objinsert);//StateCode, txtDistCode.Text.Trim(), txtDistName.Text.Trim(), date, ActiveSt, UserName, INSERT);
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
               
                    txtDistName.Text = "";
                  lblDcode.Text = "";
                    txtDistCodelg.Text = "";
                   // rbnSn.Checked = false;
                }
                getDistrictDtls();
                GetDistCode();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }




    protected void btn_clear_Click(object sender, EventArgs e)
    {
         try
        {
        BindStates();
        
        lblDcode.Visible = false;
        btn_Update.Visible = false;
        GetDistCode();      
        btn_Save.Visible = true;
       
        txtDistName.Text = "";
       // txtDistCode.Text = "";
     
      
        
        }
         catch (Exception ex)
         {
             ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
             Response.Redirect("~/lg/Error.aspx");
         }
    }
}