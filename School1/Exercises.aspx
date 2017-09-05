<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exercises.aspx.cs" Inherits="School1.Exercises"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <table>
            <tr>
              <td>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
              </td>
              <td>
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
              </td>
            </tr>
            <tr>
              <asp:Button ID="Button1" runat="server" Text="Button" />
            </tr>
          </table>
        </div>
    </form>
</body>
</html>
