<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_UserTree.aspx.cs" Inherits="Workflow.Systems.UserGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select User/选 择 用 户</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script language='javascript' type='text/javascript'>
        function OnTreeNodeChecked() {
            var ele = event.srcElement;
            if (ele.type == 'checkbox') {
                var childrenDivID = ele.id.replace('CheckBox', 'Nodes');
                var div = document.getElementById(childrenDivID);
                if (div == null) return;
                var checkBoxs = div.getElementsByTagName('INPUT');
                for (var i = 0; i < checkBoxs.length; i++) {
                    if (checkBoxs[i].type == 'checkbox')
                        checkBoxs[i].checked = ele.checked;
                }
            }
        }

        function SubmitValue() {
            var val = "";
            var returnVal = new Array();
            var inputs = document.all.tags("INPUT");
            var n = 0;
            for (var i = 0; i < inputs.length; i++) // 遍历页面上所有的 input 
            {
                if (inputs[i].type == "checkbox") {
                    if (inputs[i].checked) {
                        var strValue = inputs[i].value;
                        val += strValue + ',';
                        //returnVal[n] = val;
                        n = n + 1;
                    }
                } //if(inputs[i].type="checkbox")
            } //for

            window.returnValue = val;
            window.close();
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="lblCompany" runat="server" Text="Select Company Code" ToolTip="选 择 公 司 代 码"></asp:Label>
        <asp:DropDownList ID="dropComCode" runat="server" Width="100px" 
            AutoPostBack="true" onselectedindexchanged="dropComCode_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:TreeView ID="userTree" runat="server" ShowCheckBoxes="Leaf" ExpandDepth="0">
            <RootNodeStyle ImageUrl="~/Styles/images/root.gif" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
