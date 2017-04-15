<%@ Page Title="" Language="C#" MasterPageFile="~/Vendor_T.master" AutoEventWireup="true" CodeFile="calendartest.aspx.cs" Inherits="calendartest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">


    <form id="form2" runat="server">
       
       <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderStyle="None">
            <DayHeaderStyle CssClass="datepicker" />
            <DayStyle BorderStyle="None" BorderWidth="1px" Height="20px"  />
            <NextPrevStyle CssClass="datepicker" />
            <OtherMonthDayStyle CssClass="datepicker" />
            <SelectedDayStyle CssClass="datepicker" />
            <SelectorStyle CssClass="datepicker" />
            <TitleStyle BackColor="White" BorderColor="White" />
            <WeekendDayStyle BackColor="White" />
        </asp:Calendar>
        
    </form>


</asp:Content>

