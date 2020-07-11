<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CropMaster.aspx.cs" Inherits="SuperAdmin_CropMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/SuperAdmin/SuperAdmin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <title></title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Confirm(link) {

            if (confirm("Are you sure to delete the row?")) {

                return true;
            }
            else
                return false;


        }
        $(document).ready(function () {

            // $("#form1").validationEngine('attach', { promptPosition: "topRight" });


            $("#btn_Save").live('click', function () {

                $("input").prop('required', true);

            });
            $("#btn_Update").live('click', function () {

                $("input").prop('required', true);

            });

        });
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
                            <td colspan="2" align="center" style="padding-top: 2%;" bgcolor="White">
                                <table class="tbldata" width="90%">
                                    <tr>
                                        <th colspan="8" style="color: Red; background-color: #88d8e0; height: 35px;">
                                            Crop Master
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            SlNo.
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtslno" MaxLength="3" Width="35" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Crop Name:
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtCropName" runat="server" placeholder="Crop Name" MaxLength="50"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtCropName_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters, custom"
                                                ValidChars=" " runat="server" BehaviorID="txtCropName_FilteredTextBoxExtender"
                                                TargetControlID="txtCropName" />
                                            <asp:Label ID="lblcpcode" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td align="right">
                                            Var/Hybrid
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txttype" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Seed Rate Recommended Kg/acre
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtseedrate" runat="server" placeholder="Seed Rate per Acre" MaxLength="50"></asp:TextBox>
                                            (in kgs)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="2">
                                            Area to be considered (In acres)
                                        </td>
                                        <td align="left">
                                            
                                            <asp:TextBox ID="txtArea" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right">
                                            Packing size in Kgs
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtpcksize" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right" colspan="2">
                                            Quantity to be issued according to packing Kgs./acre
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="txtqty" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" bgcolor="White">
                                <asp:Button ID="btn_Update" runat="server" Height="30px" Text="Update" OnClick="btn_Update_Click" />
                                <asp:Button ID="btn_Save" runat="server" Height="27px" Text="Save" OnClick="btn_Save_Click" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2" bgcolor="White">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" DataKeyNames="CropCode" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    OnRowCancelingEdit="GridView1_RowCancelling" OnRowCommand="GridView1_RowCommand"
                                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    PageSize="10" Width="80%" CellSpacing="2" CssClass="Grid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl.No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblslno" runat="server" Text='<%# Bind("Slno") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Crop Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcropcode" Visible="false" runat="server" Text='<%# Bind("CropCode") %>'></asp:Label>
                                                <asp:Label ID="lblCpnm" runat="server" Text='<%# Bind("CropName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Var/Hybrid">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltype" runat="server" Text='<%# Bind("CropType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Seed Rate Recommended Kg/acre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblseedrate" runat="server" Text='<%# Bind("SeedRate") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Area to be considered (In acres)">
                                            <ItemTemplate>
                                                <asp:Label ID="lblarea" runat="server" Text='<%# Bind("No_of_Acres") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Quantity to be issued according to packing Kgs/acre">
                                            <ItemTemplate>
                                                <asp:Label ID="lblqty" runat="server" Text='<%# Bind("Quantity_in_Kgs") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Packing size in Kgs">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpcksize" runat="server" Text='<%# Bind("packing_size") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
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
