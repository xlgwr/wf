<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Maintain.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Maintain" Theme="GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recruitment Maintenance</title>
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
                <asp:Label ID="lblTitle" runat="server" Text="Recruitment Maintenance" ToolTip="招聘维护"></asp:Label>
            </div>
        </div>
        <fieldset>
            <legend>
                <asp:Label ID="lblQuery" runat="server" Text="Query" ToolTip="查询"></asp:Label>
             
            </legend>
            <asp:Label ID="lblNumber" runat="server" Text="Recruit Number" ToolTip="编 号"></asp:Label>:
                  
                        <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineFill"></asp:TextBox>
            <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                                 
                           
                                       <asp:DropDownList ID="dropCompany" runat="server" OnSelectedIndexChanged="dropCompany_SelectedIndexChanged" AutoPostBack="true">
                                       </asp:DropDownList>

            <asp:Label ID="lblDept" runat="server" Text="Department" ToolTip="部 门"></asp:Label>: 
                <asp:DropDownList ID="dropDept" runat="server" Width="120px">
                </asp:DropDownList>


            <asp:Label ID="lblSubject" runat="server" Text="Job Title" ToolTip="工 作 职 位"></asp:Label>:
                       
                        <asp:TextBox ID="txtTitle" runat="server" Width="300px" CssClass="textbox"
                            MaxLength="100"></asp:TextBox><br />

            &nbsp;<asp:Button ID="btnQuery" runat="server" Text="Search" ToolTip="搜索" CssClass="btnNormal"
                UseSubmitBehavior="false" OnClick="btnQuery_Click" />
            <asp:Button ID="btn" runat="server" Text="Download my cv task" ToolTip="下载简历任务" OnClick="btn_Click" />
        </fieldset>
        <div runat="server" id ="div_report" visible="false"> 
             <fieldset>
            <legend>
                <asp:Label ID="Label1" runat="server" Text="Down report" ToolTip="下载报表"></asp:Label>
             
            </legend>
             <asp:Label ID="lblBeginDate" runat="server" Text="Begin Date" ToolTip="开始时间"></asp:Label>
              <asp:TextBox ID="txtBeginDate" runat="server" CssClass="textdate"></asp:TextBox>
            <asp:Label ID="lblEndDate" runat="server" Text="End Date" ToolTip="结束时间"></asp:Label>
              <asp:TextBox ID="txtEndDate" runat="server" CssClass="textdate"></asp:TextBox>
             <asp:Button ID="btnDownReport" runat="server" Text="Download" ToolTip="下载" CssClass="btnNormal"
                UseSubmitBehavior="false" OnClick="btnDownReport_Click" />
                 </fieldset>
        </div>
        <asp:GridView ID="jobGrid" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridView" OnRowCommand="jobGrid_RowCommand" OnRowDataBound="jobGrid_RowDataBound">
            <Columns>
                <asp:BoundField DataField="job_nbr" HeaderText="Recruit Number" ItemStyle-Width="5%" FooterText="招聘编号"></asp:BoundField>
                <asp:BoundField DataField="job_location" HeaderText="Recruit Company" ItemStyle-Width="2%" FooterText="招聘公司"></asp:BoundField>
                <asp:BoundField DataField="job_dept" HeaderText="Job Dept" ItemStyle-Width="2%" FooterText="职位部门"></asp:BoundField>
                <asp:BoundField DataField="job_title" HeaderText="Job Title" ItemStyle-Width="10%" FooterText="职位名称" ItemStyle-Wrap="false"></asp:BoundField>
                <asp:BoundField DataField="job_applicant" HeaderText="Recruit Applicant" ItemStyle-Width="3%"
                    FooterText="招聘创建者"></asp:BoundField>
                <asp:BoundField DataField="job_recruiter" HeaderText="Recruiter" ItemStyle-Width="3%"
                    FooterText="招聘者"></asp:BoundField>
                <asp:BoundField DataField="job_date" HeaderText="Recruit Date" ItemStyle-Width="5%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                    FooterText="招聘创建日期"></asp:BoundField>

                <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="2%"
                    FooterText="步骤"></asp:BoundField>
                <asp:TemplateField HeaderText="Operate" FooterText="操作">
                    <ItemTemplate>
                        <%-- <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" ToolTip="提交" CommandArgument='<%# Eval("cv_nbr") %>' CommandName="Submit"></asp:LinkButton>&nbsp;--%>
                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" ToolTip="删除" CommandArgument='<%# Eval("job_guid") %>' CommandName="Del"></asp:LinkButton>
                    </ItemTemplate>
                    <ItemStyle Width="2%"></ItemStyle>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
