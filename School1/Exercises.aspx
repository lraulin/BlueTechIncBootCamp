<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Exercises.aspx.cs" Inherits="School1.WebForm2"
  MaintainScrollPositionOnPostback="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Lesson 1 Exercises</title>
</head>
<style type="text/css">
  h1 {
    text-align: center;
  }

  td {
    align-content: center;
  }

  .center {
    text-align: center;
  }
</style>
<body>
  <form id="form1" runat="server">
    <div>
      <h1>Lesson 1 Exercises</h1>
      <asp:Label ID="lblResult" runat="server"></asp:Label>
    </div>
    <div>
      <h2>Exercise 1</h2>
      <table border="3" width="900px" align="center">
        <tr align="center" valign="top">
          <td>1</td>
          <td>2</td>
          <td>3</td>
        </tr>
        <tr align="center" valign="top">
          <td colspan="2">4</td>
          <td rowspan="2">5</td>
        </tr>
        <tr align="center" valign="top">
          <td colspan="2">6</td>
        </tr>
        <%-- <tr align="center" valign="top">
          <td>7</td>
          <td>8</td>
          <td>9</td>
        </tr>--%>
      </table>
      <h2>Exercise 2</h2>
      <table border="3" width="900px" align="center">
        <tr align="center" valign="top">
          <td>
            <asp:Label ID="lblEnterData" runat="server" Text="Enter Data" BackColor="Wheat" ForeColor="Navy"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtEnterData" runat="server" ToolTip="Enter Data Here"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btnEnterData" runat="server" Text="Button" BorderColor="Navy" OnClick="btnEnterData_Click" />
          </td>
        </tr>
        <tr align="center" valign="top">
          <td colspan="2">
            <asp:HyperLink ID="hypImaLink" runat="server">ImaLink</asp:HyperLink>
          </td>
          <td>
            <asp:Literal ID="lit1" runat="server"></asp:Literal>
          </td>
        </tr>
        <tr align="center" valign="top">
          <td colspan="3">
            <asp:Image ID="imgCat1" runat="server" ImageUrl="media/cat1.jpg" />
          </td>
        </tr>
      </table>
    </div>
    <div>
      <h2>Exercise 3</h2>
      <table>
        <tr>
          <td>
            <asp:Label ID="lblNameIf" runat="server" Text="Name"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtNameIf" runat="server" ToolTip="Enter Name"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btnNameIf" runat="server" Text="Submit" OnClick="btnNameIf_Click" />
          </td>
          <td>
            <asp:Label ID="lblNameIf_Output" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblNameSwitch" runat="server" Text="Name"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtNameSwitch" runat="server" ToolTip="Enter Name"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btnNameSwitch" runat="server" Text="Submit" OnClick="btnNameSwitch_Click" />
          </td>
          <td>
            <asp:Label ID="lblNameSwitch_Output" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lblNumIf" runat="server" Text="Number"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txtNumIf" runat="server" ToolTip="Enter Number"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btnNumIf" runat="server" Text="Submit" OnClick="btnNumIf_Click" />
          </td>
          <td>
            <asp:Label ID="lblNumIf_Output" runat="server"></asp:Label>
          </td>
          <tr>
            <td>
              <asp:Label ID="lblNumSwitch" runat="server" Text="Number"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txtNumSwitch" runat="server" ToolTip="Enter Number"></asp:TextBox>
            </td>
            <td>
              <asp:Button ID="btnNumSwitch" runat="server" Text="Submit" OnClick="btnNumSwitch_Click" />
            </td>
            <td>
              <asp:Label ID="lblNumSwitch_Output" runat="server"></asp:Label>
            </td>
          </tr>
        </tr>
      </table>
    </div>
    <div>
      <h2>Exercise 4: Display data from loops</h2>
      <div>
        <asp:Label ID="lbl4a" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4b" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4ci" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4cii" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4ciii_in" runat="server" Text="Enter Number"></asp:Label>
        <asp:TextBox ID="txt4ciii" runat="server"></asp:TextBox>
        <asp:Button ID="btn4ciii" runat="server" Text="Submit" OnClick="btn4ciii_Click" />
      </div>
      <div>
        <asp:Label ID="lbl4ciii_out" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4di" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4dii" runat="server"></asp:Label>
      </div>
      <div>
        <asp:Label ID="lbl4diii" runat="server"></asp:Label>
      </div>
    </div>
    <div>
      <h2>Exercise 5: Return Data from a Function</h2>
      <table>
        <tr>
          <td>
            <asp:Label ID="lbl5a" runat="server" Text="Number, String"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txt5aInt" runat="server" ToolTip="Enter an Integer"></asp:TextBox>
          </td>
          <td>
            <asp:TextBox ID="txt5aStr" runat="server" ToolTip="Enter a String"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btn5a" runat="server" Text="Submit" OnClick="btn5a_Click" />
          </td>
          <td>
            <asp:Label ID="lbl5aOut" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lbl5b" runat="server" Text="3 Integers"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txt5b1" runat="server" ToolTip="Enter an Integer"></asp:TextBox>
          </td>
          <td>
            <asp:TextBox ID="txt5b2" runat="server" ToolTip="Enter an Integer"></asp:TextBox>
          </td>
          <td>
            <asp:TextBox ID="txt5b3" runat="server" ToolTip="Enter an Integer"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btn5b" runat="server" Text="Submit" OnClick="btn5b_Click" />
          </td>
          <td>
            <asp:Label ID="lbl5bOut" runat="server"></asp:Label>
          </td>
        </tr>
        <tr>
          <td>
            <asp:Label ID="lbl5c" runat="server" Text="3 Decimals"></asp:Label>
          </td>
          <td>
            <asp:TextBox ID="txt5c1" runat="server" ToolTip="Enter Decimal Number"></asp:TextBox>
          </td>
          <td>
            <asp:TextBox ID="txt5c2" runat="server" ToolTip="Enter Decimal Number"></asp:TextBox>
          </td>
          <td>
            <asp:TextBox ID="txt5c3" runat="server" ToolTip="Enter Decimal Number"></asp:TextBox>
          </td>
          <td>
            <asp:Button ID="btn5c" runat="server" Text="Submit" OnClick="btn5c_Click" />
          </td>
          <td>
            <asp:Label ID="lbl5cOut" runat="server"></asp:Label>
          </td>
          <tr>
            <td>
              <asp:Label ID="lbl5d" runat="server" Text="Boolean, 2 Decimals"></asp:Label>
            </td>
            <td>
              <asp:TextBox ID="txt5dBool" runat="server" ToolTip="Enter T or F"></asp:TextBox>
            </td>
            <td>
              <asp:TextBox ID="txt5dDec1" runat="server" ToolTip="Enter a Decimal"></asp:TextBox>
            </td>
            <td>
              <asp:TextBox ID="txt5dDec2" runat="server" ToolTip="Enter a Decimal"></asp:TextBox>
            </td>
            <td>
              <asp:Button ID="btn5d" runat="server" Text="Submit" OnClick="btn5d_Click" />
            </td>
            <td>
              <asp:Label ID="lbl5dOut" runat="server"></asp:Label>
            </td>
          </tr>
        </tr>
      </table>
    </div>
    <div>
      <h2>Exercise 6: Redirect to a New Page using a Function</h2>
      <asp:Button ID="btn6" runat="server" Text="Click Me" OnClick="btn6_Click" />
      <asp:Label ID="lbl6" runat="server"></asp:Label>
    </div>
    <div>
      <h2>Exercise 7: Display Data from Page 1 on Page 1</h2>
      <asp:Button ID="btn7" runat="server" Text="Button" OnClick="btn7_Click" />
      <asp:Literal ID="lit7" runat="server"></asp:Literal>
      <asp:Label ID="lbl7" runat="server"></asp:Label>
    </div>
    <div>
      <h1>8: Display Data from Page 1 on Page 2</h1>
      <div class="center">
        <asp:HyperLink ID="hyp8" runat="server">--> Page 2 <--</asp:HyperLink>
      </div>
    </div>
    <br />
    <br />
    <br />
    <div>
      <asp:Image ID="Image1" runat="server" ImageUrl="media/cat2.jpeg" />
      <asp:Label ID="Label1" runat="server">Space filler so you can click the link.</asp:Label>
    </div>
  </form>
</body>
</html>
