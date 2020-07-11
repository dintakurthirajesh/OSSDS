<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Admin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<ul id="menu-bar">
    <li><a href="Admin.aspx">Home</a></li>
    <li><a href="#">Masters</a>
        <ul>
          <%--  <li><a href="DistMaster.aspx">District </a></li>
            <li><a href="MandalMaster.aspx">Mandal</a></li>--%>
            <li><a href="CompanyMaster.aspx">Company</a></li>
            <li><a href="CropMaster.aspx">Crop</a></li>
            <li><a href="CropVarietyMaster.aspx">Crop Variety</a></li>
        </ul>
    </li>
    <li><a href="#">Seed</a>
        <ul>
            <li><a href="Seedprice.aspx">Seed Price</a></li>
            <li><a href="SeedAllot.aspx">Seed Allotment</a></li>
            <li><a href="ViewStockAllotted.aspx">Freeze Allotment</a></li>
        </ul>
    </li>
    <li><a href="#">Reports</a>
        <ul>
            <li><a href="ViewSP.aspx">View Sale Points</a></li>
            <li><a href="ViewSeedAllotment.aspx">View Seed Allotment</a></li>
            <li><a href="DistWiseDistribution.aspx">View Seed Distrbution</a></li>
             <li><a href="DistrbutionDetailsnew.aspx">View Seed Distrbutionnew</a></li>
            <li><a href="DistrbutionDetails.aspx">Distrbution(in Detail)</a></li>
            <li><a href="DistWiseAllReport.aspx">View Stock Position</a></li>
            <li><a href="CropWsAbstract.aspx">Crop Wise Abstract</a></li>
          
        </ul>
    </li>
   
    <li><a href="#">Account</a>
        <ul>
            <li><a href="ChangePWD.aspx">Change Password</a></li>
            <li><a href="../Logout.aspx">Logout</a></li>
        </ul>
    </li>
</ul>
