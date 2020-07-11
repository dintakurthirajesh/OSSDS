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


public partial class SubSchemeMaster : System.Web.UI.Page
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
              //  BindYear();
                bindscheme();
                bindgridview(); 
            }
        }
        //protected void BindYear()
        //{
        //    int years;
        //    string yearcd = "";
        //    if (DateTime.Today.Month >= 4)
        //        years = DateTime.Today.Year;
        //    else
        //        years = DateTime.Today.Year - 1;

        //    yearcd = years.ToString().Substring(2, 2);
        //    DataTable dt = new DataTable();
        //    dt = NfsmMaster.GetFInYear(Session["constr"].ToString());
        //    objCommon.BindDropDownLists(ddlfinyear, dt, "year_desc", "year_code", "Select Fin Year");
        //    ddlfinyear.SelectedValue = yearcd.ToString();
        //    ddlfinyear.Enabled = false;
        //}
        protected void bindscheme()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();

            //if (ddlfinyear.SelectedValue != "")
            //{
            //    nfsmobj.yearcd = ddlfinyear.SelectedValue;
            //}
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
            objCommon.BindDropDownLists_withZero(ddlscheme, dt, "scheme_name", "scheme_code", "Select Scheme");


        }
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            nfsmobj = new NFSM_Members();
          //  nfsmobj.yearcd = ddlfinyear.SelectedValue;
            nfsmobj.schemecode = ddlscheme.SelectedValue;
            nfsmobj.Componentname = txtschemename.Text;
            nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
            nfsmobj.userid = Session["UsrName"].ToString();
            if (btnsubmit.Text != "Update")
            {
                nfsmobj.Flag = "I";
            }
            else
            {
                nfsmobj.Flag = "U";
                nfsmobj.Componentcode = lblschemeid.Text;
            }
            DataTable dt = new DataTable();
            dt = NfsmMaster.insert_subScheme_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                bindgridview();
                Cleardata();
            }
            else
            {
                objCommon.ShowAlertMessage("Item Subsidy Details Not " + btnsubmit.Text + " Successfully");
            }
        }
        private void Cleardata()
        {

            lblschemeid.Text = "";
            btnsubmit.Text = "Submit";
          
            txtschemename.Text = "";
            bindgridview();
            bindscheme();
        }
        protected void bindgridview()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();

            if (ddlscheme.SelectedValue != "0")
            {
                nfsmobj.schemecode = ddlscheme.SelectedValue;
            }
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_subScheme_IURD(nfsmobj, Session["constr"].ToString());
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
    
        protected void linklinkedit_OnClick(object sender, EventArgs e)
        {

          
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
            Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
            Label lblschemecd = (Label)gv.FindControl("lblschemecode");
            Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
            Label lblsubschemename = (Label)gv.FindControl("lblsubschemename");
        //    ddlfinyear.SelectedValue = lvlfinyear.Text.Trim();
            bindscheme();
            ddlscheme.SelectedValue = lblschemecd.Text.Trim();
            txtschemename.Text = lblsubschemename.Text;
            lblschemeid.Text = lblsubschemecode.Text;
            btnsubmit.Text = "Update";
        }
        protected void linkDelete_OnClick(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
          
          Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
            Label lblschemecd = (Label)gv.FindControl("lblschemecode");
      Label lblsubschemecode = (Label)gv.FindControl("lblsubschemecode");
            Label lblsubschemename = (Label)gv.FindControl("lblsubschemename");
            nfsmobj = new NFSM_Members();
            nfsmobj.schemecode = lblschemecd.Text;
            nfsmobj.Componentname = lblsubschemename.Text;
            nfsmobj.Componentcode = lblsubschemecode.Text;
           // nfsmobj.yearcd = lvlfinyear.Text;
            nfsmobj.Flag = "D";
            DataTable dt = new DataTable();
            dt = NfsmMaster.insert_subScheme_IURD(nfsmobj, Session["constr"].ToString());
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
        protected void ddlscheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindgridview();
        }
}
