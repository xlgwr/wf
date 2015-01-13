<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_DeleteDocuments.aspx.cs" Inherits="Workflow.Systems.Sys_DeleteDocuments" Theme="GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <title>Delete Documents / 删除文档</title>
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
            <asp:Label ID="lblTitle" runat="server" Text="Delete Documents" ToolTip="删 除 文 档"></asp:Label>
        </div>
    </div>
     <asp:GridView ID="gridData" runat="server" SkinID="GridView" Width="100%" 
         
          onrowdeleting="gridData_RowDeleting">
                <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData1" runat="server" Text="No could be deleted documents" ToolTip="没有可以删除的文档"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
     <Columns>

              <asp:CommandField HeaderText="Delete" ShowDeleteButton="True"  FooterText="删除"
             ShowHeader="True" ItemStyle-Width="5%" />
        
        <asp:BoundField  DataField="form_nbr" HeaderText="Number" ItemStyle-Width="10%" 
             FooterText="单号">
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>
        <asp:BoundField  DataField="form_seq" HeaderText="Seq" ItemStyle-Width="10%" 
             FooterText="步骤">
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>
        <asp:BoundField  DataField="form_type" HeaderText="Type" ItemStyle-Width="10%" 
             FooterText="类型">
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField DataField="form_applicant" HeaderText="Applicant" 
             ItemStyle-Width="10%" FooterText="申请人">
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>
            <asp:BoundField DataField="form_dept" HeaderText="Applicant Dept" 
             ItemStyle-Width="10%" FooterText="部门">
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>
        <asp:BoundField  DataField="form_date" HeaderText="Flow Begin Date" 
             ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH:mm}" FooterText="提交日期">
        
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>

     </Columns>
    </asp:GridView>
    </form>
</body>
</html>
