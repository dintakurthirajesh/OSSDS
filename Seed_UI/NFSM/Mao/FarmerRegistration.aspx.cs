using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Seed_BL;
using Seed_BE;
using Seed_DL;
using System.Data;
using System.Web.Script.Serialization;
public partial class NFSM_Default : System.Web.UI.Page
{
    MasterDAL objDist = new MasterDAL();
    CommonFuncs objCommon = new CommonFuncs();
    LocationBE objinsert = new LocationBE();
    Validate objValidate = new Validate();
    NFSM_MasterDL NfsmMaster = new NFSM_MasterDL();
    NFSM_Members nfsmobj = new NFSM_Members();
    CommonFuncs cf = new CommonFuncs();
    NFSM_Farmer_Scheme_DL obj = new NFSM_Farmer_Scheme_DL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.ServerVariables["HTTP_REFERER"] == null) || (Request.ServerVariables["HTTP_REFERER"] == ""))
        {
            Response.Redirect("~/nfsm/Error.aspx");
        }
        else
        {
            string http_ref = Request.ServerVariables["HTTP_REFERER"].Trim();
            string http_hos = Request.ServerVariables["HTTP_HOST"].Trim();
            int len = http_hos.Length;
            if (http_ref.IndexOf(http_hos, 0) < 0)
            {
                Response.Redirect("~/nfsm/Error.aspx");
            }
        }
        if (Session["Rolecode"] == null)
        {
            Response.Redirect("~/nfsm/Error.aspx");
        }

        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
        //clear Caching 
        PrevBrowCache.enforceNoCache();
        if (!IsPostBack)
        {
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblMand.Text = Session["mandal"].ToString();
            BindStates();
            getDistrictDtls();
            ddldistrict.SelectedValue = Session["distCode"].ToString();
            BindCaste();
            BindBanks();
            BindCategory();
            BindGender();

            getMandalDtls();
            ddlmandal.SelectedValue = Session["mandcode"].ToString();
            getVillageDtls();
            ddldistrict.Enabled = false;
            //  ddlmandal.Enabled = false;
            if (Session["Rolecode"] != null)
            {
                if (Session["Rolecode"].ToString() == "4")
                {
                    ddldistrict.SelectedValue = Session["distCode"].ToString();
                    ddldistrict.Enabled = false;
                    getMandalDtls();
                    ddlmandal.SelectedValue = Session["mandcode"].ToString();
                    ddlmandal.Enabled = false;
                    getVillageDtls();

                }
            }

        }
    }
    protected void BindCaste()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetCasteDetails(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlCaste, dt, "CasteName", "CasteCode", "Select Caste");

    }
    protected void BindCategory()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetCategoryDetails(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlcategory, dt, "Category_Name", "Category_Code", "Select Category");

    }
    protected void BindBanks()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetBanks(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlbank, dt, "BankName", "BankCode", "Select Bank");

    }
    protected void BindGender()
    {
        DataTable dt = new DataTable();
        dt = NfsmMaster.GetGender(Session["constr"].ToString());
        objCommon.BindDropDownLists(ddlgender, dt, "GenderName", "GenderCode", "Select Gender");

    }
    protected void BindStates()
    {
        DataTable dt = new DataTable();
        dt = objDist.getStates();
        objCommon.BindDropDownLists(ddlstate, dt, "StateName", "StateCode", "Select State");
        ddlstate.Enabled = false;
        ddlstate.SelectedValue = "36";
    }
    protected void getDistrictDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Dis";
        objinsert.statecd = ddlstate.SelectedValue;
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " DistName Asc ";
        objCommon.BindDropDownLists(ddldistrict, dtDistricts, "DistName", "DistCode_Lg", "Select District");
        ddlmandal.Items.Clear();
        ddlmandal.Items.Insert(0, new ListItem("Select Mandal", ""));
        ddlvillage.Items.Clear();
        ddlvillage.Items.Insert(0, new ListItem("Select Village", ""));

    }
    protected void getMandalDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Man";
        objinsert.statecd = ddlstate.SelectedValue;
        objinsert.distlgcd = ddldistrict.SelectedValue;
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " MandName Asc ";
        objCommon.BindDropDownLists(ddlmandal, dtDistricts, "MandName", "MandCode_LG", "Select Mandal");
        ddlvillage.Items.Clear();
        ddlvillage.Items.Insert(0, new ListItem("Select Village", ""));
    }
    protected void getVillageDtls()
    {
        DataTable dtDistricts = new DataTable();
        objinsert.Flage = "Vil";
        objinsert.statecd = ddlstate.SelectedValue;
        objinsert.distlgcd = ddldistrict.SelectedValue;
        objinsert.mandallgcd = ddlmandal.SelectedValue;
        dtDistricts = NfsmMaster.Getlocationdet(objinsert, Session["constr"].ToString());
        dtDistricts.DefaultView.Sort = " Villname Asc ";
        objCommon.BindDropDownLists(ddlvillage, dtDistricts, "Villname", "VillCode_LG", "Select Village");

    }
    protected void ddldistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddldistrict.SelectedValue != "")
        {
            getMandalDtls();

            ddlvillage.Items.Clear();

            ddlvillage.Items.Insert(0, new ListItem("Select Village", ""));
        }
    }
    protected void ddlmandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmandal.SelectedValue != "")
        {
            getVillageDtls();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            nfsmobj.address = txtaddress.Text;
            nfsmobj.aadharno = txtpaadharno.Text;
            nfsmobj.farmerid = txtpaadharno.Text;
            nfsmobj.farmername = txtname.Text;
            nfsmobj.fatherorhusname = txtfathername.Text;
            nfsmobj.gendercd = ddlgender.SelectedValue;
            nfsmobj.catstecd = ddlCaste.SelectedValue;

            nfsmobj.statecd = ddlstate.SelectedValue;
            nfsmobj.distcd = ddldistrict.SelectedValue;
            nfsmobj.mandalcd = ddlmandal.SelectedValue;
            nfsmobj.villagecd = ddlvillage.SelectedValue;
            nfsmobj.emailid = txtemailid.Text;
            nfsmobj.mobileno = txtmobileno.Text;
            nfsmobj.bankcd = ddlbank.SelectedValue;
            nfsmobj.ifsccode = txtifsccode.Text;
            nfsmobj.accountno = txtbankaccount.Text;
            nfsmobj.DifferentlyAbled = rbldiff.SelectedValue;
            nfsmobj.percentDisability = txtperdisal.Text;
            nfsmobj.categorycd = ddlcategory.SelectedValue;
            //nfsmobj.pattadharno = txtpattano.Text;
            //nfsmobj.landextent = txtlandextent.Text;
            nfsmobj.ipaddress = HttpContext.Current.Request.UserHostAddress;
            nfsmobj.userid = Session["UsrName"].ToString();
            nfsmobj.Flag = "I";
            DataTable dt = new DataTable();

            dt = obj.InsertandupdateFarmerDetails(nfsmobj, Session["constr"].ToString());
            if (dt.Rows.Count > 0)
            {
                objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
            }
            else
            {
                objCommon.ShowAlertMessage("Farmer Not Registered");
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/nfsm/Error.aspx");

        }
    }
    protected void txtaadharno_TextChanged(object sender, EventArgs e)
    {
        if (txtaadharno.Text == "")
        {
            objCommon.ShowAlertMessage("Please Enter Aadhar No");
            txtaadharno.Focus();
            return;
        }
        try
        {
            //GetAadhardetailsfromCGG.KharifCottonCropFarmerReportSoapClient objclient = new GetAadhardetailsfromCGG.KharifCottonCropFarmerReportSoapClient();

            //var serializer = new JavaScriptSerializer();
            //List<FarmerDetails> deserialized = serializer.Deserialize<List<FarmerDetails>>(objclient.GetFarmerDetailsByAadhar("NIC", "Nic20180112", txtaadharno.Text));
            //RBService.PPB_FarmerData clint = new RBService.PPB_FarmerData();


            //List<FarmerDetails> deserialized = serializer.Deserialize<List<FarmerDetails>>(objclient.GetFarmerDetailsByAadhar("NIC", "Nic20180112", txtaadharno.Text));
            RbService.RB_PPBDetails clint = new RbService.RB_PPBDetails();

            var item = clint.GetFarmerPPBDetailsbyAadhar(txtaadharno.Text, "RB", "RB$Admin@1687");
            foreach (var items in item)
            {
                txtname.Text = items.FarmerName_Eng;
                txtmobileno.Text = items.MobileNo;
                txtifsccode.Text = items.IFSCCode;
                txtpaadharno.Text = items.Aadhaarid;
                txtbankaccount.Text = items.AccountNo;

                ddlgender.SelectedItem.Text = items.GenderName;

                try
                {
                    getDistrictDtls();
                    ddldistrict.SelectedValue = items.DISTNAME;

                }
                catch { }
                if (ddldistrict.SelectedValue != "")
                {
                    getMandalDtls();

                    try
                    {
                        ddlmandal.SelectedValue = items.MANDNAME;
                    }
                    catch { }
                }
                if (ddlmandal.SelectedValue != "")
                {
                    getVillageDtls();

                    try
                    {
                        ddlvillage.SelectedValue = items.villcode;
                    }
                    catch { }
                }
                try
                {
                    ddlbank.SelectedItem.Text = items.BANKNAME;
                }
                catch { }

                if (ddldistrict.SelectedValue == "")
                {
                    getDistrictDtls();
                }
                if (ddlmandal.SelectedValue == "" && ddldistrict.SelectedValue != "")
                {
                    getMandalDtls();

                }
                if (ddlvillage.SelectedValue == "" && ddlmandal.SelectedValue != "")
                {
                    getVillageDtls();
                }
            }
        }
        catch { }

    }

}