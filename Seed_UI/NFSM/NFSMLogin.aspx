<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NFSMLogin.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/nfsm/Outmenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>NFSM</title>

    <meta name="description" />
        <script src="js/jquery-3.1.1.js" type="text/javascript"></script>
    <link rel="stylesheet" href="css/zerogrid.css" />
    <link rel="stylesheet" href="css/style.css" />
    <link rel="stylesheet" href="css/menu.css" />
    <link rel="stylesheet" href="css/lightbox.css" />
    <meta charset="utf-8">
    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- Owl Carousel Assets -->
    <link href="owl-carousel/owl.carousel.css" rel="stylesheet" />
    <script src="js/script.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
   
    <link href="BS/css/siteMaster.css" rel="stylesheet" />
    <link href="BS/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="BS/js/bootstrap.js"></script>
  
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <script src="../Scripts/sha1.js" type="text/javascript"></script>
    <style type="text/css">
        .form-group
        {
            overflow: auto !important;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
        function validateReg() {
            var userName = document.getElementById('txtUname').value;

            var pwd = document.getElementById('txtPwd').value;
            if (userName == "") {
                alert("Please Enter User Name");
                return false;
            }
            if (pwd == "") {
                alert("Please Enter Password");
                return false;
            }
            var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
            var myval = SHA1(keyGenrate);
            document.getElementById('txtPwdHash').value = '';
            var myval1 = SHA1(document.getElementById('txtPwd').value.toString());
            document.getElementById('txtPwd').value = '******';
            document.getElementById('txtPwdHash').value = SHA1(myval1 + myval);
            //alert(document.getElementById('txtPwdHash').value);
        }
           
     
    </script>
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
    <form id="form1" runat="server">
    <header>
	<div class="wrap-header">
		<!---Main Header--->
		<div class="main-header">
			<div class="zerogrid">
				<div class="row">
					<div class="col-1-4">
						<span>
							<img src="images/1/logo.png"  />
						</span>
					</div>
					<div class="col-2-4">
						<div id="logo"><a href="#"><img src="images/logo.png"  /></a></div>
					</div>
					<div class="col-1-4">
						<span>
							<img src="images/1/digital.png"  />
						</span>
					</div>
				</div>
			</div>
		</div>
		<!---Top Menu--->
		<div id="cssmenu" class="t-center">
		   <menu:menu ID="menu" runat="server" />
		</div>	</div><br />
 </header>
    <div align="center">
        <div class="container">
            <div class="form-group">
            </div>
            <div class="form-group">
            </div>
            <div class="form-group">
            </div>
            <div class="form-group">
            </div>
            <div class="col-md-3">
            </div>
            <div class="col-md-6" id="card" style="margin-top: 0;">
                <div class="card-header">
                    <span class="card-title" ><h1><img alt="" src="../images/44.gif" /><span style="color:White;">Login</span>/<a href="NFSMHome.aspx" ><span style="color:White;">Home</span></a>
                            <img alt="" src="../images/44.gif" /></h1>
                    </span>
                </div>
                <div class="form-group">
                </div>
                <div class="col-md-12 text-center">
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-2 text-center ">
                            <asp:TextBox ID="txtUname" runat="server" placeholder="User Name" required="required"
                                CssClass="form-control" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-2 text-center">
                            <asp:TextBox ID="txtPwd" TextMode="Password" placeholder="Enter Password" required="required"
                                CssClass="form-control" runat="server" MaxLength="50"></asp:TextBox>
                            <asp:HiddenField ID="txtPwdHash" runat="server" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-8 col-md-offset-2 text-center">
                            <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                            <asp:TextBox ID="txtimgcode" autocomplete="off" runat="server" placeholder="Enter code(Case Sensitive) shown in the image"></asp:TextBox>
                            <br />
                            <asp:Image ID="Image1" runat="server" ImageUrl="~/CImage.aspx" />
                            <p class="submit">
                                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="return validateReg();"
                                    CssClass="btn btn-block btn-primary" OnClick="btnLogin_Click" />
                            </p>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <div class="col-md-3">
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="form-group">
            </div>
            <div class="form-group">
            </div>
            <%--
                <div class="form-group">
                </div> <div class="form-group">
                </div>
                <div class="form-group">
                </div>
                <div class="form-group">
                </div> <div class="form-group">
                </div>
                <div class="form-group">
                </div>
                <div class="form-group">
                </div>--%>
            <div class="form-group">
                <div class="col-md-12  text-center">
                    <p class="submit" style="color: #666666; text-align: center;">
                        <b><strong>Designed And Developed by NIC Teleangana State , Hyderabad</strong></b></p>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
