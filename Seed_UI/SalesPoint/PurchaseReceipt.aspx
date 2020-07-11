<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PurchaseReceipt.aspx.cs" Inherits="SalesPoint_PurchaseReceipt" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
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
            font-size: large;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
   <div align="center" style="padding-top: 1%;">
        <table align="center" bgcolor="white" width="90%">
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
                        <tr align="center">
                            <td colspan="2" bgcolor="White">
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center" bgcolor="White" colspan="2">
                                <table width="100%">
                                    <tr>
                                        <td valign="top" align="center" bgcolor="White">
                                            <table width="100%">
                                                <tr>
                                                    <td bgcolor="#CAFFE4" align="center">
                                                        <b class="style30">Purchase Receipt </b>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" colspan="2" align="center">
                                <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="right">
                                <asp:LinkButton ID="lblBacktoRequest" runat="server" OnClick="lblBacktoRequest_Click">Back to Seed Distribution</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <rsweb:reportviewer id="RptReceipt" runat="server" width="70%" height="600">
                                    </rsweb:reportviewer>
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
