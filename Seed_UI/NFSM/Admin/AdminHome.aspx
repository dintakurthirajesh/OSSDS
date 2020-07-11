<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="CropMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/Admin/AdminMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Item Master</title>
    <meta name="description" />
    <meta name="description" />
    <link rel="stylesheet" href="../css/zerogrid.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/menu.css" />
    <link rel="stylesheet" href="../css/lightbox.css" />
    
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
   <div class="panel-heading">
   <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10" id="card" style="margin-top: 0">
                   
                        <div class="card-header">
                            <span class="card-title">&nbsp;Item Master</span>
                </div>
                        <div class="col-md-12">
                        <div class="form-group"></div>
                        <div class="form-group">
                            <div class="col-md-3 col-md-offset-2 text-right">
                            <label for="txtschemename">Fin Year</label>
                            </div>
                            <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlfinyear"  CssClass="form-control" required="required" ></asp:DropDownList>
                            </div>
                            </div>
                             <div class="form-group">
                            <div class="col-md-3 col-md-offset-2 text-right">
                            <label for="txtschemename">Scheme Name</label>
                            </div>
                            <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlschemename"  CssClass="form-control" required="required"></asp:DropDownList>
                            </div>
                            </div>
                            
                            <div class="form-group">
                                <div class="col-md-3 col-md-offset-2 text-right">
                                    <label for="ddlcropname" >Crop  Name</label>
                                </div>
                                <div class="col-md-3">
                                  <asp:DropDownList runat="server" ID="ddlcropname"  CssClass="form-control" required="required"></asp:DropDownList>
                                </div>
                             
                            </div>
                             <div class="form-group">
                                <div class="col-md-3 col-md-offset-2 text-right">
                                    <label for="ddlintervension" >Intervension  Name</label>
                                </div>
                                <div class="col-md-3">
                                      <asp:DropDownList runat="server" ID="ddlintervension"  CssClass="form-control" required="required"></asp:DropDownList>
                                </div>
                             
                            </div>
                              <div class="form-group">
                                <div class="col-md-3 col-md-offset-2 text-right">
                                    <label for="txtitemname" >Item  Name</label>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtitemname" runat="server" MaxLength="120" placeholder="Enter Item Name" CssClass="form-control" required="required" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                             
                            </div>
                                                      
                          <div class="form-group">
                          <div class="col-md-3 col-md-offset-5">
                           <asp:Button runat="server" ID="btnsubmit" Text="Submit" onclick="btnsubmit_Click" class="btn btn-success"/>
                          </div>
                          </div>
                        </div>
                    </div>
                    <div class="col-md-1"></div>
                </div></div>
	
	
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
