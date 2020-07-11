<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Schemefilingsearch.aspx.cs" Inherits="NFSM_MAO_Schemefilingsearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/MAO/MAOMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Scheme Filing Search</title>
    <meta name="description" />
        <script src="../js/jquery-3.1.1.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/zerogrid.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/menu.css" />
    <link rel="stylesheet" href="../css/lightbox.css" />
    <meta charset="utf-8">
    <!-- Custom Fonts -->
     <style type="text/css">
        .form-group
        {
            overflow: auto !important;
        }
    </style>
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Owl Carousel Assets -->
    <link href="../owl-carousel/owl.carousel.css" rel="stylesheet" />
    <script src="../js/script.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
   
    <link href="../BS/css/siteMaster.css" rel="stylesheet" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
        <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script type="text/javascript" src="../BS/js/bootstrap.js"></script>
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
						<span>
							<img src="../images/1/digital.png"  />
						</span>
					</div>
						<div id="logo"><a href="#"><img src="../images/logo.png"  /></a></div>
					</div>
					<div class="col-1-4">
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
    
        <div class="container-fluid">
            <div class="">
                <div class="col-md-1">
                </div>
                <div class="col-md-10" id="card" style="margin-top: 0">
                    <div class="card-header">
                        <span class="card-title">Basic Benficiery Search for Scheme Filing  </span>
                    </div>
                    <div class="form-group"></div>
                      <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlstate">
                                State</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlstate" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddldistrict">
                                District</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddldistrict" CssClass="form-control" 
                                AutoPostBack="True" 
                                onselectedindexchanged="ddldistrict_SelectedIndexChanged">
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
                                AutoPostBack="True" 
                                onselectedindexchanged="ddlmandal_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddlvillage">
                                Village/Locality</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlvillage" CssClass="form-control" 
                                >
                            </asp:DropDownList>
                        </div>
                    </div>
                      <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlmandal">
                                Farmer ID</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtfarmerid" runat="server" MaxLength="120" placeholder="Enter Farmer ID"
                                     CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                          
                        </div>
                        <div class="col-md-3 text-left">
                            
                        </div>
                    </div>
                     <div class="form-group">
                                    
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn  btn-success  btn-block"
                                                OnClick="btnSearch_Click" />
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-danger btn-block"
                                                OnClick="btnReset_Click" />
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                   
                                </div>
                    <div class="card-body">
                       
                        <div class="row">
                            <div class="col-md-12 table-responsive">
                                <asp:GridView ID="gvschmefiling" CssClass="table table-bordered table-hover table-striped fnt Grid"
                                    runat="server" AutoGenerateColumns="False" >
                                    <HeaderStyle CssClass="success" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Farmer ID">
                                        <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="linkfarmerid" Text='<%#Eval("farmer_id") %>'  OnClick="linkfarmerid_OnClick"></asp:LinkButton>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Farmer Name">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblfarmername" Text='<%#Eval("Farmer_Name") %>'></asp:Label>
                                           <asp:Label runat="server" ID="lblDistCode" Text='<%#Eval("DistCode") %>' Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Relation Name">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblfathername" Text='<%#Eval("Father_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Caste">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lblcaste" Text='<%#Eval("Caste") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Aadhar No">
                                        <ItemTemplate>
                                        <asp:Label runat="server" ID="lbladharno" Text='<%#Eval("AadharNo") %>'></asp:Label>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <PagerStyle CssClass="pgn" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False" 
                                        HorizontalAlign="Center" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                 
                </div>
                <div class="col-md-1">
                </div>

            </div>
           
        </div>
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
