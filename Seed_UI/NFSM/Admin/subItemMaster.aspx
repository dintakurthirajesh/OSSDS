<%@ Page Language="C#" AutoEventWireup="true" CodeFile="subItemMaster.aspx.cs" Inherits="CropMaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/Admin/AdminMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <meta charset="utf-8"/>
	<title>Item Wise Specification</title>
	<meta name="description"/>
	 <script src="../js/script.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
<script src="../js/jquery-3.1.1.js" type="text/javascript"></script>
    <link href="../BS/css/siteMaster.css" rel="stylesheet" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../BS/js/bootstrap.js"></script>
    <link rel="stylesheet" href="../css/zerogrid.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <link rel="stylesheet" href="../css/menu.css" />
    <link rel="stylesheet" href="../css/lightbox.css" />
    <meta charset="utf-8">
   
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
        .form-control
        {
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

        <!--////////////////////////////////////Header--><header><div class="wrap-header">
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
                            <span class="card-title">&nbsp;Item Wise Specification </span>
                </div>
                        <div class="col-md-12">
                        <div class="form-group"></div>
                        <div class="form-group">
                            <%--<div class="col-md-3  text-right">
                            <label for="txtschemename">Fin Year</label>
                            </div>
                            <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlfinyear"  CssClass="form-control" 
                                    Height="34px" required="required" ></asp:DropDownList>
                            </div>--%>
                             <div class="col-md-3 text-right">
                            <label for="txtschemename">Scheme Name</label>
                            </div>
                            <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlschemename"  CssClass="form-control" AutoPostBack="true"
                                    required="required" onselectedindexchanged="ddlschemename_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                              <div class="col-md-2  text-right">
                            <label for="txtschemename">Component Name</label>
                            </div>
                            <div class="col-md-3">
                            <asp:DropDownList runat="server" ID="ddlsubcheme"  CssClass="form-control"
                                    required="required" AutoPostBack="True" 
                                    onselectedindexchanged="ddlsubcheme_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            </div>
                            
                                 <div class="form-group">
                          
                               <div class="col-md-3 text-right">
                                    <label for="ddlcropname" >Intervention  Name</label>
                                </div>
                                <div class="col-md-3">
                                  <asp:DropDownList runat="server" ID="ddlcropname"  CssClass="form-control" AutoPostBack="true"
                                        required="required" onselectedindexchanged="ddlcropname_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                                  <div class="col-md-2  text-right">
                                    <label for="ddlintervension" >Sub Intervention  Name</label>
                                </div>
                                <div class="col-md-3">
                                      <asp:DropDownList runat="server" ID="ddlintervension"  CssClass="form-control" AutoPostBack="true"
                                          required="required" 
                                          onselectedindexchanged="ddlintervension_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                            
                             <div class="form-group">
                              
                               <div class="col-md-3 text-right">
                                    <label for="txtitemname" >Item  Name</label>
                                </div>
                                <div class="col-md-3">
                                  <asp:DropDownList runat="server" ID="ddlitemname"  CssClass="form-control" AutoPostBack="true"
                                          required="required" 
                                          ></asp:DropDownList>
                                </div>
                                  <div class="col-md-2  text-right">
                                    <label for="ddlintervension" >Specification Desc</label>
                                </div>
                                <div class="col-md-3">
                                 <asp:Label runat="server" ID="lblsubitemcode" Visible="false"></asp:Label>
                                    <asp:TextBox ID="txtsubitemname" runat="server" MaxLength="120" placeholder="Enter Sub Item Name" CssClass="form-control" required="required" onkeypress="return isSpec(event);"></asp:TextBox>
                                   
                                </div>
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
                                     <%--   <asp:TemplateField HeaderText="Fin Year" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblyeardesc" Text='<%#Eval("year_desc") %>'></asp:Label>
                                                <asp:Label runat="server" ID="lblyearcd" Text='<%#Eval("year_code") %>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Scheme Code" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblschemecode" Text='<%#Eval("scheme_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblschemename" Text='<%#Eval("scheme_name") %>'></asp:Label>                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Component Code" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblsubschemecode" Text='<%#Eval("Componentcd") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Component Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblsubschemename" Text='<%#Eval("Component_name") %>'></asp:Label>                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Intervension Code" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblcropcode" Text='<%#Eval("interven_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Intervension Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblcropname" Text='<%#Eval("interven_name") %>'></asp:Label>                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub Intervension Code" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblinetervencode" Text='<%#Eval("subinterven_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sub Intervension Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblinetervenname" Text='<%#Eval("subinterven_name") %>'></asp:Label>                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Item Code" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblitemcode" Text='<%#Eval("item_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblitemname" Text='<%#Eval("item_name") %>'></asp:Label>                                             
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Sub Item Code" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label runat="server" ID="lblsubitemcode" Text='<%#Eval("subitem_code") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Specification Desc" >
                                            <ItemTemplate>
                                                <asp:Label runat="server" ID="lblsubitemname" Text='<%#Eval("subitem_name") %>'></asp:Label>                                             
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
