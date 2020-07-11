using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Seed_BL;
using Seed_BE;
using Seed_DL;
using System.Data;
using System.Web.UI.WebControls;
using System.Text;


    public partial class CropMaster : System.Web.UI.Page
    {
        MasterDAL objDist = new MasterDAL();
        CommonFuncs objCommon = new CommonFuncs();
        LocationBE objinsert = new LocationBE();
        Validate objValidate = new Validate();
        NFSM_MasterDL NfsmMaster = new NFSM_MasterDL();
        NFSM_Members nfsmobj = new NFSM_Members();
        NFSM_Farmer_Scheme_DL obj = new NFSM_Farmer_Scheme_DL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
              
                bindscheme();

                bindgridview();
            }
        }
       
        protected void bindscheme()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();

            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
            objCommon.BindDropDownLists_withZero(ddlschemename, dt, "scheme_name", "scheme_code", "Select Scheme");

            ddlsubcheme.Items.Clear();
            ddlsubcheme.Items.Insert(0, new ListItem("Select Component", "0"));
            ddlcropname.Items.Clear();
            ddlcropname.Items.Insert(0, new ListItem("Select  Select Intervension", "0"));
            ddlintervension.Items.Clear();
            ddlintervension.Items.Insert(0, new ListItem("Select Select Sub Intervension", ""));

        }
        protected void bindsubscheme()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();

          
            if (ddlschemename.SelectedValue != "")
            {
                nfsmobj.schemecode = ddlschemename.SelectedValue;
            }
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_subScheme_IURD(nfsmobj, Session["constr"].ToString());
            objCommon.BindDropDownLists_withZero(ddlsubcheme, dt, "Component_name", "Component_code", "Select Component");
            
            ddlcropname.Items.Clear();
            ddlcropname.Items.Insert(0, new ListItem("Select  Select Crop", "0"));
            ddlintervension.Items.Clear();
            ddlintervension.Items.Insert(0, new ListItem("Select Select Intervension", "0"));
            

        }
        protected void bindcrop()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();

           
            if (ddlschemename.SelectedValue != "")
            {
                nfsmobj.schemecode = ddlschemename.SelectedValue;
            }
            if (ddlsubcheme.SelectedValue != "" && ddlsubcheme.SelectedValue != "")
            {
                nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
            }
           
           
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_crop_IURD(nfsmobj, Session["constr"].ToString());
            objCommon.BindDropDownLists_withZero(ddlcropname, dt, "interven_Name", "interven_code", "Select Intervension");
            ddlintervension.Items.Clear();
            ddlintervension.Items.Insert(0, new ListItem("Select Select sub Intervension", "0"));

        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
         
            nfsmobj.schemecode = ddlschemename.SelectedValue;
            nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
            nfsmobj.intervensioncd = ddlcropname.SelectedValue;
            nfsmobj.subintervensioncd = ddlintervension.SelectedValue;
            nfsmobj.itemname = txtitemname.Text;
            nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
            nfsmobj.userid = Session["UsrName"].ToString();
            if (btnsubmit.Text != "Update")
            {
                nfsmobj.Flag = "I";
            }
            else
            {
                nfsmobj.Flag = "U";
                nfsmobj.itemcd = lblitemcode.Text;
            }
            DataTable dt = new DataTable();
            dt = NfsmMaster.insert_Item_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Cleardata();
            }
            else
            {
                objCommon.ShowAlertMessage("Item Details Not " + btnsubmit.Text + " Successfully");
            }
        }
        private void Cleardata()
        {

            lblitemcode.Text = "";
            btnsubmit.Text = "Submit";
         
            txtitemname.Text = "";
            bindgridview();
            bindscheme();
        }
        protected void bindgridview()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();
            if (ddlschemename.SelectedValue != "")
            {
                nfsmobj.schemecode = ddlschemename.SelectedValue;
            }
            if (ddlsubcheme.SelectedValue != "" && ddlsubcheme.SelectedValue != "0")
            {
                nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
            }
           
            if (ddlcropname.SelectedValue != "" && ddlcropname.SelectedValue != "0")
            {
                nfsmobj.intervensioncd = ddlcropname.SelectedValue;
            }
            if (ddlintervension.SelectedValue != "" && ddlintervension.SelectedValue != "0")
            {
                nfsmobj.subintervensioncd = ddlintervension.SelectedValue;
            }
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_Item_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {

                gvitemsubsidy.DataSource = dt;
                gvitemsubsidy.DataBind();
                gvitemsubsidy.Visible = true;

            }
            else
            {
                gvitemsubsidy.Visible = false;

            }


        }
        protected void bindintervension()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();

            if (ddlschemename.SelectedValue != "")
            {
                nfsmobj.schemecode = ddlschemename.SelectedValue;
            }
            if (ddlsubcheme.SelectedValue != "")
            {
                nfsmobj.Componentcode = ddlsubcheme.SelectedValue;
            }
           
            if (ddlcropname.SelectedValue != "")
            {
                nfsmobj.intervensioncd = ddlcropname.SelectedValue;
            }
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_SubIntervention_IURD(nfsmobj, Session["constr"].ToString());
            objCommon.BindDropDownLists_withZero(ddlintervension, dt, "Subinterven_name", "Subinterven_code", "Select SubIntervension");


        }
        protected void linklinkedit_OnClick(object sender, EventArgs e)
        {


            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
            Label lblschemecd = (Label)gv.FindControl("lblschemecode");
            Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
            Label lblcropcd = (Label)gv.FindControl("lblcropcode");
            Label lblinetervencode = (Label)gv.FindControl("lblinetervencode");
            Label lblitemname = (Label)gv.FindControl("lblitemname");
            Label lblitem_code = (Label)gv.FindControl("lblitemcode");
          //  
           
            bindscheme();
            ddlschemename.SelectedValue = lblschemecd.Text.Trim();
            bindsubscheme();
            ddlsubcheme.SelectedValue = lblsubschemecode.Text.Trim();
            bindcrop();
            ddlcropname.SelectedValue = lblcropcd.Text.Trim();
            bindintervension();
            ddlintervension.SelectedValue = lblinetervencode.Text.Trim();
            txtitemname.Text = lblitemname.Text;
            lblitemcode.Text = lblitem_code.Text;
            btnsubmit.Text = "Update";
        }
        protected void linkDelete_OnClick(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
            Label lblschemecd = (Label)gv.FindControl("lblschemecode");
            Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
            Label lblcropcode = (Label)gv.FindControl("lblcropcode");
            Label lblinetervencode = (Label)gv.FindControl("lblinetervencode");
            Label lblitemname = (Label)gv.FindControl("lblitemname");
            Label lblitem_code = (Label)gv.FindControl("lblitemcode");
            nfsmobj = new NFSM_Members();
            nfsmobj.schemecode = lblschemecd.Text;
            nfsmobj.intervensioncd = lblcropcode.Text;
            nfsmobj.subintervensioncd = lblinetervencode.Text;
            nfsmobj.itemcd = lblitem_code.Text.Trim();
            nfsmobj.itemname = lblitemname.Text;
            nfsmobj.Componentcode = lblsubschemecode.Text;
          
            nfsmobj.Flag = "D";
            DataTable dt = new DataTable();
            dt = NfsmMaster.insert_Item_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Cleardata();
            }
            bindgridview();

        }
        protected void btnreset_Click(object sender, EventArgs e)
        {
            Cleardata(); ;
        }
        protected void ddlschemename_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindsubscheme();
            bindgridview();
        }
        protected void ddlsubcheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindcrop();
            bindgridview();
        }
        protected void ddlcropname_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgridview();
            bindintervension();
        }
        protected void ddlintervension_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgridview(); 
        }
}
