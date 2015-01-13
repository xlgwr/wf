<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UploadAttach.ascx.cs" Inherits="Workflow.UserControls.UploadAttach" %>
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
                    <input type="file" runat="server" class="fileUpload" size="50" id="FileUP" />
                    <asp:Button ID="btnAddAttach" runat="server" Text="Upload" ToolTip="上 传" CssClass="btnNormal" 
                        OnClick="btnAddAttach_Click" UseSubmitBehavior="false" />
<asp:Label ID="lblWarm" runat="server" 
    Text="Attachment file must less than 10M" ForeColor="Red" ToolTip="附近必须小于10兆"></asp:Label>
