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
public partial class MandalMaster : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();
    Validate objValidate = new Validate();
    LocationBE objinsert = new LocationBE();
    DataTable ddt;
    ListItem li;
    string StateCode = "", Flag_IUP, UserName = "";
    string INSERT, UPDATE, DELETE;
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
              
                StateCode = Session["StateCode"].ToString();
                UserName = Session["UsrName"].ToString();
                ddt = objDist.viewdataDALlg(Session["StateCode"].ToString());
                objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                btn_Update.Visible = false;
                ddl_mandal_code.Items.Insert(0, new ListItem("Select Mandal", "0"));
               // Viewdata();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");

        }
    }

    

    protected void GvMandal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Dlt")
            {
                DataTable dt = new DataTable();
                StateCode = Session["StateCode"].ToString();
                UserName = Session["UsrName"].ToString();

                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label hdndistcode = (Label)gvrow.FindControl("lbldistrictcode");
                Label lblMCode = (Label)gvrow.FindControl("lblMCode");
                Label lblvillagename = (Label)gvrow.FindControl("lblvName");
                Label lblMLGCode = (Label)gvrow.FindControl("lblMLGCode");             
                objinsert.distcd = hdndistcode.Text;
                objinsert.mandalcd = lblMCode.Text;
                objinsert.panchayatcd = ((Label)(gvrow.FindControl("lblvillagelgcode"))).Text;
                objinsert.panchayatlgcd = ((Label)(gvrow.FindControl("lblvillagelgcode"))).Text;
                objinsert.panchayatname = lblvillagename.Text;              
                objinsert.userid = UserName;               
                objinsert.Flage = "D";


                dt = objDist.InsertGramPanchayat_IDUR(objinsert);
          
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                
                    txtgpname.Text = "";
                    //txtMandalLGCode.Text = "";
                    Viewdata();
                }

            }
            else if (e.CommandName == "Edt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                Label hdndistcode = (Label)gvrow.FindControl("lbldistrictcode");
                ddl_dist_code.SelectedValue = ((Label)(gvrow.FindControl("lbldistrictcode"))).Text;
                ddl_dist_code.Enabled = false;
                if (ddl_dist_code.SelectedIndex > 0)
                {
                    DataTable dt = new DataTable();
                    dt = objDist.viewDistdataDAL(ddl_dist_code.SelectedValue, "R");
                    objCommon.BindDropDownLists(ddl_mandal_code, dt, "MandName", "MandCode", "Select Mandal");
                    ddl_mandal_code.SelectedValue = ((Label)(gvrow.FindControl("lblMCode"))).Text;
                    ddl_mandal_code.Enabled = false;
                }
             
              
                txtgplgcode.Text = ((Label)(gvrow.FindControl("lblvillagelgcode"))).Text;
                lblMcode.Text = ((Label)(gvrow.FindControl("lblvillagelgcode"))).Text;
                txtgpname.Text = ((Label)(gvrow.FindControl("lblvName"))).Text;

              
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
        if (txtgpname.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Gram Panchayat Name");
            txtgpname.Focus();
            return false;
        }
      

        return true;
    }

    IFormatProvider provider = new System.Globalization.CultureInfo("fr-FR", true);
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {

            if (Validate())
            {
                
                
                string UserName = Session["UsrName"].ToString();
              
                DataTable dt = new DataTable();


            
                objinsert.statecd = Session["StateCode"].ToString(); 
                //objinsert.distlgcd = txtDistCode.Text;
                objinsert.distcd = ddl_dist_code.SelectedValue.ToString();
                objinsert.mandalcd = ddl_mandal_code.SelectedValue.Trim();
                objinsert.panchayatcd = txtgplgcode.Text.Trim();
               // objinsert.panchayatlgcd = txtgplgcode.Text.Trim();
                objinsert.panchayatname = txtgpname.Text.Trim();              
                objinsert.userid = UserName;
               
                objinsert.Flage = "I"; 
                objinsert.MandalType = "";

                dt = objDist.InsertGramPanchayat_IDUR(objinsert);

                
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "succ")
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());

                        txtgpname.Text = "";
                        txtgplgcode.Text = "";
                        ddt = objDist.viewdataDALlg(Session["StateCode"].ToString());
                        objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                        btn_Update.Visible = false;
                        ddl_mandal_code.Items.Insert(0, new ListItem("Select Mandal", "0"));
                       
                    }
                    else
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    }
                    
                }
                Viewdata();


            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");

        }


    }
    protected void ddl_dist_code_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        if (ddl_dist_code.SelectedIndex > 0)
        {
            DataTable dt = new DataTable();
            dt = objDist.viewDistdataDAL(ddl_dist_code.SelectedValue,"R");
            objCommon.BindDropDownLists(ddl_mandal_code, dt, "MandName", "MandCode", "Select Mandal");
            Viewdata();
        }
        else
            objCommon.ShowAlertMessage("Select District");   

    }
    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            Flag_IUP = "R";
            dt1 = objDist.GetGramPanchayatDetails(ddl_dist_code.SelectedValue, ddl_mandal_code.SelectedValue, Flag_IUP);
            if (dt1.Rows.Count > 0)
            {
                GvMandal.Visible = true;
                GvMandal.DataSource = dt1;
                GvMandal.DataBind();
            }
            else
            {
                objCommon.ShowAlertMessage("No data found");
                GvMandal.Visible = false;
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
            ddl_mandal_code.SelectedValue = ((Label)(gRow.FindControl("lblMCode"))).Text;
            txtgpname.Text = ((Label)(gRow.FindControl("lblMName"))).Text;
          
            lblMcode.Visible = false;
            
          
            btn_Update.Visible = true;
            btn_Save.Visible = false;
            ddl_mandal_code.Enabled = false;
            //txtMandalLGCode.Enabled = true;
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
            if (Validate())
            {
                
                string StateCode = Session["StateCode"].ToString();
                INSERT = "U";
                string UserName = Session["UsrName"].ToString();
           
                DataTable dt = new DataTable();


            


                objinsert.statecd = StateCode;
              
                objinsert.distcd = ddl_dist_code.SelectedValue.ToString();
                objinsert.mandalcd = ddl_mandal_code.SelectedValue.Trim();
                objinsert.panchayatlgcd = lblMcode.Text;
                objinsert.panchayatcd = txtgplgcode.Text.Trim();
                objinsert.panchayatname = txtgpname.Text.Trim();            
                objinsert.userid = UserName;          
                objinsert.Flage = INSERT;

                dt = objDist.InsertGramPanchayat_IDUR(objinsert);
            
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "succ")
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        txtgpname.Text = "";
                        ddl_dist_code.Enabled = true;
                        ddl_mandal_code.Enabled = true;                      
                        btn_Save.Visible = true;
                        btn_Update.Visible = false;
                       
                        txtgplgcode.Text = "";
                        ddt = objDist.viewdataDALlg(Session["StateCode"].ToString());
                        objCommon.BindDropDownLists(ddl_dist_code, ddt, "DistName", "DistCode", "0");
                        btn_Update.Visible = false;
                        ddl_mandal_code.Items.Insert(0, new ListItem("Select Mandal", "0"));
                    }
                    else
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                    }
                   
                }
                else
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                }
                Viewdata();


            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }
  
    protected void ddl_mandal_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_mandal_code.SelectedIndex > 0)
        {
            Viewdata();
        }
        else
        {
            GvMandal.Visible = false;

        }

        txtgpname.Text = "";   
       
        btn_Save.Visible = true;
        btn_Update.Visible = false;
    }
}
