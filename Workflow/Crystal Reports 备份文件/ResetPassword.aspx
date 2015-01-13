<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Workflow.ResetPassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="Scripts/Common.js" type="text/javascript"></script>
    <script src="Scripts/Login.js" type="text/javascript"></script>
    <title>Reset Passphrase</title>
    <script language="javascript" type="text/javascript">
        $(document).ready(function () { 
            
        })
            </script>
</head>
<body>
    <form id="form1" runat="server">
     <div class="subHeader">
        <div>
            <asp:Label ID="lblTitle" runat="server" Text="Reset Passphrase" ToolTip="重 设 密 码"></asp:Label>
        </div>
    </div>
    <div>
        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed;">
        <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblSelect" runat="server" Text="Select Domain" ToolTip="选择域名"></asp:Label>:
                    </div>
                </td>
                <td>
                    <div align="left">
                      <asp:DropDownList ID="dropDomain" runat="server">
                                        <asp:ListItem>NON-DOMAIN</asp:ListItem>
                                    </asp:DropDownList>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblName" runat="server" Text="Username" ToolTip="用户名"></asp:Label>:
                    </div>
                </td>
                <td>
                    <div align="left">
                        <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>
                        &nbsp;
                        </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblPass" runat="server" Text="Password" ToolTip="密码"></asp:Label>:
                    </div>
                </td>
                <td>
                    <div align="left">
                        <asp:TextBox ID="txtPass" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                        &nbsp;
                        </div>
                </td>
            </tr>
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
                    <div style="text-align:center">
                    <span>
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="提交" CssClass="btnNormal"
                            OnClick="btnAdd_Click" UseSubmitBehavior="false" />
                             </span>
                           <span style="padding-right:100px">
                        <asp:LinkButton ID="linkBack" runat="server" onclick="linkBack_Click">Back to login page</asp:LinkButton>
                    </span>
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
