<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index1.aspx.cs" Inherits="Workflow.Index1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Wong's WorkFlow System</title>
    <link href="favicon.ico" type="image/x-icon" rel="shortcut icon" />
    <link href="UI/themes/default/style.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="UI/themes/css/core.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="UI/themes/css/print.css" rel="stylesheet" type="text/css" media="print" />
    <link href="UI/uploadify/css/uploadify.css" rel="stylesheet" type="text/css" media="screen" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="UI/js/jquery-1.7.2.js" type="text/javascript"></script>
    <script src="UI/js/jquery.cookie.js" type="text/javascript"></script>
   <%-- <script src="UI/js/jquery.validate.js" type="text/javascript"></script>
    <script src="UI/js/jquery.bgiframe.js" type="text/javascript"></script>
    <script src="UI/xheditor/xheditor-1.2.1.min.js" type="text/javascript"></script>
    <script src="UI/xheditor/xheditor_lang/zh-cn.js" type="text/javascript"></script>
    <script src="UI/uploadify/scripts/jquery.uploadify.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="UI/chart/raphael.js"></script>
    <script type="text/javascript" src="UI/chart/g.raphael.js"></script>
    <script type="text/javascript" src="UI/chart/g.bar.js"></script>
    <script type="text/javascript" src="UI/chart/g.line.js"></script>
    <script type="text/javascript" src="UI/chart/g.pie.js"></script>
    <script type="text/javascript" src="UI/chart/g.dot.js"></script>
    <script src="UI/js/dwz.core.js" type="text/javascript"></script>
    <script src="UI/js/dwz.util.date.js" type="text/javascript"></script>
    <script src="UI/js/dwz.validate.method.js" type="text/javascript"></script>
    <script src="UI/js/dwz.barDrag.js" type="text/javascript"></script>
    <script src="UI/js/dwz.drag.js" type="text/javascript"></script>
    <script src="UI/js/dwz.tree.js" type="text/javascript"></script>
    <script src="UI/js/dwz.accordion.js" type="text/javascript"></script>
    <script src="UI/js/dwz.ui.js" type="text/javascript"></script>
    <script src="UI/js/dwz.theme.js" type="text/javascript"></script>
    <script src="UI/js/dwz.switchEnv.js" type="text/javascript"></script>
    <script src="UI/js/dwz.alertMsg.js" type="text/javascript"></script>
    <script src="UI/js/dwz.contextmenu.js" type="text/javascript"></script>
    <script src="UI/js/dwz.navTab.js" type="text/javascript"></script>
    <script src="UI/js/dwz.tab.js" type="text/javascript"></script>
    <script src="UI/js/dwz.resize.js" type="text/javascript"></script>
    <script src="UI/js/dwz.dialog.js" type="text/javascript"></script>
    <script src="UI/js/dwz.dialogDrag.js" type="text/javascript"></script>
    <script src="UI/js/dwz.sortDrag.js" type="text/javascript"></script>
    <script src="UI/js/dwz.cssTable.js" type="text/javascript"></script>
    <script src="UI/js/dwz.stable.js" type="text/javascript"></script>
    <script src="UI/js/dwz.taskBar.js" type="text/javascript"></script>
    <script src="UI/js/dwz.ajax.js" type="text/javascript"></script>
    <script src="UI/js/dwz.pagination.js" type="text/javascript"></script>
    <script src="UI/js/dwz.database.js" type="text/javascript"></script>
    <script src="UI/js/dwz.datepicker.js" type="text/javascript"></script>
    <script src="UI/js/dwz.effects.js" type="text/javascript"></script>
    <script src="UI/js/dwz.panel.js" type="text/javascript"></script>
    <script src="UI/js/dwz.checkbox.js" type="text/javascript"></script>
    <script src="UI/js/dwz.history.js" type="text/javascript"></script>
    <script src="UI/js/dwz.combox.js" type="text/javascript"></script>
    <script src="UI/js/dwz.print.js" type="text/javascript"></script>
    <script src="UI/js/dwz.regional.zh.js" type="text/javascript"></script>
    <script type="text/javascript">
        function setUrl(url) {
            document.getElementById("PageFrame").src = url
        }
        $(function () {
            DWZ.init("dwz.frag.xml", {
                loginUrl: "login_dialog.html", loginTitle: "登录", // 弹出登录对话框
                //		loginUrl:"login.html",	// 跳到登录页面
                statusCode: { ok: 200, error: 300, timeout: 301 }, //【可选】
                pageInfo: { pageNum: "pageNum", numPerPage: "numPerPage", orderField: "orderField", orderDirection: "orderDirection" }, //【可选】
                keys: { statusCode: "statusCode", message: "message" }, //【可选】
                debug: false, // 调试模式 【true|false】
                callback: function () {
                    initEnv();
                    $("#themeList").theme({ themeBase: "themes" }); // themeBase 相对于index页面的主题base路径
                }
            });
        });

    </script>
