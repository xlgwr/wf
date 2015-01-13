<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Workflow.test"
    Theme="GridView" %>

<%@ Register Src="~/UserControls/UploadAttach.ascx" TagName="header" TagPrefix="uc1" %>
<%@ Register Src="UserControls/UploadAttach.ascx" TagName="UploadAttach" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>锁屏2</title>
<style type="text/css"> 
#massage_box{   
    position:absolute;   
    width:350px;   
    height:200px; 
    background:#fff; color:#036; font-size:12px; line-height:150%; 
    z-index:2; visibility:hidden; 
}   
#mask{   
    position:absolute;   
    top:0; left:0;   
    width:expression(document.documentElement.scrollWidth);   
    height:expression(document.documentElement.scrollHeight); 
    background:#666;   
    filter:alpha(opacity=60);   
    z-index:1;   
    visibility:hidden; 
}  

</style>
<script language="javascript" type="text/javascript">
    function d_x() {
        mask.style.visibility = 'visible';
        massage_box.style.visibility = 'visible';
        var screenWidth = document.documentElement.clientWidth + document.documentElement.scrollLeft;
        var screenHeight = document.documentElement.clientHeight;
        var divObj = document.getElementById("massage_box");
        var divWidth = divObj.offsetWidth;
        var divHeight = divObj.offsetHeight;
        var left = parseInt((screenWidth - divWidth) / 2);
        var top = parseInt((screenHeight - divHeight) / 2);
        divObj.style.left = left + document.documentElement.scrollLeft;
        divObj.style.top = top;
    }
    function d_y() {
        massage_box.style.visibility = 'hidden';
        mask.style.visibility = 'hidden'
    } 

</script>
    
</head>

<body>
<form id="form1" runat="server">
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

</form> 
</body>


</html>
