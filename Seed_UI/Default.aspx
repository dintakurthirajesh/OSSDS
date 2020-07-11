<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register TagPrefix="menu" TagName="menu" Src="~/Mainmenu.ascx" %>
<%@ Register TagPrefix="footer" TagName="footer" Src="~/footer.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Seed Distrbution</title>
    <link href="css/style1.css" rel="stylesheet" type="text/css" />
    <link href="css/Menu1.css" rel="stylesheet" />
    <style type="text/css">
        table
        {
            background-color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <table align="center" bgcolor="#DDDDEE" width="90%" style="border-style: dotted">
            <tr>
                <td align="center">
                    <table align="center" cellpadding="3" cellspacing="1" width="100%">
                        <tr align="center">
                            <th colspan="2" style="background-color: white; color: #CCFF33">
                                <img alt="" src="images/Header.png" />
                            </th>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <menu:menu ID="menu" runat="server" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <script src="slider/js/jquery-1.11.3.min.js" type="text/javascript"></script>
                    <script src="slider/js/jssor.slider-23.1.5.mini.js" type="text/javascript"></script>
                    <script type="text/javascript">
                        jQuery(document).ready(function ($) {

                            var jssor_1_options = {
                                $ArrowNavigatorOptions: {
                                    $Class: $JssorArrowNavigator$
                                },
                                $ThumbnailNavigatorOptions: {
                                    $Class: $JssorThumbnailNavigator$,
                                    $Cols: 15,
                                    $SpacingX: 3,
                                    $SpacingY: 3,
                                    $Align: 455
                                }
                            };

                            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

                            /*responsive code begin*/
                            /*remove responsive code if you don't want the slider scales while window resizing*/
                            function ScaleSlider() {
                                var refSize = jssor_1_slider.$Elmt.parentNode.clientWidth;
                                if (refSize) {
                                    refSize = Math.min(refSize, 980);
                                    jssor_1_slider.$ScaleWidth(refSize);
                                }
                                else {
                                    window.setTimeout(ScaleSlider, 30);
                                }
                            }
                            ScaleSlider();
                            $(window).bind("load", ScaleSlider);
                            $(window).bind("resize", ScaleSlider);
                            $(window).bind("orientationchange", ScaleSlider);
                            /*responsive code end*/
                        });
                    </script>
                    <style>
                        /* jssor slider arrow navigator skin 07 css */
                        /*
        .jssora07l                  (normal)
        .jssora07r                  (normal)
        .jssora07l:hover            (normal mouseover)
        .jssora07r:hover            (normal mouseover)
        .jssora07l.jssora07ldn      (mousedown)
        .jssora07r.jssora07rdn      (mousedown)
        .jssora07l.jssora07lds      (disabled)
        .jssora07r.jssora07rds      (disabled)
        */
                        .jssora07l, .jssora07r
                        {
                            display: block;
                            position: absolute; /* size of arrow element */
                            width: 50px;
                            height: 50px;
                            cursor: pointer;
                            background: url('slider/img/a07.png') no-repeat;
                            overflow: hidden;
                        }
                        .jssora07l
                        {
                            background-position: -5px -35px;
                        }
                        .jssora07r
                        {
                            background-position: -65px -35px;
                        }
                        .jssora07l:hover
                        {
                            background-position: -125px -35px;
                        }
                        .jssora07r:hover
                        {
                            background-position: -185px -35px;
                        }
                        .jssora07l.jssora07ldn
                        {
                            background-position: -245px -35px;
                        }
                        .jssora07r.jssora07rdn
                        {
                            background-position: -305px -35px;
                        }
                        .jssora07l.jssora07lds
                        {
                            background-position: -5px -35px;
                            opacity: .3;
                            pointer-events: none;
                        }
                        .jssora07r.jssora07rds
                        {
                            background-position: -65px -35px;
                            opacity: .3;
                            pointer-events: none;
                        }
                        /* jssor slider thumbnail navigator skin 04 css *//*.jssort04 .p            (normal).jssort04 .p:hover      (normal mouseover).jssort04 .pav          (active).jssort04 .pav:hover    (active mouseover).jssort04 .pdn          (mousedown)*/.jssort04 .p
                        {
                            position: absolute;
                            top: 0;
                            left: 0;
                            width: 62px;
                            height: 32px;
                        }
                        .jssort04 .t
                        {
                            position: absolute;
                            top: 0;
                            left: 0;
                            width: 100%;
                            height: 100%;
                            border: none;
                        }
                        .jssort04 .w, .jssort04 .pav:hover .w
                        {
                            position: absolute;
                            width: 60px;
                            height: 30px;
                            border: #0099FF 1px solid;
                            box-sizing: content-box;
                        }
                        .jssort04 .pdn .w, .jssort04 .pav .w
                        {
                            border-style: dashed;
                        }
                        .jssort04 .c
                        {
                            position: absolute;
                            top: 0;
                            left: 0;
                            width: 62px;
                            height: 32px;
                            background-color: #000;
                            filter: alpha(opacity=45);
                            opacity: .45;
                            transition: opacity .6s;
                            -moz-transition: opacity .6s;
                            -webkit-transition: opacity .6s;
                            -o-transition: opacity .6s;
                        }
                        .jssort04 .p:hover .c, .jssort04 .pav .c
                        {
                            filter: alpha(opacity=0);
                            opacity: 0;
                        }
                        .jssort04 .p:hover .c
                        {
                            transition: none;
                            -moz-transition: none;
                            -webkit-transition: none;
                            -o-transition: none;
                        }
                        * html .jssort04 .w
                        {
                            width: /**/ 62px;
                            height: /**/ 32px;
                        }
                    </style>
                    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px;
                        width: 980px; height: 300px; overflow: hidden; visibility: hidden; background: url('slider/img/bg5.png') 0% 10% ;">
                        <!-- Loading Screen -->
                        <div data-u="loading" style="position: absolute; top: 0px; left: 0px; background-color: rgba(0,0,0,0.7);">
                            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block;
                                top: 0px; left: 0px; width: 100%; height: 70%;">
                            </div>
                            <div style="position: absolute; display: block; background: url('img/loading.gif') no-repeat center center;
                                top: 0px; left: 0px; width: 100%; height: 70%;">
                            </div>
                        </div>
                        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px;
                            width: 1000px; height: 500px; overflow: hidden;">
                            <div>
                                <div style="position: absolute; top: 10px; left: 10px; width: 480px; height: 300px;
                                    z-index: 0; font-family: Verdana; font-size: 12px; text-align: left;">
                                    <span style="display: block; line-height: 1em; font-size: 40px; color:Black;">Web
                                        based Application</span>
                                    <br />
                                    <span style="display: block; line-height: 1.1em; font-size: 1.3em; color:Black;
                                        text-align: justify;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SSDS is web based Subsidised
                                        Seed Distribution System designed and developed for the welfare of Agriculture Farmers
                                        in the State of Telangana for issue of Subsidy Seed.
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Farmers need to visit the nearest Sale Point
                                        located in their Mandal along with Pattadar Passbook and Aadhar Card. </span>
                                </div>
                                <img style="position: absolute; top: 23px; left: 480px; width: 500px; height: 300px;
                                    z-index: 0;" src="slider/img/s2.png" />
                                <img data-u="thumb" src="slider/img/s2t.jpg" />
                            </div>
                            <div>
                                <div style="position: absolute; top: 10px; left: 10px; width: 480px; height: 300px;
                                    z-index: 0; font-family: Verdana; font-size: 12px; text-align: left;">
                                    <span style="display: block; line-height: 1em; font-size: 35px; color:Black;">Integrated
                                        with WebLands </span>
                                    <br />
                                    <span style="display: block; line-height: 1.1em; font-size: 1.3em; color:Black;
                                        text-align: justify;">Under Agriculture Officer login, by entering Khata number,
                                        the system fetches the Land Records data from Web Land Database.
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        Application displays details like Pattadar Name, Father Name, Aadhar Number, Survey
                                        Numer wise Land Details, Crop Details and Occupant details etc. </span>
                                </div>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <img style="position: absolute; top: 23px; left: 500px; width: 400px; height: 200px;
                                    z-index: 0;" src="slider/img/s3.png" />
                                <img data-u="thumb" src="slider/img/s3t.png" />
                            </div>
                            <div>
                                <div style="position: absolute; top: 10px; left: 10px; width: 480px; height: 300px;
                                    z-index: 0; font-family: Verdana; font-size: 12px; text-align: left;">
                                    <span style="display: block; line-height: 1em; font-size: 40px; color:Black;">E-Authentication
                                    </span>
                                    <br />
                                    <br />
                                    <span style="display: block; line-height: 1.1em; font-size: 1.5em; color:Black;">
                                        The application is integrated with adhar enabled biometric devices to identify the
                                        farmer </span>
                                    <br />
                                    <br />
                                </div>
                                <img style="position: absolute; top: 23px; left: 480px; width: 500px; height: 300px;
                                    z-index: 0;" src="slider/img/bio.jpg" />
                                <img data-u="thumb" src="slider/img/e-auth.png" />
                            </div>
                            <div>
                                <div style="position: absolute; top: 10px; left: 10px; width: 480px; height: 300px;
                                    z-index: 0; font-family: Verdana; font-size: 12px; text-align: left;">
                                    <span style="display: block; line-height: 1em; font-size: 40px; color:Black;">Generates
                                        Permit</span><br />
                                    <span style="display: block; line-height: 1.1em; font-size: 1.3em; color:Black;
                                        text-align: justify;">By selecting the seed requested by the farmer, the system
                                        prompts with seed eligibility, rate and amount to be paid.
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        On confirmation, Permit Slip is generated and SMS will be sent to the Farmer's Mobile
                                        Number. Printing of Permit Slip is optional. </span>
                                    <br />
                                    <br />
                                </div>
                                <img style="position: absolute; top: 23px; left: 500px; width: 450px; height: 300px;
                                    z-index: 0;" src="slider/img/permit.png" />
                                <img data-u="thumb" src="slider/img/s4t.jpg" />
                            </div>
                            <div>
                                <div style="position: absolute; top: 10px; left: 10px; width: 480px; height: 300px;
                                    z-index: 0; font-family: Verdana; font-size: 12px; text-align: left;">
                                    <br />
                                    <span style="display: block; line-height: 1em; font-size: 35px; color:Black;">Accuracy
                                        in Seed Distrbution </span>
                                    <br />
                                    <br />
                                    <br />
                                    <br />
                                    <span style="display: block; line-height: 1.1em; font-size: 1.3em; color:Black;">
                                        The Farmer has to show the Permit Slip or SMS sent thru the system at the Sale Point
                                        and buy the Seed. The system generates various reports required by officers at various
                                        levels. </span>
                                    <br />
                                    <br />
                                </div>
                                <img style="position: absolute; top: 23px; left: 480px; width: 500px; height: 300px;
                                    z-index: 0;" src="slider/img/2.jpg" />
                                <img data-u="thumb" src="slider/img/2t.jpg" />
                            </div>
                            <div>
                                <div style="position: absolute; top: 10px; left: 10px; width: 480px; height: 300px;
                                    z-index: 0; font-family: Verdana; font-size: 12px; text-align: left;">
                                    <span style="display: block; line-height: 1em; font-size: 40px; color:Black;">Digital
                                        India</span>
                                    <br />
                                    <span style="display: block; line-height: 1.1em; font-size: 1.5em; color:Black;">
                                        Let us join hands together and move to Online system to realize the dream of Good
                                        Governance. </span>
                                    <br />
                                    <br />
                                </div>
                                <img style="position: absolute; top: 23px; left: 480px; width: 500px; height: 200px;
                                    z-index: 0;" src="slider/img/digi.jpg" />
                                <img data-u="thumb" src="slider/img/digit.jpg" />
                            </div>
                        </div>
                        <!-- Thumbnail Navigator -->
                        <div data-u="thumbnavigator" class="jssort04" style="position: absolute; left: 0px;
                            bottom: 0px; width: 980px; height: 60px;" data-autocenter="1">
                            <!-- Thumbnail Item Skin Begin -->
                            <div data-u="slides" style="cursor: default;">
                                <div data-u="prototype" class="p">
                                    <div class="w">
                                        <div data-u="thumbnailtemplate" class="t">
                                        </div>
                                    </div>
                                    <div class="c">
                                    </div>
                                </div>
                            </div>
                            <!-- Thumbnail Item Skin End -->
                        </div>
                        <!-- Arrow Navigator -->
                        <span data-u="arrowleft" class="jssora07l" style="top: 0px; left: 8px; width: 50px;
                            height: 50px;" data-autocenter="2"></span><span data-u="arrowright" class="jssora07r"
                                style="top: 0px; right: 8px; width: 50px; height: 50px;" data-autocenter="2">
                        </span>
                    </div>
                </td>
            </tr>
            <tr align="center">
                <td colspan="2" align="center" style="font-family: Verdana;">
                    <table>
                        <tr>
                            <td  align="center">
                                <div class="small-box bg-purple-gradient">
                                    <h3 style="color: #FFFFFF">
                                        Stock Received<br />(in Qtls)
                                    </h3>
                                    <br />
                                    Today:
                                    <b><asp:Label ID="lblstockday" runat="server" Text="Label"></asp:Label></b><br />
                                    This Week:
                                    <asp:Label ID="lblstockweek" runat="server" Text="Label"></asp:Label><br />
                                    This Month:<asp:Label ID="lblstockmonth" runat="server" Text="Label"></asp:Label><br />
                                    This Year:<asp:Label ID="lblstockyear" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                            <td style=" color: #FFFFFF;" align="center" valign="middle">
                                <div class="small-box bg-aqua-gradient">
                                    <h3 style="color: #FFFFFF">
                                        Permits Issued</h3>
                                    <br />
                                    Today:
                                    <asp:Label ID="lbldaypermits" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label><br />
                                    This Week:<asp:Label ID="lblweekpermits" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label><br />
                                    This Month:<asp:Label ID="lblmntpermits" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label><br />
                                    This Year:<asp:Label ID="lblyearpermits" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label>
                                </div>
                            </td>
                            <td style=""  align="center">
                                <div class="small-box bg-red-gradient">
                                    <h3>
                                        No.of Farmers<br /> Seed Distribured</h3>
                                    <br />
                                    Today:
                                    <asp:Label ID="lblfrmrday" runat="server" Text="Label"></asp:Label><br />
                                    This Week:<asp:Label ID="lblfrmrweek" runat="server" Text="Label"></asp:Label><br />
                                    This Month:<asp:Label ID="lblfrmrmnth" runat="server" Text="Label"></asp:Label><br />
                                    This Year:<asp:Label ID="lblfrmryear" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                            <%-- <td style="background-color: #eab259 !important; height: 80px; color: #FFFFFF"
                                width="15%" align="center">
                                <h3 style="color: #FFFFFF">
                                    Stock Received</h3>
                                <br />
                                Today:
                                <asp:Label ID="lblstockday" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label><br />
                                This Week:<asp:Label ID="lblstockweek" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label><br />
                                This Month:<asp:Label ID="lblstockmonth" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label><br />
                                This Year:<asp:Label ID="lblstockyear" runat="server" Text="Label" Style="color: #FFFFFF"></asp:Label>
                            </td>--%>
                            <td style=""  align="center">
                                <div class="small-box bg-green-gradient">
                                    <h3 style="color: #FFFFFF">
                                        Seed Distributed <br />(in Qtls)
                                    </h3>
                                    <br />
                                    Today:
                                    <asp:Label ID="lblseedday" runat="server" Text="Label"></asp:Label><br />
                                    This Week:
                                    <asp:Label ID="lblseedweek" runat="server" Text="Label"></asp:Label>
                                    <br />
                                    This Month:<asp:Label ID="lblseedmnth" runat="server" Text="Label"></asp:Label><br />
                                    This Year:<asp:Label ID="lblseedyear" runat="server" Text="Label"></asp:Label>
                                </div>
                            </td>
                            <%--<td style="background-image: url('images/bgpurple.jpg'); height: 80px; color: #FFFFFF;"
                                width="15%" align="center">
                                <h3 style="color: #FFFFFF">
                                    Amount Purchased
                                </h3>
                                <br />
                                Today:
                                <asp:Label ID="lblamtday" runat="server" Text="Label"></asp:Label><br />
                                This Week:
                                <asp:Label ID="lblamtweek" runat="server" Text="Label"></asp:Label><br />
                                This Month:<asp:Label ID="lblamtmnth" runat="server" Text="Label"></asp:Label><br />
                                This Year:<asp:Label ID="lblamtyear" runat="server" Text="Label"></asp:Label>
                            </td>--%>
                        </tr>
                        <%-- <tr>
                            <td colspan="6">
                                <asp:Chart ID="Chart1" runat="server" DataSourceID="SqlDataSource1" Width="1000px">
                                    <Series>
                                        <asp:Series Name="Series1" CustomProperties="DrawingStyle=Cylinder" XValueMember="DistName"
                                            YValueMembers="Column1">
                                        </asp:Series>
                                    </Series>
                                    <ChartAreas>
                                        <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                            <Area3DStyle Enable3D="True"></Area3DStyle>
                                        </asp:ChartArea>
                                    </ChartAreas>
                                </asp:Chart>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:seedsubsidyConnectionString %>"
                                    SelectCommand="HomepgReports" SelectCommandType="StoredProcedure">
                                    <SelectParameters>
                                        <asp:Parameter DefaultValue="CH" Name="action" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>--%>
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <footer:footer ID="footer1" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
