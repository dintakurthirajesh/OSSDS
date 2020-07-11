<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SPtoSPTrnsfer.aspx.cs" Inherits="MAO_SPtoSPTrnsfer" %>

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
    </style>
    <script type="text/javascript">
        $(function () {
            $("#btnSave").live('click', function () {
                $("input").prop('required', true);
            });
            $("#btnUpdate").live('click', function () {
                $("input").prop('required', true);
            });
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
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table class="tbldata" style="width: 90%;">
                        <tr>
                            <th style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                SalePoint to SalePoint Stock Transfer
                            </th>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center">
                                <table width="90%">
                                    <tr>
                                        <td colspan="4" align="left" style="color: Blue; background-color: #3399FF; height: 25px;"
                                            class="style1">
                                            From
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Salepoint:<asp:Label ID="lblspnm" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            Crop:<asp:Label ID="lblcrop" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            Available Quantity:<asp:Label ID="lblqty" runat="server"></asp:Label>
                                            &nbsp;(in qtls)
                                        </td>
                                        <td>
                                            No.of Bags:<asp:Label ID="lblnob" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="left" style="color: Blue; background-color: #3399FF; height: 25px;"
                                            class="style1">
                                            To
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Select Sale Point:
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlsp" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            No.of Bags to Transfer:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtqty" AutoPostBack="true" runat="server" OnTextChanged="txtqty_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="Button1" runat="server" Text="Transfer" OnClick="Button1_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center">
                                <asp:GridView ID="StkGrid" runat="server" BackColor="#DEBA84" AutoGenerateColumns="false"
                                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" PageSize="5" CssClass="Grid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SalePtName" HeaderText="Salepoint Name" />
                                        <asp:BoundField DataField="crop" HeaderText="Crop" />
                                        <%-- <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Qty(in qtls)" />
                                        <asp:BoundField DataField="alloted_left" HeaderText="Allotment left Qty(in qtls)" />
                                        --%>
                                        <asp:BoundField DataField="stock_available" HeaderText="Stock Left(in qtls)" />
                                        <asp:BoundField DataField="bagsAvialble" HeaderText="No.of Bags Left" />
                                      
                                      
                                    </Columns>
                                </asp:GridView>
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
