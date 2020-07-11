<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logout.aspx.cs" Inherits="Logout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  <title>Soil Health Advisory</title>
    <link href="../css/style1.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    
    <script src="../scripts/sha1.js" type="text/javascript"></script>
    <style type="text/css">
        .style3
        {
            width: 95%;
            height: 421px;
        }
        .style13
        {
            height: 13px;
            text-align: center;
        }
        .style15
        {
            height: 20px;
        }
        .style18
        {
            height: 13px;
            text-align: center;
            color: #666666;
        }
        .style63
        {
            width: 987px;
            height: 90px;
        }
    </style>
    <script type="text/javascript" language="javascript">

        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <div align="center">
        <table align="center" width="800px" bgcolor="#DDDDEE">
            <tr>
                <td style="background-color: #FFFFFF;" class="style15" bgcolor="White">
                </td>
            </tr>
            <tr>
                <td>
                    <table align="center" cellpadding="3" cellspacing="1" class="style3" width="100%">
                        <tr>
                            <td align="center">
                                <img alt="" src="../Images/soilbanner.png" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <hr style="height: -12px" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <div class="login">
                                    <h1>
                                        &nbsp;
                                    </h1>
                                    <p>
                                        Successfully Logout.. Click Here for <a href="SoilLogin.aspx">Login</a></p>
                                    <p class="submit">
                                        &nbsp;</p>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td class="style18">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <hr />
                            </td>
                        </tr>
                        <tr>
                            <td class="style13">
                                <p class="submit" style="color: #666666; text-align: center;">
                                    Designed And Developed by NIC Teleangana State , Hyderabad</p>
                                <p class="submit" style="color: #666666; text-align: center;">
                                    &nbsp;</p>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="1px" style="background-color: #FFFFFF;">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
