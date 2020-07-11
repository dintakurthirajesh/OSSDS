<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SoilLogin.aspx.cs" Inherits="Login" %>

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
            height: 421px;
        }
        .style13
        {
            height: 13px;
            text-align: center;
        }
        .style18
        {
            height: 13px;
            text-align: center;
            color: #666666;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });
        function validateReg() {
            var userName = document.getElementById('txtUname').value;
            var pwd = document.getElementById('txtPwd').value;
            if (userName == "") {
                return false;
            }
            if (pwd == "") {
                return false;
            }
            var keyGenrate = '<%=ViewState["KeyGenerator"]%>';
            var myval = SHA1(keyGenrate);
            document.getElementById('txtPwdHash').value = '';
            var myval1 = SHA1(document.getElementById('txtPwd').value.toString());
            document.getElementById('txtPwd').value = '******';
            document.getElementById('txtPwdHash').value = SHA1(myval1 + myval);
            //alert(document.getElementById('txtPwdHash').value);
        }
           
     
    </script>
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
                <%-- <td style="background-color: #FFFFFF; " class="style15" bgcolor="White">

        </td>--%>
            </tr>
            <tr>
                <td>
                    <table align="center" cellpadding="3" cellspacing="1" class="style3" width="100%">
                        <tr align="center">
                            <th colspan="2" style="background-color: white; color: #CCFF33">
                                <img src="../Images/soilbanner.png" />
                            </th>
                        </tr>
                        <tr>
                            <td class="style13">
                                <div class="login">
                                    <h1>
                                        &nbsp;<img alt="" src="../images/44.gif" />Login/<a href="Default.aspx" style="color: Blue;">Home</a>
                                        <img alt="" src="../images/44.gif" /></h1>
                                    <p>
                                        <asp:TextBox ID="txtUname" runat="server" placeholder="User Name" CssClass="validate[required]"
                                            MaxLength="50"></asp:TextBox>
                                    </p>
                                    <p>
                                        <asp:TextBox ID="txtPwd" placeholder="Password" TextMode="Password" CssClass="validate[required]"
                                            runat="server" MaxLength="50"></asp:TextBox>
                                        <asp:HiddenField ID="txtPwdHash" runat="server" />
                                    </p>
                                    <p>
                                        <asp:Label ID="lblmsg" runat="server" Font-Bold="True" ForeColor="Red" Text=""></asp:Label>
                                      
                                        <asp:TextBox ID="txtimgcode" autocomplete="off" runat="server" placeholder="Enter code(Case Sensitive) shown in the image" ></asp:TextBox>
                                        <br />
                                        <asp:Image ID="Image1" runat="server" ImageUrl="~/CImage.aspx" />
                                    </p>
                                    <p class="submit">
                                        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClientClick="return validateReg();"
                                            OnClick="btnLogin_Click" />
                                    </p>
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
