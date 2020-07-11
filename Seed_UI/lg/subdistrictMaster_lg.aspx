<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subdistrictMaster_lg.aspx.cs" Inherits="MandalMaster" %>

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
                                Sub District Master
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
                                        
                                      <%--  <tr>
                                            <td align="right">
                                                Mandal Code: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMandalCode" runat="server" placeholder="Mandal Code" CssClass="style_txt_entry"
                                                    MaxLength="3" OnTextChanged="txtMandalCode_TextChanged"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtMandalCode_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtMandalCode"></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>--%>
                                        
                                        <tr>
                                            <td align="right">
                                                Sub District 
                                                LG Code: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMandallgCode" runat="server" placeholder="Sub District LG Code" CssClass="style_txt_entry"
                                                    MaxLength="6" ></asp:TextBox>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Sub District Name: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMandalName" runat="server" placeholder="Sub District Name" CssClass="style_txt_entry"
                                                    MaxLength="75"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtMandalName_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txtMandalName" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                    ValidChars=" ."></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td align="right">
                                                Mandal LGcode: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtMandalLGCode" runat="server" placeholder="Mandal LGCode" CssClass="style_txt_entry"
                                                    MaxLength="6"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtMandalCode"></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Mandal (New/Old): <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlMandalType" runat="server" CssClass="style_txt_entry">
                                                <asp:ListItem Value="O" Text="Old"></asp:ListItem>
                                                <asp:ListItem Value="N" Text="New"></asp:ListItem>                                                
                                                </asp:DropDownList>
                                            </td>
                                        </tr>--%>
                                        
                                   <%--     <tr>
                                            <td align="right">
                                                Effective Date: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txt_Date" runat="server" placeholder="Enter date" CssClass="style_txt_entry"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                Active: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButton ID="rbnSy" runat="server" AutoPostBack="True" GroupName="ActiveSt"
                                                    Text="Yes" Checked="true"/>
                                                <asp:RadioButton ID="rbnSn" runat="server" AutoPostBack="true" GroupName="ActiveSt"
                                                    Text="No" />
                                            </td>
                                        </tr>--%>
                                        <tr align="center">
                                            <td colspan="2">
                                                <asp:Button ID="btn_Save" ValidationGroup="g1" runat="server" Height="27px" Text="Save"
                                                    OnClick="btn_Save_Click" Visible="False" />
                                                <asp:Button ID="btn_Update" runat="server" Height="30px" OnClick="btn_Update_Click"
                                                    Text="Update" />
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="2">
                                                &nbsp;
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
                                    CellPadding="3"  Width="590px"
                                    OnRowCommand="GvMandal_RowCommand" CellSpacing="2" CssClass="Grid">
                                    <Columns>
                                     <asp:TemplateField HeaderText="Sl.No">  <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" /></ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub District Code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMCode" runat="server" Text='<%# Bind("MandCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub District Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMName" runat="server" Text='<%# Bind("MandName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub District LGCode">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMLGCode" runat="server" Text='<%# Bind("sub_distcode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    
                                 
                                         <asp:TemplateField HeaderText="Update" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return Confirm(this)" Visible="false"
                                                    CommandName="Dlt" Text="Delete"></asp:LinkButton>
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
