<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="Client.aspx.cs" Inherits="Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row" data-toggle="isotope">

        <div class="item col-xs-12 col-md-4">

            <!-- Recent tickets -->
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">Your Job(s)</h4>
                </div>
                <ul class="list-group">
                    <asp:Label ID="lblshowrecentlyadded" runat="server"></asp:Label>
                </ul>
            </div>
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-xs-6">
                            <h4 class="text-headline margin-none">
                                <asp:Label ID="lblJobs" runat="server"></asp:Label></h4>
                            <p class="text-light"><i class="fa fa-circle-o text-success fa-fw"></i>Total Job(s)</p>
                        </div>
                        <div class="col-xs-6">
                            <h4 class="text-headline margin-none">
                                <asp:Label ID="lblVendors" runat="server"></asp:Label></h4>
                            <p class="text-light"><i class="fa fa-circle-o text-danger fa-fw"></i>Vendors</p>
                        </div>
                    </div>

                    <div class="progress progress-mini">
                        <div class="progress-bar progress-bar-success" style="width: 85%">
                            <span class="sr-only">35% Complete (info)</span>
                        </div>
                        <div class="progress-bar progress-bar-danger" style="width: 15%">
                            <span class="sr-only">10% Complete (danger)</span>
                        </div>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="text-right">

                        <asp:Button ID="btnVendorContribution" runat="server" data-toggle="tk-modal-demo" data-modal-options="slide-down" class="btn  btn-success" Text="View Vendor Contribution" OnClick="btnVendorContribution_Click" />

                    </div>
                </div>

            </div>

        </div>
        <div class="item col-md-4 col-xs-12">
            <asp:UpdatePanel>

                <ContentTemplate>

                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">TimeSheets to be Approved</h4>
                        </div>
                        <table class="table table-striped margin-none">
                            <thead>
                                <tr>
                                    <th>Name</th>
                                    <th>#Hours</th>
                                    <th class="text-right width-100">Action</th>
                                </tr>

                            </thead>
                            <asp:Label ID="lblTableData" runat="server"></asp:Label>
                        </table>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4 class="panel-title">Worker Absence Notification</h4>
                </div>
                <div class="table-responsive">
                    <table class="table table-striped margin-none">
                        <thead>
                            <tr>
                                <th>Name</th>
                                <th>Request Date</th>
                                <th>Reason</th>
                                <th>Action</th>
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
        <div class="item col-xs-12 col-md-4">
            <div class="panel panel-default">
                <div class="panel panel-default text-center">
                    <div class="panel-body">
                        <h4 class="text-headline">Top Vendor</h4>
                        <p class="text-h2 text-primary">
                            <strong>
                                <asp:Label ID="lblTopVendorName" runat="server"></asp:Label></strong>
                        </p>
                    </div>


                    <hr class="margin-none" />
                    <div class="panel-body">
                        <%--<div class="sparkline-bar" sparkheight="66">
                            <span class="hide">0:10,7:3,5:5,6:4,3:7,7:3,5:5,6:4,2:8,3:7,7:3,5:5,0:10</span>
                        </div>--%>
                    </div>
                    <div class="panel-body">
                        <h3>Hires</h3>
                        <div data-percent="60" data-size="100" class="easy-pie inline-block primary" data-scale-color="false" data-track-color="#efefef" data-line-width="6">
                            <div class="value text-center">
                                <span class="strong"><i class="icon-graph-up-1 fa-3x text-default"></i></span>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <h3>Responded</h3>
                        <div data-percent="80" data-size="100" class="easy-pie inline-block  warning" data-scale-color="false" data-track-color="green" data-line-width="6">
                            <div class="value text-center">
                                <span class="strong"><i class="icon-graph-up-1 fa-3x text-default"></i></span>
                            </div>
                        </div>
                    </div>
                </div>

            </div>

        </div>


        <script id="tk-modal-demo" type="text/x-handlebars-template">
            <div class="modal fade{{#if modalOptions}} {{ modalOptions }}{{/if}}" id="{{ id }}">
                <div class="modal-dialog{{#if dialogOptions}} {{ dialogOptions }}{{/if}}">
                    <div class="v-cell">
                        <div class="modal-content{{#if contentOptions}} {{ contentOptions }}{{/if}}">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblVendorContribution" runat="server"></asp:Label></h4>
                            </div>
                            <div class="modal-body data-scrollable">
                                <div class="panel panel-default">
                                    <!-- Data table -->
                                    <table data-toggle="data-table" class="table" cellspacing="0" width="100%">
                                        <thead>
                                            <tr>
                                                <th>Employee Name</th>
                                                <th>Active Employee Count</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                            <asp:Label ID="lblVendorList" runat="server"></asp:Label>
                                        </tbody>
                                    </table>
                                    <!-- // Data table -->
                                </div>
                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </script>
        <% if (Request["empid1"] != null)
            { %>
        <div id="xyz" data-toggle='tk-modal-demo' data-modal-options='slide-down'></div>
        <script>
            alert("hi");
        </script>
        <% } %>
    </div>
    <label id="timesheetaction" visible="false" style="visibility: hidden" data-toggle="modal" data-target="#modalTimeSheetAction" class="btn btn-primary" class="btn btn-primary"></label>

    <label id="timesheetaction2" visible="false" style="visibility: hidden" data-toggle="modal" data-target="#modalTimeSheetAction2" class="btn btn-primary" class="btn btn-primary"></label>

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
                            <asp:TextBox TextMode="MultiLine" runat="server" ID="Txt_reject_cmnt" class="form-control" rows="5" cols="5"></asp:TextBox>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                        <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Yes" OnClick="Send4_Click" />
                      <%--  <asp:Button ID="Send4" CssClass="btn btn-danger" runat="server" Text="No" OnClick="Send4_Click" />--%>
                        <%--    <input type="submit" class="btn btn-success" id="Send3"  value="Yes" />--%>
                        <!--<button type="button" class="btn btn-primary" runat="server" id="btnSubmit4" data-dismiss="modal" >Send Request</button>-->
                    </div>
                    <%--   </form>--%>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

