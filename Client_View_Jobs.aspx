<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="Client_View_Jobs.aspx.cs" Inherits="Client_View_Jobs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

             <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View Jobs</b></h4>
    </div>   
    
    <div class="panel panel-default">
        <!-- Data table -->
        <table id="data-table1" data-toggle="data-table" class="table" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Sr.No</th>
                    <th>Status</th>
                    <th>ID</th>
                    <th>Title</th>
                    <th>Location</th>
                    <th>Start date</th>
                    <th>End Date</th>
                    <th>Open</th>
                    <th>Hired</th>
                    <th>left</th>
                    <th>Created</th>
                    <th>Created By</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Sr.No</th>
                    <th>Status</th>
                    <th>ID</th>
                    <th>Title</th>
                    <th>Location</th>
                    <th>Start date</th>
                    <th>End Date</th>
                    <th>Open</th>
                    <th>Hired</th>
                    <th>left</th>
                    <th>Created</th>
                    <th>Created By</th>
                </tr>
            </tfoot>
            <asp:label id="lblTableData" runat="server"></asp:label>

        </table>

    </div>
</asp:Content>

