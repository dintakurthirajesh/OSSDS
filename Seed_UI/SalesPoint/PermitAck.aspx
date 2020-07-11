<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PermitAck.aspx.cs" Inherits="SalesPoint_PermitAck" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            height: 421px;
        }
        .style9
        {
            height: 37px;
            text-align: left;
        }
        .style13
        {
            height: 13px;
            text-align: center;
        }
        .style19
        {
            width: 100%;
            height: 30px;
        }
        .style20
        {
            width: 100%;
            height: 88px;
            background-color: #DDDDEE;
        }
        .style21
        {
            height: 39px;
        }
        .style23
        {
            text-align: right;
            height: 28px;
        }
        .style24
        {
            width: 12px;
            height: 12px;
        }
        .style25
        {
            text-align: left;
            height: 28px;
        }
        .style33
        {
            width: 100%;
            height: 54px;
        }
        .style35
        {
        }
        .style37
        {
            color: #800000;
        }
        .style39
        {
            width: 943px;
        }
        .style40
        {
            width: 970px;
        }
        .style36
        {
            width: 128px;
        }
        .style41
        {
            width: 987px;
            height: 90px;
        }
        .style42
        {
            width: 943px;
            height: 18px;
        }
        .style43
        {
            width: 943px;
            height: 29px;
        }
        .style44
        {
            width: 178px;
        }
        .style45
        {
            width: 87px;
        }
        .style46
        {
            width: 912px;
        }
        .style47
        {
            width: 651px;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <br />
        <table align="center" bgcolor="#DDDDEE" width="990px">
            <tr>
                <td align="center">
                    <table align="center" cellpadding="3" cellspacing="1" class="style3" width="100%">
                        <tr>
                            <td class="style9">
                                <table align="center" cellpadding="0" cellspacing="0" class="style33">
                                    <tr>
                                        <td class="style35" valign="bottom" align="center" style="background-color: White;">
                                            &nbsp;
                                            <img alt="" class="style41" src="../Seed_UI/images/seed%20banner%20.png" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <table cellpadding="3" cellspacing="1" class="style19">
                                    <tr>
                                        <td class="style21">
                                            <table align="center" cellpadding="0" cellspacing="0" class="style20">
                                                <tr>
                                                    <td class="style25" bgcolor="#3B3E75">
                                                        <img class="style24" src="../images/14.gif" />
                                                        <span style="color: white;">Logged As ::</span> &nbsp; <span class="style37">
                                                            <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                                                    </td>
                                                    <td class="style25" bgcolor="#3B3E75">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" class="style23" style="color: White;" bgcolor="#3B3E75">
                                                        Date :&nbsp;&nbsp;
                                                        <asp:Label ID="lblDate" ForeColor="White" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <div id='cssmenu' runat="server" align="center">
                                                            <p>
                                                                &nbsp;</p>
                                                            <div style="float: right; padding: 0px 10px 0px 0px">
                                                                <ul>
                                                                    <li class='has-sub'><a href="../Seed_UI/Logout.aspx">Logout</a></li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                       
                         <tr>
                            <td valign="top" align="center" bgcolor="White" >
                        <table width="100%" >
                        <tr>
                          <td valign="top" align="center" bgcolor="White" >
                        <table width="100%" >
                        <tr>
                            <td bgcolor="#CAFFE4" align="center">
                                
                                <b class="style30">Permit </b>
                                    
                                
                            </td>
                            </tr>
                        </table>
                        </td>
                            </tr>
                        </table>
                        </td>
                        </tr>
                        <tr>
                              <td bgcolor="White" align="center"><asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" 
                                        ForeColor="Red"></asp:Label></td>
                        </tr>
                        <tr>
                                                    <td colspan="4" align="right">
                                                    <asp:LinkButton ID="lblBacktoRequest" runat="server" OnClick="lblBacktoRequest_Click">Back to Farmer Indent Page</asp:LinkButton>
                                                    </td>
                                                </tr>
                       
                                                 <tr>
                                                    <td colspan="4" align="center">
                                                    <rsweb:ReportViewer ID="RptPermit" runat="server" Width="100%">
                                                                </rsweb:ReportViewer>
                                                    </td>
                                                </tr>
                        
                        
                    </table>
                </td>
            </tr>
            
            <tr>
                <td class="style13">
                </td>
            </tr>
            <tr>
                <td bgcolor="#3B3E75" class="style13">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

