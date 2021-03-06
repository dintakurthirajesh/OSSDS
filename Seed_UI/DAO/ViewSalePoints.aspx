﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewSalePoints.aspx.cs" Inherits="DAO_ViewSalePoints" %>

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
    <div align="center" class="inner">
        <table border="1" style="border: thick none #00CC00; background-color: white;">
            <tr align="center">
                <th colspan="2" style="background-color: white; color: #CCFF33">
                    <img alt="" src="../images/Header.png" />
                </th>
            </tr>
            <tr>
                <td class="style65" colspan="2">
                    <menu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" class="loggedUser">
                    <img src="../images/14.gif" alt="" />
                    <span style="color: white;">Logged As ::</span> &nbsp;
                    <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                </td>
                <td align="right" class="loggedUser">
                    <span style="color: white;">Date ::</span> &nbsp; <span>
                        <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                </td>
            </tr>
            <tr>
                <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;" class="style64">
                    District Wide Sale Points
                </th>
            </tr>
            <tr>
                <td colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvsp" runat="server" BackColor="#DEBA84" AutoGenerateColumns="false"
                        BorderColor="#DEBA84" Width="30%" BorderStyle="None" BorderWidth="1px" PageSize="10"
                        CssClass="Grid" OnRowDataBound="gvsp_RowDataBound" ShowFooter="true">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." ItemStyle-Width="2%">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex+1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle Width="10px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandal Name" ItemStyle-HorizontalAlign="Left">
                                <ItemTemplate>
                                    <asp:Label ID="lblMandcode" runat="server" Visible="false" Text='<%# Eval("MandCode")%>'></asp:Label>
                                    <asp:LinkButton ID="lblMand" runat="server" Text='<%# Eval("MandName")%>' OnClick="nosp_Click"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No.of SalePoints" FooterStyle-HorizontalAlign="Center"
                                FooterStyle-BackColor="Silver">
                                <ItemTemplate>
                                    <asp:Label ID="nosp" runat="server" Text='<%# Eval("no_of_sp") %>'>LinkButton</asp:Label>
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="totalsps" runat="server" OnClick="totalsps_Click" Font-Bold="True"
                                        Font-Underline="true" Font-Size="Medium"></asp:LinkButton>
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <RowStyle HorizontalAlign="Center" />
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
                <td colspan="2">
                    <br />
                    <footer:footer ID="footer1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
