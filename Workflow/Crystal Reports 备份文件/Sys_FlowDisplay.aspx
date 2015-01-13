<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_FlowDisplay.aspx.cs" Theme="GridView"
    Inherits="Workflow.Systems.Sys_Flow_Display" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flow Chart Display / 流程图显示</title>
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
            <asp:Label ID="lblTitle" runat="server" Text="Flow Chart Display" ToolTip="流 程 图 显 示"></asp:Label>
        </div>
    </div>
    <fieldset style="text-align: left">
        <legend>
            <asp:Label ID="lblQuery" runat="server" Text="Query" ToolTip="查询"></asp:Label></legend>
        <asp:Label ID="lblNbr" runat="server" Text="Number" ToolTip="单号"></asp:Label>：
        <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineCenter"></asp:TextBox>
        &nbsp;
        <asp:Button ID="btnQuery" runat="server" Text="Search" ToolTip="搜 索" CssClass="btnNormal"
            OnClick="btnQuery_Click" UseSubmitBehavior="false"/>
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
    </fieldset>
    <div style="">
    <asp:Label ID="lblMust" runat="server" Text="Mandatory Step" ToolTip="必要的步骤" 
            Style="float: right"></asp:Label>
        <div style="width: 30px; height: 15px; background-color: #BDDEFF; float: right">
        </div>
        <asp:Label ID="lblJump" runat="server" Text="Optional Step" ToolTip="可跳过的步骤" 
            Style="float: right"></asp:Label>
        <div style="width: 30px; height: 15px; background-color: #EBF09B; float: right">
        </div>
         <asp:Label ID="lblCurr" runat="server" Text="Current Step" ToolTip="当前状态" Style="float: right"></asp:Label>
        <div style="width: 30px; height: 15px; background-color: #81B470; float: right">
        </div>
       
    </div>
    <br />
    <div class="div_flow">
        <asp:PlaceHolder ID="lblPlace" runat="server" ></asp:PlaceHolder>
    </div>
    <table width="100%" align="center">
    <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="lblHitory" runat="server" Text="Approval History" ToolTip="审 批 记 录"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" colspan="5">
                    <asp:GridView ID="historyGrid" runat="server" Width="100%" AutoGenerateColumns="false"
                        SkinID="GridView">
                        <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData1" runat="server" Text="No Approve Record" ToolTip="没有审批记录"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                           <asp:BoundField DataField="appd_seq" HeaderText="Seq" ItemStyle-Width="5%" FooterText="步骤" />
                            <asp:BoundField DataField="appd_user" HeaderText="Approver" ItemStyle-Width="10%"
                                FooterText="审批人" />
                            <asp:BoundField DataField="appd_mandator" HeaderText="Orig Approver" ItemStyle-Width="15%"
                                FooterText="原审批人" />
                            <asp:BoundField DataField="appd_date" HeaderText="Date" ItemStyle-Width="15%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                                FooterText="审批日期" />
                            <asp:BoundField DataField="appd_action" HeaderText="Action" ItemStyle-Width="5%"
                                FooterText="动作" />
                            <asp:BoundField DataField="appd_remark" HeaderText="Remark" ItemStyle-Width="50%"
                                FooterText="备注" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
