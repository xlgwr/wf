<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_WorkEntrust.aspx.cs"
    Inherits="Workflow.Systems.Sys_WorkEntrust"  Theme="GridView"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Work Entrust / 工作委托</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
    <script src="../Scripts/Common.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
        function chkTypeClick() {
            if ($("#chkAllType").prop("checked") == true) {
                $("#drpFlowList").attr("disabled", "disabled");
              
                
            }
            else {
                $("#drpFlowList").removeAttr("disabled");
            }

        }
        function chkTimeClick() {
            if ($("#chkAllTime").prop("checked") == true) {
                $("#txtBeginDate").attr("disabled", "disabled");
                $("#txtEndDate").attr("disabled", "disabled");
            }
            else {
                $("#txtBeginDate").removeAttr("disabled");
                $("#txtEndDate").removeAttr("disabled");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="subHeader">
        <div>
            <asp:Label ID="lblTitle" runat="server" Text="Work Entrust" ToolTip="工 作 委 托"></asp:Label>
        </div>
    </div>
    <div style="width: 100%" align="center">
        <div class="caption_head" style="width: 60%">
            <asp:Label ID="Label1" runat="server" Text="Add Entrust" ToolTip="增加代理"></asp:Label>:
        </div>
        <table width="60%" border="0" cellpadding="3" cellspacing="1" bgcolor="3A66AD" style="table-layout: fixed;">
            <tr bgcolor="#FFFFFF">
                <td width="20%" bgcolor="EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblFlow" runat="server" Text="Choose Flow" ToolTip="选 择 流 程"></asp:Label>:</div>
                </td>
                <td width="80%">
                    <div align="left">
                        <asp:DropDownList ID="drpFlowList" runat="server" Width="300px">
                        </asp:DropDownList>
                        <asp:CheckBox ID="chkAllType" runat="server" Text="Choose All" ToolTip="选择全部流程" onclick="chkTypeClick()" />
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblMan" runat="server" Text="Mandatary" ToolTip="被委托人"></asp:Label>:
                    </div>
                </td>
                <td>
                    <div align="left">
                        <asp:TextBox ID="txtMan" runat="server" CssClass="textbox"></asp:TextBox>
                        <asp:Button ID="btnChoose" runat="server" Text="Choose" ToolTip="选择" CssClass="btnNormal" />&nbsp;
                        <asp:Button ID="btnClear" runat="server" Text="Clear" ToolTip="清除" CssClass="btnNormal" />
                    </div>
                </td>
            </tr>
            <tr bgcolor="#FFFFFF">
                <td bgcolor="#EAF2F9">
                    <div align="right">
                        <asp:Label ID="lblValidity" runat="server" Text="Validity" ToolTip="有效期"></asp:Label>:</div>
                </td>
                <td>
                    <div align="left">
                        <asp:Label ID="lblBegin" runat="server" Text="Begin Date" ToolTip="开始日期" Width="80px"
                            Style="text-align: right"></asp:Label>：
                        <asp:TextBox ID="txtBeginDate" runat="server" CssClass="textdate"></asp:TextBox><br />
                        <asp:Label ID="lblEnd" runat="server" Text="End Date" ToolTip="终止日期" Width="80px"
                            Style="text-align: right"></asp:Label>：
                        <asp:TextBox ID="txtEndDate" runat="server" CssClass="textdate"></asp:TextBox>
                        <asp:CheckBox ID="chkAllTime" runat="server" Text="All the time" ToolTip="一直有效" onclick="chkTimeClick()" />
                    </div>
                </td>
            </tr>
            <tr bgcolor="#EAF2F9">
                <td colspan="2">
                    <div align="center">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" ToolTip="添 加" 
                            CssClass="btnNormal" onclick="btnAdd_Click" />
                    </div>
                </td>
            </tr>
        </table>
        <table cellspacing="1" cellpadding="3" width="100%" align="center" border="0" bgcolor="3A66AD">
        </table>
        <div class="caption_head" style="width: 60%">
            <asp:Label ID="lblWork" runat="server" Text="My Work Entrust" ToolTip="我的工作委托"></asp:Label>:
        </div>
        <asp:GridView ID="gridMstr" runat="server" SkinID="GridView" Width="60%">
        <Columns>
            <asp:BoundField  DataField="entrust_type" HeaderText="Type" ItemStyle-Width="10%" />
            <asp:BoundField  DataField="entrust_by" HeaderText="Mandator" ItemStyle-Width="10%" />
            <asp:BoundField  DataField="entrust_to" HeaderText="Type" ItemStyle-Width="10%"/>
            <asp:BoundField  DataField="entrust_begin" HeaderText="Begin Date" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH}" />
            <asp:BoundField  DataField="entrust_end" HeaderText="End Date" ItemStyle-Width="10%" DataFormatString="{0:MM/dd/yyyy HH}" />
         </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
