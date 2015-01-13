<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Workflow.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Wong's WorkFlow System</title>
    <link href="favicon.ico" type="image/x-icon" rel="shortcut icon" />
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="scripts/outlook.js" type="text/javascript"></script>
    <script type="text/javascript">
        if (getBrowser() == 6) {
            $(document).ready(
                function () {
                    var w = ($("#PageForm").width() - 200) + "px";
                    $("#content").css({ width: w });
                }
            );
        }
        $(document).ready(function () {
            
            $('li.button a').click(function (e) {
                var dropDown = $(this).parent().next();
                $('.dropdown').not(dropDown).slideUp('fast');
                dropDown.slideToggle('fast');
                e.preventDefault();
            })
            $("li.button a").eq(0).click();
        });
    </script>
    <style type="text/css" >
        .aclick
        {
           font-weight:bold;
            }
    </style>
</head>
<body onresize="resizeWindow()" onload="resizeWindow()">
    <form id="PageForm" runat="server">
    <div class="header">
        <div>
            <a target="PageFrame" href="Systems/Sys_ModifyPass.aspx">
                <asp:Label ID="lblModify" runat="server" Text="Modify Passphrase" ToolTip="修改密码"></asp:Label></a>|<asp:LinkButton
                    ID="lblLanguage" runat="server" OnClick="lblLanguage_Click" Text="中文" ToolTip="English"></asp:LinkButton>|
            <asp:LinkButton ID="lnkLogiout" runat="server" Text="Logout" ToolTip="注销" OnClick="lnkLogiout_Click"
                OnClientClick="javascript:return confirm('Sure log off?');"></asp:LinkButton>
           <%-- <asp:ImageButton ID="imgLoginout" 
                OnClientClick="javascript:return confirm('Sure log off?');" 
                ImageUrl="images/btn_exit.png" runat="server" onclick="imgLoginout_Click" />--%>
            <br />
            <span></span>
        </div>
        <span class="title">Wong's Electronics Company Limited</span> <span style="margin-left: 200px;">
            &nbsp;</span>
        <asp:Label ID="lblWelco" runat="server" Text="Welcome" ToolTip="欢迎"></asp:Label>
        [
        <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
        ] | <a>
            <asp:Label ID="lblDept" runat="server" Text="Dept" ToolTip="部门"></asp:Label>:
            <asp:Label ID="lblDeptName" runat="server" Text="" Font-Size="14px"></asp:Label></a>
        <a>
            <asp:Label ID="lblCompany" runat="server" Text="Company" ToolTip="公司"></asp:Label>:
            <asp:Label ID="lblLocation" runat="server" Text="" Font-Size="14px"></asp:Label></a>
        <br />
    </div>
    <div class="toolbar">
        <div class="toolbarLeft">
        </div>
        <div class="toolbarContent">
            <a onclick="setUrl('Systems/Sys_Tasklist_001.aspx')" href="#">
                <img src="images/61.png" alt="" />
                <asp:Label ID="lblHide" runat="server" Text="My To-Do-List" ToolTip="我的任务"></asp:Label></a>|
            <a onclick="setUrl('Systems/Sys_InProcess.aspx')" href="#">
                <img src="images/28.png" alt="" />
                <asp:Label ID="lblProcessIn" runat="server" Text="My Open Task" ToolTip="我的处理中任务"></asp:Label></a>
        </div>
        <div class="toolbarRight">
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="clear">
    </div>
    <div class="navigation" id="navigation">
        <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
            <HeaderTemplate>
                <ul>
            </HeaderTemplate>
            <ItemTemplate>
                <li class="button" id='3'><a href="#" class="root">
                    <%#Eval("title") %></a></li>
                <asp:Repeater runat="server" ID="rptItem">
                    <HeaderTemplate>
                        <li class="dropdown">
                            <ul>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <li><a href="#" onclick="setUrl('<%#Eval("menu_page") %>')">
                            <%# Eval("title") %></a></li>
                    </ItemTemplate>
                    <FooterTemplate>
                        </ul> </li>
                    </FooterTemplate>
                </asp:Repeater>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
    <div class="divbar" id="divbar" onclick="setMenuHide()">
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <img src="images/mini-left.gif" alt="" />
    </div>
    <div class="content" id="content">
        <div class="contentPanel" id="contentPanel">
            <iframe id="PageFrame" name="PageFrame" width="100%" height="100%" frameborder="0"
                src="Systems/Sys_Tasklist_001.aspx" style="border: 0px solid #cecece;"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
