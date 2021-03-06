﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="DAO_home" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
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
                                <img src="../images/14.gif" />
                                <span style="color: white;">Logged As ::</span> &nbsp; <span>
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
            <tr align="center">
                <td colspan="2" align="center">
                    Welcome To Distrcict Agriculture Officer,
                    <asp:Label ID="lbld" Font-Bold="true" runat="server"></asp:Label>
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table width="80%">
                        <tr>
                            <td align="center">
                                <strong>Seed Allotted to Your District<br />
                                </strong>
                            </td>
                        </tr>
                        <tr align="center">
                            <td align="center">
                                <asp:GridView ID="KharifGrid" runat="server" BackColor="#DEBA84" AutoGenerateColumns="false"
                                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" PageSize="5" CssClass="Grid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="year" HeaderText="Year" />
                                        <asp:BoundField DataField="season" HeaderText="Season" />
                                        <asp:BoundField DataField="AgencyName" HeaderText="Supplying Agency" />
                                        <asp:BoundField DataField="CropNm" HeaderText="Crop Name" />
                                        <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity" />
                                        <asp:BoundField DataField="alloted_dt" HeaderText="Alloted On" />
                                        <asp:BoundField DataField="qty_left" HeaderText="Qty Left" />
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnAllot" runat="server" Text="Allot Seed" CommandArgument='<%# Eval("year")+ "," +Eval("season")+ "," +Eval("CropNm")+ "," +Eval("crop")+ "," 
                                                +Eval("alloted_qty")+ "," +Eval("allotment_id")+ "," +Eval("qty_left") %>'
                                                    OnClick="AllotSeed"></asp:LinkButton>
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
                            <td align="center">
                                <asp:GridView ID="RabiGrid" runat="server" BackColor="#DEBA84" AutoGenerateColumns="false"
                                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" PageSize="5" CssClass="Grid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="year" HeaderText="Year" />
                                        <asp:BoundField DataField="season" HeaderText="Season" />
                                        <asp:BoundField DataField="AgencyName" HeaderText="Supplying Agency" />
                                        <asp:BoundField DataField="CropNm" HeaderText="Crop Name" />
                                        <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity" />
                                        <asp:BoundField DataField="alloted_dt" HeaderText="Alloted On" />
                                        <asp:TemplateField ShowHeader="False">
                                             <ItemTemplate>
                                                <asp:LinkButton ID="btnAllot" runat="server" Text="Allot Seed" CommandArgument='<%# Eval("year")+ "," +Eval("season")+ "," +Eval("CropNm")+ "," +Eval("crop")+ "," 
                                                +Eval("alloted_qty")+ "," +Eval("allotment_id")+ "," +Eval("qty_left") %>'
                                                    OnClick="AllotSeed"></asp:LinkButton>
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
