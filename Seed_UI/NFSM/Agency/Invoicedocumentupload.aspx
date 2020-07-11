<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Invoicedocumentupload.aspx.cs"
    Inherits="NFSM_MAO_SchemeFilingSearch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/Agency/AgencyMenu.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Scheme Filing</title>
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
						<div id="logo"><a href="#"><img src="../images/logo.png"  /></a></div>
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
   
        <div class="container-fluid">
            <div class="">
                <div class="col-md-1">
                </div>
                <div class="col-md-10" id="card" style="margin-top: 0">
                    <div class="card-header">
                        <span class="card-title">Upload Documents&nbsp; (Agency)</span>
                    </div>
                    <div class="card-body">
                     
                        <div class="form-group">
                        </div>
                        <div class="form-group">
                        </div>
                        <div class="row align-center">
                            <div class="col-md-10 col-md-offset-1 table-responsive ">
                             <asp:GridView ID="gvUpload" CssClass="table table-bordered table-hover table-striped fnt" runat="server" AutoGenerateColumns="false" 
                    EmptyDataText="No records found" onrowdatabound="gvUpload_RowDataBound" 
                    ShowFooter="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Sl.No">
                            <ItemTemplate>
                                <%#Container.DataItemIndex +1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Farmer ID" Visible="false">
                            <ItemTemplate>
                                <asp:Label ID="lblEmpID" runat="server" 
                                  ></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtEmpID" runat="server" Visible="false"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Document Type">
                            <ItemTemplate>
                                <asp:Label ID="lbldocs" runat="server" Text='<%#Eval("Doc_code") %>'
                                    Visible="false"></asp:Label>
                                <asp:DropDownList ID="ddldocument" runat="server" Enabled="false" CssClass="form-control">
                                    <asp:ListItem Text="--Select Documents--" Value="0"></asp:ListItem>
                                  
                                    <asp:ListItem Text="Invoice Document" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="Item With Farmer " Value="02"></asp:ListItem>
                                  
                                </asp:DropDownList>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:DropDownList ID="ddldocumentselect" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="--Select Documents--" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="Invoice Document" Value="01"></asp:ListItem>
                                    <asp:ListItem Text="Item With Farmer " Value="02"></asp:ListItem>
                                  
                                 
                                </asp:DropDownList>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice No Or Other Details">
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("invoice_no") %>'
                                   ></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Invoice No Or Other Details"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Invoice Date">
                            <ItemTemplate>
                                <asp:Label ID="lbldate" runat="server" 
                                   ></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txtdate" runat="server" CssClass="form-control" placeholder="Invoice Date"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Photo">
                            <ItemTemplate>
                               <img src='data:image/jpg;base64,<%# Eval("doc_image") != System.DBNull.Value ? Convert.ToBase64String((byte[])Eval("doc_image")) : string.Empty %>' alt="image" height="60" width="60" />
                             
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:FileUpload ID="fUpload" runat="server" CssClass="form-control"/>
                            </FooterTemplate>
                        </asp:TemplateField>
                      
                        <asp:TemplateField>
                            <FooterTemplate>
                                <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_OnClick" CssClass="form-control btn btn-primary btn-block"
                                    Text="Upload" />
                            </FooterTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                            
                            </div>
                            <div class="col-md-1">
                              <asp:Button runat="server" ID="btnback" Text="Back" CssClass="form-control,btn btn-primary" OnClick="btnback_OnClick" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="row">
                                <div class="col-md-4">
                                </div>
                                <div class="col-md-2">
                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" 
                                        Visible="false" OnClick="btnsubmit_Click" />
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
        <div class="form-group"></div>
         <div class="form-group"></div>
        <div class="form-group"></div>
         <div class="form-group"></div>
        <div class="form-group"></div>
        <div class="form-group"></div>
          <div class="form-group"></div>
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
