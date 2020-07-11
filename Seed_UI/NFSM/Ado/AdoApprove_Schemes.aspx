<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdoApprove_Schemes.aspx.cs"
    Inherits="NFSM_MAO_SchemeFilingSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/Ado/AdoMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Scheme Approve(ADO) </title>
    <meta name="description" />
      <script src="../js/jquery-3.1.1.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/zerogrid.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/menu.css" />
    <link rel="stylesheet" href="../css/lightbox.css" />
    <meta charset="utf-8">
    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Owl Carousel Assets -->
    <link href="../owl-carousel/owl.carousel.css" rel="stylesheet" />
    <script src="../js/script.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    
    <link href="../BS/css/siteMaster.css" rel="stylesheet" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../BS/js/bootstrap.js"></script>

      <script type="text/javascript" language="javascript">

          function Showgrid() {
              $('#mask').show();
              $('#<%=pnlgridview.ClientID %>').show();
          }

          function HidegridPopup() {
              $('#mask').hide();
              $('#<%=pnlgridview.ClientID %>').hide();
          }

          $(".btnclose1").live('click', function () {

              HidegridPopup();
          });
    </script>
    <script type="text/javascript">
        function chkbadchar(str) {
            badch = new Array("select", "drop", "update", "insert", "grant", "alter", "revoke", "union", "truncate", "delete", "xp_", ".", "<", ">", ";", "*", "#", "%", "^", "&", "|", "$", "'", ":", "?", "(", ")", "+", ",", "_", "!", "~", "\\", "/Script");
            for (var k = 0; k < 35; k++) {
                if (str.toLowerCase().indexOf(badch[k]) != -1) {
                    alert("Invalid characters ");
                    return false;
                }
            }
            return true;
        }
    </script>
    <style>
        .pgn a
        {
            padding: 6px 10px;
            border: 1px solid #027a6f;
            background: #009688;
            color: #fff !important;
        }
        
        .pgn span
        {
            padding: 6px 10px;
            border: 1px solid #666;
            background: #fff;
        }
        
        .fnt td
        {
            font-size: 12px;
            font-weight: bold;
            padding: 5px 8px !important;
        }
        
        tr.success ~ tr:hover
        {
            background: #508f35 !important;
            color: #fff !important;
            cursor: pointer;
        }
        
        .card-body
        {
            padding: 15px !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <header>
	<div class="wrap-header">
		<!---Main Header--->
		<div class="main-header">
			<div class="zerogrid">
				<div class="row">
					<div class="col-1-4">
						<span>
							<img src="../images/1/logo.png"  />
						</span>
					</div>
					<div class="col-2-4">
						<div id="logo"><a href=""><img src="../images/logo.png"  /></a></div>
					</div>
					<div class="col-1-4">
						<span>
							<img src="../images/1/digital.png"  />
						</span>
					</div>
				</div>
			</div>
		</div>
		<!---Top Menu--->
		<div id="cssmenu" >
		   <menu:menu ID="menu" runat="server" />
		</div>	</div><br />
        <div class="container">
        <div class="form-group">
        <div class="col-md-6 text-left card-header">                                 <img src="../../images/14.gif" alt="" />        
                              <span style="color: Red;">Logged As ::</span> &nbsp;
                                <asp:Label ID="lblUsrName" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                <asp:Label ID="lblDist" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                                <asp:Label ID="lblMand" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label></div>
        <div class="col-md-6 text-right card-header">                               <span style="color: Red;">Date ::</span> &nbsp; <span>
                                    <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span></div>
        </div>
        </div>
 </header>
  <asp:Panel ID="Panel1" DefaultButton="btnSearch" runat="server">
        <div class="container-fluid">
            <div class="">
                <div class="col-md-1">
                </div>
                <div class="col-md-10" id="card" style="margin-top: 0">
                    <div class="card-header">
                        <span class="card-title">Scheme Approve (ADO) </span>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <div class="row">
                           <%-- <div class="col-md-1"></div>--%>
                              <div class="col-md-11">
                               <div class="row">
                               <%-- <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 t-center">
                                            Fin Year
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                                <asp:ListItem Value="S">State Scheme</asp:ListItem>
                                                <asp:ListItem Value="C">Central Schem</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                           
                                      
                                        <div class="col-md-2 t-center">
                                            Scheme
                                        </div>
                                        <div class="col-md-2 ">
                                            <asp:DropDownList ID="ddlscheme" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="ddlscheme_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </div>
                                         <div class="col-md-2  t-center">
                           Sub Scheme Name
                            </div>
                            <div class="col-md-2">
                            <asp:DropDownList runat="server" ID="ddlsubcheme"  CssClass="form-control" AutoPostBack="true"
                                    onselectedindexchanged="ddlsubcheme_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 t-center">
                                            Crop Type
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlCroptype" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="ddlCroptype_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Intervention
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlintervenstion" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlintervenstion_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                               
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Item
                                        </div>
                                        <div class="col-md-2 align-center">
                                            <asp:DropDownList ID="ddlitem" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="ddlitem_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 t-center">
                                            Farmer ID
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtfarmerid" placeholder="Farmer ID" runat="server" CssClass="form-control"
                                                onkeypress="return chkbadchar(str);"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Agency 
                                        </div>
                                        <div class="col-md-2 t-center">
                                             <asp:DropDownList ID="ddlagency" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            
                                                                                    </div>
                                        <div class="col-md-2 t-center">
                                            
                                        </div>
                                    </div>
                                </div>--%>
                                 <asp:ScriptManager ID="ScriptManager1" runat="server">
                             </asp:ScriptManager>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 t-center">
                                            Fin Year
                                        </div>
                                        <div class="col-md-2">
                                            <asp:DropDownList ID="ddlyear" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                            
                                            </asp:DropDownList>
                                        </div>
                                    
                                        <div class="col-md-2 t-center">
                                            Scheme
                                        </div>
                                        <div class="col-md-2 ">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                 <ContentTemplate>
                                            <asp:DropDownList ID="ddlscheme" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="ddlscheme_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                               
                                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                        </div>
                                         <div class="col-md-2  t-center">
                           Sub Scheme Name
                            </div>
                            <div class="col-md-2">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                 <ContentTemplate>
                            <asp:DropDownList runat="server" ID="ddlsubcheme"  CssClass="form-control"                            
                                    onselectedindexchanged="ddlsubcheme_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                            </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-2 t-center">
                                            Crop Type
                                        </div>
                                        <div class="col-md-2">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                 <ContentTemplate>
                                            <asp:DropDownList ID="ddlCroptype" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="ddlCroptype_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Intervention</div>
                                        <div class="col-md-2">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                 <ContentTemplate>
                                            <asp:DropDownList ID="ddlintervenstion" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" 
                                                onselectedindexchanged="ddlintervenstion_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                               
                                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Item
                                        </div>
                                        <div class="col-md-2 align-center">
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                 <ContentTemplate>
                                            <asp:DropDownList ID="ddlitem" runat="server" CssClass="form-control" 
                                                AutoPostBack="True" onselectedindexchanged="ddlitem_SelectedIndexChanged">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                                
                                            </asp:DropDownList></ContentTemplate></asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="row">
                                    <div class="col-md-2 t-center">
                                  SubItem Name
                                </div>
                                <div class="col-md-2 t-center">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                 <ContentTemplate>
                                <asp:DropDownList runat="server" ID="ddlsubitem"  CssClass="form-control" 
                                        AutoPostBack="true"  
                                        onselectedindexchanged="ddlsubitem_SelectedIndexChanged"></asp:DropDownList>
                                        </ContentTemplate></asp:UpdatePanel>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Farmer ID
                                        </div>
                                        <div class="col-md-2">
                                            <asp:TextBox ID="txtfarmerid" placeholder="Farmer ID" runat="server" CssClass="form-control"
                                                onkeypress="return chkbadchar(str);"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 t-center">
                                            Agency 
                                        </div>
                                        <div class="col-md-2 t-center">
                                             <asp:DropDownList ID="ddlagency" runat="server" CssClass="form-control">
                                                <asp:ListItem Value="">-- Select --</asp:ListItem>
                                                
                                            </asp:DropDownList>
                                        </div>
                                       
                                    </div>
                                </div>
                                        </div>
                                <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn  btn-success  btn-block"
                                                OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger btn-block"
                                                OnClick="btnReset_Click" />
                                        </div>
                                        <div class="col-md-4">
                                        </div>
                                    </div>
                                </div></div></div>
                                <div class="col-md-1"></div>
                            </div>
                        </div>
                           <div class="form-group">
                            <div id="mask">
                            </div>
                            <!--Popup Box- start-->
                           
                           
                                   <asp:Panel ID="pnlgridview" runat="server" BackColor="White" Style="width: 1000px;z-index: 111; background-color: White;
                                position: absolute; left: 5%; top: 5%; border: outset 2px gray; padding: 5px;
                                display: none">
                                <div class="panel-heading">
                                    <div class="row">
                                        <div class="col-md-1">
                                        </div>
                                        <div class="col-md-10" id="Div2" style="margin-top: 0">
                                            <div class="card-header">
                                                <span class="card-title">Farmer Details</span>
                                            </div>
                                            <br />
                                            <div class="col-md-12">
                                                <div class="form-group">
                                                   
                                                        <div class="form-group">
                        <div class="col-md-3  text-center">
                            <label for="txtname">
                                Name</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtname" runat="server" MaxLength="80" placeholder="Enter Name"
                                 CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3  text-center">
                            <label for="txtfathername">
                                F/o or W/o Name</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtfathername" runat="server" MaxLength="80" placeholder="Father/Husband"
                                 CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3  text-center">
                            <label for="ddlgender">
                                Gender</label>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlgender" CssClass="form-control" >
                                <asp:ListItem Value="0" Text="Select Gender"></asp:ListItem>
                                <asp:ListItem Value="M" Text="Male"></asp:ListItem>
                                <asp:ListItem Value="F" Text="FeMale"></asp:ListItem>
                                <asp:ListItem Value="O" Text="Others"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddlCaste">
                                Caste</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlCaste" CssClass="form-control" >
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlstate">
                                State</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlstate" CssClass="form-control" >
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddldistrict">
                                District</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddldistrict" CssClass="form-control" 
                               >
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlmandal">
                                Mandal</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlmandal" CssClass="form-control" 
                              >
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddlvillage">
                                Village/Locality</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlvillage" CssClass="form-control" >
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="txtaddress">
                                Address</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtaddress" runat="server" MaxLength="60" placeholder="Enter Address"
                                 CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtpaadharno">
                                Aadhaar No</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtpaadharno" runat="server" MaxLength="12" placeholder="Enter Aadhar No"
                                 CssClass="form-control" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="txtemailid ">
                                E-mail ID</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtemailid" runat="server" MaxLength="30" placeholder="Enter E-mail ID"
                                 CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtmobileno">
                                Mobile No</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtmobileno" runat="server" MaxLength="12" placeholder="Enter Mobile No"
                                 CssClass="form-control" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="txtemailid ">
                                Differently Abled</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:RadioButtonList runat="server" ID="rbldiff" RepeatDirection="Horizontal">
                                <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                                <asp:ListItem Text="No" Value="0" Selected="True"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtperdisal">
                                % Of Disability</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtperdisal" runat="server" MaxLength="3" placeholder="Enter  % Of Disability"
                                CssClass="form-control" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                     <div class="col-md-3 text-center">
                            <label for="ddlcategory">
                                Farmer Category</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control" >
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                        
                        </div>
                        <div class="col-md-3 text-left">
                         
                        </div>
                       
                    </div>
                    <div class="form-group">
                        <div class="col-md-12  text-left">
                            <span class="card-title"><span style="color: Red;">Bank Details</span></span></div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlbank">
                                Bank Name</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlbank" CssClass="form-control" >
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtifsccode">
                                IFS Code</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtifsccode" runat="server" MaxLength="20" placeholder="Enter Ifsc Code"
                                 CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="txtbankaccount">
                                Account No</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtbankaccount" runat="server" MaxLength="18" placeholder="Enter Account No"
                                 CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                        </div>
                        <div class="col-md-3 text-left">
                        </div>
                    </div>
                                                   <div class="form-group">
                                                    <div class="col-md-6 align-right t-right">
                                                    </div>
                                                    <div class="col-md-6 align-left">
                                                        <asp:Button runat="server" ID="btnclose1" Text="Close" OnClick="btnclose1_Click"
                                                            class="btn btn-danger" CausesValidation="false" />
                                                    </div>
                                                </div>
                                                </div>
                                               
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <!--Popup Box- End-->
                        </div>
                         <div class="form-group"></div>
                         <div class="form-group"></div>
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:GridView ID="gvschmefiling" CssClass="table table-bordered table-hover table-striped fnt"
                                    runat="server" AutoGenerateColumns="False" >
                                    <HeaderStyle CssClass="success" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Farmer ID">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblfarmerid" Text='<%#Eval("farmer_id") %>' Visible="false"></asp:Label>
                                         <asp:LinkButton runat="server" ID="linkView" Text='<%#Eval("farmer_id") %>' OnClick="linkview_OnClick"></asp:LinkButton>
                                       
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Farmer Name">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblfarmername" Text='<%#Eval("Farmer_Name") %>'></asp:Label>
                                         <asp:Label runat="server" ID="lblDistCode" Text='<%#Eval("DistCode") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Father Name">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblfathername" Text='<%#Eval("Father_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Name" Visible="false">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblschemename" Text='<%#Eval("scheme_name") %>'></asp:Label>
                                        <asp:Label runat="server" ID="lblschemecode" Text='<%#Eval("scheme_code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Agency Name">
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblagencyname" Text='<%#Eval("agency_name") %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblagencycd" Text='<%#Eval("agency_code") %>' Visible="false"></asp:Label>                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Crop type">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblcropname" Text='<%#Eval("crop_name") %>'></asp:Label>
                                          <asp:Label runat="server" ID="lblcropcode" Text='<%#Eval("crop_code") %>' Visible="false"></asp:Label>
                                            <asp:Label runat="server" ID="lblsubschemecode" Text='<%#Eval("subscheme_code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Intervention">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblintervenname" Text='<%#Eval("interven_name") %>'></asp:Label>
                                          <asp:Label runat="server" ID="lblintercode" Text='<%#Eval("interven_code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblitemname" Text='<%#Eval("item_name") %>'></asp:Label>
                                          <asp:Label runat="server" ID="lblitemcode" Text='<%#Eval("item_code") %>' Visible="false"></asp:Label>
                                            <asp:Label runat="server" ID="lblsubitemcode" Text='<%#Eval("subitem_code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Full Cost">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblfullcost" Text='<%#Eval("fullcost") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subsidy Amount">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblsubsidyamt" Text='<%#Eval("subsidy_amt") %>'></asp:Label>
                                        
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Non Subsidy Amount">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblnonsubsidy" Text='<%#Eval("nonsubsidy_amt") %>'></asp:Label>
                                          <asp:Label runat="server" ID="lblyearcd" Text='<%#Eval("year_code") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Forwarded By">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblForwardedby" Text='<%#Eval("UserName") %>'></asp:Label>
                                        
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Remarks">
                                        <ItemTemplate>
                                        <asp:TextBox runat="server" ID="txtremarks" placeholder="Remarks"  CssClass="form-control"></asp:TextBox>                                         
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Approve">
                                        <ItemTemplate>
                                     <%--   <asp:CheckBox runat="server" ID="chkapprove" ></asp:CheckBox> --%>   
                                      <asp:RadioButtonList runat="server"  ID="chkapprove" RepeatDirection="Horizontal" >
                                      <asp:ListItem Value="A" Text="Approve"></asp:ListItem>
                                      <asp:ListItem Value="R" Text="Reject"></asp:ListItem>
                                      </asp:RadioButtonList>                                       
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgn" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False" 
                                        HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </div>
                         <div class="form-group">
                                    <div class="row">
                                        <div class="col-md-4">
                                        </div>
                                        <div class="col-md-2">
                                            <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
                                                CssClass="btn  btn-success  btn-block" Visible="false" onclick="btnsubmit_Click"
                                                 />
                                        </div>
                                        <div class="col-md-2">
                                          
                                        </div>
                                        <div class="col-md-4">
                                        </div>
                                    </div>
                                </div>
                    </div>
                    
                </div>
                <div class="col-md-1">
                </div>
            </div>
        </div>
    </asp:Panel>
    <footer>
	
	<div class="copyright">
		<div class="zerogrid wrapper">
			Designed and Developed by <a href="#">National Informatics Center</a>
			<ul class="quick-link">
				<li><a href="#">Hyderabad,</a></li>
				<li><a href="#">Telangana</a></li>
			</ul>
		</div>
	</div>
</footer>
    </form>
</body>
</html>
