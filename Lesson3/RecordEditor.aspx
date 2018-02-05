<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordEditor.aspx.cs" Inherits="Lesson3.RecordEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="jumbotron text-center">
      <h1>&nbsp;&nbsp;&nbsp;&nbsp; Record View</h1>
      <p>Add new record, or select existing record to view or edit.</p>
    </div>
  </div>
  <div id="divData">
    <asp:DropDownList ID="ddlBookEditor" runat="server" OnSelectedIndexChanged="ddlBookEditor_SelectedIndexChanged" AutoPostBack="true" Style="height: 27px"></asp:DropDownList>
    <asp:Button ID="btnNewRecord" runat="server" Text="New Record" ToolTip="Click to enter a new record" OnClick="btnNewRecord_Click" />
    <table>
      <tr>
        <td>
          <asp:Label ID="lblBookID" runat="server" Text="Book ID"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtBookID" runat="server" ReadOnly="true" Text="New Record" Width="200px" CssClass="recordbox"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblBookTitle" runat="server" Text="Book Title"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtBookTitle" runat="server" Placeholder="Enter Book Title" Width="200px" CssClass="recordbox"></asp:TextBox>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="rfvBookTitle" runat="server" ControlToValidate="txtBookTitle" ErrorMessage="Please enter a book title" CssClass="warning"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblAuthorName" runat="server" Text="Author Name"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtAuthorName" runat="server" Placeholder="Enter Author Name" Width="200px" CssClass="recordbox"></asp:TextBox>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="rvfAuthorName" runat="server" ControlToValidate="txtAuthorName" ErrorMessage="Please enter the author's name" CssClass="warning"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblLength" runat="server" Text="Length"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtLength" runat="server" Placeholder="0" Width="200px" CssClass="recordbox"></asp:TextBox>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="rfvLength" runat="server" ControlToValidate="txtLength" ErrorMessage="Enter the number of pages in the book" CssClass="warning"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="rgxLength" runat="server" ControlToValidate="txtLength" ErrorMessage="Invalid input. Enter a positive integer no greater than 1,000,000" ValidationExpression="^([0-9],?)+$" CssClass="warning"></asp:RegularExpressionValidator>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblIsOnAmazon" runat="server" Text="On Amazon?"></asp:Label>
        </td>
        <td>
          <asp:DropDownList ID="drdIsOnAmazon" runat="server" Width="200px">
            <asp:ListItem Text="" />
            <asp:ListItem Text="True" />
            <asp:ListItem Text="False" />
          </asp:DropDownList>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="rfvIsOnAmazon" runat="server" ControlToValidate="drdIsOnAmazon" ErrorMessage="Please select 'true' or 'false'." CssClass="warning"></asp:RequiredFieldValidator>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtPrice" runat="server" Placeholder="$0.00" Width="200px" CssClass="recordbox"></asp:TextBox>
        </td>
        <td>
          <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Enter the book's price in USD" CssClass="warning"></asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="rgxPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price is not valid. Please enter an amount between $0.00 and $1,000,000.00" ValidationExpression="(?=.)^\$?(([1-9][0-9]{0,2}(,[0-9]{3})*)|[0-9]+)?(\.[0-9]{1,2})?$" CssClass="warning"></asp:RegularExpressionValidator>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblDateCreated" runat="server" Text="Date Created"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtDateCreated" ReadOnly="true" runat="server" Text="Current Time" CssClass="recordbox" Width="200px"></asp:TextBox>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Button ID="btnSaveRecord" runat="server" Text="Save Record" OnClick="btnSaveRecord_Click" />
        </td>
      </tr>
    </table>
    <asp:Label ID="lblRecordEditor" CssClass="message" runat="server"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="btnDelete" runat="server" Text="Delete Record" CssClass="btn btn-warning" OnClick="btnDelete_Click" />
  </div>
</asp:Content>
