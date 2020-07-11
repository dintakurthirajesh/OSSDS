<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistMaster_lg.aspx.cs" Inherits="DistMaster" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/lg/SAdmin.ascx" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/sFooter.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LG Directory</title>
   
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

                $("#txtDistCode").prop('required', true);
                $("#txtDistName").prop('required', true);
                $("#txt_Date").prop('required', true);
                $("#rbnSy").prop('required', true);
                $("#rbnSn").prop('required', true);
            });
            $("#btn_Update").live("click", function () {

                $("#txtDistName").prop('required', true);

            });
        });
        history.pushState(null, null, 'DistMaster.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'DistMaster.aspx');
        });
        function Confirm(link) {

            if (confirm("Are you sure to delete the selected district?")) {

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

            var txtbx = document.getElementById("txtDistCode").value;

            if (txtbx.startsWith("0")) // true
            {
                document.getElementById("txtDistCode").value = "";
                alert("you can not insert zero as first character");
            }
        }
        function chlength() {
            var str = document.getElementById("txtDistCode");
            var txtlen = str.value.length;
            if (txtlen > 5) {
                //red
                txtDistCode.style.backgroundColor = "#FF0000";
            }
            else {
                //green
                txtDistCode.style.backgroundColor = "#00FF00";
            }

        }
    </script>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
      <style type="text/css">
       .gridview{
    background-color:#fff;
   
   padding:2px;
   margin:2% auto;
   
   
}
.gridview a{
  margin:auto 1%;
    border-radius:50%;
      background-color:#444;
      padding:5px 10px 5px 10px;
      color:#fff;
      text-decoration:none;
      -o-box-shadow:1px 1px 1px #111;
      -moz-box-shadow:1px 1px 1px #111;
      -webkit-box-shadow:1px 1px 1px #111;
      box-shadow:1px 1px 1px #111;
     
}
.gridview a:hover{
    background-color:#1e8d12;
    color:#fff;
}
.gridview span{
    background-color:#ae2676;
    color:#fff;
     -o-box-shadow:1px 1px 1px #111;
      -moz-box-shadow:1px 1px 1px #111;
      -webkit-box-shadow:1px 1px 1px #111;
      box-shadow:1px 1px 1px #111;

    border-radius:50%;
    padding:5px 10px 5px 10px;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <table border="0" width="1190px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td align="center">
                    <img alt="" src="../Images/lg_dire.jpg" />
                </td>
            </tr>
            <tr>
                <td colspan="2" bgcolor="#55A8BD" align="left">
                    <menu:menu ID="menu" runat="server" />
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
                                District Master
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
                        <table align="center" width="80%">
                            <tr>
                                <td style="background-color" class="style65">
                                    <table class="tbldata" align="center" width="100%">
                                        <tr>
                                            <td colspan="2" align="center" style="color: Red">
                                                Note:Fields marked with&nbsp;* &nbsp;are Compulsory.
                                            </td>
                                        </tr>
                                         <tr>
                                            <td align="right" style="width: 50%;">
                                               Select State: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlstate" CssClass="style_txt_entry"  runat="server" 
                                                    AutoPostBack="True" onselectedindexchanged="ddlstate_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                  <%--      <tr>
                                            <td align="right" style="width: 50%;">
                                                District Code: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDistCode" runat="server" CssClass="style_txt_entry" Font-Size="1.0em"
                                                    Height="25px" MaxLength="4" placeholder="District Code" OnTextChanged="txtDistCode_TextChanged"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtDistCode_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtDistCode"></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td align="right" style="width: 50%;">
                                                District 
                                                LG Code:</td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDistCodelg" runat="server" CssClass="style_txt_entry" Font-Size="1.0em"
                                                    Height="25px" MaxLength="4" placeholder="District LG Code" 
                                                   ></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtDistCodelg_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" FilterType="Numbers" TargetControlID="txtDistCodelg"></ajax:FilteredTextBoxExtender>
                                                <asp:Label ID="lblDcode" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                District Name:<span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtDistName" runat="server" placeholder="District Name" Font-Size="1.0em"
                                                    Height="25px" CssClass="style_txt_entry" MaxLength="50"></asp:TextBox>
                                                <ajax:FilteredTextBoxExtender ID="txtDistName_FilteredTextBoxExtender" runat="server"
                                                    Enabled="True" TargetControlID="txtDistName" FilterType="Custom,Numbers,UppercaseLetters,lowercaseLetters"
                                                    ValidChars=" ."></ajax:FilteredTextBoxExtender>
                                            </td>
                                        </tr>
                                       <%-- <tr>
                                            <td align="right">
                                                Effective&nbsp;Date:&nbsp;<span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txt_Date" placeholder="Enter date" runat="server" CssClass="style_txt_entry"
                                                    Font-Size="1.0em" Height="25px" AutoCompleteType="Disabled"></asp:TextBox>
                                            </td>
                                        </tr>--%>
                                 <%--       <tr>
                                            <td align="right">
                                                Active: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:RadioButton ID="rbnSy" runat="server" AutoPostBack="True" GroupName="ActiveSt"
                                                    Text="Yes" Checked="true" />
                                                <asp:RadioButton ID="rbnSn" runat="server" AutoPostBack="true" GroupName="ActiveSt"
                                                    Text="No" />
                                            </td>
                                        </tr>--%>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
            <tr>
                <td class="style79" align="center" colspan="2">
                    <asp:Button ID="btn_Save" runat="server" Height="29px" OnClick="btn_Save_Click" Text="Save" />
                    <asp:Button ID="btn_Update" runat="server" Height="30px" OnClick="btn_Update_Click"
                        Text="Update" />
                    <asp:Button ID="btn_clear" runat="server" Height="30px" 
                        Text="Clear" onclick="btn_clear_Click" />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <table style="width: 80%;">
                        <tr>
                            <td align="center">
                                <asp:GridView ID="GvDistricts" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                    CssClass="Grid" OnPageIndexChanging="GvDistricts_PageIndexChanging" OnRowCommand="GvDistricts_RowCommand"
                                    PageSize="35" Width="565px">
                                    <Columns>  <asp:TemplateField HeaderText="Sl.No">  <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" /></ItemTemplate>
                                    </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldcode" runat="server" Text='<%# Bind("DistCode") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="District LG Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lbllgdcode" runat="server" Text='<%# Bind("DistCode_Lg") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="District Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lbldnm" runat="server" Text='<%# Bind("DistName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Active">
                                            <ItemTemplate>
                                                <asp:Label ID="lblstatus" runat="server" Text='<%# Bind("Active") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Effective Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lbleffdate" runat="server" Text='<%# Bind("EffectiveDt") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update/Delete" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edt" Text="Edit"></asp:LinkButton>
                                                <asp:LinkButton ID="btnDelete" runat="server" OnClientClick="return Confirm(this)"
                                                    CommandName="Dlt" Text="Delete"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <pagerstyle cssclass="gridview">

</pagerstyle>
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
