<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Workflow.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="favicon.ico" type="image/x-icon" rel="shortcut icon"/>
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <%--<script src="Scripts/Common.js" type="text/javascript"></script>--%>
    <script src="Scripts/Login.js" type="text/javascript"></script>
    <title>Workflow System Login </title>
    <style type="text/css">
        #dropDomain
        {
            width:200px;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin:100px">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
                <div class="accountInfo">
                    <div style="border: 1px solid #00703C">
                        <img src="Styles/images/Logo.jpg" width="398px" height="88px" alt="Wongs Electronics Company Limited" />
                    </div>
                    <fieldset class="login">
                        <legend>Account Information</legend>
                        <table width="100%">
                            <tr>
                                <td>
                                    <asp:Label ID="lblbSelect" runat="server" Text="Select Domain"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropDomain" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td rowspan="3" width="50px">
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
                                <td>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="3">
                                <asp:LinkButton ID="lnkForget" runat="server" 
                                        ToolTip="Please enter Username and Password first" 
                                        OnClientClick="javascript:return confirm('Sure forget passphrase and will reset it?')" 
                                        onclick="lnkForget_Click">Forgot Passphrase?</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="text-align:center">
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="loginNormal" OnClick="btnSubmit_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="right">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" align="center">
                                   <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
                                </td>
                                
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
