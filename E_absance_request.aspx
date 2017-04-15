<%@ Page Language="C#" AutoEventWireup="true" CodeFile="E_absance_request.aspx.cs" Inherits="E_absance_request" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <meta http-equiv="refresh" content="180">
    <link rel='stylesheet prefetch' href='http://ajax.googleAPIs.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'>
  
    <style>
        .loader {position: fixed; left: 0px; top: 0px; width: 100%; height: 100%; z-index: 9999; background: url('images/page-loader.gif') 50% 50% no-repeat rgb(249,249,249);}
   </style>
    <!-- Vendor CSS BUNDLE
    Includes styling for all of the 3rd party libraries used with this module, such as Bootstrap, Font Awesome and others.
    TIP: Using bundles will improve performance by reducing the number of network requests the client needs to make when loading the page. -->
    <link href="css/vendor/all.css" rel="stylesheet">

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

    <link rel="stylesheet" href="https://fonts.googleAPIs.com/css?family=Source+Sans+Pro:300">
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
    <script>
        function ShowOtherQuestions_2() {
            //alert("here")
            if (document.getElementById("Q1Y").click == true) {
                document.getElementById("question_2").style = 'visibility:visible';
            }
            //if (document.getElementById("Q1N").click == true) {
            //    alert("you clicked NO");
            //}
        }





    </script>
     <script type="text/javascript">
        function blink() {
            var blinks = document.getElementsByTagName('blink');
            for (var i = blinks.length - 1; i >= 0; i--) {
                var s = blinks[i];
                s.style.visibility = (s.style.visibility === 'visible') ? 'hidden' : 'visible';
            }
            window.setTimeout(blink, 400);
        }
        if (document.addEventListener) document.addEventListener("DOMContentLoaded", blink, false);
        else if (window.addEventListener) window.addEventListener("load", blink, false);
        else if (window.attachEvent) window.attachEvent("onload", blink);
        else window.onload = blink;
        </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <div class="panel panel-default text-center">
                <div class="panel-body">
                    <h3 class="text-center text-center margin-none">Absence Notification
                    </h3>
                    <p></p>
                    <asp:Label ID="lblAbsenceSent" CssClass="label label-success" runat="server"></asp:Label>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <%--<form class="form-horizontal" role="form">
                          <div class="form-group">
                            <label class="col-sm-5 control-label">Date</label>
                             <div class="col-sm-9">
                                <input id="datepicker" type="text" class="form-control datepicker">
                             </div>
                          </div>
                         <div class="form-group">
                          <label class="col-sm-5 control-label">Reason</label>
                          <div class="col-sm-9">
                            <textarea class="form-control" rows="3"></textarea>
                          </div>
                        </div>
                        <div class="form-group">
                          <label class="col-sm-5 control-label">Comments</label>
                          <div class="col-sm-9">
                            <textarea class="form-control" rows="5"></textarea>
                          </div>
                        </div>
                        
                       
                      </form>--%>

                            <div class="row">
                                <div class="col-md-12">

                                    <div class="form-group form-control-default">
                                        <label for="exampleInputFirstName" class="pull-left">
                                            Date<asp:RequiredFieldValidator ID="reqdate" ControlToValidate="datepicker" ErrorMessage="&nbsp;Please select a date" runat="server"></asp:RequiredFieldValidator>
                                        </label>
                                        <input id="datepicker" runat="server" type="text" class="form-control datepicker" placeholder="Click here to pick date from calendar">
                                    </div>
                                </div>

                                <div class="col-md-12">
                                    <div class="form-group form-control-default">
                                        <label for="exampleInputFirstName" class="pull-left">
                                            Reason<asp:RequiredFieldValidator ID="reqReason" ControlToValidate="textreason" ErrorMessage="&nbsp;Please type a Reason" runat="server"></asp:RequiredFieldValidator>
                                        </label>
                                        <textarea class="form-control" id="textreason" maxlength="250" runat="server" rows="2" placeholder="ie: Sick leave, personal day"></textarea>
                                    </div>
                                </div>

                                <div class="col-md-12">

                                    <div class="form-group form-control-default">
                                        <label for="exampleInputFirstName" class="pull-left">
                                            Comments<asp:RequiredFieldValidator ID="reqComment" ControlToValidate="textcomment" ErrorMessage="&nbsp;Please type a brief comment" runat="server"></asp:RequiredFieldValidator>
                                        </label>
                                        <textarea class="form-control" maxlength="250" id="textcomment" rows="2" runat="server" placeholder="ie: What is impeeding you from working"></textarea>
                                    </div>
                                </div>

                            </div>
                            <asp:Button ID="btnSendRequest" runat="server" OnClick="btnSendRequest_Click" class="btn btn-primary" Text="Send Request" />


                        </div>
                    </div>
                </div>


            </div>
    </div>
    </form>
                            <script id="tk-modal-demo" type="text/x-handlebars-template">
        <div class="modal fade{{#if modalOptions}} {{ modalOptions }}{{/if}}" id="{{ id }}">
            <div class="modal-dialog{{#if dialogOptions}} {{ dialogOptions }}{{/if}}">
                <div class="v-cell">
                    <div class="modal-content{{#if contentOptions}} {{ contentOptions }}{{/if}}">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Refer a friend</h4>
                        </div>
                        <div class="modal-body">
                            Please use this form to inform us of a friend that you would like to refer to a job.
                     <div class="panel panel-default">
                         <div class="panel-body">
                             <form class="form-horizontal" method="post" enctype="multipart/form-data">
                                 <div class="form-group">
                                     <label for="text" class="col-sm-3 control-label">Full Name</label>
                                     <div class="col-sm-9">
                                         <input type="text" id="txtname" name="txtname" class="form-control" runat="server">
                                     </div>
                                 </div>
                                 <div class="form-group">
                                     <label for="text" class="col-sm-3 control-label">Phone</label>
                                     <div class="col-sm-9">
                                         <input type="text" id="txtphone" name="txtphone" class="form-control">
                                     </div>
                                 </div>
                                 <div class="form-group">
                                     <label for="text" class="col-sm-3 control-label">Email</label>
                                     <div class="col-sm-9">
                                         <input type="text" id="txtemail" name="txtemail" class="form-control">
                                     </div>
                                 </div>
                                 <div class="form-group">
                                     <label for="text" class="col-sm-3 control-label">Job Name</label>
                                     <div class="col-sm-9">
                                         <input type="text" id="txtjob" name="txtjob" class="form-control" rows="5"></input>
                                     </div>
                                 </div>
                                 <div class="form-group">
                                     <label class="col-sm-3 control-label">Resume</label>
                                     <div class="col-sm-9">
                                         <%--<input type="file" id="fileresume" runat="server" name="fileresume" class="form-control" data-defaultvalue="#25ad9f">
                --%>                    <INPUT type=file id=fileresume name=fileresume runat="server" />
                                      


                                     </div>
                                 </div>
                                 <div class="form-group">
                                     <label class="col-sm-3 control-label">Other Comments</label>
                                     <div class="col-sm-9">
                                         <textarea class="form-control" id="txtcomnt" name="txtcomnt" rows="5"></textarea>
                                     </div>
                                 </div>
                                  <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            <input type="submit" class="btn btn-primary" id="Send2" name="Send2" value="Send" />
                          
                        </div>
                             </form>
                         </div>
                     </div>
                        </div>
                       
                    </div>
                </div>
            </div>
        </div>
    </script>
</body>
</html>
