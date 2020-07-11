using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using System.Data;
using System.Web.Security;


public partial class Master_CropMaster : System.Web.UI.Page
{
    MasterBAL objDist = new MasterBAL();
     CommonFuncs objCommon = new CommonFuncs();
    string INSERT, UPDATE;
    string UserName = "";
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
        if (Session["UsrName"] == null || Session["UsrName"].ToString() != "Admin")
        {
            Response.Redirect("~/Error.aspx");
        }
        lblUsrName.Text = Session["Role"].ToString();
        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        if (!IsPostBack)
        {
            viewdata();        
            btn_Update.Visible = false;   
        }
    }

    protected void btn_Save_Click(object sender, EventArgs e)
    {
        //  string StateCode = Session["StateCode"].ToString();INSERT INTO LR_CropMst (CropName,CropType,SeedRate,No_of_Acres,Quantity_in_Kgs,packing_size,Slno) 
		//	VALUES(@CropName,@cropType,@seedrate,@no_of_acres,@qty,@packsize,@slno)
        //string CropName,string type, string no_of_acres,string qty,string packsize,string slno,string seedrate
        INSERT = "I";
        DataTable dt = new DataTable();
        try
        {
            dt = objDist.getInsertCropBAL(txtCropName.Text.Trim(), txttype.Text.Trim(), txtArea.Text.Trim(), txtqty.Text.Trim(), txtpcksize.Text.Trim(),
                Convert.ToInt32(txtslno.Text.Trim()), txtseedrate.Text.Trim(), INSERT);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Inserted Successfully";
                     objCommon.ShowAlertMessage(aa);
                     txtCropName.Text = "";
                     txttype.Text = "";
                     txtslno.Text = "";
                     txtseedrate.Text = "";
                     txtqty.Text = "";
                     txtpcksize.Text = "";
                     txtseedrate.Text = "";
                }
                else
                {
                    string aa = dt.Rows[0][0].ToString();
                    objCommon.ShowAlertMessage(aa);
                }
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
        
    }
    private void viewdata()
    {
        DataTable dt1 = new DataTable();
        // string StateCode = Session["StateCode"].ToString();
        dt1 = objDist.viewdCropBAL();
        GridView1.DataSource = dt1;
        GridView1.DataBind();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        viewdata();
    }
    protected void GridView1_RowCancelling(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        viewdata();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Dlt")
        {
            string Delete = "D";
            DataTable dt = new DataTable();
            UserName = Session["UsrName"].ToString();
            GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
            Label lblCpcode = (Label)gvrow.FindControl("lblcropcode");
            Label lblCpnm = (Label)gvrow.FindControl("lblCpnm");
            dt = objDist.DeleteCropBAL(lblCpcode.Text,Delete);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Deleted Successfully";
                    objCommon.ShowAlertMessage(aa);
                    viewdata();
                }
                else
                {
                    string aa = "Deleted Failure";
                    objCommon.ShowAlertMessage(aa);
                }
            }

        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        viewdata();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        viewdata();
    }
    
    protected void lnkEdit_Click(object sender, EventArgs e)
    {
        LinkButton btnsubmit = sender as LinkButton;
        GridViewRow gRow = (GridViewRow)btnsubmit.NamingContainer;
        txtslno.Text = ((Label)(gRow.FindControl("lblslno"))).Text;
        lblcpcode.Text = ((Label)(gRow.FindControl("lblcropcode"))).Text;
        txtCropName.Text = ((Label)(gRow.FindControl("lblCpnm"))).Text;

        txttype.Text = ((Label)(gRow.FindControl("lbltype"))).Text;
        txtArea.Text = ((Label)(gRow.FindControl("lblarea"))).Text;
        txtseedrate.Text = ((Label)(gRow.FindControl("lblseedrate"))).Text;
        txtpcksize.Text = ((Label)(gRow.FindControl("lblpcksize"))).Text;
        txtqty.Text = ((Label)(gRow.FindControl("lblqty"))).Text;

        btn_Update.Visible = true;
        btn_Save.Visible = false;
    }

    protected void btn_Update_Click(object sender, EventArgs e)
    {
        UserName = Session["UsrName"].ToString();
        UPDATE = "U";
        DataTable dt = new DataTable();
        try
        {
            dt = objDist.UpdateCropBAL(txtCropName.Text.Trim(), txttype.Text.Trim(), txtArea.Text.Trim(), txtqty.Text.Trim(), 
                txtpcksize.Text.Trim(),Convert.ToInt32( txtslno.Text.Trim()), txtseedrate.Text.Trim(), lblcpcode.Text, UPDATE);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0][0].ToString() == "1")
                {
                    string aa = "Updated Successfully";
                    objCommon.ShowAlertMessage(aa);
                    btn_Save.Visible = true;
                    txtCropName.Text = "";
                    txttype.Text = "";
                    txtslno.Text = "";
                    txtseedrate.Text = "";
                    txtqty.Text = "";
                    txtpcksize.Text = "";
                    txtseedrate.Text = "";
                    btn_Update.Visible = false;
                }
                else
                {
                    string aa = "Updated Fai";
                    objCommon.ShowAlertMessage(aa);
                }
            }
            viewdata();
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
       
    }
}