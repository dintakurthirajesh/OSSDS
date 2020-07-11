<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheckAdhar.aspx.cs" Inherits="MAO_CheckAdhar" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/MAO/MAOMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Distrbution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
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
        .style64
        {
            color: #000066;
        }
    </style>
    <script type="text/javascript">
        function moveOnMax(field, nextFieldID) {
            if (field.value.length >= field.maxLength) {
                document.getElementById(nextFieldID).focus();
            }
        }
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
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table class="tbldata" style="width: 90%;">
                        <tr>
                            <th colspan="4" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                Check Adhar
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table align="center">
                                    <tr>
                                        <td>
                                            Enter Adhar Number
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAdhar1" MaxLength="4" onkeyup="moveOnMax(this, 'txtAdhar2')"
                                                runat="server" Width="30"></asp:TextBox>
                                            <asp:TextBox ID="txtAdhar2" MaxLength="4" onkeyup="moveOnMax(this, 'txtAdhar3')"
                                                runat="server" Width="30"></asp:TextBox>
                                            <asp:TextBox ID="txtAdhar3" MaxLength="4" runat="server" Width="30"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            <asp:GridView ID="GVDetails" runat="server" AllowPaging="True" CellPadding="3" BackColor="#DEBA84"
                                                AutoGenerateColumns="false" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                                PageSize="15" Width="600px" CssClass="Grid" 
                                                onpageindexchanging="GVDetails_PageIndexChanging">
                                                <RowStyle BackColor="#FFF7E7" BorderStyle="Solid" Font-Size="Small" ForeColor="#8C4510" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SlNo">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="farmer" HeaderText="Farmer Name" />
                                                    <asp:TemplateField HeaderText="Farmer Adderess">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Eval("DistName") %>'></asp:Label>/
                                                            <asp:Label ID="l2" runat="server" Text='<%# Eval("MandName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Khata Number">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("khata") %>'></asp:Label>
                                                            <asp:Label ID="l" runat="server" Text='<%# Eval("KhataNo") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="SurveyNo" HeaderText="Survey Numbers" />
                                                    <asp:BoundField DataField="spdist" HeaderText="Sale Point District" />
                                                    <asp:TemplateField HeaderText="sale Point Details">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Eval("spdist") %>'></asp:Label>/
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("spmand") %>'></asp:Label>/
                                                            <asp:Label ID="l4" runat="server" Text='<%# Eval("SalePtName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="permit_code" HeaderText="Permit Number" />
                                                    <asp:BoundField DataField="Seed_Permit_IssuedDt" HeaderText="Permit Issued Date" />
                                                    <asp:BoundField DataField="crop" HeaderText="Crop Taken" />
                                                    <asp:BoundField DataField="SeedQty_Issued" HeaderText="No of Bags" />
                                                    <asp:BoundField DataField="no_of_bags_purchased" HeaderText="No.of Bags Purchased" />
                                                    <asp:BoundField DataField="issued_date" HeaderText="Purchased Date" />
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
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
