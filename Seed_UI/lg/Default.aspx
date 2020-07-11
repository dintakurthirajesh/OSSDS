<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register TagPrefix="menu" TagName="menu" Src="~/lg/outadmin.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/sfooter.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Local Government Directory</title>

        <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <script type="text/javascript">
        tday = new Array("Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday");
        tmonth = new Array("Jan", "Feb", "March", "April", "May", "June", "July", "August", "Sep", "Oct", "Nov", "Dec");

        function GetClock() {
            d = new Date();
            nday = d.getDay();
            nmonth = d.getMonth();
            ndate = d.getDate();
            nyear = d.getYear();
            nhour = d.getHours();
            nmin = d.getMinutes();
            nsec = d.getSeconds();

            if (nyear < 1000) nyear = nyear + 1900;

            if (nhour == 0) { ap = " AM"; nhour = 12; }
            else if (nhour <= 11) { ap = " AM"; }
            else if (nhour == 12) { ap = " PM"; }
            else if (nhour >= 13) { ap = " PM"; nhour -= 12; }

            if (nmin <= 9) { nmin = "0" + nmin; }
            if (nsec <= 9) { nsec = "0" + nsec; }


            document.getElementById('time').innerHTML = "" + tday[nday] + ", " + tmonth[nmonth] + " " + ndate + ", " + nyear + " " + nhour + ":" + nmin + ":" + nsec + ap + "";
            setTimeout("GetClock()", 1000);
        }
        window.onload = GetClock;
    </script>
    </head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table border="0" width="1190px" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td>
                    <img src="../images/lg_dire.jpg" />
                </td>
            </tr>
            <tr>
                <td bgcolor="#55A8BD">
                    <Menu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; padding-top: 0px;" align="left">
                    <br />
                </td>
            </tr>
         

            <tr>
                <td style="font-family: Verdana; font-size: medium;">
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                        &nbsp;</p>
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                        <strong>LOCAL GOVERNMENT DIRECTORY Telangana State</strong>
                    </p>                    
                    <br />
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                        Primary objective of Local Government directory is to facilitate State 
                        Departments to update the directory with newly formed panchayats/local 
                        bodies,re-organization in panchayats, conversion from Rural to Urban area etc 
                        and provide the same info in public domain. Key Features of Local Government 
                        Directory: Generation of unique code for each local government body - each local 
                        government body is assigned with a unique code.
                    </p>
                    <br />
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                       Maintenance of local government bodies and its mapping with constituting land region entities. For ex. gram panchayat mapping with villages.</p>
                    <br />
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                        Mandatory upload of Govt. order for each modification in the directory - to ascertain the users that the data published in LGD is authentic.
Maintenance of historical data - when modifications take place in LGD, the old values/data is archived.
Provision to maintain state specific local government setup.Compliance with Census 2011 codes.
                    </p>
                    <br />
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                        Facility to integrate with state specific standard codes - if any state is following standard codes for state level software applications, the same code can be linked to LGD code.</p>
                    <br />
                    <p style="text-align: justify; margin-left: 35px; margin-right: 35px;">
                        &nbsp;</p>
                    <br />
                    <%--  <p style="text-align: justify; margin-left: 650px;">
                        Prl Secretary,<br />
                        Animal Husbandry, Dairy Development and Fisheries<br />
                        Government of Telangana<br />
                        Hyderabad</p>--%>
                    <br />
                </td>
            </tr>
             <tr>
                <td style="font-family: Verdana; font-size: medium;" align="center">
                
                <strong> <asp:Label ID="lblhitcount" runat="server" 
                        Text="Label" ></asp:Label></strong>
                
                </td>
                
                </tr>
         
            <tr>
                <td>
                    <Footer:footer ID="footer" runat="server"></Footer:footer>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
