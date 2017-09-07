using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace School1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        List<string> oNames = new List<string>
            {
                "James",
                "MARY",
                "Sue",
                "Lester",
                "JESSICA",
                "RABBIT"
            };

        protected void Page_Load(object sender, EventArgs e)
        {   
            if (!IsPostBack)
            {
                // Exercise 4
                PrintNums(10);
                PrintNumsLine(10);
                PrintNames();

                // Exercise 7
                ViewState["TestValue"] = "RockAndRoll";

                // Exercise 8
                hyp8.NavigateUrl = "Page_2.aspx?ID=65";
                Global.WorldID = 23456;
                Cache["TeamName"] = "ChicagoCubs";
            }

            try
            {
                //lblResult.Text = Request["ID"] + ' ' + Request["Name"];
                //Response.Redirect("PageThree.aspx?ID=" + Request["ID"]);

               
            }
            catch (Exception ex)
            {

                lblResult.Text = ex.Message;
            }
        }

        protected void btnEnterData_Click(object sender, EventArgs e)
        {
            try
            {
                // Display the text entered.
                //      Where? The literal?
                lit1.Text = txtEnterData.Text;

                // Change the Hyperlink to say “Changed.”
                hypImaLink.Text = "Changed.";

                // Make the TextBox border red
                txtEnterData.BorderColor = Color.Red;

                // Change the Label font to green
                lblEnterData.ForeColor = Color.Green;

                // Next
                //     Just do it next? Or make it happen it each subsequent button click?
                // Display “Greetings Earth person” AFTER the entered text in the Literal
                lit1.Text += " Greetings Earth person";

                // Next Display “Greetings Earth person” BEFORE the entered text in Italics in the Literal
                lit1.Text = "<i>Greetings Earth person</i> " + lit1.Text;

                // Next Display the sum of 5 + the number entered in Bold in the Literal.
                try
                {
                    int iTotal = Int32.Parse(txtEnterData.Text) + 5;
                    lit1.Text += " <b>" + iTotal.ToString() + "</b>";
                }
                catch (Exception)
                {

                    lit1.Text = "\"" + txtEnterData.Text + "\" is not a number";
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // Exercise 3

        protected void btnNameIf_Click(object sender, EventArgs e)
        {
            lblNameIf_Output.Text = "NO";
            if (txtNameIf.Text == "Mary")
            {
                lblNameIf_Output.Text = "Sort Of";
            }
            if (txtNameIf.Text == "MaryAnn")
            {
                lblNameIf_Output.Text = "Maybe";
            }
            if (txtNameIf.Text == "MARYANN")
            {
                lblNameIf_Output.Text = "YES";
            }
            if (txtNameIf.Text == "Ginger")
            {
                lblNameIf_Output.Text = "Awesome";
            }
        }

        protected void btnNameSwitch_Click(object sender, EventArgs e)
        {
            switch (txtNameSwitch.Text)
            {
                case "Mary":
                    lblNameSwitch_Output.Text = "Sort Of";
                    break;
                case "MaryAnn":
                    lblNameSwitch_Output.Text = "Maybe";
                    break;
                case "MARYANN":
                    lblNameSwitch_Output.Text = "YES";
                    break;
                case "Ginger":
                    lblNameSwitch_Output.Text = "Awesome";
                    break;
                default:
                    lblNameSwitch_Output.Text = "NO";
                    break;
            }
        }

        protected void btnNumIf_Click(object sender, EventArgs e)
        {
            try
            {
                int iNumIf = Int32.Parse(txtNumIf.Text);
                lblNumIf_Output.Text = "NO";

                if (iNumIf + 2 == 6)
                {
                    lblNumIf_Output.Text = "Sort Of";
                }
                if (iNumIf - 2 == 6)
                {
                    lblNumIf_Output.Text = "Maybe";
                }
                if (iNumIf + 2 == 5)
                {
                    lblNumIf_Output.Text = "YES";
                }
                if (iNumIf + 5 == 10)
                {
                    lblNumIf_Output.Text = "Awesome";
                }
            }
            catch (Exception ex)
            {

                lblNumIf_Output.Text = ex.Message;
            }
        }

        protected void btnNumSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                int iNumSwitch = Int32.Parse(txtNumSwitch.Text);

                switch (iNumSwitch)
                {
                    case 4:
                        lblNumSwitch_Output.Text = "Sort Of";
                        break;
                    case 8:
                        lblNumSwitch_Output.Text = "Maybe";
                        break;
                    case 3:
                        lblNumSwitch_Output.Text = "YES";
                        break;
                    case 5:
                        lblNumSwitch_Output.Text = "Awesome";
                        break;
                    default:
                        lblNumSwitch_Output.Text = "NO";
                        break;
                }
            }
            catch (Exception ex)
            {

                lblNumIf_Output.Text = ex.Message;
            }
        }

        // Exercise 4

        public void PrintNums(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                lbl4a.Text += " " + i.ToString();
            }
        }

        public void PrintNumsLine(int length)
        {
            for (int i = 1; i <= length; i++)
            {
                lbl4b.Text += "<br/>" + i.ToString();
            }
        }

        protected void btn4ciii_Click(object sender, EventArgs e)
        {
            // Ex 4c-iii.Add a TextBox and write x number of them based the input from it
            lbl4ciii_out.Text = "";

            try
            {
                int iCount = Int32.Parse(txt4ciii.Text);
                
                for (int i = 0; i < iCount; i++)
                {
                    lbl4ciii_out.Text += oNames[i % oNames.Count()] + " ";
                }
            }
            catch (Exception ex)
            {

                lbl4ciii_out.Text = ex.Message;
            }
        }

        public void PrintNames()
        {
           // i.	Write them all to a label.

            foreach (var item in oNames)
            {
                lbl4ci.Text += item;
                if (oNames.IndexOf(item) != oNames.Count - 1)
                {
                    lbl4ci.Text += ", ";
                }
            }

            // ii.	Write only the ones that are in all capital letters
            foreach (var item in oNames)
            {
                if (item == item.ToUpper())
                {
                    lbl4cii.Text += item + " ";
                }
            }


            // d.Create a list of five numbers in code

            List<int> oNums = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                oNums.Add(i);
            }

            // i.Display each one
            foreach (var item in oNums)
            {
                lbl4di.Text += item + " ";
            }

            // ii.Display each one with the letters “XYZ” next to it
            foreach (var item in oNums)
            {
                lbl4dii.Text += item + "XYZ ";
            }
            // iii.Display the total when the numbers are added together
            int iNumListSum = 0;
            foreach (var item in oNums)
            {
                iNumListSum += item;
            }
            lbl4diii.Text = "Sum: " + iNumListSum.ToString();


        }

        // Exercise 5

        protected void btn5a_Click(object sender, EventArgs e)
        {
            int iNum = Int32.Parse(txt5aInt.Text);
            lbl5aOut.Text = Concat(iNum, txt5aStr.Text);
        }

        public string Concat(int iArg, string sArg)
        {
            try
            {
                string sResult = iArg.ToString() + sArg;
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

                throw;
            }
        }

        protected void btn5b_Click(object sender, EventArgs e)
        {
            int iNum1 = Int32.Parse(txt5b1.Text);
            int iNum2 = Int32.Parse(txt5b2.Text);
            int iNum3 = Int32.Parse(txt5b3.Text);

            int iResult = AddInts(iNum1, iNum2, iNum3);

            lbl5bOut.Text = iResult.ToString();

            if (iResult < 0)
            {
                lbl5bOut.ForeColor = Color.Red;
            }
        }

        public decimal AddDecs(decimal dArg1, decimal dArg2, decimal dArg3)
        {
            return dArg1 + dArg2 + dArg3;
        }

        protected void btn5c_Click(object sender, EventArgs e)
        {
            decimal dResult = AddDecs(decimal.Parse(txt5c1.Text), decimal.Parse(txt5c2.Text), decimal.Parse(txt5c3.Text));
            lbl5cOut.Text = dResult.ToString();
            if (dResult > 0)
            {
                lbl5cOut.ForeColor = Color.Green;
            }
            else if (dResult < 0)
            {
                lbl5cOut.Width = 300;
            }
        }

        public void Percent(bool bArg, decimal dArg1, decimal dArg2)
        {
            if (!bArg)
            {
                lbl5dOut.Text = "$" + (dArg1 + dArg2).ToString();
                lbl5dOut.ForeColor = Color.Brown;
            }
            else
            {
                lbl5dOut.Text = (dArg1 + dArg2).ToString() + "%";
                lbl5dOut.ForeColor = Color.Blue;
            }
        }

        protected void btn5d_Click(object sender, EventArgs e)
        {
            Percent(Boolean.Parse(txt5dBool.Text), decimal.Parse(txt5dDec1.Text), decimal.Parse(txt5dDec2.Text));
        }

        // Exercise 6
        protected void btn6_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Page_2.aspx");

            }
            catch (Exception ex)
            {
                lbl6.Text = ex.Message;
            }

        }

        // Exercise 7
        protected void btn7_Click(object sender, EventArgs e)
        {
            // d.Use the Button function on your web page to: (all at the same time)
            // i.Display the TestValue from ViewState In the literal control
            lit7.Text = ViewState["TestValue"].ToString();

            // ii.Replace that TestValue in ViewState Assign it the new value “Country&Western”
            ViewState["TestValue"] = "Country&Western";

            // iii.Display the new TestValue from ViewState In the label control In Bold
            lbl7.Text = "<b>" + ViewState["TestValue"].ToString() + "</b>";
        }

    }
}