<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistWiseDistributionold.aspx.cs"
    Inherits="Admin_DistWiseDistribution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Distribution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <style type="text/css">

        .auto-style2 {
            font-size: 100%;
            vertical-align: baseline;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0;
            padding: 0;
            background:;
        }
         .myGridStyle
        {
          width:90%;
            
        }
        
.myGridStyle
        {
            border-collapse:collapse;
            font-size:19px;
            
        }
    
        #txtbros {
            width: 82px;
            height: 19px;
        }
    
        .style63
        {
            font-size: 100%;
            vertical-align: baseline;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0;
            padding: 0;
            background: ;
            height: 29px;
        }
    
        .style65
        {
            height: 5px;
            
        }    
        .style66
        {
            height: 33px;
        }    
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" class="inner">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="border: thick none #00CC00; background-color: white;">
            <tr align="center">
                <th colspan="2" style="background-color: white; color: #CCFF33">
                    <img alt="" src="../images/Header.png" />
                </th>
            </tr>
            <tr>
                <td class="style65" colspan="2">
                    <adminmenu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#3B3E75">
                    <img class="style24" src="../images/14.gif" />
                    <span style="color: white;">Logged As ::</span> &nbsp; <span class="style37">
                        <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                </td>
                <td align="right" class="style66" style="color: White;" bgcolor="#3B3E75">
                    Date :&nbsp;&nbsp;
                    <asp:Label ID="lblDate" ForeColor="White" runat="server"></asp:Label>
                    &nbsp;&nbsp;
                </td>
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
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label3" runat="server" Text="Crop"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="ddlcrop" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Crop"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label4" runat="server" Text="Category"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="ddlcaste" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcaste" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Category"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label5" runat="server" Text="Gender"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:RadioButtonList ID="rblgender" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="m">Male</asp:ListItem>
                                    <asp:ListItem Value="f">Female</asp:ListItem>
                                </asp:RadioButtonList>
                            </td><td align="right" class="style_td_label" colspan="2"></td>
                            <%--<td align="right" class="style_td_label">
                                <asp:Label ID="Label6" runat="server" Text="Crop"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Crop"></asp:RequiredFieldValidator>
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="Get" runat="server" Text="GetData" OnClick="GetData" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" valign="top">
                                <table align="center" style="width: 800px">
                                    <tr>
                                        <td align="center">
                                            <rsweb:ReportViewer ID="Rept" Width="100%" Height="100%" runat="server" SizeToReportContent="true"
                                                OnDrillthrough="Rept_Drillthrough">
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
    </div>
    </form>
</body>
</html>
