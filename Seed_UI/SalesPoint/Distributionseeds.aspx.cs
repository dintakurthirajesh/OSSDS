using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Seed_BE;
using Seed_BL;


public partial class SalesPoint_Distributionseeds : System.Web.UI.Page
{
    CommonFuncs cmnfn = new CommonFuncs();
    DataTable dt = new DataTable();
    DistributedseedBL objbl = new DistributedseedBL();
    SmsText smsobj = new SmsText();
    double total = 0.0;
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
        //clear Caching 
        PrevBrowCache.enforceNoCache();

        if (Session["UsrName"] == null || Session["Role"].ToString().ToLower() != "sale point")
        {
            Response.Redirect("~/Error.aspx");
        }

        if (!IsPostBack)
        {
            lblUsrName.Text = Session["UsrName"].ToString();
            lblDist.Text = Session["district"].ToString();
            lblMand.Text = Session["mandal"].ToString();
            lblDate.Text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;   
        }
    }
    protected void txtPurchQty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            TextBox txtpermit = (TextBox)sender;
            double permit = Convert.ToDouble(txtpermit.Text);
            GridViewRow gvRow = (GridViewRow)txtpermit.Parent.Parent;
            Label lblRs = (Label)gvRow.FindControl("lblsanctioned");
            Label weight = (Label)gvRow.FindControl("lblweight");
            Label stockavailble = (Label)gvRow.FindControl("lbl_stock_available");
            int we = Convert.ToInt16(weight.Text);
            double sanctioned = Convert.ToDouble(lblRs.Text);
            if (permit > sanctioned)
            {
                cmnfn.ShowAlertMessage("You entered more than sanctioned");
                txtpermit.Text = "";
            }
            else if (permit > Convert.ToDouble(stockavailble.Text))
            {
                cmnfn.ShowAlertMessage("More than the Stock available can not be purchased ");
                txtpermit.Text = "";
            }
            else
            {
                DropDownList ddlprice = (DropDownList)gvRow.FindControl("ddlprice");
                Label lblamount = (Label)gvRow.FindControl("lblamount");
                Label totalamt = (Label)gvRow.FindControl("lbltot");
                TextBox txtPurchQty = (TextBox)gvRow.FindControl("txtPurchQty");
                if (ddlprice.SelectedValue == "")
                {
                    cmnfn.ShowAlertMessage("Actual MRP & Subsidy not yet entered");
                }
                else
                {
                    double qty = Convert.ToDouble(txtPurchQty.Text);
                    double price = Convert.ToDouble(ddlprice.SelectedValue);
                    ((Label)gvRow.FindControl("lblqtypurchased")).Text = (qty * we).ToString();
                    lblamount.Text = (qty * price * we).ToString();
                    
                }
                try
                {
                    double amount = 0;
                    foreach (GridViewRow gr in grdPermit.Rows)
                    {
                        if (((Label)gr.FindControl("lblamount")).Text.Trim() != "")
                        {
                            amount += Convert.ToDouble(lblamount.Text);
                        }

                    }
                    lbltot.Text = amount.ToString();
                }
                catch { }
            }
        }
        catch (Exception ex)
        {
          //  ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
          //  Response.Redirect("~/Error.aspx");
        }
    }
    protected void getTotal(string amt)
    {
        if (lbltot.Text == "")
            lbltot.Text = amt;
        else
            lbltot.Text = (Convert.ToDouble(lbltot.Text) + Convert.ToDouble(amt)).ToString();
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        lbltot.Text = "";
        try
        {
            DataTable t = new DataTable();
            t = objbl.GetPrice(txtpermit.Text.Trim());
            if (t.Rows.Count > 0)
            {
                dt = objbl.GetPermitData(txtpermit.Text, Session["SpCode"].ToString());
                if (dt.Rows.Count > 0 && dt != null)
                {
                    if (dt.Rows[0][0].ToString() == "1")
                    {
                        cmnfn.ShowAlertMessage("This permit not allotted to this Sale point");
                        txtpermit.Text = "";
                        grdPermit.DataBind();
                        fid.Text = "";
                        farmeNm.Text = "";
                        fatherNm.Text = "";
                        lblyear.Text = "";
                        lblseason.Text = "";
                        spcode.Text = "";
                    }
                    else if (dt.Rows[0][0].ToString() == "2")
                    {
                        cmnfn.ShowAlertMessage("Seed Already purchased by this farmer");
                        txtpermit.Text = "";
                        grdPermit.DataBind();
                        fid.Text = "";
                        farmeNm.Text = "";
                        fatherNm.Text = "";
                        lblyear.Text = "";
                        lblseason.Text = "";
                        spcode.Text = "";
                    }
                    else if (dt.Rows[0][0].ToString() == "3")
                    {
                        cmnfn.ShowAlertMessage("This Permit Number is invalid");
                        txtpermit.Text = "";
                        grdPermit.DataBind();
                        fid.Text = "";
                        farmeNm.Text = "";
                        fatherNm.Text = "";
                        lblyear.Text = "";
                        lblseason.Text = "";
                        spcode.Text = "";
                    }
                    else if (dt.Rows[0][0].ToString() == "4")
                    {
                        cmnfn.ShowAlertMessage("Permit number is out dated");
                        txtpermit.Text = "";
                        grdPermit.DataBind();
                        fid.Text = "";
                        farmeNm.Text = "";
                        fatherNm.Text = "";
                        lblyear.Text = "";
                        lblseason.Text = "";
                        spcode.Text = "";
                    }
                    else
                    {
                        fid.Text = dt.Rows[0]["FarmerId"].ToString();
                        farmeNm.Text = dt.Rows[0]["Farmer_Name"].ToString();
                        fatherNm.Text = dt.Rows[0]["Father_Name"].ToString();
                        lblyear.Text = dt.Rows[0]["FinYear"].ToString();
                        lblseason.Text = dt.Rows[0]["SeasonName"].ToString();
                        spcode.Text = dt.Rows[0]["SalePointCode"].ToString();
                        lblmobile.Text = dt.Rows[0]["mobile"].ToString();
                        grdPermit.DataSource = dt;
                        grdPermit.DataBind();
                    }
                }
                else
                {
                    cmnfn.ShowAlertMessage(dt.Rows[0][0].ToString());
                    txtpermit.Text = "";
                    grdPermit.DataBind();
                    fid.Text = "";
                    farmeNm.Text = "";
                    fatherNm.Text = "";
                    lblyear.Text = "";
                    lblseason.Text = "";
                    spcode.Text = "";
                }
                //else if (dt.Rows[0]["SalePointCode"].ToString() != Session["SpCode"].ToString())
                //{
                //    cmnfn.ShowAlertMessage("Permit number is not allotted to this salepoint");
                //    txtpermit.Text = "";
                //    grdPermit.DataBind();
                //    fid.Text = "";
                //    farmeNm.Text = "";
                //    fatherNm.Text = "";
                //    lblyear.Text = "";
                //    lblseason.Text = "";
                //    spcode.Text = "";
                //}

            }
            else
            {
                cmnfn.ShowAlertMessage("Price Not Yet Entered for Selected Crop");
            }
        }
            
        catch (Exception ex)
        {
            ExceptionLogging.SendExcepToDB(ex, Session["UsrName"].ToString(), Request.ServerVariables["REMOTE_ADDR"].ToString());
            Response.Redirect("~/Error.aspx");
        }
    }
    protected void Save_Click(object sender, EventArgs e)
    {
        DataTable DtSeedPurchased = new DataTable();
        
        DtSeedPurchased.Columns.Add("stock_id", typeof(Int32));
        DtSeedPurchased.Columns.Add("bags_sanctioned", typeof(string));
        DtSeedPurchased.Columns.Add("qty_purchased", typeof(string));
        DtSeedPurchased.Columns.Add("bags_purchased", typeof(string));
        DtSeedPurchased.Columns.Add("weight", typeof(string));
        DtSeedPurchased.Columns.Add("Amount_paid", typeof(string));
        int j = 0;
        foreach (GridViewRow gr in grdPermit.Rows)
        {
            if (((TextBox)gr.FindControl("txtPurchQty")).Text.Trim() != "")
            {
                DtSeedPurchased.Rows.Add();
                DtSeedPurchased.Rows[j]["stock_id"] = Convert.ToInt32(((Label)gr.FindControl("stock_id")).Text.Trim());
                DtSeedPurchased.Rows[j]["bags_sanctioned"] = ((Label)gr.FindControl("lblsanctioned")).Text.Trim();
                DtSeedPurchased.Rows[j]["qty_purchased"] = ((Label)gr.FindControl("lblqtypurchased")).Text.Trim();
                DtSeedPurchased.Rows[j]["bags_purchased"] = ((TextBox)gr.FindControl("txtPurchQty")).Text.Trim();
                DtSeedPurchased.Rows[j]["weight"] = ((Label)gr.FindControl("lblweight")).Text.Trim();
                DtSeedPurchased.Rows[j]["Amount_paid"] = ((Label)gr.FindControl("lblamount")).Text.Trim();
                j++;
            }
        }

        dt = objbl.InsertSeedDistribution(DtSeedPurchased, lblyear.Text, lblseason.Text, fid.Text, spcode.Text,txtpermit.Text.Trim());
        if (dt.Rows.Count > 0)
        {
            string seed=" Crop ";
            if (dt.Rows[0][0].ToString() == "Inserted")
            {
                cmnfn.ShowAlertMessage("Saved");
                Session["permit"] = txtpermit.Text;
                foreach (GridViewRow gvrow in grdPermit.Rows)
                {
                    TextBox t = (TextBox)gvrow.FindControl("txtPurchQty");
                    Label l = (Label)gvrow.FindControl("lblamount");
                    seed += gvrow.Cells[1].Text.Trim()+"/" + gvrow.Cells[2].Text.Trim()+" Bags:"+  t.Text+ " . Amount Paid: "+l.Text;
                }
                string msg = farmeNm.Text + " S/o " + fatherNm.Text + " :Seed Purchased "+seed;
                smsobj.BroadcastSMS(lblmobile.Text.Trim(), "T", msg);
                Response.Redirect("PurchaseReceipt.aspx");
            }
            else
            {
                cmnfn.ShowAlertMessage(dt.Rows[0][0].ToString());
                txtpermit.Text = "";
                fid.Text = "";
                farmeNm.Text = "";
                fatherNm.Text = "";
                lblyear.Text = "";
                lblseason.Text = "";
                lbltot.Text = "";
                grdPermit.DataSource = null;
                grdPermit.DataBind();
            }
            
        }
    }
    protected void grdPermit_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddlprice = (DropDownList)e.Row.FindControl("ddlprice");
            Label crop = (Label)e.Row.FindControl("crop_code");
            Label cv = (Label)e.Row.FindControl("crop_vcode");

            DataTable dtcropcost = new DataTable();
            dtcropcost = objbl.GetPriceLabels(lblyear.Text, lblseason.Text, crop.Text, cv.Text);
            cmnfn.BindDropDownLists(ddlprice, dtcropcost, "price", "id", "select");  

            Label lblamount = (Label)e.Row.FindControl("lblamount");
            if(lblamount.Text != "")
               total = total + Convert.ToDouble(lblamount.Text);
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
           // Label TotalAmt = (Label)e.Row.FindControl("lbltot");
          //  TotalAmt.Text = total.ToString();
        }
    }
}