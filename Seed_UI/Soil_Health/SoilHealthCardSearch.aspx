<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoilHealthCardSearch.aspx.cs" Inherits="SoilHealthCardSearch" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/Soil_Health/SAdmin.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register TagPrefix="Footer" TagName="footer" Src="~/sFooter.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Soil Health Advisory</title>
    
    <script src="../Scripts/jquery-ui.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.2/themes/ui-lightness/jquery-ui.css" />
       <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <script type="text/javascript">
       

        $(document).ready(function () {
            getdate();
            $("#btn_Save").live("click", function () {
                $("#ddl_dist_code").prop('required', true);
                $("#txtMandalCode").prop('required', true);
                $("#txtMandalName").prop('required', true);
            
            });
            
        });
        history.pushState(null, null, 'SoilHealthCardSearch.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'SoilHealthCardSearch.aspx');
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
                    <img alt="" class="style64" src="../Images/soilbanner.png" />
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
                                Soil Health Card 
                                (Send SMS) &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                  
                    <div align="center">
                        <table align="center" width="100%">
                            <tr align="center">
                                <td class="style65">
                                    <table class="tbldata" align="center" width="80%">
                                        <tr>
                                            <td align="center" colspan="4" style="color: Red">
                                                Note:Fields marked with&nbsp;* &nbsp;are Compulsory.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" >
                                                District Name: <span style="color: Red">*</span>
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddl_dist_code" runat="server" CssClass="style_txt_entry" AutoPostBack="true"
                                                    OnSelectedIndexChanged="ddl_dist_code_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                Mandal Name:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddl_mandal_code" runat="server" 
                                                    CssClass="style_txt_entry" AutoPostBack="true" onselectedindexchanged="ddl_mandal_code_SelectedIndexChanged"
                                                   >
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td align="right">
                                                Village Name:</td>
                                            <td align="left">
                                                <asp:DropDownList ID="ddlvillage" runat="server"   CssClass="style_txt_entry" >
                                                </asp:DropDownList>
                                            </td>
                                            <td align="left">
                                                &nbsp;</td>
                                            <td align="left">
                                                &nbsp;</td>
                                        </tr>
                                        
                                   
                                        <tr align="center">
                                            <td colspan="4">
                                                <asp:Button ID="btn_Save" ValidationGroup="g1" runat="server" Height="27px" Text="Search"
                                                    OnClick="btn_Save_Click" />
                                               
                                            </td>
                                        </tr>
                                        <tr align="center">
                                            <td colspan="2">
                                                &nbsp;
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
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
                                <asp:GridView ID="Gvsendsms" runat="server" AutoGenerateColumns="False"
                                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3"  Width="693px"
                                    CellSpacing="2" CssClass="Grid">
                                    <Columns>
                                    <asp:TemplateField HeaderText="Sl.No">  <ItemTemplate>
                                    <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" /></ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Soil Sample ID" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoil_Sample_ID" runat="server" Text='<%# Bind("Soil_Sample_ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mandal Code" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMCode" runat="server" Text='<%# Bind("Mandal_Code") %>'></asp:Label>
                                                      <asp:Label ID="lbldistrictcode" runat="server" Text='<%# Bind("District_Code") %>'></asp:Label>
                                                       <asp:Label ID="lblvillagecd" runat="server" Text='<%# Bind("Village_Code") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Farmer Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblfarmername" runat="server" Text='<%# Bind("FarmerName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Father Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblfathername" runat="server" Text='<%# Bind("FatherName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Gender">
                                            <ItemTemplate>
                                                <asp:Label ID="lblgender" runat="server" Text='<%# Bind("Gender") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Address"  Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAddress" runat="server" Text='<%# Bind("Address") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                           <asp:TemplateField HeaderText="Aadhar No" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblAadhar_No" runat="server" Text='<%# Bind("Aadhar_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Mobile No" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile_No" runat="server" Text='<%# Bind("Mobile_No") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="pH_rating" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="pH_rating" runat="server" Text='<%# Bind("pH_rating") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="SurveyNo" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblSurveyNo" runat="server" Text='<%# Bind("SurveyNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="KhasraNo/DagNo" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblKhasraNo" runat="server" Text='<%# Bind("KhasraNo") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="IrrigationSource" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblIrrigationSource" runat="server" Text='<%# Bind("IrrigationSource") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="SoilType" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblSoilTyp" runat="server" Text='<%# Bind("SoilType") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FarmSize" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblFarmSize" runat="server" Text='<%# Bind("FarmSize") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FarmSizeUnit" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblFarmSizeUnit" runat="server" Text='<%# Bind("FarmSizeUnit") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Select All" >
                                         <HeaderTemplate>
                        <asp:CheckBox ID="chkall" runat="server" Text="Select All" OnCheckedChanged="sellectAll"
                            AutoPostBack="true" />
                    </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkselect" runat="server"  ></asp:CheckBox>
                                                     </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                                <asp:Button ID="btnsendsms" CausesValidation="false" runat="server" 
                                    Height="27px" Text="Send Sms" onclick="btnsendsms_Click"
                                                     />
                                               
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
