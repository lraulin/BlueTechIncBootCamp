using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;

namespace School1
{
    public partial class WebForm2 : Page
    {
        private List<string> oNames = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.oNames.Add("James");
            this.oNames.Add("MARY");
            this.oNames.Add("Sue");
            this.oNames.Add("Lester");
            this.oNames.Add("JESSICA");
            this.oNames.Add("RABBIT");

            if (!this.IsPostBack)
            {
                // Exercise 4
                this.PrintNums(10);
                this.PrintNumsLine(10);
                this.PrintNames();

                // Exercise 7
                this.ViewState["TestValue"] = "RockAndRoll";

                // Exercise 8
                this.hyp8.NavigateUrl = "Page_2.aspx?ID=65";
                Global.WorldID = 23456;
                this.Cache["TeamName"] = "ChicagoCubs";
            }

            try
            {
                //lblResult.Text = Request["ID"] + ' ' + Request["Name"];
                //Response.Redirect("PageThree.aspx?ID=" + Request["ID"]);
            }
            catch (Exception ex)
            {
                this.lblResult.Text = ex.Message;
            }
        }

        protected void btnEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                // Display the text entered.
                this.lit1.Text = this.txtEnterData.Text;

                // Change the Hyperlink to say “Changed.”
                this.hypImaLink.Text = "Changed.";

                // Make the TextBox border red
                this.txtEnterData.BorderColor = Color.Red;

                // Change the Label font to green
                this.lblEnterData.ForeColor = Color.Green;

                // Display “Greetings Earth person” AFTER the entered text in the Literal
                this.lit1.Text += " Greetings Earth person";

                // Next Display “Greetings Earth person” BEFORE the entered text in Italics in the Literal
                this.lit1.Text = "<i>Greetings Earth person</i> " + this.lit1.Text;

