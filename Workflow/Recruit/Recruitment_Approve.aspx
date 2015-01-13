<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Approve.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Approve" Theme="GridView" %>

<%@ Register Src="~/UserControls/UploadAttach.ascx" TagPrefix="uc1" TagName="UploadAttach" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recruitment</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script type="text/javascript">
        //$(document).ready(function () {
        //    var dept = $("#txtDept").val();
        //    $("#txtDept1").val(dept)
        //    $("#btnApprve").click(function () {
        //        var lang = $("#txtReqLang").val();
        //        $.ajax({
        //            type: "post",
        //            url: "../AjaxLoad.ashx",
        //            data: {
        //                AjaxType: 'EXECFLOWAPPROVE',
        //                ReqNbr: $("#txtCVNbr").val(),
        //                ReqLoc: $("#txtReqLoc").val(),
        //                ReqType: 'CV',
        //                ReqAction: 'PASS',
        //                ReqUser: $("#txtReqUser").val(),
        //                ReqRemark: $("#txtRemark").val(),
        //                ReqLang: lang,
        //            },
        //            success: function (result) {
                        
        //                alert(result);
        //            },
        //            error: function () {
        //                alert("Error");
        //            }
        //        });
        //        return false;
        //    });
        //})
        function showDialog(guid, jobguid) {

            window.showModalDialog("Recruitment_Approve_Dialog.aspx?ReqGuid=" + guid + "&ReqJobGuid=" + jobguid + "","Title", "dialogWidth:800px;dialogHeight:800px;status:no;toolbar:no;menubar:no;location:center;")
            window.location.href = window.location.href;
            //if (result == 1)this.form.submit();
            //return false
        }
        function validateReason() {
            var reason = $("txtRemark").text;
            if (reason == "") {
                alert("Please input reject reason");
                return false;
            }
        }
        function SetValue(username) {
            $("#txtMan").val(username);
        }
    </script>
</head>
<body>

    <form id="form1" runat="server">
        <div class="subHeader">
            <div>
            </div>
        </div>
        <div style="width: 99.8%">
            <fieldset>
                <legend>
                    <asp:Label ID="lblTitle" runat="server" Text="Recruitment Master Info" ToolTip="招聘主信息"></asp:Label>
                </legend>
                <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed">
                    <tr bgcolor="#FFFFFF">
                        <td width="5%" bgcolor="EAF2F9">
                            <div align="right">
                                <asp:Label ID="lblNumber" runat="server" Text="Job Number" ToolTip="编 号"></asp:Label>:
                            </div>
                        </td>
                        <td width="10%">
                            <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="5%" bgcolor="EAF2F9">
                            <div align="right">
                                <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                            </div>
                        </td>
                        <td width="10%">
                            <asp:TextBox ID="txtLocation" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td width="5%" bgcolor="EAF2F9">
                            <div align="right">
                                <asp:Label ID="lblDept" runat="server" Text="Department" ToolTip="部 门"></asp:Label>: 
                            </div>
                        </td>
                        <td width="10%">
                            <asp:TextBox ID="txtDept" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td width="5%" bgcolor="EAF2F9">
                            <div align="right">
                                <asp:Label ID="lblSubject" runat="server" Text="Job Title" ToolTip="工 作 职 位"></asp:Label>:
                            </div>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtTitle" runat="server" Width="400px" CssClass="myLineCenter"
                                MaxLength="100"  ReadOnly="True"></asp:TextBox><br />
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td width="5%" bgcolor="EAF2F9">
                            <div align="right">
                                <asp:Label ID="lblDesc" runat="server" Text="Job Description" ToolTip="工 作 描 述"></asp:Label>:
                       
                            </div>
                        </td>
                        <td colspan="5">
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="100%" Height="100px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <asp:GridView ID="attachGrid" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="false"
                        OnRowDataBound="attachGrid_RowDataBound">
                        <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData" runat="server" Text="No Adv Info" ToolTip="没有广告信息"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="attach_title" HeaderText="FileName" ItemStyle-Width="60%"
                                FooterText="文件名称">
                            </asp:BoundField>
                                                         <asp:BoundField DataField="attach_rmk1" HeaderText="Adv Webs ite" ItemStyle-Width="10%"
                                FooterText="网站">
                            </asp:BoundField>
                             <asp:BoundField DataField="attach_user" HeaderText="Creater" ItemStyle-Width="10%"
                                FooterText="上传人">
                            </asp:BoundField>
                                                         <asp:BoundField DataField="attach_time" HeaderText="Create Time" ItemStyle-Width="20%"
                                FooterText="创建时间"  DataFormatString="{0:MM/dd/yyyy HH:mm}">
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>

        </div>
        <div style="width: 99.8%">
            <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed">
                <tr class="attachment_head">
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Recruitment CV Info" ToolTip="招聘简历信息"></asp:Label>:
                    </td>
                </tr>
                <tr bgcolor="#FFFFFF">
                    <td align="center">
                        <asp:GridView ID="cvGrid" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridView" OnRowDataBound="cvGrid_RowDataBound" OnRowCommand="cvGrid_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="cv_nbr" HeaderText="CV Number" ItemStyle-Width="5%" FooterText="简历编号">
                                    <ItemStyle Width="5%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="cv_cre_by" HeaderText="CV Creater" ItemStyle-Width="3%"
                                    FooterText="简历创建者"></asp:BoundField>
                                <asp:BoundField DataField="cv_cre_date" HeaderText="CV Create Date" ItemStyle-Width="5%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                                    FooterText="简历创建日期"></asp:BoundField>
                                <asp:BoundField DataField="cv_cre_date" HeaderText="CV" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                                    FooterText="简历" ItemStyle-Wrap="true">
                                    <ItemStyle Width="10%"></ItemStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="2%"
                                    FooterText="步骤"></asp:BoundField>
                                 <asp:BoundField DataField="flow_status" HeaderText="Current Status" ItemStyle-Width="10%" 
                                    FooterText="当前状态" ItemStyle-Wrap="true">
                                    <ItemStyle Width="10%"></ItemStyle>
                                </asp:BoundField>
                                
                                <asp:TemplateField HeaderText="Operate" FooterText="操作">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnSubmit" runat="server" Text="Toggle" ToolTip="触发" CommandArgument='<%# Eval("cv_guid") %>' CommandName="Toggle" UseSubmitBehavior="false"  ></asp:LinkButton>

                                    </ItemTemplate>
                                    <ItemStyle Width="2%"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <div id="hidden_approve" style="display: none">

            <asp:TextBox ID="txtReqUser" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtReqLang" runat="server"></asp:TextBox>
        </div>
    </form>
</body>
</html>
