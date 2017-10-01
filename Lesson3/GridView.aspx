<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridView.aspx.cs" Inherits="Lesson3.GridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container">
    <div class="my-jumbotron text-center">
      <h1>Grid View</h1>
    </div>
  </div>
  <div class="container-fluid">
    <div class="row">
      <div class="col-xs-3">
        <div class="calendar-box">
          <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" CssClass="calendar"></asp:Calendar>
        </div>
        <div class="well well-sm text-center">
          <asp:Label ID="lbl21a" runat="server"></asp:Label>
          <br />
          <asp:Label ID="lbl21b" runat="server"></asp:Label>
          <br />
          <asp:Label ID="lbl21c" runat="server"></asp:Label>
        </div>
      </div>
      <div class="col-xs-9">
        <asp:DataGrid ID="dgBooks" runat="server" AllowSorting="True" AutoGenerateColumns="False" CssClass="grid" CellPadding="4" ForeColor="#333333" GridLines="None">
          <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
          <Columns>
            <asp:BoundColumn DataField="BookID" SortExpression="BookID" HeaderText="Book ID" ItemStyle-HorizontalAlign="Center">
              <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="BookTitle" SortExpression="BookTitle" HeaderText="Book Title" />
            <asp:BoundColumn DataField="AuthorName" SortExpression="AuthorName" HeaderText="Author Name" />
            <asp:BoundColumn DataField="Length" SortExpression="Length" HeaderText="Length" ItemStyle-HorizontalAlign="Center">
              <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="IsOnAmazon" SortExpression="IsOnAmazon" HeaderText="On Amazon?" ItemStyle-HorizontalAlign="Center">
              <ItemStyle HorizontalAlign="Center"></ItemStyle>
            </asp:BoundColumn>
            <asp:BoundColumn DataField="DateCreated" SortExpression="DateCreated" HeaderText="Date Created" />
            <asp:BoundColumn DataField="Price" SortExpression="Price" HeaderText="Price" DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right">
              <ItemStyle HorizontalAlign="Right"></ItemStyle>
            </asp:BoundColumn>
            <asp:TemplateColumn>
              <ItemTemplate>
                <asp:CheckBox ID="chkSelection" runat="server" />
              </ItemTemplate>
            </asp:TemplateColumn>
          </Columns>
          <EditItemStyle BackColor="#999999" />
          <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
          <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
          <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
          <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        </asp:DataGrid>
        <div id="SearchBox">
          <asp:Button ID="btnRemoveSelected" runat="server" Text="Remove" OnClick="btnRemoveSelected_Click" />
          <asp:Label ID="lblTotalPrice" runat="server" Text="Total Price: "></asp:Label>
          <asp:Label ID="lblAveragePrice" runat="server" Text="Average Price: "></asp:Label>
        </div>
      </div>
    </div>
    <br />
    <br />
    <div class="row">
      <div class="col-xs-4">
        <asp:DropDownList ID="ddlBooks" runat="server" OnSelectedIndexChanged="ddlBooks_SelectedIndexChanged" AutoPostBack="true" Style="height: 27px"></asp:DropDownList>
      </div>
      <div class="col-xs-4 border">
        <asp:CheckBoxList ID="chkBooks" runat="server" OnSelectedIndexChanged="chkBooks_SelectedIndexChanged" AutoPostBack="true">
        </asp:CheckBoxList>
        <asp:Label ID="lblCheckBox" runat="server"></asp:Label>
        <br />
      </div>
      <div class="col-xs-4">
        <asp:RadioButtonList ID="rdoBooks" runat="server" OnSelectedIndexChanged="rdoBooks_SelectedIndexChanged" AutoPostBack="True">
        </asp:RadioButtonList>
        <asp:Label ID="lblRadio" runat="server"></asp:Label>
      </div>
    </div>
    <div class="row">
      <div class="col-xs-2">
        <asp:DropDownList ID="ddl2" runat="server" OnSelectedIndexChanged="ddl2_SelectedIndexChanged" AutoPostBack="true" Style="height: 27px"></asp:DropDownList>
        <div class="card">
          <asp:Label ID="lblDropDown2" runat="server"></asp:Label>
        </div>
      </div>
      <div class="col-xs-2">
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/media/tabletinykitten.jpg" runat="server" OnClick="ImageButton1_Click" />
        <asp:Label ID="lblImage" runat="server"></asp:Label>
      </div>
      <div class="col-xs-4">
        <asp:Label ID="lblSelection" runat="server"></asp:Label>
      </div>
    </div>
  </div>
</asp:Content>
