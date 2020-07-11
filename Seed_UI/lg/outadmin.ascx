<%@ Control Language="C#" AutoEventWireup="true" CodeFile="outadmin.ascx.cs" Inherits="EVHMS_UI_Admin_Admin" %>
<ul id="menu-bar">
   <%-- <li><a href="#">LG State Master</a>
        <ul>
            <li><a href="StateMaster.aspx">State Master</a></li>
            <li><a href="DistMaster_lg.aspx">LG District Master</a></li>
            <li><a href="MandalMaster_lg.aspx">Mandal Master</a></li>
            <li><a href="VillageMaster_lg.aspx">Village Master</a></li>
           
        </ul>
    </li>--%>
    <li><a href="DistMaster_lg_vew.aspx">District Master</a>
      <%--  <ul>--%>
            <%--<li><a href="StateMaster.aspx">State Master</a></li>--%>
          <%--  <li><a href="DistMaster_lg_vew.aspx">LG District Master</a></li>--%>
           <%-- <li><a href="MandalMaster_lg.aspx">Mandal Master</a></li>
            <li><a href="VillageMaster_lg.aspx">Village Master</a></li>--%>
           
        <%--</ul>--%>
    </li>
<%--    <li><a href="MandalMaster_lg_view.aspx">Sub District Master</a>
       
    </li>--%>
    <li><a href="MandalMaster_lg_view.aspx">Mandal Master</a>
        <ul>
          <%--  <li><a href="MandalMaster_lg_view.aspx">LG Mandal Master</a></li>--%>
          <%--  <li><a href="GPEntry.aspx">GP_Mandal Mapping</a></li>--%>
        </ul>
    </li>
    <li><a href="VillageMaster_lg_view.aspx">Village Master</a>
        <ul>
            <%--<li><a href="AddCodes.aspx">Add Village Codes</a></li>--%>
          <%--  <li><a >LG Village Master</a></li>--%>
           <%-- <li><a href="Search.aspx">Search Villages</a></li>
            <li><a href="GetDuplicates.aspx">Duplicate Entries</a></li>--%>
        </ul>
    </li>
   <%-- <li><a href="Admin_SheepBenficiaries.aspx">Beneficiary Contribution details</a></li>
    <li><a href="Notice_Board.aspx">Notice Board</a></li>
    <li><a href="FeeBack_Reviw.aspx">Feedback Review</a></li>
    <li>--%>
        <%-- <a href="#">Account</a>
    </li>--%>
    <li style="float: right; padding-right: 5px;"><a href="lgLogin.aspx">Login</a></li>
</ul>