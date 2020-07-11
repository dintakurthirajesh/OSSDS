<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddSeedRequirement.aspx.cs"
    Inherits="Admin_AddSeedRequirement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
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
            //$("#form1").validationEngine();
            $("#btnSave").live('click', function () {
                $("input").prop('required', true);
                //                var valid = $("#form1").validationEngine('validate');
                //                var vars = $("#form1").serialize();

                //                if (valid == true) {

                //                    return true;

                //                } else {
                //                    $("#form1").validationEngine();
                //                    return false;
                //                }
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
        //        function NumberOnly() {
        //            var AsciiValue = event.keyCode
        //            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
        //                event.returnValue = true;
        //            else
        //                event.returnValue = false;
        //        }
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
                            <td colspan="2" align="center">
                                <table class="tbldata" style="width: 80%;">
                                    <tr>
                                        <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;">
                                            Seed Requirement Master
                                        </th>
                                    </tr>
                                    <tr>
                                        <td bgcolor="White" align="center" colspan="2">
                                            <table width="80%">
                                                <tr>
                                                    <td align="right" class="style_td_label">
                                                        <asp:Label ID="Label2" runat="server" Text="Crop Name:"></asp:Label>
                                                    </td>
                                                    <td align="left" class="style_td_label">
                                                        <asp:DropDownList ID="ddlcrop" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcropname_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                                            ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="Select Crop Name"
                                                            runat="server" ForeColor="Red" ErrorMessage="Please Select Crop Name"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style_td_label">
                                                        <asp:Label ID="Label3" runat="server" Text="Seed Variety Name:"></asp:Label>
                                                    </td>
                                                    <td align="left" class="style_td_label">
                                                        <asp:DropDownList ID="seeds" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style_td_label">
                                                        <asp:Label ID="Label1" runat="server" Text="Seed Requirement"></asp:Label>
                                                    </td>
                                                    <td align="left" class="style_td_label">
                                                        <asp:TextBox ID="requrmnt" runat="server"></asp:TextBox>
                                                        (kg/acre)
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <table width="990px">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button ID="btnSave" runat="server" ValidationGroup="g1" Text="Save" OnClick="btnSave_Click" />
                                <asp:Button ID="btnUpdate" Visible="false" runat="server" Text="Update" OnClick="btnUpdate_Click1" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:GridView ID="grdSeedPrice" BackColor="#DEBA84" AutoGenerateColumns="false" BorderColor="#DEBA84"
                                    BorderStyle="None" BorderWidth="1px" PageSize="10" CssClass="Grid" OnRowCommand="GridView1_RowCommand"
                                    runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="SlNo">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- <asp:BoundField DataField="Year" HeaderText="Year" />
                                <asp:BoundField DataField="season" HeaderText="Season" />
                                <asp:BoundField DataField="CropName_Tel" HeaderText="Crop Name" />
                                <asp:BoundField DataField="CropVcode" HeaderText="CropVCode" />
                                <asp:BoundField DataField="CropVnmTel" HeaderText="Seed Variety Name" />
                                <asp:BoundField DataField="Actual_MRP" HeaderText="Actual Price" />
                                <asp:BoundField DataField="Subsidized_Price" HeaderText="Subsidized Price" />--%>
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
