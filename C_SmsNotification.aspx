<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_SmsNotification.aspx.cs" Inherits="C_SmsNotification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <from id="frm1" runat="server">
 <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>SMS Notification 
                       </b></h4>
    </div>
      <div class="panel panel-default">
            <div class="panel-body">
                <div class="row subjected">
                    <div class="col-lg-8 col-md-8">
<p class="bg-checksub"><input id="sublab" runat="server" class="form-control" placeholder="Subject" value="" >
                                 </input></p>
                    </div>
                    <div class="col-lg-4 col-md-4">
                      <div class="bg-checksub">
                          <p style="text-align: center; margin-top: 5px; font-weight: bold;"> Send SMS to</p>
                            <asp:DropDownList ID="vendor_ph" runat="server" AutoPostBack="true" CssClass="form-control" />
                          </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8 col-md-8">
                         <div class="bg-checksub"> 
                             
                        <textarea ID="messagesend" runat="server" class="form-control" placeholder="Text Message here" TextMode="MultiLine" Rows="10" Columns="60" MaxLength="160"  />
                          <div></div> 
                       <span id='remainingC'></span>
                             <br />
                               <asp:Button ID="sendmessage" runat="server" OnClick="sendmessage_Click" Text="Send" CssClass="btn btn-primary" />
                       </div>
                    </div>
                    <div class="col-lg-4 col-md-4">
                      <%-- <div class="bg-checksub">
                           
                          </div>    --%>                                            
                    </div>
                  
                </div>
            <div class="row">
               <p style="margin-top:5px; padding-left:10px;"></p>
                <asp:Label ID="error" runat="server" />
            </div>
             </div>
        </div>
        </from>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.1/jquery.min.js"></script>
   <script type="text/javascript" >

       $('textarea').keypress(function () {

           if (this.value.length > 160) {
               return false;
           }
           $("#remainingC").html("Remaining characters : " + (160 - this.value.length));
       });
       //$('#messagesend').keypress(function(){

       //    if(this.value.length > 160){
       //        return false;
       //    }
       //    $("#dispcnt").html("Remaining characters : " +(160 - this.value.length));
       //});
     
   ////    $(document).ready(function () {
         
   ////        });
   ////        updateCountdown();
   //// $('#messagesend').change(updateCountdown);
   //// $('#messagesend').keyup(updateCountdown);
   //// $('#messagesend').keypress(updateCountdown);
   ////});
   ////    function updateCountdown() {
           
   ////        var textBox = document.getElementById("messagesend");
           
   ////        var length = textBox.length; //(textBox.textContent || textBox.innerText ||
   ////        //        textBox.innerHTML).length;
   ////        alert("remaining");
   ////        var remaining = 160 - length;
   ////        alert("bolo");
   ////    $('#dispcnt').innerhtml(remaining + ' characters remaining.');
   ////}
</script>
</asp:Content>

