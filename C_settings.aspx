<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_settings.aspx.cs" Inherits="C_settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
       <% if (Request["C_settingPop"] == "1")
            { %>

        <label id="c_settingPage" style="visibility: hidden" data-toggle="modal" data-target="#modal-settingpage_c" class="btn btn-primary"></label>

        <% } %>
     <div class="modal slide-down fade" id="modal-settingpage_c">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title">Change Profile</h4>
                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
                    <div class="modal-body">
                        <div class="panel-body">
                            Are you sure, you want to make following changes to profile:<br>
                            Company Name:&nbsp<asp:Label ID="lblcopname" runat="server" Text="Label"></asp:Label><br>
                            Phone Number:&nbsp<asp:Label ID="lblphone" runat="server" Text="Label"></asp:Label><br>
                             Fax:&nbsp<asp:Label ID="lblfax" runat="server" Text="Label"></asp:Label><br>
                             Email:&nbsp<asp:Label ID="lblemail" runat="server" Text="Label"></asp:Label><br>
                            Secondary Email:&nbsp<asp:Label ID="lblSecEmail" runat="server" Text="Label"></asp:Label><br>
                       Address1:&nbsp<asp:Label ID="lbladdress1" runat="server" Text="Label"></asp:Label><br>
                             Address2:&nbsp<asp:Label ID="lbladdress2" runat="server" Text="Label"></asp:Label><br>
                             Postal Code:&nbsp<asp:Label ID="lblpostal" runat="server" Text="Label"></asp:Label><br>
                             City:&nbsp<asp:Label ID="lblcity" runat="server" Text="Label"></asp:Label><br>
                             Country:&nbsp<asp:Label ID="lblcountry" runat="server" Text="Label"></asp:Label>

                        </div>

                    </div>
                    <div class="modal-footer">

                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="btnchangeprofile_client" OnClick="btnchangeprofile_client_Click" runat="server"  class="btn btn-primary" Text="Send" />
                    </div>
                    <%-- </form>--%>
                </div>
            </div>
        </div>
    </div>
    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>Profile</b></h4>
    </div>
     <%--<form runat="server">--%>
    <div style="width: 640px; height=100px" class="panel panel-default">
        <div class="panel-body">
            <div>
                <asp:Label ID="Label2" ForeColor="#0080FF" Font-Bold="true" runat="server" Text="Basic Information" Style="text-align: center"></asp:Label>
                <br />
                <br />
            </div>
            <%-- <form runat="server">--%>
            <div class="row">

                <div class="col-md-6">

                    <div class="form-group form-control-default">
                        <label for="exampleInputFirstName">First name</label>
                        <asp:TextBox ReadOnly="true" ID="txtfirst" class="form-control" runat="server"></asp:TextBox>
                         </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group form-control-default">
                        <label for="exampleInputLastName">Last name</label>
                        <asp:TextBox ReadOnly="true" ID="txtsecond" class="form-control" runat="server"></asp:TextBox>
                         </div>
                </div>
            </div>
            <div class="form-group form-control-default required">
                <label for="exampleInputEmail1">Email address</label>
                <asp:TextBox ID="txtemail" ReadOnly="true" class="form-control" runat="server"></asp:TextBox>
                </div>
            <%--<div id="newDiv" runat="server" class="form-group form-control-default required">
        <label for="exampleInputPassword1">Password</label>
        <input type="password" class="form-control" runat="server"  id="txtPassword1" name="txtPassword1" placeholder="Password">
    </div>--%>

            <br />
            
            <div>
              <%--  <asp:Button ID="btnupdate" class="btn btn-primary btn-xs" Visible="true" runat="server" Text="Update" OnClick="Button2_Click" />
            --%>    
                <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                
            </div>

        </div>
    </div>
     <div style="width: 640px; height=100px" class="panel panel-default">
        <div class="panel-body">
            <div>
                <asp:Label ID="Label5" ForeColor="#0080FF" Font-Bold="true" runat="server" Text="Company Information" Style="text-align: center"></asp:Label>
                <br />
                <br />
            </div>
            <%-- <form runat="server">--%>
            <div class="row">

                <div class="col-md-6">

                    <div class="form-group form-control-default">
                        <label for="exampleInputFirstName">Company Name</label>
                        <asp:TextBox  ID="txtComp_name" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group form-control-default">
                        <label for="exampleInputLastName">Phone Number</label>
                        <asp:TextBox ID="txtPhone" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group form-control-default">
                        <label for="exampleInputLastName">Fax</label>
                        <asp:TextBox ID="txtfax" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="col-md-6">
                    <div class="form-group form-control-default">
                        <label for="exampleInputEmail1">Email Address (Primary)</label>
                        <asp:TextBox ID="Txtcompemail" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="col-md-6">
                    <div class="form-group form-control-default ">
                        <label for="exampleInputEmail1">Email Address (Secondary)</label>
                        <asp:TextBox ID="txtsecEmail" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group form-control-default ">
                        <label for="exampleInputEmail1">Address 1</label>
                        <asp:TextBox ID="txtSuite" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group form-control-default ">
                        <label for="exampleInputEmail1">Address 2</label>
                        <asp:TextBox ID="txtadrres2" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group form-control-default ">
                        <label for="exampleInputEmail1">Postal Code</label>
                        <asp:TextBox ID="txtPostal" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                 <div class="col-md-6">
                    <div class="form-group form-control-default ">
                        <label for="exampleInputEmail1">City</label>
                        <asp:TextBox ID="txtcity" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group form-control-default ">
                        <label for="exampleInputEmail1">Country</label>
                        <asp:TextBox ID="txtcountry" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

            </div>

            <br />

            <div>
                  <asp:Button ID="btnupdateCompInfo" class="btn btn-primary btn-xs" Visible="true" runat="server" Text="Update" onclick="btnupdateCompInfo_Click" />

                <asp:Label ID="Label6" runat="server" Text=""></asp:Label>

            </div>

        </div>
    </div>
    <div style="width: 640px; height=100px" runat="server" class="panel panel-default">
       
        <div class="panel-body">
 <asp:Label ID="Label3" ForeColor="#0080FF" Font-Bold="true" runat="server" Text="Personal Information"></asp:Label>
            <br />
                <br />
            <%--<div id="Div1" runat="server" class="form-group form-control-default required">
        <label for="exampleInputPassword1">Password</label>
        <input type="Text" class="form-control" runat="server"  id="Password1" name="txtPassword1" placeholder="Password">
    </div>--%>

            <%--<asp:Button ID="Button2" runat="server" Text="Update Information" Visible="true" OnClick="Button1_Click1" />--%>
            <div id="div2" runat="server" visible="true" class="form-group form-control-default required">
                <label for="exampleInputPassword1">New Password</label>
                <asp:TextBox ID="txtnewpass" TextMode="Password" placeholder="Enter new password" class="form-control" runat="server"></asp:TextBox>
                 </div>
            <div id="div3" runat="server" visible="true" class="form-group form-control-default required">
                <label for="exampleInputPassword1">Confirm Password</label>
                <asp:TextBox ID="txtcompass" TextMode="Password" class="form-control" runat="server"></asp:TextBox>
                  </div>
            <br />  
            <div>
                <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-xs " OnClick="Button1_Click" Text="Update " />
                <asp:Label color="red" Font-Bold="true" ID="Label1" runat="server" Visible="true" Text=""></asp:Label>
            </div>
        </div>
        </div>
       

            <%-- SMS Notifications --%>
     <div style="width: 640px; height=100px" class="panel panel-default">
        <div class="panel-body">
            <asp:Label ID="Label7" ForeColor="#0080FF" Font-Bold="true" runat="server" Text="SMS Notifications"></asp:Label>
            <br />
                <br />
            <div class="row">
            <div class="col-lg-8 col-md-8"> <b>New Job Added</b></div>
               <div class="col-lg-4 col-md-4">
                 <asp:RadioButtonList id="RadioButtonList1" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>
                   </div>
                 
                    </div>
               <div class="row"></div>
             <div class="row">
                <div class="col-lg-8 col-md-8"><b>Interview Scheduled</b></div>
                <div class="col-lg-4 col-md-4">
                <asp:RadioButtonList id="RadioButtonList2" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>
               
                    </div>
                 </div>
              <div class="row"></div>

            <div class="row">
                <div class="col-lg-8 col-md-8"><b>Interview Rescheduled</b></div>
            <div class="col-lg-4 col-md-4">
               <asp:RadioButtonList id="RadioButtonList3" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>

                    </div>
                </div>
              <div class="row"></div>

             <div class="row">
                 <div class="col-lg-8 col-md-8"><b>Approved Candidate</b></div>
            <div class="col-lg-4 col-md-4">
                 <asp:RadioButtonList id="RadioButtonList4" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>
                    </div>
                 </div>
            <div></div>

            <div class="row">
                 <div class="col-lg-8 col-md-8"><b>Rejected Candidate</b></div>
            <div class="col-lg-4 col-md-4">
                <asp:RadioButtonList id="RadioButtonList5" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>
                    </div></div>
              <div class="row"></div>

            <div class="row">
                 <div class="col-lg-8 col-md-8"><b>Approve TimeSheet</b></div>
             <div class="col-lg-4 col-md-4">
                 <asp:RadioButtonList id="RadioButtonList6" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>
                    </div>
                </div>
             <div class="row"></div>

            <div class="row">
                <div class="col-lg-8 col-md-8"><b>Reject TimeSheet</b></div>
                             <div class="col-lg-4 col-md-4">
                  <asp:RadioButtonList id="RadioButtonList7" runat="server"> 
                 <asp:ListItem value="1" Selected>&nbsp; Enable</asp:ListItem>
                 <asp:ListItem value="0">&nbsp; Disable</asp:ListItem>
                     </asp:RadioButtonList>
                    </div>  
                </div>
            <br /><br />
            <div><asp:Button ID="updatesms" runat="server" class="btn btn-primary btn-xs " OnClick="updatesms_Click" Text="Update " />     </div>          
           
            
       </div>
         <asp:Label ID="errorDisp" runat="server" />
            

     </div>
        <%--</div>--%>
  <%--  </form>--%>
</asp:Content>

