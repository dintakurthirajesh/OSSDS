<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewDistrbution.aspx.cs" Inherits="MAO_ViewDistrbution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/MAO/MAOMenu.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Seed Distrbution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />    
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <style type="text/css">
        table
        {
            background-color: white;
        }
        .style63
        {
            font-size: x-large;
        }
        .style1
        {
            font-weight: bolder;
            font-size: larger;
        }
        </style>
      <script type="text/javascript" language="javascript">
          function getdate() {
              $('#txtFrmdt').datepicker({
                  dateFormat: 'dd/mm/yy',
                  maxDate: new Date(),
                  changeMonth: true,
                  changeYear: true,
                  yearRange: "-20:+0"
              });

              $('#txtTodt').datepicker({
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
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table align="center" bgcolor="#DDDDEE" width="90%" style="border-style: dotted">
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
                                <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                <asp:Label ID="lblMand" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="loggedUser">
                                <span style="color: white;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                        <tr align="center">
                            <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                View Seed Distribution
                            </th>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td bgcolor="White" align="center" colspan="2">
                    <table width="90%">
                        <tr>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label3" runat="server" Text="Select Sale Point"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="ddlsp" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlsp" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Sale Point"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label1" runat="server" Text="From Date"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:TextBox ID="txtFrmdt" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="txtFrmdt" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Select From Date"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label2" runat="server" Text="To Date"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                             <asp:TextBox ID="txtTodt" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="txtTodt" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Select To Date"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="Get" runat="server" Text="GetData" OnClick="GetData" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <rsweb:ReportViewer ID="Rept" Width="100%" Height="100%" runat="server" SizeToReportContent="true">
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