                // Next Display the sum of 5 + the number entered in Bold in the Literal.
                try
                {
                    int iTotal = int.Parse(this.txtEnterData.Text) + 5;
                    this.lit1.Text += " <b>" + iTotal + "</b>";
                }
                catch (Exception)
                {
                    this.lit1.Text = "\"" + this.txtEnterData.Text + "\" is not a number";
                }
            }
            catch (Exception ex)
            {
                this.Response.Write(ex.Message);
            }
        }

        // Exercise 3

        protected void btnNameIf_Click(object sender, EventArgs e)
        {
            this.lblNameIf_Output.Text = "NO";
            if (this.txtNameIf.Text == "Mary")
                this.lblNameIf_Output.Text = "Sort Of";
            if (this.txtNameIf.Text == "MaryAnn")
                this.lblNameIf_Output.Text = "Maybe";
            if (this.txtNameIf.Text == "MARYANN")
                this.lblNameIf_Output.Text = "YES";
            if (this.txtNameIf.Text == "Ginger")
                this.lblNameIf_Output.Text = "Awesome";
        }

        protected void btnNameSwitch_Click(object sender, EventArgs e)
        {
            switch (this.txtNameSwitch.Text)
            {
                case "Mary":
                    this.lblNameSwitch_Output.Text = "Sort Of";
                    break;
                case "MaryAnn":
                    this.lblNameSwitch_Output.Text = "Maybe";
                    break;
                case "MARYANN":
                    this.lblNameSwitch_Output.Text = "YES";
                    break;
                case "Ginger":
                    this.lblNameSwitch_Output.Text = "Awesome";
                    break;
                default:
                    this.lblNameSwitch_Output.Text = "NO";
                    break;
            }
        }

        protected void btnNumIf_Click(object sender, EventArgs e)
        {
            try
            {
                int iNumIf = int.Parse(this.txtNumIf.Text);
                this.lblNumIf_Output.Text = "NO";

                if (iNumIf + 2 == 6)
                    this.lblNumIf_Output.Text = "Sort Of";
                if (iNumIf - 2 == 6)
                    this.lblNumIf_Output.Text = "Maybe";
                if (iNumIf + 2 == 5)
                    this.lblNumIf_Output.Text = "YES";
                if (iNumIf + 5 == 10)
                    this.lblNumIf_Output.Text = "Awesome";
            }
            catch (Exception ex)
            {
                this.lblNumIf_Output.Text = ex.Message;
            }
        }

        protected void btnNumSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                int iNumSwitch = int.Parse(this.txtNumSwitch.Text);

                switch (iNumSwitch)
                {
                    case 4:
                        this.lblNumSwitch_Output.Text = "Sort Of";
                        break;
                    case 8:
                        this.lblNumSwitch_Output.Text = "Maybe";
                        break;
                    case 3:
                        this.lblNumSwitch_Output.Text = "YES";
                        break;
                    case 5:
                        this.lblNumSwitch_Output.Text = "Awesome";
                        break;
                    default:
                        this.lblNumSwitch_Output.Text = "NO";
                        break;
                }
            }
            catch (Exception ex)
            {
                this.lblNumIf_Output.Text = ex.Message;
            }
        }

        // Exercise 4

        public void PrintNums(int length)
        {
            for (int i = 1; i <= length; i++)
                this.lbl4a.Text += " " + i;
        }

        public void PrintNumsLine(int length)
        {
            for (int i = 1; i <= length; i++)
                this.lbl4b.Text += "<br/>" + i;
        }

        protected void btn4ciii_Click(object sender, EventArgs e)
        {
            // Ex 4c-iii.Add a TextBox and write x number of them based the input from it
            this.lbl4ciii_out.Text = "";

            try
            {
                for (int i = 0; i < int.Parse(this.txt4ciii.Text); i++)
                    this.lbl4ciii_out.Text += this.oNames[i] + " ";
            }
            catch (Exception)
            {
                this.lbl4ciii_out.Text = "Input error. Enter a number from 1 to 6.";
            }
        }

        public void PrintNames()
        {
            // i.	Write them all to a label.

            foreach (string item in this.oNames)
            {
                this.lbl4ci.Text += item;
                if (this.oNames.IndexOf(item) != this.oNames.Count - 1)
                    this.lbl4ci.Text += ", ";
            }

            // ii.	Write only the ones that are in all capital letters
            foreach (string item in this.oNames)
                if (item == item.ToUpper())
                    this.lbl4cii.Text += item + " ";


            // d.Create a list of five numbers in code

            List<int> oNums = new List<int>();
            oNums.Add(1);
            oNums.Add(6);
            oNums.Add(10);
            oNums.Add(80);
            oNums.Add(99);

            // i.Display each one
            foreach (int item in oNums)
                this.lbl4di.Text += item + " ";

            // ii.Display each one with the letters “XYZ” next to it
            foreach (int item in oNums)
                this.lbl4dii.Text += item + "XYZ ";
            // iii.Display the total when the numbers are added together
            int iNumListSum = 0;
            foreach (int item in oNums)
                iNumListSum += item;
            this.lbl4diii.Text = "Sum: " + iNumListSum;
        }

        // Exercise 5

        protected void btn5a_Click(object sender, EventArgs e)
        {
            int iNum = int.Parse(this.txt5aInt.Text);
            this.lbl5aOut.Text = this.Concat(iNum, this.txt5aStr.Text);
        }

        public string Concat(int iArg, string sArg)
        {
            try
            {
                string sResult = iArg + sArg;
                return sResult;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int AddInts(int iArg1, int iArg2, int iArg3)
        {
            try
            {
                return iArg1 + iArg2 + iArg3;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        protected void btn5b_Click(object sender, EventArgs e)
        {
            int iNum1 = int.Parse(this.txt5b1.Text);
            int iNum2 = int.Parse(this.txt5b2.Text);
            int iNum3 = int.Parse(this.txt5b3.Text);

            int iResult = this.AddInts(iNum1, iNum2, iNum3);

            this.lbl5bOut.Text = iResult.ToString();

            if (iResult < 0)
                this.lbl5bOut.ForeColor = Color.Red;
        }

        public decimal AddDecs(decimal dArg1, decimal dArg2, decimal dArg3)
        {
            return dArg1 + dArg2 + dArg3;
        }

        protected void btn5c_Click(object sender, EventArgs e)
        {
            decimal dResult = this.AddDecs(decimal.Parse(this.txt5c1.Text), decimal.Parse(this.txt5c2.Text),
                decimal.Parse(this.txt5c3.Text));
            this.lbl5cOut.Text = dResult.ToString();
            if (dResult > 0)
                this.lbl5cOut.ForeColor = Color.Green;
            else if (dResult < 0)
                this.lbl5cOut.Width = 300;
        }

        public void Percent(bool bArg, decimal dArg1, decimal dArg2)
        {
            if (!bArg)
            {
                this.lbl5dOut.Text = "$" + (dArg1 + dArg2);
                this.lbl5dOut.ForeColor = Color.Brown;
            }
            else
            {
                this.lbl5dOut.Text = dArg1 + dArg2 + "%";
                this.lbl5dOut.ForeColor = Color.Blue;
            }
        }

        protected void btn5d_Click(object sender, EventArgs e)
        {
            this.Percent(bool.Parse(this.txt5dBool.Text), decimal.Parse(this.txt5dDec1.Text),
                decimal.Parse(this.txt5dDec2.Text));
        }

        // Exercise 6
        protected void btn6_Click(object sender, EventArgs e)
        {
            try
            {
                this.Response.Redirect("Page_2.aspx");
            }
            catch (Exception ex)
            {
                this.lbl6.Text = ex.Message;
            }
        }

        // Exercise 7
        protected void btn7_Click(object sender, EventArgs e)
        {
            // d.Use the Button function on your web page to: (all at the same time)
            // i.Display the TestValue from ViewState In the literal control
            this.lit7.Text = this.ViewState["TestValue"].ToString();

            // ii.Replace that TestValue in ViewState Assign it the new value “Country&Western”
            this.ViewState["TestValue"] = "Country&Western";

            // iii.Display the new TestValue from ViewState In the label control In Bold
            this.lbl7.Text = "<b>" + this.ViewState["TestValue"] + "</b>";
        }
    }
}