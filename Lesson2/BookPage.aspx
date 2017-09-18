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
        <asp:TextBox ID="txtSearchID" runat="server" placeholder="Enter Book ID"  />
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
              <asp:TextBox ID="txtBookID" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblBookTitle" runat="server" Text="Book Title"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtBookTitle" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblAuthorName" runat="server" Text="Author Name"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtAuthorName" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblLength" runat="server" Text="Length"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtLength" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td>
              <asp:Label ID="lblIsOnAmazon" runat="server" Text="On Amazon?"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtIsOnAmazon" runat="server"></asp:TextBox>
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
      </div>
      <%--Testing Area--%>
      <br /><br /><br />
      <div>
      <asp:DataGrid ID="dgBooks" runat="server"></asp:DataGrid>
      <asp:Label ID="lblError" runat="server" />
      <h1>Test Results:</h1>
      <asp:Label ID="lblTest" runat="server" />
      </div>
    </div>
  </form>
</body>
</html>
