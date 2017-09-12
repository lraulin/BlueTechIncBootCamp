<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageThree.aspx.cs" Inherits="School2.PageThree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Page Three</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:DataGrid ID="dgUsers" runat="server" AutoGenerateColumns="false" AllowPaging="true"
        OnPageIndexChanged="dgUsers_PageIndexChanged" PagerStyle-Mode="NumericPages"
        AllowSorting="true" OnSortCommand="dgUsers_SortCommand">
        <Columns>
          <asp:BoundColumn DataField="UserID" SortExpression="UserID" HeaderText="UserID" />
          <asp:BoundColumn DataField="LastName" SortExpression="LastName" HeaderText="Last Name" />
          <asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="First Name" />
          <asp:TemplateColumn>
            <ItemTemplate>
              <asp:CheckBox ID="chkSelection" runat="server" />
            </ItemTemplate>
          </asp:TemplateColumn>
        </Columns>
      </asp:DataGrid>
      <asp:Button ID="btnGo" runat="server" Text="Go" OnClick="btnGo_Click" />
      <asp:Label ID="lblError" runat="server" />
    </div>
  </form>
</body>
</html>
