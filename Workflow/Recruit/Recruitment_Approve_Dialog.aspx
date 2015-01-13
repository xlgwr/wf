<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Approve_Dialog.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Approve_Dialog" Theme="GridView" %>

<%@ Register Src="../UserControls/UploadAttach.ascx" TagName="UploadAttach" TagPrefix="uc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CV Approval</title>
    <base target="_self" />
    <meta http-equiv="Expires" content="0">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Pragma" content="no-cache">
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $(".textdate").datepicker({ changeMonth: true, changeYear: true });
        })
        function ShowEdit() {
            $("#hideEdit").dialog(
            {
                modal: false,
                draggable: false,
                resizable: false,
                title: "Add Interview Info",
                height: 200
            }

   ).parent().appendTo(jQuery("form:first"));

        }
    </script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="subHeader">
            <div>
                <asp:Label ID="Label2" runat="server" Text="Recruitment Approval" ToolTip="招聘审批"></asp:Label>
                --<asp:Label ID="lblTaskStatus" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div id="div_show">
            <div>
                <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed; height: 300px">

                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9" width="15%">
                            <div align="right">
                                <asp:Label ID="Label1" runat="server" Text="Job Number" ToolTip="编 号"></asp:Label>:
                            </div>
                        </td>
                        <td width="40%">
                            <asp:TextBox ID="txtCVNbr" runat="server" CssClass="myLineCenter" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td bgcolor="EAF2F9">
                            <asp:Label ID="Label3" runat="server" Text="Job Description" ToolTip="工 作 描 述"></asp:Label>:
                      
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9" width="15%">
                            <div align="right">
                                <asp:Label ID="Label4" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtReqLoc" runat="server" CssClass="myLineCenter"></asp:TextBox>
                        </td>
                        <td rowspan="10">
                            <asp:TextBox ID="txtDesc1" runat="server" TextMode="MultiLine" Width="98%" Height="380px" ReadOnly="True"></asp:TextBox></td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9" width="15%">
                            <div align="right">
                                <asp:Label ID="Label5" runat="server" Text="Department" ToolTip="部 门"></asp:Label>: 
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtDept1" runat="server" CssClass="myLineCenter"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9" width="15%">
                            <div align="right">
                                <asp:Label ID="lblTitle" runat="server" Text="Job Title" ToolTip="职位标题"></asp:Label>: 
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" CssClass="myLineCenter" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9" width="15%">
                            <div align="right">
                                <asp:Label ID="lbl1" runat="server" Text="CV" ToolTip="简历"></asp:Label>: 
                            </div>
                        </td>
                        <td>
                            <asp:Label ID="lblCV" runat="server" Text="" ToolTip=""></asp:Label>
                        </td>
                    </tr>

                    <asp:Panel runat="server" ID="Panel1" Visible="false">
                        <tr bgcolor="#FFFFFF">
                            <td colspan="2" bgcolor="EAF2F9">
                                <asp:Label ID="lblApporve" runat="server" Text="Need additional user approval"
                                    ToolTip="需要相关用户审批"></asp:Label>


                                <asp:CheckBox ID="checkApprove" runat="server" OnCheckedChanged="checkApprove_CheckedChanged"
                                    AutoPostBack="true" />
                                <asp:Panel ID="panelRelate" runat="server" Visible="false">
                                    <asp:TextBox ID="txtRelative" runat="server" CssClass="textbox" Width="380px"></asp:TextBox><img
                                        onclick='if (document.all.txtRelative.readOnly) return;window.open("../Systems/Sys_SelectUser.aspx?ctrlname=txtRelative",null,"height=400,width=600,status=yes,top=100,left=100,toolbar=no,menubar=no,location=center")'
                                        src="../images/person1.gif" align="absMiddle" border="0">
                                </asp:Panel>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="Panel3" Visible="false">
                        <tr bgcolor="#FFFFFF">
                            <td bgcolor="EAF2F9">
                                <asp:Label ID="Label8" runat="server" Text="Suggestion"
                                    ToolTip="建议"></asp:Label>


                            </td>
                            <td>
                                <asp:RadioButtonList ID="rdoSuggestion" runat="server">
                                    <asp:ListItem Text="Recommend"></asp:ListItem>
                                    <asp:ListItem Text="Not Recommend"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="Panel2" Visible="false">
                        <tr bgcolor="#FFFFFF">
                            <td colspan="2" bgcolor="EAF2F9">
                                <fieldset>
                                    <legend>
                                        <asp:Label ID="Label6" runat="server" Text="Interview Information" ToolTip="面试信息"></asp:Label></legend>

                                    <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed;">
                                        <tr>
                                            <td bgcolor="EAF2F9">
                                                <div align="right">
                                                    <asp:Label ID="lblCandicate" runat="server" Text="Candidate Name" ToolTip="候选人姓名"></asp:Label>:
                                                </div>
                                            </td>
                                            <td bgcolor="#FFFFFF">
                                                <asp:TextBox ID="txtCandidate" runat="server" CssClass="textbox"></asp:TextBox>
                                                <%--<asp:Button ID="btnConfirm" runat="server" Text="Save" ToolTip="保存"  OnClick="btnSave_Click"  />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="EAF2F9">
                                                <div align="right">
                                                    <asp:Label ID="Label9" runat="server" Text="Gender" ToolTip="候选人性别"></asp:Label>:
                                                </div>
                                            </td>
                                            <td bgcolor="#FFFFFF">
                                                <asp:DropDownList ID="dropGender" runat="server">
                                                    <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                                                    <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                                                </asp:DropDownList>
                                                <%--<asp:Button ID="btnConfirm" runat="server" Text="Save" ToolTip="保存"  OnClick="btnSave_Click"  />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td bgcolor="EAF2F9">
                                                <div align="right">
                                                    <asp:Label ID="lblCondicatePhone" runat="server" Text="Candidate Phone" ToolTip="候选人电话"></asp:Label>:
                                                </div>
                                            </td>
                                            <td bgcolor="#FFFFFF">
                                                <asp:TextBox ID="txtPhone" runat="server" CssClass="textbox"></asp:TextBox>
                                                <%--<asp:Button ID="btnConfirm" runat="server" Text="Save" ToolTip="保存"  OnClick="btnSave_Click"  />--%>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#FFFFFF">
                                            <td bgcolor="EAF2F9" width="30%">
                                                <div align="right">
                                                    <asp:Label ID="lblTimes" runat="server" Text="Interview round" ToolTip="面试轮数"></asp:Label>:
                                                </div>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropRound" runat="server">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#FFFFFF">
                                            <td bgcolor="EAF2F9" width="30%">
                                                <div align="right">
                                                    <asp:Label ID="Label7" runat="server" Text="Interview Type" ToolTip="面试方式"></asp:Label>:
                                                </div>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="dropInterviewType" runat="server">
                                                    <asp:ListItem Text="Screening interview" Value="Screening interview"></asp:ListItem>
                                                    <asp:ListItem Text="Hiring interview" Value="Hiring interview"></asp:ListItem>
                                                    <asp:ListItem Text="Telephone interview" Value="Telephone interview"></asp:ListItem>
                                                    <asp:ListItem Text="Video conferencing interview" Value="Video conferencing interview"></asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#FFFFFF">
                                            <td bgcolor="EAF2F9" width="15%">
                                                <div align="right">
                                                    <asp:Label ID="lblIterviewer" runat="server" Text="Interviewer" ToolTip="面试者"></asp:Label>:
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtInterviewer" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox><img
                                                    onclick='window.open("../Systems/Sys_SelectUser.aspx?ctrlname=txtInterviewer",null,"height=400,width=600,status=yes,top=100,left=100,toolbar=no,menubar=no,location=center")'
                                                    src="../images/person1.gif" align="absMiddle" border="0">
                                            </td>
                                        </tr>

                                        <tr bgcolor="#FFFFFF">
                                            <td bgcolor="EAF2F9" width="15%">
                                                <div align="right">
                                                    <asp:Label ID="lblDate" runat="server" Text="Interview Date" ToolTip="面试时间"></asp:Label>
                                                </div>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtDate" runat="server" CssClass="textdate"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr bgcolor="#FFFFFF">
                                            <td colspan="2">
                                                <asp:Button ID="btnAdd" runat="server" Text="Save" ToolTip="保存" OnClick="btnAdd_Click" CssClass="btnNormal" UseSubmitBehavior="false" /></td>
                                        </tr>
                                    </table>

                                    <%--<asp:LinkButton ID="linkshow" runat="server" Text="Add Interview Info" ToolTip="增加面试信息" OnClientClick="showEdit();return false;"></asp:LinkButton>--%>
                                    <asp:GridView ID="interviewGrid" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="false" OnRowDataBound="interviewGrid_RowDataBound" OnRowDeleting="interviewGrid_RowDeleting">
                                        <EmptyDataTemplate>
                                            <div class="emptydatatemplate">
                                                <asp:Label ID="lblNoData" runat="server" Text="No Interview Info" ToolTip="没有数据"></asp:Label>
                                            </div>
                                        </EmptyDataTemplate>
                                        <Columns>
                                            <asp:CommandField HeaderText="Operate" ShowDeleteButton="True" ShowHeader="True"
                                                FooterText="操 作" ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="interview_round" HeaderText="Round" ItemStyle-Width="1%"
                                                FooterText="次数"></asp:BoundField>
                                            <asp:BoundField DataField="interview_type" HeaderText="Interview Type" ItemStyle-Width="10%"
                                                FooterText="面试方式"></asp:BoundField>
                                            <asp:BoundField DataField="interview_by" HeaderText="Interviewer" ItemStyle-Width="10%"
                                                FooterText="面试人"></asp:BoundField>
                                            <asp:BoundField DataField="interview_date" HeaderText="Interview Date" ItemStyle-Width="10%"
                                                FooterText="面试日期" DataFormatString="{0:MM/dd/yyyy}"></asp:BoundField>
                                            <asp:BoundField DataField="interview_cre_by" HeaderText="Recruiter" ItemStyle-Width="10%"
                                                FooterText="招聘人"></asp:BoundField>
                                        </Columns>
                                    </asp:GridView>
                                </fieldset>
                                <div id="div_append"></div>
                                <div id="hideEdit" style="display: none">
                                </div>
                            </td>
                        </tr>
                        <tr bgcolor="#FFFFFF" class="tr_assign">
                            <td bgcolor="EAF2F9">
                                <div align="right">
                                    <asp:Label ID="lblConfirmDay" runat="server" Text="Offer Date" ToolTip="录取通知日期"></asp:Label>:
                                </div>
                            </td>
                            <td>
                                <asp:TextBox ID="txtConfirmDate" runat="server" CssClass="textdate"></asp:TextBox>
                                <%--<asp:Button ID="btnConfirm" runat="server" Text="Save" ToolTip="保存"  OnClick="btnSave_Click"  />--%>
                            </td>
                        </tr>

                    </asp:Panel>
                    <asp:Panel runat="server" ID="Panel4" Visible="false">
                        <tr class="attachment_head" >
                            <td colspan="2">
                                <asp:Label ID="Label10" runat="server" Text="Attachment" ToolTip="附 件 区 域"></asp:Label>:
                            </td>
                        </tr>
                        <tr bgcolor="#FFFFFF">
                            <td align="left" colspan="2">
                                <uc1:UploadAttach ID="UploadAttach1" runat="server" />
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9" width="15%">
                            <div align="right">

                                <asp:Label ID="lblReason" runat="server" Text="Reject Reason" ToolTip="退回原因"></asp:Label>
                            </div>
                        </td>
                        <td>
                            <%--     <asp:RadioButtonList ID="rdoReason" runat="server" OnSelectedIndexChanged="rdoReason_SelectedIndexChanged" AutoPostBack="true">
                            </asp:RadioButtonList>--%>
                            <asp:DropDownList ID="dropReason" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropReason_SelectedIndexChanged"></asp:DropDownList>
                            <br />
                            <br />
                            <asp:TextBox ID="txtOther" runat="server" CssClass="myLineCenter" Visible="false" Width="80%"></asp:TextBox>

                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td bgcolor="EAF2F9">
                            <div align="right">
                                <asp:Label ID="lblSubmit" runat="server" Text="Remark" ToolTip="备 注"></asp:Label>:
                            </div>
                        </td>
                        <td>
                            <asp:TextBox ID="txtRemark" runat="server" TextMode="MultiLine" Width="98%" Height="60px"></asp:TextBox>
                            <asp:Button ID="btnApprve" runat="server" Text="Approve" ToolTip="提 交" CssClass="btnNormal"
                                OnClick="btnApprve_Click" />
                            &nbsp;
                                    <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="退 回" CssClass="btnNormal"
                                        OnClick="btnReject_Click" />
                            &nbsp;</td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed;">
                    <tr class="attachment_head">
                        <td>
                            <asp:Label ID="lblHitory" runat="server" Text="Approval History" ToolTip="审 批 记 录"></asp:Label>:
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td align="center">
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
                </table>
            </div>
        </div>
    </form>
</body>
</html>
