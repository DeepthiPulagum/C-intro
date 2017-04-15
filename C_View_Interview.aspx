<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_View_Interview.aspx.cs" Inherits="C_View_Interview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View Interview</b></h4>
    </div>
    <div class="panel panel-default">
        <!-- Data table -->
        <table data-toggle="data-table" class="table" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>ID</th>
                    <th>Candidate Name</th>
                    <th>Job Title</th>
                    <th>Interview Date</th>
                    <th>Start Time</th>
                    <th>End Time</th>
                    <th>Interviewer</th>
                    <th>Comments</th>

                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Sr.No</th>
                    <th>ID</th>
                    <th>Candidate Name</th>
                    <th>Job Title</th>
                    <th>Interview Date</th>
                    <th>Start Time</th>
                    <th>End Time</th>
                    <th>Interviewer</th>
                    <th>Comments</th>
                </tr>

            </tfoot>
            <asp:Label ID="lblTableData" runat="server"></asp:Label>

        </table>
        <!-- // Data table -->

    </div>
</asp:Content>