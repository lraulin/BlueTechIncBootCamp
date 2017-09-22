<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Page2WithMaster.aspx.cs" Inherits="School2.Page2WithMaster" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table>
    <tr>
      <td onclick="ShowBox('david')">
      Page 2
      </td>
    </tr>
  </table>
  <asp:HyperLink ID="hyp1" runat="server" NavigateUrl="~/Page1WithMaster.aspx">Page One</asp:HyperLink>
  <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
</asp:Content>
