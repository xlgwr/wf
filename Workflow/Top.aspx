<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top.aspx.cs" Inherits="Workflow.Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script type="text/javascript" language="javascript">
        function Exits() {
            if (!window.confirm("Sure log off?")) {

                return;
            }

            window.parent.location.href = "Login.aspx";
        }
        function setUrl(url) {
            //document.getElementById("manFrame").src = url
            window.top.frames['manFrame'].location = url
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="header">
                <div>
                    <a target="manFrame" href="Systems/Sys_ModifyPass.aspx">
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
                <span class="title">Wong's Electronics Company Limited</span> <span style="margin-left: 200px;">&nbsp;</span>
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
            </div>

        </div>
    </form>
</body>
</html>
