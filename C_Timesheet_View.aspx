<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_Timesheet_View.aspx.cs" Inherits="C_Timesheet_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View TimeSheets</b></h4>
    </div>
    <div class="panel panel-default">
       <%-- <form name="form1" id="form1" method="post" action="TimeSheet_Insert.aspx">--%>

            <div class="panel panel-default">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <!-- Data table -->
                <table id="data-table1" class="table" cellspacing="0" width="100%">
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Week #</th>
                            <th>Start Week</th>
                            <th>Week End</th>
                            <th>Mon</th>
                            <th>Tue</th>
                            <th>Wed</th>
                            <th>Thu</th>
                            <th>Fri</th>
                            <th>Sat</th>
                            <th>Sun</th>
                            <th>Total</th>
                            <th>Action</th>

                        </tr>
                    </thead>

                    <tfoot>
                        <tr>
                            <th>Name</th>
                            <th>Week #</th>
                            <th>Start Week</th>
                            <th>Week End</th>
                            <th>Mon</th>
                            <th>Tue</th>
                            <th>Wed</th>
                            <th>Thu</th>
                            <th>Fri</th>
                            <th>Sat</th>
                            <th>Sun</th>
                            <th>Total</th>
                            <th>Action</th>
                        </tr>
                    </tfoot>
                    <tbody>
                        <asp:Label ID="lblNames" runat="server"></asp:Label>
                    
                        <asp:Label ID="lblTimeSheet" runat="server"></asp:Label>



                    </tbody>
                    <%-- </tbody>--%>
                </table>
                
            </div>
    <%--    </form>--%>
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

                        </div>

                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                        <asp:Button ID="Send4" class="btn btn-success" runat="server" Text="Yes" OnClick="Send4_Click" />
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

