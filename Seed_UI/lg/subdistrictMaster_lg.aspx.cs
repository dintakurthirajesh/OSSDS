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
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");

        }
    }

    protected void GetmandalCode()
    {
        DataTable dt = new DataTable();
        dt = objDist.GetMaxmandalCode(ddl_dist_code.SelectedValue);
        lblMcode.Text = dt.Rows[0][0].ToString();
        lblMcode.Enabled = false;
        lblMcode.Visible = false;
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
                HiddenField hdndistcode = (HiddenField)gvrow.FindControl("hdndistcode");
                Label lblMCode = (Label)gvrow.FindControl("lblMCode");
                Label lblMName = (Label)gvrow.FindControl("lblMName");
                Label lblMLGCode = (Label)gvrow.FindControl("lblMLGCode");             
                objinsert.distcd = hdndistcode.Value;
                objinsert.mandalcd = lblMCode.Text;
                objinsert.mandallgcd = lblMLGCode.Text.Trim();
                objinsert.mandalname = lblMName.Text;              
                objinsert.userid = UserName;               
                objinsert.Flage = "D";
                objinsert.MandalType = "";

                dt = objDist.insertsubdistrictDAL(objinsert);
            //    dt = objDist.DeletemandalBAL(hdndistcode.Value, lblMCode.Text, lblMName.Text, "");
                if (dt.Rows.Count > 0)
                {
                    objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                  //  txtMandalCode.Text = "";
                    txtMandalName.Text = "";
                    //txtMandalLGCode.Text = "";
                    Viewdata();
                }

            }
            else if (e.CommandName == "Edt")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                HiddenField hdndistcode = (HiddenField)gvrow.FindControl("hdndistcode");
             //   ddl_dist_code.SelectedValue =((HiddenField)(gvrow.FindControl("hdndistcode"))).Value;
                lblMcode.Text = ((Label)(gvrow.FindControl("lblMCode"))).Text;
                txtMandallgCode.Text = ((Label)(gvrow.FindControl("lblMLGCode"))).Text;
                txtMandalName.Text = ((Label)(gvrow.FindControl("lblMName"))).Text;

               
               
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
       
        if (txtMandalName.Text == "")
        {
            objCommon.ShowAlertMessage("Enter Mandal Name");
            txtMandalName.Focus();
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

                GetmandalCode();
                objinsert.statecd = Session["StateCode"].ToString(); 
                //objinsert.distlgcd = txtDistCode.Text;
                objinsert.distcd = ddl_dist_code.SelectedValue.ToString();
                objinsert.mandalcd = lblMcode.Text;
                objinsert.mandallgcd = txtMandallgCode.Text.Trim();
                objinsert.mandalname = txtMandalName.Text.Trim();
              
                objinsert.userid = UserName;
              
                objinsert.Flage = "I"; 
                objinsert.MandalType = "";

                dt = objDist.insertsubdistrictDAL(objinsert);

                
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "succ")
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                      
                       
                        txtMandalName.Text = "";
                        txtMandallgCode.Text = "";
                        //txtMandalLGCode.Text = "";
                        //txtMandalLGCode.Enabled = true;
                        
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
            Viewdata();
        }
        else
        {
            GvMandal.Visible = false;

        }
      
        txtMandalName.Text = "";
        //txtMandalLGCode.Text = "";
     
       
        //txtMandalLGCode.Enabled = true;
   
        btn_Save.Visible = false;
        btn_Update.Visible = false;

    }
    public void Viewdata()
    {
        try
        {
            DataTable dt1 = new DataTable();
            Flag_IUP = "R";
            dt1 = objDist.viewDistdataDAL(ddl_dist_code.SelectedValue.ToString(), Flag_IUP);
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
          
            lblMcode.Text = ((Label)(gRow.FindControl("lblMCode"))).Text;
            txtMandalName.Text = ((Label)(gRow.FindControl("lblMName"))).Text;
            //txtMandalLGCode.Text = ((Label)(gRow.FindControl("lblMLGCode"))).Text;
          
            lblMcode.Visible = false;
            
          
            btn_Update.Visible = true;
            btn_Save.Visible = false;
            lblMcode.Enabled = false;
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
                //string StateCode = Session["StateCode"].ToString();
                //UPDATE = "U";
                //string UserName = Session["UsrName"].ToString();
                //int ActiveSt = (rbnSn.Checked ? 0 : (rbnSy.Checked ? 1 : 0));
                //DataTable dt = new DataTable();
                string StateCode = Session["StateCode"].ToString();
                INSERT = "U";
                string UserName = Session["UsrName"].ToString();
             
                DataTable dt = new DataTable();



                objinsert.statecd = StateCode;
                //objinsert.distlgcd = txtDistCode.Text;
                objinsert.distcd = ddl_dist_code.SelectedValue.ToString();
                objinsert.mandalcd = lblMcode.Text.Trim();
                
                objinsert.mandallgcd = txtMandallgCode.Text.Trim();
                objinsert.mandalname = txtMandalName.Text.Trim();              
                objinsert.userid = UserName;              
                objinsert.Flage = INSERT;
                objinsert.MandalType = "";

                dt = objDist.insertsubdistrictDAL(objinsert);
           
                if (dt.Rows.Count > 0)
                {
                    if (dt.Columns[0].ColumnName == "succ")
                    {
                        objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                        txtMandalName.Text = "";
                        //txtMandalLGCode.Text = "";

                        btn_Save.Visible = false;
                        btn_Update.Visible = false;
                        
                        txtMandallgCode.Text = "";
                       
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
    protected void txtMandalCode_TextChanged(object sender, EventArgs e)
    {
        try
        {
           
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, "", Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/lg/Error.aspx");
        }
    }
}
