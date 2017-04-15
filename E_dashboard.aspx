<%@ Page Title="" Language="C#" MasterPageFile="~/Employee_T.master" AutoEventWireup="true" CodeFile="E_dashboard.aspx.cs" Inherits="E_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="panel panel-default">
        <h4 class="text-center" style="color: #0080FF"><b>
            <asp:Label ID="lblnothing" runat="server"> You are currently </asp:Label>
            <asp:Label ID="lblEmployeeStatus" runat="server"></asp:Label>
            </b></h4>
    </div>
    <div class="row">
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_jobgrid.aspx" style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <%--<div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_information.aspx" style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>--%>
        
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_refer_friend.aspx" style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_revnue_contratct.aspx"  style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="ContractStart" Visible="false" runat="server"></asp:Label>

    <asp:Label ID="ContractEnd" Visible="false" runat="server"></asp:Label>
    <div class="row">
        <%--<div class="item col-md-6 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_refer_friend.aspx" style="width: 100%; height: 430px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>

        </div>--%>
        <div class="item col-md-8 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_jobdescription.aspx" style="width: 100%; height: 485px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_absance_request.aspx" style="width: 100%; height: 485px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
        
    </div>
    <div class="row">
        
    </div>
    <%--    <div class="row">
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_jobgrid.aspx" style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_information.aspx" style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
        <div class="item col-md-4 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_revnue_contratct.aspx" style="width: 100%; height: 335px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Label ID="ContractStart" Visible="false" runat="server"></asp:Label>

    <asp:Label ID="ContractEnd" Visible="false" runat="server"></asp:Label>
    <div class="row">
        <div class="item col-md-6 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_refer_friend.aspx" style="width: 100%; height: 430px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>

        </div>
        <div class="item col-md-6 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_absance_request.aspx" style="width: 100%; height: 430px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>



    </div>
    <div class="row">
        <div class="item col-md-12 col-xs-12">
            <div class="panel panel-default timeline-appointments">
                <div class="panel-heading">
                    <div id="layoutContainer">
                        <iframe src="E_jobdescription.aspx" style="width: 100%; height: 485px" frameborder="0" hspace="0" vspace="0" marginheight="0" marginwidth="0"></iframe>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
</asp:Content>


