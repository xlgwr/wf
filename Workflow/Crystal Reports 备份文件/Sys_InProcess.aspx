<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_InProcess.aspx.cs" Inherits="Workflow.Systems.Alltask" Theme="GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Forms In Process / 处理中的表单</title>
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
            <asp:Label ID="lblTitle" runat="server" Text="Forms In Process" ToolTip="处 理 中 的 表 单"></asp:Label>
        </div>
    </div>
    <asp:GridView ID="gridData" runat="server" SkinID="GridView" Width="100%" 
            onrowdatabound="gridData_RowDataBound">
     <Columns>
        <asp:BoundField  DataField="form_nbr" HeaderText="Number" ItemStyle-Width="10%" FooterText="单号"/>
        <asp:BoundField  DataField="form_seq" HeaderText="Seq" ItemStyle-Width="10%" FooterText="步骤"/>
        <asp:BoundField  DataField="form_type" HeaderText="Type" ItemStyle-Width="10%" FooterText="类型"/>
         <asp:BoundField DataField="form_applicant" HeaderText="Applicant" ItemStyle-Width="10%" FooterText="申请人"/>
            <asp:BoundField DataField="form_dept" HeaderText="Applicant Dept" ItemStyle-Width="10%" FooterText="部门"/>
        <asp:BoundField  DataField="form_date" HeaderText="Flow Begin Date" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH:mm}" FooterText="提交日期"/>
        
     </Columns>
    </asp:GridView>
    </form>
</body>
</html>
