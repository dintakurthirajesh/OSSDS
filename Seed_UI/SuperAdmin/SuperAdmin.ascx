<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SuperAdmin.ascx.cs" Inherits="SuperAdmin_SuperAdmin" %>
<ul id="menu-bar">
    <li><a href="SuperAdmin.aspx">Home</a></li>
    <li><a href="#">Masters</a>
        <ul>
            <%--  <li><a href="DistMaster.aspx">District </a></li>
            <li><a href="MandalMaster.aspx">Mandal</a></li>--%>
            <li><a href="CompanyMaster.aspx">Company</a></li>
            <li><a href="CropMaster.aspx">Crop</a></li>
            <li><a href="CropVarietyMaster.aspx">Crop Variety</a></li>
        </ul>
    </li>
   <%-- <li><a href="#">LG Directory </a>
        <ul>
            <li><a href="lg/DistMaster_lg.aspx">District Master</a></li>
            <li><a href="lg/MandalMaster_lg.aspx">Mandal Master</a></li>
        </ul>
    </li>--%>
    <li><a href="#">Reports</a>
        <ul>
            <li><a href="ViewSP.aspx">View Sale Points</a></li>
            <li><a href="ViewSeedAllotment.aspx">View Seed Allotment</a></li>
            <li><a href="DistWiseDistribution.aspx">View Seed Distrbution</a></li>
        </ul>
    </li>
    <li><a href="#">Account</a>
        <ul>
            <li><a href="ChangePWD.aspx">Change Password</a></li>
            <li><a href="../Logout.aspx">Logout</a></li>
        </ul>
    </li>
</ul>
