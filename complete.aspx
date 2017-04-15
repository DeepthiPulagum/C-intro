<%@ Page Language="C#" AutoEventWireup="true" CodeFile="complete.aspx.cs" Inherits="complete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
         <form id="form1" runat="server">
    <div>
<asp:ScriptManager ID="ScriptManager1" runat="server" 
EnablePageMethods = "true">
</asp:ScriptManager>

<asp:TextBox ID="txtContactsSearch" runat="server"></asp:TextBox>
<%--<ajaxToolkit:AutoCompleteExtender ServiceMethod="SearchCustomers" 
    MinimumPrefixLength="2"
    CompletionInterval="100" EnableCaching="false" CompletionSetCount="10" 
    TargetControlID="txtContactsSearch"
    ID="AutoCompleteExtender1" runat="server" FirstRowSelected = "false">
</ajaxToolkit:AutoCompleteExtender>--%>
    </div>
    </form>
</body>
</html>
