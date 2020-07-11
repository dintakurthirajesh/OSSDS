<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MAOMenu.ascx.cs" Inherits="MAO_MAOMenu" %>
<ul id="menu-bar">
    <li><a href="home.aspx">Home</a></li>
     <li><a href="AddRepresentative.aspx">Add Representative</a></li>
   <%-- <li><a href="GeneratePermit.aspx">Generate Permit</a></li>--%>
    <li><a href="GeneratePermitAlternate.aspx">Generate Permit</a></li>
    <li><a href="CheckAdhar.aspx">Check Adhar</a></li>
    <li><a href="StockTransfer.aspx">Stock Transfer</a></li>
    <li><a href="#">Reports</a>
        <ul>
            <li><a href="ViewPermits.aspx">View Permits</a></li>
            <li><a href="ViewDistrbution.aspx">View Seed Distribution</a></li>
          <%--  <li><a href="#">List Of Beneficiaries</a></li>--%>
        </ul>
    </li>
    <li><a href="#">Account</a>
        <ul>
        <li><a href="ResetPwd.aspx">Reset Password</a></li>
            <li><a href="ChangePWD.aspx">Change Password</a></li>
            <li><a href="../Logout.aspx">Logout</a></li>
        </ul>
    </li>
</ul>
