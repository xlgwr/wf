<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workflow.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="favicon.ico" type="image/x-icon" rel="shortcut icon"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="Scripts/Common.js" type="text/javascript"></script>
    <script src="Scripts/Login.js" type="text/javascript"></script>
    <title>Login Page</title>
    <style type="text/css">
        .bg {
	HEIGHT: 100%; RIGHT: 0px; POSITION: absolute; LEFT: 0px; Z-INDEX: -1; TOP: 0px; WIDTH: 100%; BOTTOM: 0px
}
    .login_div_body
    {
        HEIGHT: 100%;
        VERTICAL-ALIGN: middle;
        padding-bottom:100px;
        HEIGHT: 500px; POSITION: absolute; Z-INDEX: 2; TOP: 25%;left:35%
        }
        #dropDomain
        {
            width:200px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="bg">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="100%" height="100%" id="Internation">
		<param name="movie" value="Styles/images/login_water.swf" />
		<param name="wmode" value="transparent" />
		<param name="menu" value="false" />
		<param name="scale" value="exactfit" />
	</object>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center" class="login_div_body">
                <div class="accountInfo">
                    <div style="border: 1px solid #00703C">
                        <img src="Styles/images/Logo.jpg" width="398px" height="88px" alt="Wongs Electronics Company Limited" />
                    </div>
                    <fieldset class="login">
                        <legend>Account Information</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblbSelect" runat="server" Text="Select Domain"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropDomain" runat="server">
                                        <asp:ListItem>NON-DOMAIN</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td rowspan="4" width="50px">
                                &nbsp;
                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <asp:Image ID="ImgLoading" runat="server" ImageUrl="~/Styles/images/loading.gif"
                                                AlternateText="Loading..." />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblUname" runat="server" Text="Username"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtUName" runat="server" CssClass="textEntry"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblbPassword" runat="server" Text="Password" CssClass="lblLogin"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblPhase" runat="server" Text="Pass Phrase" CssClass="lblLogin"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPhase" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align:center">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="loginNormal" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="right">
                                  <%--  <a>Forget PassPhrase?</a>--%>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                   <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                                
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
