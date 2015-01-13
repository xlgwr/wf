<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sys_SelectUser.aspx.cs"
    Inherits="Workflow.Systems.Sys_SelectUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Select User / 选择用户</title>
    <link href="../Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/jquery-ui-1.10.3.custom.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="../Scripts/jquery-ui-1.10.3.custom.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
    <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
            <asp:UpdatePanel
            ID="UpdatePanel1" runat="server">
       <ContentTemplate>
    <div>
        <asp:Label ID="lblCompany" runat="server" Text="Company Code" ToolTip="公司代码"></asp:Label>：
 
        <asp:DropDownList ID="dropCompany" runat="server" AutoPostBack="true" 
            onselectedindexchanged="dropCompany_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
     <div style="float: left">
        <asp:Label ID="lblDept" runat="server" Width="105px" Text="Department" ToolTip="请从列表中选取"></asp:Label><br />
        <asp:ListBox ID="listDept" runat="server" Width="100px" Height="208px" 
             onselectedindexchanged="listDept_SelectedIndexChanged" AutoPostBack="true"></asp:ListBox>
    </div>
    <div style="float: left">
        <asp:Label ID="lblSelectList" runat="server" ToolTip="请从列表中选取" Width="205px">Please select from the list</asp:Label><br />
        <asp:ListBox ID="ListBox1" runat="server" Width="200px" Height="208px"></asp:ListBox>
    </div>
              </ContentTemplate>
     </asp:UpdatePanel>
    <div>
        <asp:Label ID="lblSelected" runat="server" ToolTip="已选中">Your selection</asp:Label><br />

        <asp:ListBox ID="lstselect" runat="server" Width="184px" Height="208px"></asp:ListBox>
      
        
    </div>
    <div style="text-align:center">
    <input id="btnaddall" type="button" value="AddAll" name="btnaddall" class="btnHTML">&nbsp;<input id="btnaddone"
        type="button" value="AddOne" name="btnaddone" class="btnHTML">&nbsp;<input id="btndel" type="button" value="DeleteOne"
            name="btndel" class="btnHTML">&nbsp;<input id="btnconfirm" type="button" value="Confirm" name="btnconfirm" class="btnHTML">
   &nbsp; <input id="txtctrlname" style="z-index: 111; left: 72px; width: 112px; position: absolute;
        top: 352px; height: 24px" type="hidden" size="13" name="txtctrlname" value="<%=ctrlname%>">
    &nbsp;<input id="txtSelectuser" name="txtSelectuser" type="hidden" size="13" value="<%=selectuser%>">
    </div>
    </form>
</body>
<script language="vbscript" type="text/vbscript">
		<!--
		 
		 
		  sub SetSeletedUser()
		   dim parvalue
		   dim i
		   dim j
		   dim selected



		   dim ctrname
		   ctrname=form1.txtctrlname.value 
		   if trim(ctrname) <> "" then
		       execute "parvalue=opener.document.all." + trim(ctrname) + ".value"
		   else
		       parvalue = ""
		   end if
		   
		   if trim(form1.txtselectuser.value) <>  "" then
		       parvalue = form1.txtselectuser.value 
		   end if
              
              
              
		   if trim(parvalue) <> "" then
			selected = split(parvalue,";")
			   
			for i = 0 to ubound(selected)
				set oOption = document.createElement("OPTION")
					form1.lstselect.options.add(oOption)
					oOption.innerText = selected(i)
					oOption.value = selected(i)
			next 
		   end if
		   
		  end sub
		  
		  sub btnaddone_OnClick()
		     dim sIndex
		     dim sValue 
		     
		     if not isnull(form1.listbox1.selectedIndex) then
		         sindex = form1.listbox1.selectedindex
		         if sindex >= 0 then
		            svalue = form1.listbox1.options(sindex).value
                    AddValueToList(svalue)
		         end if   
		    end if 
		    GetSelectUser
		  end sub
		  
		  sub btndel_OnClick()
		     dim sIndex
		     if not isnull(form1.lstselect.selectedIndex) then
		         sindex = form1.lstselect.selectedindex
		         if sindex >= 0 then 
                     form1.lstselect.options.remove(sIndex)
                 end if
		    end if 
            GetSelectUser
		  end sub		  
		  
		  sub btnaddAll_OnClick()
             dim i
             dim svalue 
             for i = 0 to form1.listbox1.options.length -1
                svalue = form1.listbox1.options(i).value
                AddValueToList(svalue)
             next
             GetSelectUser
		  end sub	
		  
         sub AddValueToList(byval strValue)
             dim i
             dim lcon
             lcon = "T"
             for i = 0 to form1.lstselect.options.length - 1
                 if ucase(trim(strvalue)) = ucase(trim(ucase(form1.lstselect.options(i).value))) then
                    lcon=""
                 end if   
             next      
             if lcon = "T" then
				    set oOption = document.createElement("OPTION")
					form1.lstselect.options.add(oOption)
					oOption.innerText = strvalue
					oOption.value = strvalue             
             end if  
         end sub
	
	     sub GetSelectUser()
		    dim i
		    dim selectvalue
		    selectvalue = ""
		    for i = 0 to form1.lstselect.options.length - 1
		       selectvalue = selectvalue & trim(form1.lstselect.options(i).value) & ";"
		    next
		    selectvalue = trim(selectvalue)
		    if len(selectvalue) > 0 then
		       selectvalue = left(selectvalue,len(selectvalue) - 1)
		    end if
	        form1.txtSelectuser.value = selectvalue
	     end sub
		 
		 sub btnconfirm_OnClick()
		    dim i
		    dim selectvalue
		    selectvalue = ""
		    for i = 0 to form1.lstselect.options.length - 1
		       selectvalue = selectvalue & trim(form1.lstselect.options(i).value) & ";"
		    next
		    selectvalue = trim(selectvalue)
		    if len(selectvalue) > 0 then
		       selectvalue = left(selectvalue,len(selectvalue) - 1)
		    end if
		   dim ctrname
		   ctrname=form1.txtctrlname.value 
		   if trim(ctrname) <> "" then
		       execute "opener.document.all." + trim(ctrname) + ".value=""" & selectvalue & """"
		   end if
		       
		    window.close 
		 end sub 
		-->
</script>
<script language="vbscript" type="text/vbscript">
	<!-- 
	   call SetSeletedUser()
	   -->
</script>
</html>
