<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GramPanchayatMaster_lg_view.aspx.cs" Inherits="MandalMaster" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/Soil_Health/SAdmin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/sFooter.ascx" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LG Directory</title>
    
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
       <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
   
    <script type="text/javascript" language="javascript">
        String.prototype.startsWith = function (str) {
            return (this.indexOf(str) === 0);
        }
        function ChkValidChar() {

            var txtbx = document.getElementById("txtMandalCode").value;
            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtMandalCode").value = "";
                alert("you can not insert zero as first character");
            }
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table border="0" width="1190px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td align="center">
                    <img alt="" class="style64" src="../Images/soilbanner.png" />
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#55A8BD" align="left">
                    <menu:menu ID="menu1" runat="server" />
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
                                 &nbsp;Gram Panchayat
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                  
                    <div align="center">
                        <table align="center" width="100%">
                            <tr align="center">
                                <td class="style65">
                                    <table class="tbldata" align="center" width="80%">
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 50%;">
                                                District Name:&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddl_dist_code" runat="server" CssClass="style_txt_entry" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                     
                                        <tr>
                                            <td align="right" style="width: 50%;">
                                                Mandal Name:&nbsp;
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddl_mandal_code" runat="server" 
                                                    CssClass="style_txt_entry" AutoPostBack="true" onselectedindexchanged="ddl_mandal_code_SelectedIndexChanged"
                                                   >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                     
                                        </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                  
                </td>
            </tr>
            <tr align="center">
                <td align="center">
                    <table style="width: 80%;">
                        <tr>
                            <td align="center">
                                <rsweb:ReportViewer ID="ReportViewer1" runat="server" SizeToReportContent="true">
                                </rsweb:ReportViewer>
                            </td>
                        </tr>
                      
                    </table>
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
