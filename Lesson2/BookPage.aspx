﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookPage.aspx.cs" Inherits="Lesson2.BookPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Book Page</title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <asp:DataGrid ID="dgBooks" runat="server"></asp:DataGrid>
      <asp:Label ID="lblError" runat="server" />
      <h1>Test Results:</h1>
      <asp:Label ID="lblTest" runat="server" />
    </div>
  </form>
</body>
</html>
