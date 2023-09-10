<%@ Page language="c#" Codebehind="Edit.aspx.cs" AutoEventWireup="false" Inherits="WebLog.Edit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link rel="stylesheet" href="style.css">
	</HEAD>
	<body>
		<form id="Edit" method="post" runat="server">
			<div class="header">
				Disraeli's Weblog
			</div>
			<br>
			<div class="normalHeading">
				Create a New Entry
			</div>
			<br>
			<div class="normal">
				<table cellspacing="0" cellpadding="3">
					<tr>
						<td class="normal">
							Title:
						</td>
						<td>
							<asp:TextBox id="textTitle" runat="server" Width="313px" Height="24px"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ErrorMessage="Required" ControlToValidate="textTitle"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td class="normal" style="HEIGHT: 152px">
							Details:
						</td>
						<td style="HEIGHT: 152px">
							<asp:TextBox id="textDetails" runat="server" TextMode="MultiLine" Width="312px" Height="148px"></asp:TextBox>
							<asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" ErrorMessage="Required" ControlToValidate="textDetails"></asp:RequiredFieldValidator>
						</td>
					</tr>
					<tr>
						<td colspan="2" align="right">
							<asp:Button id="buttonOk" runat="server" Text="Save Changes"></asp:Button>
						</td>
					</tr>
				</table>
			</div>
		</form>
	</body>
</HTML>
