<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PO_Approval.aspx.cs" Inherits="Workflow.PO_Approval.PO_Approve" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PO Approval / PO审批</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function aa() {
            var a = document.getElementById("GridViewFix_Detail").scrollTop;
            var b = document.getElementById("GridViewFix_Detail").scrollLeft;
            document.getElementById("GridViewFix_Head").scrollLeft = b;
        } 
        function showCondition() {
            if ($("#tblCondition").css("display") != "none") {
                $("#tblCondition").fadeOut("fast");
            }
            else {
                $("#tblCondition").fadeIn("slow");
            }

        }

</script> 
</head>
<body onresize="resizePOApprovalWindow()" onload="resizePOApprovalWindow()">
    <form id="form1" runat="server">

    <div class="subHeader">
       <div>
            <asp:Label ID="lblTitle" runat="server" Text="PO Approval" ToolTip="PO审批"></asp:Label>
            --<asp:Label ID="lblTaskStatus" runat="server" Text=""></asp:Label>
        </div>
    </div>
        <%=sss %>
        <input type="button" value="Click Me" onclick="showCondition()" />
        <div id="tblCondition" style="display:none">
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />

    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />

    </form>
</body>
</html>
