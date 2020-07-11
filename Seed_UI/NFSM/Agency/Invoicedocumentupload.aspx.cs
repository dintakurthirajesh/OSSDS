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
using System.IO;
public partial class NFSM_MAO_SchemeFilingSearch : System.Web.UI.Page
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
        if (Session["Rolecode"].ToString() == null)
        {
            Response.Redirect("~/nfsm/Error.aspx");
        }

        lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;

      
        if (!IsPostBack)
        {
          //  BindYear();
           // BindScheme();
            lblUsrName.Text = Session["Role"].ToString();
            lblDist.Text = Session["district"].ToString();
            BindGrid();
        }
    }

    protected void btnUpload_OnClick(object sender, EventArgs e)
    {



        TextBox txtEmpID = (TextBox)gvUpload.FooterRow.FindControl("txtEmpID");
        TextBox txtName = (TextBox)gvUpload.FooterRow.FindControl("txtName");
        FileUpload fuploadFile = (FileUpload)gvUpload.FooterRow.FindControl("fUpload");
        Button btnUpload = (Button)gvUpload.FooterRow.FindControl("btnUpload");
        DropDownList ddldocs = (DropDownList)gvUpload.FooterRow.FindControl("ddldocumentselect");
        if (fuploadFile.HasFile)
        {
            string fileName = fuploadFile.FileName;
           string exten = Path.GetExtension(fileName);
            Stream imgStream = fuploadFile.PostedFile.InputStream;
            int imgLength = fuploadFile.PostedFile.ContentLength;

            decimal size = Math.Round(((decimal)fuploadFile.PostedFile.ContentLength / (decimal)2048), 2);
            //if (size > 200)
            //{
            //    objCommon.ShowAlertMessage(" File size must not exceed in " + ddldocs.SelectedItem.Text + " ,doc or image must 200 KB.");
            //    return;
            //}

            byte[] imgBinaryData = new byte[imgLength];
            int n = imgStream.Read(imgBinaryData, 0, imgLength);

            exten = exten.ToLower();

            string[] acceptedFileTypes = new string[6];

            acceptedFileTypes[0] = ".jpg";
            acceptedFileTypes[1] = ".jpeg";
            acceptedFileTypes[2] = ".pdf";
            acceptedFileTypes[3] = ".png";
          

            bool acceptFile = false;

            for (int i = 0; i <= 3; i++)
            {
                if (exten == acceptedFileTypes[i])
                {

                    acceptFile = true;
                }
            }

            if (!acceptFile)
            {

            }
            else
            {

                string image_type = "";
                try
                {
                    image_type = exten.Substring(1, exten.Length - 1);
                }
                catch { }
                
                

                string strdetails = "";
                if (txtName.Text != "")
                {
                    strdetails = txtName.Text;
                }
                else
                {
                    strdetails = "";
                }
                nfsmobj.farmerid = Session["farmerid"].ToString();
                nfsmobj.distcd = Session["distcd"].ToString();
                nfsmobj.schemecode = Session["schemecd"].ToString();
                nfsmobj.subschemecode = Session["subschemecd"].ToString();
                nfsmobj.yearcd = Session["yearcd"].ToString();
                nfsmobj.intervensioncd = Session["intervencd"].ToString();
                nfsmobj.cropcd = Session["cropcd"].ToString();
                nfsmobj.itemcd = Session["itemcd"].ToString();
                nfsmobj.subitemcode = Session["subitemcd"].ToString();
                nfsmobj.agencycd = Session["agencycd"].ToString();              
                nfsmobj.upImage = imgBinaryData;
                nfsmobj.doc_type = image_type.ToString();
                nfsmobj.invoice_other = strdetails;
                nfsmobj.doc_code = ddldocs.SelectedValue;
                nfsmobj.Flag = "I";
                DataTable dt = new DataTable();
                dt = obj.InsertschemeDocuments(nfsmobj, Session["constr"].ToString());
              if (dt.Rows.Count > 0)
              {
                  objCommon.ShowAlertMessage(dt.Rows[0][0].ToString());
                  BindGrid();

              }
            
            }
        }

    }
    private void BindGrid()
    {
        nfsmobj = new NFSM_Members();
        DataTable FromTable = new DataTable();
        nfsmobj.farmerid = Session["farmerid"].ToString();
        nfsmobj.distcd = Session["distcd"].ToString();
        nfsmobj.schemecode = Session["schemecd"].ToString();
        nfsmobj.subschemecode = Session["subschemecd"].ToString();
        nfsmobj.yearcd = Session["yearcd"].ToString();
        nfsmobj.intervensioncd = Session["intervencd"].ToString();
        nfsmobj.cropcd = Session["cropcd"].ToString();
        nfsmobj.itemcd = Session["itemcd"].ToString();
        nfsmobj.agencycd = Session["agencycd"].ToString();
        nfsmobj.subitemcode = Session["subitemcd"].ToString();
        nfsmobj.Flag = "R";
        FromTable = obj.InsertschemeDocuments(nfsmobj, Session["constr"].ToString());
    
        if (FromTable.Rows.Count > 0)
        {
            gvUpload.DataSource = FromTable;
            gvUpload.DataBind();
        }
        else
        {
            FromTable.Rows.Add(FromTable.NewRow());
            gvUpload.DataSource = FromTable;
            gvUpload.DataBind();
            int TotalColumns = gvUpload.Rows[0].Cells.Count;
            gvUpload.Rows[0].Cells.Clear();
            gvUpload.Rows[0].Cells.Add(new TableCell());
            gvUpload.Rows[0].Cells[0].ColumnSpan = TotalColumns;
            gvUpload.Rows[0].Cells[0].Text = "No records Found";
        }
    }
    protected void gvUpload_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddldoc = (DropDownList)e.Row.FindControl("ddldocument");

            Label lbldoc = (Label)e.Row.FindControl("lbldocs");
            if (lbldoc.Text != "" && lbldoc.Text != null)
            {
                ddldoc.SelectedValue = lbldoc.Text.Trim();
            }
        }
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {

    }
    protected void btnback_OnClick(object sender, EventArgs e)
    {
        Response.Redirect("~/nfsm/agency/Agency_Schemes.aspx");
    }
}