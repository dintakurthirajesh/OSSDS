<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Permit.aspx.cs" Inherits="SalesPoint_Permit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 6px;
        }
    </style>
    <script type = "text/javascript">
        function PrintPanel() {
            var panel = document.getElementById("<%=pnlContents.ClientID %>");
            var printWindow = window.open('', '', 'height=400,width=800');
            printWindow.document.write('<html><head><title>DIV Contents</title>');
            printWindow.document.write('</head><body >');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Panel id="pnlContents" runat = "server">
    <table align="center">
    <tr>
    <td align="center" colspan="5">
        Government of Telangana</td>
    <td align="center">
        &nbsp;</td>
    <td align="center">
        &nbsp;</td>
    <td align="center" class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td align="center" colspan="5">
        Department of Agriculture<br />
    </td>
    <td align="center">
        &nbsp;</td>
    <td align="center">
        &nbsp;</td>
    <td align="center" class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td align="center" colspan="5">
        Cheriyal Mandal, Warangal District</td>
    <td align="center">
        &nbsp;</td>
    <td align="center">
        &nbsp;</td>
    <td align="center" class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td colspan="5">
        PERMIT SLIP FOR SUPPLY OF SEEDS</td>
    <td>
        &nbsp;</td>
    <td>
        &nbsp;</td>
    <td class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td align="center" colspan="5">
        Permit Number:01/00005</td>
    <td align="center">
        &nbsp;</td>
    <td align="center">
        &nbsp;</td>
    <td align="center" class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td align="center" colspan="5">
        &nbsp;</td>
    <td align="center">
        &nbsp;</td>
    <td align="center">
        &nbsp;</td>
    <td align="center" class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td align="center">
        Scheme</td>
        <td>RKVY</td>
        <td>&nbsp;</td>
        <td>Year</td>
        <td>2015</td>
        <td>&nbsp;</td>
        <td>
            Season</td>
        <td class="style1">
            &nbsp;</td>
    </tr>
    <tr>
    <td align="center">
        &nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>
            &nbsp;</td>
        <td class="style1">
            &nbsp;</td>
    </tr>
    <tr>
    <td>
        Khata Number:</td>
        <td colspan="7">
            <asp:Label ID="lblkhata" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
        Name of the Farmer:</td>
        <td colspan="7">
            <asp:Label ID="lblpnm" runat="server" Text="Label"></asp:Label>
        </td>
        
    </tr>
    <tr>
    <td>
        Father/Husband:</td>
        <td colspan="7">
            <asp:Label ID="lblpfnm" runat="server" Text="Label"></asp:Label>
        </td>
        
    </tr>
    <tr>
    <td>
        Mandal:</td>
        <td colspan="7">CHERIYAL</td>
        
    </tr>
    <tr>
    <td>
        Village:</td>
        <td colspan="7">&nbsp;</td>
        
    </tr>
    <tr>
    <td>
        Caste:</td>
        <td colspan="7">&nbsp;</td>
       
    </tr>
    <tr>
    <td colspan="8">
        Total Area Recommended (in Acres)</td>
    </tr>
 
        <table align="center" border="1">
            <tr>
                <td>
                    Sl.No</td>
                <td>
                    Name of the Crop</td>
                <td>
                    Area(Acres)</td>
                <td>
                    Quantity(in Kgs)</td>
                <tr>
                    <td>
                        1</td>
                    <td>
                        <span style="color: rgb(0, 0, 0); font-family: &quot;Times New Roman&quot;; font-size: medium; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 1; word-spacing: 0px; -webkit-text-stroke-width: 0px; display: inline !important; float: none; background-color: rgb(255, 255, 255);">
                        ప్రత్తి</span></td>
                    <td>
                        2</td>
                    <td>
                        50</td>
                </tr>
                <tr>
                    <td>
                        2</td>
                    <td>
                        వరి</td>
                    <td>
                        3</td>
                    <td>
                        20</td>
                </tr>
            </tr>
            <tr align="center">
               <td colspan="4">
                    <asp:Button ID="btnPrint" runat="server" OnClientClick="return PrintPanel();" 
                        Text="Print" />
                </td> 
            </tr>
        </table>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
    <tr>
    <td colspan="8" align="center">
        &nbsp;</td>
    </tr>
        <tr>
            <td align="center" colspan="8">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="8">
                &nbsp;</td>
        </tr>
    </table>
    </asp:Panel>
    </div>
    </form>
</body>
</html>
