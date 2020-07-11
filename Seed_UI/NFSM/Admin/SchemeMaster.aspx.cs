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


    public partial class SchemeMaster : System.Web.UI.Page
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
             
                  bindgridview();
            }
        }
      
        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            nfsmobj = new NFSM_Members();
            nfsmobj.schemename = txtschemename.Text;
            nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
            nfsmobj.userid = Session["userid"].ToString();
            if (btnsubmit.Text != "Update")
            {
                nfsmobj.Flag = "I";
            }
            else
            {
                nfsmobj.Flag = "U";
                nfsmobj.schemecode = lblschemeid.Text;
            }
            DataTable dt = new DataTable();
            dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
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
        }
        protected void bindgridview()
        {
            DataTable dt = new DataTable();
            nfsmobj = new NFSM_Members();
         
         
            nfsmobj.Flag = "R";
            dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {

                gvitemsubsidy.DataSource = dt;
                gvitemsubsidy.DataBind();
                gvitemsubsidy.Visible = true;
              //  btnsubmit.Visible = true;
            }
            else
            {
                gvitemsubsidy.Visible = false;
              //  btnsubmit.Visible = false;
            }


        }
        protected void linklinkedit_OnClick(object sender, EventArgs e)
        {

            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
         //   Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
            Label lblschemecd = (Label)gv.FindControl("lblschemecode");
            Label lblschemename = (Label)gv.FindControl("lblschemename");

            txtschemename.Text = lblschemename.Text;
            lblschemeid.Text = lblschemecd.Text;
            btnsubmit.Text = "Update";
        }
        protected void linkDelete_OnClick(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;
          
          Label lvlfinyear = (Label)gv.FindControl("lblyearcd");
            Label lblschemecd = (Label)gv.FindControl("lblschemecode");
            Label lblschemename = (Label)gv.FindControl("lblschemename");
            nfsmobj = new NFSM_Members();
            nfsmobj.schemecode = lblschemecd.Text;
            nfsmobj.schemename = lblschemename.Text;
           
          //  nfsmobj.yearcd = lvlfinyear.Text;
            nfsmobj.Flag = "D";
            DataTable dt = new DataTable();
            dt = NfsmMaster.insert_Scheme_IURD(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                Cleardata();
            }
            bindgridview();

        }
        protected void btnreset_Click(object sender, EventArgs e)
        {

        }
}
