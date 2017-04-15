<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="Client_Job_Details.aspx.cs" Inherits="Client_Job_Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="panel panel-default ribbon-wrapper ribbon-corner-wrapper ">
        <div class="panel-body">
            <div class="media">
                <div class="media-body">
                    <h4 class="text-center" style="color: #0080FF"><b>Job Details</b></h4>
                    <br>
                    <div class="pull-right text-muted">
                        <div class="ribbon-corner right">
                            <a href="Client_job_Details.aspx?cCMNT=1&jobID=<%=Request.QueryString["jobID"].ToString() %>">Client's Comment</a>
                                                    </div>
                    </div>
                    <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Title
                    </b></h4>
                    <br />
                    <h4 class="media-heading margin-v-5">
                        <asp:Label ID="lbljobtitle" runat="server"></asp:Label>
                        <font color="red">
                            <blink><asp:label  id="lblUrgent"  runat="server"></asp:label></blink>
                        </font>- 
                        Position 
                       
                        <asp:Label ID="lblpositiontype" runat="server"></asp:Label>
                        <%-- Created on
                        <i class="fa fa-calendar"></i>
                     
                            <asp:Label ID="lblPostingDate" runat="server"></asp:Label>--%>
                       
                        
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
                        <tr id="w" runat="server">
                            <td>Address :
                                                      
                           

                                <asp:Label ID="lbladdress3" runat="server"></asp:Label>
                            </td>
                            <td>Location :
                           
                           

                                <asp:Label ID="lbllocation3" runat="server"></asp:Label>
                            </td>
                            <td>Base Salary :
                                 $<asp:Label ID="lblsalary" runat="server"></asp:Label>
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

                    <div>

                        <asp:Button ID="Button1" runat="server" Text="Edit Job" class="btn btn-primary pull-left" OnClick="Button1_Click" />

                        <input id="btnDeletejob" type="button" class="btn btn-danger pull-right" data-toggle="modal" data-target="#modal-delete-job" value="Delete Job" />
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
                                        <th>Action</th>
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


     <% if (Request["c_jobchat"] != null)
            { %>

        <label id="forchat" style="visibility: hidden" data-toggle="modal" data-target="#modal-jobDetaisChat" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["job_done"] != null)
            {
        %>

        <label id="approve_job" style="visibility: hidden" data-toggle="modal" data-target="#modal-select" class="btn btn-primary"></label>


        <% } %>
      <% if (Request["job_Reject"] != null)
            {
        %>

        <label id="reject_job" style="visibility: hidden" data-toggle="modal" data-target="#modal-reject1" class="btn btn-primary"></label>


        <% } %>
     <% if (Request["Resch_int1"] != null)
            { %>

        <label id="reshedule_inter" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewREs" class="btn btn-primary"></label>

        <% } %>
      <% if (Request["reject_reasonbyVendor"] != null)
            { %>

        <label id="reasonRejection" style="visibility: hidden" data-toggle="modal" data-target="#modal-reasonofrejection" class="btn btn-primary"></label>

        <% } %>
       <% if (Request["u"] != null)
            { %>

        <label id="job_update" style="visibility: hidden" data-toggle="modal" data-target="#update_job" class="btn btn-primary"></label>

        <% } %>
      <% if (Request["c_confirm1"] == "1")
            { %>

        <label id="candApprove_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-confirm_cj1" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["c_confirm2"] == "1")
            { %>

        <label id="candInterview_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-interview_cj1" class="btn btn-primary"></label>

        <% } %>
      <% if (Request["c_confirm3"] == "1")
            { %>

        <label id="candReject_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-reject_cj" class="btn btn-primary"></label>

        <% } %>
      <% if (Request["c_confirm4"] == "1")
            { %>

        <label id="candaprov_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-aprove_cj" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["c_confirm5"] == "1")
            { %>

        <label id="candrejct_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-rejct_cj" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["c_confirm6"] == "1")
            { %>

        <label id="cancelint_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-cancelInt_cj" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["c_confirm7"] == "1")
            { %>

        <label id="ReschInt_cj" style="visibility: hidden" data-toggle="modal" data-target="#modal-ReschInt" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["cCMNT"] != null)
        { %>

    <label id="client_comment" style="visibility: hidden" data-toggle="modal" data-target="#modal-cComments" class="btn btn-primary"></label>

    <% } %>
     <div class="modal slide-down fade" id="modal-cComments">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Client Comments</h4>
                    </div>

                    <div class="modal-body">
                        <div class="panel-body">

                            <div class="col-sm-12">
                                <h4 class="modal-title">Previous Comment:
                                    <asp:Label ID="lblcommenttime" runat="server"></asp:Label></h4>
                                <textarea readonly id="Txtarea_client_comment" runat="server" cols="100" rows="5" class="form-control"></textarea><br>
                                <hr />
                                <h4 class="modal-title">Add a new comment  <small>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ValidationGroup="rfvclientcomment" ControlToValidate="Txtarea_client_new_commnt" runat="server" Text="* Required"></asp:RequiredFieldValidator></small>
                                </h4>
                                <textarea id="Txtarea_client_new_commnt" runat="server" validationgroup="rfvclientcomment" cols="100" rows="5" class="form-control"></textarea>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="brnAddNewComment" ValidationGroup="rfvclientcomment" class="btn btn-primary" OnClick="brnAddNewComment_Click" runat="server" Text="Send" />
                        <%-- <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Reject" OnClick="btnReject_Click" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit91" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
      <div class="modal slide-down fade" id="modal-ReschInt">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Interview Reschedule</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to reschedule interview with following schedule:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblReschCand" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblReschJOB" runat="server" Text="Label"></asp:Label>
                            Schedule:&nbsp<asp:Label ID="lblReschSCh" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="rescheduleINT" runat="server" onclick="rescheduleINT_Click" class="btn btn-primary" Text="Reschedule" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-cancelInt_cj">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Cancel Interview</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to cancel interview with following details:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblCancelIntcand" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblcancelIntJob" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnCancelINt" runat="server" onclick="btnCancelINt_Click" class="btn btn-primary" Text="Cancel" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-rejct_cj">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Reject Candidate</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to reject candidate with following details:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblrejctCand" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="LblRejctJob" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnRejectCandidate_cj" runat="server" onclick="btnRejectCandidate_cj_Click" class="btn btn-primary" Text="Reject" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
      <div class="modal slide-down fade" id="modal-aprove_cj">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Approve Candidate</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to confirm candidate with following details:<br>
                            Candidate Name:&nbsp<asp:Label ID="lblaprove" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblaprovejob" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnaprovCandidate" runat="server" OnClick="btnaprovCandidate_Click" class="btn btn-primary" Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-reject_cj">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Reject Candidate</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to reject candidate with following details:<br>
                            Candidate Name:&nbsp<asp:Label ID="lblRejectname" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblRejectJobTitle" runat="server" Text="Label"></asp:Label><br>
                            


                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                 

                        <asp:Button ID="btnreject_c" onclick="btnreject_c_Click" runat="server" class="btn btn-primary" Text="Reject" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
      <div class="modal slide-down fade" id="modal-interview_cj1">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Schedule an Interview</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to schedule interview with following details:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblInterviewCJ" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblJbtitleCJ" runat="server" Text="Label"></asp:Label><br>
                             Schedule:&nbsp<asp:Label ID="lblscheduleCJ" runat="server" Text="Label"></asp:Label>


                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                      <%--  <asp:Button ID="btnscheduleintCJ" runat="server" OnClick="btnscheduleintCJ_Click" class="btn btn-primary" Text="Send" />--%>

                        <asp:Button ID="btnIntscheduleCJ" OnClick="btnIntscheduleCJ_Click" runat="server" class="btn btn-primary" Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
       <div class="modal slide-down fade" id="modal-confirm_cj1">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Approve Candidate</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to confirm candidate with following details:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblAprvename" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblaprvejob" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnApprove_cj" runat="server" OnClick="btnApprove_cj_Click" class="btn btn-primary" Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="modal slide-down fade" id="modal-delete-job">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Delete The Job</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                           Are you sure, you want to delete the job?

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="Button2" Onclick="btndeletejob_Click" class="btn btn-danger" runat="server" Text="Delete" />

                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="modal slide-down fade" id="update_job">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Updated successfully</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                       Job has been  updated successfully.

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                       

                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
      <div class="modal slide-down fade" id="modal-reasonofrejection">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Reason Of Rejection</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                            <asp:Label ID="rejection_reason" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    
      <div class="modal slide-down fade" id="modal-interviewREs">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h3 class="modal-title">Worker Actions</h3>
                    </div>
                    <div class="modal-body">
                        <table style="width: 700px; height: 400px; border: thin; border-color: gray">
                            <tr>
                                <td valign="top" style="width: 400px">

                                    <h5 style="resize: 6"><u>INTERVIEW DETAILS</u></h5>
                                    <br>
                              
                                 
                                Candidate Name :<asp:Label ID="lblCandidateRE" runat="server" Text="Label"></asp:Label>
                                    <br>
                                    Job Title : <asp:Label ID="lbljobRE" runat="server" Text="Label"></asp:Label>
                                    <br>
                                    Schedule : <asp:Label ID="LblScheduleRE" runat="server" Text="Label"></asp:Label>
                              </td>

                                <td rowspan="2" valign="top" style="width: 400px; height: 400px">
                                    <table style="width: 400px; height: 400px">
                                        <tr>
                                            <td valign="top" align="center">
                                                <h5><u>RESCHEDULE</u></h5>
                                                <div class="col-sm-12">
                                                    <p>Please pick a date and time when you would like to interview this candidate</p>
                                                    <div>
                                                        <table>
                                                            <tr>
                                                                <td>

                                                                    <input type="text" class="form-control datepicker" validationgroup="rfvINTSCHEDULE" onkeypress="return isNumberKey(event)" id="TxtNewdate1" runat="server" name="TxtNewdate" placeholder="Choose a date">
                                                                </td>
                                                                <td></td>
                                                                <td style="margin-left: 5px">

                                                                    <asp:DropDownList ID="DDnewtime1" runat="server" AppendDataBoundItems="true" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                                                        <asp:ListItem Text="--select one--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="1:00 AM" Value="1:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:15 AM" Value="1:15 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="1:30 AM" Value="1:30 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="1:45 AM" Value="1:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:00 AM" Value="2:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:15 AM" Value="2:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:30 AM" Value="2:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:45 AM" Value="2:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:00 AM" Value="3:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:15 AM" Value="3:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:30 AM" Value="3:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:45 AM" Value="3:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:00 AM" Value="4:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:15 AM" Value="4:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:30 AM" Value="4:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:45 AM" Value="4:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:00 AM" Value="5:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:15 AM" Value="5:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:30 AM" Value="5:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:45 AM" Value="5:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:00 AM" Value="6:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:15 AM" Value="6:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:30 AM" Value="6:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:45 AM" Value="6:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:00 AM" Value="7:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:15 AM" Value="7:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:30 AM" Value="7:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:45 AM" Value="7:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:00 AM" Value="8:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:15 AM" Value="8:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:30 AM" Value="8:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:45 AM" Value="8:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:00 AM" Value="9:00 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="9:15 AM" Value="9:15 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="9:30 AM" Value="9:30 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="9:45 AM" Value="9:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:00 AM" Value="10:00 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="10:15 AM" Value="10:15 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="10:30 AM" Value="10:30 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="10:45 AM" Value="10:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:00 AM" Value="11:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:15 AM" Value="11:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:30 AM" Value="11:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:45 AM" Value="11:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:00 PM" Value="12:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:15 PM" Value="12:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:30 PM" Value="12:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:45 PM" Value="12:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:00 PM" Value="1:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:15 PM" Value="1:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:30 PM" Value="1:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:45 PM" Value="1:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:00 PM" Value="2:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:15 PM" Value="2:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:30 PM" Value="2:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:45 PM" Value="2:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:00 PM" Value="3:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:15 PM" Value="3:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:30 PM" Value="3:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:45 PM" Value="3:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:00 PM" Value="4:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:15 PM" Value="4:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:30 PM" Value="4:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:45 PM" Value="4:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:00 PM" Value="5:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:15 PM" Value="5:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:30 PM" Value="5:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:45 PM" Value="5:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:00 PM" Value="6:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:15 PM" Value="6:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:30 PM" Value="6:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:45 PM" Value="6:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:00 PM" Value="7:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:15 PM" Value="7:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:30 PM" Value="7:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:45 PM" Value="7:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:00 PM" Value="8:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:15 PM" Value="8:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:30 PM" Value="8:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:45 PM" Value="8:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:00 PM" Value="9:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:15 PM" Value="9:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:30 PM" Value="9:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:45 PM" Value="9:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:00 PM" Value="10:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:15 PM" Value="10:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:30 PM" Value="10:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:45 PM" Value="10:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:00 PM" Value="11:00 PM"></asp:ListItem>
                                                                         <asp:ListItem Text="11:15 PM" Value="11:15 PM"></asp:ListItem>
                                                                         <asp:ListItem Text="11:30 PM" Value="11:30 PM"></asp:ListItem>
                                                                         <asp:ListItem Text="11:45 PM" Value="11:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:00 AM" Value="12:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="00:15 AM" Value="00:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="00:30 AM" Value="00:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="00:45 AM" Value="00:45 AM"></asp:ListItem> </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <asp:Button ID="btnRescdhle" OnClick="btnRescdhle_Click" class="btn btn-primary" runat="server" Text="Reschedule" />
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />

                                                <asp:Button ID="btnApproveCandidate" OnClick="btnApproveCandidate_Click" class="btn btn-default"  Height="70px" Width="400px" runat="server" Text="Approve Candidate" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />

                                                <asp:Button ID="btnRejectCandidate" onclick="btnRejectCandidate_Click" onmouseover="OnHover1(this);"  class="btn btn-default" Height="70px" Width="400px" runat="server" Text="Reject Candidate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />
                                                <asp:Button ID="btncancelINTErview" onclick="btncancelINTErview_Click" onmouseover="OnHover(this);" onmouseout="OnOut(this);" OnClientClick="javascript:alert('Are you sure you want to cancel Interview?');" class="btn btn-default" Height="70px" Width="400px" runat="server" Text="Cancel Interview" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                           &nbsp;  <tr>
                                 &nbsp&nbsp <td valign="right">

                                    <%-- <asp:TextBox TextMode="MultiLine" ReadOnly="true" ID="TextBox1" runat="server" Columns="1" Rows="5" CssClass="form-control"></asp:TextBox>
                                    --%>
                                 <asp:TextBox Height="270px" Width="250px" ID="txtAllchats" TextMode="MultiLine" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

                                </td>
                            </tr>
                        </table>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <%--<button type="button" class="btn btn-primary" data-dismiss="modal">Save</button>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-reject1">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Reject Candidate</h4>
                    </div>
                    <%--<form name="form2" method="post" action="test123.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                            <p>Please enter your comments below as to why this candidate has been rejected</p>

                            <div class="col-sm-12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="rfvREJECT" InitialValue="" SetFocusOnError="true" ControlToValidate="txtComments1" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" runat="server" ValidationGroup="rfvREJECT" ID="txtComments1" class="form-control" Rows="5" cols="5"></asp:TextBox>

                                <% if (Request["Reject"] != null)
                                    { %>
                                <input type="hidden" name="Rejected" value="<%=Request["Reject"].ToString() %>" />
                                <input type="hidden" name="job_id1" value="<%=Request["job_id"].ToString() %>" />
                                <input type="hidden" name="job_end_date1" value="<%=Request["job_end_date"].ToString() %>" />
                                <input type="hidden" name="emp_end_date1" value="<%=Request["emp_enddate"].ToString() %>" />
                                <% } %>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnReject" runat="server" class="btn btn-primary" ValidationGroup="rfvREJECT" Text="Reject" onclick="btnReject_Click" />
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit1" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%-- </form>--%>
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
                    <%--<form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">



                            <div class="col-sm-12">
                                <p>Please pick a date and time when you would like to interview this candidate</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="rfvINTERVIEW" InitialValue="" SetFocusOnError="true" ControlToValidate="Textdate" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                                <input type="text" class="form-control datepicker" onkeypress="return isNumberKey(event)" id="Textdate" runat="server" name="Textdate" placeholder="Choose a date">

                                                <%--<input type="text" class="form-control datepicker" name="DP1" id="DP1">--%>
                                                <%--<asp:TextBox ID="Textdate" class="form-control" placeholder="MM/DD/YYYY" runat="server"></asp:TextBox>
                                                --%>     </td>
                                            <td></td>
                                            <td style="margin-left: 5px">
                                                <asp:RequiredFieldValidator ID="time001" ValidationGroup="rfvINTERVIEW" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddtime" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>
                                                <asp:DropDownList ID="ddtime" runat="server" ValidationGroup="rfvINTERVIEW" CausesValidation="true" AppendDataBoundItems="true" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                                     <asp:ListItem Text="--select one--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="1:00 AM" Value="1:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:15 AM" Value="1:15 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="1:30 AM" Value="1:30 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="1:45 AM" Value="1:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:00 AM" Value="2:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:15 AM" Value="2:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:30 AM" Value="2:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:45 AM" Value="2:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:00 AM" Value="3:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:15 AM" Value="3:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:30 AM" Value="3:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:45 AM" Value="3:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:00 AM" Value="4:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:15 AM" Value="4:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:30 AM" Value="4:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:45 AM" Value="4:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:00 AM" Value="5:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:15 AM" Value="5:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:30 AM" Value="5:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:45 AM" Value="5:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:00 AM" Value="6:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:15 AM" Value="6:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:30 AM" Value="6:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:45 AM" Value="6:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:00 AM" Value="7:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:15 AM" Value="7:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:30 AM" Value="7:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:45 AM" Value="7:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:00 AM" Value="8:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:15 AM" Value="8:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:30 AM" Value="8:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:45 AM" Value="8:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:00 AM" Value="9:00 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="9:15 AM" Value="9:15 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="9:30 AM" Value="9:30 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="9:45 AM" Value="9:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:00 AM" Value="10:00 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="10:15 AM" Value="10:15 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="10:30 AM" Value="10:30 AM"></asp:ListItem>
                                                                         <asp:ListItem Text="10:45 AM" Value="10:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:00 AM" Value="11:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:15 AM" Value="11:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:30 AM" Value="11:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:45 AM" Value="11:45 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:00 PM" Value="12:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:15 PM" Value="12:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:30 PM" Value="12:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:45 PM" Value="12:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:00 PM" Value="1:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:15 PM" Value="1:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:30 PM" Value="1:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:45 PM" Value="1:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:00 PM" Value="2:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:15 PM" Value="2:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:30 PM" Value="2:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:45 PM" Value="2:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:00 PM" Value="3:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:15 PM" Value="3:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:30 PM" Value="3:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:45 PM" Value="3:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:00 PM" Value="4:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:15 PM" Value="4:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:30 PM" Value="4:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:45 PM" Value="4:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:00 PM" Value="5:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:15 PM" Value="5:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:30 PM" Value="5:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:45 PM" Value="5:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:00 PM" Value="6:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:15 PM" Value="6:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:30 PM" Value="6:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:45 PM" Value="6:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:00 PM" Value="7:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:15 PM" Value="7:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:30 PM" Value="7:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:45 PM" Value="7:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:00 PM" Value="8:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:15 PM" Value="8:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:30 PM" Value="8:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:45 PM" Value="8:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:00 PM" Value="9:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:15 PM" Value="9:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:30 PM" Value="9:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:45 PM" Value="9:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:00 PM" Value="10:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:15 PM" Value="10:15 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:30 PM" Value="10:30 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:45 PM" Value="10:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:00 PM" Value="11:00 PM"></asp:ListItem>
                                                                         <asp:ListItem Text="11:15 PM" Value="11:15 PM"></asp:ListItem>
                                                                         <asp:ListItem Text="11:30 PM" Value="11:30 PM"></asp:ListItem>
                                                                         <asp:ListItem Text="11:45 PM" Value="11:45 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:00 AM" Value="12:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="00:15 AM" Value="00:15 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="00:30 AM" Value="00:30 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="00:45 AM" Value="00:45 AM"></asp:ListItem>

                                                </asp:DropDownList>
                                                <%--  <select id="DDLT1" name="DDLT1" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
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
                                                    </select>--%></td>


                                        </tr>

                                    </table>
                                    <br />
                                    <br />



                                    <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvMOREINFO123" runat="server" ID="txtsubmitintervew" CssClass="form-control"></asp:TextBox>

                                    <br />



                                    <p>OR</p>
                                    <%-- OR   <input type="checkbox" name="chkapprove" id="chkapprove" value="yes"> Approve--%>


                                    <div>
                                        <asp:CheckBox ID="checkurgent" AutoPostBack="true" ValidationGroup="chekchek" runat="server" Checked="false" CssClass="checkbox-primary" />
                                        <%--<input type="checkbox" id="checkurgent" checked="checked">--%>&nbsp;
                                            <label for="checkurgent">Approve</label>
                                    </div>

                                </div>

                                <% if (Request["done"] != null)
                                    { %>
                                <input type="hidden" name="approve" value="<%=Request["done"].ToString() %>" />
                                <input type="hidden" name="job_id1" value="<%=Request["job_id"].ToString() %>" />
                                <input type="hidden" name="job_end_date1" value="<%=Request["job_end_date"].ToString() %>" />
                                <input type="hidden" name="emp_end_date1" value="<%=Request["emp_enddate"].ToString() %>" />

                                <% } %>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnsbmit" class="btn btn-primary" CausesValidation="true" ValidationGroup="rfvINTERVIEW" OnClick="btnsbmit_Click" runat="server" Text="Send" />
                        <%--<input type="submit" class="btn btn-primary" id="Send3" name="Send3" value="Send" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit3" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-jobDetaisChat">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Comments</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                            <asp:TextBox TextMode="MultiLine" ReadOnly="true" ID="txtfrstaction" runat="server" Columns="5" Rows="5" CssClass="form-control"></asp:TextBox>
                            <br>
                            <b>
                                <p>Type the comments</p>
                            </b>

                            <div class="col-sm-14">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator" ValidationGroup="rfvMOREINFO12" InitialValue="" SetFocusOnError="true" ControlToValidate="txtfrstaction2" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvMOREINFO12" runat="server" ID="txtfrstaction2" CssClass="form-control" Rows="5" cols="5"></asp:TextBox>

                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <%-- <asp:Button ID="btnFRSTaction" OnClick="btnFRSTaction_Click" ValidationGroup="rfvMOREINFO" class="btn btn-primary" runat="server" Text="Send" />--%>

                        <asp:Button ID="btnCOMMENTs" runat="server" class="btn btn-primary" Text="Send" OnClick="btnCOMMENTs_Click1" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
</asp:Content>