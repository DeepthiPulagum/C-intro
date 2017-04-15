<%@ Page Language="C#" AutoEventWireup="true" CodeFile="C_DayActivity.aspx.cs" Inherits="C_DayActivity" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <link rel='stylesheet prefetch' href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'>
    <!-- Vendor CSS BUNDLE
    Includes styling for all of the 3rd party libraries used with this module, such as Bootstrap, Font Awesome and others.
    TIP: Using bundles will improve performance by reducing the number of network requests the client needs to make when loading the page. -->
    <link href="css/vendor/all.css" rel="stylesheet">
    <meta http-equiv="refresh" content="180">


    <!-- Vendor CSS Standalone Libraries
        NOTE: Some of these may have been customized (for example, Bootstrap).
        See: src/less/themes/{theme_name}/vendor/ directory -->
    <!-- <link href="css/vendor/bootstrap.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/font-awesome.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/picto.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/material-design-iconic-font.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/datepicker3.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/jquery.minicolors.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/bootstrap-slider.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/railscasts.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/jquery-jvectormap.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/owl.carousel.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/slick.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/morris.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/ui.fancytree.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/daterangepicker-bs3.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/jquery.bootstrap-touchspin.css" rel="stylesheet"> -->
    <!-- <link href="css/vendor/select2.css" rel="stylesheet"> -->

    <!-- APP CSS BUNDLE [css/app/app.css]
INCLUDES:
    - The APP CSS CORE styling required by the "admin" module, also available with main.css - see below;
    - The APP CSS STANDALONE modules required by the "admin" module;
NOTE:
    - This bundle may NOT include ALL of the available APP CSS STANDALONE modules;
      It was optimised to load only what is actually used by the "admin" module;
      Other APP CSS STANDALONE modules may be available in addition to what's included with this bundle.
      See src/less/themes/admin/app.less
TIP:
    - Using bundles will improve performance by greatly reducing the number of network requests the client needs to make when loading the page. -->
    <link href="css/app/app.css" rel="stylesheet">

    <!-- App CSS CORE
This variant is to be used when loading the separate styling modules -->
    <!-- <link href="css/app/main.css" rel="stylesheet"> -->

    <!-- App CSS Standalone Modules
    As a convenience, we provide the entire UI framework broke down in separate modules
    Some of the standalone modules may have not been used with the current theme/module
    but ALL modules are 100% compatible -->

    <!-- <link href="css/app/essentials.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/layout.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/sidebar.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/sidebar-skins.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/navbar.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/media.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/player.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/timeline.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/cover.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/chat.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/charts.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/maps.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/colors-alerts.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/colors-background.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/colors-buttons.css" rel="stylesheet" /> -->
    <link href="css/app/colors-calendar.css" rel="stylesheet" />
    <!-- <link href="css/app/colors-progress-bars.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/colors-text.css" rel="stylesheet" /> -->
    <!-- <link href="css/app/ui.css" rel="stylesheet" /> -->

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries
WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!-- If you don't need support for Internet Explorer <= 8 you can safely remove these -->
    <!--[if lt IE 9]>
