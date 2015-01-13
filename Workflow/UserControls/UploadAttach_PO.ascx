<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadAttach_PO.ascx.cs" Inherits="Workflow.UserControls.UploadAttach_PO" %>
<script type="text/javascript" language="javascript">
    function upload() {
        var filename = $("#FileUP").val();
        alert(filename);
        if (filename == "") {
            return;
        }
        getFileSize();
        if (getFileSize == false) {
            alert("123123");
        }
    }
    function getFileSize() {
        $.ajax({
            type: "post",
            url: "PO_Approval.aspx/getFileSize",
            data: "{\"strProj\":\"" + 1 + "\"}",
            contentType: "application/json;_charset=utf-8",
            dataType: "json",
            success: function (result) {
                var jsondata = eval(result.d);
                //                    if (jsondata[0].msg == "no records") {
                //                        alert("WorkHours Table is" + jsondata[0].msg);
                //                        return false;
                //                    }
                //todo upload
            }
            //,
            //                error: function (XMLHttpRequest, textStatus, errorThrown) { alert(errorThrown); },
            //                complete: function () {
            //                    //                getIsFreeze(maxdate, category, Proj_Status, Res_ID);
            //                }
        });
    }
</script>
<script src="../Scripts/Common.js" type="text/javascript"></script>
<asp:GridView ID="attachGrid" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="false"
                        OnRowDataBound="attachGrid_RowDataBound" OnRowDeleting="attachGrid_RowDeleting">
                        <EmptyDataTemplate>
                            <div class="emptydatatemplate">
                                <asp:Label ID="lblNoData" runat="server" Text="No Attachment" ToolTip="没有数据"></asp:Label>
                            </div>
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:CommandField HeaderText="Operate" ShowDeleteButton="True" ShowHeader="True"
                                FooterText="操 作" ItemStyle-Width="10%" />
                            <asp:BoundField DataField="attach_title" HeaderText="FileName" ItemStyle-Width="60%"
                                FooterText="文件名称">
                            </asp:BoundField>
                             <asp:BoundField DataField="attach_user" HeaderText="Creater" ItemStyle-Width="10%"
                                FooterText="上传人">
                            </asp:BoundField>
                                                         <asp:BoundField DataField="attach_time" HeaderText="Create Time" ItemStyle-Width="20%"
                                FooterText="创建时间"  DataFormatString="{0:MM/dd/yyyy HH:mm}">
                            </asp:BoundField>
                        </Columns>
                    </asp:GridView>
<asp:Label ID="lblUpload" runat="server" Text="Select" ToolTip="选 择"></asp:Label>：<br />
                    <input type="file" runat="server" class="fileUpload" size="50" id="FileUP" /><asp:Button 
    ID="btnAddAttach" runat="server" Text="Upload" CssClass="btnNormal" onclick="btnAddAttach_Click" ToolTip="上传" 
     UseSubmitBehavior="false" />
&nbsp;
<asp:Label ID="lblWarm" runat="server" 
    Text="Attachment file must less than 10M" ForeColor="Red" ToolTip="附件必须小于10兆"></asp:Label>
