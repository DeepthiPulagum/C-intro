<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor_T.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Add_worker.aspx.cs" Inherits="Add_worker" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <% if (Request["star"] != null)
        {
    %>

    <label id="starsrating" visible="false" style="visibility: hidden" data-toggle="modal" data-target="#starsqa" class="btn btn-primary"></label>
    <% } %>

    <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
    <script>tinymce.init({ selector: 'textarea' });</script>
    <script>
        function isNumberKey(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 46 || charCode > 57))
                return false;
            return true;
        }
        function validateForm() {
            return checkPhone();
        }
        function checkPhone() {
            var phone = document.forms["myForm"]["phone"].value;
            var phoneNum = /^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$/;
            if (phone.value.match(phoneNum)) {
                return true;
            }
            else {
                document.getElementById("phone").className = document.getElementById("phone").className + " error";
                return false;
            }
        }
        function formatPhone(phonenum) {
            var regexObj = /^(?:\+?1[-. ]?)?(?:\(?([0-9]{3})\)?[-. ]?)?([0-9]{3})[-. ]?([0-9]{4})$/;
            if (regexObj.test(phonenum)) {
                var parts = phonenum.match(regexObj);
                var phone = "";
                if (parts[1]) { phone += "+1 (" + parts[1] + ") "; }
                phone += parts[2] + "-" + parts[3];
                return phone;
            }
            else {
                //invalid phone number
                return phonenum;
            }
        }


    </script>

    <script src="latestJs_1.11/jquery.min.js"></script>
    <%-- <asp:HyperLink ID="ahrefid1" data-toggle="modal" data-target="#StarValidationjob"  runat="server">here</asp:HyperLink>
    <button data-toggle="modal" data-target="#StarValidationjob" class="btn btn-primary" formaction="#"  >Slide down</button>--%>
    <%--  <a href="#" data-toggle="modal" data-target="#StarValidationjob" id="ahreid"><i class="fa fa-plus"></i><span>ModalPOpu;</span></a>--%>


    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>Add Worker</b><asp:Label ID="lblDup" runat="server"></asp:Label></h4>

    </div>

    <div class="panel panel-defaultx">
        <div class="panel-body">
            <h4 class="media-heading margin-v-5" style="text-align: center"><b>
                <asp:Label ID="lbljobtitle" runat="server"></asp:Label></b>

                <font color="red">
                            <asp:label id="lblUrgent" runat="server"></asp:label>
                        </font>- 
                        <asp:Label ID="lblpositiontype" runat="server"></asp:Label>
                Position
            </h4>
            <br />
            <table class="table" cellspacing="0" width="100%">
                <tr>
                    <td>No of Openings :
                                                        
                            <asp:Label ID="lblnoofopning" runat="server"></asp:Label>
                    </td>

                    <td>Start Date :
                                                       
                            <asp:Label ID="lblstartdate" runat="server"></asp:Label>
                    </td>
                    <td>End Date :
                                                      
                            <asp:Label ID="lblenddate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="y" runat="server">
                    <td>Address :
                                                         
                            <asp:Label ID="lbladdress2" runat="server"></asp:Label>
                    </td>
                    <td>Location :
                           
                            <asp:Label ID="lbllocation2" runat="server"></asp:Label>
                    </td>
                    <td>Bill Rate :
                                 $<asp:Label ID="lblbill" runat="server"></asp:Label>
                    </td>

                </tr>
                <tr id="x" runat="server">
                    <td>Address :
                                                      
                            <asp:Label ID="lbladdres" runat="server"></asp:Label>
                    </td>
                    <td>Location :
                           
                            <asp:Label ID="lbllocation" runat="server"></asp:Label>
                    </td>
                    <td>Pay Rate :
                                 $<asp:Label ID="lblpay2" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="w" runat="server">
                    <td>Address :
                                                      
                            <asp:Label ID="lbladdress3" runat="server"></asp:Label>
                    </td>
                    <td>Location :
                           
                            <asp:Label ID="lbllocation3" runat="server"></asp:Label>
                    </td>
                    <td>Base Salary :
                                 $<asp:Label ID="lblsalary" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </div>
    </div>
    <div class="panel panel-default">
        <%-- Perosnal INfo --%>
        <div class="panel-body">
            <h4 style="color: #0080FF; text-decoration: underline;" class="text-center">Personal Information</h4>

            <div id="job" runat="server" class="form-group col-md-12">
                <h5>Job Title</h5>
                <asp:DropDownList class="form-control" name="ddljobs" ID="ddljobs" AutoPostBack="true" runat="server"></asp:DropDownList>
            </div>
            <div class="form-group col-md-12">
                <asp:Label ID="lblTableData" runat="server"></asp:Label>

                <div class="avatar">
                    <img src="images/people/110/noface.jpg" alt="" class="img-responsive" runat="server" visible="false">
                    <asp:FileUpload ID="FileUpload1" runat="server" Visible="false" />
                </div>

                <asp:Label ID="lblimagestatus" runat="server"
                    ForeColor="Black">
                </asp:Label>
            </div>
            <br />
            <br />

            <%--  <button id="btnUpload" runat="server" class="btn btn-info btn-stroke"><i class="fa fa-cloud-upload" onclick="Upload"></i></button>--%>
            <%--  <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload" />--%>
            <div class="form-group col-md-4">
                <h5>First Name
                    <asp:RequiredFieldValidator ID="reqFirstName" ControlToValidate="txtfistname" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>

                <input type="text" class="form-control" id="txtfistname" runat="server" name="txtfistname" enableviewstate="true">
            </div>

            <div class="form-group col-md-4">
                <h5>Middle Name</h5>
                <input type="text" class="form-control col-xs-6 .col-md-4" placeholder="" id="txtmiddle" runat="server" name="txtmiddle">
            </div>

            <div class="form-group col-md-4">
                <h5>Last Name
                    <asp:RequiredFieldValidator ID="reqLastName" ControlToValidate="txtlastname" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtlastname" placeholder="" runat="server" name="txtlastname">
            </div>

            <div class="form-group col-md-4">
                <h5>Email 
                    <asp:RequiredFieldValidator ID="reqEmail" ControlToValidate="txtemail" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>

                </h5>
                <blink><font color="red"><asp:Label ID="lblDuplicate" runat="server"></asp:Label></font></blink>
                <asp:TextBox ID="txtemail" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
            </div>

            <div class="form-group col-md-4">
                <h5>Phone
                    <asp:RequiredFieldValidator ID="reqPhone" ControlToValidate="txtphone" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtphone" onkeypress="return isNumberKey(event)" onsubmit="return validateForm()" runat="server" name="txtphone">
            </div>

            <div class="form-group col-md-4 ">
                <h5>DOB
                    <asp:RequiredFieldValidator ID="reqDOB" ControlToValidate="txtdateofbirth" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <div class="form-group">
                    <input type="text" id="txtdateofbirth" runat="server" placeholder="" name="txtdateofbirth" class="form-control datepicker">
                </div>
            </div>

            <div class="form-group col-md-2">
                <h5>Suite/Apt
                    <asp:RequiredFieldValidator ID="reqSuite" ControlToValidate="txtsuite" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtsuite" placeholder="" runat="server" name="txtsuite">
            </div>

            <div class="form-group col-md-6">
                <h5>Address
                    <asp:RequiredFieldValidator ID="reqtxtAddress1" ControlToValidate="txtaddress1" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtaddress1" placeholder="" runat="server" name="txtaddress1">
            </div>

            <div class="form-group col-md-4">
                <h5>Availability
                    <asp:RequiredFieldValidator ID="reqAvailability" ControlToValidate="txtavailable" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <div class="form-group">
                    <input type="text" id="txtavailable" runat="server" name="txtavailable" class="form-control datepicker">
                </div>
            </div>

            <div class="form-group col-xs-4">
                <h5>City
                    <asp:RequiredFieldValidator ID="reqCity" ControlToValidate="txtCity" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtcity" runat="server" name="txtcity">
            </div>

            <div class="form-group  col-xs-4">
                <h5>State or Province / Country
                       <asp:RequiredFieldValidator ID="reqprivince" ControlToValidate="ddlprivince" InitialValue="0" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <asp:DropDownList class="form-control" name="ddlprivince" ID="ddlprivince" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group  col-xs-4">
                <h5>Postal/Zip
                    <asp:RequiredFieldValidator ID="reqPostal" ControlToValidate="txtpostal" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtpostal" runat="server" name="txtpostal">
            </div>

            <div class="form-group col-md-2">
                <h5>Skype ID</h5>
                <input type="text" class="form-control" id="txtskype" runat="server" name="txtskype">
            </div>

            <div class="form-group col-md-4">
                <h5>License Number
                    <%--<span style="float: right" id="message" class="fa fa-question-circle"><a href="#"></a>
                    </span>--%><asp:RequiredFieldValidator ID="reqLicNumber" ControlToValidate="txtlicence" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="Text" class="form-control" id="txtlicence" runat="server" name="txtlicence">
            </div>

            <div class="form-group col-md-4">
                <h5>Last 4 Digits of SSN/SIN
                        <asp:RequiredFieldValidator ID="reqSin" ControlToValidate="txtsinnumber" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator>
                </h5>
                <input type="Text" class="form-control" id="txtsinnumber" runat="server" name="txtsecutity">
            </div>

            <%--<div class="form-group col-md-4">
                    <h5>conform Security ID</h5>
                    <input type="password" class="form-control" id="txtconformsecutity" runat="server" onkeyup="checkPass(); return false;" name="txtconformsecutity" required>
                    <asp:Label ID="confirmMessage" runat="server"></asp:Label>
                </div>--%>
        </div>
    </div>

    <%-- Perosnal Info Ends--%>
    <%-- Salary --%>
    <div class="panel panel-default">
        <div class="panel-body">

            <h4 style="color: #0080FF; text-decoration: underline;" class="text-center">Salary Details</h4>
            <%--  </div>
                <div class="form-group col-md-6">--%>
            <div class="form-group col-md-2">
                <h5>Pay Rate
                    <asp:RequiredFieldValidator ID="reqPayRate" ControlToValidate="txtstdpayf" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <input type="text" class="form-control" id="txtstdpayf" placeholder="" runat="server" maxlength="5" name="txtstdpayf">
            </div>
            <%--   <div class="form-group col-md-6">
                    <h5>Pay Rate To</h5>
                    <input type="text" class="form-control" id="txtstdpayt" runat="server" name="txtstdpayt">
                </div>--%>
        </div>
    </div>

    <%-- Salary Ends--%>
    <%-- Supporting Docs --%>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="form-group col-md-12">
                <h4 style="color: #0080FF; text-decoration: underline;" class="text-center">Supporting Documents</h4>
                <h5>Upload Your Resume
                    <asp:RequiredFieldValidator ID="reqUpload" ControlToValidate="fileupresume" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                <asp:FileUpload ID="fileupresume" runat="server" />


                <asp:Label ID="lblresumestatus" runat="server" Text="Only .doc or .docx file are allowed."
                    ForeColor="Black">
                </asp:Label>
            </div>
        </div>
    </div>
    <%-- <div class="panel panel-default">
            <div class="panel-body">
                <div class="form-group col-md-12">
                    <h4 style="color: #0080FF; text-decoration: underline;" class="text-center">Comparition</h4>

                    <div class="form-group col-md-12">
                        <h5>Questions Ratings</h5>
                    </div>
                    <div>--%>

    <div id="divstar" runat="server">
        <div class="panel panel-default">
            <div class="panel-body">
                <div>
                    <div class="overflow-hidden">
                        <h4 class="media-heading margin-v-5" style="color: #0080FF"><b>Job Rating</b><span style="float: right">
                            <%-- <asp:Button ID="btnadd" runat="server" Text="Add New" data-toggle="tk-modal-demo" data-modal-options="slide-down" data-content-options="modal-lg" class="btn btn-primary" OnClick="btnadd_Click" />--%>
                        </span></h4>
                        <div id="questions1">
                            <div class="form-group col-md-4">
                                <h5>Question #1 (<small>Set by Client</small>)</h5>
                                <asp:Label ID="lblque1" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:TextBox ID="txtRating1" name="txtRating1" ReadOnly class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprating1" name="txtemprating1" class="rating rating10" value="3" runat="server" />

                                <asp:CompareValidator ID="comvalid11" runat="server" ControlToCompare="txtemprating1" ControlToValidate="txtRating1" Operator="LessThanEqual" Type="Integer" ErrorMessage="Candidate does not meet minimum requirement" />
                            </div>
                        </div>
                        <div class="form-group col-md-12">
                        </div>
                        <div id="questions2">
                            <div class="form-group col-md-4">
                                <h5>Question #2 (<small>Set by Client</small>)</h5>
                                <asp:Label ID="labque2" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:TextBox ID="txtRating2" name="txtRating2" ReadOnly class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprating2" name="txtemprating2" class="rating rating10" value="3" runat="server" />
                                <asp:CompareValidator ID="comvalid10" runat="server" ControlToCompare="txtemprating2" ControlToValidate="txtRating2" Operator="LessThanEqual" Type="Integer" ErrorMessage="Candidate does not meet minimum requirement" />
                            </div>
                        </div>
                        <div class="form-group col-md-12">
                        </div>
                        <div id="questions3">
                            <div class="form-group col-md-4">
                                <h5>Question #3 (<small>Set by Client</small>)</h5>
                                <asp:Label ID="lblque3" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:TextBox ID="txtRating3" name="txtRating3" ReadOnly class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprating3" name="txtemprating3" class="rating rating10" value="3" runat="server" />
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtemprating3" ControlToValidate="txtRating3" Operator="LessThanEqual" Type="Integer" ErrorMessage="Candidate does not meet minimum requirement" />
                            </div>
                        </div>
                        <div class="form-group col-md-12">
                        </div>
                        <div id="questions4">
                            <div class="form-group col-md-4">
                                <h5>Question #4 (<small>Set by Client</small>)</h5>
                                <asp:Label ID="lblque4" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:TextBox ID="txtRating4" name="txtRating4" ReadOnly class="rating rating10" value="3" runat="server" />

                                <asp:TextBox ID="txtemprating4" name="txtemprating4" class="rating rating10" value="3" runat="server" />

                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToCompare="txtemprating4" ControlToValidate="txtRating4" Operator="LessThanEqual" Type="Integer" ErrorMessage="Candidate does not meet minimum requirement" />
                            </div>
                        </div>
                        <div class="form-group col-md-12">
                        </div>
                        <div id="questions5">
                            <div class="form-group col-md-4">
                                <h5>Question #5 (<small>Set by Client</small>)</h5>
                                <asp:Label ID="lblque5" runat="server"></asp:Label>
                            </div>
                            <div class="form-group col-md-4">
                                <asp:TextBox ID="txtRating5" name="txtRating5" ReadOnly class="rating rating10" value="3" runat="server" />
                                <asp:TextBox ID="txtemprating5" name="txtemprating5" class="rating rating10" value="3" runat="server" />
                                <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToCompare="txtemprating5" ControlToValidate="txtRating5" Operator="LessThanEqual" Type="Integer" ErrorMessage="Candidate does not meet minimum requirement" />
                            </div>
                        </div>
                        <br />
                    </div>
                    <%--   <div class="col-md-2 col-md-offset-5">
                                                        </div>--%>
                </div>
            </div>
        </div>
    </div>


    <%-- Supporting Docs Ends--%>
    <%-- Others --%>
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="form-group col-md-12">
                <h4 style="color: #0080FF; text-decoration: underline;">Other Information</h4>
                <h5>Comments</h5>
                <asp:TextBox ID="txtcomment" class="form-control" runat="server" TextMode="MultiLine" Height="60%"></asp:TextBox>
                <%--  <input type="text" class="form-control" id="txtcomment" runat="server" name="txtcomment">--%>
            </div>

            <div class="form-group col-md-12">
                <asp:Button ID="btnpreview" runat="server" Text="Preview and submit" class="btn btn-primary pull-left" OnClick="btnpreview_Click1" />
                <%--  <asp:Button ID="BtnAddWorker" runat="server" Text="Add Worker" class="btn btn-success pull-right" OnClick="BtnAddWorker_Click1" />--%>
            </div>
        </div>
        <%-- Others Ends --%>
    </div>

    <%--  <% if (txtRating1.Text.Length') >= document.getElementById('txtemprating1.Text.Length'))
            {
        %>
        <label id="moredetails" visible="false" style="visibility: hidden" data-toggle="modal" data-target="#modal-more" class="btn btn-primary"></label>
        <% } %>--%>

    <%--<div class="modal slide-down fade" id="starsqa">
        <div class="modal-dialog">
            <div class="v-cell">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                        <h4 class="modal-title" style="color: #0080FF">Canddidate does not meet minimumum requirements</h4>

                    </div>
                    <%-- <form name="form3" method="post" action="emp_actions.aspx">--%>
    <%-- %> <div class="modal-body">
                        <div class="panel-body">
                            <h5>The Candidate that you about to submit does not meet the minimumum Requirement </h5>
                            <h5>Do you want to sumbmit this candidate ?</h5>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                        <asp:Button class="btn btn-primary" ID="btncont" runat="server" OnClick="btncont_Click" CausesValidation="false" Text="Yes" />
                    </div>
                   </form>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>
