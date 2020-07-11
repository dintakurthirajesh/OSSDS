<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SalePoint.aspx.cs" Inherits="DAO_SalePoint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DAO/DAOMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Distrbution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <style type="text/css">
        table
        {
            background-color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table align="center" bgcolor="#DDDDEE" width="90%">
            <tr>
                <td align="center">
                    <table align="center" cellpadding="3" cellspacing="1" width="100%">
                        <tr align="center">
                            <th colspan="2" style="background-color: white; color: #CCFF33">
                                <img alt="" src="../images/Header.png" />
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <menu:menu ID="menu" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="loggedUser">
                                <img src="../images/14.gif" alt="" />
                                <span style="color: white;">Logged As ::</span>
                                <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="loggedUser">
                                <span style="color: white;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" bgcolor="White">
                    <table class="tbldata" style="width: 80%;">
                        <tr>
                            <th colspan="4" style="color: Red; font-size: large; background-color: #88d8e0; height: 35px;">
                                Add Sale Point
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 30%;">
                                Mandal Name:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddl_Mandal" runat="server" Width="160px" AutoPostBack="True"
                                    OnSelectedIndexChanged="ddl_Mandal_SelectedIndexChanged">
                                    <asp:ListItem Text="Select Mandal" Value="0"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ddl_Mandal"
                                    ValidationGroup="g1" InitialValue="Select Mandal" runat="server" ForeColor="Red"
                                    ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 30%;">
                                Sale Point Name:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSalePName" placeholder="Sale Pont Name" runat="server" Height="23px"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtSalePName_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters,numbers, custom"
                                    ValidChars=" " runat="server" BehaviorID="txtSalePName_FilteredTextBoxExtender"
                                    TargetControlID="txtSalePName" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ForeColor="Red"
                                    ErrorMessage="*" ControlToValidate="txtSalePName"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Sale Point Incharge(Agriculture):
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtinchrgAgri" placeholder="Sale Pont Name" runat="server" Height="23px"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="UppercaseLetters, LowercaseLetters, custom"
                                    ValidChars=" " runat="server" BehaviorID="txtSalePName_FilteredTextBoxExtender"
                                    TargetControlID="txtinchrgAgri" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ForeColor="Red"
                                    ErrorMessage="*" ControlToValidate="txtinchrgAgri"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                Sale Point Incharge(Society):
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtinchrgSocty" placeholder="Sale Pont Name" runat="server" Height="23px"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="UppercaseLetters, LowercaseLetters, custom"
                                    ValidChars=" " runat="server" BehaviorID="txtSalePName_FilteredTextBoxExtender"
                                    TargetControlID="txtinchrgSocty" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red"
                                    ErrorMessage="*" ControlToValidate="txtinchrgSocty"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Sale Point Incharge Mobile Number:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmobile" MaxLength="10" placeholder="Incharge Mobile number" runat="server"
                                    Height="23px"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="mobile_filter" BehaviorID="mobile_filter" FilterType="numbers"
                                    ValidChars="1,2,3,4,5,6,7,8,9,0 " runat="server" TargetControlID="txtmobile" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ForeColor="Red"
                                    ErrorMessage="*" ControlToValidate="txtmobile"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmobile"
                                    ErrorMessage="*" ForeColor="Red" ValidationExpression="^[789]\d{9}$"></asp:RegularExpressionValidator>
                            </td>
                            <td align="right">
                               <b> UserID For Sale Point Lgoin</b>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtuser" placeholder="UserName for login to sale point" runat="server"
                                    Height="23px" AutoPostBack="true" ontextchanged="txtuser_TextChanged"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtSociety_FilteredTextBoxExtender" runat="server"
                                    Enabled="True" TargetControlID="txtuser" FilterType="UppercaseLetters,lowercaseLetters">
                                </ajax:FilteredTextBoxExtender>
                                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red"
                                    ErrorMessage="*" ControlToValidate="txtuser"></asp:RequiredFieldValidator>
                                <span style="color: Red; font-size: small; background-color: #88d8e0; height: 35px;">
                                   <b> UserId Cannot be Changed.</b></span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" valign="top" colspan="2">
                                <asp:Label ID="Label1" runat="server" Text="Active:"></asp:Label>
                            </td>
                            <td align="left" style="width: 100%;" colspan="2">
                                <asp:RadioButtonList ID="rblActive" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="g1" ControlToValidate="rblActive"
                                    runat="server" ForeColor="Red" ErrorMessage="*"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2" bgcolor="White">
                    <asp:Button ID="btn_Save" ValidationGroup="g1" runat="server" Height="27px" Text="Save"
                        OnClick="btn_Save_Click" />
                    <asp:Button ID="btn_Update" runat="server" Height="30px" Text="Update" OnClick="btn_Update_Click" />
                    <asp:HiddenField ID="hdnspcode" runat="server" />
                </td>
            </tr>
            <tr align="center">
                <td colspan="2" bgcolor="White">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="3" OnRowCommand="GridView1_RowCommand"
                        BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84" BorderStyle="None"
                        BorderWidth="1px" PageSize="15" Width="80%" CssClass="Grid" 
                        OnRowDataBound="GridView1_RowDataBound" 
                        onpageindexchanging="GridView1_PageIndexChanging">
                        <RowStyle BackColor="#FFF7E7" BorderStyle="Solid" Font-Size="Small" ForeColor="#8C4510" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.NO.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandal">
                                <ItemTemplate>
                                    <asp:Label ID="lblMand" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sale Point Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblspcode" runat="server" Visible="false" Text='<%# Bind("SalePtCode") %>'></asp:Label>
                                    <asp:Label ID="lblSPName" runat="server" Text='<%# Bind("SalePtName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incharge(Agriculture)">
                                <ItemTemplate>
                                    <asp:Label ID="lblagrinch" runat="server" Text='<%# Bind("Incharge") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Incharge(Society)">
                                <ItemTemplate>
                                    <asp:Label ID="lblagriSoc" runat="server" Text='<%# Bind("Incharge_Society") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mobile">
                                <ItemTemplate>
                                    <asp:Label ID="lblmobile" runat="server" Text='<%# Bind("mobile") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="UserName">
                                <ItemTemplate>
                                   <b> <asp:Label ID="lbluser" runat="server" Text='<%# Bind("UserName") %>'></asp:Label></b>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblActive" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CausesValidation="false" CommandName="Edt"
                                        Text="Edit"></asp:LinkButton>
                                    <%-- <asp:LinkButton ID="btnDelete" runat="server"  CausesValidation="false" OnClientClick="return GetSelectedRow(this)"
                                        CommandName="Dlt" Text="Delete"></asp:LinkButton>--%>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <RowStyle HorizontalAlign="Center" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" Font-Size="Small" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
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
