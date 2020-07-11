<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeedAllotment.aspx.cs" Inherits="DAO_SeedAllotment" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/DAO/DAOMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
        function Confirm(link) {
            if (confirm("Are you sure to delete the row?")) {
                return true;
            }
            else
                return false;
        }      
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table align="center" width="90%">
            <tr>
                <td align="center">
                    <table align="center" cellpadding="3" cellspacing="1" width="100%">
                        <tr align="center">
                            <th colspan="2">
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
                                <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                            <td align="right" class="loggedUser">
                                <span style="color: white;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <table class="tbldata" style="width: 90%;">
                                    <tr>
                                        <th colspan="4" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                            Seed Allotment
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table class="tbldata" width="90%">
                                                <tr>
                                                    <td align="right">
                                                        Crop
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lblCrop" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <%--<td align="right" >
                                                        Crop Variety
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lblcv" runat="server" Text="Label"></asp:Label>
                                                    </td>--%>
                                                    <td align="right">
                                                        Total Qty
                                                    </td>
                                                    <td align="left" class="style1">
                                                        <asp:Label ID="lblqty" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;
                                                        <span class="style64">Qtls </span>
                                                        <asp:Label ID="lblaid" runat="server" Visible="false"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <table class="tbldata" width="90%">
                                                <tr>
                                                    <td>
                                                        Select Mandal
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMand" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        Qty Allotted
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                                                        &nbsp; Qtls
                                                        <ajax:FilteredTextBoxExtender ID="txtqty_filter" BehaviorID="txtqty_filter" FilterType="numbers"
                                                            runat="server" TargetControlID="txtqty" />
                                                    </td>
                                                    <td>
                                                        Qty Available
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblqtyAvail" runat="server"></asp:Label>
                                                        &nbsp;&nbsp; Qtls
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Button1_Click" />
                                            <asp:Button ID="btnUpdate" Visible="false" runat="server" Text="Update" OnClick="btnUpdate_Click1" />
                                            <asp:Label ID="lblspstkid" runat="server" Visible="false"></asp:Label>
                                            <asp:Label ID="lbloldqty" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:GridView ID="grdSeed" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84"
                                                BorderStyle="None" BorderWidth="1px" PageSize="10" CssClass="Grid" OnRowCommand="GridView1_RowCommand"
                                                runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="SlNo">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex+1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="year" HeaderText="Year" />
                                                    <asp:BoundField DataField="season" HeaderText="Season" />
                                                    <%--  <asp:TemplateField HeaderText="Agency">
                                            <ItemTemplate>
                                                <asp:Label ID="lblagency" runat="server" Text='<%# Eval("AgencyName")%>'></asp:Label>
                                                <asp:Label ID="lblagencycode" runat="server" Visible="false" Text='<%# Eval("agency_code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Crop">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblcrop" runat="server" Text='<%# Eval("cropNm")%>'></asp:Label>
                                                            <asp:Label ID="lblcv" runat="server" Visible="false" Text='<%# Eval("cropv")%>'></asp:Label>
                                                            <asp:Label ID="lblcropcode" runat="server" Visible="false" Text='<%# Eval("crop")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Mandal">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmandal" runat="server" Text='<%# Eval("MandName")%>'></asp:Label>
                                                            <asp:Label ID="lblallotid" runat="server" Visible="false" Text='<%# Eval("allotment_id")%>'></asp:Label>
                                                            <asp:Label ID="lblspstkid" runat="server" Visible="false" Text='<%# Eval("sp_stock_id")%>'></asp:Label>
                                                            <asp:Label ID="lblmandcode" runat="server" Visible="false" Text='<%# Eval("mandal")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity(in Qtls)" />
                                                    <asp:BoundField DataField="alloted_dt" HeaderText="Alloted On" />
                                                    <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt" OnClientClick="return Confirm(this)"
                                                                Text="Delete"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <RowStyle HorizontalAlign="Center" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#A55129" BorderStyle="Solid" Font-Bold="True" Font-Size="Small"
                                                    ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView>
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
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
