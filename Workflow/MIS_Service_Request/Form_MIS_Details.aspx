<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_MIS_Details.aspx.cs"
    Inherits="Workflow.MIS_Service_Request.Form_MIS_Details" Theme="GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MIS Service Details / MIS服务单明细</title>
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
            <asp:Label ID="lblTitle" runat="server" Text="MIS Service Request" ToolTip="MIS 服 务 单 处 理"></asp:Label>&nbsp;
            <asp:Label ID="lblTitle1" runat="server" Text="Status" ToolTip="状态"></asp:Label>：
            <asp:Label ID="lblTaskStatus" runat="server"></asp:Label>
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
                    <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                    <asp:CheckBox ID="chkUrgent" runat="server" Enabled="False" Text="Urgent" ToolTip="紧 急" />
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公司"></asp:Label>:
                    </div>
                </td>
                <td colspan="4">
                    <div align="left">
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblApplicant" runat="server" Text="Applicant" ToolTip="申 请 人"></asp:Label>:
                    </div>
                </td>
                <td colspan="4">
                    <div align="left">
                        <asp:TextBox ID="txtApplicant" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblDept" runat="server" Text="Dept" ToolTip="部 门"></asp:Label>:
                    </div>
                </td>
                <td colspan="4">
                    <div align="left">
                        <asp:TextBox ID="txtDept" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                    </div>
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
                        <asp:TextBox ID="txtRequestDate" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
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
                        <asp:TextBox ID="txtType" runat="server" CssClass="myLineFill" Width="60%" ReadOnly="True"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblPlanBegin" runat="server" Text="Plan Begin" ToolTip="计划开始日期"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtPlanBegin" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="Label3" runat="server" Text="Plan End" ToolTip="计划结束日期"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtPlanEnd" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblActBegin" runat="server" Text="Act Begin" ToolTip="实际开始日期"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtActBegin" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblActEnd" runat="server" Text="Act End" ToolTip="实际结束日期"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtActEnd" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblProcess" runat="server" Text="ProcessBy" ToolTip="处理人"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtProcessBy" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblSubject" runat="server" Text="Subject" ToolTip="主 题"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtSubject" runat="server" TextMode="MultiLine" Width="400px" Height="41px"
                        MaxLength="100" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblDesc" runat="server" Text="Description" ToolTip="描 述"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="100%" Height="100px"
                        ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <%--  <tr bgcolor="#FFFFFF">
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblRemark" runat="server" Text="Remark" ToolTip="备 注"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="400px" Height="100px"
                        Enabled="False"></asp:TextBox>
                </td>
            </tr>--%>
            <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="Label1" runat="server" Text="Attachment" ToolTip="附 件 区 域"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" colspan="5">
                    <asp:GridView ID="attachGrid" runat="server" AutoGenerateColumns="false" OnRowDataBound="attachGrid_RowDataBound"
                        SkinID="GridView" Width="100%">
                        <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData" runat="server" Text="No Attachment" ToolTip="没有附件"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="attach_title" FooterText="文件名" HeaderText="FileName" ItemStyle-Width="70%" />
                            <asp:BoundField DataField="attach_user" HeaderText="Creater" ItemStyle-Width="10%"
                                FooterText="上传人"></asp:BoundField>
                            <asp:BoundField DataField="attach_time" HeaderText="Create Time" ItemStyle-Width="20%"
                                FooterText="创建时间" DataFormatString="{0:MM/dd/yyyy HH:mm}"></asp:BoundField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
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
            <tr bgcolor="#FFFFFF">
                <td colspan="5" align="center">
                    <img alt="back" src="../images/up.gif" onclick="javascript:window.history.go(-1);" /><a
                        href="#" onclick="javascript:window.history.go(-1);" style="text-decoration: none;"><asp:Label
                            ID="lblBack" runat="server" Text="Back" ToolTip="返回"></asp:Label></a>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
