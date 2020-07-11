<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Copy of Request_Issue.aspx.cs" Inherits="SalesPoint_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../css/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style3
        {
            height: 421px;
        }
        .style9
        {
            height: 37px;
            text-align: left;
        }
        .style13
        {
            height: 13px;
            text-align: center;
        }
        .style19
        {
            width: 100%;
            height: 30px;
        }
        .style20
        {
            width: 100%;
            height: 88px;
            background-color: #DDDDEE;
        }
        .style21
        {
            height: 39px;
        }
        .style23
        {
            text-align: right;
            height: 28px;
        }
        .style24
        {
            width: 12px;
            height: 12px;
        }
        .style25
        {
            text-align: left;
            height: 28px;
        }
        .style33
        {
            width: 100%;
            height: 54px;
        }
        .style35
        {
        }
        .style37
        {
            color: #800000;
        }
        .style39
        {
            width: 943px;
        }
        .style40
        {
            width: 970px;
        }
        .style36
        {
            width: 128px;
        }
        </style>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center">
        <br />
        <table align="center" bgcolor="#DDDDEE" width="990px">
            <tr>
                <td align="center">
                    <table align="center" cellpadding="3" cellspacing="1" class="style3" width="100%">
                        <tr>
                            <td class="style9">
                                <table align="center" cellpadding="0" cellspacing="0" class="style33">
                                    <tr>
                                        <td class="style35" valign="bottom" align="center" style="background-color: White;">
                                            <img alt="" class="style63" src="../images/InsideHeader.jpg" />&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <table cellpadding="3" cellspacing="1" class="style19">
                                    <tr>
                                        <td class="style21">
                                            <table align="center" cellpadding="0" cellspacing="0" class="style20">
                                                <tr>
                                                    <td class="style25" bgcolor="#3B3E75">
                                                        <img class="style24" src="../images/14.gif" />
                                                        <span style="color: white;">Logged As ::</span> &nbsp; <span class="style37">
                                                            <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                                                    </td>
                                                    <td class="style25" bgcolor="#3B3E75">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" class="style23" style="color: White;" bgcolor="#3B3E75">
                                                        Date :&nbsp;&nbsp;
                                                        <asp:Label ID="lblDate" ForeColor="White" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3" align="center">
                                                        <div id='cssmenu' runat="server" align="center">
                                                            <p>
                                                                &nbsp;</p>
                                                            <div style="float: right; padding: 0px 10px 0px 0px">
                                                                <ul>
                                                                    <li class='has-sub'><a href="../Seed_UI/Logout.aspx">Logout</a></li>
                                                                </ul>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="top" align="center" bgcolor="White">
                                <table width="100%">
                                    <tr>
                                        <td bgcolor="#CAFFE4" align="center">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center">
                        <table>
        <tr><td> District
        </td>
        <td>
            <asp:DropDownList ID="ddl_dist" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddl_dist_SelectedIndexChanged"> 
            </asp:DropDownList>
            </td>
            <td> Mandal
        </td>
        <td>
            <asp:DropDownList ID="ddl_mandal" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddl_mandal_SelectedIndexChanged"> 
            </asp:DropDownList>
            </td>
            <td> Village
        </td>
        <td>
            <asp:DropDownList ID="ddl_vill" runat="server" AutoPostBack="true" 
                onselectedindexchanged="ddl_vill_SelectedIndexChanged"> 
            </asp:DropDownList>
            </td>
             <td> Survey Number
        </td>
        <td class="style36">
            <asp:DropDownList ID="ddlSurveyNos" runat="server">
            </asp:DropDownList>
            </td>
            </tr>
            <tr>
            <td colspan="8" align="center">
                <asp:Button ID="getlr" runat="server" Text="Get LR Data" 
                    onclick="getlr_Click" />
            </td>
            </tr>
            </table>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center">
                            <table width="100%">
                            <tr>
                           
                            <td align="center" valign="top" class="style40">
                            <table align="center" style="border: 1px solid green;width:100%">
                            <tr>
                            <td bgcolor="green" align="center" style="color:White; padding:2px" class="style39">
                                &nbsp;</td>
                            </tr>
                            <tr>
                            <td height="120px" class="style39">
                <asp:GridView ID="GvPopUpFarmerdata" runat="server" AlternatingRowStyle-CssClass="alt"
                                        AutoGenerateColumns="false" CssClass="Grid" PagerStyle-CssClass="pgr" AllowPaging="true"
                                       
                                        PageSize="10">
                                        <PagerSettings Mode="NumericFirstLast" PageButtonCount="5" />
                                        <PagerStyle HorizontalAlign="Center" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sno">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Crop">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCropName" runat="server" Text='<%# Eval("pCRPNAME") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Extent">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExtent" runat="server" Text='<%# Eval("pCR_TR_I_EXT") %>'></asp:Label>
                                                </ItemTemplate>
                                               
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eligible Quantity" ItemStyle-HorizontalAlign="Center">
                                               <ItemTemplate>
                                                <asp:TextBox ID="txtEligible" runat="server" CssClass="flds validate[required]" MaxLength="3" ></asp:TextBox>

                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Requested Quantity">
                                                <ItemTemplate>
                                                <asp:TextBox ID="txtRequest" runat="server" CssClass="flds validate[required]" MaxLength="3" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Available Quantity" 
                                                ItemStyle-HorizontalAlign="Center">
                                               <ItemTemplate>
                                                <asp:TextBox ID="txtSanction" runat="server" CssClass="flds validate[required]" MaxLength="3" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                          
                                            
                                          
                                        </Columns>
                                    </asp:GridView>
                            </td>
                            </tr>
                            <tr>
                            <td  height="120px" class="style39">
                                &nbsp;</td>
                            </tr>
                            </table>
                             
                            </td>
                            <td valign="top" align="center">
                                &nbsp;</td>
                            </tr>
                            </table>
                               
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="White" align="center">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <ajax:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel1" CancelControlID="btnLogClose"
                        TargetControlID="HiddenField1" BackgroundCssClass="modalBackground">
                    </ajax:ModalPopupExtender>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="left" Style="display: none;
                        overflow: auto" Height="400px">
                        <%--Style="display: none"--%>
                        <table width="800px" style="overflow: auto; background-color: #DDDDEE;">
                            <tr>
                                <td align="center" class="header">
                                    <h3>
                                        Details of Prisoner's Released Today</h3>
                                </td>
                                <td align="right" class="header">
                                    <asp:ImageButton ID="btnLogClose" runat="server" ImageUrl="~/images/close.jpg" Width="40px"
                                        Height="40px" CausesValidation="false" />
                                </td>
                            </tr>
                            <tr>
                                <td bgcolor="White" align="center">
                                    <asp:Label ID="lblNoRecordFound" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" class="style20" colspan="2" style="text-align: center; background-color: #FFFFFF;">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style13">
                </td>
            </tr>
            <tr>
                <td bgcolor="#3B3E75" class="style13">
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
