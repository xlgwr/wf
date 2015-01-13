<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Job_Relation.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Job_Relation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Recruitment Position Relation</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
        <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="subHeader">
            <div>
                <asp:Label ID="lblSetup" runat="server" Text="Recruitment Position Relation Set Up" ToolTip="招聘职位关系设置"></asp:Label>
            </div>
        </div>
    <div>

                                <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                       
               
                            <asp:DropDownList ID="dropCompany" runat="server" OnSelectedIndexChanged="dropCompany_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                            <asp:Label ID="lblDept" runat="server" Text="Department" ToolTip="部 门"></asp:Label>
                            :
                            <asp:DropDownList ID="dropDept" runat="server" Width="120px" AutoPostBack="true" OnSelectedIndexChanged="dropDept_SelectedIndexChanged">
                            </asp:DropDownList>
                  
    </div>
        <div style="float:left;width:300px">
        <asp:ListBox ID="listJobs" runat="server" Width="98%" Height="400px"></asp:ListBox>
            </div>
         <div style="float: left; margin-top: 120px">
            <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="btnNormal" ToolTip="增加" OnClick="btnAdd_Click" />
            <br />
            <br />
            <asp:Button ID="btnRemove" runat="server" Text="Delete" Width="65px" CssClass="btnNormal" ToolTip="删除" OnClick="btnRemove_Click" />
             </div>
         <div style="float:left;width:300px">
        <asp:ListBox ID="listAdd" runat="server" Width="98%" Height="400px" SelectionMode="Multiple"></asp:ListBox>
            </div>
    </form>
</body>
</html>
