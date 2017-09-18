<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BooksGrid.aspx.cs" Inherits="Lesson2.BooksGrid" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Books</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:DataGrid ID="dgBooks" runat="server" AllowSorting="true" AutoGenerateColumns="false">
        <Columns>
          <asp:BoundColumn DataField="BookID" SortExpression="BookID" HeaderText="Book ID" />
          <asp:BoundColumn DataField="BookTitle" SortExpression="BookTitle" HeaderText="Book Title" />
          <asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="Author Name" />
          <asp:BoundColumn DataField="Length" SortExpression="Length" HeaderText="Length" />
          <asp:BoundColumn DataField="IsOnAmazon" SortExpression="IsOnAmazon" HeaderText="On Amazon?" />
          <asp:BoundColumn DataField="DateCreated" SortExpression="DateCreated" HeaderText="Date Created" />
          <asp:BoundColumn DataField="Price" SortExpression="Price" HeaderText="Price" DataFormatString="{0:c}" />
        </Columns>
      </asp:DataGrid>
      <div id="SearchBox">
        <asp:TextBox ID="txtTitleSearch" runat="server" placeholder="Search by Title" />
        <asp:Button ID="btnTitleSearch" runat="server" Text="Go" OnClick="btnTitleSearch_Click" />
        <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price: "></asp:Label>
        <asp:Label ID="lblAveragePrice" runat="server" Text="Average Price: "></asp:Label>
      </div>
      <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
  </form>
</body>
</html>
