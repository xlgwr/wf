﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_Tasklist_001.aspx.cs" Inherits="Workflow.Systems.Tasklist"
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
        <div>
            <asp:Label ID="lblTitle" runat="server" Text="Task List" ToolTip="任 务 列 表"></asp:Label>
        </div>
    </div>
    <asp:GridView ID="gridTask" runat="server" SkinID="GridView" Width="100%" OnRowDataBound="gridTask_RowDataBound">
        <Columns>
            <asp:BoundField DataField="appr_nbr" HeaderText="Number" ItemStyle-Width="15%" FooterText="单号"/>
            <asp:BoundField DataField="config_title" HeaderText="Doc" ItemStyle-Width="20%" FooterText="单据类型"/>
            <asp:BoundField DataField="form_location" HeaderText="Company" ItemStyle-Width="10%" FooterText="公司"/>
            <asp:BoundField DataField="appr_date_in" HeaderText="Comming Time" ItemStyle-Width="15%"
                DataFormatString="{0:MM/dd/yyyy HH}" FooterText="进入时间"/>
            <asp:BoundField DataField="appr_pending" HeaderText="Pending Hours" ItemStyle-Width="10%" FooterText="等待时间"/>
            <asp:BoundField DataField="form_applicant" HeaderText="Applicant" ItemStyle-Width="20%" FooterText="申请人"/>
            <asp:BoundField DataField="form_dept" HeaderText="Applicant Dept" ItemStyle-Width="10%" FooterText="部门"/>
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
