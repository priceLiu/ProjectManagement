<%@ Page Language="C#" AutoEventWireup="true" enableEventValidation="False" CodeBehind="Default.aspx.cs" Inherits="bigFile._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script language="javascript">
		function showProgress()
		{
		        var ary = document.getElementsByTagName('INPUT');
				var openBar = false;
				for(var i=0;i<ary.length;i++)
				{
					var obj = ary[i];
					if(obj.type  == 'file')
					{
						if(obj.value != '')
						{
							openBar = true;
							break;
						}
					}
				}
				if(openBar)
				{
					window.showModelessDialog('ProgressBar.aspx?UploadID='+document.all.UploadID.value,window,'status:no;dialogWidth:500px;dialogHeight:250px;center:yes;help:no;');
				}
		}
		
		</script>
</head>
<body>
    <form id="form1" runat="server" method="Post">
	
				<asp:TextBox id="TextBox1" runat="server"></asp:TextBox>
				<asp:TextBox id="TextBox2" runat="server"></asp:TextBox><BR>
				<INPUT type="file" id="file1" name="file1" runat="server"><BR>
				<asp:Button id="Button1" runat="server" Text="开始上传" OnClick="Button1_Click"></asp:Button>
<script language="javascript" event="onclick" for="<% =Button1.ClientID %>">
showProgress();
</script>
    </form>
</body>
</html>
