<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Client_Edit_job.aspx.cs" Inherits="Client_Edit_job" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <script language="Javascript">
        //document.getElementById("questions").hidden == true;
        //document.getElementById('questions').style.display = "none";
        function isNumberKey(evt) {
            evt = (evt) ? evt : window.event;
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode > 31 && (charCode < 46 || charCode > 57))
                return false;
            return true;
        }

        function DoQuestions() {

            if (document.getElementById('questions1').style.display == "block") {
                document.getElementById('questions1').style.display = "none";
            } else {
                document.getElementById('questions1').style.display = "block";
            }
            if (document.getElementById('questions2').style.display == "block") {
                document.getElementById('questions2').style.display = "none";
            } else {
                document.getElementById('questions2').style.display = "block";
            }
            if (document.getElementById('questions3').style.display == "block") {
                document.getElementById('questions3').style.display = "none";
            } else {
                document.getElementById('questions3').style.display = "block";
            }
            if (document.getElementById('questions4').style.display == "block") {
                document.getElementById('questions4').style.display = "none";
            } else {
                document.getElementById('questions4').style.display = "block";
            }
            if (document.getElementById('questions5').style.display == "block") {
                document.getElementById('questions5').style.display = "none";
            } else {
                document.getElementById('questions5').style.display = "block";
            }
        }
        function HideQuestions() {

            document.getElementById('questions1').style.display = "none";

            document.getElementById('questions2').style.display = "none";

            document.getElementById('questions3').style.display = "none";

            document.getElementById('questions4').style.display = "none";

            document.getElementById('questions5').style.display = "none";

        }

        function checkCheckbox() {
            document.getElementById("checkQuestions").checked = true;

            document.getElementById('questions1').style.display = "block";

            document.getElementById('questions2').style.display = "block";

            document.getElementById('questions3').style.display = "block";

            document.getElementById('questions4').style.display = "block";

            document.getElementById('questions5').style.display = "block";
        }
        function setovertimedouble() {
            // if (document.getElementById('txtst_bill_rate_from').value != null)
            // {
            alert(document.getElementById('txtst_bill_rate_from').value)
            // }
        }
    </script>
    <script src="//cdn.tinymce.com/4/tinymce.min.js"></script>
    <script>tinymce.init({ selector: 'textarea' });</script>
    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>Edit Job</b></h4>
    </div>

    <div class="panel panel-default">
        <asp:TextBox ID="TextBox1" runat="server" Text="2" Visible="false"></asp:TextBox>
        <asp:Label ID="lblTableData" CssClass="text-blue-400" runat="server"></asp:Label>
        <div class="row">
            <div class="panel-body">
                <asp:TextBox ID="ddllocation" runat="server" Visible="false" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>
                <asp:TextBox ID="ddldepartment" runat="server" Visible="false" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>
                <asp:TextBox ID="ddlvendor" runat="server" Visible="false" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>
                <asp:TextBox ID="ddljobStatus" runat="server" Visible="false" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>
                <asp:TextBox ID="ddlpositiontype" runat="server" Visible="false" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>
               

                <div class="col-md-4">
                    <h5>Job Title 
                        <asp:RequiredFieldValidator ID="reqjobtitle" ControlToValidate="txtjobtitle" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>

                    <input type="text" class="form-control" id="txtjobtitle" runat="server" name="txtjobtitle">
                </div>
                <div class="col-md-4">
                    <h5>Hiring Manager Name 
                        <asp:RequiredFieldValidator ID="reqmanager" ControlToValidate="txthiremanagername" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <input type="text" class="form-control" id="txthiremanagername" runat="server" name="txthiremanagername">
                </div>
                <div class="col-md-4">
                    <h5>Hours Per Day 
                        <asp:RequiredFieldValidator ID="reqhours" ControlToValidate="txthoursperday" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <input type="text" class="form-control" onkeypress="return isNumberKey(event)" id="txthoursperday" runat="server" name="txthoursperday">
                </div>
                <%-- <div class="col-md-4">
                    <h5>Job Status <asp:RequiredFieldValidator ID="reqstatus" ControlToValidate="ddljobStatus" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator> </h5>
                    <select name="jobStatus" class="selectpicker" runat="server" id="ddljobStatus" data-style="btn-white" data-live-search="true" data-size="5">
                    </select>
                </div>--%>
                <%--<div class="col-md-4">
                    <h5>Job location <asp:RequiredFieldValidator ID="reqlocation" ControlToValidate="ddllocation" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <select name="ddllocation" runat="server" id="ddllocation" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                    </select>
                    
                </div>--%>

                <div class="col-md-4">
                    <h5>No of Openings
                        <asp:RequiredFieldValidator ID="reqnumb" ControlToValidate="txtnumberofopning" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <select name="txtnumberofopning" runat="server" id="txtnumberofopning" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                    </select>

                </div>

                <%--  <div class="col-md-4">
                    <h5>Department <asp:RequiredFieldValidator ID="reqdepart" ControlToValidate="ddldepartment" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <select name="department" runat="server" id="ddldepartment" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                    </select>
                </div>--%>
                <div class="col-md-4">
                    <h5>Travel Time(%)
                        <asp:RequiredFieldValidator ID="reqtrav" ControlToValidate="txttraveltime" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <select name="txttraveltime" runat="server" id="txttraveltime" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                    </select>
                </div>

                <%--  <div class="col-md-4">
                    <h5>Vendor <asp:RequiredFieldValidator ID="reqvendor" ControlToValidate="ddlvendor" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>

                    <select class="selectpicker" name="vendor" runat="server" id="ddlvendor" data-style="btn-white" data-live-search="true" data-size="5">
                    </select>

                </div>--%>
                <div class="col-md-4">
                    <h5>Wiling to Relocate?
                        <asp:RequiredFieldValidator ID="reqmove" ControlToValidate="ddlmove" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <asp:DropDownList class="form-control" runat="server" ID="ddlmove">
                        <asp:ListItem Text="--select--" Value="1" Selected="true" />
                        <asp:ListItem Text="Yes" Value="2" />
                        <asp:ListItem Text="No" Value="3" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-12">
                    <h5>Roles And Responsibility
                        <asp:RequiredFieldValidator ID="reqroles" ControlToValidate="txtroles_and_responsibility" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <asp:TextBox ID="txtroles_and_responsibility" runat="server" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>

                </div>



                <div class="col-md-4">
                    <h5>Coordinator
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="txtcoordinator" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <input type="text" class="form-control" id="txtcoordinator" runat="server" name="txtcoordinator">
                </div>

                <%--<div class="form-group col-md-3">
                        <h5>Create Date</h5>
                        <input type="text" id="txtcreatedate" runat="server" name="txtcreatedate" class="form-control datepicker">
                    </div>--%>


                <div class="col-md-4">
                    <h5>Maximum Submition Per Supplier
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtmaxsub" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <input id="txtmaxsub" onkeypress="return isNumberKey(event)" type="text" value="3" name="txtmaxsub" runat="server" class="form-control" />
                </div>


                <div class="col-md-4">
                    <h5>Interview Requirement
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="ddlinterviw" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <asp:DropDownList class="form-control" runat="server" ID="ddlinterviw">
                        <asp:ListItem Text="--select--" Value="--select--" Selected="true" />
                        <asp:ListItem Text="Yes" Value="Yes" />
                        <asp:ListItem Text="No" Value="No" />
                    </asp:DropDownList>
                </div>

                <div class="col-md-4">
                    <h5>Reason for Open
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="ddlreasonforopen" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                    <asp:DropDownList class="form-control" runat="server" ID="ddlreasonforopen">
                        <asp:ListItem Text="--select--" Value="--select--" Selected="true" />
                        <asp:ListItem Text="New Position" Value="New Position" />
                        <asp:ListItem Text="Backfill" Value="Backfill" />
                        <asp:ListItem Text="Replacement" Value="Replacement" />
                    </asp:DropDownList>
                </div>
                <div id="divjobstart" runat="server">
                    <div class="col-md-4">
                        <h5>Job Start Date
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="txtjobstart" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control datepicker" placeholder="Choose a Date" id="txtjobstart" runat="server" name="txtjobstart">
                    </div>
                </div>
                <div id="permentdiv" runat="server">
                    <div class="col-md-4">
                        <h5>Base Salary
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="txtbasesallary" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtbasesallary" runat="server" name="txtbasesallary">
                    </div>
                    <div class="col-md-4">
                        <h5>Bonus
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="txtbouns" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtbouns" runat="server" name="txtbouns">
                    </div>
                    <div class="col-md-12">
                        <h5>Benefits
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="txtbenifits" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <asp:TextBox ID="txtbenifits" runat="server" class="form-control" TextMode="MultiLine" Height="40%"></asp:TextBox>
                    </div>
                </div>
                <div id="markupdiv" runat="server">
                    <div class="col-md-4">
                        <h5>Markup (%)
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="txtmarkup" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtmarkup" runat="server" name="txtmarkup" />
                        <%-- <input id="txtmarkup" data-toggle="touch-spin" data-verticalbuttons="true" type="text" value="32" data-postfix="%" name="txtmarkup" runat="server" class="form-control" />--%>
                    </div>
                    <div class="col-md-4">
                        <h5>Pay Rate
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="txtstd_pay_rate_from" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtstd_pay_rate_from" runat="server" name="txtstd_pay_rate_from" />
                    </div>
                    <div class="col-md-4">
                        <h5>Vendor Pay Rate
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="txtvendor_pay" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtvendor_pay" runat="server" name="txtvendor_pay">
                    </div>

                    <div class="col-md-4">
                        <h5>Vendor Overtime Pay Rate
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="txtvendorot_pay" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtvendorot_pay" runat="server" name="txtvendorot_pay">
                    </div>
                    <div class="col-md-4">
                        <h5>Vendor DoubleTime Pay Rate
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="txtvendordbl_pay" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" id="txtvendordbl_pay" runat="server" name="txtvendordbl_pay">
                    </div>
                </div>
                <div id="newdiv" runat="server">
                    <div class="col-md-4">
                        <h5>Bill Rate
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="txtst_bill_rate_from" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control" onchange="setovertimedouble()" id="txtst_bill_rate_from" runat="server" name="txtst_bill_rate_from">
                    </div>
                </div>

                <div id="divposition" runat="server">
                  <%--  <div class="col-md-4">
                        <h5>Position Type
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator25" ControlToValidate="ddlpositiontype" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <select name="positiontype" runat="server" id="ddlpositiontype" placeholder="--select--" class="selectpicker" data-style="btn-white" data-live-search="true" data-size="5">
                        </select>
                    </div>--%>

                    <div class="col-md-4">
                        <h5>Contract Start Date
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator26" ControlToValidate="txtcontstart" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control datepicker" placeholder="Choose a Date" onkeypress="return isNumberKey(event)" id="txtcontstart" runat="server" name="txtcontstart">
                    </div>
                    <div class="col-md-4">
                        <h5>Contract End Date
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator27" ControlToValidate="txtendstart" runat="server" ErrorMessage="* Required"></asp:RequiredFieldValidator></h5>
                        <input type="text" class="form-control datepicker" placeholder="Choose a Date" onkeypress="return isNumberKey(event)" id="txtendstart" runat="server" name="txtendstart">
                    </div>
                </div>
                <div class="col-md-12">
                    <h5>Comments</h5>
                    <asp:TextBox ID="txtcomment" runat="server" class="form-control" TextMode="MultiLine" Height="60%"></asp:TextBox>

                </div>
                <div class="col-md-2">
                    <h5>Urgent</h5>
                    <div>
                        <asp:CheckBox ID="checkurgent" runat="server" Checked="true" CssClass="checkbox-danger" />
                        <%--<input type="checkbox" id="checkurgent" checked="checked">--%>
                        <label for="checkurgent">This job is Urgent!</label>
                    </div>
                </div>

                <div class="col-md-12">
                    <h5>Questions (up to 5 questions)</h5>
                    <div class="checkbox checkbox-danger">
                        <input type="checkbox" id="checkQuestions" onclick="DoQuestions();">
                        <label for="checkQuestions">I want to ask questions to candidates</label>
                    </div>
                </div>

                <div id="questions1" hidden="hidden">
                    <div class="col-md-6">
                        <h5>Question #1 </h5>
                        <asp:TextBox ID="txtQuestion1" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <h5>Minimum Rating Needed (out of 10)</h5>
                        <asp:TextBox ID="txtRating1" name="txtRating1" class="rating rating10" value="3" runat="server" />
                    </div>
                </div>
                <div class="col-md-12">
                </div>
                <div id="questions2" hidden="hidden">
                    <div class="form-group col-md-6">
                        <h5>Question #2</h5>
                        <asp:TextBox ID="txtQuestion2" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <h5>Minimum Rating Needed</h5>
                        <asp:TextBox ID="txtRating2" name="txtRating2" class="rating rating10" value="3" runat="server" />
                    </div>
                </div>
                <div class="col-md-12">
                </div>
                <div id="questions3" hidden="hidden">
                    <div class="col-md-6">
                        <h5>Question #3</h5>
                        <asp:TextBox ID="txtquestion3" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <h5>Minimum Rating Needed</h5>
                        <asp:TextBox ID="txtRating3" name="txtRating3" class="rating rating10" value="3" runat="server" />
                    </div>
                </div>
                <div class="form-group col-md-12">
                </div>
                <div id="questions4" hidden="hidden">
                    <div class="col-md-6">
                        <h5>Question #4</h5>
                        <asp:TextBox ID="txtquestion4" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-4">
                        <h5>Minimum Rating Needed</h5>
                        <asp:TextBox ID="txtRating4" name="txtRating4" class="rating rating10" value="3" runat="server" />
                    </div>
                </div>
                <div class="col-md-12">
                </div>
                <div id="questions5" hidden="hidden">
                    <div class="form-group col-md-6">
                        <h5>Question #5</h5>
                        <asp:TextBox ID="txtquestion5" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <h5>Minimum Rating Needed</h5>
                        <asp:TextBox ID="txtRating5" name="txtRating5" class="rating rating10" value="3" runat="server" />
                    </div>
                </div>



                <div class="form-group col-md-12" style="text-align: center">
                    <asp:Button ID="btnaddjob" runat="server" class="btn btn-primary pull-left" Text="Preview And Submit" OnClick="btnaddjob_Click" />
                </div>
            </div>
        </div>
    </div>
 
</asp:Content>