<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Workflow.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Tree View</title>
    <script src="Scripts/jquery.js" type="text/javascript"></script>
    <link href="Styles/Simple.tree.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery.simple.tree.js" type="text/javascript"></script>

    <script type="text/javascript">
        var simpleTreeCollection;
        $(document).ready(function () {
            simpleTreeCollection = $('.simpleTree').simpleTree({
                autoclose: true,
                afterClick: function (node) {

                },
                afterDblClick: function (node) {

                },
                afterMove: function (destination, source, pos) {

                },
                afterAjax: function () {

                },
                animate: true

            });
        });
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
     <table cellpadding="0" cellspacing="0" border="0"  style="margin-left: -20px;margin-top: -28px" height="100%"  width=170  >
        <tr>
            <td valign="Top" align="left">
                <asp:Repeater runat="server" ID="rptList">
                    <HeaderTemplate>
                        <ul class="simpleTree">
                            <li class="root" id='1' height="0px">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <ul>
                            <li id='3'><span>
                                <%# Eval("menu_title") %></span>
                                <ul class="ajax">
                                    <li>{url:Left_Menu.aspx?Type=1&RsCode=<%# Eval("menu_id") %>}</li>
                                </ul>
                            </li>
                        </ul>
                    </ItemTemplate>
                    <FooterTemplate>
                        </li> </ul>
                    </FooterTemplate>
                </asp:Repeater>
            </td>
        </tr>
    </table>
    
    </form>
</body>
<script language="JavaScript" type="text/javascript">
    var frmTitlestile = ""
    function switchSysBar() {

        var par = window.parent;
        if (frmTitlestile == "none") {

            frmTitlestile = "";
            par.ViewHelper('open');

        }
        else {
            frmTitlestile = "none"
            par.ViewHelper('close');
        }
    }
</script>
</html>
