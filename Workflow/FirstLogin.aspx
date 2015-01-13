<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FirstLogin.aspx.cs" Inherits="Workflow.FirstLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="Scripts/Login.js" type="text/javascript"></script>
    <title>Set Password</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="subHeader">
        <div>
            <asp:Label ID="lblTitle" runat="server" Text="Setting Passphrase" ToolTip="设 置 密 码"></asp:Label>
        </div>
    </div>
    <div>
        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed;">
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblNewPass" runat="server" Text="Passphrase" ToolTip="密码"></asp:Label>:
                    </div>
                </td>
                <td>
                    <div align="left">
                        <asp:TextBox ID="txtNewPass" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        &nbsp;
                        <asp:Label ID="lblWarm" runat="server" Text="passphrase at least 6 alphanumeric"
                            ForeColor="Red"></asp:Label>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblConfirmPass" runat="server" Text="Confirm Passphase" ToolTip="确认密码"></asp:Label>:</div>
                </td>
                <td>
                    <div align="left">
                        <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#EAF2F9">
                <td colspan="2">
                    <div align="center">
                        <asp:Button ID="btnModify" runat="server" Text="Modify" ToolTip="修 改" CssClass="btnNormal"
                            OnClick="btnAdd_Click" UseSubmitBehavior="false" />
                    </div>
                </td>
            </tr>
            <tr bgcolor="#EAF2F9">
                <td colspan="2">
                    <div align="center">
                        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                    </div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
