<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Client_Job_Detail_Add_Email.aspx.cs" Inherits="Client_Job_Detail_Add_Email" %>

<!DOCTYPE html>
<html class="st-layout ls-top-navbar ls-bottom-footer show-sidebar sidebar-l2" lang="en">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <link rel='stylesheet prefetch' href='http://ajax.googleAPIs.com/ajax/libs/jqueryui/1.11.2/themes/smoothness/jquery-ui.css'>
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
    <!-- <link href="css/app/colors-calendar.css" rel="stylesheet" /> -->
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

</head>
<body>
    <form id="form1" runat="server">
            <div class="st-container">


            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="media">
                        <div class="media-body">
                            <div class="pull-right text-muted">
                                <i class="fa fa-calendar"></i>
                                <strong>
                                    <asp:Label ID="lblPostingDate" runat="server"></asp:Label>
                                </strong>
                            </div>
                            <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Title
                            </b></h4>
                            <br />
                            <h4 class="media-heading margin-v-5">
                                <asp:Label ID="lbljobtitle" runat="server"></asp:Label>
                                <font color="red">
                            <asp:label id="lblUrgent" runat="server"></asp:label>
                        </font>
                            </h4>
                            <br />

                            <table class="table" cellspacing="0" width="100%">
                                <tr>
                                    <td>No of Openings :
                                                        
                            <asp:Label ID="lblnoofopning" runat="server"></asp:Label>
                                    </td>

                                    <td>Start Date :
                                                       
                            <asp:Label ID="lblstartdate" runat="server"></asp:Label>
                                    </td>
                                    <td>End Date :
                                                      
                            <asp:Label ID="lblenddate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr id="y" runat="server">
                                    <td>Address :
                                                         
                            <asp:Label ID="lbladdress2" runat="server"></asp:Label>
                                    </td>
                                    <td>Location :
                           
                            <asp:Label ID="lbllocation2" runat="server"></asp:Label>
                                    </td>
                                    <td>Bill Rate :
                                 $<asp:Label ID="lblbill" runat="server"></asp:Label>
                                    </td>

                                </tr>
                                <tr id="x" runat="server">
                                    <td>Address :
                                                      
                            <asp:Label ID="lbladdres" runat="server"></asp:Label>
                                    </td>
                                    <td>Location :
                           
                            <asp:Label ID="lbllocation" runat="server"></asp:Label>
                                    </td>
                                    <td>Pay Rate :
                                 $<asp:Label ID="lblpay2" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                            </table>
                            <%-- <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Add Candidate" OnClick="Button1_Click" />--%>
                            <%-- <asp:Label ID="lblNumberofPOsitions" runat="server"></asp:Label>
                    <div class="text-default">
                        Location:
                        <asp:Label ID="lblLocation" runat="server"></asp:Label>
                    </div>--%>
                        </div>

                    </div>
                </div>
            </div>

            <div class="split-vertical-body">

                <div class="split-vertical-cell">

                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="data-scrollable">
                                <div class="overflow-hidden">
                                    <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Description</b><span style="float: right">
                                        <%-- <asp:Button ID="btnadd" runat="server" Text="Add New" data-toggle="tk-modal-demo" data-modal-options="slide-down" data-content-options="modal-lg" class="btn btn-primary" OnClick="btnadd_Click" />--%>
                                    </span></h4>
                                    <%-- <h4 class="media-heading margin-v-5">Job Description<b></b></h4>--%>
                                    <p class="media-heading margin-v-5">&nbsp;</p>
                                    <asp:Label ID="lblJobDescription" runat="server"></asp:Label>
                                    <br />

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="split-vertical-body">

                <div class="split-vertical-cell">

                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div>
                                <div class="overflow-hidden">
                                    <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Comments</b><span style="float: right">
                              
                                    </span></h4>
                                    <p class="media-heading margin-v-5">&nbsp;</p>
                                    <asp:Label ID="lblcomments" runat="server"></asp:Label>
                                    <br />
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="divstar" runat="server">
                <div class="split-vertical-body">

                    <div class="split-vertical-cell">

                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div>
                                    <div class="overflow-hidden">
                                        <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Rating</b><span style="float: right">
                                
                                        </span></h4>
                                        <div id="questions1">
                                            <div class="form-group col-md-6">
                                                <h5>Question #1 </h5>
                                                <asp:Label ID="lblque1" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <h5>Minimum Rating Needed (out of 10)</h5>
                                                <asp:TextBox ID="txtRating1" ReadOnly name="txtRating1" class="rating rating10" value="3" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12">
                                        </div>
                                        <div id="questions2">
                                            <div class="form-group col-md-6">
                                                <h5>Question #2</h5>
                                                <asp:Label ID="labque2" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <h5>Minimum Rating Needed</h5>
                                                <asp:TextBox ID="txtRating2" ReadOnly name="txtRating2" class="rating rating10" value="3" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12">
                                        </div>
                                        <div id="questions3">
                                            <div class="form-group col-md-6">
                                                <h5>Question #3</h5>
                                                <asp:Label ID="lblque3" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <h5>Minimum Rating Needed</h5>
                                                <asp:TextBox ID="txtRating3" ReadOnly name="txtRating3" class="rating rating10" value="3" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12">
                                        </div>
                                        <div id="questions4">
                                            <div class="form-group col-md-6">
                                                <h5>Question #4</h5>
                                                <asp:Label ID="lblque4" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <h5>Minimum Rating Needed</h5>
                                                <asp:TextBox ID="txtRating4" ReadOnly name="txtRating4" class="rating rating10" value="3" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group col-md-12">
                                        </div>
                                        <div id="questions5">
                                            <div class="form-group col-md-6">
                                                <h5>Question #5</h5>
                                                <asp:Label ID="lblque5" runat="server"></asp:Label>
                                            </div>
                                            <div class="form-group col-md-4">
                                                <h5>Minimum Rating Needed</h5>
                                                <asp:TextBox ID="txtRating5" ReadOnly name="txtRating5" class="rating rating10" value="3" runat="server" />
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>


            <div class="split-vertical-body">

                <div class="split-vertical-cell">

                    <div class="panel panel-default">
                        <div class="panel-body">

                            <div class="col-md-2 col-md-offset-5">
                                <asp:Button ID="Button1" runat="server" Text="Edit Job" class="btn btn-primary" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="split-vertical-body">

                <div class="split-vertical-cell">

                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div>
                                <div class="overflow-hidden">
                                    <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Candidates Submitted</b><span style="float: right">
                                 
                                    </span></h4>
                                </div>

                                <div class="table-responsive">
                                    <table id="tbl123" class="table v-middle">
                                        <thead>
                                            <tr>
                                                <th>Date</th>
                                                <th>Name</th>
                                                <th>Email</th>
                                                <th>Location</th>
                                                <th>Status</th>
                                                <th>Pay Rate</th>
                                                <th>Resume</th>
                                                <th>action</th>
                                            </tr>
                                        </thead>

                                        <asp:Label ID="lblTableData" runat="server"></asp:Label>
                                    </table>
                                    <br />

                                </div>
                            </div>
                            <!-- // Progress table -->
                        </div>
                    </div>
                </div>
            </div>


            <% if (Request["more"] != null)
                {
            %>
            <label id="moredetails" visible="false" style="visibility: hidden" data-toggle="modal" data-target="#modal-more" class="btn btn-primary"></label>
            <% } %>

            <% if (Request["done"] != null)
                {
            %>

            <label id="approve" style="visibility: hidden" data-toggle="modal" data-target="#modal-select" class="btn btn-primary"></label>


            <% } %>
            <% if (Request["Reject"] != null)
                { %>

            <label id="rejected" style="visibility: hidden" data-toggle="modal" data-target="#modal-reject" class="btn btn-primary"></label>

            <% } %>
        </div>




        <div class="modal slide-down fade" id="modal-reject">
            <div class="modal-dialog">
                <div class="v-cell">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Reject Candidate</h4>
                        </div>
                        <form name="form2" method="post" action="client_job_emp_actions.aspx">
                            <div class="modal-body">
                                <div class="panel-body">

                                    <p>Please enter your comments below as to why this candidate has been rejected</p>

                                    <div class="col-sm-12">


                                        <textarea id="txtComments1" name="txtComments1" class="form-control" rows="5" cols="5"></textarea>

                                        <% if (Request["Reject"] != null)
                                            { %>
                                        <input type="hidden" name="Reject" value="<%=Request["Reject"].ToString() %>" />
                                        <input type="hidden" name="jobID" value="<%=Request["jobID"].ToString() %>" />

                                        <% } %>
                                    </div>

                                </div>

                            </div>
                            <div class="modal-footer">

                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                                <input type="submit" class="btn btn-primary" id="Send1" name="Send1" value="Reject" />
                                <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit1" data-dismiss="modal" >Send Request</button>-->
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal slide-down fade" id="modal-more">
            <div class="modal-dialog">
                <div class="v-cell">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Request more details</h4>
                        </div>
                        <form name="form3" method="post" action="client_job_emp_actions.aspx">
                            <div class="modal-body">
                                <div class="panel-body">

                                    <p>Type below the details you need answered to proceed</p>

                                    <div class="col-sm-12">

                                        <textarea id="txtComments2" name="txtComments2" class="form-control" rows="5"></textarea>

                                        <% if (Request["more"] != null)
                                            { %>
                                        <input type="hidden" name="more" value="<%=Request["more"].ToString() %>" />
                                        <input type="hidden" name="jobID" value="<%=Request["jobID"].ToString() %>" />
                                        <% } %>
                                    </div>

                                </div>

                            </div>
                            <div class="modal-footer">

                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                                <input type="submit" class="btn btn-primary" id="Send2" name="Send2" value="Send" />
                                <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit2" data-dismiss="modal" >Send Request</button>-->
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal slide-down fade" id="modal-select">
            <div class="modal-dialog">
                <div class="v-cell">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Request for an Interview</h4>
                        </div>
                        <form name="form3" method="post" action="client_job_emp_actions.aspx">
                            <div class="modal-body">
                                <div class="panel-body">

                                    <p>Please pick a date and time when you would like to interview this candidate</p>

                                    <div class="col-sm-10">
                                        <div>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <input type="text" class="form-control datepicker" name="DP1" id="DP2">
                                                    </td>
                                                    <td>
                                                        <select id="DDLT1" name="DDLT1" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                                            <option value="0:00 AM">Select a Time</option>
                                                            <option value="1:00 AM">1:00 AM</option>
                                                            <option value="2:00 AM">2:00 AM</option>
                                                            <option value="3:00 AM">3:00 AM</option>
                                                            <option value="4:00 AM">4:00 AM</option>
                                                            <option value="5:00 AM">5:00 AM</option>
                                                            <option value="6:00 AM">6:00 AM</option>
                                                            <option value="7:00 AM">7:00 AM</option>
                                                            <option value="8:00 AM">8:00 AM</option>
                                                            <option value="9:00 AM">9:00 AM</option>
                                                            <option value="10:00 AM">10:00 AM</option>
                                                            <option value="11:00 AM">11:00 AM</option>
                                                            <option value="12:00 AM">12:00 PM</option>
                                                            <option value="1:00 PM">1:00 PM</option>
                                                            <option value="2:00 PM">2:00 PM</option>
                                                            <option value="3:00 PM">3:00 PM</option>
                                                            <option value="4:00 PM">4:00 PM</option>
                                                            <option value="5:00 PM">5:00 PM</option>
                                                            <option value="6:00 PM">6:00 PM</option>
                                                            <option value="7:00 PM">7:00 PM</option>
                                                            <option value="8:00 PM">8:00 PM</option>
                                                            <option value="9:00 PM">9:00 PM</option>
                                                            <option value="10:00 PM">10:00 PM</option>
                                                            <option value="11:00 PM">11:00 PM</option>
                                                            <option value="12:00 AM">12:00 PM</option>
                                                        </select></td>


                                                </tr>

                                            </table>
                                            <br />
                                            <p>OR</p>
                                            <%-- OR   <input type="checkbox" name="chkapprove" id="chkapprove" value="yes"> Approve--%>
                                            <div class="checkbox checkbox-success">
                                                <input id="chkapprove" type="checkbox" name="chkapprove" value="yes">
                                                <label for="chkapprove">Approve Candidate</label>
                                            </div>
                                        </div>

                                        <% if (Request["done"] != null)
                                            { %>
                                        <input type="hidden" name="approve" value="<%=Request["done"].ToString() %>" />
                                        <input type="hidden" name="jobID" value="<%=Request["jobID"].ToString() %>" />
                                        <% } %>
                                    </div>

                                </div>

                            </div>
                            <div class="modal-footer">

                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                                <input type="submit" class="btn btn-primary" id="Send3" name="Send3" value="Send" />
                                <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit3" data-dismiss="modal" >Send Request</button>-->
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>

        </div>
    </form>
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

    <!-- Vendor Scripts Bundle
    Includes all of the 3rd party JavaScript libraries above.
    The bundle was generated using modern frontend development tools that are provided with the package
    To learn more about the development process, please refer to the documentation.
    Do not use it simultaneously with the separate bundles above. -->
    <script src="js/vendor/all.js"></script>

    <!-- Vendor Scripts Standalone Libraries -->
    <!-- <script src="js/vendor/core/all.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.js"></script> -->
    <!-- <script src="js/vendor/core/bootstrap.js"></script> -->
    <!-- <script src="js/vendor/core/breakpoints.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.nicescroll.js"></script> -->
    <!-- <script src="js/vendor/core/isotope.pkgd.js"></script> -->
    <!-- <script src="js/vendor/core/packery-mode.pkgd.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.grid-a-licious.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.cookie.js"></script> -->
    <!-- <script src="js/vendor/core/jquery-ui.custom.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.hotkeys.js"></script> -->
    <!-- <script src="js/vendor/core/handlebars.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.hotkeys.js"></script> -->
    <!-- <script src="js/vendor/core/load_image.js"></script> -->
    <!-- <script src="js/vendor/core/jquery.debouncedresize.js"></script> -->
    <!-- <script src="js/vendor/tables/all.js"></script> -->
    <!-- <script src="js/vendor/forms/all.js"></script> -->
    <!-- <script src="js/vendor/media/all.js"></script> -->
    <!-- <script src="js/vendor/player/all.js"></script> -->
    <!-- <script src="js/vendor/charts/all.js"></script> -->
    <!-- <script src="js/vendor/charts/flot/all.js"></script> -->
    <!-- <script src="js/vendor/charts/easy-pie/jquery.easypiechart.js"></script> -->
    <!-- <script src="js/vendor/charts/morris/all.js"></script> -->
    <!-- <script src="js/vendor/charts/sparkline/all.js"></script> -->
    <!-- <script src="js/vendor/maps/vector/all.js"></script> -->
    <!-- <script src="js/vendor/tree/jquery.fancytree-all.js"></script> -->
    <!-- <script src="js/vendor/nestable/jquery.nestable.js"></script> -->
    <!-- <script src="js/vendor/angular/all.js"></script> -->

    <!-- App Scripts Bundle
    Includes Custom Application JavaScript used for the current theme/module;
    Do not use it simultaneously with the standalone modules below. -->

    <script src="js/app/app.js"></script>

    <!-- App Scripts Standalone Modules
    As a convenience, we provide the entire UI framework broke down in separate modules
    Some of the standalone modules may have not been used with the current theme/module
    but ALL the modules are 100% compatible -->

    <!-- <script src="js/app/essentials.js"></script> -->
    <!-- <script src="js/app/layout.js"></script> -->
    <!-- <script src="js/app/sidebar.js"></script> -->
    <!-- <script src="js/app/media.js"></script> -->
    <!-- <script src="js/app/player.js"></script> -->
    <!-- <script src="js/app/timeline.js"></script> -->
    <!-- <script src="js/app/chat.js"></script> -->
    <!-- <script src="js/app/maps.js"></script> -->
    <!-- <script src="js/app/charts/all.js"></script> -->
    <!-- <script src="js/app/charts/flot.js"></script> -->
    <!-- <script src="js/app/charts/easy-pie.js"></script> -->
    <!-- <script src="js/app/charts/morris.js"></script> -->
    <!-- <script src="js/app/charts/sparkline.js"></script> -->

    <!-- log out stuff -->
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>
    <script src='http://ajax.googleAPIs.com/ajax/libs/jqueryui/1.11.2/jquery-ui.min.js'></script>
    <script src="js/index.js"></script>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/rateYo/2.2.0/jquery.rateyo.min.css">
    <!-- Latest compiled and minified JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/rateYo/2.2.0/jquery.rateyo.min.js"></script>

    <script>
        function populateSecondTextBox() {
            // alert ("hello");
            document.getElementById("txtstd_pay_rate_from").value =
                (document.getElementById("txtdbl_pay_rate_from").value) * 2;


        }

    </script>
    <script type="text/javascript" src="jquery.js"></script>
    <script type="text/javascript" src="rating.js"></script>
    <script type="text/javascript" src="nanobar.js"></script>
    <link rel="stylesheet" type="text/css" href="rating.css" />
    <script type="text/javascript">
        $(function () {
            $('.rating').rating();

            $('.ratingEvent').rating({ rateEnd: function (v) { $('#result').text(v); } });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {

            <% if (Request["action"] != null) %>
            <% { %>
            document.getElementById("timesheetaction").click();
            <% } %>
            //following code is for rescheduling interview pop-up
            <% if (Request["action_id"] != null) %>
            <% { %>
            document.getElementById("reshedule_int").click();
            <% } %>
            <% if (Request["action2"] != null) %>
            <% { %>
            document.getElementById("timesheetaction2").click();
            <% } %>

           <% if (Request["done"] != null)
        { %>
            document.getElementById("approve").click();
             <% }

        if (Request["Reject"] != null)

        {%>
            document.getElementById("rejected").click();
             <% }
        else
               if (Request["More"] != null)

        {%>
            document.getElementById("moredetails").click();
            <% } %>
            <% if (Request["moreinfomsg"] != null) %>
            <% { %>
            document.getElementById("more_info_msg_show").click();
            <% } %>
            <% if (Request["moreinfomsg1"] != null) %>
            <% { %>
            document.getElementById("interveiw_schedule2").click();
            <% } %>
            <% if (Request["moreinfomsg2"] != null) %>
            <% { %>
            document.getElementById("reject_candidate2").click();
            <% } %>

        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            document.getElementById("xyz").click();
            alert("hello2");
        });

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
    <script type="text/javascript">
        var options = {
            classname: 'my-class',
            id: 'my-id',
            target: document.getElementById('myDivId')
        };

        var nanobar = new Nanobar(options);

        // move bar
        nanobar.go(30); // size bar 30%
        nanobar.go(76); // size bar 76%

        // size bar 100% and and finish
        nanobar.go(100);

    </script>


    </form>
     <script>
         function gotoFunction(sEvent) {
             var x = document.getElementById("magicselect").value;
             if (x == "Jobs") {
                 document.location.href = 'Client_View_jobs.aspx?jopen=Y&p=JV';
             }


             if (x == "TimeSheets") {
                 document.location.href = 'Timesheet_View.aspx?topen=Y&p=VT';
             }


             if ((x != "TimeSheets") && (x != "Jobs")) {
                 document.location.href = x;
             }

         }

     </script>



</body>

</html>
