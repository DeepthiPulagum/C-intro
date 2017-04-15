<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_View_Candidate.aspx.cs" Inherits="C_View_Candidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:TextBox ID="Txtbox1" Visible="false" runat="server"></asp:TextBox>

    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View Candidates</b></h4>
    </div>
    <div class="panel panel-default">
        <!-- Data table -->
        <table id="data-table1" data-toggle="data-table" class="table" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Job Title</th>
                    <th>Location</th>
                    <th>Start date</th>
                    <th>End Date</th>
                    <th>Created by</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Sr.No</th>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Job Title</th>
                    <th>Location</th>
                    <th>Start date</th>
                    <th>End Date</th>
                    <th>Created by</th>
                    <th>Action</th>
                </tr>

            </tfoot>
            <asp:Label ID="lblTableData" runat="server"></asp:Label>

        </table>
        <!-- // Data table -->
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

        <% if (Request["action_id"] != null)
            { %>

        <label id="reshedule_int" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewRE" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["moreinfomsg"] != null)
            { %>

        <label id="more_info_msg_show" style="visibility: hidden" data-toggle="modal" data-target="#modal-more_info_msg" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["moreinfomsg1"] != null)
            { %>

        <label id="interveiw_schedule2" style="visibility: hidden" data-toggle="modal" data-target="#modal-int_schedule2" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["moreinfomsg2"] != null)
            { %>

        <label id="reject_candidate2" style="visibility: hidden" data-toggle="modal" data-target="#modal-reject2" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["foreye"] != null)
            { %>

        <label id="for_eye" style="visibility: hidden" data-toggle="modal" data-target="#modal-moreinfomsgs_eye" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["foreye1"] != null)
            { %>

        <label id="for_eye1" style="visibility: hidden" data-toggle="modal" data-target="#modal-moreinfomsgs_eye1" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["foreyecon"] != null)
            { %>

        <label id="for_eyecon" style="visibility: hidden" data-toggle="modal" data-target="#modal-moreinfomsgs_eye12" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["forImsg"] != null)
            { %>

        <label id="forFRSTaction" style="visibility: hidden" data-toggle="modal" data-target="#modal-moreinfomsgs_eye123" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["action_idd"] != null)
            { %>

        <label id="reschedule1" style="visibility: hidden" data-toggle="modal" data-target="#modal-reschedule" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["reject_reason1"] == "1")
            { %>

        <label id="rejectFromVendor" style="visibility: hidden" data-toggle="modal" data-target="#modal-rejectionvendor" class="btn btn-primary"></label>

        <% } %>
         <% if (Request["makesure"] == "1")
            { %>

        <label id="InterviewMakeSure" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure" class="btn btn-primary"></label>

        <% } %>
         <% if (Request["makesure2"] == "1")
            { %>

        <label id="InterviewMakeSure2" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure2" class="btn btn-primary"></label>

        <% } %>
         <% if (Request["makesure3"] == "1")
            { %>

        <label id="InterviewMakeSure3" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure3" class="btn btn-primary"></label>

        <% } %>
         <% if (Request["makesure4"] == "1")
            { %>

        <label id="InterviewMakeSure4" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure4" class="btn btn-primary"></label>

        <% } %>
         <% if (Request["makesure5"] == "1")
            { %>

        <label id="InterviewMakeSure5" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure5" class="btn btn-primary"></label>

        <% } %>
          <% if (Request["makesure6"] == "1")
            { %>

        <label id="InterviewMakeSure6" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure6" class="btn btn-primary"></label>

        <% } %>
        <% if (Request["makesure7"] == "1")
            { %>

        <label id="InterviewMakeSure7" style="visibility: hidden" data-toggle="modal" data-target="#modal-interviewMakesure7" class="btn btn-primary"></label>

        <% } %>


     
    </div>
     <div class="modal slide-down fade" id="modal-interviewMakesure7">
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

                           Are you sure, you want to reject following candidate:<br>
                            Candidate Name:&nbsp<asp:Label ID="lblrejctname" runat="server" Text="Label"></asp:Label><br>
                         Job Title:&nbsp<asp:Label ID="lbljobtitle" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnrejectcan" runat="server" onclick="btnrejectcan_Click" class="btn btn-primary"  Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-interviewMakesure6">
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

                           Are you sure, you want to cancel following interview:<br>
                            Candidate Name:&nbsp<asp:Label ID="lblrejectintname" runat="server" Text="Label"></asp:Label><br>
                         Job Title:&nbsp<asp:Label ID="lblrejecttitlejob" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnCancelIntview" runat="server" onclick="btnCancelIntview_Click" class="btn btn-primary"  Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-interviewMakesure5">
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

                           Are you sure, you want to reject candidate:<br>
                            Candidate Name:&nbsp<asp:Label ID="lblrjctname" runat="server" Text="Label"></asp:Label><br>
                         Job Title:&nbsp<asp:Label ID="lblrjctjob" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnrjctperson" runat="server" onclick="btnrjctperson_Click" class="btn btn-primary"  Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
       <div class="modal slide-down fade" id="modal-interviewMakesure4">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Candidate Approve</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                           Are you sure, you want to approve candidate:<br>
                            Candidate Name:&nbsp<asp:Label ID="lblapprvcandiate" runat="server" Text="Label"></asp:Label><br>
                         Job Title:&nbsp<asp:Label ID="LbltitleJOB" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnapprovePerson" runat="server" onclick="btnapprovePerson_Click" class="btn btn-primary"  Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-interviewMakesure3">
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

                           Are you sure, you want to reschedule the interview for following details<br>
                            Candidate Name:&nbsp<asp:Label ID="lblname_C" runat="server" Text="Label"></asp:Label><br>
                           New Schedule:&nbsp<asp:Label ID="lbldateC" runat="server" Text="Label"></asp:Label>&nbsp at&nbsp<asp:Label ID="lbltimeC" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnREscheduleTime" runat="server" onclick="btnREscheduleTime_Click" class="btn btn-primary"  Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-interviewMakesure2">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Interview Request</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                           Are you sure, you want to request an interview with following details<br>
                            Candidate Name:&nbsp<asp:Label ID="lblcandname" runat="server" Text="Label"></asp:Label><br>
                            Schedule:&nbsp<asp:Label ID="lblinterviewdate" runat="server" Text="Label"></asp:Label>&nbsp at&nbsp<asp:Label ID="lbltime" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btninterviewReqConfrm" runat="server" OnClick="btninterviewReqConfrm_Click" class="btn btn-primary"  Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
     <div class="modal slide-down fade" id="modal-interviewMakesure">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Candidate Approval</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                           Are you sure, you want to approve&nbsp<asp:Label ID="lblempname" runat="server" Text="Label"></asp:Label>&nbsp for&nbsp<asp:Label ID="lbljobname" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnApproveCand" runat="server" OnClick="btnApproveCand_Click" class="btn btn-primary"  Text="Approve" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-reschedule">
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
                                    <% if (Request["action_idd"] != null)
                                        { %>
                                
                                 
                                Candidate Name : <%= Server.UrlDecode(Request.QueryString["cand_name"]) %><br>
                                    <br>
                                    Job Title : <%= Server.UrlDecode(Request.QueryString["job_title"]) %><br>
                                    <br>
                                    Schedule : <%= Server.UrlDecode(Request.QueryString["schedule"]) %></asp:Label>
                            <% } %>     </td>

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

                                                                    <input type="text" class="form-control datepicker" validationgroup="rfvINTSCHEDULE" onkeypress="return isNumberKey(event)" id="Text1" runat="server" name="TxtNewdate" placeholder="Choose a date">
                                                                </td>
                                                                <td></td>
                                                                <td style="margin-left: 5px">

                                                                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="true" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                                                        <asp:ListItem Text="--select one--" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="1:00 AM" Value="1:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:00 AM" Value="2:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:00 AM" Value="3:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:00 AM" Value="4:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:00 AM" Value="5:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:00 AM" Value="6:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:00 AM" Value="7:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:00 AM" Value="8:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:00 AM" Value="9:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:00 AM" Value="10:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:00 AM" Value="11:00 AM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:00 PM" Value="12:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="1:00 PM" Value="1:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="2:00 PM" Value="2:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="3:00 PM" Value="3:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="4:00 PM" Value="4:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="5:00 PM" Value="5:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="6:00 PM" Value="6:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="7:00 PM" Value="7:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="8:00 PM" Value="8:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="9:00 PM" Value="9:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="10:00 PM" Value="10:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="11:00 PM" Value="11:00 PM"></asp:ListItem>
                                                                        <asp:ListItem Text="12:00 AM" Value="12:00 AM"></asp:ListItem>

                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <br>
                                                        <asp:Button ID="Button2" class="btn btn-primary" runat="server" Text="Reschedule" />
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />

                                                <asp:Button ID="btnreshedul" OnClick="btnApproveCandidate_Click" class="btn btn-default" OnClientClick="javascript:alert('Are you sure you want to approve the Candidate?');" Height="70px" Width="400px" runat="server" Text="Approve Candidate" />

                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />

                                                <asp:Button ID="Button4" OnClick="btnRejectCandidate_Click" onmouseover="OnHover1(this);" onmouseout="OnOut1(this);" OnClientClick="javascript:alert('Are you sure you want to reject the Candidate?');" class="btn btn-default" Height="70px" Width="400px" runat="server" Text="Reject Candidate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />
                                                <asp:Button ID="Button5" OnClick="btncancelINTErview_Click" onmouseover="OnHover(this);" onmouseout="OnOut(this);" OnClientClick="javascript:alert('Are you sure you want to cancel Interview?');" class="btn btn-default" Height="70px" Width="400px" runat="server" Text="Cancel Interview" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">

                                    <%-- <asp:TextBox TextMode="MultiLine" ReadOnly="true" ID="TextBox1" runat="server" Columns="1" Rows="5" CssClass="form-control"></asp:TextBox>
                                    --%>
                                    <asp:TextBox Height="270px" Width="250px" ID="TextBox1" TextMode="MultiLine" ReadOnly="true" CssClass="form-control" runat="server"></asp:TextBox>

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
    <div class="modal slide-down fade" id="modal-moreinfomsgs_eye123">
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

                        <asp:Button ID="btnCOMMENTs" class="btn btn-primary" ValidationGroup="rfvMOREINFO12" OnClick="btnCOMMENTs_Click" runat="server" Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-moreinfomsgs_eye12">
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

                            <asp:TextBox TextMode="MultiLine" ReadOnly="true" ID="txtConfirmINT" runat="server" Columns="5" Rows="5" CssClass="form-control"></asp:TextBox>
                            <br>
                            <b>
                                <p>Type the comments</p>
                            </b>

                            <div class="col-sm-14">

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="rfvMOREINFO1234" InitialValue="" SetFocusOnError="true" ControlToValidate="txtConfirmInt2" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvMOREINFO1234" runat="server" ID="txtConfirmInt2" CssClass="form-control" Rows="5" cols="5"></asp:TextBox>

                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnConfirmintcomment" runat="server" ValidationGroup="rfvMOREINFO1234" class="btn btn-primary" OnClick="btnConfirmintcomment_Click" Text="Send" />


                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-moreinfomsgs_eye1">
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

                            <asp:TextBox TextMode="MultiLine" ReadOnly="true" ID="txtMessage2" runat="server" Columns="5" Rows="5" CssClass="form-control"></asp:TextBox>
                            <b>
                                <p>Type the comments</p>
                            </b>

                            <div class="col-sm-14">


                                <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvMOREINFO" runat="server" ID="TxtMSG2" CssClass="form-control" Rows="5" cols="5"></asp:TextBox>

                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="BtnMSG2" runat="server" class="btn btn-primary" OnClick="BtnMSG2_Click" Text="Send" />


                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-moreinfomsgs_eye">
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

                            <asp:TextBox TextMode="MultiLine" ID="messages" runat="server" Columns="5" Rows="5" CssClass="form-control"></asp:TextBox>
                            <br>
                            <b>
                                <p>Type the comments</p>
                            </b>

                            <div class="col-sm-14">

                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="rfvMOREINFO123" InitialValue="" SetFocusOnError="true" ControlToValidate="txtEYEMSG" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvMOREINFO123" runat="server" ID="txtEYEMSG" CssClass="form-control" Rows="5" cols="5"></asp:TextBox>

                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btneye" ValidationGroup="rfvMOREINFO123" runat="server" class="btn btn-primary" OnClick="btneye_Click" Text="Send" />


                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-reject2">
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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="rfvREJECT2" InitialValue="" SetFocusOnError="true" ControlToValidate="txtReason2" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" runat="server" ValidationGroup="rfvREJECT2" ID="txtReason2" class="form-control" Rows="5" cols="5"></asp:TextBox>

                                <% if (Request["employeeid2"] != null)
                                    { %>
                                <input type="hidden" name="employeeid2" value="<%=Request["employeeid2"].ToString() %>" />


                                <% } %>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnreject2" runat="server" class="btn btn-primary" ValidationGroup="rfvREJECT2" Text="Reject" OnClick="btnreject2_Click" />

                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-int_schedule2">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Request for an Interview </h4>
                    </div>
                    <%--<form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">



                            <div class="col-sm-12">
                                <p></p>
                                <p>Please pick a date and time when you would like to interview this candidate</p>
                                <div>
                                    <table>
                                        <tr>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="rfvINTERVIEW2" InitialValue="" SetFocusOnError="true" ControlToValidate="Txtinterview_date" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                                <input type="text" class="form-control datepicker" onkeypress="return isNumberKey(event)" id="Txtinterview_date" runat="server" name="Textdate" placeholder="Choose a date">

                                                <%--<input type="text" class="form-control datepicker" name="DP1" id="DP1">--%>
                                                <%--<asp:TextBox ID="Txtinterview_date" class="form-control" placeholder="MM/DD/YYYY" runat="server"></asp:TextBox>
                                                --%>  </td>
                                            <td></td>
                                            <td style="margin-left: 5px">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="rfvINTERVIEW2" InitialValue="0" SetFocusOnError="true" ControlToValidate="ddinterview_moreinfo" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                                <asp:DropDownList ID="ddinterview_moreinfo" runat="server" AppendDataBoundItems="true" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                                    <asp:ListItem Text="--select one--" Value="0"></asp:ListItem>
                                                    <asp:ListItem Text="1:00 AM" Value="1:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="2:00 AM" Value="2:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="3:00 AM" Value="3:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="4:00 AM" Value="4:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="5:00 AM" Value="5:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="6:00 AM" Value="6:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="7:00 AM" Value="7:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="8:00 AM" Value="8:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="9:00 AM" Value="9:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="10:00 AM" Value="10:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="11:00 AM" Value="11:00 AM"></asp:ListItem>
                                                    <asp:ListItem Text="12:00 PM" Value="12:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="1:00 PM" Value="1:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="2:00 PM" Value="2:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="3:00 PM" Value="3:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="4:00 PM" Value="4:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="5:00 PM" Value="5:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="6:00 PM" Value="6:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="7:00 PM" Value="7:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="8:00 PM" Value="8:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="9:00 PM" Value="9:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="10:00 PM" Value="10:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="11:00 PM" Value="11:00 PM"></asp:ListItem>
                                                    <asp:ListItem Text="12:00 AM" Value="12:00 AM"></asp:ListItem>

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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="rfvINTERVIEW2" InitialValue="" SetFocusOnError="true" ControlToValidate="txtcommnt_int_moreinfo" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                    <asp:TextBox TextMode="MultiLine" runat="server" Height="200px" Width="100px" ValidationGroup="rfvINTERVIEW2" ID="txtcommnt_int_moreinfo" class="form-control" Rows="5" cols="5"></asp:TextBox>

                                    <br />


                                    <%-- <p>OR</p>--%>
                                    <%-- OR   <input type="checkbox" name="chkapprove" id="chkapprove" value="yes"> Approve--%>
                                </div>

                                <% if (Request["moreinfomsg1"] != null)
                                    { %>
                                <input type="hidden" name="actionID" value="<%=Request["actionID2"].ToString() %>" />
                                <input type="hidden" name="employeeid1" value="<%=Request["employeeid1"].ToString() %>" />
                                <input type="hidden" name="job_id1" value="<%=Request["job_id"].ToString() %>" />
                                <input type="hidden" name="job_end_date1" value="<%=Request["job_end_date"].ToString() %>" />
                                <input type="hidden" name="emp_end_date1" value="<%=Request["emp_enddate"].ToString() %>" />

                                <% } %>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="Btninterview_moreinfo" OnClick="Btninterview_moreinfo_Click" class="btn btn-primary" ValidationGroup="rfvINTERVIEW2" runat="server" Text="Send" />
                        <%--<input type="submit" class="btn btn-primary" id="Send3" name="Send3" value="Send" />--%>
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-more_info_msg">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Information</h4>
                    </div>
                    <%--<form name="form2" method="post" action="test123.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">



                            <div class="col-sm-12">
                                <asp:Label ID="lblinformationneeded" runat="server" Font="medium" Text="Label"></asp:Label>
                                <asp:Label ID="lblMoreinfomsg" runat="server" Font="medium" Text="Label"></asp:Label>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <%-- <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Reject" OnClick="btnReject_Click" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit91" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="modal slide-down fade" id="modal-interviewRE">
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
                                    <% if (Request["action_id"] != null)
                                        { %>
                                
                                 
                                Candidate Name : <%= Server.UrlDecode(Request.QueryString["cand_name"]) %><br>
                                    <br>
                                    Job Title : <%= Server.UrlDecode(Request.QueryString["job_title"]) %><br>
                                    <br>
                                    Schedule : <%= Server.UrlDecode(Request.QueryString["schedule"]) %></asp:Label>
                            <% } %>     </td>

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
                                                                        <asp:ListItem Text="00:45 AM" Value="00:45 AM"></asp:ListItem>

                                                                    </asp:DropDownList>
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

                                                <asp:Button ID="btnRejectCandidate" OnClick="btnRejectCandidate_Click" onmouseover="OnHover1(this);" onmouseout="OnOut1(this);"  class="btn btn-default" Height="70px" Width="400px" runat="server" Text="Reject Candidate" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <hr />
                                                <asp:Button ID="btncancelINTErview" OnClick="btncancelINTErview_Click" onmouseover="OnHover(this);" onmouseout="OnOut(this);"  class="btn btn-default" Height="70px" Width="400px" runat="server" Text="Cancel Interview" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="middle">

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
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="rfvREJECT" InitialValue="" SetFocusOnError="true" ControlToValidate="txtComments1" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" runat="server" ValidationGroup="rfvREJECT" ID="txtComments1" class="form-control" Rows="5" cols="5"></asp:TextBox>

                               <%-- <% if (Request["Reject"] != null)
                                    { %>
                                <input type="hidden" name="Rejected" value="<%=Request["Reject"].ToString() %>" />
                                <input type="hidden" name="job_id1" value="<%=Request["job_id"].ToString() %>" />
                                <input type="hidden" name="job_end_date1" value="<%=Request["job_end_date"].ToString() %>" />
                                <input type="hidden" name="emp_end_date1" value="<%=Request["emp_enddate"].ToString() %>" />
                                <% } %>--%>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnReject" runat="server" class="btn btn-primary" ValidationGroup="rfvREJECT" Text="Reject" OnClick="btnReject_Click" />
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit1" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%-- </form>--%>
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
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">

                            <p>Type below the details you need answered to proceed</p>

                            <div class="col-sm-12">

                                <%-- <textarea id="txtComments2" name="txtComments2" class="form-control" rows="5"></textarea>--%>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="rfvMOREINFO" InitialValue="" SetFocusOnError="true" ControlToValidate="txtComments2" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" placeholder="Type your comments" ValidationGroup="rfvMOREINFO" runat="server" ID="txtComments2" class="form-control" Rows="5" cols="5"></asp:TextBox>
                                <% if (Request["more"] != null)
                                    { %>
                                <input type="hidden" name="more" value="<%=Request["more"].ToString() %>" />
                                <input type="hidden" name="job_id1" value="<%=Request["job_id"].ToString() %>" />
                                <input type="hidden" name="job_end_date1" value="<%=Request["job_end_date"].ToString() %>" />
                                <input type="hidden" name="emp_end_date1" value="<%=Request["emp_enddate"].ToString() %>" />
                                <% } %>
                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="BtnMoreInfo" OnClick="BtnMoreInfo_Click" ValidationGroup="rfvMOREINFO" class="btn btn-primary" runat="server" Text="Send" />
                        <%-- <input type="submit" class="btn btn-primary" id="Send2" name="Send2" value="Send" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit2" data-dismiss="modal" >Send Request</button>-->
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
    <div class="modal slide-down fade" id="modal-rejectionvendor">
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
    <script>
        //following code is for mousehover color change on the reschedule of interview
        function OnHover(val) {
            val.style.backgroundColor = "#996f6b";
        }
        function OnOut(val) {
            val.style.backgroundColor = "";
        }
        function OnHover1(val) {
            val.style.backgroundColor = "#996f6b";
        }
        function OnOut1(val) {
            val.style.backgroundColor = "";
        }

    </script>


</asp:Content>


