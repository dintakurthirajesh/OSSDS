<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SchemeFiling.aspx.cs" Inherits="NFSM_MAO_SchemeFiling" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register TagPrefix="menu" TagName="menu" Src="~/NFSM/MAO/MAOMenu.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>Scheme Filing</title>
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
    <link href="../../css/jquery-ui.css" rel="stylesheet" />
    <script src="../js/script.js" type="text/javascript"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <%--   <script type="text/javascript" src="https://code.jquery.com/jquery-3.1.1.js"></script>--%>
    <link href="../BS/css/siteMaster.css" rel="stylesheet" />
    <link href="../BS/css/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="../BS/js/bootstrap.js"></script>
    <script src="../../Scripts/jquery-ui.js" type="text/javascript"></script>
    <script type="text/javascript">
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode > 31 && (charCode < 48 || charCode > 57)) { return false; }

            return true;
        }
    </script>
    <style type="text/css">
        .form-group {
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

        $(document).ready(function () {
            $('#txtDatePicker').datepicker({
                dateFormat: 'dd/mm/yy',
                changeMonth: true,
                changeYear: true,
                yearRange: "-100:+2"
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap-body">
            <!--////////////////////////////////////Header-->
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
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
                                <div id="logo">
                                    <a href="../index.html">
                                        <img src="../images/logo.png" /></a></div>
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
                <div id="cssmenu">
                    <menu:menu ID="menu" runat="server" />
                </div>
            </div>
            <br />
            <div class="container">
                <div class="form-group">
                    <div class="col-md-6 text-left card-header">
                        <img src="../../images/14.gif" alt="" />
                        <span style="color: Red;">Logged As ::</span> &nbsp;
                        <asp:Label ID="lblUsrName" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="lblDist" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label>&nbsp;
                        <asp:Label ID="lblMand" ForeColor="Red" Font-Bold="true" runat="server"></asp:Label></div>
                    <div class="col-md-6 text-right card-header">
                        <span style="color: Red;">Date ::</span> &nbsp; <span>
                            <asp:Label ID="lblDate" ForeColor="#ab7d44" Font-Bold="true" runat="server" Text=""></asp:Label>&nbsp;</span></div>
                </div>
            </div>
        </header>
            <div class="container">
                <div class="col-md-1">
                </div>
                <div class="col-md-10" id="card" style="margin-top: 0;">
                    <div class="card-header">
                        <span class="card-title">Scheme Filing</span>
                    </div>
                    <div class="form-group">
                    </div>
                    <asp:Panel ID="pnlstateschemdetails" runat="server" Visible="false">
                        <div class="form-group">
                            <div class="col-md-12  text-left">
                                <span class="card-title"><span style="color: Red;">Scheme Details</span></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1  text-left v-middle">
                                <label for="ddlyear">
                                    Fin Year</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddlyear" CssClass="form-control" required="required">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 text-left">
                                <label for="ddlschemes">
                                    Schemes</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddlscheme" CssClass="form-control" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlscheme_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <%-- <div class="col-md-3 text-center">
                                <label for="ddlscheme">
                                    Scheme</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddlscheme" CssClass="form-control" required="required"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlscheme_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="col-md-2 col-md-offset-1  text-left">
                                <label for="ddlsubcheme">
                                    Sub Scheme Name</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList runat="server" ID="ddlsubcheme" CssClass="form-control" AutoPostBack="true"
                                    required="required" OnSelectedIndexChanged="ddlsubcheme_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 text-left">
                                <label for="ddlcroptype">
                                    Crop Type</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddlcroptype" CssClass="form-control" required="required"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlcroptype_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="ddlintervention">
                                    Intervention</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddlintervention" CssClass="form-control" required="required"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlintervention_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 text-left">
                                <label for="ddlitem">
                                    Item</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddlitem" CssClass="form-control" required="required"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlitem_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="ddlsubitem">SubItem  Name</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlsubitem" CssClass="form-control"
                                            AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlsubitem_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-2   text-left">
                                <label for="ddlagency">Agency</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList runat="server" ID="ddlagency" CssClass="form-control" required="required"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlagency_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Select Agency"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="ddlsubitem">Category</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList runat="server" ID="ddlcategory" CssClass="form-control"
                                            AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:ListBox ID="lstCategory" runat="server" SelectionMode="Multiple" Visible="false"></asp:ListBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-2   text-left">
                                <label for="ddlagency">Firm Name</label>
                            </div>
                            <div class="col-md-3">
                                <asp:DropDownList runat="server" ID="ddlfirmname" CssClass="form-control"
                                    required="required" AutoPostBack="True" OnSelectedIndexChanged="ddlfirmname_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="txtitemfullcost">
                                    Full Cost</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:TextBox ID="txtitemfullcost" runat="server" MaxLength="120" placeholder="Item Full Cost"
                                    required="required" CssClass="form-control" onkeypress="return isSpec(event);"
                                    Enabled="False"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="txtitemfullcost_FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtitemfullcost" FilterType="Numbers, custom" ValidChars=".">
                                </ajax:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-2  text-left">
                                <label for="ddlagency">
                                    Subsidy Amount</label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtsubsidyamt" runat="server" MaxLength="120" placeholder="Subsidy Amount"
                                    required="required" CssClass="form-control" onkeypress="return isSpec(event);"
                                    Enabled="False"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="txtitemfullcost">
                                    Non Subsidy Amount</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:TextBox ID="txtnonSubsidyAmount" runat="server" MaxLength="120" placeholder="Non Subsidy Amount"
                                    required="required" CssClass="form-control" onkeypress="return isSpec(event);"
                                    Enabled="False"></asp:TextBox>
                                <asp:Label ID="lblMaxLenght" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12  text-left">
                                <span class="card-title"><span style="color: Red;">Land Details</span></span>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="ddllandtype">
                                    Land Type</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:DropDownList runat="server" ID="ddllandtype" CssClass="form-control" required="required">
                                    <asp:ListItem Value="" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="Ownland" Text="Own Land"></asp:ListItem>
                                    <asp:ListItem Value="Ownland" Text="lease Land"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 text-left">
                                <label for="txtpattano">
                                    Pattadar No</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:TextBox ID="txtpattano" runat="server" MaxLength="120" placeholder="Enter Pattadar No"
                                    required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                            </div>
                            <div class="col-md-3 text-center">
                                <label for="txtsurveyno">
                                    Survey No</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:TextBox ID="txtsurveyno" runat="server" MaxLength="120" placeholder="Enter Survey No"
                                    required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="txtlandextent">
                                    Land Extent</label>
                            </div>
                            <div class="col-md-3 text-left">
                                <asp:TextBox ID="txtlandextent" runat="server" MaxLength="120" placeholder="Enter Land Extent"
                                    required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                            </div>
                            <%--<div class="col-md-3 text-center">
                            <label for="txtlandextent">
                                Land Extent</label>
                        </div>
                        <div class="col-md-3 text-left">
                            <asp:TextBox ID="txtlandextent" runat="server" MaxLength="120" placeholder="Enter Land Extent"
                                required="required" CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                        </div>--%>
                        </div>
                        <div class="form-group">
                            <div class="col-md-12  text-left">
                                <span class="card-title"><span style="color: Red;">Beneficiary Contribution Details</span></span>
                            </div>
                        </div>
                        <div class="form-group">

                            <div class="col-md-2 col-md-offset-1 text-left">
                                <label for="ddlbank">
                                    Bank Name</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:DropDownList ID="ddlbank" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="">-- Select --</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2 text-left">
                                <label for="txtChallanno">
                                    Challan/DD No.</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtChallanno" runat="server" MaxLength="40" placeholder="Enter Challan/DD No"
                                    CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-2 col-md-offset-1  text-left">
                                <label>
                                    Challan Amount</label>
                            </div>
                            <div class="col-md-3 text-center">
                                <asp:TextBox ID="txtchallanamt" runat="server" MaxLength="10" placeholder="Enter Challan/DD Amount" AutoComplete="Off"
                                    CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
                                <ajax:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                    Enabled="True" TargetControlID="txtchallanamt" FilterType="Numbers" ValidChars=".">
                                </ajax:FilteredTextBoxExtender>
                            </div>
                            <div class="col-md-2  text-left">
                                <label for="txtDatePicker">
                                    Challan Date</label>
                            </div>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtDatePicker" runat="server" placeholder="Enter Challan/DD Date" AutoComplete="Off"
                                    CssClass="form-control" onkeypress="return isSpec(event);"></asp:TextBox>
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
                    </asp:Panel>
                </div>
            </div>
            <div class="col-md-1">
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
