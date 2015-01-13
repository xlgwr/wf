<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PO_Query.aspx.cs" Inherits="Workflow.PO_Approval.PO_Query" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PO Query / PO查询</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
<div class="subHeader">
       <div>
            <asp:Label ID="lblTitle" runat="server" Text="PO Query" ToolTip="PO 查询"></asp:Label>
            --<asp:Label ID="lblTaskStatus" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
