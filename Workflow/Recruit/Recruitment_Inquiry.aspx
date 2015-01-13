<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Inquiry.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Inquiry" Theme="GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recruitment Enquiry</title>
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
                <asp:Label ID="lblTitle" runat="server" Text="Recruitment Enuiry" ToolTip="查询"></asp:Label>
            </div>
        </div>
        <fieldset>
            <legend>
                <asp:Label ID="lblQuery" runat="server" Text="Query" ToolTip="查询"></asp:Label>
            </legend>

            <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                                 
                           
                                       <asp:DropDownList ID="dropCompany" runat="server" OnSelectedIndexChanged="dropCompany_SelectedIndexChanged" AutoPostBack="true">
                                       </asp:DropDownList>

            <asp:Label ID="lblDept" runat="server" Text="Department" ToolTip="部 门"></asp:Label>: 
                <asp:DropDownList ID="dropDept" runat="server" Width="120px">
                </asp:DropDownList>


            <asp:Label ID="lblSubject" runat="server" Text="Job Title" ToolTip="工 作 职 位"></asp:Label>:
                       
                        <asp:TextBox ID="txtTitle" runat="server" Width="300px" CssClass="textbox"
                            MaxLength="100"></asp:TextBox>
            <asp:Label ID="lblNumber" runat="server" Text="Recruit Number" ToolTip="编 号"></asp:Label>:
                  
                        <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineFill"></asp:TextBox><br />

            &nbsp;<asp:Button ID="btnQuery" runat="server" Text="Search" ToolTip="搜索" CssClass="btnNormal"
                UseSubmitBehavior="false" OnClick="btnQuery_Click" />
        </fieldset>
        <asp:GridView ID="jobGrid" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridView" OnRowCommand="jobGrid_RowCommand" OnRowDataBound="jobGrid_RowDataBound">
            <Columns>
                <asp:BoundField DataField="job_nbr" HeaderText="Recruit Number" ItemStyle-Width="3%" FooterText="招聘编号"></asp:BoundField>
                <asp:BoundField DataField="job_location" HeaderText="Recruit Company" ItemStyle-Width="2%" FooterText="招聘公司"></asp:BoundField>
                <asp:BoundField DataField="job_dept" HeaderText="Job Dept" ItemStyle-Width="2%" FooterText="职位部门"></asp:BoundField>
                <asp:BoundField DataField="job_title" HeaderText="Job Title" ItemStyle-Width="6%" FooterText="职位名称" ItemStyle-Wrap="false"></asp:BoundField>
                <asp:BoundField DataField="job_applicant" HeaderText="Recruit Applicant" ItemStyle-Width="3%"
                    FooterText="招聘创建者"></asp:BoundField>
                <asp:BoundField DataField="job_recruiter" HeaderText="Recruiter" ItemStyle-Width="3%"
                    FooterText="招聘者"></asp:BoundField>
                <asp:BoundField DataField="job_date" HeaderText="Recruit Date" ItemStyle-Width="2%" DataFormatString="{0:MM/dd/yyyy}"
                    FooterText="招聘创建日期"></asp:BoundField>

                <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="2%"
                    FooterText="步骤"></asp:BoundField>
                
                <asp:BoundField DataField="flow_status_en" HeaderText="Status" ItemStyle-Width="2%"
                    FooterText="状态"></asp:BoundField>

            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
