<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProgressBar.aspx.cs" Inherits="bigFile.ProgressBar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>已上传
			<%=Percentage%>
			% </title>
			
	<base target="_self">
		<style>
    BODY { FONT-SIZE: 9pt; MARGIN: 0px; OVERFLOW: hidden; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BACKGROUND-COLOR: buttonface; BORDER-BOTTOM-STYLE: none }
    TD { FONT-SIZE: 9pt; FONT-FAMILY: Arial }
		</style>
</head>
<body>
    <form id="Form1" method="post" runat="server">
			<table border="0"  cellpadding="10" width="100%" height="180px">
				<tr>
					<td align="center" valign="middle" height="100%">
						<table border="0" width="100%" height="100%">
							<tr>
								<td nowrap colspan="2" align="Left">上传状态:&nbsp;<b><asp:Label ID="txt_progressinfo" Runat="server" /></b></td>
							</tr>
							<tr>
								<td nowrap colspan="2" align="Left">正上传文件:&nbsp;<b><asp:Label ID="txt_filename" style="TEXT-OVERFLOW:ellipsis" Runat="server" /></b></td>
							</tr>
							<tr>
								<td width="<%=Percentage%>%" bgcolor="highlight">&nbsp;</td>
								<td width="<%=100-Percentage%>%">&nbsp;</td>
							</tr>
						
							<tr>
								<td nowrap colspan="2" align="Left">上传速度:&nbsp;<asp:Label ID="txt_speed" Runat="server" /></td>
							</tr>
							<tr>
								<td nowrap colspan="2" align="Left">估计剩计时间:&nbsp;<asp:Label ID="txt_leftTime" Runat="server" /></td>
							</tr>
							<tr>
							    <td align="right" colspan="2" nowrap><asp:Button ID="btn_ok" Text="确 定" Runat="server" Width="70" OnClick="btn_ok_Click" />&nbsp;&nbsp;<asp:Button ID="btn_cancle" Text="取 消" Runat="server" Width="70" OnClick="btn_cancle_Click" />&nbsp;&nbsp;&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
</body>
</html>
