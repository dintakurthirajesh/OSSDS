<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Sadmin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<ul id="menu-bar">
   <%-- <li><a href="#">LG State Master</a>
        <ul>
            <li><a href="StateMaster.aspx">State Master</a></li>
            <li><a href="DistMaster_lg.aspx">LG District Master</a></li>
            <li><a href="MandalMaster_lg.aspx">Mandal Master</a></li>
            <li><a href="VillageMaster_lg.aspx">Village Master</a></li>
           
        </ul>
    </li>--%>
    <li><a href="DistMaster_lg.aspx">District Master</a>
        <ul>
            <%--<li><a href="StateMaster.aspx">State Master</a></li>--%>
          <%--  <li><a href="DistMaster_lg.aspx">LG District Master</a></li>--%>
           <%-- <li><a href="MandalMaster_lg.aspx">Mandal Master</a></li>
            <li><a href="VillageMaster_lg.aspx">Village Master</a></li>--%>
           
        </ul>
    </li>
    <li><a href="subdistrictMaster_lg.aspx">Sub District Master</a></li>
    <li><a href="MandalMaster_lg.aspx">Mandal Master</a>
        <ul>
          <%--  <li><a href="MandalMaster_lg.aspx">LG Mandal Master</a></li>--%>
          <%--  <li><a href="GPEntry.aspx">GP_Mandal Mapping</a></li>--%>
        </ul>
    </li>
    <li><a href="villageMaster_lg.aspx">Village Master</a>
        <ul>
            <li><a href="MismatchVillageNameMaster_lg.aspx">MisMatch Villages Names</a></li>
          <%--  <li><a >LG Village Master</a></li>--%>
           <%-- <li><a href="Search.aspx">Search Villages</a></li>
            <li><a href="GetDuplicates.aspx">Duplicate Entries</a></li>--%>
        </ul>
    </li>
     <li><a href="GramPanchayatMaster_lg.aspx">Gram Panchayat Master</a></li>
   <%-- <li><a href="Admin_SheepBenficiaries.aspx">Beneficiary Contribution details</a></li>
    <li><a href="Notice_Board.aspx">Notice Board</a></li>
    <li><a href="FeeBack_Reviw.aspx">Feedback Review</a></li>
    <li>--%>
        <%-- <a href="#">Account</a>
    </li>--%>
    <li style="float: right; padding-right: 5px;"><a href="Logout.aspx">LogOut</a></li>
</ul>