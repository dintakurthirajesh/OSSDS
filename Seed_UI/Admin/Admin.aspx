﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="EVHMS_UI_Admin_Admin" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
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
    <script type="text/javascript">
        function cal() {

            var txtbrocen = document.getElementById('txtbroc').value;
            var txtbros = document.getElementById('txtbros').value;
            var txtTotal = MathRound(parseFloat(txtbrocen) + parseFloat(id));
            alert("txtTotal" + txtTotal);
            alert("txtbrocen" + txtbrocen);
            alert("txtbros" + txtbros);
            var TotalVar = document.getElementById(lblBroT);
            TotalVar.innerHTML = txtTotal;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server" align="center">
    <div align="center" class="inner">
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
                <td class="style65" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr align="center">
                <td class="style63" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr align="center">
                <td class="style63" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <br />
            <tr>
                <td class="auto-style2" align="center">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    Welcome to Commissionerate, Seeds, Departement of Agriculture
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="auto-style2" align="center" colspan="2">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <footer:footer ID="footer1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
