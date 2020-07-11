<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DAOMenu.ascx.cs" Inherits="DAO_DAOMenu" %>
<ul id="menu-bar">
    <li><a href="home.aspx">Home</a></li>
    <li><a href="FreezeAllotment.aspx">Freeze Allottment</a></li>
    <li><a href="SalePoint.aspx">Add Sale Point</a></li>
   
    <li><a href="#">Reports</a>
        <ul>
            <li><a href="ViewSalePoints.aspx">View Sale Points</a></li>
            <li><a href="MandWiseDistribution.aspx">View Seed Distrbution</a></li>
           <%-- <li><a href="">List Of Beneficiaries</a></li>--%>
        </ul>
    </li>
    <li><a href="#">Account</a>
        <ul>
         <li><a href="ResetPwd.aspx">Password Reset</a></li>
            <li><a href="ChangePWD.aspx">Change Password</a></li>
            <li><a href="../Logout.aspx">Logout</a></li>
        </ul>
    </li>
</ul>
