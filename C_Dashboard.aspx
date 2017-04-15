<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_Dashboard.aspx.cs" Inherits="C_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

   <div class="row">
   
        <div class="col-md-6 col-lg-6">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="C_Jobgrid.aspx" style="width: 100%; height: 284px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>

            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="C_TimesheetApproval.aspx" style="width: 100%; height: 283px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="C_feedback_request.aspx" style="width: 100%; height: 283px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
     
        <div class="col-md-6 col-lg-6">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="C_DayActivity.aspx" style="width: 100%; height: 600px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <asp:Timer ID="tm" Interval="90000" runat="server"></asp:Timer>


                    <div class="col-md-6 col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-body text-center">
                                <strong>Total Spend</strong>
                                <p class="lead text-primary margin-v-10">
                                    <strong>
                                        <asp:Label ID="lblJobCount" runat="server"></asp:Label></strong>
                                </p>
                                <a href="#" class="btn btn-success">By Worker&nbsp;<i class="fa fa-money"></i></a>
                            </div>
                            <div class="panel-footer  text-center">
                                <a href="#">Update as of <%=String.Format("{0:T}", DateTime.Now) %></a>
                            </div>
                        </div>
                    </div>
                    <script>
                        // request permission on page load
                        document.addEventListener('DOMContentLoaded', function () {
                            if (Notification.permission !== "granted")
                                Notification.requestPermission();
                        });

                        function notifyMe(jobid, numopenings, jobdesc) {
                            if (!Notification) {
                                alert('Desktop notifications not available in your browser. Try Chrome.');
                                return;
                            }

                            if (Notification.permission !== "granted")
                                Notification.requestPermission();
                            else {
                                var notification = new Notification('New Job Has Been Added', {
                                    icon: 'http://opusing.com/images/logo1.png',
                                    body: "A new job is now available: " + jobid + " with: " + numopenings + " position(s)...Click here for more details",
                                });

                                notification.onclick = function () {
                                    window.open("http://API:2012/Job_Details.aspx?jopen=Y&p=JV&jobID=" + jobid);
                                };

                            }
                        }
                    </script>

                    <div class="col-md-4 col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-body text-center">
                                <strong>This Week</strong>
                                <p class="lead text-primary margin-v-10">
                                    <strong>
                                        <asp:Label ID="lblInterviewCount" runat="server"></asp:Label></strong>
                                </p>
                                <a href="C_View_Interview.aspx?inopen=Y&p=IN" class="btn btn-warning text-center">Interviews<i class="fa fa-eye"></i></a>
                            </div>
                            <div class="panel-footer  text-center">
                                <a href="#">Update as of <%=String.Format("{0:T}", DateTime.Now) %></a>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-4 col-lg-4">
                        <div class="panel panel-default">
                            <div class="panel-body text-center">
                                <strong>Total</strong>
                                <p class="lead text-primary margin-v-10">
                                    <strong>
                                        <asp:Label ID="lblWorkers" runat="server"></asp:Label></strong>
                                </p>
                                <a href="#" class="btn btn-default  text-center">Workers&nbsp;<i class="fa  fa-user"></i></a>
                            </div>
                            <div class="panel-footer  text-center">
                                <a href="#">Update as of <%=String.Format("{0:T}", DateTime.Now) %></a>
                            </div>
                        </div>
                    </div>
                    <%--  <div class="col-md-3 col-lg-2">
            <div class="panel panel-default">
                <div class="panel-body text-center">
                     <strong>Total</strong>
                    <p class="lead text-primary margin-v-10">
                        <strong>
                            <asp:Label ID="lblNoFeedback" runat="server"></asp:Label></strong>
                    </p>
                    <a href="#" class="btn btn-white text-center">No Feedback&nbsp;<i class="fa fa-eye"></i></a>
                </div>

                   <div class="panel-footer  text-center">
                    <a href="#">Update as of <%=String.Format("{0:T}", DateTime.Now) %></a>
                </div>
            </div>
        </div>
        <div class="col-md-3 col-lg-2">
            <div class="panel panel-default">
                <div class="panel-body text-center">
                    <strong>This Week</strong>
                    <p class="lead text-primary  text-center margin-v-10">
                        <strong>
                            <asp:Label ID="lblTimeSheetAction" runat="server"></asp:Label></strong>
                    </p>
                    <a href="#" class="btn btn-primary text-center">TimeSheet Action&nbsp;<i class="fa  fa-calendar"></i></a>
                </div>
                <div class="panel-footer  text-center">
                    <a href="#">Update as of <%=String.Format("{0:T}", DateTime.Now) %></a>
                </div>
            </div>
        </div>
        <div class="col-md-3 col-lg-2">
            <div class="panel panel-default">
                <div class="panel-body text-center">
                     <strong>This Week</strong>
                    <p class="lead text-primary margin-v-10">
                        <strong>
                            <asp:Label ID="lblContractEnding" runat="server"></asp:Label></strong>
                    </p>
                    <a href="#" class="btn btn-danger text-center">Absence Notification&nbsp;<i class="fa  fa-calendar"></i></a>
                </div>
                <div class="panel-footer  text-center">
                    <a href="#">Update as of <%=String.Format("{0:T}", DateTime.Now) %></a>
                </div>
            </div>
        </div>--%>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    
   </div>



    <div class="modal slide-down fade" id="modalTimeSheetAction">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblAction" runat="server"></asp:Label></h4>
                    </div>
                    <%--   <% if (Request.QueryString["TID"] != null)
                        {
                    %>
                    <form name="formAction" method="post" action="ClientActionPage.aspx?TID=<%=Request.QueryString["TID"].ToString()%>&action=<%=Request.QueryString["action"].ToString()%>&fromD=<%=Request.QueryString["fromD"].ToString()%>&FromM=<%=Request.QueryString["FromM"].ToString()%>&FromY=<%=Request.QueryString["FromY"].ToString()%>&ModalAction=Y">
                        <% }
                            else
                            { %>
                        <form name="formAction" method="get" action="#">
                            <% } %>--%>
                    <div class="modal-body">
                        <div class="panel-body">

                            <p>
                                <center><asp:Label ID="lblActionTimeSheet" runat="server"></asp:Label></center>
                            </p>

                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                        <asp:Button ID="Send3" class="btn btn-success" runat="server" Text="Yes" OnClick="Send3_Click" />
                        <%--    <input type="submit" class="btn btn-success" id="Send3"  value="Yes" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit3" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%--   </form>--%>
                </div>
            </div>
        </div>
    </div>

    <div class="modal slide-down fade" id="modalTimeSheetAction2">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">
                            <asp:Label ID="lblaction2" runat="server"></asp:Label></h4>
                    </div>
                    <%--   <% if (Request.QueryString["TID"] != null)
                        {
                    %>
                    <form name="formAction" method="post" action="ClientActionPage.aspx?TID=<%=Request.QueryString["TID"].ToString()%>&action=<%=Request.QueryString["action"].ToString()%>&fromD=<%=Request.QueryString["fromD"].ToString()%>&FromM=<%=Request.QueryString["FromM"].ToString()%>&FromY=<%=Request.QueryString["FromY"].ToString()%>&ModalAction=Y">
                        <% }
                            else
                            { %>
                        <form name="formAction" method="get" action="#">
                            <% } %>--%>
                    <div class="modal-body">
                        <div class="panel-body">

                            <p>
                                <center><asp:Label ID="lblActionTimeSheet2" runat="server"></asp:Label></center>
                            </p>
                            <asp:TextBox TextMode="MultiLine" runat="server" ID="Txt_reject_cmnt" class="form-control" Rows="5" cols="5"></asp:TextBox>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                        <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Yes" OnClick="Button2_Click" />
                        <%--  <asp:Button ID="Send4" CssClass="btn btn-danger" runat="server" Text="No" OnClick="Send4_Click" />--%>
                        <%--    <input type="submit" class="btn btn-success" id="Send3"  value="Yes" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit4" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%--   </form>--%>
                </div>
            </div>
        </div>

    </div>

    <label id="timesheetaction" visible="false" target="_Blank" style="visibility: hidden" data-toggle="modal" data-target="#modalTimeSheetAction" class="btn btn-primary" class="btn btn-primary"></label>

    <label id="timesheetaction2" visible="false" target="_Blank" style="visibility: hidden" data-toggle="modal" data-target="#modalTimeSheetAction2" class="btn btn-primary" class="btn btn-primary"></label>

      <% if (Request["Rejectedempid"] != null)
            { %>
        
        <label id="lblrejectcom" style="visibility: hidden" data-toggle="modal" data-target="#reject_comment" class="btn btn-primary"></label>

        <% } %>
    <label id="interveiwAlert" style="visibility: hidden" data-toggle="modal" data-target="#modal-aakash" class="btn btn-primary"></label>

     <div class="modal slide-down fade" id="modal-aakash">
            <div class="modal-dialog">
                <div class="v-cell">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Interview Alert
                            <asp:Label ID="Label1" runat="server"></asp:Label></h4>
                        </div>

                        <div class="modal-body">
                            <div class="panel-body">
                               You Have an interview in 15 minutes

                            </div>

                        </div>
                        <div class="modal-footer">

                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                          

                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="modal slide-down fade" id="reject_comment">
            <div class="modal-dialog">
                <div class="v-cell">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title">Reasone of rejection for 
                            <asp:Label ID="lblrejectedname" runat="server"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <div class="panel-body">
                                <asp:Label ID="lblrejected_comment" runat="server"></asp:Label>

                            </div>

                        </div>
                        <div class="modal-footer">

                            <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                          

                        </div>

                    </div>
                </div>
            </div>
        </div>
    <% if (Request["done_dash"] != null)
                    {
                %>

                <label id="approve_can" style="visibility: hidden" data-toggle="modal" data-target="#modal-select_acept" class="btn btn-primary"></label>


                <% } %>
      <% if (Request["Reject_dash"] != null)
                    {
                %>

                <label id="reject_can" style="visibility: hidden" data-toggle="modal" data-target="#modal-reject" class="btn btn-primary"></label>


                <% } %>
     <% if (Request["forImsgDash"] != null)
            { %>

        <label id="forFRSTaction" style="visibility: hidden" data-toggle="modal" data-target="#modal-dashCHAT" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["dash_con1"] == "1")
            { %>
   
        <label id="dashReject" style="visibility: hidden" data-toggle="modal" data-target="#modal-reject-dash" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["dash_con2"] == "1")
            { %>
   
        <label id="dashaprove" style="visibility: hidden" data-toggle="modal" data-target="#modal-aprove-dash" class="btn btn-primary"></label>

        <% } %>
     <% if (Request["dash_conS"] == "1")
            { %>
 
        <label id="dashintschedule" style="visibility: hidden" data-toggle="modal" data-target="#modal-sch-int" class="btn btn-primary"></label>

        <% } %>
      <div class="modal slide-down fade" id="modal-sch-int">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Schedule Interview</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to schedule an interview with following details:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblscheduleintname" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lblschedulejab" runat="server" Text="Label"></asp:Label><br>
                            Schedule:&nbsp<asp:Label ID="lblschedul" runat="server" Text="Label"></asp:Label>
                         

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnscheduleint_dash" runat="server" OnClick="btnscheduleint_dash_Click"  class="btn btn-primary" Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-aprove-dash">
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
                            Are you sure, you want to approve candidate with following details:<br><br>
                            Candidate Name:&nbsp<asp:Label ID="lblaprovedash" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lbljobaprdash" runat="server" Text="Label"></asp:Label>
                         

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="dashAproveConfirm" runat="server" onclick="dashAproveConfirm_Click" class="btn btn-primary" Text="Approve" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-reject-dash">
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
                            Candidate Name:&nbsp<asp:Label ID="lbldashrejectCand" runat="server" Text="Label"></asp:Label><br>
                            Job Title:&nbsp<asp:Label ID="lbldashjob" runat="server" Text="Label"></asp:Label>
                         

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnrejectDAsh" runat="server" onclick="btnrejectDAsh_Click" class="btn btn-primary" Text="Reject" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-dashCHAT">
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
                        <asp:Button ID="btnCHAT" runat="server" ValidationGroup="rfvMOREINFO12" class="btn btn-primary"  Text="Send" OnClick="btnCHAT_Click" />

                         </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-reject">
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
                               
                                <asp:TextBox TextMode="MultiLine" runat="server" ValidationGroup="rfvREJECT" ID="txtComments1" class="form-control" Rows="5" cols="5"></asp:TextBox>

                              
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnDashReject" runat="server" class="btn btn-primary" OnClick="btnDashReject_Click" Text="Reject" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
                <div class="modal slide-down fade" id="modal-select_acept">
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



                                                <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvINTERVIEW" runat="server" ID="txtcomments" CssClass="form-control"></asp:TextBox>

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
                                    <asp:Button ID="btndash_interview"  ValidationGroup="rfvINTERVIEW" runat="server" class="btn btn-primary" Text="Send" OnClick="btndash_interview_Click" />
                                    </div>
                                <%-- </form>--%>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>