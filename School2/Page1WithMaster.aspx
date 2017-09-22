<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Page1WithMaster.aspx.cs" Inherits="School2.Page1WithMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  Page content
  <asp:Button ID="btnTest" runat="server" Text="Button" />
  <asp:HyperLink ID="hyp1" runat="server" NavigateUrl="~/Page2WithMaster.aspx">Page Two</asp:HyperLink>
  <table>
    <tr>
      <td>
        <div id="div1" onclick="ShowBox('1')">
          <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>
          <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label>
          Howdy
        </div>
      </td>
    </tr>
  </table>
</asp:Content>
