<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockEntry.aspx.cs" Inherits="SalesPoint_StockEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="spmenu" TagName="menu" Src="~/SalesPoint/SalePoint.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Subsidy</title>
    <script src="../Scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
    <link href="../css/Menu1.css" rel="stylesheet" type="text/css" />
    <link href="../css/style1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">

        function getdate() {
            $('#lrdt').datepicker({
                dateFormat: 'dd/mm/yy',
                maxDate: new Date(),
                changeMonth: true,
                changeYear: true,
                yearRange: "-20:+0"
            });
        }
        $(document).ready(function () {
            getdate();
        });

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
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
                                <img src="../images/14.gif" />
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
                        <tr align="center">
                            <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                Stock Received Details
                            </th>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Label ID="lblaid" Visible="false" runat="server"></asp:Label>
                                Allotted:
                               <span style=""><asp:Label ID="lblstkMax" runat="server"></asp:Label></span>
                            &nbsp; Qtls</td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center" colspan="2">
                                <table width="90%">
                                    <tr>
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label1" runat="server" Text="Year"></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="fldtxtbox">
                                                <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                <asp:ListItem Text="2017" Selected="True" Value="2017"></asp:ListItem>
                                                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlyear" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Year"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label2" runat="server" Text="Season"></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="seasons" runat="server" CssClass="fldtxtbox" 
                                                AutoPostBack="True" onselectedindexchanged="seasons_SelectedIndexChanged">
                                                <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                                <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" class="style_td_entry">
                                            <asp:Label ID="Label8" runat="server" Text="Company Name "></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="ddlcomapnies" CssClass="fldtxtbox" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcomapnies_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td></tr>
                                     <tr>
                                        <td align="right" class="style_td_label">
                                            Crop
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="ddl_crop" runat="server" CssClass="fldtxtbox" AutoPostBack="true" OnSelectedIndexChanged="ddl_crop_SelectedIndexChanged">
                                                <asp:ListItem>Select Crop</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            Crop Variety
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="ddl_variety" AutoPostBack="true" OnSelectedIndexChanged="ddl_variety_SelectedIndexChanged"
                                                runat="server" Width="200px" CssClass="fldtxtbox">
                                                <asp:ListItem>Select Crop Variety</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                         <td align="right" class="style_td_label">
                                             <asp:Label ID="Label3" runat="server" Text="DC Number"></asp:Label>
                                           
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:TextBox ID="lrno" runat="server" CssClass="fldtxtbox"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style_td_label">
                                            LR Date
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:TextBox ID="lrdt" runat="server" CssClass="fldtxtbox"></asp:TextBox>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            Stock Received
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:TextBox ID="stkrecd" runat="server" CssClass="fldtxtbox" Enabled="false" ></asp:TextBox>
                                            (in qtls)
                                            <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom"
                                                ValidChars="01234567890." TargetControlID="stkrecd" />
                                            <asp:Label ID="lbloldqty" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            No.Of Bags Received
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:TextBox ID="txtNo_bags" runat="server" Width="50" CssClass="fldtxtbox" 
                                                ontextchanged="txtNo_bags_TextChanged" AutoPostBack="true"></asp:TextBox>
                                               <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" FilterType="Numbers"
                                                TargetControlID="txtNo_bags" />  
                                                Each of
                                            <asp:Label ID="txtpcksize" Width="20px" runat="server" Font-Bold="True"></asp:Label>Kgs
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style_td_label">
                                            Agency
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="ddlagency" runat="server" CssClass="fldtxtbox">
                                            </asp:DropDownList>
                                        </td>
                                        <td colspan="4" class="style_td_entry"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6" align="center">
                                            <asp:Button ID="Save" runat="server" Text="Save" OnClick="save_Click" />
                                            <asp:Button ID="Update" runat="server" Text="Update" OnClick="Update_Click" />
                                            <asp:Label ID="lblstkid" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center" colspan="2">
                                <table width="90%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridView1" runat="server" AlternatingRowStyle-CssClass="alt" AutoGenerateColumns="false"
                                                PagerStyle-CssClass="pgr" AllowPaging="false" BackColor="#DEBA84" BorderColor="#DEBA84"
                                                OnRowCommand="GridView1_RowCommand" CssClass="Grid" BorderStyle="None" BorderWidth="1px">
                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SlNo">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Year" HeaderText="Year" />
                                                    <asp:BoundField DataField="season" HeaderText="Season" />
                                                    <asp:TemplateField HeaderText="Crop">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcv" runat="server" Text='<%# Eval("CropVnmTel")%>'></asp:Label>
                                                            <asp:Label ID="lblcrpcode" runat="server" Visible="false" Text='<%# Eval("crop_code")%>'></asp:Label>
                                                            <asp:Label ID="lblcvcode" runat="server" Visible="false" Text='<%# Eval("crop_vcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Lr_no" HeaderText="LR Number" />
                                                    <asp:TemplateField HeaderText="Stock Received(in Qtls)">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblrcvd" runat="server" Text='<%# Eval("stock_received")%>'></asp:Label>
                                                            <asp:Label ID="lblallotid" runat="server" Visible="false" Text='<%# Eval("allot_id")%>'></asp:Label>
                                                            <asp:Label ID="lblstkid" runat="server" Visible="false" Text='<%# Eval("stock_id")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Agency">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblagency" runat="server" Text='<%# Eval("AgencyName")%>'></asp:Label>
                                                            <asp:Label ID="lblagencycode" runat="server" Visible="false" Text='<%# Eval("agency")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="stock_recvd_dt" HeaderText="Stock Receiving Date" />
                                                    <asp:BoundField DataField="no_of_bags" HeaderText="No.of Bags" />
                                                    <asp:BoundField DataField="weight_of_bag" HeaderText="Weight of Bag" />
                                                    <asp:TemplateField HeaderText="Update" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                                               <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt" OnClientClick="return Confirm(this)"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
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
