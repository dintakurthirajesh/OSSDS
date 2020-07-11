<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StockTransfer.aspx.cs" Inherits="MAO_StockTransfer" %>

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
                            <th colspan="4" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                Stock Transfer
                            </th>
                        </tr>
                        <tr>
                            <td align="center">
                                <table align="center" cellpadding="3" cellspacing="1" width="90%">
                                    <tr align="center">
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_label">
                                            <asp:DropDownList ID="ddlyear" runat="server" Width="160px">
                                                <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                                <asp:ListItem Selected="True" Text="2017" Value="2017"></asp:ListItem>
                                                <%-- <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>--%>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlyear" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Year"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label6" runat="server" Text="Season:"></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_label">
                                            <asp:DropDownList ID="seasons" runat="server" Width="160px">
                                                <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Kharif" Selected="True" Value="Kharif"></asp:ListItem>
                                                <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label2" runat="server" Text="Crop:"></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_label">
                                            <asp:DropDownList ID="ddlcrop" runat="server" Width="160px" AutoPostBack="True" OnSelectedIndexChanged="ddlcrop_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Crop"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" class="style_td_label">
                                            <asp:Label ID="Label3" runat="server" Text="Crop Vareity: "></asp:Label>
                                        </td>
                                        <td align="left" class="style_td_label">
                                            <asp:DropDownList ID="ddlvareity" runat="server" Width="160px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlvareity" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Crop Vareity"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="8">
                                            <asp:Button ID="Button1" runat="server" Text="GetData" OnClick="Button1_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
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
                                        <asp:BoundField DataField="stock_available" HeaderText="Stock Left(in qtls)" />
                                        <asp:BoundField DataField="bagsAvialble" HeaderText="No.of Bags Left" />
                                        <asp:BoundField DataField="weight_of_bag" HeaderText="Weight of each Bag" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="tsp" runat="server" Text="Transfer to Another Salepoint" 
                                                CommandArgument='<%# Eval("spcode")+ "," +Eval("SalePtName")+ "," +Eval("crop")+ "," +Eval("stock_available")+ "," +Eval("bagsAvialble")+ "," +Eval("weight_of_bag") %>'
                                                    OnClick="Trnsfer_to_SP"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="tmndl" runat="server" Text="Transfer to Mandal" 
                                                CommandArgument='<%# Eval("spcode")+ "," +Eval("SalePtName")+ "," +Eval("crop")+ "," +Eval("stock_available")+ "," +Eval("bagsAvialble")+ "," +Eval("weight_of_bag") %>'
                                                    OnClick="Trnsfer_to_Mand"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
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
