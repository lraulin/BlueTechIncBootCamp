﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageThree.aspx.cs" Inherits="School2.PageThree" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Three</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <asp:DataGrid ID="dgUsers" runat="server"></asp:DataGrid>
          <asp:Label ID="lblError" runat="server" />
        </div>
    </form>
</body>
</html>
