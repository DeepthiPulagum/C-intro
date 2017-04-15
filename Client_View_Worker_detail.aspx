<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="Client_View_Worker_detail.aspx.cs" Inherits="Client_View_Worker_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View Worker Details</b></h4>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Title</b></h4>
            <br />
            <h4 class="media-heading margin-v-5">
                <b>
                    <asp:Label ID="lbljobtitle" runat="server"></asp:Label></b>
                <font color="red">
                            <asp:label id="lblUrgent" runat="server"></asp:label>
                        </font>
            </h4>

            <table class="table" cellspacing="0" width="100%">
                <tr>
                    <td>No of Openings :
                                                  <asp:Label ID="lblnoofopning" runat="server"></asp:Label>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </td>
                                        <%-- <td>|  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>--%>
                    <td>Start Date :
                          <asp:Label ID="lblstartdate" runat="server"></asp:Label>
                    </td>
                    <%-- <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                |
                                </td>--%>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                  End Date :
                                
                                   

                        <asp:Label ID="lblenddate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="y" runat="server">
                    <td>Location :
                                
                                   

                        <asp:Label ID="lbllocation2" runat="server"></asp:Label>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    </td>

                    <%-- <td>|  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>--%>
                    <td>Bill Rate :
                                 $<asp:Label ID="lblbill" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                    </td>
                </tr>
                <tr id="x" runat="server">
                    <td>Location :
                                
                                   

                        <asp:Label ID="lbllocation" runat="server"></asp:Label>

                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                    </td>

                    <%-- <td>|  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>--%>
                    <td>Pay Rate :
                                 $<asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
    <div class="panel panel-default">
        <div class="panel-body">
            <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Worker Detail</b></h4>
            <br />
            <table class="table table-striped margin-none">
                <tbody>
                    <%--  <tr>

                        <td width="400">Profile Picture</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblprofile" class="text-subhead" runat="server"></asp:Label></td>
                    </tr>--%>
                    <tr>

                        <td width="400">First Name</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblfirst" name="lblfirst" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td>Middle Name</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblmiddle" name="lblmiddle" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Last Name</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lbllast" name="lbllast" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Email</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblemail" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Phone</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblphone" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Date of Birth</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lbldob" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td>Suite</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblsuite" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Address</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lbladdress" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>City</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblcity" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Province</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblprovince" runat="server"></asp:Label></td>
                    </tr>
                    <%--  <tr>

                        <td>Country</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblcountry" class="text-subhead" runat="server"></asp:Label></td>
                    </tr>--%>
                    <tr>

                        <td>Postal</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblpostal" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Available date</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblavailable" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Skype ID</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblskype" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>licence Number</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lbllicence" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Last Four Digits of SIN/SSN</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lbllastsin" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Pay Rate</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblpay" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Job Title</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lbljob" runat="server"></asp:Label></td>
                    </tr>
                    <tr>

                        <td>Comments</td>
                        <td width="20">:</td>
                        <td>
                            <asp:Label ID="lblcomment" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>Resume</td>
                        <td width="20">:</td>
                        <td>
                            <%--    <a href="#">Resume</a>--%>
                            <%-- <asp:Label ID="lblresume" class="text-subhead" runat="server"></asp:Label></td>--%>
                            <asp:Label ID="lblresume" class="text-subhead" runat="server"></asp:Label>
                    </tr>

                </tbody>
            </table>
            <div id="divstar" runat="server">
                <table class="table table-striped margin-none">
                    <tbody>
                        <tr>

                            <td width="400">
                                <h5>Question #1 </h5>
                                <asp:Label ID="lblque1" runat="server"></asp:Label></td>
                            <td width="20">:</td>
                            <td>
                                <asp:TextBox ID="txtRating1" ReadOnly name="txtRating1" class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprat1" ReadOnly name="txtemprat1" class="rating rating10" value="3" runat="server" />
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <h5>Question #2</h5>
                                <asp:Label ID="labque2" runat="server"></asp:Label></td>
                            <td width="20">:</td>
                            <td>
                                <asp:TextBox ID="txtRating2" ReadOnly name="txtRating2" class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprat2" ReadOnly name="txtemprat2" class="rating rating10" value="3" runat="server" />
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <h5>Question #3</h5>
                                <asp:Label ID="lblque3" runat="server"></asp:Label></td>
                            <td width="20">:</td>
                            <td>
                                <asp:TextBox ID="txtRating3" ReadOnly name="txtRating3" class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprat3" ReadOnly name="txtemprat3" class="rating rating10" value="3" runat="server" />
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <h5>Question #4</h5>
                                <asp:Label ID="lblque4" runat="server"></asp:Label></td>
                            <td width="20">:</td>
                            <td>
                                <asp:TextBox ID="txtRating4" ReadOnly name="txtRating4" class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprat4" ReadOnly name="txtemprat4" class="rating rating10" value="3" runat="server" />
                            </td>
                        </tr>
                        <tr>

                            <td>
                                <h5>Question #5</h5>
                                <asp:Label ID="lblque5" runat="server"></asp:Label></td>
                            <td width="20">:</td>
                            <td>
                                <asp:TextBox ID="txtRating5" ReadOnly name="txtRating5" class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprat5" ReadOnly name="txtemprat5" class="rating rating10" value="3" runat="server" />
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <%--<table class="table table-striped margin-none">
                        <tr>
                            <td>Profile Picture
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblprofile" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>First Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblfirst" class="text-subhead" name="lblfirst" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Middle Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblmiddle" class="text-subhead" name="lblmiddle" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Last Name
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lbllast" class="text-subhead" name="lbllast" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Email
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblemail" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Phone
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblphone" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Date of Birth

                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lbldob" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Suite
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblsuite" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Address
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lbladdress" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>City
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblcity" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Province
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblprovince" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Country
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblcountry" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Postal
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblpostal" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Available date
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblavailable" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Skype ID
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblskype" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td>licence 
                            </td>
                            <td>:
                            </td>
                            <td>&nbsp;<asp:Label ID="lbllicence" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td>last four digits of SIN
                            </td>
                            <td>:
                            </td>
                            <td>&nbsp;<asp:Label ID="lbllastsin" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                           <tr>
                            <td>pay Rate
                            </td>
                            <td>:
                            </td>
                            <td>&nbsp;<asp:Label ID="lblpay" class="text-subhead" runat="server"></asp:Label>
                            </td>
                       
                           </tr>
                           <tr>
                            <td>job
                            </td>
                            <td>:
                            </td>
                            <td>&nbsp;<asp:Label ID="lbljob" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                      
                        <tr>
                            <td>comments
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblcomment" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>Upload Resume
                            </td>
                            <td>:
                            </td>
                            <td>
                                <asp:Label ID="lblresume" class="text-subhead" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Button ID="btnback" runat="server" class="btn btn-primary" Text="Close" OnClick="btnback_Click" />
     
                            </td>
                        </tr>
                    </table>--%>
        </div>
    </div>



    <div class="panel panel-default">
        <div class="panel-body">
            <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>History Worker Absence Request</b></h4>
            <br />
            <div class="table-responsive">
                <table class="table table-striped margin-none">
                    <thead>
                        <tr>
                            <th>Request Date</th>
                            <th>Reason</th>
                            <th>Comments</th>
                            <th>Status</th>
                        </tr>
                    </thead>
                    <asp:Label ID="lblrequestleave" runat="server"></asp:Label>
                </table>
                <div>
                    <asp:Label ID="lblrequestnothing" runat="server"></asp:Label>
                </div>

            </div>
        </div>

    </div>
    <div class="panel panel-default" id="request_for_updates">
        <div class="panel-body">
            <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Requests by Vendor about this candidate</b></h4>
            <br />
            <div class="table-responsive">
                <table class="table table-striped margin-none">
                    <tbody>
                        <asp:Label ID="lblMessagesBackForth" runat="server"></asp:Label>
                     
                    </tbody>

                </table>
                <div>
                </div>
            </div>
        </div>

    </div>
    <% if (Request["reply"] != null)
        { %>

    <label id="clientfeedback" style="visibility: hidden" data-toggle="modal" data-target="#model_clientfeedback" class="btn btn-primary"></label>

    <% } %>

    <div class="modal slide-down fade" id="model_clientfeedback">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Fedback needed for 
                            <asp:Label ID="lblname" runat="server"></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <div class="panel-body">

                            <p>Please enter your comments below for feedback</p>

                            <div class="col-sm-12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="" SetFocusOnError="true" ControlToValidate="txtfeedcomment" runat="server" ErrorMessage="required" Text="* Required"></asp:RequiredFieldValidator>

                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtfeedcomment" class="form-control" Rows="5" cols="5"></asp:TextBox>

                            </div>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnsend" runat="server" class="btn btn-primary" Text="Send" OnClick="btnsend_Click" />

                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

