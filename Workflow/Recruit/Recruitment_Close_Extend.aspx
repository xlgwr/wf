<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment_Close_Extend.aspx.cs" Inherits="Workflow.Recruit.Recruitment_Close_Extend" Theme="GridView" %>

<%@ Register Src="~/UserControls/UploadAttach_COM.ascx" TagPrefix="uc1" TagName="UploadAttach" %>
<%@ Register Src="../UserControls/UploadAttach.ascx" TagName="UploadAttach" TagPrefix="uc2" %>
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
        function showDialog(guid, jobguid) {

            window.showModalDialog("Recruitment_Approve_Dialog.aspx?ReqGuid=" + guid + "&ReqJobGuid=" + jobguid + "", "Title", "dialogWidth:800px;status:no;toolbar:no;menubar:no;location:center;")
            window.location.href = window.location.href;
            //if (result == 1)this.form.submit();
            //return false
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="subHeader">
            <div>
                <asp:Label ID="lblTitles" runat="server" Text="Recruitment" ToolTip="招聘"></asp:Label>
                --<asp:Label ID="lblTaskStatus" runat="server" Text=""></asp:Label>
            </div>
        </div>
        <div style="width: 99.8%">
            <fieldset>
                <legend>

                    <asp:Label ID="lblTitle" runat="server" Text="Recruitment Master Info" ToolTip="招聘主信息"></asp:Label>
                </legend>
                <div style="float: left; width: 50%">
                    <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="" style="height: 200px">

                        <tr bgcolor="">
                            <td bgcolor="" width="10%">
                                <div align="right">
                                    <asp:Label ID="lblNumber" runat="server" Text="Job Number" ToolTip="编 号"></asp:Label>:
                                </div>
                            </td>
                            <td width="65%">
                                <asp:TextBox ID="txtNbr" runat="server" CssClass="myLineFill" ReadOnly="True"></asp:TextBox>
                                <%--<asp:CheckBox ID="chkKey" runat="server" Text="key position" ToolTip="关键职位" />--%>
                                <asp:Label ID="lblPriority" runat="server" Text="Priority" ToolTip="优先级"></asp:Label>:  
                                <asp:DropDownList ID="dropPriority" runat="server"></asp:DropDownList>
                            </td>
                            <td>
                                <div style="text-align: right">
                                    <asp:Label ID="lblDesc" runat="server" Text="Job Description" ToolTip="工作描述"></asp:Label>:
                                </div>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">
                                    <asp:Label ID="lblLocation" runat="server" Text="Company" ToolTip="公 司"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:DropDownList ID="dropCompany" runat="server" OnSelectedIndexChanged="dropCompany_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                </asp:DropDownList>
                                <asp:Label ID="lblDept" runat="server" Text="Department" ToolTip="部 门"></asp:Label>
                                :
                            <asp:DropDownList ID="dropDept" runat="server" Width="120px">
                            </asp:DropDownList>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">
                                    <asp:Label ID="lblDefault" runat="server" Text="Hiring Manager" ToolTip="默认审批人"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">

                                <asp:TextBox ID="txtMan" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>

                                <%--    <img align="absMiddle" alt="Picture" border="0" onclick="window.open(&quot;../Systems/Sys_SelectOne.aspx?ctrlname=txtMan&quot;,null,&quot;height=400,width=400,status=no,top=200,left=400,toolbar=no,menubar=no,location=center&quot;)" src="../images/person1.gif" />&nbsp;
                            <asp:Button ID="btnClear" runat="server" CssClass="btnNormal" OnClick="btnClear_Click" Text="Clear" ToolTip="清除" UseSubmitBehavior="false" />--%>




                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="" width="15%">
                                <div align="right">
                                    <asp:Label ID="Label5" runat="server" Text="First Screen department manager" ToolTip="First Screen department manager"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">

                                <asp:TextBox ID="txtDeptmanager" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label3" runat="server" Text="Recruiter" ToolTip="招聘人"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtRecruter" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" Text="Application Date" ToolTip="申请日期"></asp:Label>:
                                <asp:TextBox ID="txtApplicationDate" runat="server" CssClass="myLineCenter"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="lblSubject" runat="server" Text="Job Title" ToolTip="工 作 职 位"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtTitle" runat="server" Width="90%" CssClass="myLineCenter"
                                    MaxLength="100"></asp:TextBox><br />

                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label7" runat="server" Text="CV Number" ToolTip="简历编号"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtCVNbr" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="Label8" runat="server" Text="Offer Date" ToolTip="录取通知日期"></asp:Label>:
                                <asp:TextBox ID="txtCondidateDate" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label10" runat="server" Text="Candidate Name" ToolTip="候选人姓名"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtName" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                                <asp:Label ID="Label11" runat="server" Text="Candidate phone" ToolTip="候选人电话"></asp:Label>:
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="myLineCenter" ReadOnly="true" Width="150px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label9" runat="server" Text="Commits On Board Date" ToolTip="预计上班日期"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtOnboardDate" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label12" runat="server" Text="Actual On Board Date" ToolTip="上班日期"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtActualDate" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>

                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label13" runat="server" Text="Probation period end date" ToolTip="试用期结束日期"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="myLineCenter" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label14" runat="server" Text="Probation period end date extend" ToolTip="试用期结束日期"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtExtendDate" runat="server" CssClass="textdate" ReadOnly="true"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label4" runat="server" Text="Remark" ToolTip="备注"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtRemark" runat="server" Width="90%" Height="80px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox><br />

                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td colspan="2">

                                <%-- <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="保 存" CssClass="btnNormal"
                                    OnClick="btnSave_Click" />--%>
                                <%-- <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="提 交" CssClass="btnNormal" Visible="false" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="退回" CssClass="btnNormal" UseSubmitBehavior="false" />--%>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="提交" CssClass="btnNormal" OnClick="btnSubmit_Click" />
                                <asp:Button ID="btnReject" runat="server" Text="Reject" ToolTip="退回" CssClass="btnNormal" OnClick="btnReject_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 200px; width: 48%; float: left">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="95%" Height="190px"></asp:TextBox>
                </div>
                <br />
                <div id="div_ATTACH" runat="server" visible="false" style="clear: both">
                    <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed">
                        <tr class="attachment_head">
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Adv Attachment" ToolTip="广告附件"></asp:Label>:
                            </td>
                        </tr>
                        <tr bgcolor="#FFFFFF">
                            <td align="left">

                                <uc1:UploadAttach ID="UploadAttach1" runat="server" />

                            </td>
                        </tr>
                         <tr class="attachment_head">
                <td >
                    <asp:Label ID="Label15" runat="server" Text="Add Reference" ToolTip="增加参照"></asp:Label>:
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td align="left">
                    <uc2:UploadAttach ID="UploadAttach2" runat="server" />
                </td>
            </tr>
                    </table>
                </div>
        </div>
        <div>
        </div>

        </fieldset>




        </div>
        <div style="width: 100%; display: none" id="div_CV" runat="server">
            <fieldset>
                <legend>

                    <asp:Label ID="Label2" runat="server" Text="Recruitment CV Info" ToolTip="招聘简历信息"></asp:Label>:
                </legend>
                <asp:GridView ID="cvGrid" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridView" OnRowDataBound="cvGrid_RowDataBound" OnRowCommand="cvGrid_RowCommand" OnRowCancelingEdit="cvGrid_RowCancelingEdit" OnRowEditing="cvGrid_RowEditing" OnRowUpdating="cvGrid_RowUpdating">
                    <Columns>
                        <asp:BoundField DataField="cv_nbr" HeaderText="CV Number" ItemStyle-Width="5%" FooterText="简历编号" ReadOnly="true">
                            <ItemStyle Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="cv_cre_by" HeaderText="CV Creater" ItemStyle-Width="3%" ReadOnly="true"
                            FooterText="简历创建者">
                            <ItemStyle Width="3%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="cv_cre_date" HeaderText="CV Create Date" ItemStyle-Width="5%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                            FooterText="简历创建日期" ReadOnly="true">
                            <ItemStyle Width="5%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="cv_cre_date" HeaderText="CV" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                            FooterText="简历" ItemStyle-Wrap="true" ReadOnly="true">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="2%"
                            FooterText="步骤" ReadOnly="true">
                            <ItemStyle Width="2%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="flow_status" HeaderText="Current Status" ItemStyle-Width="10%"
                            FooterText="当前状态" ReadOnly="true">
                            <ItemStyle Width="10%"></ItemStyle>
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="cv_onboard_date" HeaderText="On Board Date" ItemStyle-Width="10%"
                                        FooterText="上班日期">
<ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField> --%>
                        <asp:TemplateField HeaderText="On Board Date" ItemStyle-Width="5%">
                            <ItemTemplate>

                                <asp:Label ID="Label5" Text='<%# Eval("cv_onboard_date") %>' runat="server"></asp:Label>

                            </ItemTemplate>

                            <EditItemTemplate>

                                <asp:TextBox ID="txtOnBoardDate" CssClass="textdate" runat="server" Text='<%# Eval("cv_onboard_date") %>'></asp:TextBox>

                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField HeaderText="Operate" ShowEditButton="True" ShowHeader="True" ItemStyle-Width="2%" />
                        <%--  <asp:TemplateField HeaderText="Operate" FooterText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" ToolTip="提交" CommandArgument='<%# Eval("cv_guid") %>' CommandName="Submit"></asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="btnReject" runat="server" Text="Reject" ToolTip="退回" CommandArgument='<%# Eval("cv_guid") %>' CommandName="Reject"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%"></ItemStyle>
                                    </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
                <%--  <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed">
                    <tr bgcolor="#FFFFFF">
                        <td>

                            <input type="file" runat="server" class="fileUpload" size="50" id="FileUP" />
                            <asp:Label ID="lblUpload" runat="server" Text="Select Website" ToolTip="选 择 网 站"></asp:Label>：<asp:DropDownList ID="dropSites" runat="server"></asp:DropDownList>
                            <asp:Button ID="btnAddCV" runat="server" Text="Add CV" ToolTip="创建简历" CssClass="btnNormal"
                                UseSubmitBehavior="false" OnClick="btnAddCV_Click" />
                            <asp:Label ID="lblWarm" runat="server"
                                Text="Attachment file must less than 10M" ForeColor="Red" ToolTip="附件必须小于10兆"></asp:Label>
                        </td>
                    </tr>
                    <tr bgcolor="#FFFFFF">
                        <td align="center">
                            &nbsp;</td>
                    </tr>
                </table>--%>
            </fieldset>
        </div>

    </form>
</body>
</html>
