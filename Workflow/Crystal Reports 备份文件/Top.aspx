<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Workflow.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" language="javascript">
         function Exits() {
             if (!window.confirm("Sure log off?")) {

                 return;
             }

             window.parent.location.href = "Login.aspx";
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <table width="100%" border="0" cellspacing="0" cellpadding="0"  style="background:#BDDEFF;background-image:url('Styles/images/page_bg.png'); background-repeat:repeat-x;">
        <tr>
            <td height="69" rowspan="3" width="1px">
              <%--  <img src="Styles/images/logo.gif" height="60px" alt="logo" />--%>
            </td>
            <td rowspan="3">
                <h2>Wong's Electronics Company Limited</h2>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td class="welcome" valign="bottom">
                Welcome
                <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
            </td>
            <td class="operate" valign="bottom" align="right">
                <asp:LinkButton ID="lkModify" runat="server">Modify password</asp:LinkButton>
                |
                <asp:LinkButton ID="linkSignOut" runat="server" OnClientClick="Exits()">Sign out</asp:LinkButton>&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
