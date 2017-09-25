<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lesson3.WebForm1" %>

<!DOCTYPE html>

<html>
<head runat="server">
  <title></title>
  <!-- Latest compiled and minified CSS -->
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css" integrity="sha384-/Y6pD6FV/Vv2HJnA6t+vslU6fwYXjCFtcEpHbNJ0lyAFsXTsjBbfaDjzALeQsN6M" crossorigin="anonymous">
  <!-- Required meta tags -->
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link href="css/StyleSheet1.css" rel="stylesheet" />
</head>
<body>
  <form id="form1" runat="server">
    <div class="container">
      <div class="jumbotron text-center">
        <h1>Lesson 3</h1>
      </div>
    </div>
    <div class="container">
      <div class="row">
        <div class="col-md-12 calendar">
          <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender"></asp:Calendar>
          <div class="well text-center">
            <asp:Label ID="lbl21a" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl21b" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lbl21c" runat="server"></asp:Label>
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
          <asp:CheckBoxList ID="chkBooks" runat="server" OnSelectedIndexChanged="chkBooks_SelectedIndexChanged" AutoPostBack="true">
          </asp:CheckBoxList>
          <asp:Label ID="lblCheckBox" runat="server" Text="Label"></asp:Label>
          <br />
        </div>

        <div class="col-md-4">
          <asp:RadioButtonList ID="rdoBooks" runat="server" OnSelectedIndexChanged="rdoBooks_SelectedIndexChanged" AutoPostBack="True">
          </asp:RadioButtonList>
          <asp:Label ID="lblRadio" runat="server"></asp:Label>
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
      <div id="container">
            <asp:Label ID="lblSelection" runat="server"></asp:Label>
      </div>
  </form>
  <!-- Optional JavaScript -->
  <!-- jQuery first, then Popper.js, then Bootstrap JS -->
  <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js" integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4" crossorigin="anonymous"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js" integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1" crossorigin="anonymous"></script>
</body>
</html>
