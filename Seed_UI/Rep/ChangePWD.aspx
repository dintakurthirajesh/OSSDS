<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePWD.aspx.cs" Inherits="Rep_ChangePWD" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Rep/RepMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Seed Distribution</title>
    <link href="../css/style1.css" rel="Stylesheet" type="text/css" />
    <script src="../scripts/JQuery-1.8.3-min.js.js" type="text/javascript"></script>
    <link href="../css/Menu1.css" rel="stylesheet" />
    <script src="../scripts/JQuery_FormValidation_Engines.js" type="text/javascript"></script>
    <script src="../scripts/Jquery_FormValidation_Engine_1.js" type="text/javascript"></script>
    <link href="../css/ValidationEngine.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/sha1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            $("#form1").validationEngine('attach', { promptPosition: "topRight" });
        });   
       
    </script>
</head>
<body>
<script type="text/javascript">
    function validateReg() {
        if (typeof (Page_ClientValidate) == 'function') {
            Page_ClientValidate();
        }
        if (Page_IsValid) {
            var newpwd = document.getElementById('txtNpwd').value;
            if (newpwd != '') {
                var oldpwd = document.getElementById('txtOpwd').value;
                document.getElementById('txtOldPwdHash').value = '';
                document.getElementById('txtNewPwdHash').value = '';
                var keyGenrate = '<%= ViewState["keyGen"]%>';
                var myval1 = SHA1(oldpwd);
                var myval = SHA1(keyGenrate);
                var myval2 = SHA1(newpwd);
                document.getElementById('txtOpwd').value = '**********';
                document.getElementById('txtNpwd').value = '**********';
                document.getElementById('txtCpwd').value = '**********';
                document.getElementById('txtOldPwdHash').value = SHA1(myval1 + myval);
                document.getElementById('txtNewPwdHash').value = myval2;
            }
        }

    }
    function validateCustomReg(oSrc, args) {
        var psw = document.getElementById('txtNpwd').value;
        var encpsw = document.getElementById('txtNewPwdHash').value;
        if (psw == '') {
            args.IsValid = false;
        }
        else {
            if (encpsw == '') {
                var pattern = new RegExp("^.*(?=.{8,})(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&amp;+=]).*$");
                args.IsValid = pattern.test(psw);
            }
        }

    }
    </script>
    <form id="form1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center" class="inner">
        <table border="1" style="border: thick none #00CC00; background-color: white;">
            <tr align="center">
                <th colspan="2" style="background-color: white; color: #CCFF33">
                    <img alt="" src="../images/Header.png" />
                </th>
            </tr>
            <tr>
                <td class="style65" colspan="2">
                    <menu:menu ID="menu" runat="server" />
                </td>
            </tr>
            <tr>
                 <td align="left" class="loggedUser">
                                <img src="../images/14.gif" />
                                <span style="color: white;">Logged As ::</span> &nbsp; 
                                    <asp:Label ID="lblUsrName" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;                                   
                                    <asp:Label ID="lblDist" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>&nbsp;   
                                     <asp:Label ID="lblMand" ForeColor="white" Font-Bold="true" runat="server"></asp:Label>
                            </td>
                <td align="right" class="style66" style="color: White;" bgcolor="#3B3E75">
                    Date :&nbsp;&nbsp;
                    <asp:Label ID="lblDate" ForeColor="White" runat="server"></asp:Label>
                    &nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <table class="tbldata" width="70%" style="padding: 2%; text-align: center;">
                        <tr>
                            <th colspan="3" style="color: Red; font-size: large; background-color: #88d8e0; height: 35px;">
                                Change Password
                            </th>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                <strong>Old Password</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtOpwd" runat="server" TextMode="Password" Width="200px" CssClass="validate[required]"
                                    MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                <asp:HiddenField ID="txtOldPwdHash" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="g1" ControlToValidate="txtOpwd"
                                    runat="server" ErrorMessage="Please Enter Password" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator1">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                <strong>New Password</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtNpwd" runat="server" TextMode="Password" Width="200px" CssClass="validate[required]"
                                    MaxLength="20"> </asp:TextBox>
                            </td>
                            <td>
                                <asp:HiddenField ID="txtNewPwdHash" runat="server" />
                                <asp:CustomValidator ID="CustomValidator1" runat="server" ValidationGroup="g1" Display="None"
                                    ErrorMessage="Your Password Should Contain minimum 8 Characters with atleast 1 uppercase,1 lowercase, 1 numeric and 1 Special character"
                                    ControlToValidate="txtNpwd" ClientValidationFunction="validateCustomReg"></asp:CustomValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True"
                                    TargetControlID="CustomValidator1">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 50%;">
                                <strong>Confirm Password</strong>
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtCpwd" runat="server" TextMode="Password" Width="200px" CssClass="validate[required]"
                                    MaxLength="20"></asp:TextBox>
                            </td>
                            <td>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="g1" ControlToValidate="txtCpwd"
                                    runat="server" ErrorMessage="Please Enter Password" SetFocusOnError="true" Display="None"></asp:RequiredFieldValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True"
                                    TargetControlID="RequiredFieldValidator9">
                                </asp:ValidatorCalloutExtender>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="g1"
                                    ErrorMessage="Password and Confirm Password doesnot Match" Display="None" ControlToValidate="txtCpwd"
                                    ControlToCompare="txtNpwd"></asp:CompareValidator>
                                <asp:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True"
                                    TargetControlID="CompareValidator1">
                                </asp:ValidatorCalloutExtender>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" align="center">
                                <asp:Button ID="btnSubmit" runat="server" ValidationGroup="g1" Text="Update" OnClick="Button1_Click"
                                    OnClientClick="validateReg();" CssClass="btnsubmit" /><br />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <footer:footer ID="footer1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
