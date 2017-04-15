<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_View_Worker.aspx.cs" Inherits="C_View_Worker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View Workers</b></h4>
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
                    <th>Location</th>
                    <th>Start date</th>
                    <th>End Date</th>
                  <%--  <th>Created by</th>--%>
              
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
                  <%--  <th>Created by</th>--%>
             
                </tr>

            </tfoot>
            <asp:Label ID="lblTableData" runat="server"></asp:Label>

        </table>
        <!-- // Data table -->
      
    </div>
</asp:Content>

