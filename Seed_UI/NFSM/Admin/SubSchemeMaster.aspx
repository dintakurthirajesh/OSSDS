<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SubSchemeMaster.aspx.cs" Inherits="SubSchemeMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/Admin/AdminMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8"/>
	<title>Sub Scheme Master</title>
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
       <script src="../js/jquery-3.1.1.js" type="text/javascript"></script>
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
                            <span class="card-title text-center"><h1>Component </h1></span>
                        </div>
                         <div class="form-group"></div>
                        <div class="form-group">
                         
                             <div class="col-md-3 col-md-offset-2  text-right">
                                    <label for="ddlscheme">Scheme Name</label>
                                </div>
                                <div class="col-md-3 text-left">
                                      <asp:DropDownList runat="server" ID="ddlscheme"  CssClass="form-control" AutoPostBack="true"
                                          onselectedindexchanged="ddlscheme_SelectedIndexChanged" ></asp:DropDownList>
                                          <asp:Label runat="server" ID="lblschemeid" Visible="false"></asp:Label>
                                </div>
                            </div>
                             
                         <div class="form-group">
                                <div class="col-md-3 col-md-offset-2 text-right">
                                    <label for="txtschemename">Component Name</label>
                                </div>
                                <div class="col-md-3">
                                   <asp:TextBox ID="txtschemename" runat="server" MaxLength="120" placeholder="Enter Component Name" required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                </div>
                             
                            </div>
                          <div class="form-group">
                          <div class="col-md-3 col-md-offset-5">
                           <asp:Button runat="server" ID="btnsubmit" Text="Submit" onclick="btnsubmit_Click" class="btn btn-success"/>
                             &nbsp;<asp:Button runat="server" ID="btnreset" Text="Reset" 
                                   class="btn btn-danger" onclick="btnreset_Click"/>
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
                                   <%--     <asp:TemplateField HeaderText="Fin Year" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblyeardesc" Text='<%#Eval("year_desc") %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblyearcd" Text='<%#Eval("year_code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Scheme Code">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblschemecode" Text='<%#Eval("scheme_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblschemename" Text='<%#Eval("scheme_name") %>'></asp:Label>                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Component Code">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblsubschemecode" Text='<%#Eval("Component_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Component Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblsubschemename" Text='<%#Eval("Component_name") %>'></asp:Label>                                             
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
