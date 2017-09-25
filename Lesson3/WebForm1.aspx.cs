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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                    string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                    Books oBooks = new Books(sCnxn, sLogPath);

                    this.ddlBooks.DataSource = oBooks.Values;
                    this.ddlBooks.DataTextField = "BookTitle";
                    this.ddlBooks.DataValueField = "BookID";
                    this.ddlBooks.DataBind();

                    this.chkBooks.DataSource = oBooks.Values;
                    this.chkBooks.DataTextField = "BookTitle";
                    this.chkBooks.DataValueField = "BookID";
                    this.chkBooks.DataBind();

                    this.rdoBooks.DataSource = oBooks.Values;
                    this.rdoBooks.DataTextField = "BookTitle";
                    this.rdoBooks.DataValueField = "BookID";
                    this.rdoBooks.DataBind();

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


        protected void chkBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, sLogPath);

                this.lblSelection.Text = "You have selected:<br/>";

                foreach (ListItem i in chkBooks.Items)
                {
                    if (i.Selected)
                    {
                        if (int.TryParse(i.Value, out int x))
                        {
                            this.lblSelection.Text += "\"" + oBooks[int.Parse(i.Value)].BookTitle + ",\" by " + oBooks[int.Parse(i.Value)].AuthorName + "<br/>";
                        }
                        else
                        {
                            this.lblSelection.Text += i.Value.ToString() + "<br/>";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                this.lblSelection.Text = ex.Message;
            }
        }

        protected void rdoBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, sLogPath);

                this.lblSelection.Text = "You have selected \"" + oBooks[int.Parse(rdoBooks.SelectedItem.Value)].BookTitle + ",\" by " + oBooks[int.Parse(rdoBooks.SelectedItem.Value)].AuthorName + ".";
            }
            catch (Exception ex)
            {

                this.lblSelection.Text = ex.Message;
            }
        }

        protected void ddlBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, sLogPath);

                this.lblSelection.Text = "You have selected \"" + oBooks[int.Parse(ddlBooks.SelectedItem.Value)].BookTitle + ",\" by " + oBooks[int.Parse(ddlBooks.SelectedItem.Value)].AuthorName + ".";
            }
            catch (Exception ex)
            {

                this.lblSelection.Text = ex.Message;
            }
        }

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkBooks.Items.Remove("Stop Sign");
            chkBooks.Items.Remove("Firetruck");
            chkBooks.Items.Remove("Sky");
            chkBooks.Items.Remove("Blueberry");
            chkBooks.Items.Remove("Grass");
            chkBooks.Items.Remove("Money");

            if (ddl2.Text == "Red")
            {
                chkBooks.Items.Add("Stop Sign");
                chkBooks.Items.Add("Firetruck");
            }
            if (ddl2.Text == "Blue")
            {
                chkBooks.Items.Add("Sky");
                chkBooks.Items.Add("Blueberry");
            }
            if (ddl2.Text == "Green")
            {
                chkBooks.Items.Add("Grass");
                chkBooks.Items.Add("Money");
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