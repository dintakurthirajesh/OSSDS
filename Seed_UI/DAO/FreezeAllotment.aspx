﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FreezeAllotment.aspx.cs"
    Inherits="DAO_FreezeAllotment" %>

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
    <script type="text/javascript" language="javascript">
        function SelectAllCheckboxes1(chk) {

            $('#<%=grdSeed.ClientID%>').find("input:checkbox").each(function () {
                if (this != chk) {
                    this.checked = chk.checked;
                }
            });
        }

        $(".cbChild").change(function () {
            var all = $('.cbChild');
            if (all.length === all.find(':checked').length) {
                $(".cbAll").attr("checked", true);
            } else {
                $(".cbAll").attr("checked", false);
            }
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" bgcolor="White">
                    <table class="tbldata" style="width: 90%;">
                        <tr>
                            <th colspan="6" style="color: Red; background-color: #88d8e0; height: 35px; font-size: large;">
                                Seed Allotment
                            </th>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlyear" runat="server">
                                    <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                    <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlyear" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Year"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label6" runat="server" Text="Season:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="seasons" runat="server">
                                    <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                    <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right">
                                <asp:Label ID="Label4" runat="server" Text="Criteria"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblcriteria" runat="server" RepeatDirection="Horizontal"
                                    AutoPostBack="True" OnSelectedIndexChanged="rblcriteria_SelectedIndexChanged">
                                    <asp:ListItem Text="Crop Wise" Value="crop"></asp:ListItem>
                                    <asp:ListItem Text="Mandal Wise" Value="mand"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label2" runat="server" Text="Crop Name:"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlcropname" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlcropname_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcropname" InitialValue="Select Crop Name"
                                    runat="server" ForeColor="Red" ErrorMessage="Please Select Crop Name"></asp:RequiredFieldValidator>
                            </td>
                            
                            <td align="right">
                                Mandal
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlMand" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlMand_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="g1" runat="server"
                                    ControlToValidate="ddlMand" ErrorMessage="Select Mandal" InitialValue="Select Mandal"
                                    ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td></td>
                            <td></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr bgcolor="White">
                <td align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:GridView ID="grdSeed" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84"
                        BorderStyle="None" BorderWidth="1px" PageSize="10" CssClass="Grid" Width="90%"
                        runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="year" HeaderText="Year" />
                            <asp:BoundField DataField="season" HeaderText="Season" />
                            <%-- <asp:TemplateField HeaderText="Agency">
                                <ItemTemplate>
                                    <asp:Label ID="lblagency" runat="server" Text='<%# Eval("AgencyName")%>'></asp:Label>
                                    <asp:Label ID="lblagencycode" runat="server" Visible="false" Text='<%# Eval("agency_code")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Crop">
                                <ItemTemplate>
                                    <asp:Label ID="lblcrop" runat="server" Text='<%# Eval("cropNm")%>'></asp:Label>
                                    <asp:Label ID="lblcv" runat="server" Visible="false" Text='<%# Eval("cropv")%>'></asp:Label>
                                    <asp:Label ID="lblcropcode" runat="server" Visible="false" Text='<%# Eval("crop")%>'></asp:Label>
                                    <asp:Label ID="lblAllotid" runat="server" Visible="false" Text='<%# Eval("allotment_id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandal">
                                <ItemTemplate>
                                    <asp:Label ID="lblMand" runat="server" Text='<%# Eval("MandName")%>'></asp:Label>
                                    <asp:Label ID="lblmandcode" runat="server" Visible="false" Text='<%# Eval("mandal")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity(in Qtls)" />
                            <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                    <input id="chkAll" class="cbAll" onclick="javascript:SelectAllCheckboxes1(this);"
                                        runat="server" type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelct" runat="server" CssClass="cbChild" /><br />
                                </ItemTemplate>
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
                <td colspan="2" align="center" bgcolor="White">
                    <asp:Button ID="Button1" runat="server" Text="Freeze" OnClick="Button1_Click" />
                </td>
            </tr>
             <tr>
                <td align="center">
                    <asp:GridView ID="gvfreezed" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84"
                        BorderStyle="None" BorderWidth="1px" PageSize="10" CssClass="Grid" Width="90%"
                        runat="server">
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="year" HeaderText="Year" />
                            <asp:BoundField DataField="season" HeaderText="Season" />
                           
                            <asp:TemplateField HeaderText="Crop">
                                <ItemTemplate>
                                    <asp:Label ID="lblcrop" runat="server" Text='<%# Eval("cropNm")%>'></asp:Label>
                                    <asp:Label ID="lblcv" runat="server" Visible="false" Text='<%# Eval("cropv")%>'></asp:Label>
                                    <asp:Label ID="lblcropcode" runat="server" Visible="false" Text='<%# Eval("crop")%>'></asp:Label>
                                    <asp:Label ID="lblAllotid" runat="server" Visible="false" Text='<%# Eval("allotment_id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Mandal">
                                <ItemTemplate>
                                    <asp:Label ID="lblMand" runat="server" Text='<%# Eval("MandName")%>'></asp:Label>
                                    <asp:Label ID="lblmandcode" runat="server" Visible="false" Text='<%# Eval("mandal")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity(in Qtls)" />
                         
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
