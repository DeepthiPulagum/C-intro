<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_Invoices.aspx.cs" Inherits="C_Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:TextBox ID="Txtbox1" Visible="false" runat="server"></asp:TextBox>
    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>View Invoices</b></h4>
    </div>
    <div class="panel panel-default">
        <!-- Data table -->
        <table id="data-table1" data-toggle="data-table" class="table" cellspacing="0" width="100%">
            <thead>
                <tr>
                    <th>Contractor Name</th>
                    <th>Week Starting</th>
                    <th>Week Ending</th>
                    <th>Total Hours</th>
                    <th>Standard Hours</th>
                    <th>Standard Rate</th>
                    <th>Standard Amount</th>
                    <th>Overtime Hours</th>
                    <th>Overtime Rate</th>
                    <th>Overtime Amount</th>
                    <th>Gross Amount</th>
                    <th>Volume Discount</th>
                    <th>Program Fee</th>
                    <th>Tax Amount</th>
                    <th>Net Supplier Payable</th>
                         <th>Vendor Name</th>
                </tr>
            </thead>
            <tfoot>
                <tr>
                    <th>Contractor Name</th>
                    <th>Week Starting</th>
                    <th>Week Ending</th>
                    <th>Total Hours</th>
                    <th>Standard Hours</th>
                    <th>Standard Rate</th>
                    <th>Standard Amount</th>
                    <th>Overtime Hours</th>
                    <th>Overtime Rate</th>
                    <th>Overtime Amount</th>
                    <th>Gross Amount</th>
                    <th>Volume Discount</th>
                    <th>Program Fee</th>
                    <th>Tax Amount</th>
                    <th>Net Supplier Payable</th>
                    <th>Vendor Name</th>
                </tr>
            </tfoot>
            <asp:Label ID="lblTableData" runat="server"></asp:Label>

        </table>


        </div>
</asp:Content>

