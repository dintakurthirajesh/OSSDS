<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DaliyDistWiseDistribution.aspx.cs"  Inherits="Admin_DistWiseDistribution" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="adminmenu" TagName="menu" Src="~/Admin/Admin.ascx" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Seed Distribution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <%--<style type="text/css">

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
        </style>--%>
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
.gridview a
{
   
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
.gridviewfrz 
{
position:relative ;
top:expression(this.offsetParent.scrollTop);
z-index: 10;
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
                       <%-- <tr>
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
                                <asp:DropDownList ID="seasons" runat="server" >
                                    <asp:ListItem Text="Select Season" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Kharif" Value="Kharif"></asp:ListItem>
                                    <asp:ListItem Text="Rabi" Value="Rabi"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="seasons" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Season"></asp:RequiredFieldValidator>
                            </td>
                        </tr>--%>
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
                                &nbsp;</td>
                            <td align="left" class="style_td_entry">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right" class="style_td_label">
                                &nbsp;</td>
                            <td align="left" class="style_td_entry">
                                &nbsp;</td>
                            <td align="right" class="style_td_label">
                                &nbsp;</td>
                            <td align="left" class="style_td_entry">
                                &nbsp;</td><td align="right" class="style_td_label" colspan="2"></td>
                            <%--<td align="right" class="style_td_label">
                                <asp:Label ID="Label6" runat="server" Text="Crop"></asp:Label>
                            </td>
                            <td align="left" class="style_td_entry">
                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" EnableClientScript="true"
                                    ValidationGroup="g1" ControlToValidate="ddlcrop" InitialValue="0" runat="server"
                                    ForeColor="Red" ErrorMessage="Please Select Crop"></asp:RequiredFieldValidator>
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="6" align="center">
                                <asp:Button ID="Get" runat="server" Text="GetData" OnClick="GetData" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6" align="center" valign="top">
                                <table align="center" style="width: 800px">
                                    <tr>
                                        <td align="center">
                                        <asp:Panel runat="server" ID="pnlgrid" Width="1000px" ScrollBars="Both" Height="400px">
                                            <asp:GridView ID="gridviewdistrictwise" runat="server" CssClass="Grid" ShowFooter="true"
                                                AutoGenerateColumns="False" OnRowDataBound="gridviewdistrictwise_RowDataBound" 
        BackColor="White" onrowcreated="gridviewdistrictwise_RowCreated"  
                                                BorderColor="#3366CC" BorderWidth="1px" CellPadding="4" PageSize="35" 
                                                BorderStyle="None">
                                                <Columns>
                                                <asp:TemplateField HeaderText="Sl.No"><ItemTemplate>
                                                <asp:Label runat="server" ID="sno" Text='<%# Container.DataItemIndex +1%>' /></ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="District"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lbldistrictname" Text='<%# bind("DistName") %>' /><asp:Label runat="server" ID="lbldistrictcode" Text='<%# bind("DistCode") %>' Visible="false"/></ItemTemplate>
                                               
                                                </asp:TemplateField>
                                                 
                                                  <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblgntsallowat" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgntsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Ground nut TSSDC--> <asp:Label runat="server" ID="lblgntsPositioned" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgntsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblgntsSales" Text="0"  /></ItemTemplate>
                                               <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgntsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                
                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate> <!--Ground nut HACA--> <asp:Label runat="server" ID="lblgnhacallowat" Text="0"  /></ItemTemplate>
                                              <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgnhacallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblgnhacPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgnhacPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblhactsSales" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblhactsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                               
                                                  <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>   <!--Ground nut total--><asp:Label runat="server" ID="lblgntotallowat" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgntotallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblgntotPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblgntotPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lbltotSales" Text="0" /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lbltotSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                
                                                   <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbgtsallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Bengal gram TSSDC--> <asp:Label runat="server" ID="lblbgtsPositioned" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbgtsSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                
                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate> <!--Bengal gram HACA--> <asp:Label runat="server" ID="lblbghacallowat" Text="0"  /></ItemTemplate>
                                               <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbghacallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbghacPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbghacPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbghacSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbghacSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>   <!--Bengal gram NSC--><asp:Label runat="server" ID="lblbgnscallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgnscallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbgnscPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgnscPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbgnscSales" Text="0" /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgnscSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>   <!--Bengal gram total--><asp:Label runat="server" ID="lblbgtotallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgtotallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbgtotPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgtotPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbgtotSales" Text="0" /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbgtotSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                  <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblpdtsallowat" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblpdtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Paddy TSSDC--> <asp:Label runat="server" ID="lblpdtsPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblpdtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblpdtsSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblpdtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                
                                                  <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lbljwtsallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lbljwtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Jowar TSSDC--> <asp:Label runat="server" ID="lbljwtsPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lbljwtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lbljwtsSales" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lbljwtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblmztsallowat" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblmztsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Maize TSSDC--> <asp:Label runat="server" ID="lblmztsPositioned" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblmztsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblmztsSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblmztsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbggtsallowat" Text="0"  /></ItemTemplate>
                                                   <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbggtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Black  gram TSSDC--> <asp:Label runat="server" ID="lblbggtsPositioned" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbggtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblbggtsSales" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblbggtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblggtsallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblggtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Green gram  TSSDC--> <asp:Label runat="server" ID="lblggtsPositioned" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblggtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblggtsSales" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblggtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblrgtsallowat" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblrgtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Red gram  TSSDC--> <asp:Label runat="server" ID="lblrgtsPositioned" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblrgtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblrgtsSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblrgtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblsmtsallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblsmtsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Sesamum TSSDC--> <asp:Label runat="server" ID="lblsmtsPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblsmtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblsmtsSales" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblsmtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                
                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblsftsallowat" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblsftsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Sun flower TSSDC--> <asp:Label runat="server" ID="lblsftsPositioned" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lblsftsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblsftsSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblsftsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                 <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lbldntsallowat" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lbldntsallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Dhai ncha TSSDC--> <asp:Label runat="server" ID="lbldntsPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lbldntsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lbldntsSales" Text="0"  /></ItemTemplate>
                                                <FooterTemplate>
                                                <asp:Label runat="server" ID="lbldntsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblshtsallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblshtsallowatf" Text="0"  />
                                                </FooterTemplate>

                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Sun hemp TSSDC--> <asp:Label runat="server" ID="lblshtsPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblshtsPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblshtsSales" Text="0"  /></ItemTemplate>
                                                  <FooterTemplate>
                                                <asp:Label runat="server" ID="lblshtsSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Allotment"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblrabiallowat" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblrabiallowatf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="Positioned"> 
                                                <ItemTemplate>  <!--Sun hemp TSSDC--> <asp:Label runat="server" ID="lblrabiPositioned" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblrabiPositionedf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="Sales"> 
                                                <ItemTemplate>  <asp:Label runat="server" ID="lblrabiSales" Text="0"  /></ItemTemplate>
                                                 <FooterTemplate>
                                                <asp:Label runat="server" ID="lblrabiSalesf" Text="0"  />
                                                </FooterTemplate>
                                                </asp:TemplateField>
                                                </Columns>
                                                <FooterStyle BackColor="#99CCCC" ForeColor="#007DC1" />
                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                                                <PagerStyle BackColor="#99CCCC" ForeColor="#007DC1" 
                                                    HorizontalAlign="Left" />
                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                <SelectedRowStyle BackColor="#009999" ForeColor="#007DC1" Font-Bold="True" />
                                                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                                                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                                                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                                                <SortedDescendingHeaderStyle BackColor="#002876" />
                                            </asp:GridView></asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                      
                        <tr>
                            <td colspan="6">
                               <asp:Button ID="btnexport" runat="server" Text="Export To Excel" 
                                    onclick="btnexport_Click" Height="25px" Width="89px"  />
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
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
