﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MismatchVillageNameMaster_lg.aspx.cs" Inherits="MandalMaster" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/lg/SAdmin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/sFooter.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LG Directory</title>
    
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
       <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <script type="text/javascript">
        function getdate() {

            $('#txt_Date').datepicker({
                dateFormat: 'dd/mm/yy',
                maxDate: new Date(),
                changeMonth: true,
                changeYear: true,
                yearRange: "-20:+0"
            });


        }

        $(document).ready(function () {
            getdate();
            $("#btn_Save").live("click", function () {
                $("#ddl_dist_code").prop('required', true);
                $("#txtMandalCode").prop('required', true);
                $("#txtMandalName").prop('required', true);
                $("#txt_Date").prop('required', true);
                $("#rbnSy").prop('required', true);
                $("#rbnSn").prop('required', true);
            });
            $("#btn_Update").live("click", function () {

                $("#ddl_dist_code").prop('required', true);
                $("#txtMandalName").prop('required', true);
            });
        });
        history.pushState(null, null, 'MandalMaster.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'MandalMaster.aspx');
        });
        function Confirm(link) {

            if (confirm("Are you sure to delete the selected mandal?")) {

                return true;
            }
            else
                return false;


        }
       
    </script>
    <script type="text/javascript" language="javascript">
        String.prototype.startsWith = function (str) {
            return (this.indexOf(str) === 0);
        }
        function ChkValidChar() {

            var txtbx = document.getElementById("txtMandalCode").value;
            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtMandalCode").value = "";
                alert("you can not insert zero as first character");
            }
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table border="0" width="1190px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td align="center">
                    <img alt="" class="style64" src="../Images/lg_dire.jpg" />
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#55A8BD" align="left">
                    <menu:menu ID="menu1" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <table width="100%">
                        <tr>
                            <td align="left" class="userdate">
                                <img src="../Images/14.gif" />
                                <span style="color: green;">Logged As ::</span> &nbsp; <span>
                                    <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                            <td align="right" bgcolor="White">
                                <span style="color: green;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center" style="background-color: #3882a2; color: White; height: 30px;
                                font-size: larger;">
                                Village Master
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <%-- <asp:UpdatePanel ID="up1" runat="server">
                        <ContentTemplate>--%>
                    <div align="center">
                        <table align="center" width="100%">
                            <tr align="center">
                                <td class="style65">
                                    <table class="tbldata" align="center" width="80%">
                                        <tr>
                                            <td align="center" colspan="2" style="color: Red">
                                                Note:Fields marked with&nbsp;* &nbsp;are Compulsory.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 50%;">
                                                District Name: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddl_dist_code" runat="server" CssClass="style_txt_entry" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblMcode" runat="server" Visible="False"></asp:Label>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_dist_code"
                                                    ErrorMessage="Select District" ForeColor="Red" InitialValue="0" ValidationGroup="g1"></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right">
                                                Mandal Name: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddl_mandal_code" runat="server" 
                                                    CssClass="style_txt_entry" AutoPostBack="true" onselectedindexchanged="ddl_mandal_code_SelectedIndexChanged"
                                                   >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right">
                                                Village 
                                                Name(LG): <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtlgvillagename" runat="server" placeholder="Village Name LG " CssClass="style_txt_entry"
                                                    Enabled="false" ></asp:TextBox>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Village Name(Local): <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtlocalvillagename" runat="server" placeholder="Village Name Local" CssClass="style_txt_entry"
                                                    MaxLength="75"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtlocalvillagename_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txtlocalvillagename" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                    ValidChars=" ."></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                     
                                        
                                   
                                        <tr align="center">
                                            <td colspan="2">
                                                <asp:Button ID="btn_Save" ValidationGroup="g1" runat="server" Height="27px" Text="Save"
                                                    OnClick="btn_Save_Click" />
                                                <asp:Button ID="btn_Update" runat="server" Height="30px" OnClick="btn_Update_Click"
                                                    Text="Update" />
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="2">
                                                &nbsp;
                                                <asp:Label ID="lbldistrictlgcode" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblvillagecode" runat="server" Visible="False"></asp:Label>
                                                <asp:Label ID="lblvillagelgcode" runat="server" Visible="False"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr align="center">
                <td align="center">
                    <table style="width: 80%;">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="GvMandal" runat="server" AutoGenerateColumns="False"
                                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3"  Width="693px"
                                    OnRowCommand="GvMandal_RowCommand" CellSpacing="2" CssClass="Grid">
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sl.No">  <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" /></ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="District Name" >
                                            <ItemTemplate>
                                            <asp:Label ID="lbldistrictname" runat="server" Text='<%# Bind("DistrictName") %>'></asp:Label>
                                                <asp:Label ID="lblMCode" runat="server" Text='<%# Bind("MandCode") %>' Visible="false"></asp:Label>
                                                      <asp:Label ID="lbldistrictcode" runat="server" Text='<%# Bind("DistCode") %>' Visible="false"></asp:Label>
                                                       <asp:Label ID="lblvillagecode" runat="server" Text='<%# Bind("VillCode") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandal Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblmandalname" runat="server" Text='<%# Bind("SubDistrictName") %>'></asp:Label>
                                                     
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LG Village Code" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbllgvillagecode" runat="server" Text='<%# Bind("LGVillageCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Local Village Code" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbllocalvillagecode" runat="server" Text='<%# Bind("LocalVillageCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LG Village Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbllgvillagename" runat="server" Text='<%# Bind("LGVillageName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText=" Local Village Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lbllocalvillagename" runat="server" Text='<%# Bind("LocalVillageName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--  <asp:TemplateField HeaderText="Village Code (LG)" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblvillagelgcode" runat="server" Text='<%# Bind("VillCode_LG") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     
                                          <asp:TemplateField HeaderText="Village Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblvName" runat="server" Text='<%# Bind("VillName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                      <%--  <asp:TemplateField HeaderText="Effective Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbleffdate" runat="server" Text='<%# Bind("EffectiveDt") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Active">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                                <asp:HiddenField ID="hdndistcode" Value='<%# Bind("DistCode") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                         <asp:TemplateField HeaderText="Update" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return Confirm(this)"
                                                    CommandName="Dlt" Text="Delete" Visible="false"></asp:LinkButton>
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
                <td style="padding-top: 10px;">
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
