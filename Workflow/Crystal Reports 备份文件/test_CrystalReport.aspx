<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test_CrystalReport.aspx.cs" Inherits="Workflow.test_CrystalReport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <CR:CrystalReportViewer runat="server" AutoDataBind="true"  ID="cryView">
        </CR:CrystalReportViewer>
    </div>
    </form>
   
</body>
</html>
