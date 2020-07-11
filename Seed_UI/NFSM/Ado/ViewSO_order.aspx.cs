using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using Seed_BL;
using Seed_BE;
using Seed_DL;
public partial class NFSM_MAO_MAOHome : System.Web.UI.Page
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
        lblUsrName.Text = Session["Role"].ToString();
        lblDist.Text = Session["district"].ToString();
        
        if (!IsPostBack)
        {
            getSupplyOrderGeneration();
        }
    }
    protected void btnback_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/nfsm/ADO/ADO_UC_Generation.aspx");
    }
    protected void getSupplyOrderGeneration()
    {
        try
        {
            nfsmobj = new NFSM_Members();
           nfsmobj.farmerid= Session["farmerid"].ToString() ;
           nfsmobj.distcd= Session["distcd"].ToString();
           nfsmobj.schemecode= Session["schemecd"].ToString() ;
           nfsmobj.cropcd = Session["cropcd"].ToString();
           nfsmobj.intervensioncd = Session["intervencd"].ToString();
           nfsmobj.itemcd = Session["itemcd"].ToString();
           nfsmobj.yearcd = Session["yearcd"].ToString();
           nfsmobj.agencycd = Session["agencycd"].ToString();
           nfsmobj.uid = Session["uc_uid"].ToString();
           nfsmobj.Flag = "DAOV";
            DataTable dt = new DataTable();
            dt = obj.Generateutilization_certi_supply(nfsmobj, Session["constr"].ToString());
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/nfsm/Reports/Rpt_Supply.rdlc");
            lgdistrict dsdistrict = new lgdistrict();
            dsdistrict.Tables.Add(dt);
            ReportDataSource datasource = new ReportDataSource("DataSet1", dsdistrict.Tables[1]);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);
        }
        catch { }
    }
}