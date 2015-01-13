<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_InProcess.aspx.cs" Inherits="Workflow.Systems.Alltask" Theme="GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Forms In Process / 处理中的表单</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function showDiv() {
            $("#div_show").dialog(
            {
                modal: true,
                draggable: false,
                resizable: false,
                title: "Flow View" ,
                height: 600,
                width: 800
            }

           );
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="subHeader">
            <div>
                <asp:Label ID="lblTitle" runat="server" Text="Forms In Process" ToolTip="处 理 中 的 表 单"></asp:Label>
            </div>
        </div>
        <asp:GridView ID="gridData" runat="server" SkinID="GridView" Width="100%"
            OnRowDataBound="gridData_RowDataBound" OnRowCommand="gridData_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Number" FooterText="单号" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <asp:LinkButton ID="linkNum" runat="server" Text="" ToolTip="" CommandName="LinkNum"
                            CommandArgument='<%# Eval("form_guid") %>' />
                    </ItemTemplate>
                    <ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Details" FooterText="明细" ItemStyle-Width="5%">
                    <ItemTemplate>
                        <%--<asp:LinkButton ID="linkSubNum" runat="server" Text="" ToolTip="" CommandName="LinkSubNum"
                        CommandArgument='<%# Eval("form_guid") %>' />--%>
                        <asp:Label runat="server" Text="" ID="lblSubNum" CommandArgument='<%# Eval("form_guid") %>'></asp:Label>
                    </ItemTemplate>

                    <ItemStyle Width="5%"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="10%" FooterText="步骤" />
                <asp:BoundField DataField="form_type" HeaderText="Type" ItemStyle-Width="10%" FooterText="类型" />
                <asp:BoundField DataField="form_applicant" HeaderText="Applicant" ItemStyle-Width="10%" FooterText="申请人" />
                <asp:BoundField DataField="form_dept" HeaderText="Applicant Dept" ItemStyle-Width="10%" FooterText="部门" />
                <asp:BoundField DataField="form_date" HeaderText="Flow Begin Date" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH:mm}" FooterText="提交日期" />
            </Columns>
        </asp:GridView>
        <div id="div_show" style="display: none">
            <div>
                <div>
                    <asp:Label ID="lblFlow" runat="server" Text="Flow Display" ToolTip="流程显示" Font-Bold="True"
                        Font-Size="Larger"></asp:Label>
                    <asp:Label ID="lblMust" runat="server" Text="Mandatory Step" ToolTip="必要的步骤" Style="float: right"></asp:Label>
                    <div style="width: 30px; height: 15px; background-color: #BDDEFF; float: right">
                    </div>
                    <asp:Label ID="lblJump" runat="server" Text="Optional Step" ToolTip="可跳过的步骤" Style="float: right"></asp:Label>
                    <div style="width: 30px; height: 15px; background-color: #EBF09B; float: right">
                    </div>
                    <asp:Label ID="lblCurr" runat="server" Text="Current Step" ToolTip="当前状态" Style="float: right"></asp:Label>
                    <div style="width: 30px; height: 15px; background-color: #81B470; float: right">
                    </div>
                </div>
                <br />
                <div class="div_flow">
                    <asp:PlaceHolder ID="lblPlace" runat="server"></asp:PlaceHolder>
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
            </div>
        </div>
    </form>
</body>
</html>
