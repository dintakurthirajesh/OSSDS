<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AgencyMaster.aspx.cs" Inherits="NFSM_Admin_AgencyMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/Admin/AdminMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta charset="utf-8"/>
	<title>Scheme Master</title>
	<meta name="description"/>
	
   <meta name="description" />
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
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.1.1.js"></script>
    <link href="../BS/css/siteMaster.css" rel="stylesheet" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../BS/js/bootstrap.js"></script>
     <script type="text/javascript">
         function isNumberKey(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode
             if (charCode > 31 && (charCode < 48 || charCode > 57))
             { return false; }

             return true;
         }
    </script>
    <style type="text/css">
        .form-group
        {
            overflow: auto !important;
        }
    </style>
    <script type="text/javascript">
        function isSpec(e) {
            var c;
            if (!e)
                e = window.event
            if (e.keyCode)
                c = e.keyCode;
            if (e.which)
                c = e.which;
            ch = String.fromCharCode(c);
            if ((ch == '!' || ch == '%' || ch == '<' || ch == '>' || ch == '@' || ch == '#' || ch == '$' || ch == '*' || ch == ';' || ch == '"' || ch == '(' || ch == ')' || ch == '[' || ch == ']' || ch == '{' || ch == '}' || ch == '^')) {
                alert("Not allowed <,>,!,%");
                return false;
            }
            else {
                return true;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="wrap-body">

<!--////////////////////////////////////Header-->
<header>
	<div class="wrap-header">
		<!---Main Header--->
		<div class="main-header">
			<div class="zerogrid">
				<div class="row">
					<div class="col-1-4">
						<span>
							<img src="../images/1/logo.png" />
						</span>
					</div>
					<div class="col-2-4">
						<div id="logo"><a href="index.html"><img src="../images/logo.png" /></a></div>
					</div>
					<div class="col-1-4">
						<span>
							<img src="../images/1/digital.png" />
						</span>
					</div>
				</div>
			</div>
		</div>
		<!---Top Menu--->
		<div id="cssmenu" >
		   <menu:menu ID="menu" runat="server" />
		</div>
 
   <div class="row"><div class="form-group"></div>
                    <div class="col-md-1"></div>
                    <div class="col-md-10" id="card" style="margin-top: 0">
                 
                        <div class="card-header text-center">
                            <span class="card-title text-center"><h1>Agency Master</h1></span>
                        </div>
                         <div class="form-group"></div>
                        <div class="form-group">
                            <div class="col-md-3  text-right">
                            <label for="txtschemename">Fin Year</label>
                            </div>
                            <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlfinyear"  CssClass="form-control" ></asp:DropDownList>
                            <asp:Label runat="server" ID="lblschemeid" Visible="false"></asp:Label>
                            </div>
                            <div class="col-md-2  text-right">
                                    <label for="txtschemename">Agency Name</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtschemename" runat="server" MaxLength="120" placeholder="Enter Agency Name" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                            </div>
                              <div class="form-group">
                             <div class="col-md-3  text-right">
                                    <label for="txtAccountNumber">District</label>
                                </div>
                                <div class="col-md-3">
                                   <asp:DropDownList runat="server" ID="ddldistrict"  CssClass="form-control" ></asp:DropDownList>
                                </div>
                            <div class="col-md-2  text-right">
                                    <label for="txtmobileno">Mobile No</label>
                                </div>
                                <div class="col-md-3"> <asp:TextBox ID="txtmobileno" runat="server" MaxLength="10" placeholder="Enter Mobile No" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox></div>
                            </div>
                              <div class="form-group">
                             <div class="col-md-3  text-right">
                              <label for="txtaddress">Address</label>
                                  
                                </div>
                                <div class="col-md-3">
                                     <asp:TextBox ID="txtaddress" runat="server" MaxLength="120" placeholder="Enter Address" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                            <div class="col-md-2  text-right">
                                     <label for="txtPincode">Pincode </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPincode" runat="server" MaxLength="120" placeholder="Enter Pincode" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                            </div>
                       <div class="form-group">
                             <div class="col-md-3  text-right">
                                    <label for="txtbankname">Bank Name </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtbankname" runat="server" MaxLength="10" placeholder="Enter Bank Name" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                            <div class="col-md-2  text-right">
                                    <label for="txtifsccode">Bank IFSC Code</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtifsccode" runat="server" MaxLength="120" placeholder="Enter IFSC Code" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                             <div class="col-md-3  text-right">
                                    <label for="txtAccountNumber">Account Number </label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtAccountNumber" runat="server" MaxLength="10" placeholder="Enter Account Number" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                           
                            </div>
                            <div class="form-group">
                                
                             
                            </div>
                        
                          <div class="form-group">
                          <div class="col-md-3 col-md-offset-5">
                           <asp:Button runat="server" ID="btnsubmit" Text="Submit" onclick="btnsubmit_Click" class="btn btn-success"/>
                          </div>
                        
                        </div>
                         <div class="row">
                            <div class="col-md-12 table-responsive">
                                  <asp:GridView ID="gvitemsubsidy" CssClass="table table-bordered table-hover table-striped fnt"
                                    runat="server" AutoGenerateColumns="False" >
                                    <HeaderStyle CssClass="success" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sl.No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" /></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fin Year" Visible="false" >
                                            <ItemTemplate>
                                                
                                                <asp:Label runat="server" ID="lblyearcd" Text='<%#Eval("year_code") %>' Visible="false"></asp:Label>
                                                 <asp:Label runat="server" ID="lblpincode" Text='<%#Eval("pincode") %>' Visible="false"></asp:Label>
                                                  <asp:Label runat="server" ID="lbldistrictcode" Text='<%#Eval("district_code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Agency Code">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblschemecode" Text='<%#Eval("agency_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agency Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblschemename" Text='<%#Eval("agency_name") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Mobile No " >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblmobileno" Text='<%#Eval("mobileno") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Bank Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblbankname" Text='<%#Eval("bank_code") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Ifsc Code " >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblifsccode" Text='<%#Eval("ifsc_code") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Account No" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblaccountno" Text='<%#Eval("account_no") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Address" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblAddress" Text='<%#Eval("address") %>'></asp:Label>
                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkedit"  Text="Edit" OnClick="linklinkedit_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="linkDelete" Text="Delete" OnClick="linkDelete_OnClick"></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          
                                    </Columns>
                                    <PagerStyle CssClass="pgn" Font-Bold="True" Font-Italic="False" Font-Overline="False"
                                        Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                </asp:GridView>
                       
                            </div>
                        </div>
                    </div>
                    <div class="col-md-1"></div>
                </div>
	
	
	</div>
</header>

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

	
    
	
</div>
    </form>
</body>
</html>