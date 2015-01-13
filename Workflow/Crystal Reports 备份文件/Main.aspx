<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Workflow.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function ViewHelper(Helper) {
            if (Helper == 'open') {
                document.getElementById('frmtitle').cols = "170,5,*";

            } else
                if (Helper == 'close') {
                    document.getElementById('frmtitle').cols = "1,5,*";
                }
        }
       
</script>
</head>
<frameset rows="70,*"   framespacing="0" style="width:100%; margin:auto;" frameborder="0">
<!--rows="140,*,25" 140是高度-->
  <frame src="Top.aspx" name="topFrame"  scrolling="No"  id="topFrame" title="topFrame"/>
  <frameset cols="171,4,*" framespacing="1" border="1" frameborder="0" id="frmtitle" style="border:1px solid #83B3D8;display:block">
    <frame src='Left.aspx' id="leftFrame" name="leftFrame" scrolling="yes"  title="leftFrame" style="border-right:1px solid #83B3D8;display:block" />
    <frame src='LeftBar.aspx' name="leftF" id="leftF" scrolling="no"  title="leftFrame" noresize="noresize"/>
    <frame src='Systems/Tasklist.aspx' name="main" id="main" title="main" style="border-left:1px solid #83B3D8;display:block" noresize="noresize"/>
  </frameset>
  <frame src="foot.aspx" scrolling="no">
  </frameset>
<noframes>

</html>
