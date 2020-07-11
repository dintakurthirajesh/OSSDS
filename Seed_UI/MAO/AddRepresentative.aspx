<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddRepresentative.aspx.cs"
    Inherits="MAO_AddRepresentative" %>

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
                <td colspan="2" align="center" bgcolor="White">
                    <table class="tbldata" style="width: 80%;">
                        <tr>
                            <th colspan="2" style="color: Red; background-color: #88d8e0; font-size: large; height: 35px;">
                                Add Representative to Generate Permit Slip
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                Name Of the Person
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtnm" runat="server"></asp:TextBox>
                                <asp:Label ID="lblrepcode" runat="server" Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                Designation
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtdesig" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                Mobile Number
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtmobile" MaxLength="10" runat="server"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtmobile_filter" BehaviorID="txtmobile_filter"
                                    FilterType="Numbers" runat="server" TargetControlID="txtmobile" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                Attached Sale Point
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlsps" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                UserName
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtusernm" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                Active
                            </td>
                            <td align="left">
                                <asp:RadioButtonList ID="rblActive" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="No" Value="0"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btn_save" runat="server" Text="Add" OnClick="Button1_Click" />
                                <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="Update_Click" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center" bgcolor="White">
                    <asp:GridView ID="RepGrid" runat="server" AllowPaging="True" CellPadding="3" BackColor="#DEBA84"
                        OnRowCommand="RepGrid_RowCommand" AutoGenerateColumns="false" BorderColor="#DEBA84"
                        BorderStyle="None" BorderWidth="1px" PageSize="15" Width="600px" CssClass="Grid"
                        OnPageIndexChanging="RepGrid_PageIndexChanging">
                        <RowStyle BackColor="#FFF7E7" BorderStyle="Solid" Font-Size="Small" ForeColor="#8C4510" />
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                            <asp:BoundField DataField="Designation" HeaderText="Designation" />
                            <asp:BoundField DataField="mobile" HeaderText="Mobile" />
                            <asp:TemplateField HeaderText="UserName">
                                <ItemTemplate>
                                    <asp:Label ID="lblrepid" runat="server" Visible="false" Text='<%# Bind("Rep_Id") %>'></asp:Label>
                                    <asp:Label ID="lblusernm" runat="server" Text='<%# Bind("UserName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sale Point">
                                <ItemTemplate>
                                    <asp:Label ID="lblspcode" runat="server" Visible="false" Text='<%# Bind("spcode") %>'></asp:Label>
                                    <asp:Label ID="lblsp" runat="server" Text='<%# Bind("SalePtName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Active">
                                <ItemTemplate>
                                    <asp:Label ID="lblActive" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return GetSelectedRow(this)"
                                        CommandName="Dlt" Text="Delete"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <RowStyle HorizontalAlign="Center" />
                        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" Font-Size="Small" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
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
