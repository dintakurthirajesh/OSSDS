<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewPermits.aspx.cs" Inherits="Admin_ViewPermits" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
    <style type="text/css">
        .style63
        {
            font-size: large;
        }
    </style>
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
                                <adminmenu:menu ID="menu" runat="server" alt="" />
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
                                View Sales
                            </th>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center" colspan="2">
                                <table width="90%">
                                    <tr>
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label1" runat="server" Text="Year"></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_entry">
                                            <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged">
                                                <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                <asp:ListItem Selected="True" Text="2017" Value="2017"></asp:ListItem>
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
                                            <asp:DropDownList ID="seasons" runat="server" AutoPostBack="true">
                                                <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                                <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="Get" runat="server" Text="GetData" OnClick="GetData" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" valign="top">
                                            <table align="center" style="width: 800px">
                                                <tr>
                                                    <td align="center">
                                                        <rsweb:ReportViewer ID="Rept" Width="100%" Height="100%" runat="server" 
                                                            SizeToReportContent="true" ondrillthrough="Rept_Drillthrough">
                                                        </rsweb:ReportViewer>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            &nbsp;
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