<script src="https://oss.maxcdn.com/html5shiv/3.7.2/html5shiv.min.js"></script>
<script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
<![endif]-->

    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300">
    <link rel="stylesheet" href="https://cdn.rawgit.com/yahoo/pure-release/v0.6.0/pure-min.css">
    <%--<style>
       
        html, button, input, select, textarea, .pure-g [class *= "pure-u"] {  }
        p, td { line-height: 1.5; }
        ul { padding: 0 0 0 20px; }

        th { background: #eee; white-space: nowrap; }
        th, td { padding: 10px; text-align: left; vertical-align: top; font-size: .9em; font-weight: normal; border-right: 1px solid #fff; }
        td:first-child { white-space: nowrap; color: #008000; width: 1%; font-style: italic; }

        h1, h2, h3 { color: #4b4b4b; font-family: "Source Sans Pro", sans-serif; font-weight: 300; margin: 0 0 1.2em; }
        h1 { font-size: 4.5em; color: #1f8dd6; margin: 0 0 .4em; }
        h2 { font-size: 2em; color: #636363; }
        h3 { font-size: 1.8em; color: #4b4b4b; margin: 1.8em 0 .8em }
        h4 { font: bold 1em sans-serif; color: #636363; margin: 4em 0 1em; }
        a { color: #4e99c7; text-decoration: none; }
        a:hover { text-decoration: underline; }
        p { margin: 0 0 1.2em; }
        ::selection { color: #fff; background: #328efd; }
        ::-moz-selection { color: #fff; background: #328efd; }

        @media (max-width:480px) {
            h1 { font-size: 3em; }
            h2 { font-size: 1.8em; }
            h3 { font-size: 1.5em; }
            td:first-child { white-space: normal; }
        }

        .inline-code { padding: 1px 5px; background: #eee; border-radius: 2px; }
        pre {
            margin: 10px 0; overflow: auto; white-space: pre; word-wrap: normal;
            border: 0 !important; padding: 8px 10px !important; line-height: 18px; background: #edf3f8;
            font-family: Consolas, 'Liberation Mono', Courier, monospace; font-size: 14px;
        }

        /* Pure CSS */
        .pure-button { margin: 5px 0; text-decoration: none !important; }
        .button-lg { margin: 5px 0; padding: .65em 1.6em; font-size: 105%; }

        input[type="text"] { border-radius: 0 !important; }
    </style>--%>
    <link rel="stylesheet" href="auto-complete.css">
    <style>
        .loader {
            position: fixed;
            left: 0px;
            top: 0px;
            width: 100%;
            height: 100%;
            z-index: 9999;
            background: url('images/page-loader.gif') 50% 50% no-repeat rgb(249,249,249);
        }
    </style>
  <%--   <link href="css/css/materialize.css" rel="stylesheet">

    <link href="css/css/materialize.min.css" rel="stylesheet">--%>
</head>

<body>
    <div class="loader"></div>
    <form id="form1" runat="server">

        <!-- Recent tickets -->
        <div class="panel panel-default">

        
                <div class="panel panel-default timeline-appointments ">
                    <div class="panel-heading">
                        <div class="pull-left">
                            <a href="#" class="btn btn-primary">What your day looks like today</a>
                        </div>
                        <div class="pull-right">
                            <%--  <%
                                DateTime sPReviousDate;
                                if (Request["sPReviousDate"] != null)
                                {
                                    sPReviousDate = Convert.ToDateTime(Request["sPReviousDate"].ToString());
                                }
                            %>--%>

                            <%  DateTime sPReviousDate;
                                DateTime sNextDate;
                                DateTime current;
                                DateTime sDate;
                                if (Request["sPReviousDate"] != null)
                                {
                                    sPReviousDate = Convert.ToDateTime(Request["sPReviousDate"].ToString());
                                    //sDate = sPReviousDate.AddDays(-1);
                                    sDate = sPReviousDate;
                                    //sDate = Convert.ToDateTime(Request["sPReviousDate"].ToString()).AddDays(-1);
                                }
                                else if (Request["sNextDate"] != null)
                                {
                                    sNextDate = Convert.ToDateTime(Request["sNextDate"].ToString());
                                    //sDate = sNextDate.AddDays(+1);
                                    sDate = sNextDate;
                                }
                                else
                                {
                                    sDate = DateTime.Today;
                                }
                                current = sDate;
                            %>

                            <%--<a href="V_DayActivity.aspx?sPReviousDate="><i class="fa fa-fw fa-arrow-left"></i></a>--%>
                            <a href='C_DayActivity.aspx?sPReviousDate=<%=current.AddDays(-1)%>'><i class="fa fa-fw fa-arrow-left"></i></a>
                            <span class="date">
                                <asp:Label ID="lblDate" runat="server"></asp:Label></span>
                            <%--<a href="#"><i class="fa fa-fw fa-arrow-right"></i></a>--%>

                            <a href='C_DayActivity.aspx?sNextDate=<%=current.AddDays(+1)%>'><i class="fa fa-fw fa-arrow-right"></i></a>
                            <a target="_blank" href='C_DayActivity.aspx'><i class="pagehidden fa fa-fw fa-external-link"></i></a>
                        </div>
                        <div class="clearfix"></div>
                    </div>

                    <!-- Body -->
                    <ul class="list-unstyled">
                        <li>
                            <div class="time">8:00 <span class="text-muted">am</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <!--<select id="selNoAction" data-toggle="select2" style="width: 100%;" data-style="btn-white"  data-live-search="true"  class="btn btn-white text-center" onchange="gotoFunction(this);">-->
                            <select name="select" data-toggle="select2" id="selNoAction" class="btn btn-white text-center" style="width: 100%;" data-style="btn-white" data-live-search="true" data-size="5">

                                <asp:Label ID="lblselNoAction" runat="server"></asp:Label>
                            </select>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <div class="apt">
                                            <asp:Label ID="lblNoFeedback" runat="server"></asp:Label>
                                        </div>
                                    </li>
                                </ul>
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lblnewCandidate" runat="server"></asp:Label>
                                    </li>
                                </ul>
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lblpausedjobs" runat="server"></asp:Label>
                                    </li>
                                </ul>
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lblabsencerequest" runat="server"></asp:Label>
                                    </li>
                                </ul>
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl8am" runat="server"></asp:Label>
                                    </li>
                                </ul>
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl8amStarts" runat="server"></asp:Label>
                                    </li>
                                </ul>

                            </div>
                        </li>
                        <li>
                            <div class="time">9:00 <span class="text-muted">am</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl9am" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">10:00 <span class="text-muted">am</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl10am" runat="server"></asp:Label>
                                        <%--<div class="apt">
                                            <div class="btn-group btn-group-xs pull-right">
                                                <a href="" class="btn btn-default"><i class="fa  fa-info-circle"></i></a>
                                            </div>
                                            <a href="" class="text-regular strong"><i class="fa fa-fw fa-female"></i>Fima
                                        Brennus</a> <i class="text-muted fa fa-stethoscope"></i>Consultation
                           
                                        </div>--%>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">11:00 <span class="text-muted">am</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl11am" runat="server"></asp:Label>
                                        <%--<div class="apt">
                                            <div class="btn-group btn-group-xs pull-right">
                                                <a href="" class="btn btn-success"><i class="fa fa-plus"></i></a>
                                            </div>
                                            <span class="text-muted">Empty time slot ...</span>
                                        </div>--%>
                                    </li>
                                    <%-- <li class="bg-primary-light text-danger">
                                        <i class="fa fa-fw fa-clock-o"></i>Half an hour break
                          </li>--%>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">12:00 <span class="text-muted">pm</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl12pm" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">1:00 <span class="text-muted">pm</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl1pm" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">2:00 <span class="text-muted">pm</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl2pm" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">3:00 <span class="text-muted">pm</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl3pm" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">4:00 <span class="text-muted">pm</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl4pm" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>
                        </li>
                        <li>
                            <div class="time">5:00 <span class="text-muted">pm</span></div>
                            <i class="fa fa-dot-circle-o text-primary dot"></i>
                            <div class="appointments">
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl5pm" runat="server"></asp:Label>
                                    </li>
                                </ul>
                                <ul class="list-unstyled">
                                    <li>
                                        <asp:Label ID="lbl5pmContractEnding" runat="server"></asp:Label>
                                    </li>
                                </ul>
                            </div>

                        </li>
                    </ul>
                           <!-- Floating -->

                <%--<div class="fixed-action-btn horizontal">
                    <a class="btn-floating red">
                        <i class="fa fa-pencil"></i>
                    </a>
                    <ul>
                        <li><a href="Add_jobs.aspx" class="btn-floating red" title="Add Jobs"><i class="fa fa-pencil"></i></a></li>
                        <li><a href="C_View_Interview.aspx?inopen=Y&p=IN" class="btn-floating purple" title="View Interview"><i class="fa fa-suitcase"></i></a></li>
                        <li><a href="Client_View_Worker.aspx" class="btn-floating orange" title="View Worker"><i class="fa fa-eye"></i></a></li>
                        <li><a href="C_View_Candidate.aspx" class="btn-floating green" title="View Candidate"><i class="fa fa-eye"></i></a></li>
                        <li><a href="C_Timesheet_View.aspx" class="btn-floating blue" title="View Timesheets"><i class="fa fa-calendar"></i></a></li>
                        <li><a href="C_Invoices.aspx" class="btn-floating pink" title="Invoices"><i class="fa fa-dollar"></i></a></li>
                    </ul>
                </div>--%>
                    <!-- /Body-->
                </div>
           <%--<div class="col-md-4 col-lg-4 datepic">
                <asp:Calendar ID="Calendar1" class="day_calender" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth"  OnSelectionChanged="Selection_Change"  TitleFormat="Month" Width="400px">
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#EDE468" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>

                <script language="C#" runat="server">
                    
                    void Selection_Change(Object sender, EventArgs e)
                    {
                       
                        DateTime dateselect = Calendar1.SelectedDate;
                        DateTime current = DateTime.Now;
                        if(current > dateselect)
                        Response.Redirect("C_DayActivity.aspx?sPReviousDate=" + dateselect);
                        else 
                            Response.Redirect("C_DayActivity.aspx?sNextDate=" + dateselect);
                    }

                </script>
            </div>--%>
            </div>
       
    </form>
    <script src="//ajax.googleapis.com/ajax/libs/jquery/1.9.1/jquery.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".loader").fadeOut("slow");
        });
    </script>
      <button data-toggle="modal"  id="slidedown" data-target="#modal-slide-down" class="btn btn-primary propercalender "><i class="fa fa-calendar  fa-fw " ></i></button>

    <div class="modal slide-down fade" id="modal-slide-down">
	<div class="modal-dialog">
		<div class="v-cell">
			<div class="modal-content">
				<div class="modal-header">
					<button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
					<h4 class="modal-title">Select a date</h4>
				</div>
				<div class="modal-body">
					<div class="sidebar-block padding-none">
                      <div  id="a123"  ></div>
                   
                    </div>
				</div>
				<div class="modal-footer">
					<%--<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					<button type="button" id="dispBtn" class="btn btn-primary" <%--onclick='document.location.href="V_DayActivity.aspx?"'-- >Go</button>.--%>
                </div>
			</div>
		</div>
	</div>
</div>
    <script type="text/javascript">
        $('head').append('<link rel="stylesheet" href="css/app/colors-calendar.css" type="text/css" />');
        document.getElementById("slidedown").addEventListener("click", displayDate);
        function displayDate() {
            $("#a123").datepicker({
                
                changeMonth: true,
                changeYear: true,
                showOtherMonths: true,
                selectOtherMonths: true
            });
             $("#a123").on("change", function () {
                 var selected = $(this).val();
                     document.location.href = "C_DayActivity.aspx?sPReviousDate=" + selected;
             
            });
           
        }
    </script>
    
    <!-- Inline Script for colors and config objects; used by various external scripts; -->
    <script>
   
        var colors = {
            "danger-color": "#e74c3c",
            "success-color": "#81b53e",
            "warning-color": "#f0ad4e",
            "inverse-color": "#2c3e50",
            "info-color": "#2d7cb5",
            "default-color": "#6e7882",
            "default-light-color": "#cfd9db",
            "purple-color": "#9D8AC7",
            "mustard-color": "#d4d171",
            "lightred-color": "#e15258",
            "body-bg": "#f6f6f6"
        };
        var config = {
            theme: "admin",
            skins: {
                "default": {
                    "primary-color": "#3498db"
                }
            }
        };
    </script>

    <script src="js/vendor/all.js"></script>
    <script src="js/vendor/tables/all.js"></script>
    

    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src='http://ajax.googleAPIs.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>
    <script src="js/index.js"></script>
</body>
</html>