<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Tasklist_001.aspx.cs" Inherits="Workflow.Systems.Sys_Tasklist_001"
    Culture="auto" meta:resourcekey="PageResource1" UICulture="auto" Theme="GridView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Task List / 任务列表</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="subHeader">
            <div style="float: left">
                <asp:Label ID="lblTitle" runat="server" Text="Task List" ToolTip="任 务 列 表"></asp:Label>

            </div>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:CheckBox ID="chkMIS" runat="server" Text="MIS Service" Checked="true" OnCheckedChanged="chkMIS_CheckedChanged" AutoPostBack="true" ForeColor="#E17009"  ToolTip="MIS服务"/>
            <asp:CheckBox ID="chkHR" runat="server" Text="Recruit" Checked="true" OnCheckedChanged="chkHR_CheckedChanged" AutoPostBack="true" ForeColor="#E17009" ToolTip="招聘" />
        </div>

        <div id="div_mis" runat="server">
            <div class="ui-accordion-header ui-helper-reset ui-state-default ui-accordion-header-active ui-state-active ui-corner-top ui-accordion-icons">
                    <asp:Label ID="lblMISService" runat="server" Text="MIS Service Request" ToolTip="MIS 服 务 申 请 单"></asp:Label>
            </div>
            <asp:GridView ID="gridTask_MIS" runat="server" SkinID="GridView" Width="100%" OnRowDataBound="gridTask_MIS_RowDataBound">
                <EmptyDataTemplate>
                    <div class="emptydatatemplate">
                        <asp:Label ID="lblNoData1" runat="server" Text="No task of this type" ToolTip="没有这个类型的任务"></asp:Label>
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="appr_nbr" HeaderText="Number" ItemStyle-Width="4%" FooterText="单号" />
                    <asp:BoundField DataField="form_location" HeaderText="Company" ItemStyle-Width="2%" ItemStyle-Wrap="false"
                        FooterText="公司" />
                    <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="2%" ItemStyle-Wrap="false"
                        FooterText="步骤" />
                    <asp:BoundField DataField="flow_status" HeaderText="Current Status" ItemStyle-Width="5%" ItemStyle-Wrap="false"
                        FooterText="当前状态" />
                    <asp:BoundField DataField="m_svr_subject" HeaderText="Subject" ItemStyle-Width="8%" ItemStyle-Wrap="false"
                        FooterText="主题" />

                    <asp:BoundField DataField="appr_date_in" HeaderText="Comming Time" ItemStyle-Width="5%" ItemStyle-Wrap="false"
                        DataFormatString="{0:MM/dd/yyyy HH}" FooterText="进入时间" />
                    <asp:BoundField DataField="appr_pending" HeaderText="Pending Hours" ItemStyle-Width="3%" ItemStyle-Wrap="false"
                        FooterText="等待时间" />
                    <asp:BoundField DataField="form_applicant" HeaderText="Applicant" ItemStyle-Width="3%" ItemStyle-Wrap="false"
                        FooterText="申请人" />
                    <asp:BoundField DataField="form_dept" HeaderText="Applicant Dept" ItemStyle-Width="2%" ItemStyle-Wrap="false"
                        FooterText="部门" />
                </Columns>
            </asp:GridView>
        </div>

        <div id="div_RECRUIT" runat="server">
            <div class="ui-accordion-header ui-helper-reset ui-state-default ui-accordion-header-active ui-state-active ui-corner-top ui-accordion-icons">
                <span class="ui-dialog-title">
                    <asp:Label ID="lblRecruit" runat="server" Text="HR Recruitment" ToolTip="人事招聘"></asp:Label>
                    </span>
            </div>
            <asp:GridView ID="gridTask_RECRUIT" runat="server" SkinID="GridView" Width="100%" OnRowDataBound="gridTask_RECRUIT_RowDataBound" OnSorting="gridTask_RECRUIT_Sorting" AllowSorting="True">
                <EmptyDataTemplate>
                    <div class="emptydatatemplate">
                        <asp:Label ID="lblNoData1" runat="server" Text="No task of this type" ToolTip="没有这个类型的任务"></asp:Label>
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:BoundField DataField="job_nbr" HeaderText="Number" ItemStyle-Width="4%" FooterText="单号" />
                  
                    <asp:BoundField DataField="job_location" HeaderText="Company" ItemStyle-Width="2%" ItemStyle-Wrap="false"
                        FooterText="公司" />
                        <asp:BoundField DataField="flow_type" HeaderText="Type" ItemStyle-Width="2%" ItemStyle-Wrap="false"
                        FooterText="类型" />
                    <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-Width="5%" ItemStyle-Wrap="false"
                        FooterText="状态" />
                    <asp:BoundField DataField="job_title" HeaderText="Job Title" ItemStyle-Width="3%" ItemStyle-Wrap="false"
                        FooterText="职位名称" />
                    <asp:BoundField DataField="job_applicant" HeaderText="Applicant" ItemStyle-Width="5%" ItemStyle-Wrap="false"
                        FooterText="申请人" />
                    <asp:BoundField DataField="job_date" HeaderText="Application Date" ItemStyle-Width="3%" ItemStyle-Wrap="false"
                        DataFormatString="{0:MM/dd/yyyy}" FooterText="申请时间" SortExpression="job_date" />
                    <asp:BoundField DataField="job_dept" HeaderText="Recruitment Dept" ItemStyle-Width="2%" ItemStyle-Wrap="false"
                        FooterText="部门" />
                </Columns>
            </asp:GridView>
        </div>

    </form>
</body>
</html>
