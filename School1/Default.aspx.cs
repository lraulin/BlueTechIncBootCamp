using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace School1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                hyp1.NavigateUrl = "PageTwo.aspx?ID=1&Name=David";
                hyp2.NavigateUrl = "PageTwo.aspx?ID=2&Name=Mary";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnCombine_Click(object sender, EventArgs e)
        {

            try
            {

                pnl1.Visible = false;

            }
            catch (Exception ex)
            {

                this.lblResult.Text = ex.Message;
            }
        }

        public string SayHelloByName(string FirstName)
        {
            try
            {
                // run the code process
                string sOutput = "Hello ";
                sOutput += FirstName;
                sOutput += " ";
                sOutput += txtLastName.Text;
                sOutput += "!";

                if (FirstName == "Mary")
                    lblResult.ForeColor = Color.Firebrick;
                if (FirstName == "Leo")
                    lblResult.ForeColor = Color.ForestGreen;

                // return the result
                return (sOutput);
            }
            catch (Exception Exc)
            {

                return (Exc.Message);
            }
        }
    }
}