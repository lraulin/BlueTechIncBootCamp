<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecordEditor.aspx.cs" Inherits="Lesson3.RecordEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="my-jumbotron text-center">
      <h1>Record View</h1>
    </div>
  </div>
  <div id="divData">
    <asp:Button ID="btnNewRecord" runat="server" Text="New Record" ToolTip="Click to enter a new record" OnClick="btnNewRecord_Click" />
    <table>
      <tr>
        <td>
          <asp:Label ID="lblBookID" runat="server" Text="Book ID"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtBookID" runat="server" ToolTip="Enter 0 to insert new record" ReadOnly="True"></asp:TextBox>
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
          <asp:DropDownList ID="drdIsOnAmazon" runat="server" Width="152px">
            <asp:ListItem Text="" />
            <asp:ListItem Text="True" />
            <asp:ListItem Text="False" />
          </asp:DropDownList>
        </td>
      </tr>
      <tr>
        <td>
          <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        </td>
        <td>
          <asp:TextBox ID="txtPrice" runat="server" ToolTip="Enter price in USD as a decimal number"></asp:TextBox>
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
      <tr>
        <td>
          <asp:DropDownList ID="ddlBookEditor" runat="server" OnSelectedIndexChanged="ddlBookEditor_SelectedIndexChanged" AutoPostBack="true" Style="height: 27px"></asp:DropDownList>
        </td>
        <td>
          <asp:Button ID="btnSaveRecord" runat="server" Text="Save Record" OnClick="btnSaveRecord_Click" />
        </td>
      </tr>
    </table>
    <asp:Label ID="lblRecordEditor" runat="server"></asp:Label>
  </div>


</asp:Content>
