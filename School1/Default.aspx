<%@ Page AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="School1.WebForm1" Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
</head>
<body>
  <form id="form1" runat="server">
    <div>
      <table width="900px" border="1" align="center">
        <tr>
          <td>
            <asp:Label ID="lblFirstName" runat="server" Text="First Name" ToolTip="Enter First Name"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblLastName" runat="server" Text="Last Name" ToolTip="Enter Last Name"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
          </td>
        </tr>
        <tr>
          <td colspan="2">
            <asp:Button ID="btnCombine" runat="server" Text="Combine" OnClick="btnCombine_Click" />
            <br />
            <asp:Label ID="lblResult" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
          </td>
          <td>
            <asp:Panel ID="pnl1" runat="server">
              <asp:HyperLink ID="hyp1" runat="server" >To Page Two</asp:HyperLink><br />
              <asp:HyperLink ID="hyp2" runat="server" Text="To Page Two v2" /><br />
              <asp:Literal ID="lit1" runat="server" Text="<b>Hello</b>" />
            </asp:Panel>
          </td>
        </tr>
      </table>
      <br />
      <br />
    </div>
  </form>
</body>
</html>
