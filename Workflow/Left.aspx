<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Workflow.Left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/css.css" rel="stylesheet" type="text/css" />

    <link href="Styles/easyui.css" rel="stylesheet" />
    <link href="Styles/icon.css" rel="stylesheet" />
    <script src="Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            initLayout()

        });
        function setUrl(url) {
            window.top.frames['manFrame'].location = url
        }
        function initLayout() {

            var iContentH = $(window).height();


            $("#sidebar").height(iContentH);

        }

</script>
    <script src="Scripts/jquery.easyui.min.js"></script>
    <%--<script src="scripts/outlook.js" type="text/javascript"></script>--%>
</head>
<body>
    <form id="form1" runat="server">
        <div class="easyui-accordion" id="sidebar" style="width:220px">
            <asp:Repeater runat="server" ID="rptList" OnItemDataBound="rptList_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div title="<%# Eval("title") %>">
                        <ul class="easyui-tree">
                            <asp:Repeater runat="server" ID="rptItem">
                                <HeaderTemplate>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <li>
                                        <a href="#" onclick="setUrl('<%#Eval("menu_page") %>')">
                                            <%# Eval("title") %></a>
                                    </li>
                                </ItemTemplate>
                                <FooterTemplate>
                                </FooterTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
