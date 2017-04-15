<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_View_rejectedCandidate.aspx.cs" Inherits="C_View_rejectedCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
<div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>Rejected Candidate</b></h4>
    </div>
    <div class="panel panel-default">
        <!-- Data table -->
        <table data-toggle="data-table" class="table" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Job Title</th>
                    <th>Rejected Date</th>
                    <th>Rejected Time</th>
                    <th align='center'>Reason</th>
                    <th>Rejected By</th>
                    
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Sr.No</th>
                    <th>ID</th>
                    <th>Candidate Name</th>
                    <th>Job Title</th>
                    <th>Rejected Date</th>
                    <th>Rejected Time</th>
                    <th>Reason</th>
                    <th>Rejected By</th>

                </tr>

            </tfoot>
            <asp:Label ID="lblTableData" runat="server"></asp:Label>

        </table>
        <!-- // Data table -->

    </div>
</asp:Content>


