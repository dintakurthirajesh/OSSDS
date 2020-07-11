<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistMaster.aspx.cs" Inherits="Master_DistMaster" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>--%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
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
            height: 29px;
        }
        
        .style65
        {
            width: 384px;
        }
        
        .style66
        {
        }
        .style67
        {
            width: 987px;
            height: 107px;
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
                        <tr align="center">
                            <td colspan="2" bgcolor="White">
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="padding-top: 2%;">
                                <table class="tbldata" width="50%">
                                    <tr>
                                        <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;">
                                            District Master
                                        </th>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 50%;">
                                            District Code:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDcode" MaxLength="2" runat="server" placeholder="Disrtict Code"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtDcode_FilteredTextBoxExtender" FilterType="Numbers"
                                                runat="server" BehaviorID="txtDcode_FilteredTextBoxExtender" TargetControlID="txtDcode" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="style65">
                                            District Name:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDistName" runat="server" CssClass="validate[required]" placeholder="Disrtict Name"
                                                MaxLength="50" Height="25px"></asp:TextBox>
                                            <ajax:FilteredTextBoxExtender ID="txtDistName_FilteredTextBoxExtender" FilterType="UppercaseLetters, LowercaseLetters, custom"
                                                ValidChars=" " runat="server" BehaviorID="txtDistName_FilteredTextBoxExtender"
                                                TargetControlID="txtDistName" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Button ID="btn_Save" runat="server" ValidationGroup="g1" Height="27px" Text="Save"
                                    OnClick="btn_Save_Click" />
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                &nbsp;
                            </td>
                        </tr>
                        <tr align="center">
                            <td colspan="2">
                                <asp:Button ID="btn_Update" runat="server" Height="30px" Text="Update" OnClick="btn_Update_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" DataKeyNames="DistCode" OnPageIndexChanging="GridView1_PageIndexChanging"
                                    OnRowCancelingEdit="GridView1_RowCancelling" OnRowCommand="GridView1_RowCommand"
                                    OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                    PageSize="10" Width="382px" CellSpacing="2" CssClass="Grid">
                                    <Columns>
                                        <asp:TemplateField HeaderText="District Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldcode" runat="server" Text='<%# Bind("DistCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldnm" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" Text="Edit" OnClick="lnkEdit_Click"></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return Confirm(this)"
                                                    CommandName="Dlt" Text="Delete"></asp:LinkButton>
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
