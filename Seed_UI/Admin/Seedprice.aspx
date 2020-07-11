<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seedprice.aspx.cs" Inherits="Seed_UI_Masters_Seedprice" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
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
        <table align="center" bgcolor="#DDDDEE" width="90%">
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
                                <adminmenu:menu ID="menu" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="loggedUser">
                                <img src="../images/14.gif" />
                                <span style="color: white;">Logged As ::</span> &nbsp; <span>
                                    <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                            <td align="right" class="loggedUser">
                                <span style="color: white;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" bgcolor="White">
                                <table class="tbldata" width="90%" style="padding: 2%; text-align: center;">
                                    <tr>
                                        <th colspan="8" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                            Seed Price Master
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label1" runat="server" Text="Year:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlyear" runat="server" Width="160px">
                                                <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                                <asp:ListItem Selected="True" Text="2017" Value="2017"></asp:ListItem>
                                                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlyear" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Year"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label6" runat="server" Text="Season:"></asp:Label>
                                        </td>
                                        <td align="left" style="width:100px">
                                            <asp:DropDownList ID="seasons" runat="server" Width="130px" AutoPostBack="True" 
                                                onselectedindexchanged="seasons_SelectedIndexChanged">
                                                <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                                <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label8" runat="server" Text="Company Name "></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlcomapnies" runat="server" AutoPostBack="True" 
                                                onselectedindexchanged="ddlcomapnies_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" width="7%">
                                            <asp:Label ID="Label2" runat="server" Text="Crop Name:"></asp:Label>
                                        </td>
                                        <td align="left" width="10%">
                                            <asp:DropDownList ID="ddlcropname" runat="server" Width="160px" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlcropname_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlcropname" InitialValue="Select Crop Name"
                                                runat="server" ForeColor="Red" ErrorMessage="Please Select Crop Name"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right" width="10%">
                                            <asp:Label ID="Label3" runat="server" Text="Seed Variety Name:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="seeds" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label4" runat="server" Text="Actual MRP:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtmrp" CssClass="validate[required]" placeholder="Actual Price:"
                                                runat="server"></asp:TextBox>(per qtl)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label7" runat="server" Text="Subsidy"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtsubsidy" CssClass="validate[required]" placeholder="Subsidy"
                                                runat="server" AutoPostBack="true" OnTextChanged="txtsubsidy_TextChanged"></asp:TextBox>(per
                                            qtl)
                                        </td>
                                        <td align="right" colspan="2">
                                            <asp:Label ID="Label5" runat="server" Text="Subsidized Price(Farmer Share) "></asp:Label>
                                        </td>
                                        <td align="left" colspan="2">
                                            <asp:TextBox ID="txtprice" CssClass="validate[required]" placeholder="Subsidized Price"
                                                ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>(per qtl)
                                        </td>
                                    </tr>
                                </table>
                </td>
            </tr>
            </table> </td> </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="btnSave" runat="server" ValidationGroup="g1" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnUpdate" Visible="false" runat="server" Text="Update" OnClick="btnUpdate_Click1" />
                </td>
            </tr>
            <%-- <tr>
                <td colspan="2" align="center">
                    <table style="text-align: center; width: 20%;">
                        <tr>
                            <td>
                                <asp:ValidationSummary ID="valSum" ForeColor="Red" ValidationGroup="g1" DisplayMode="BulletList"
                                    ShowSummary="true" EnableClientScript="true" HeaderText="Reqiuered Fields:" runat="server" />
                                <asp:Label ID="Label6" AssociatedControlID="ddlcropname" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>--%>
            <tr>
                <td colspan="2" align="center" bgcolor="White">
                    <asp:GridView ID="grdSeedPrice" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84"
                        BorderStyle="None" BorderWidth="1px" PageSize="10" CssClass="Grid" OnRowCommand="GridView1_RowCommand"
                        runat="server" Width="90%">
                        <Columns>
                            <asp:TemplateField HeaderText="SlNo">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Year" HeaderText="Year" />
                            <asp:BoundField DataField="season" HeaderText="Season" />
                            <asp:BoundField DataField="CropCode" HeaderText="Crop Code" />
                            <asp:BoundField DataField="CropName" HeaderText="Crop Name" />
                            <asp:BoundField DataField="CropVcode" HeaderText="CropVCode" />
                            <asp:BoundField DataField="CropVnmTel" HeaderText="Seed Variety Name" />
                            <asp:BoundField DataField="Actual_MRP" HeaderText="Actual Price(Per Qtl)" />
                            <asp:BoundField DataField="Subsidy_Amount" HeaderText="Subsidy Amount (Per Qtl)" />
                            <asp:BoundField DataField="Subsidized_Price" HeaderText="Farmer Share(Per Qtl)" />
                            <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt" OnClientClick="return Confirm(this)"
                                        Text="Delete"></asp:LinkButton>
                                    <asp:HiddenField ID="hdncropcode" Value='<%# Eval("CropVCode") %>' runat="server" />
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
