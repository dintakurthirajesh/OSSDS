<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DistrbutionDetailsDrillFarmerMandalWs.aspx.cs" Inherits="Admin_DistrbutionDetails" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Seed Distribution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <style type="text/css">

        .auto-style2 {
            font-size: 100%;
            vertical-align: baseline;
            border-style: none;
            border-color: inherit;
            border-width: 0;
            margin-left: 0;
            margin-right: 0;
            margin-bottom: 0;
            padding: 0;
            background:;
        }
         .myGridStyle
        {
          width:90%;
            
        }
        
        .WordWrap
        {
            width: 100%;
            word-break: break-all;
        }
        .WordBreak
        {
            width: 100px;
            overflow: hidden;
            text-overflow: ellipsis;
        }
        
.myGridStyle
        {
            border-collapse:collapse;
            font-size:19px;
            
        }
    
        #txtbros {
            width: 82px;
            height: 19px;
        }
    
        .style65
        {
            height: 5px;
            
        }    
        .style66
        {
            height: 33px;
        }    
        </style>
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
    <div align="center" class="inner">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <table border="1" style="border: thick none #00CC00; background-color: white;">
            <tr align="center">
                <th colspan="2" style="background-color: white; color: #CCFF33">
                    <img alt="" src="../images/Header.png" />
                </th>
            </tr>
            <tr>
                <td class="style65" colspan="2">
                    <adminmenu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="left" bgcolor="#3B3E75">
                    <img class="style24" src="../images/14.gif" />
                    <span style="color: white;">Logged As ::</span> &nbsp; <span class="style37">
                        <asp:Label ID="lblUsrName" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span>
                </td>
                <td align="right" class="style66" style="color: White;" bgcolor="#3B3E75">
                    Date :&nbsp;&nbsp;
                    <asp:Label ID="lblDate" ForeColor="White" runat="server"></asp:Label>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td bgcolor="White" align="center" colspan="2">
                    <table width="90%">
                        <tr>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label1" runat="server" Text="Year"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="ddlyear" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlyear_SelectedIndexChanged">
                                    <asp:ListItem Text="Select Year" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                    <asp:ListItem Selected="True" Text="2017" Value="2017"></asp:ListItem>
                                    <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                    <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                    <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlyear" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Year"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label2" runat="server" Text="Season"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="seasons" runat="server" AutoPostBack="true">
                                    <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                    <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" class="style_td_label">
                                <asp:Label ID="Label3" runat="server" Text="Crop"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="ddlcrop" runat="server" >
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Crop"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="Get" runat="server" Text="GetData" OnClick="GetData" />
                            </td>
                        </tr>
                       
                        <tr>
                            <td colspan="6" align="right">
                                <asp:Button ID="btnhome" runat="server" Text="Back" onclick="btnhome_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" valign="top">
                                                            
                                          <strong> <b><asp:Label ID="lblremarks" Visible="false" runat="server" Text="Label"></asp:Label></b> </strong>  <br />
                                                  <asp:Label ID="Label4" Visible="false" runat="server" Text="No Record to View"></asp:Label>                   
                                <asp:DropDownList ID="ddlpagesize" runat="server" AutoPostBack="true" 
                                              onselectedindexchanged="ddlpagesize_SelectedIndexChanged" Visible="False">
                                    <asp:ListItem Text="50" Value="50"></asp:ListItem>
                                    <asp:ListItem Text="100" Value="100"></asp:ListItem>
                                    <asp:ListItem Text="200" Value="200"></asp:ListItem>
                                     <asp:ListItem Text="300" Value="300"></asp:ListItem>
                                      <asp:ListItem Text="400" Value="400"></asp:ListItem>
                                       <asp:ListItem Text="500" Value="500"></asp:ListItem>
                                       <asp:ListItem Text="1000" Value="1000"></asp:ListItem>
                                </asp:DropDownList>
                               <div class="WordWrap">
                                            <asp:GridView ID="gridviewdistrictwise" runat="server"  CssClass="Grid" PageSize="50" ShowFooter="true" AllowPaging="true" OnPageIndexChanging="OnPaging"
                                    AutoGenerateColumns="False" Width="100%"
                                                BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None"  OnRowDataBound="gridviewdistrictwise_RowDataBound" 
                                    BorderWidth="1px" onrowcreated="gridviewdistrictwise_RowCreated"
                                                CellPadding="3" CellSpacing="2">
                                                <Columns>
                                              <asp:TemplateField HeaderText="Sl.No" ><ItemTemplate>
                                                <asp:Label runat="server" ID="sno" Text='<%# Container.DataItemIndex +1%>' /></ItemTemplate>
                                                
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Farmer Id" Visible="false"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblfarmerid" Text='<%# bind("Farmer_Id") %>'/></ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Farmer Name"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblfarmername" Text='<%# bind("Farmer_Name") %>'/></ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                    <asp:TemplateField HeaderText="Father Name"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblfathername" Text='<%# bind("Father_Name") %>'/></ItemTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="SurveyNo"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblSurveyNo" Text='<%# bind("survey_nos") %>' Width="80px"/></ItemTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="KhataNo"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblKhataNo" Text='<%# bind("KhataNo") %>' Width="80px"/></ItemTemplate>
                                                </asp:TemplateField>
                                            <%--    <asp:TemplateField HeaderText="No of Bags Sanctioned"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblnobagssanctioned" Text='<%# bind("no_of_bags_sanctioned") %>'/></ItemTemplate>
                                                </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Season"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblSeason" Text='<%# bind("Season") %>'/></ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Crop Name"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblCropName" Text='<%# bind("CropName") %>'/></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblftotalval" Text="Total"></asp:Label>
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="No of Bags Purchased"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblnobagspurchased" Text='<%# bind("no_of_bags_purchased") %>'/></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblfbagspurchased" Text="0.00"></asp:Label>
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount Paid"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblamountpaid" Text='<%# bind("Amount_paid") %>'/></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblfamountpaid" Text="0.00"></asp:Label>
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Issued Date"><ItemTemplate>
                                                <asp:Label runat="server" ID="lblissued_date" Text='<%# bind("issued_date") %>'/></ItemTemplate>
                                             
                                                </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                                <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                                <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                                <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                                <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                                <SortedDescendingHeaderStyle BackColor="#93451F" />
                                            </asp:GridView></div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" valign="top">
                                <asp:Button ID="btnexport" runat="server" Text="Export To Excel" 
                                    onclick="btnexport_Click"  />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                &nbsp;
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
