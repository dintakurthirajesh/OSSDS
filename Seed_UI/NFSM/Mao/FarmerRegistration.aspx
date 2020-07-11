<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FarmerRegistration.aspx.cs"
    Inherits="NFSM_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/MAO/MAOMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Beneficiary Registration</title>
    <meta name="description" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
      <script src="../js/script.js"></script>
   
    <script type="text/javascript" src="../BS/js/bootstrap.js"></script>
        <script src="../js/jquery-3.1.1.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../css/zerogrid.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/menu.css" />
    <link rel="stylesheet" href="../css/lightbox.css" />
     <link href="../BS/css/siteMaster.css" rel="stylesheet" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />

    <!-- Custom Fonts -->
    <link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Owl Carousel Assets -->
    <link href="../owl-carousel/owl.carousel.css" rel="stylesheet" />

    
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
            if ((ch == '!' || ch == '%' || ch == '<' || ch == '>' ||  ch == '#' || ch == '$' || ch == '*' || ch == ';' || ch == '"' || ch == '(' || ch == ')' || ch == '[' || ch == ']' || ch == '{' || ch == '}' || ch == '^')) {
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
							<img src="../images/1/logo.png"  />
						</span>
					</div>
					<div class="col-2-4">
						<div id="logo"><a href="index.html"><img src="../images/logo.png"  /></a></div>
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
		</div></div><br />
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
        <div class="container">
          
            <div class="col-md-12" id="card" style="margin-top: 0;">
                <div class="card-header">
                    <span class="card-title">Beneficiary Registration</span>
                </div>
                <div class="form-group">
                </div>
                <div class="col-md-12 text-center">
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-2 text-center">
                                <label for="txtaadharno">
                                    Aadhar No</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtaadharno" runat="server" MaxLength="12" placeholder="Enter Aadhar Number" AutoPostBack="true"
                                     CssClass="form-control" onkeypress="return isSpec(event);" 
                                    ontextchanged="txtaadharno_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-12  text-left">
                            <span class="card-title"><span style="color: Red;">Personal Details</span></span></div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3  text-center">
                            <label for="txtname">
                                Name</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtname" runat="server" MaxLength="80" placeholder="Enter Name"
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3  text-center">
                            <label for="txtfathername">
                                F/o or W/o Name</label>
                        </div>
                        <div class="col-md-3">
                            <asp:TextBox ID="txtfathername" runat="server" MaxLength="80" placeholder="Father/Husband"
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3  text-center">
                            <label for="ddlgender">
                                Gender</label>
                        </div>
                        <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlgender" CssClass="form-control" required="required">
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
                            <asp:DropDownList runat="server" ID="ddlCaste" CssClass="form-control" required="required">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlstate">
                                State</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlstate" CssClass="form-control" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddldistrict">
                                District</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddldistrict" CssClass="form-control" required="required"
                                AutoPostBack="True" OnSelectedIndexChanged="ddldistrict_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="ddlmandal">
                                Mandal</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlmandal" CssClass="form-control" required="required"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlmandal_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="ddlvillage">
                                Village/Locality</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:DropDownList runat="server" ID="ddlvillage" CssClass="form-control" required="required">
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
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtpaadharno">
                                Aadhaar No</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtpaadharno" runat="server" MaxLength="12" placeholder="Enter Aadhar No"
                                required="required" CssClass="form-control" onkeypress="return isNumberKey(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="txtemailid ">
                                E-mail ID</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtemailid" runat="server" MaxLength="30" placeholder="Enter E-mail ID"
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtmobileno">
                                Mobile No</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtmobileno" runat="server" MaxLength="12" placeholder="Enter Mobile No"
                                required="required" CssClass="form-control" onkeypress="return isNumberKey(event);"></asp:TextBox>
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
                            <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control" required="required">
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
                            <asp:DropDownList runat="server" ID="ddlbank" CssClass="form-control" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3 text-center">
                            <label for="txtifsccode">
                                IFS Code</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtifsccode" runat="server" MaxLength="20" placeholder="Enter Ifsc Code"
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-3 text-center">
                            <label for="txtbankaccount">
                                Account No</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtbankaccount" runat="server" MaxLength="18" placeholder="Enter Account No"
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>
                        <div class="col-md-3 text-center">
                        </div>
                        <div class="col-md-3 text-left">
                        </div>
                    </div>
                 
                    <div class="form-group">
                        <div class="col-md-4 col-md-offset-4 align-center">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-block btn-success" TabIndex="12"
                                Text="Submit" OnClick="btnSave_Click" />
                        </div>
                        <div class="col-md-4">
                        </div>
                    </div>
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
    </div>
    </form>
</body>
</html>
