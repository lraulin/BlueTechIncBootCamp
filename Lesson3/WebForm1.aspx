<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lesson3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
</head>
<body>
  <form id="form1" runat="server">
    <div class="container">
      <div class="jumbotron">
        <h1>Lesson 3</h1>
      </div>
    </div>
    <div class="container">
      <div class="row">
        <div class="col-md-12 align-content-center">
          <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>
          <div class="card card-inverse card-primary mb-3 text-center">
            <div class="card-block">
              <div class="card-blockquote">
                <asp:Label ID="lbl21a" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lbl21b" runat="server"></asp:Label>
                <br />
                <asp:Label ID="lbl21c" runat="server"></asp:Label>
              </div>
            </div>
          </div>
        </div>
      </div>
      
      <div class="row">

        <div class="col-md-4">
          <asp:DropDownList ID="ddlBooks" runat="server" OnSelectedIndexChanged="ddlBooks_SelectedIndexChanged" AutoPostBack="true" Style="height: 27px"></asp:DropDownList>
          <div class="card">
            <asp:Label ID="lblDropDown" runat="server" Text="Label"></asp:Label>
          </div>
        </div>

        <div class="col-md-4 border">
          <asp:CheckBoxList ID="lstBooks" runat="server" OnSelectedIndexChanged="lstBooks_SelectedIndexChanged" AutoPostBack="true">
          </asp:CheckBoxList>
          <asp:Label ID="lblCheckBox" runat="server" Text="Label"></asp:Label>
          <br />
        </div>

        <div class="col-md-4">
          <asp:RadioButtonList ID="rdoBooks" runat="server" OnSelectedIndexChanged="rdoBooks_SelectedIndexChanged" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="BookTitle" DataValueField="BookTitle">
          </asp:RadioButtonList>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Lesson2ConnectionString %>" SelectCommand="SELECT [BookTitle] FROM [tblBooks]"></asp:SqlDataSource>
          <asp:Label ID="lblRadio" runat="server" Text="Label"></asp:Label>
        </div>

      </div>

      <div class="row">

        <div class="col-md-4">
          <asp:DropDownList ID="ddl2" runat="server" OnSelectedIndexChanged="ddl2_SelectedIndexChanged" AutoPostBack="true" Style="height: 27px"></asp:DropDownList>
          <div class="card">
            <asp:Label ID="lblDropDown2" runat="server"></asp:Label>
          </div>
        </div>

        <div class="col-md-4">
          <asp:ImageButton ID="ImageButton1" ImageUrl="~/media/tabletinykitten.jpg" runat="server" />
          <asp:Label ID="lblImage" runat="server" Text="Label"></asp:Label>
        </div>

      </div>
      <div>
        <asp:TextBox ID="txtTest" runat="server" />
        <asp:RequiredFieldValidator ID="rfvTest" runat="server" ErrorMessage="Name is missing" ControlToValidate="txtTest"></asp:RequiredFieldValidator>
        <asp:Button ID="btnGo" runat="server" Text="Go" />
      </div>
    </div>
  </form>
</body>
</html>
