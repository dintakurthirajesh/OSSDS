<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Distributionseeds.aspx.cs"
    Inherits="SalesPoint_Distributionseeds" %>
    
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="spmenu" TagName="menu" Src="~/SalesPoint/SalePoint.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Distribution</title>
    <link href="../css/Menu1.css" rel="stylesheet" type="text/css" />
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style63
        {
            font-size: larger;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--<div class="inner" style="padding: 2% 5% 5% 5%" align="center">--%>
    <div align="center" style="padding-top: 1%;">
        <table align="center" bgcolor="#DDDDEE" width="90%">
            <tr>
                <td align="center">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <table align="center" cellpadding="3" cellspacing="1" width="100%">
                        <tr align="center">
                            <th colspan="2" style="background-color: white; color: #CCFF33">
                                <img alt="" src="../images/Header.png" />
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <spmenu:menu ID="menu" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="loggedUser">
                                <img src="../images/14.gif" alt="" />
                                <span style="color: #ab7d44;">Logged As ::</span> &nbsp; <span>
                                    <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                    <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                    <asp:Label ID="lblMand" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                                </span>
                            </td>
                            <td align="right" class="loggedUser">
                                <span style="color: white;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center" colspan="2">
                                <table width="90%">
                                    <tr align="center">
                                        <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                            Seed Distribution
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50%;">
                                            <asp:Label ID="Label1" runat="server" Text="Enter Permit No :"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtpermit" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Get" OnClick="btnSubmit_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center" bgcolor="White">
                                            <table width="70%">
                                                <tr>
                                                    <td class="style_td_label">
                                                        Farmer Name
                                                        <asp:Label ID="fid" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                    <td class="style_td_label">
                                                        <asp:Label ID="farmeNm" runat="server"></asp:Label>
                                                        &nbsp; S/o.
                                                        <asp:Label ID="fatherNm" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style_td_label">
                                                        Year
                                                    </td>
                                                    <td class="style_td_label">
                                                        <asp:Label ID="lblyear" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="spcode" runat="server" Visible="false"></asp:Label>
                                                        <%-- <asp:Label ID="lblcrpcode" runat="server" Visible="false"></asp:Label>--%>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="style_td_label">
                                                        Season
                                                    </td>
                                                    <td class="style_td_label">
                                                        <asp:Label ID="lblseason" runat="server" Text="Label"></asp:Label>
                                                        <asp:Label ID="lblmobile" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:GridView ID="grdPermit" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84" OnRowDataBound="grdPermit_RowDataBound"
                                                BorderStyle="None" BorderWidth="1px" PageSize="5" Width="80%" CssClass="Grid"
                                                runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SlNo">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CropName" HeaderText="Crop Name" />
                                                    <asp:BoundField DataField="CropVnmTel" HeaderText="Crop Variety Name" />
                                                    <%--  <asp:BoundField DataField="stock_available" HeaderText="Stock Available" />--%>
                                                    <asp:TemplateField HeaderText="Bags Available/Weight Of Each Bag" HeaderStyle-Width="150">
                                                        <ItemTemplate>
                                                            <asp:Label ID="stock_id" Visible="false" runat="server" Text='<%# Eval("stock_id") %>'></asp:Label>
                                                            <asp:Label ID="crop_code" Visible="false" runat="server" Text='<%# Eval("CropCode") %>'></asp:Label>
                                                            <asp:Label ID="crop_vcode" Visible="false" runat="server" Text='<%# Eval("CropVarietyCode") %>'></asp:Label>
                                                            <asp:Label ID="lbl_stock_available" runat="server" Text='<%# Eval("stock_available") %>'></asp:Label>/
                                                            <asp:Label ID="lblweight" runat="server" Text='<%# Eval("weight_of_bag") %>'></asp:Label>Kg
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:BoundField DataField="Extent" HeaderText="Extent" />
                            <asp:BoundField DataField="SeedQty_Requirement" HeaderText="Seed Requirement(Kgs)" />
                            <asp:BoundField DataField="SeedQty_Requested" HeaderText="Seed Requested(Kgs)" />--%>
                                                    <%--  <asp:BoundField DataField="SeedQty_Issued" HeaderText="Seed Sanctioned(Kgs)" />--%>
                                                    <asp:TemplateField HeaderText="No of Bags Sanctioned" HeaderStyle-Width="100">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblsanctioned" runat="server" Text='<%# Eval("SeedQty_Issued") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                  <%--  <asp:BoundField DataField="Actual_MRP" HeaderText="Actual Rate(Rs.)" HeaderStyle-Width="100" />--%>
                                                    <%--  <asp:BoundField DataField="Subsidized_Price" HeaderText="Subsidy Rate(Rs.)" />--%>
                                                    <%--<asp:TemplateField HeaderText="Subsidy Price(Rs/kg)" HeaderStyle-Width="100">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblprice" runat="server" Text='<%# Eval("Subsidized_Price") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                     <asp:TemplateField HeaderText="Price">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="ddlprice" runat="server" Width="200px" CssClass="fldtxtbox">
                                                                <asp:ListItem>Select Price</asp:ListItem>
                                                                  <asp:ListItem Text="test" Value="0">Select Price</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No of bags Purchased " HeaderStyle-Width="100">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtPurchQty" AutoPostBack="True" Width="50" runat="server" OnTextChanged="txtPurchQty_TextChanged"></asp:TextBox>
                                                            <ajaxtoolkit:filteredtextboxextender id="txtPurchQty_Extender" filtertype="Numbers"
                                                                runat="server" behaviorid="txtPurchQty_Extender" targetcontrolid="txtPurchQty">
                                                                </ajaxtoolkit:filteredtextboxextender>
                                                            <asp:Label ID="lblqtypurchased" runat="server" Visible="false"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblamount" placeholder="Amount" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#A55129" BorderStyle="Solid" Font-Bold="True" Font-Size="Small"
                                                    ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Total Amount
                                        </td>
                                        <td align="left">
                                            <b>
                                                <asp:Label ID="lbltot" runat="server"></asp:Label></b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="Save" runat="server" Text="Submit" OnClick="Save_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <footer:footer ID="footer1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
