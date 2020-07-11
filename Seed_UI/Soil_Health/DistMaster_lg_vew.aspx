<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistMaster_lg_vew.aspx.cs" Inherits="DistMaster" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/Soil_Health/SAdmin.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/sFooter.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LG Directory</title>
   
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
 
        <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
      

  
 
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table border="0" width="1190px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td align="center">
                    <img alt="" src="../Images/soilbanner.png" />
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#55A8BD" align="left">
                    <menu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                             <tr>
                            <td align="left" class="userdate">
                                <img src="../Images/14.gif" />
                                <span style="color: green;">Logged As ::</span> &nbsp; <span>
                                    <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                            <td align="right" bgcolor="White">
                                <span style="color: green;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="background-color: #3882a2; color: White; height: 30px;
                                font-size: larger;">
                                &nbsp;District Master</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <%-- <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>--%>
                    <div align="center">
                        <table align="center" width="80%">
                            <tr>
                                <td style="background-color" align="center">
                                
                                    <rsweb:ReportViewer ID="ReportViewer1" SizeToReportContent="true" runat="server">
                                    </rsweb:ReportViewer>
                                </td>
                            </tr>
                        </table>
                    </div>
                  
                </td>
            </tr>
       
          
            <tr>
                <td style="padding-top: 10px;">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
