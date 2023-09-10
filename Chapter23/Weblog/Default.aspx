<%@ Page language="c#" Codebehind="Default.aspx.cs" AutoEventWireup="false" Inherits="WebLog.CDefault" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript (ECMAScript)" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link rel="stylesheet" href="style.css">
	</HEAD>
	<body>
		<form id="Default" method="post" runat="server">
			<div class="header">
				Disraeli's Weblog
			</div>
			<br>
			<asp:DataList id="datalistEntries" runat="server">
				<ItemTemplate>
					<asp:Label id="Label1" runat="server" CssClass="entryTitle" Text='<%# DataBinder.Eval(Container, "DataItem.Title") %>'>
					</asp:Label>
					&nbsp;
					<asp:HyperLink id="HyperLink1" runat="server" CssClass="entry" NavigateUrl='<%# "edit.aspx?filename=" + DataBinder.Eval(Container, "DataItem.Filename") %>'>Edit</asp:HyperLink>
					<BR>
					<asp:Label id="Label2" runat="server" CssClass="entryDate" Text='<%# DataBinder.Eval(Container, "DataItem.TimestampAsString") %>'>
					</asp:Label>
					&nbsp;-
					<asp:Label id="Label3" runat="server" CssClass="entry" Text='<%# DataBinder.Eval(Container, "DataItem.Details") %>'>
					</asp:Label>
				</ItemTemplate>
			</asp:DataList>
			<br>
			<div class="normal">
				<a href="edit.aspx">Create a new entry</a>
			</div>
			<br>
			<hr color="#000000">
			<div class="normal">
				<asp:label id="labelCopyright" runat="server">(copyright)</asp:label>
			</div>
			<br>
			<div class="normal">
				<asp:Label id="labelServerPath" runat="server">(serverpath)</asp:Label>
			</div>
		</form>
	</body>
</HTML>
