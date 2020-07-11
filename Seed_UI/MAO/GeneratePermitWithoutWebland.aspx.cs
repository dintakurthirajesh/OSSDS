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
using Seed_BL;
using Seed_BE;

public partial class MAO_GeneratePermitAlternate : System.Web.UI.Page
{
    string strConnectionString = null;
    Request_IssueBE ObjBE = new Request_IssueBE();
    Request_Issue_BL ObjBL = new Request_Issue_BL();
    SeedAllotBL seedObj = new SeedAllotBL();
    CommonFuncs cf = new CommonFuncs();
    MasterBAL objcrop = new MasterBAL();
    AOBAL objao = new AOBAL();
    Purchaser p = new Purchaser();
    SmsText smsobj = new SmsText();
    CommonBL ObjCmnBL = new CommonBL();
    string season;
    string surveynos = "";
    List<AdharList> aadharList;
    public MAO_GeneratePermitAlternate()
    {
        strConnectionString = ConfigurationManager.AppSettings["ConnectionString"];//ConfigurationManager.AppSettings["ConnectionString"];
    }
    protected void Page_Load(object sender, EventArgs e)
    {
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
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            // Binddist();
            DataTable DtDist = objao.GetDistrictsAcordingtoLogin(Session["distCode"].ToString());
            lbl_old_dist_code.Text = DtDist.Rows[0][0].ToString();
            lbl_Old_Dist.Text = DtDist.Rows[0][1].ToString();
            new_dist_code.Text = DtDist.Rows[0][2].ToString();
            dist_code_LG.Text = DtDist.Rows[0][4].ToString();
            GetSalepoints();
            //BindBanks();
            Bindmandal();
            otherTbl.Visible = false;
            season = objao.GetSeasonbyMonth(DateTime.Now.Month.ToString());
        }
    }
    protected void ddl_mandal_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindvillage();
    }
    private void Bindmandal()
    {
        DataTable DtMand = objao.GetNewMandals(new_dist_code.Text);
        cf.BindDropDownLists(ddl_mandal, DtMand, "mand_name_new", "mand_code_new", "Select Mandal");
    }
    private void GetSalepoints()
    {
        DataTable dt = new DataTable();
        dt = seedObj.GetSalepoints(Session["StateCode"].ToString(), Session["distCode"].ToString(), Session["mandcode"].ToString());
        cf.BindDropDownLists(ddlsp, dt, "SalePtName", "SalePtCode", "select sale point");
    }
    //private void BindBanks()
    //{
    //    DataTable dt = new DataTable();
    //    dt = ObjCmnBL.GetBankByStateBAL("36");
    //    cf.BindDropDownLists(ddlbank, dt, "BankName", "BankCode", "Select Bank");
    //}
    /*protected void ddl_dist_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindmandal();
    }*/
    private void Bindvillage()
    {
        DataTable DtVill = objao.GetNewVillages(new_dist_code.Text, ddl_mandal.SelectedValue);
        cf.BindDropDownLists(ddl_vill, DtVill, "VillName", "VillCode", "Select Village");
    }
   
   
    protected List<AdharList> ConvertDataSetToArrayList(DataTable dt)
    {
        List<AdharList> aadharList = dt.AsEnumerable().Select(m => new AdharList()
        {
            KahatNo = m.Field<string>("Khatha_No"),
            adharno = m.Field<string>("Aadhaar"),
        }).ToList();
        return aadharList;
    }
   
    protected void CreateNewRow()
    {
        DataTable DtSeedReq = new DataTable();
        // DtSeedReq.Columns.Add("FarmerID", typeof(string));
        DtSeedReq.Columns.Add("CropName", typeof(string));
        DtSeedReq.Columns.Add("CropCode", typeof(string));
        DtSeedReq.Columns.Add("CropVCode", typeof(string));
        DtSeedReq.Columns.Add("Extent", typeof(string));
        DtSeedReq.Columns.Add("Requirement_in_kgs", typeof(string));
        DtSeedReq.Columns.Add("nob", typeof(string));
        DtSeedReq.Columns.Add("weight", typeof(string));
        DtSeedReq.Columns.Add("Requirement_in_bags", typeof(string));
        DtSeedReq.Columns.Add("Sanctioned", typeof(string));
        DtSeedReq.Columns.Add("qtyissued", typeof(string));
        DtSeedReq.Columns.Add("StockID", typeof(string));
        DtSeedReq.Rows.Add();
        GvCropData.DataSource = DtSeedReq;
        GvCropData.DataBind();
    }

    protected void imgBtnAdd_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("CropName", typeof(string));
            dt.Columns.Add("CropCode", typeof(string));
            dt.Columns.Add("CropVCode", typeof(string));
            dt.Columns.Add("Extent", typeof(string));
            dt.Columns.Add("Requirement_in_kgs", typeof(string));
            dt.Columns.Add("nob", typeof(string));
            dt.Columns.Add("weight", typeof(string));
            dt.Columns.Add("Requirement_in_bags", typeof(string));
            dt.Columns.Add("Sanctioned", typeof(string));
            dt.Columns.Add("qtyissued", typeof(string));
            dt.Columns.Add("StockID", typeof(string));
            int j = 0;
            //string[] codes;
            foreach (GridViewRow gr in GvCropData.Rows)
            {
                string cropcode = ((DropDownList)gr.FindControl("ddlCrop")).SelectedValue;

                // double txtex = Convert.ToInt64((Label)gr.FindControl("lblCRExtent"));
                if (cropcode != "")
                {

                    dt.Rows.Add();
                    // dt.Rows[j]["FarmerID"] = ((Label)gr.FindControl("lblFarmerId")).Text;
                    // dt.Rows[j]["CropName"] = ((Label)gr.FindControl("lblCRName")).Text;
                    dt.Rows[j]["CropCode"] = ((DropDownList)gr.FindControl("ddlCrop")).SelectedValue;
                    //codes = ((DropDownList)gr.FindControl("ddlCrop")).SelectedValue.ToString();
                    dt.Rows[j]["CropName"] = ((DropDownList)gr.FindControl("ddlCrop")).SelectedItem.Text;
                    dt.Rows[j]["CropVCode"] = ((DropDownList)gr.FindControl("ddlCropV")).SelectedValue;
                    dt.Rows[j]["Extent"] = ((TextBox)gr.FindControl("txtExtent")).Text.Trim();
                    dt.Rows[j]["nob"] = ((Label)gr.FindControl("lblnobleft")).Text.Trim();
                    dt.Rows[j]["weight"] = ((Label)gr.FindControl("lblweight")).Text.Trim();
                    dt.Rows[j]["qtyissued"] = ((Label)gr.FindControl("lblqtyissued")).Text.Trim();
                    dt.Rows[j]["Requirement_in_kgs"] = ((Label)gr.FindControl("lblkgsRequirement")).Text.Trim();
                    dt.Rows[j]["Requirement_in_bags"] = ((Label)gr.FindControl("lblnobrequired")).Text.Trim();
                    dt.Rows[j]["Sanctioned"] = ((TextBox)gr.FindControl("txt_bags_sanctioned")).Text.Trim();
                    dt.Rows[j]["StockID"] = ((Label)gr.FindControl("lblStkId")).Text.Trim();
                    //dt.Rows[j]["Request"] = ((TextBox)gr.FindControl("txtRequest")).Text.Trim();
                    //dt.Rows[j]["Sanctioned"] = ((TextBox)gr.FindControl("txtSanction")).Text.Trim();

                    // ((Label)gr.FindControl("lblCrop")).Text = dt.Rows[j]["CropName"].ToString();
                    //((Label)gr.FindControl("lblCorpV")).Text = dt.Rows[j]["CropVCode"].ToString();
                    j++;
                    //if (dt.Rows[j - 1]["CropCode"] == cropcode)
                    //    cf.ShowAlertMessage("Crop already selected");
                }
                else
                {
                    cf.ShowAlertMessage("Please Select Crop");
                    return;
                }
            }
            dt.Rows.Add();
            Session["dtcheckcrops"] = dt;
            GvCropData.DataSource = dt;
            GvCropData.DataBind();
            btn_Save.Visible = true;
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void GvCropData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label CrCode = (e.Row.FindControl("lblCRCode") as Label);
            Label CorpVCode = (e.Row.FindControl("lblCorpV") as Label);
            DataTable ddt = new DataTable();
            //DropDownList ddlcrop = (e.Row.FindControl("ddlCrop") as DropDownList);
            ddt = objao.GetCropsMandalWise(Session["distCode"].ToString(), Session["mandcode"].ToString());
            DropDownList ddlCrop = (DropDownList)e.Row.FindControl("ddlCrop");
            cf.BindDropDownLists(ddlCrop, ddt, "CropName", "crop", "Select ");
            Label Cropname = (e.Row.FindControl("lblCRName") as Label);
            ddlCrop.SelectedValue = CrCode.Text;
            if (ddlCrop.SelectedValue != "")
            {
                ddt = objcrop.viewdCroplistBAL(ddlCrop.SelectedValue);
                DropDownList ddlCropV = (e.Row.FindControl("ddlCropV") as DropDownList);
                cf.BindDropDownLists(ddlCropV, ddt, "CropVName", "CropVCode", " select");
                ddlCropV.SelectedValue = CorpVCode.Text;
            }
        }
    }
    protected void GvCropData_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Remove")
            {
                GridViewRow gvrow = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                DataTable dt = new DataTable();
                dt.Columns.Add("FarmerID", typeof(string));
                dt.Columns.Add("CropName", typeof(string));
                dt.Columns.Add("CropCode", typeof(string));
                dt.Columns.Add("CropVCode", typeof(string));
                dt.Columns.Add("Extent", typeof(string));
                dt.Columns.Add("Requirement", typeof(string));
                dt.Columns.Add("qtyissued", typeof(string));
                dt.Columns.Add("Sanctioned", typeof(string));
                int i = 0;
                foreach (GridViewRow gr in GvCropData.Rows)
                {
                    dt.Rows.Add();
                    //dt.Rows[i]["FarmerID"] = ((Label)gr.FindControl("lblFarmerId")).Text;
                    dt.Rows[i]["CropCode"] = ((DropDownList)gr.FindControl("ddlCrop")).SelectedValue;
                    if (dt.Rows[i]["CropCode"].ToString() == "0")
                        dt.Rows[i]["CropName"] = "";
                    else
                        dt.Rows[i]["CropName"] = ((DropDownList)gr.FindControl("ddlCrop")).SelectedItem.Text;
                    dt.Rows[i]["CropVCode"] = ((DropDownList)gr.FindControl("ddlCropV")).SelectedValue;
                    if (dt.Rows[i]["CropVCode"].ToString() == "0")
                        dt.Rows[i]["Extent"] = ((TextBox)gr.FindControl("txtExtent")).Text.Trim();
                    dt.Rows[i]["Requirement"] = ((Label)gr.FindControl("txtRequirement")).Text;
                    dt.Rows[i]["Request"] = ((TextBox)gr.FindControl("txtRequest")).Text.Trim();
                    dt.Rows[i]["Sanctioned"] = ((TextBox)gr.FindControl("txtSanction")).Text.Trim();
                    i++;
                }
                dt.Rows.RemoveAt(gvrow.RowIndex);
                if (dt.Rows.Count == 0)
                {
                    dt.Rows.Add();
                }
                GvCropData.DataSource = dt;
                GvCropData.DataBind();
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }

    }
   
    protected bool validateForm()
    {
        if (txtownerNm.Text == "")
        {
            cf.ShowAlertMessage("Enter pattadar name");
            return false;
        }
        if (txtOwnerfatherNm.Text == "")
        {
            cf.ShowAlertMessage("Enter pattadar Father name");
            return false;
        }
        if (ddlOwnercaste.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Select Caste");
            return false;
        }

        if (a1Owner.Text == "")
        {
            cf.ShowAlertMessage("Enter Adhar Number of Pattadar");
            return false;
        }
        if (a2Owner.Text == "")
        {
            cf.ShowAlertMessage("Enter Adhar Number of Pattadar");
            return false;
        }
        if (a3Owner.Text == "")
        {
            cf.ShowAlertMessage("Enter Adhar Number of Pattadar");
            return false;
        }

        if (txtOwnerMobile.Text == "")
        {
            cf.ShowAlertMessage("Enter Mobile Number of pattadar");
            return false;
        }
        if (txtsurveynos.Text == "")
        {
            cf.ShowAlertMessage("Enter Survey Numbers of pattadar");
            return false;
        }
        if (lblPextent.Text == "")
        {
            cf.ShowAlertMessage("Enter Total Extent of pattadar");
            return false;
        }
        if (rblsame.SelectedValue == "")
        {
            cf.ShowAlertMessage("Select person who came for seed is the owner/ocupant/ other");
            return false;
        }
        else if (rblsame.SelectedValue == "other")
        {
            if (txtPnm.Text == "")
            {
                cf.ShowAlertMessage("Enter Name of the Person who came for Seed");
                return false;
            }
            if (a1P.Text == "")
            {
                cf.ShowAlertMessage("Enter Adhar Number of the person who came for Seed");
                return false;
            }
            if (a2p.Text == "")
            {
                cf.ShowAlertMessage("Enter Adhar Number of the person who came for Seed");
                return false;
            }
            if (a3p.Text == "")
            {
                cf.ShowAlertMessage("Enter Adhar Number of the person who came for Seed");
                return false;
            }
            if (ddlrelation.SelectedValue == "0")
            {
                cf.ShowAlertMessage("Select Relation of person with owner/ocupant");
                return false;
            }
            if (txtMobile.Text == "")
            {
                cf.ShowAlertMessage("Enter Mobile Number of the person who came for Seed");
                return false;
            }
        }
        /* if (txtacno.Text == "")
         {
             cf.ShowAlertMessage("Enter Account Number");
             return false;
         }
         if (ddlbank.SelectedIndex==0)
         {
             cf.ShowAlertMessage("Select Bank");
             return false;
         }
         if (txtbranch.Text == "")
         {
             cf.ShowAlertMessage("Enter Branch Name");
             return false;
         }
         if (txtifsc.Text == "")
         {
             cf.ShowAlertMessage("Enter IFSC Code");
             return false;
         }*/

        foreach (GridViewRow gr in GvCropData.Rows)
        {
            if (((DropDownList)gr.FindControl("ddlCrop")).SelectedIndex == 0)
            {
                cf.ShowAlertMessage("Select crop");
                return false;
            }
            if (((DropDownList)gr.FindControl("ddlCropV")).SelectedIndex == 0)
            {
                cf.ShowAlertMessage("Select Crop Variety");
                return false;
            }
            if (((TextBox)gr.FindControl("txtExtent")).Text == "")
            {
                cf.ShowAlertMessage("Enter Extent");
                return false;
            }
            //if (((TextBox)gr.FindControl("txt_bags_requested")).Text == "")
            //{
            //    cf.ShowAlertMessage("Enter Number of Bags Requested");
            //    return false;
            //}
            if (((TextBox)gr.FindControl("txt_bags_sanctioned")).Text == "")
            {
                cf.ShowAlertMessage("Enter Number of Bags Sanctioned");
                return false;
            }

            bool chk = false;
            //foreach (GridViewRow gvr in GvPopUpFarmerdata.Rows)
            //{
            //    if (((CheckBox)gvr.FindControl("chkSurvey")).Checked == true)
            //    {
            //        chk = true;
            //        string s = ((Label)gvr.FindControl("lblSurveyNumber")).Text.Trim();
            //        surveynos += "," + s;
            //    }
            //}
            //if (chk == false)
            //{
            //    cf.ShowAlertMessage("Select atleast one survey number");
            //    return false;
            //}

        }
        return true;
    }
    protected bool checkExtent(string fid,string KhataNo)
    {
        //DataTable t = new DataTable();
        //t = ObjBL.getSurveyNo(fid);
        //string[] sno = t.Rows[0][0].ToString().Split(',');
        //foreach (GridViewRow gr in GvPopUpFarmerdata.Rows)
        //{
        //    if (((CheckBox)gr.FindControl("lblSurveyNumber")).Checked == true)
        //    {
        //        string ext = ((Label)gr.FindControl("lblExtent")).Text;
        //        if (sno.Contains(ext))
        //            cf.ShowAlertMessage("Permit for selected Survey Number already issued");
        //    }
        //}

        DataTable dt = new DataTable();
        dt = ObjBL.CheckEligibilty(fid,KhataNo);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][0].ToString().Trim() == "1")
            {
                cf.ShowAlertMessage("Permit is issued to his total extent");
                return false;
            }
            //if (dt.Rows[0][0].ToString().Trim() == "2")
            //{
            //    cf.ShowAlertMessage("Limit is completed");
            //    return false;
            //}
            if (dt.Rows[0][0].ToString().Trim() == "3")
            {
                lblRemExtent.Text = lblPextent.Text;
                return true;
            }
            else
            {
                lblRemExtent.Text = dt.Rows[0][0].ToString();
                return true;
            }
        }
        return false;
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            string farmerid = "";
            if (validateForm())
            {
                DataTable t = new DataTable();
                ObjBE.AadharNo = a1Owner.Text + a2Owner.Text + a3Owner.Text;
                ObjBE.acno = "";
                ObjBE.bank = "";
                ObjBE.branch = "";
                ObjBE.Caste = ddlOwnercaste.SelectedValue;
                ObjBE.DistCode = dist_code_LG.Text;
                ObjBE.extent = lblPextent.Text.Trim();
                ObjBE.Farmer_Name = txtownerNm.Text;
                ObjBE.Father_Name = txtOwnerfatherNm.Text;
                ObjBE.FinYear = SanYear.SelectedValue;
                ObjBE.SeasonName = SanSeason.SelectedValue;
                ObjBE.surveynos = txtsurveynos.Text.Trim();
                ObjBE.VillCode = ddl_vill.SelectedValue;
                ObjBE.Gender = rblOwnergender.SelectedValue;
                ObjBE.ifsc = "";
                ObjBE.KhataNo = txtKahataNo.Text.Trim();
                ObjBE.MandCode = ddl_mandal.SelectedValue;
                ObjBE.mobile = txtOwnerMobile.Text.Trim();

                t = ObjBL.InsertFarmerDetailsBAL(ObjBE);
                if (t.Rows.Count > 0)
                    farmerid = t.Rows[0][0].ToString();
                //t = ObjBL.InsertDetails(lblfid.Text, a1Owner.Text + a2Owner.Text + a3Owner.Text, a1P.Text + a2p.Text + a3p.Text, rblOwnergender.SelectedValue,
                //    ddlOwnercaste.SelectedValue, surveynos, txtPnm.Text.Trim(), ddlrelation.SelectedValue, txtMobile.Text.Trim(), txtOwnerMobile.Text.Trim(), rblsame.SelectedValue,
                //   txtacno.Text.Trim(), ddlbank.SelectedValue, txtbranch.Text.Trim(), txtifsc.Text.Trim());


                if (checkExtent(farmerid, txtKahataNo.Text.Trim()))
                {
                    double tExt = 0;
                    DataTable DtSeedIssued = new DataTable();

                    DtSeedIssued.Columns.Add("CropCode", typeof(string));
                    DtSeedIssued.Columns.Add("CropVCode", typeof(string));
                    DtSeedIssued.Columns.Add("Extent", typeof(string));
                    DtSeedIssued.Columns.Add("Requirement", typeof(double));
                    DtSeedIssued.Columns.Add("Request", typeof(string));
                    // DtSeedIssued.Columns.Add("nob", typeof(string));
                    // DtSeedIssued.Columns.Add("weight", typeof(string));
                    DtSeedIssued.Columns.Add("Sanctioned", typeof(string));
                    DtSeedIssued.Columns.Add("qtyissued", typeof(string));
                    DtSeedIssued.Columns.Add("stock_id", typeof(string));
                    int j = 0;
                    foreach (GridViewRow gr in GvCropData.Rows)
                    {
                        DtSeedIssued.Rows.Add();
                        DtSeedIssued.Rows[j]["CropCode"] = ((DropDownList)gr.FindControl("ddlCrop")).SelectedValue;
                        DtSeedIssued.Rows[j]["CropVCode"] = ((DropDownList)gr.FindControl("ddlCropV")).SelectedValue;
                        tExt += Convert.ToDouble(((TextBox)gr.FindControl("txtExtent")).Text.Trim());
                        DtSeedIssued.Rows[j]["Extent"] = ((TextBox)gr.FindControl("txtExtent")).Text.Trim();
                        DtSeedIssued.Rows[j]["Requirement"] = Convert.ToDouble(((Label)gr.FindControl("lblkgsRequirement")).Text.Trim());
                        // DtSeedIssued.Rows[j]["Request"] = ((TextBox)gr.FindControl("txt_bags_requested")).Text.Trim();
                        DtSeedIssued.Rows[j]["Sanctioned"] = ((TextBox)gr.FindControl("txt_bags_sanctioned")).Text.Trim();
                        DtSeedIssued.Rows[j]["qtyissued"] = ((Label)gr.FindControl("lblqtyissued")).Text.Trim();
                        DtSeedIssued.Rows[j]["stock_id"] = ((Label)gr.FindControl("lblStkId")).Text.Trim();
                        j++;
                    }

                    // ViewState["FarmerId"] = lblfid.Text;
                    if (tExt <= Convert.ToDouble(lblPextent.Text))
                    {
                        if (tExt <= Convert.ToDouble(lblRemExtent.Text))
                        {
                            string msg = "";
                            //string permitcode = getPermitCode(a1Owner.Text, a2Owner.Text, a3Owner.Text);
                            DataTable dt = new DataTable();
                            dt = seedObj.InsertSeedIssual(DtSeedIssued, farmerid, SanYear.SelectedItem.Text, SanSeason.SelectedValue, ddlsp.SelectedValue, Session["UsrName"].ToString());
                            if (dt.Rows.Count > 0)
                            {
                                //if (dt.Rows[0][0].ToString().Trim() == "1")
                                //    cf.ShowAlertMessage("Permit Slip is already issued for this farmer for select year and season");
                                //if (dt.Rows[0][0].ToString().Trim() == "2")
                                //    cf.ShowAlertMessage("Stock for this crop is finished");
                                // else
                                // {
                                msg = "Permit generated for " + dt.Rows[0][0].ToString() + "  crop ";
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Seed Request Raised Successfully')", true);
                                foreach (DataRow r in dt.Rows)
                                {
                                    msg += r[1].ToString() + " : " + r[2].ToString() + " bags ";
                                }
                                msg += "with permit number: " + dt.Rows[0][3].ToString();

                                if (rblsame.SelectedValue == "other")
                                    smsobj.BroadcastSMS(txtMobile.Text.Trim(), "T", msg);

                                else
                                    smsobj.BroadcastSMS(txtOwnerMobile.Text.Trim(), "T", msg);
                                /*Redirect to Permit issual page*/
                                Session["FarmerId"] = dt.Rows[0][4].ToString();
                                Session["FinYear"] = SanYear.SelectedItem.Text;
                                Session["SeasonName"] = SanSeason.SelectedValue;
                                Session["PermitCode"] = dt.Rows[0][3].ToString();
                                Response.Redirect("~/MAO/PermitSlip.aspx", false);

                            }
                        }
                        else
                        {
                            cf.ShowAlertMessage("Extent can't exceed remaining extents");
                        }

                    }
                    else
                    {
                        cf.ShowAlertMessage("Requested Extent should not be more than total extent ");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }

    protected void ddlCrop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlsp.SelectedIndex == 0)
        {
            cf.ShowAlertMessage("Select Sale Point");
            DropDownList Dropdown = sender as DropDownList;
            GridViewRow gRow = (GridViewRow)Dropdown.NamingContainer;
            DropDownList crop = ((DropDownList)(gRow.FindControl("ddlCrop")));
            crop.SelectedIndex = 0;
            //btn_Save.Visible = false;
        }
        else
        {
          
            DropDownList Dropdown = sender as DropDownList;
            GridViewRow gRow = (GridViewRow)Dropdown.NamingContainer;
            string crop = ((DropDownList)(gRow.FindControl("ddlCrop"))).SelectedValue;
          
            DataTable dtcheck = (DataTable)Session["dtcheckcrops"];
            if (dtcheck != null)
            {
                if (dtcheck.Rows.Count > 0)
                {
                    DataRow[] foundRows;

                    string where = "";
                    where = "CropCode='" + crop + "' ";
                    foundRows = dtcheck.Select(where);
                    if (foundRows.Length > 0)
                    {
                        cf.ShowAlertMessage("Crop already selected");
                        return;
                    }

                }
            }
            DataTable ddt = new DataTable();
            DropDownList ddlCropV = (gRow.FindControl("ddlCropV") as DropDownList);
            ddlCropV.Items.Clear();
            ddt = objcrop.viewdCroplistBAL(crop);
            cf.BindDropDownLists(ddlCropV, ddt, "CropVName", "CropVCode", "Please select");
            btn_Save.Visible = true;
        }
    }
    protected void txtExtent_OnTextChanged(object sender, EventArgs e)
    {
        if (lblPextent.Text == "")
        {
            cf.ShowAlertMessage("Enter Total Land Extent");
            TextBox txtExtent = (TextBox)sender;
            txtExtent.Text = "";
        }
        else
        {
            btn_Save.Visible = true;
            try
            {
                TextBox txtExtent = (TextBox)sender;
                GridViewRow gvRow = (GridViewRow)txtExtent.Parent.Parent;
                string cropcode = ((DropDownList)gvRow.FindControl("ddlCrop")).SelectedValue;
                
                string cropVcode = ((DropDownList)gvRow.FindControl("ddlCropV")).SelectedValue;
                DataTable dt = new DataTable();
                dt = ObjBL.getCropExtentBAL(cropcode, txtExtent.Text);
                Label Requirement = ((Label)gvRow.FindControl("lblkgsRequirement"));
                Requirement.Text = dt.Rows[0]["requirement"].ToString();
                string weight = ((Label)gvRow.FindControl("lblweight")).Text;

                decimal x = Math.Round(Convert.ToDecimal(Requirement.Text) / Convert.ToInt16(weight));
                if (x == 0)
                    ((Label)gvRow.FindControl("lblnobrequired")).Text = "1";
                else
                    ((Label)gvRow.FindControl("lblnobrequired")).Text = x.ToString();

                if (!CheckExtent(txtExtent.Text, lblPextent.Text))
                {
                    txtExtent.Text = "";
                    Requirement.Text = "";
                    txtExtent.Focus();
                }
                btn_Save.Visible = true;
            }
            catch (Exception ex)
            {
                ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
                Response.Redirect("~/Error.aspx");
            }
        }
    }
    protected void txtSanction_OnTextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtSanction = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txtSanction.Parent.Parent;
            string requested = ((Label)gvRow.FindControl("lblnobrequired")).Text;
            string left = ((Label)gvRow.FindControl("lblnobleft")).Text;
            if (Convert.ToInt16(txtSanction.Text) > Convert.ToInt16(requested))
            {
                cf.ShowAlertMessage("Sanctioned should not be more than the Seed Rate");
                btn_Save.Visible = false;
                txtSanction.Text = "";
                txtSanction.Focus();
                ViewState["bagsIssued"] = Convert.ToInt32(ViewState["bagsIssued"]) +Convert.ToInt32( txtSanction.Text);
            }
            if (Convert.ToInt16(txtSanction.Text) > Convert.ToInt16(left))
            {
                cf.ShowAlertMessage("More than the stock available can not be issued");
                btn_Save.Visible = false;
                txtSanction.Text = "";
                txtSanction.Focus();
            }
            else
            {
                string wght = ((Label)gvRow.FindControl("lblweight")).Text;
                ((Label)gvRow.FindControl("lblqtyissued")).Text = (Convert.ToInt16(txtSanction.Text) * Convert.ToInt16(wght)).ToString();
                btn_Save.Visible = true;
            }
        }
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected bool CheckExtent(string txtReqst, string totalextent)
    {
        if (txtReqst != "")
        {
            decimal txtReqst1 = Convert.ToDecimal(txtReqst);
            //if (txtReqst1 > 5)
            //{
            //    cf.ShowAlertMessage("Individual crop Limit is 5 acres");
            //    return false;
            //}
            if (txtReqst1 > Convert.ToDecimal(totalextent))
            {
                cf.ShowAlertMessage("Extent must be less than total Extent");
                return false;
            }

        }
        else
        {
            cf.ShowAlertMessage("Enter Extent");
            return false;
            //txtqty.Text = "0";
            //GridViewRow gvRow = (GridViewRow)txtqty.Parent.Parent;
            //Label Amount = (Label)gvRow.FindControl("lblAmount");
            //Amount.Text = "0.00";

        }
        return true;

    }
    protected void GetStockAvailable(object sender, EventArgs e)
    {

        DropDownList Dropdown = sender as DropDownList;
        GridViewRow gRow = (GridViewRow)Dropdown.NamingContainer;
        string crop = ((DropDownList)(gRow.FindControl("ddlCrop"))).SelectedValue;
        string cv = ((DropDownList)(gRow.FindControl("ddlCropV"))).SelectedValue;
        Label nob = ((Label)(gRow.FindControl("lblnobleft")));
        Label weight = ((Label)(gRow.FindControl("lblweight")));
        Label stkid = ((Label)(gRow.FindControl("lblStkId")));
       
        DataTable dt = new DataTable();

        dt = seedObj.GetSPStockLeftAtSP(SanYear.SelectedValue, SanSeason.SelectedValue, crop, Convert.ToInt16(cv), ddlsp.SelectedValue);
        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0][0].ToString() != "" && dt.Rows[0][1].ToString() != "")
            {
                if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                {
                    // lblqtyAvail.Text = dt.Rows[0][0].ToString();

                    nob.Text = dt.Rows[0][0].ToString();
                    weight.Text = dt.Rows[0][1].ToString();
                    stkid.Text = dt.Rows[0][2].ToString();
                }
                else
                {
                    cf.ShowAlertMessage("Do not have enough stock, Add some more stock");
                    ((DropDownList)(gRow.FindControl("ddlCrop"))).SelectedIndex = 0;
                    ((DropDownList)(gRow.FindControl("ddlCropV"))).Items.Clear();
                }
            }
            else
            {
                cf.ShowAlertMessage("Stock Not Yet Received or Stock is over");
                ((DropDownList)(gRow.FindControl("ddlCrop"))).SelectedIndex = 0;
                ((DropDownList)(gRow.FindControl("ddlCropV"))).Items.Clear();
            }
            
        }
        else
        {
            cf.ShowAlertMessage("Stock Not Yet Received or Stock is over");
            ((DropDownList)(gRow.FindControl("ddlCrop"))).SelectedIndex = 0;
            ((DropDownList)(gRow.FindControl("ddlCropV"))).Items.Clear();
        }

    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rblsame.SelectedValue == "pattadar" || rblsame.SelectedValue == "ocupant")
        {
            otherTbl.Visible = false;
            leg.Text = "";
        }
        else
        {
            otherTbl.Visible = true;
            leg.Text = "Details of Person Who came for Seed";
        }
    }

    protected string getPermitCode(string a1, string a2, string a3)
    {
        string code = cf.GenerateUniqueText(5);
        char[] adhar1 = a1.ToCharArray();
        char[] adhar2 = a2.ToCharArray();
        char[] adhar3 = a3.ToCharArray();
        System.Text.StringBuilder sb = new System.Text.StringBuilder(code);
        return sb.Append((adhar1[0] + adhar1[1] + adhar2[1] + adhar2[2] + adhar3[2] + adhar3[3])).ToString();
        //return (adhar1[0] + adhar1[1] + adhar2[1] + adhar2[2] + adhar3[2] + adhar3[3]).ToString() + code;
    }

    protected void a3Owner_TextChanged(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = ObjBL.CheckAdhar(a1Owner.Text + a2Owner.Text + a3Owner.Text);
        if (dt.Rows.Count > 0)
        {
            cf.ShowAlertMessage("This adhar already exists");
            a1Owner.Text = "";
            a2Owner.Text = "";
            a3Owner.Text = "";
        }
    }
    protected void ddlsp_SelectedIndexChanged(object sender, EventArgs e)
    {
        CreateNewRow();
    }
}