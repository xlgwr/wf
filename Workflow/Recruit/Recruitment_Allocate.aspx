<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Allocate.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Allocate" Theme="GridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recruitment</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/easyui.css" rel="stylesheet" />
    <link href="../Styles/icon.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.easyui.min.js"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        //$(function () {
        //    $('#ReceiveList').datagrid({
        //        title: '收件箱',
        //        loadMsg: "正在加载，请稍等...",
        //        striped: true,
        //        fit: true,//自动大小
        //        fitColumns: true,
        //        url: '../AjaxLoad.ashx?AjaxType=CVALLOCATION',//查看收件箱内容
        //        columns: [[
        //            { field: 'cv_guid', checkbox: true },
        //            { field: 'cv_nbr', title: '发件人', width: 120, sortable: true },
        //            { field: 'cv_location', title: '发件时间', width: 120, sortable: true },
        //            { field: 'cv_path', title: '标题', width: 200, sortable: true }
        //        ]],
        //        rownumbers: true,//行号    
        //        singleSelect: false,//是否单选
        //        pagination: true//分页控件                 
        //    });
        //    //设置分页控件       
        //    //var p = $('#ReceiveList').datagrid('getPager');
        //    //$(p).pagination({
        //    //    pageSize: 10,//每页显示的记录条数，默认为10           
        //    //    pageList: [10, 20, 50],//可以设置每页记录条数的列表           
        //    //    beforePageText: '第',//页数文本框前显示的汉字           
        //    //    afterPageText: '页    共 {pages} 页',
        //    //    displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
        //    //});
        //});

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="subHeader">
            <div>
                <asp:Label ID="lblTitles" runat="server" Text="Recruitment Allocation" ToolTip="招聘分配"></asp:Label>
            </div>
        </div>
         <fieldset>
                <legend>
                    <asp:Label ID="lblTitle" runat="server" Text="Operate" ToolTip="操作"></asp:Label>
                </legend>
        <div>
               <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
            <asp:DropDownList ID="dropCompany" runat="server" OnSelectedIndexChanged="dropCompany_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                </asp:DropDownList>
                                <asp:Label ID="lblDept" runat="server" Text="Department" ToolTip="部 门"></asp:Label>
                                :
                            <asp:DropDownList ID="dropDept" runat="server"  OnSelectedIndexChanged="dropDept_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
            <asp:Label ID="Label1" runat="server" Text="Job Number" ToolTip="单号"></asp:Label>:
            <asp:DropDownList ID="dropJobs" runat="server" Width="150px"></asp:DropDownList>
            <asp:Button ID="btnSave" runat="server" Text="Allocate" ToolTip="分配" CssClass="btnNormal" UseSubmitBehavior="false" OnClick="btnSave_Click" />
        </div>
             </fieldset>
        <%-- <div style="height:200px">
            <table id="ReceiveList" height="400px;"></table>
        </div>--%>
        <div>
            <asp:GridView ID="cvGrid" runat="server" Width="100%" AutoGenerateColumns="false"
                SkinID="GridView" OnRowDataBound="cvGrid_RowDataBound">
                <EmptyDataTemplate>
                    <div class="emptydatatemplate">
                        <asp:Label ID="lblNoData1" runat="server" Text="No CV" ToolTip="没有可以分配的简历"></asp:Label>
                    </div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Select" FooterText="全选">
                               <itemtemplate>
                                    <asp:CheckBox ID="chkCheck" runat="server" />
                                </itemtemplate>
                      <ItemStyle Width="1%" />
                    </asp:TemplateField>

                                <asp:BoundField DataField="log_subject" HeaderText="CV" ItemStyle-Width="15%" FooterText="简历" ItemStyle-Wrap="false" />
                    
                    <asp:BoundField DataField="log_send_user" HeaderText="From" ItemStyle-Width="5%" FooterText="来自" />
                    <asp:BoundField DataField="log_domain" HeaderText="Domain" ItemStyle-Width="5%" FooterText="域名" />
                    <asp:BoundField DataField="log_cre_date" HeaderText="Coming Date" ItemStyle-Width="5%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                        FooterText="进入日期" />

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
