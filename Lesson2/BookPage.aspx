<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="Lesson2.BookPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Book Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <div id="SearchBox">
        <asp:TextBox ID="txtSearchID" runat="server" placeholder="Enter Book ID" />
        <asp:Button ID="btnSearchID" runat="server" Text="Search ID" OnClick="btnSearchID_Click" />
        <br />
        <asp:Label ID="lblSearch" runat="server" Text="Searching for..."></asp:Label>
      </div>
      <div id="Data">
        <table>
          <tr>
            <td>
              <asp:Label ID="lblBookID" runat="server" Text="Book ID"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtBookID" runat="server" ToolTip="Enter 0 to insert new record"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblBookTitle" runat="server" Text="Book Title"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtBookTitle" runat="server" ToolTip="Enter Book Title"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblAuthorName" runat="server" Text="Author Name"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtAuthorName" runat="server" ToolTip="Enter Author Name"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblLength" runat="server" Text="Length"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtLength" runat="server" ToolTip="Enter Number of Pages"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblIsOnAmazon" runat="server" Text="On Amazon?"></asp:Label>
            </td>
            <td>
<%--              <asp:TextBox ID="txtIsOnAmazon" runat="server"></asp:TextBox>--%>
              <asp:DropDownList ID="drdIsOnAmazon" runat="server" Width="152px">
                <asp:ListItem Text="" />
                <asp:ListItem Text="True" />
                <asp:ListItem Text="False" />
              </asp:DropDownList>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblDateCreated" runat="server" Text="Date Created"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtDateCreated" ReadOnly="true" runat="server"></asp:TextBox>
            </td>
          </tr>
        </table>
      </div>
      <div>
        <asp:Button ID="btnSaveRecord" runat="server" Text="Save Record" OnClick="btnSaveRecord_Click" />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:HyperLink ID="hypBooksGrid" runat="server" Text="Books Database" NavigateUrl="~/BooksGrid.aspx">HyperLink</asp:HyperLink>
      </div>
    </div>
  </form>
</body>
</html>
