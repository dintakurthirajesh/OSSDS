<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyReport.aspx.cs" Inherits="Admin_DailyReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
    <script src="../Scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
    <script type="text/javascript" language="javascript">

        function getdate() {
            $('#txtdt').datepicker({
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
    </script>
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
                                <adminmenu:menu ID="menu" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="loggedUser">
                                <img src="../images/14.gif" />
                                <span style="color: white;">Logged As ::</span>
                                <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
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
                <td align="center">
                    <table align="center" cellpadding="3" cellspacing="1" width="80%">
                        <tr align="center">
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
                            </td>
                            <td align="left" class="style_td_label">
                                <asp:DropDownList ID="ddlyear" runat="server" Width="160px">
                                    <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                    <asp:ListItem Selected="True" Text="2017" Value="2017"></asp:ListItem>
                                    <%-- <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>--%>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlyear" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Year"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label6" runat="server" Text="Season:"></asp:Label>
                            </td>
                            <td align="left" class="style_td_label">
                                <asp:DropDownList ID="seasons" runat="server" Width="160px">
                                    <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Kharif" Selected="True" Value="Kharif"></asp:ListItem>
                                    <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label2" runat="server" Text="Date:"></asp:Label>
                            </td>
                            <td align="left" class="style_td_label">
                                <asp:TextBox ID="txtdt" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="txtdt" runat="server" ForeColor="Red"
                                    ErrorMessage="Select Date"></asp:RequiredFieldValidator>
                            </td>
                            <%-- <td align="right" class="style_td_label">
                                <asp:Label ID="Label3" runat="server" Text="Agency"></asp:Label>
                            </td>
                            <td align="left" class="style_td_label">
                                <asp:DropDownList ID="ddlagency" runat="server" Width="160px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlagency" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Agency"></asp:RequiredFieldValidator>
                            </td>--%>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label4" runat="server" Text="Crop"></asp:Label>
                            </td>
                            <td align="left" class="style_td_label">
                                <asp:DropDownList ID="ddlcrop" runat="server" Width="160px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Crop"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" class="style_td_label" colspan="8">
                                <asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="center">
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px" Height="500px">
                                </rsweb:ReportViewer>
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
