<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="NFSM_Admin_AdminMenu" %>
<link rel="stylesheet" href="../css/zerogrid.css"/>
	<link rel="stylesheet" href="../css/style.css"/>
	<link rel="stylesheet" href="../css/menu.css"/>
	<link rel="stylesheet" href="../css/lightbox.css"/>
	
	<!-- Custom Fonts -->
	<link href="../font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
	
	<!-- Owl Carousel Assets -->
    <link href="../owl-carousel/owl.carousel.css" rel="stylesheet"/>
    
	
	<script src="../js/jquery-2.1.1.js"></script>
	<script src="../js/script.js"></script>
    
			<ul>
			   <li class="active"><a href="#"><span>Home</span></a></li>
			   <li class="has-sub"><a href="#"><span>Masters</span></a>
               <ul>
               <li><a href="SchemeMaster.aspx"><span>Scheme</span></a></li> 
                <li><a href="SubSchemeMaster.aspx"><span>Component</span></a></li> 
                <li><a href="CropMaster.aspx"><span>Intervention</span></a></li> 
                <li><a href="IntervensionMaster.aspx"><span>Sub Intervention</span></a></li>                
                 <li><a href="ItemMaster.aspx"><span>Items Master</span></a></li> 
                   <li><a href="subItemMaster.aspx"><span>Items Ws Specification</span></a></li> 
                 </ul>
               </li>
                <li><a href="MstAgency.aspx"><span>Agency Details</span></a></li>
			   <li><a href="MST_FIRM_MFG.aspx"><span>Firm Details</span></a></li>
			   <li><a href="SubsidyItemMaster.aspx"><span>Subsidy Item Master</span></a></li>
                <li><a href="SubsidyItemCrop.aspx"><span>Subsidy Item Crop</span></a></li>
			   <li class="last"><a href="AgencySubsidyItemMaster.aspx"><span>Agency Subsidy Item Master</span></a></li>
			   <li class="last"><a href="#"><span>Reports</span></a></li>
			   <li class="last"><a href="#"><span>Dash Board</span></a></li>
			   <li class="last"><a href="#"><span>Feedback</span></a></li>
			   <li class="last"><a href="#"><span>Helpdesk</span></a></li>
			   <li class="last"><a href="../Logout.aspx"><span>Logout</span></a></li>
			  </ul>
