<%@ Page Title="" Language="C#" MasterPageFile="~/Client_T.master" AutoEventWireup="true" CodeFile="C_Documentation.aspx.cs" Inherits="C_Documentation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <div class="panel panel-default">
       <h4 class="text-center" style="color:#0080FF"><b>View Worker</b></h4>
    </div>
      
                  

                        <div class="panel panel-default">
                            <!-- Data table -->
                            <table data-toggle="data-table" class="table" cellspacing="0" width="100%">
                                <thead>
                                    <tr>
                                        
                                            <th>Create Date</th>
                                            <th>Name of Document</th>
                                            <th>Type of Document</th>
                                            <th>Download Link</th>
                                           
                                        
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                         
                                            <th>Create Date</th>
                                            <th>Name of Document</th>
                                            <th>Type of Document</th>
                                            <th>Download Link</th>
                                           
                                       
                                    </tr>
                                </tfoot>
                                <asp:Label ID="lblFileDocument" runat="server"></asp:Label>
                             
                            </table>
     

</asp:Content>


