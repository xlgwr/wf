<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_SelectOne.aspx.cs" Inherits="Workflow.Systems.Sys_SelectOne" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Select User / 选择用户</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function oneuser() {
            var username = $("#listUserBox option:selected").text();
            window.opener.SetValue(username);
            window.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:left">
        <div style="width:400px">
        <asp:Label ID="lblCompany" runat="server" Text="Company" ToolTip="公司代码" Width="60px"></asp:Label>
        <asp:DropDownList ID="dropCompany" runat="server" AutoPostBack="true" 
            onselectedindexchanged="dropCompany_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
    <div style="float:left">
     <asp:Label ID="lblDept" runat="server" ToolTip="请从列表中选取" Width="105px" Text="Department"></asp:Label><br />
        <asp:ListBox ID="listDeptBox" runat="server" Width="100px" Height="208px" 
            onselectedindexchanged="listDeptBox_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    </div>
    <div style="float:left">
        <asp:Label ID="lblSelectList" runat="server" ToolTip="请从列表中选取" Text="Please select from the list"></asp:Label><br />
        <asp:ListBox ID="listUserBox" runat="server" Width="200px" Height="208px"></asp:ListBox>
        </div>
        </div>
       <input id="btnconfirm"
				type="button" value="Confirm" name="btnconfirm" class="btnHTML" onclick="oneuser()"/>
                <input 
id="txtctrlname" 
style="Z-INDEX: 111; LEFT: 88px; VISIBILITY: hidden; WIDTH: 112px; POSITION: absolute; TOP: 312px; HEIGHT: 24px" 
size="13" value="<%=ctrlname%>" name="txtctrlname"/>
    </div>
    </form>
</body>
</html>
