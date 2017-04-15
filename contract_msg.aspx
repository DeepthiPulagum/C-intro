<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor_T.master" AutoEventWireup="true" CodeFile="contract_msg.aspx.cs" Inherits="contract_msg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <%  if (Request["ms"] != null)
            { %>
    <h5><font color="red"><%=Request["ms"].ToString() %></font></h5>

    <% } %>

    <form name="formPMO" id="formPMO" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div class="media">
                   
                    <div class="media-body">
                        <span style="float: right">
                           <%-- <table>
                                <tr>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp   &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp    
                                                           
                                                                <asp:CheckBox ID="ChkVendor" runat="server" Text="PMO" Checked="true" Visible="false" />

                                    </td>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp  &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                           
                                                                <asp:CheckBox ID="ChKClient" runat="server" Text="CLIENT" Visible="false" />
                                    </td>
                                    <tr>
                                        <br />
                                    </tr>
                                <tr>
                                    <td>
                                        <span style="float: right">
                                            <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server" Width="300px">
                                                <asp:ListItem></span>Client Name</asp:ListItem>
                                                                    <asp:ListItem></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp</td>
                                    <td>
                                        <asp:DropDownList ID="DropDownList1" Visible="false" CssClass="form-control" runat="server" Width="300px">
                                            <asp:ListItem>Vendor Name</asp:ListItem>
                                        </asp:DropDownList>


                                    </td>



                                </tr>

                            </table>--%>
                        </span>
                    </div>
                    <div class="pull-right text-muted">
                        <i class="fa fa-calendar"></i>
                        <strong>
                            <asp:Label ID="lblDate" runat="server"></asp:Label></strong>
                    </div>
                    <div class="form-group">
                        <h4 class="media-heading margin-v-5">Subject of the Email</h4>
                        <input type="text" class="form-control" id="txtSubjectOfEmail" placeholder="Type here.." runat="server">
                    </div>
                </div>
            </div>
        </div>

        <div class="split-vertical-cell">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div data-scrollable="">
                        <div class="overflow-hidden">
                            <div class="form-group">
                                <h4 class="media-heading margin-v-5">Message</h4>
                                <textarea id="txtMessageofEmail" class="form-control" rows="5" placeholder="Type here.." runat="server"></textarea>
                            </div>
                            <asp:Button ID="btnSendEmail" class="btn btn-success" runat="server" Text="Send" OnClick="btnSendEmail_Click"></asp:Button>
                            <asp:Button ID="btnCancelEmail" class="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancelEmail_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>

        </div>

    </form>



</asp:Content>