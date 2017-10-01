using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using School1Companion;

namespace MyStuff
{
    public partial class CharacterSheet : System.Web.UI.Page
    {
        List<string> oNationalityList = new List<string>();
        List<string> oRaceList = new List<string>
        { "Dwarf", "Elf", "Gnome", "Half-Elf", "Half-Orc", "Halfling", "Human" };
        public static Dictionary<string, int> oRacialAttributeMods = new Dictionary<string, int>();
        public static Dictionary<string, int> oAttributes = new Dictionary<string, int>();

        Random random = new Random(DateTime.UtcNow.Millisecond);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                oAttributes["Str"] = 10;
                oAttributes["Dex"] = 10;
                oAttributes["Con"] = 10;
                oAttributes["Int"] = 10;
                oAttributes["Wis"] = 10;
                oAttributes["Cha"] = 10;
                // Populate lists
                ddlRace.DataSource = oRaceList;
                ddlRace.DataBind();
                ddlRace.SelectedIndex = 6;
                RacialAttributeModsReset();
                AttributesSet();
            }
        }

        protected void RacialAttributeModsReset()
        {
            oRacialAttributeMods["Str"] = 0;
            oRacialAttributeMods["Dex"] = 0;
            oRacialAttributeMods["Con"] = 0;
            oRacialAttributeMods["Int"] = 0;
            oRacialAttributeMods["Wis"] = 0;
            oRacialAttributeMods["Cha"] = 0;
        }

        protected void AttributesSet()
        {
            if (ddlSex.SelectedValue == "Female")
            {
                txtStr.Text = (oAttributes["Str"] + oRacialAttributeMods["Str"] - 2).ToString();
            }
            else
            {
                txtStr.Text = (oAttributes["Str"] + oRacialAttributeMods["Str"]).ToString();
            }
            txtDex.Text = (oAttributes["Dex"] + oRacialAttributeMods["Dex"]).ToString();
            txtCon.Text = (oAttributes["Con"] + oRacialAttributeMods["Con"]).ToString();
            txtInt.Text = (oAttributes["Int"] + oRacialAttributeMods["Int"]).ToString();
            txtWis.Text = (oAttributes["Wis"] + oRacialAttributeMods["Wis"]).ToString();
            if (ddlSex.SelectedValue == "Female")
            {
                txtCha.Text = (oAttributes["Cha"] + oRacialAttributeMods["Cha"] + 2).ToString();
            }
            else
            {
                txtCha.Text = (oAttributes["Cha"] + oRacialAttributeMods["Cha"]).ToString();
            }

            lblStrDetails.Text = GetModifier(int.Parse(txtStr.Text)).ToString("+#;-#;0");
            lblDexDetails.Text = GetModifier(int.Parse(txtDex.Text)).ToString("+#;-#;0");
            lblConDetails.Text = GetModifier(int.Parse(txtCon.Text)).ToString("+#;-#;0");
            lblIntDetails.Text = GetModifier(int.Parse(txtInt.Text)).ToString("+#;-#;0");
            lblWisDetails.Text = GetModifier(int.Parse(txtWis.Text)).ToString("+#;-#;0");
            lblChaDetails.Text = GetModifier(int.Parse(txtCha.Text)).ToString("+#;-#;0");
        }

        protected int GetModifier(int iAttribute)
        {
            return iAttribute / 2 - 5;
        }

        public Dictionary<string, int> RollStandard()
        {
            Random random = new Random(DateTime.UtcNow.Millisecond);
            List<int> iScoresList = new List<int>();
            Dictionary<string, int> oAttributes = new Dictionary<string, int>();
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Remove(iScoresList.Min());
            oAttributes.Add("Str", iScoresList.Sum());
            iScoresList.Clear();
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Remove(iScoresList.Min());
            oAttributes.Add("Dex", iScoresList.Sum());
            iScoresList.Clear();
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Remove(iScoresList.Min());
            oAttributes.Add("Con", iScoresList.Sum());
            iScoresList.Clear();
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Remove(iScoresList.Min());
            oAttributes.Add("Int", iScoresList.Sum());
            iScoresList.Clear();
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Remove(iScoresList.Min());
            oAttributes.Add("Wis", iScoresList.Sum());
            iScoresList.Clear();
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Add(random.Next(1, 7));
            iScoresList.Remove(iScoresList.Min());
            oAttributes.Add("Cha", iScoresList.Sum());
            return oAttributes;
        }

        public Dictionary<string, int> RollClassic()
        {
            Random random = new Random(DateTime.UtcNow.Millisecond);
            Dictionary<string, int> oAttributes = new Dictionary<string, int>();
            int iTotal = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            oAttributes.Add("Str", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            oAttributes.Add("Dex", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            oAttributes.Add("Con", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            oAttributes.Add("Int", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            oAttributes.Add("Wis", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + random.Next(1, 7);
            oAttributes.Add("Cha", iTotal);
            return oAttributes;
        }

        public Dictionary<string, int> RollHeroic()
        {
            Random random = new Random(DateTime.UtcNow.Millisecond);
            Dictionary<string, int> oAttributes = new Dictionary<string, int>();
            int iTotal = random.Next(1, 7) + random.Next(1, 7) + 6;
            oAttributes.Add("Str", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + 6;
            oAttributes.Add("Dex", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + 6;
            oAttributes.Add("Con", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + 6;
            oAttributes.Add("Int", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + 6;
            oAttributes.Add("Wis", iTotal);
            iTotal = random.Next(1, 7) + random.Next(1, 7) + 6;
            oAttributes.Add("Cha", iTotal);
            return oAttributes;
        }

        protected void btnRollAttributes_Click(object sender, EventArgs e)
        {
            btnRollAttributes.Text = "Reroll";

            if (ddlRollMethod.SelectedValue == "0")
            { oAttributes = RollStandard(); }
            if (ddlRollMethod.SelectedValue == "1")
            { oAttributes = RollClassic(); }
            if (ddlRollMethod.SelectedValue == "2")
            { oAttributes = RollHeroic(); }

            AttributesSet();

            int iTotal = oAttributes.Values.Sum();
            decimal dAvg = Convert.ToDecimal(iTotal) / 6;
            lblSummary.Text = "";
            lblSummary.Text += "Average: " + dAvg.ToString("F");
        }

        protected void ddlRace_SelectedIndexChanged(object sender, EventArgs e)
        {
            RacialAttributeModsReset();
            if (ddlRace.Text == "Dwarf")
            {
                oRacialAttributeMods["Wis"] = 2;
                oRacialAttributeMods["Cha"] = -2;
                oRacialAttributeMods["Con"] = 2;
            }
            if (ddlRace.Text == "Elf")
            {
                oRacialAttributeMods["Int"] = 2;
                oRacialAttributeMods["Dex"] = 2;
                oRacialAttributeMods["Con"] = -2;
            }
            if (ddlRace.Text == "Gnome")
            {
                oRacialAttributeMods["Con"] = 2;
                oRacialAttributeMods["Cha"] = 2;
                oRacialAttributeMods["Str"] = -2;
            }
            if (ddlRace.Text == "Half-Elf")
            {
                oRacialAttributeMods["Int"] = 1;
                oRacialAttributeMods["Dex"] = 1;
                oRacialAttributeMods["Con"] = -1;
            }
            if (ddlRace.Text == "Half-Orc")
            {
                oRacialAttributeMods["Str"] = 2;
                oRacialAttributeMods["Con"] = 2;
                oRacialAttributeMods["Cha"] = -2;
                oRacialAttributeMods["Int"] = -2;
            }
            if (ddlRace.Text == "Halfling")
            {
                oRacialAttributeMods["Cha"] = 2;
                oRacialAttributeMods["Dex"] = 2;
                oRacialAttributeMods["Str"] = -2;
            }

            AttributesSet();
        }

        protected void ddlSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            AttributesSet();
        }
    }
}