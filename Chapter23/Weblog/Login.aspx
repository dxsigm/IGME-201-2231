<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="WebLog.Login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta name="GENERATOR" Content="Microsoft Visual Studio 7.0">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript (ECMAScript)">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Login" method="post" runat="server">
			<asp:TextBox id="textPassword" runat="server" TextMode="Password"></asp:TextBox>
			<asp:Button id="Button1" runat="server" Text="Login"></asp:Button>
		</form>
	</body>
</HTML>
