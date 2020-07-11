<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GeneratePermitWithoutWebland.aspx.cs"
    Inherits="MAO_GeneratePermitAlternate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
        history.pushState(null, null, 'GeneratePermitAlternate.aspx');
        window.addEventListener('popstate', function (event) {
            history.pushState(null, null, 'GeneratePermitAlternate.aspx');
        });

        function BeginRequestHandler(sender, args) {
            alert("hi");
            $("#btn_Save").prop("disabled", true);
            $("#btn_Save").val("Submitting ...Plase Wait");
            //            var overlay = $('<div class="overlay"></div>');
            //            overlay.show();
            //            overlay.appendTo(document.body);
            //            $('.Processpopup').show();

            $(document).ready(function () {
                $("#btn_Save").click(function () {
                    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(BeginRequestHandler);
                });
            });
        }
    </script>
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

        function moveOnMax(field, nextFieldID) {
            if (field.value.length >= field.maxLength) {
                document.getElementById(nextFieldID).focus();
            }
        }
   
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="UpdatePanel1">
        <ContentTemplate>
            <div align="center">
                <table align="center" bgcolor="#DDDDEE" width="90%">
                    <tr>
                        <td align="center">
                            <table align="center" cellpadding="3" cellspacing="1" width="100%" border="1">
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
                                        <span style="color: white;">Logged As ::</span> &nbsp; <span>
                                            <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                            <asp:Label ID="lblMand" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                            <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                                    </td>
                                    <td align="right" class="loggedUser">
                                        <span style="color: white;">Date ::</span> &nbsp; <span>
                                            <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <th colspan="2" style="color: Red; background-color: #88d8e0; height: 35px;" class="style63">
                                        Generate Permit
                                    </th>
                                </tr>
                                <tr>
                                    <td bgcolor="White" align="center" colspan="2">
                                        <table width="90%">
                                            <tr>
                                                <td align="right" class="style_td_label">
                                                    District
                                                </td>
                                                <td align="left" class="style_td_entry">
                                                    <asp:Label ID="lbl_Old_Dist" runat="server"></asp:Label>
                                                    <asp:Label ID="new_dist_code" Visible="false" runat="server"></asp:Label>
                                                    <asp:Label ID="lbl_old_dist_code" Visible="false" runat="server"></asp:Label>
                                                    <asp:Label ID="dist_code_LG" Visible="false" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" class="style_td_label">
                                                    &nbsp;Mandal
                                                </td>
                                                <td align="left" class="style_td_entry">
                                                    <asp:DropDownList ID="ddl_mandal" runat="server" AutoPostBack="true" Width="150px"
                                                        CssClass="fldtxtbox" OnSelectedIndexChanged="ddl_mandal_SelectedIndexChanged">
                                                        <asp:ListItem>Select Mandal</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" class="style_td_label">
                                                    Village
                                                </td>
                                                <td align="left" class="style_td_entry">
                                                    <asp:DropDownList ID="ddl_vill" runat="server" Width="200px">
                                                        <asp:ListItem>Select Village</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                                <td align="right" class="style_td_label">
                                                    Khatha Number
                                                </td>
                                                <td align="left" class="style_td_entry">
                                                    <asp:TextBox ID="txtKahataNo" runat="server"></asp:TextBox>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="KhataExtender" FilterType="Numbers" runat="server"
                                                        BehaviorID="KhataExtender" TargetControlID="txtKahataNo">
                                                    </ajaxToolkit:FilteredTextBoxExtender>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td bgcolor="White" align="center" colspan="2">
                                        <table width="100%" align="center">
                                            <tr>
                                                <td>
                                                    <table id="viewTable" runat="server" width="100%" align="center">
                                                        <tr>
                                                            <th colspan="8">
                                                                Pattadar Details
                                                            </th>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" class="style_td_label">
                                                                Pattadar Name
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="txtownerNm" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Father/Husband Name
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="txtOwnerfatherNm" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Caste
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:DropDownList ID="ddlOwnercaste" runat="server">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="sc">SC</asp:ListItem>
                                                                    <asp:ListItem Value="st">ST</asp:ListItem>
                                                                    <asp:ListItem Value="bc">BC</asp:ListItem>
                                                                    <asp:ListItem Value="other">Other</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Gender
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:RadioButtonList ID="rblOwnergender" runat="server" RepeatDirection="Horizontal">
                                                                    <asp:ListItem Selected="True" Value="m">Male</asp:ListItem>
                                                                    <asp:ListItem Value="f">Female</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" class="style_td_label">
                                                                Aadhar Number
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="a1Owner" onkeyup="moveOnMax(this, 'a2Owner')" runat="server" Width="30"
                                                                    MaxLength="4"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="a1_FilteredTextBoxExtender" FilterType="Numbers"
                                                                    runat="server" BehaviorID="a1_FilteredTextBoxExtender" TargetControlID="a1Owner">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:TextBox ID="a2Owner" onkeyup="moveOnMax(this, 'a3Owner')" runat="server" Width="30"
                                                                    MaxLength="4"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="a2_FilteredTextBoxExtender" FilterType="Numbers"
                                                                    runat="server" BehaviorID="a2_FilteredTextBoxExtender" TargetControlID="a2Owner">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:TextBox ID="a3Owner" runat="server" MaxLength="4" Width="30"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="a3_FilteredTextBoxExtender" FilterType="Numbers"
                                                                    runat="server" BehaviorID="a3_FilteredTextBoxExtender" TargetControlID="a3Owner">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Mobile Number
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="txtOwnerMobile" runat="server" MaxLength="10"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" FilterType="Numbers"
                                                                    runat="server" BehaviorID="FilteredTextBoxExtender1" TargetControlID="txtOwnerMobile">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Survey Numbers
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="txtsurveynos" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Total Extent
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="lblPextent" runat="server"></asp:TextBox>
                                                                  <ajaxToolkit:FilteredTextBoxExtender ID="lblPextent_Extender" FilterType="Numbers,Custom"
                                                                    runat="server" BehaviorID="lblPextent_Extender" TargetControlID="lblPextent" ValidChars='.'>
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                        <%-- <tr>
                                                    <th colspan="8">
                                                        Bank Details
                                                    </th>
                                                </tr>
                                                <tr>
                                                    <td class="style_td_label" align="right">
                                                        Account Number
                                                    </td>
                                                    <td align="left" class="style_td_entry">
                                                        <asp:TextBox ID="txtacno" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="style_td_label" align="right">
                                                        Bank
                                                    </td>
                                                    <td align="left" class="style_td_entry">
                                                        <asp:DropDownList ID="ddlbank" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td class="style_td_label" align="right">
                                                        Branch
                                                    </td>
                                                    <td align="left" class="style_td_entry">
                                                        <asp:TextBox ID="txtbranch" runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="style_td_label" align="right">
                                                        IFSC Code
                                                    </td>
                                                    <td align="left" class="style_td_entry">
                                                        <asp:TextBox ID="txtifsc" runat="server"></asp:TextBox>
                                                    </td>
                                                </tr>--%>
                                                        <tr>
                                                            <td align="right" colspan="4">
                                                                person came for seed is
                                                            </td>
                                                            <td align="left" colspan="4">
                                                                <asp:RadioButtonList ID="rblsame" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged"
                                                                    RepeatDirection="Horizontal">
                                                                    <asp:ListItem Value="pattadar">Pattadar</asp:ListItem>
                                                                    <asp:ListItem Value="ocupant">Ocupant</asp:ListItem>
                                                                    <asp:ListItem Value="other">Other</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                                <asp:Label runat="server" ID="lblRemExtent" Visible="false"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <th colspan="8">
                                                                <asp:Label ID="leg" runat="server"></asp:Label>
                                                            </th>
                                                        </tr>
                                                        <tr id="otherTbl" runat="server">
                                                            <td class="style_td_label" align="right">
                                                                Person Name
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="txtPnm" runat="server"></asp:TextBox>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Relation with Owner
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:DropDownList ID="ddlrelation" runat="server">
                                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    <asp:ListItem Value="Husband">Husband</asp:ListItem>
                                                                    <asp:ListItem Value="Wife">Wife</asp:ListItem>
                                                                    <asp:ListItem Value="Son">Son</asp:ListItem>
                                                                    <asp:ListItem Value="Daughter">Daughter</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Aadhar Number
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="a1P" onkeyup="moveOnMax(this, 'a2p')" runat="server" Width="30"
                                                                    MaxLength="4"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" FilterType="Numbers"
                                                                    runat="server" BehaviorID="a1_FilteredTextBoxExtender" TargetControlID="a1P">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:TextBox ID="a2p" onkeyup="moveOnMax(this, 'a3p')" runat="server" Width="30"
                                                                    MaxLength="4"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" FilterType="Numbers"
                                                                    runat="server" BehaviorID="a2_FilteredTextBoxExtender" TargetControlID="a2p">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                                <asp:TextBox ID="a3p" runat="server" MaxLength="4" Width="30"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" FilterType="Numbers"
                                                                    runat="server" BehaviorID="a3p_FilteredTextBoxExtender" TargetControlID="a3p">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Mobile Number
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10"></asp:TextBox>
                                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" FilterType="Numbers"
                                                                    runat="server" BehaviorID="FilteredTextBoxExtender1" TargetControlID="txtMobile">
                                                                </ajaxToolkit:FilteredTextBoxExtender>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <%--  </ContentTemplate>
                                                        <Triggers>
                                                        <asp:PostBackTrigger ControlID="rblsame" />
                                                        </Triggers>
                                                        </asp:UpdatePanel>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="White" align="center" colspan="8">
                                                    <table align="center" width="90%">
                                                        <tr>
                                                            <td align="right" class="style_td_label">
                                                                Sanctioning Year
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:DropDownList ID="SanYear" runat="server">
                                                                    <asp:ListItem Text="2017" Selected="True" Value="2017"></asp:ListItem>
                                                                    <%--  <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                                        <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                                        <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                                        <asp:ListItem Text="2021" Value="2021"></asp:ListItem>--%>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Sanctioning Season
                                                            </td>
                                                            <td align="left" class="style_td_entry">
                                                                <asp:DropDownList ID="SanSeason" runat="server">
                                                                    <asp:ListItem Selected="True" Text="ఖరీఫ్" Value="Kharif"></asp:ListItem>
                                                                    <asp:ListItem Text="రబీ" Value="Rabi"></asp:ListItem>
                                                                </asp:DropDownList>
                                                                <asp:Label ID="lblfid" runat="server" Visible="false"></asp:Label>
                                                            </td>
                                                            <td align="right" class="style_td_label">
                                                                Select Sale Point
                                                            </td>
                                                            <td class="style_td_entry" align="left">
                                                                <asp:DropDownList ID="ddlsp" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlsp_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="8">
                                                    <asp:UpdatePanel runat="server" ID="up">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="GvCropData" runat="server" AlternatingRowStyle-CssClass="alt" OnRowDataBound="GvCropData_RowDataBound"
                                                                AutoGenerateColumns="false" CssClass="Grid" PagerStyle-CssClass="pgr" AllowPaging="false"
                                                                PageSize="10" ShowFooter="true" OnRowCommand="GvCropData_RowCommand">
                                                                <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                                                <PagerStyle HorizontalAlign="Center" />
                                                                <Columns>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <asp:ImageButton ID="imgBtnRemove" ValidationGroup="g3" runat="server" CommandName="Remove"
                                                                                CommandArgument="" ImageUrl="~/Images/hr.gif" />
                                                                        </ItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:ImageButton ID="imgBtnAdd" runat="server" ValidationGroup="g2" OnClientClick="return Validate(this)"
                                                                                Height="30px" ImageUrl="~/images/add.jpg" OnClick="imgBtnAdd_Click" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Sno">
                                                                        <ItemTemplate>
                                                                            <%# Container.DataItemIndex + 1 %>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Crop">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlCrop" Width="150px" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCrop_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="lblCRName" runat="server" Visible="false" Text='<%# Eval("CropName") %>'></asp:Label>
                                                                            <asp:Label ID="lblCRCode" runat="server" Visible="false" Text='<%# Eval("CropCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Crop variety">
                                                                        <ItemTemplate>
                                                                            <asp:DropDownList ID="ddlCropV" AppendDataBoundItems="true" Width="150px" runat="server"
                                                                                AutoPostBack="True" OnSelectedIndexChanged="GetStockAvailable">
                                                                            </asp:DropDownList>
                                                                            <asp:Label ID="lblStkId" runat="server" Visible="false" Text='<%# Eval("StockID") %>'></asp:Label>
                                                                            <asp:Label ID="lblCorpV" runat="server" Visible="false" Text='<%# Eval("CropVCode") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Extent">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txtExtent" runat="server" CssClass="flds validate[required]" MaxLength="7"
                                                                                Width="50" Text='<%# Eval("Extent") %>' OnTextChanged="txtExtent_OnTextChanged"
                                                                                AutoPostBack="true"></asp:TextBox>
                                                                            <ajaxToolkit:FilteredTextBoxExtender ID="txtExtent_extender" FilterType="Numbers,Custom"
                                                                                ValidChars="." runat="server" BehaviorID="txtExtent_extender" TargetControlID="txtExtent">
                                                                            </ajaxToolkit:FilteredTextBoxExtender>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Seed Rate" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblkgsRequirement" Text='<%# Eval("Requirement_in_kgs") %>' runat="server"
                                                                                CssClass="flds validate[required]" Width="50" MaxLength="5"></asp:Label>Kg
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No.Of Bags Available/Weight of Each Bag" HeaderStyle-Width="100">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblnobleft" runat="server" Text='<%# Eval("nob") %>'></asp:Label>/
                                                                            <asp:Label ID="lblweight" runat="server" Text='<%# Eval("weight") %>'></asp:Label>kg
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No.of Bags Required" ItemStyle-HorizontalAlign="Center">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblnobrequired" Text='<%# Eval("Requirement_in_bags") %>' runat="server"
                                                                                Width="50" MaxLength="5"></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="No.of Bags Sanctioned">
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="txt_bags_sanctioned" Text='<%# Eval("Sanctioned") %>' runat="server"
                                                                                Width="50" AutoPostBack="true" OnTextChanged="txtSanction_OnTextChanged"></asp:TextBox>
                                                                            <ajax:FilteredTextBoxExtender ID="bags_filter" BehaviorID="bags_filter" FilterType="Numbers"
                                                                                runat="server" TargetControlID="txt_bags_sanctioned" />
                                                                            <asp:Label ID="lblqtyissued" runat="server" Visible="false" Text='<%# Eval("qtyissued") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:PostBackTrigger ControlID="GvCropData" />
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr align="center">
                        <td colspan="8">
                            <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                            <asp:Button ID="btn_Save" runat="server" OnClick="btn_Save_Click" CssClass="fldbtn"
                                Text="Generate Permit Slip" />
                            <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <footer:footer ID="footer1" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
