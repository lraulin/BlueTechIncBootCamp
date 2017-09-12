<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageTwo.aspx.cs" Inherits="School2.PageTwo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Page Two</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <h1>Welcome to Page Two!</h1>
      Search: 
      <asp:TextBox ID="txtSearch" runat="server" />
      <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
      <asp:CheckBoxList ID="chkUsers" runat="server" /><br />
      <asp:RadioButtonList ID="rdUsers" runat="server" /><br />
      <asp:ListBox ID="lstUsers" runat="server" SelectionMode="Multiple" /><br />
      <asp:DropDownList ID="drdUsers" runat="server" /><br />
      <asp:Label ID="lblResult" runat="server" />
    </div>
  </form>
</body>
</html>
