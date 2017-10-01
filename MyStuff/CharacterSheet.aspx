<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CharacterSheet.aspx.cs" Inherits="MyStuff.CharacterSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <asp:DropDownList ID="ddlRollMethod" runat="server">
    <asp:ListItem Text="Standard" Value="0" Selected="True"></asp:ListItem>
    <asp:ListItem Text="Classic" Value="1"></asp:ListItem>
    <asp:ListItem Text="Heroic" Value="2"></asp:ListItem>
  </asp:DropDownList>
  <asp:Label ID="lblCharacterName" runat="server" Text="Name"></asp:Label>
  <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
  <table>
    <tr>
      <td>
        <asp:Label ID="lblStr" runat="server" Text="Strength:"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtStr" runat="server" ToolTip="Strength measures your character’s muscle and physical power. This ability is especially 
          important for Fighters, barbarians, paladins, rangers, and monks because it helps them prevail in combat. Strength also limits the amount of equipment 
          your character can carry."
          Width="52px"></asp:TextBox>
      </td>
      <td>
        <asp:Label ID="lblStrDetails" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblDex" runat="server" Text="Dexterity:"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtDex" runat="server" ToolTip="Dexterity measures hand-eye coordination, agility, reflexes, and balance. This ability 
        is the most important one for rogues, but it’s also high on the list for characters who typically wear light or medium armor (rangers 
        and barbarians) or no armor at all (monks, wizards, and sorcerers), and for anyone who wants to be a skilled archer."
          Width="52px"></asp:TextBox>
      </td>
      <td>
        <asp:Label ID="lblDexDetails" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblCon" runat="server" Text="Constitution:"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtCon" runat="server" ToolTip="Constitution represents your character’s health and stamina. A Constitution bonus 
          increases a character’s hit points, so the ability is important for all classes."
          Width="52px"></asp:TextBox>
      </td>
      <td>
        <asp:Label ID="lblConDetails" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblInt" runat="server" Text="Intelligence:"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtInt" runat="server" ToolTip="Intelligence determines how well your character learns and reasons. This ability 
        is important for wizards because it affects how many spells they can cast, how hard their spells are to resist, and how powerful 
        their spells can be. It’s also important for any character who wants to have a wide assortment of skills."
          Width="52px"></asp:TextBox>
      </td>
      <td>
        <asp:Label ID="lblIntDetails" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblWis" runat="server" Text="Wisdom:"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtWis" runat="server" ToolTip="Wisdom describes a character’s willpower, common sense, perception, and intuition. 
          While Intelligence represents one’s ability to analyze information, Wisdom represents being in tune with and aware of one’s 
          surroundings. Wisdom is the most important ability for clerics and druids, and it is also important for paladins and rangers. 
          If you want your character to have acute senses, put a high score in Wisdom. Every creature has a Wisdom score."
          Width="52px"></asp:TextBox>
      </td>
      <td>
        <asp:Label ID="lblWisDetails" runat="server"></asp:Label>
      </td>
    </tr>
    <tr>
      <td>
        <asp:Label ID="lblCha" runat="server" Text="Charisma:"></asp:Label>
      </td>
      <td>
        <asp:TextBox ID="txtCha" runat="server" ToolTip="Charisma measures a character’s force of personality, persuasiveness, personal 
          magnetism, ability to lead, and physical attractiveness. This ability represents actual strength of personality, not merely how one 
          is perceived by others in a social setting. Charisma is most important for paladins, sorcerers, and bards. It is also important for 
          clerics, since it affects their ability to turn undead. Every creature has a Charisma score."
          Width="52px"></asp:TextBox>
      </td>
      <td>
        <asp:Label ID="lblChaDetails" runat="server"></asp:Label>
      </td>
    </tr>
  </table>
  <asp:Button ID="btnRollAttributes" runat="server" Text="Roll Scores" OnClick="btnRollAttributes_Click" />
  <asp:Label ID="lblSummary" runat="server"></asp:Label>
  <br />
  <asp:DropDownList ID="ddlRace" runat="server" OnSelectedIndexChanged="ddlRace_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
  <asp:DropDownList ID="ddlSex" runat="server" OnSelectedIndexChanged="ddlSex_SelectedIndexChanged" AutoPostBack="true">
    <asp:ListItem Selected="True">Male</asp:ListItem>
    <asp:ListItem>Female</asp:ListItem>
  </asp:DropDownList>
  <asp:DropDownList ID="ddlClass" runat="server">
    <asp:ListItem Selected="True">Bard</asp:ListItem>
    <asp:ListItem>Cleric</asp:ListItem>
    <asp:ListItem>Mage</asp:ListItem>
    <asp:ListItem>Thief</asp:ListItem>
    <asp:ListItem>Warrior</asp:ListItem>
  </asp:DropDownList>
</asp:Content>
