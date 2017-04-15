<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor_T.master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
   
        <div class="v-cell">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title">Worker Actions</h4>
                </div>
                <div class="modal-body">
                    <table style="width:700px;height:400px;border:thin;border-color:gray">
                        <tr>
                            <td valign="top" style="width:200px">Interview Details</td>
                            <td valign="top" style="width:500px;height:400px">
                                <table style="width:500px;height:400px">
                                    <tr>
                                        <td valign="top">Reschedule</td>
                                    </tr>
                                    <tr>
                                        <td><hr />Approve</td>
                                    </tr>                                    
                                    <tr>
                                        <td><hr />Reject</td>
                                    </tr>
                                    <tr>
                                        <td><hr />Cancel Interview</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer">
					<button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
					<%--<button type="button" class="btn btn-primary" data-dismiss="modal">Save</button>--%>
				</div>
            </div></div>
</asp:Content>

