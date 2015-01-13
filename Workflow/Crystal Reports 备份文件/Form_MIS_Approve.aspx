<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_MIS_Approve.aspx.cs"
    Inherits="Workflow.MIS_Service_Request.Form_MIS_Approve" Theme="GridView" %>

<%@ Register src="../UserControls/UploadAttach.ascx" tagname="UploadAttach" tagprefix="uc1"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MIS Service Request Approve</title>
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
            <asp:Label ID="lblTitle" runat="server" Text="MIS Service Request Approve" ToolTip="MIS 服 务 申 请 单 审 批"></asp:Label>
            --<asp:Label ID="lblTaskStatus" runat="server" Text=""></asp:Label>
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
            <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="Label1" runat="server" Text="Attachment" ToolTip="附 件 区 域"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="left" colspan="5">
                    <uc1:UploadAttach ID="UploadAttach1" runat="server" />
                </td>
            </tr>
            <tr class="attachment_head">
                <td colspan="5">
                    <asp:Label ID="lblHitory" runat="server" Text="Approval History" ToolTip="审 批 记 录"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="center" colspan="5">
                    <asp:GridView ID="historyGrid" runat="server" Width="100%" AutoGenerateColumns="false" SkinID="GridView">
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
                <td bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblRemark" runat="server" Text="Remark" ToolTip="备 注"></asp:Label>:</div>
                </td>
                <td colspan="4">
                    <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td colspan="5">
                    <div align="center">
                        <table width="580" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="455">
                                    <asp:Button ID="btnApprve" runat="server" Text="Approve" ToolTip="提 交" CssClass="btnNormal"
                                        OnClick="btnApprve_Click" UseSubmitBehavior="false"/>
                                    &nbsp;
                                    <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="反 对" CssClass="btnNormal"
                                        OnClick="btnReject_Click" UseSubmitBehavior="false"/>
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
