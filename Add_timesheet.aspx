<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor_T.master" AutoEventWireup="true" CodeFile="Add_timesheet.aspx.cs" Inherits="Add_timesheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
 <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>Add Timesheet</b></h4>
    </div>

    <div class="panel panel-default">
        <div class="panel-body">
        </div>
        <div class="panel panel-default">
            <div class="panel panel-default">
                <form runat="server">
                    <div class="panel-body">

                        <h5>Employee Name</h5>
                        <select style="width: 50%;" data-toggle="select2">
                        </select>
                        <%-- <select name="jobStatus" runat="server" id="jobStatus" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                        </select>--%>
                        <h5>Day</h5>
                        <input type="text" style="width: 50%;" class="form-control" id="day">
                        <h5>Month</h5>
                        <input type="text" style="width: 50%;" class="form-control" id="month">

                        <%--  <select name="departmentid" runat="server" id="departmentid" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                        </select>--%>
                        <h5>Year</h5>
                        <input type="text" style="width: 50%;" class="form-control" id="year">

                        <%--<select name="clientid" runat="server" id="clientid" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                        </select>--%>
                        <h5>Hours</h5>
                        <input type="text" style="width: 50%;" class="form-control" id="jobtitle">

                        <%--  <select name="positiontype" runat="server" id="positiontype" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                                        </select>--%>
                        <h5>Overtime</h5>
                        <input type="text" style="width: 50%;" class="form-control" id="numberofopning">
                        <h5>Timesheet Status</h5>
                        <select style="width: 50%;" data-toggle="select2">
                        </select>
                        <h5>Timesheet comment</h5>
                        <select style="width: 50%;" data-toggle="select2">
                        </select><br />
                        <br />
                        <asp:Button ID="btnaddjob" runat="server" class="btn btn-primary" Text="Search" />
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>

