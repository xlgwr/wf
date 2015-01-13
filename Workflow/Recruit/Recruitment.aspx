<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recruitment.aspx.cs" Inherits="Workflow.Recruit.Recruitment" Theme="GridView" %>

<%@ Register Src="~/UserControls/UploadAttach_COM.ascx" TagPrefix="uc1" TagName="UploadAttach" %>

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
        function showmMGT()
        {
            var location = $("#dropCompany").val();
            var dept = $("#dropDept").val();
            if (dept.indexOf("&") >= 0)
            {
                dept = dept.replace("&", "[]");
            }
            if (location == "" || dept == "")
            {
                return;
            }
            window.open("../Custom/Cus_SelectOneMGT.aspx?ctrlname=txtMan&location=" + location + "&dept=" + dept + "", null, "height=400,width=400,status=no,top=200,left=400,toolbar=no,menubar=no,location=center")
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="subHeader">
            <div>
                <asp:Label ID="lblTitles" runat="server" Text="Recruitment" ToolTip="招聘"></asp:Label>
            </div>
        </div>
        <div style="width: 99.8%">
            <fieldset>
                <legend>

                    <asp:Label ID="lblTitle" runat="server" Text="Recruitment Master Info" ToolTip="招聘主信息"></asp:Label>
                </legend>
                <div>
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

                                <asp:TextBox ID="txtMan" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>

                                <img
                                    onclick='showmMGT()'
                                    src="../images/person1.gif" align="absMiddle" border="0" alt="Picture" />&nbsp;
                            <asp:Button ID="btnClear" runat="server" CssClass="btnNormal" OnClick="btnClear_Click" Text="Clear" ToolTip="清除" UseSubmitBehavior="false" />
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">
                                    <asp:Label ID="Label5" runat="server" Text="First Screen department manager" ToolTip="First Screen department manager"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">

                                <asp:TextBox ID="txtDeptmanager" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>

                                <img
                                    onclick='window.open("../Systems/Sys_SelectUser.aspx?ctrlname=txtDeptmanager",null,"height=400,width=600,status=yes,top=100,left=100,toolbar=no,menubar=no,location=center")'
                                    src="../images/person1.gif" align="absMiddle" border="0" alt="Picture" />&nbsp;
                            <asp:Button ID="btnClear1" runat="server" CssClass="btnNormal" Text="Clear" ToolTip="清除" UseSubmitBehavior="false" OnClick="btnClear1_Click" />
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="Label3" runat="server" Text="Recruiter" ToolTip="招聘人"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtRecruter" runat="server" CssClass="textbox" ReadOnly="true"></asp:TextBox>
                                <img runat="server" id="imgRecruiter"
                                    onclick='window.open("../Systems/Sys_SelectOne.aspx?ctrlname=txtRecruter",null,"height=400,width=400,status=no,top=200,left=400,toolbar=no,menubar=no,location=center")'
                                    src="../images/person1.gif" align="absMiddle" border="0" alt="Picture" />
                                <asp:Label ID="Label4" runat="server" Text="Application Date" ToolTip="申请日期"></asp:Label>:
                                <asp:TextBox ID="txtApplicationDate" runat="server" CssClass="textdate"></asp:TextBox>
                            </td>
                        </tr>
                        <tr bgcolor="">
                            <td bgcolor="" width="15%">
                                <div align="right">

                                    <asp:Label ID="lblSubject" runat="server" Text="Job Title" ToolTip="工 作 职 位"></asp:Label>:
                                </div>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtTitle" runat="server" Width="90%" CssClass="textbox"
                                    MaxLength="100"></asp:TextBox><br />

                            </td>
                        </tr>

                        <tr>
                            <td></td>
                            <td colspan="2">

                                <asp:Button ID="btnSave" runat="server" Text="Save" ToolTip="保 存" CssClass="btnNormal"
                                    OnClick="btnSave_Click" />
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ToolTip="提 交" CssClass="btnNormal" Visible="false" OnClick="btnSubmit_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="height: 200px; width: 48%; float: left">
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="95%" Height="190px"></asp:TextBox>
                </div>
                </div>
                <br />
                <div id="div_ATTACH" runat="server" visible="false" style="clear:both">
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
                    </table>
                </div>
        </fieldset>
         </div>
        <div style="width: 99.8%" id="div_CV" runat="server" visible="false">
            <fieldset>
                <legend>

                    <asp:Label ID="Label2" runat="server" Text="Recruitment CV Info" ToolTip="招聘简历信息"></asp:Label>:
                </legend>
                <table width="100%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed">
                    <tr bgcolor="#FFFFFF">
                        <td>

                            <%--                            <asp:RadioButtonList ID="rdoSites" runat="server">
                            </asp:RadioButtonList>--%>
                            <%--   <asp:ListBox ID="listSites" runat="server"></asp:ListBox>
                            <br />--%>
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
                            <asp:GridView ID="cvGrid" runat="server" Width="100%" AutoGenerateColumns="False" SkinID="GridView" OnRowDataBound="cvGrid_RowDataBound" OnRowCommand="cvGrid_RowCommand" OnRowEditing="cvGrid_RowEditing" OnRowUpdating="cvGrid_RowUpdating">
                                <Columns>
                                    <asp:BoundField DataField="cv_nbr" HeaderText="CV Number" ItemStyle-Width="5%" FooterText="简历编号">
                                        <ItemStyle Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cv_cre_by" HeaderText="CV Creater" ItemStyle-Width="3%"
                                        FooterText="简历创建者">
                                        <ItemStyle Width="3%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cv_cre_date" HeaderText="CV Create Date" ItemStyle-Width="5%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                                        FooterText="简历创建日期">
                                        <ItemStyle Width="5%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="cv_cre_date" HeaderText="CV" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}"
                                        FooterText="简历" ItemStyle-Wrap="true">
                                        <ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="form_seq" HeaderText="Seq" ItemStyle-Width="2%"
                                        FooterText="步骤">
                                        <ItemStyle Width="2%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="flow_status" HeaderText="Current Status" ItemStyle-Width="10%"
                                        FooterText="当前状态">
                                        <ItemStyle Width="10%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Operate" FooterText="操作">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnSubmit" runat="server" Text="Submit" ToolTip="提交" CommandArgument='<%# Eval("cv_nbr") %>' CommandName="Toggle"></asp:LinkButton>&nbsp;
                                        <asp:LinkButton ID="btnDelete" runat="server" Text="Delete" ToolTip="删除" CommandArgument='<%# Eval("attach_id") %>' CommandName="Del"></asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="5%"></ItemStyle>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
    </form>
</body>
</html>
