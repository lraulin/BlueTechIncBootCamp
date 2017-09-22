using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using BooksCompanion;
using System.Configuration;

namespace Lesson3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Books oBooks = new Books(sCnxn, sLogPath);
                    List<string> sBooks = new List<string>();
                    foreach (int key in oBooks.Keys)
                    {
                        sBooks.Add(oBooks[key].BookTitle);
                    }

                    ddlBooks.DataSource = sBooks;
                    ddlBooks.DataBind();

                    lstBooks.DataSource = sBooks;
                    lstBooks.DataBind();

                    ddlBooks.Items.Insert(0, new ListItem("--Select--"));

                    ddl2.Items.Add("Red");
                    ddl2.Items.Add("Blue");
                    ddl2.Items.Add("Green");

                }
                catch (Exception ex)
                {
                    Response.Write("BindData:" + ex.Message);
                }
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.lbl21a.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(Calendar1.SelectedDate.Month);
            Calendar1.SelectedDate = Calendar1.SelectedDate.AddHours(10);
            this.lbl21b.Text = "Date & Time: " + Calendar1.SelectedDate;
            Calendar1.SelectedDate = Calendar1.SelectedDate.AddHours(14);
            this.lbl21c.Text = "Next Day: " + Calendar1.SelectedDate;
        }


        protected void lstBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void rdoBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlBooks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBooks.Items.Remove("Stop Sign");
            lstBooks.Items.Remove("Firetruck");
            lstBooks.Items.Remove("Sky");
            lstBooks.Items.Remove("Blueberry");
            lstBooks.Items.Remove("Grass");
            lstBooks.Items.Remove("Money");

            if (ddl2.Text == "Red")
            {
                lstBooks.Items.Add("Stop Sign");
                lstBooks.Items.Add("Firetruck");
            }
            if (ddl2.Text == "Blue")
            {
                lstBooks.Items.Add("Sky");
                lstBooks.Items.Add("Blueberry");
            }
            if (ddl2.Text == "Green")
            {
                lstBooks.Items.Add("Grass");
                lstBooks.Items.Add("Money");
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today ||
                e.Day.Date < DateTime.Today ||
                e.Day.Date.DayOfWeek.ToString() == "Saturday" ||
                e.Day.Date.DayOfWeek.ToString() == "Sunday")
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}