<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="From_MIS_Complete.aspx.cs"
    Inherits="Workflow.MIS_Service_Request.From_MIS_Complete"  Theme="GridView"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MIS Service Handle / MIS服务单处理</title>
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
            <asp:Label ID="lblTitle" runat="server" Text="MIS Service Handle" ToolTip="MIS 服 务 单 处 理"></asp:Label>
        </div>
    </div>
    <div style="width: 80%">
        <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed">
            <tr bgcolor="#FFFFFF">
                <td width="10%" bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblNumber" runat="server" Text="Number" ToolTip="编 号"></asp:Label>:</div>
                </td>
                <td width="80%" colspan="4">
                    <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineFill" Enabled="False"></asp:TextBox>
                    <asp:CheckBox ID="chkUrgent" runat="server" Enabled="False" Text="Urgent" ToolTip="紧 急" />
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblDate" runat="server" Text="Expect Date" ToolTip="期 望 日 期"></asp:Label>:
                    </div>
                </td>
                <td colspan="4">
                    <div align="left">
                        <asp:TextBox ID="txtRequestDate" runat="server" CssClass="myLineFill" Enabled="False"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblType" runat="server" Text="Type" ToolTip="类 型"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <div align="left">
                        <asp:TextBox ID="txtType" runat="server" CssClass="myLineFill" Width="300px" Enabled="False"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblSubject" runat="server" Text="Subject" ToolTip="主 题"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtSubject" runat="server" TextMode="MultiLine" Width="400px" Height="41px"
                        MaxLength="100" Enabled="False"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblDesc" runat="server" Text="Description" ToolTip="描 述"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="400px" Height="60px"
                        Enabled="False"></asp:TextBox>
                </td>
            </tr>
          <%--  <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblRemark" runat="server" Text="Remark" ToolTip="备 注"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="400px" Height="60px"
                        Enabled="False"></asp:TextBox>
                </td>
            </tr>--%>
            <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="Label1" runat="server" Text="Attachment Area" ToolTip="附 件 区 域"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" colspan="5">
                   <asp:GridView ID="attachGrid" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="false"
                        OnRowDataBound="attachGrid_RowDataBound">
                        <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData" runat="server" Text="No Attachment" ToolTip="没有数据"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="attach_title" HeaderText="FileName" ItemStyle-Width="100%">
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="lblHitory" runat="server" Text="Approve History" ToolTip="审 批 记 录"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" colspan="5">
                    <asp:GridView ID="historyGrid" runat="server" AutoGenerateColumns="false" 
                        Width="100%">
                        <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData1" runat="server" Text="No Approve Record" 
                                    ToolTip="没有审批记录"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="appd_seq" HeaderText="Seq" ItemStyle-Width="5%" />
                            <asp:BoundField DataField="appd_user" HeaderText="Approver" 
                                ItemStyle-Width="10%" />
                            <asp:BoundField DataField="appd_mandator" HeaderText="Mandator" 
                                ItemStyle-Width="10%" />
                            <asp:BoundField DataField="appd_date" DataFormatString="{0:MM/dd/yyyy HH:mm}" 
                                HeaderText="Date" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="appd_action" HeaderText="Action" 
                                ItemStyle-Width="5%" />
                            <asp:BoundField DataField="appd_remark" HeaderText="Remark" 
                                ItemStyle-Width="60%" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="Label2" runat="server" Text="Schedule" ToolTip="时 间 安 排"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblPlanBegin" runat="server" Text="Plan Begin" ToolTip="计划开始日期"></asp:Label>:</div>
                </td>
                <td>
                    <asp:TextBox ID="txtPlanBegin" runat="server" CssClass="myLineFill" Enabled="true"></asp:TextBox>
                </td>
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="Label3" runat="server" Text="Plan End" ToolTip="计划结束日期"></asp:Label>:</div>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="txtPlanEnd" runat="server" CssClass="myLineFill" Enabled="true"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblActBegin" runat="server" Text="Act Begin" ToolTip="实际开始日期"></asp:Label>:</div>
                </td>
                <td>
                    <asp:TextBox ID="txtActBegin" runat="server" CssClass="textdate"></asp:TextBox>
                </td>
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblActEnd" runat="server" Text="Act End" ToolTip="实际结束日期"></asp:Label>:</div>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="textdate"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblSubmit" runat="server" Text="Remark" ToolTip="备 注"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="400px"
                        Height="60px"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td colspan="5">
                    <div align="center">
                        <table width="580" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="455">
                                    <asp:Button ID="btnApprve" runat="server" Text="Approve" ToolTip="提 交" 
                                        CssClass="btnNormal" onclick="btnApprve_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="退 回" 
                                        CssClass="btnNormal" onclick="btnReject_Click" />
                                </td>
                                <td width="125">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="3" width="100%" align="center" border="0" bgcolor="3A66AD">
        </table>
    </div>
    </form>
</body>
</html>
