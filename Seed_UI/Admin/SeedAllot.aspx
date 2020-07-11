<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SeedAllot.aspx.cs" Inherits="Admin_SeedAllot" %>

<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Distribution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
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
    <style type="text/css">
        .auto-style2
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
        }
        .myGridStyle
        {
            width: 64%;
        }
        
        .myGridStyle
        {
            border-collapse: collapse;
            font-size: 17px;
        }
        
        #txtbros
        {
            width: 82px;
            height: 19px;
        }
        .style63
        {
            font-size: large;
        }
    </style>
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
                                <img src="../images/14.gif" alt="" />
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
                                <table class="tbldata" style="width: 90%;">
                                    <tr>
                                        <th colspan="6" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                            Seed Allotment
                                        </th>
                                    </tr>
                                    <tr>
                                        <td style="width:20%" align="right">
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
                                        <td align="left">
                                            <asp:DropDownList ID="seasons" runat="server" Width="160px">
                                                <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                                <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                                ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Crop Name:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlcropname" runat="server" Width="160px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddlcropname_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlcropname" InitialValue="Select Crop Name"
                                                runat="server" ForeColor="Red" ErrorMessage="Please Select Crop Name"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="Label3" runat="server" Text="Seed Variety Name:"></asp:Label>
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="seeds" runat="server" >
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Agency
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddlAgency" runat="server">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" EnableClientScript="true"
                                                ValidationGroup="g1" ControlToValidate="ddlAgency" InitialValue="Select Crop Name"
                                                runat="server" ForeColor="Red" ErrorMessage="Please Select Agency"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="right">
                                            District
                                        </td>
                                        <td align="left">
                                            <asp:DropDownList ID="ddl_dist_code" runat="server" Width="160px">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="g1" runat="server"
                                                ControlToValidate="ddl_dist_code" ErrorMessage="Select District" InitialValue="Select District"
                                                ForeColor="Red"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                       
                                        <td>
                                           
                                        </td>
                                        <td align="right">
                                            Seed Alotted
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtalloted_qty" runat="server"></asp:TextBox>(Qtls)
                                        </td>
                                       <td>
                                           <asp:Label ID="lblaid" runat="server" Visible="false"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr bgcolor="White">
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="Button1_Click" />
                                <asp:Button ID="btnUpdate" Visible="false" runat="server" Text="Update" OnClick="btnUpdate_Click1" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" bgcolor="White">
                                <asp:GridView ID="grdSeed" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84"
                                    Width="90%" BorderStyle="None" BorderWidth="1px" PageSize="10" CssClass="Grid"
                                    OnRowCommand="GridView1_RowCommand" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="year" HeaderText="Year" />
                                        <asp:BoundField DataField="season" HeaderText="Season" />
                                        <asp:TemplateField HeaderText="Agency">
                                            <ItemTemplate>
                                                <asp:Label ID="lblagency" runat="server" Text='<%# Eval("AgencyName")%>'></asp:Label>
                                                <asp:Label ID="lblagencycode" runat="server" Visible="false" Text='<%# Eval("agency_code")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Crop">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcrop" runat="server" Text='<%# Eval("cropNm")%>'></asp:Label>
                                                <asp:Label ID="lblcv" runat="server" Visible="false" Text='<%# Eval("cropv")%>'></asp:Label>
                                                <asp:Label ID="lblcropcode" runat="server" Visible="false" Text='<%# Eval("crop")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldist" runat="server" Text='<%# Eval("DistName")%>'></asp:Label>
                                                <asp:Label ID="lblallotid" runat="server" Visible="false" Text='<%# Eval("allotment_id")%>'></asp:Label>
                                                <asp:Label ID="lbldistcode" runat="server" Visible="false" Text='<%# Eval("district")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="alloted_qty" HeaderText="Alloted Quantity(in Qtls)" />
                                        <asp:BoundField DataField="alloted_dt" HeaderText="Alloted On" />
                                        <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <%--<% If(Eval("freeze").ToString()== "NULL") { %>--%>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandName="Dlt" OnClientClick="return Confirm(this)"
                                                    Text="Delete"></asp:LinkButton>
                                                <%--     <%} else %> Freezed <% End If%>--%>
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
    </div>
    </form>
</body>
</html>
