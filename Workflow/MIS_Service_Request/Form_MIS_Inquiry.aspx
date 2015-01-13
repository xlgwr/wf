<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form_MIS_Inquiry.aspx.cs"
    Inherits="Workflow.MIS_Service_Request.Form_MIS_Inquiry" Theme="GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Documents Inquriy / 文档查询</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function showCondition() {
            if ($("#tblCondition").css("display") != "none") {
                $("#tblCondition").fadeOut("fast");
            }
            else {
                $("#tblCondition").fadeIn("slow");
            }

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="subHeader">
            <div>
                <asp:Label ID="lblTitle" runat="server" Text="Documents Inquriy" ToolTip="文 档 查 询"></asp:Label>
            </div>
        </div>
        <fieldset>
            <legend>
                <asp:Label ID="lblQuery" runat="server" Text="Query" ToolTip="查询"></asp:Label></legend>

            <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed; border-top: 0">
                <tr bgcolor="#FFFFFF">
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblNumber" runat="server" Text="Number" ToolTip="编 号"></asp:Label>:
                        </div>
                    </td>
                    <td width="10%">
                        <asp:TextBox ID="txtNbr" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblStatus" runat="server" Text="Status" ToolTip="状 态"></asp:Label>:
                        </div>
                    </td>
                    <td width="10%">
                        <asp:DropDownList ID="dropStatus" runat="server" Width="120px">
                        </asp:DropDownList>
                    </td>
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblProcess" runat="server" Text="Process By" ToolTip="处理人"></asp:Label>:
                        </div>
                    </td>
                    <td width="10%">
                        <asp:TextBox ID="txtProcess" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblApplicant" runat="server" Text="Applicant" ToolTip="申 请 人"></asp:Label>:
                        </div>
                    </td>
                    <td width="10%">
                        <asp:TextBox ID="txtApplicant" runat="server" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblCompany" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                        </div>
                    </td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <td width="10%">

                                <asp:DropDownList ID="dropCompany" runat="server" OnSelectedIndexChanged="dropCompany_SelectedIndexChanged"
                                    AutoPostBack="true" Width="120px">
                                </asp:DropDownList>

                            </td>
                            <td width="5%" bgcolor="EAF2F9">
                                <div align="right">
                                    <asp:Label ID="lblDept" runat="server" Text="Applicant Dept" ToolTip="申 请 部 门"></asp:Label>:
                                </div>
                            </td>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td width="10%">
                        <asp:DropDownList ID="dpdept" runat="server" Width="120px">
                        </asp:DropDownList>
                    </td>
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblBeginDate" runat="server" Text="Begin Date" ToolTip="开 始 日 期"></asp:Label>:
                        </div>
                    </td>
                    <td width="10%">
                        <asp:TextBox ID="txtBegin" runat="server" CssClass="textdate"></asp:TextBox>
                    </td>
                    <td width="5%" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblEnd" runat="server" Text="End Date" ToolTip="结 束 日 期"></asp:Label>:
                        </div>
                    </td>
                    <td width="10%">
                        <asp:TextBox ID="txtEnd" runat="server" CssClass="textdate"></asp:TextBox>
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td height="60px" bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblParType" runat="server" Text="Type" ToolTip="类 别"></asp:Label>:
                        </div>
                    </td>
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <td colspan="3">

                                <asp:DropDownList ID="dropTypeParent" runat="server" OnSelectedIndexChanged="dropTypeParent_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>

                                <br />
                                <asp:DropDownList ID="dropTypeChild" runat="server" Visible="False">
                                </asp:DropDownList>
                            </td>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <td bgcolor="EAF2F9">
                        <div align="right">
                            <asp:Label ID="lblSubject" runat="server" Text="Subject" ToolTip="主 题"></asp:Label>:
                        </div>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtSubject" runat="server" CssClass="textbox" Width="90%" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
            </table>

            <div style="text-align: right">
                <asp:Button ID="btnSearch" runat="server" Text="Search" ToolTip="搜索" CssClass="btnNormal"
                    OnClick="btnSearch_Click" UseSubmitBehavior="false" />
            </div>
        </fieldset>
        <asp:GridView ID="gridData" runat="server" SkinID="GridView" AutoGenerateColumns="false"
            Width="120%" OnRowDataBound="gridData_RowDataBound">
            <EmptyDataTemplate>
                <div class="emptydatatemplate">
                    <asp:Label ID="lblNoData" runat="server" Text="No Details Data" ToolTip="没有明细信息"></asp:Label>
                </div>
            </EmptyDataTemplate>
            <Columns>
                <asp:BoundField DataField="m_svr_nbr" HeaderText="Number" ItemStyle-Width="3%" FooterText="单号" />
                <asp:BoundField DataField="m_svr_location" HeaderText="Company" ItemStyle-Width="2%"
                    FooterText="公司" />
                <asp:BoundField DataField="m_svr_user" HeaderText="Applicant" ItemStyle-Width="3%"
                    FooterText="申请人" />
                <asp:BoundField DataField="m_svr_dept" HeaderText="Dept" ItemStyle-Width="2%" FooterText="部门" />
                <asp:TemplateField HeaderText="Type" FooterText="类型" ItemStyle-Width="10%" ItemStyle-CssClass="div_overflow">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"mis_type")%>'
                            ToolTip='<%# DataBinder.Eval(Container.DataItem,"mis_type") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Next Process" FooterText="下一步处理" ItemStyle-Width="4%" ItemStyle-CssClass="div_overflow">
                    <ItemTemplate>
                        <div class="div_overflow">
                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"mis_status")%>'
                                ToolTip='<%# DataBinder.Eval(Container.DataItem,"mis_status") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="m_svr_process_by" HeaderText="ProcessBy" ItemStyle-Width="3%" ItemStyle-CssClass="div_overflow"
                    FooterText="处理人" />
                <asp:TemplateField HeaderText="Subject" FooterText="主题" ItemStyle-Width="6%">
                    <ItemTemplate>
                        <div class="div_overflow">
                            <asp:Label ID="Label1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"m_svr_subject")%>'
                                ToolTip='<%# DataBinder.Eval(Container.DataItem,"m_svr_subject") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="m_svr_date" HeaderText="Date" ItemStyle-Width="3%"
                    FooterText="日期" DataFormatString="{0:MM/dd/yyyy}" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