</head>
<body scroll="no">
    <form id="PageForm" runat="server">
    <div id="layout">
        <div id="header">
            <div style="height: 15px">
            </div>
            <div class="headerNav">
                <div style="float: left">
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
                </div>
                <div style="text-align: right;">
                    <a target="PageFrame" href="Systems/Sys_ModifyPass.aspx">
                        <asp:Label ID="lblModify" runat="server" Text="Modify Passphrase" ToolTip="修改密码"></asp:Label></a>|<asp:LinkButton
                            ID="lblLanguage" runat="server" OnClick="lblLanguage_Click" Text="中文" ToolTip="English"></asp:LinkButton>|
                    <asp:LinkButton ID="lnkLogiout" runat="server" Text="Logout" ToolTip="注销" OnClick="lnkLogiout_Click"
                        OnClientClick="javascript:return confirm('Sure log off?');"></asp:LinkButton>
                    <span>&nbsp;&nbsp;</span>
                </div>
            </div>
        </div>
        <div id="leftside">
            <div id="sidebar_s">
                <div class="collapse">
                    <div class="toggleCollapse">
                        <div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="sidebar">
                <div class="toggleCollapse">
                    <h2>
                        主菜单</h2>
                    <div>
                        收缩</div>
                </div>
                <div class="accordion" fillspace="sidebar">
                    <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
                        <%-- <HeaderTemplate>
                            <ul>
                        </HeaderTemplate>--%>
                        <ItemTemplate>
                            <div class="accordionHeader">
                                <h2>
                                    <span>Folder</span>
                                    <%#Eval("title") %></h2>
                            </div>
                            <asp:Repeater runat="server" ID="rptItem">
                                <HeaderTemplate>
                                    <div class="accordionContent">
                                        <ul class="tree treeFolder">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li><a href="#" onclick="setUrl('<%#Eval("menu_page") %>')">
                                        <%# Eval("title") %></a></li>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </ul> </div>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ItemTemplate>
                        <%-- <FooterTemplate>
                            </ul>
                        </FooterTemplate>--%>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div id="container">
            <div id="navTab" class="tabsPage">
                <div class="tabsPageHeader">
                    <div class="tabsPageHeaderContent">
                        <!-- 显示左右控制时添加 class="tabsPageHeaderMargin" -->
                    </div>
                    <%--<div class="tabsLeft tabsLeftDisabled">
                        left</div>
                    <!-- 禁用只需要添加一个样式 class="tabsLeft tabsLeftDisabled" -->
                    <div class="tabsRight tabsRightDisabled">
                        right</div>
                    <!-- 禁用只需要添加一个样式 class="tabsRight tabsRightDisabled" -->
                    <div class="tabsMore tabsMoreDisabled">
                        more</div>--%>
                </div>
                <div class="navTab-panel tabsPageContent layoutBox">
                    <iframe id="PageFrame" name="PageFrame" width="100%" height="100%" frameborder="0"
                        src="Systems/Sys_Tasklist_001.aspx" style="border: 0px solid #cecece;"></iframe>
                </div>
            </div>
        </div>
    </div>
    <div id="footer">
        Workflow System Version 2.0</div>
    </form>
</body>
</html>
