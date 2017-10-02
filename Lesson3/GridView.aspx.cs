using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using BooksCompanion;
using System.Data;

namespace Lesson3
{
    public partial class GridView : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];
        private static List<int> iSelections = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateWebControls();
        }

        private Boolean CanCovert(String value, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.IsValid(value);
        }

        private void PopulateWebControls()
        {
            try
            {
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

                this.ddlBooks.Items.Insert(0, new ListItem("--Select--"));

                this.ddlColor.Items.Add("Red");
                this.ddlColor.Items.Add("Blue");
                this.ddlColor.Items.Add("Green");
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "PopulateWebControls: " + ex.Message;
            }
        }

        private void BindSelections()
        {
            try
            {
                iSelections.Clear();
                if (CanCovert(this.ddlBooks.SelectedValue, typeof(int)))
                    iSelections.Add(int.Parse(this.ddlBooks.SelectedValue));

                if (CanCovert(this.rdoBooks.SelectedValue, typeof(int)))
                    iSelections.Add(int.Parse(this.rdoBooks.SelectedValue));

                foreach (ListItem item in this.chkBooks.Items)
                    if (item.Selected && CanCovert(item.Value, typeof(int)))
                        iSelections.Add(int.Parse(item.Value));

                Books oBooks = new Books(sCnxn, sLogPath);
                List<Book> oList = new List<Book>();
                List<Book> oListFiltered = new List<Book>();
                oList.AddRange(oBooks.Values);
                oListFiltered = oList.FindAll(delegate (Book b1) { return iSelections.Contains(b1.BookID); });
                this.dgBooks.DataSource = oListFiltered;
                this.dgBooks.DataBind();

                this.lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                this.lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "BindSelections:" + ex.Message;
            }
        }

        private void UpdateSelection()
        {
            try
            {
                Books oBooks = new Books(sCnxn, sLogPath);
                List<Book> oList = new List<Book>();
                oList.AddRange(oBooks.Values);
                IEnumerable<object> oSelectedBooks =
                    from book in oList
                    where iSelections.Contains(book.BookID)
                    select book;
                this.dgBooks.DataSource = oSelectedBooks;
                this.dgBooks.DataBind();

                this.lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                this.lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "UpdateSelection:" + ex.Message;
            }
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            try
            {
                iSelections = iSelections.Distinct<int>().ToList<int>();
                for (int i = this.dgBooks.Items.Count - 1; i >= 0; i--)
                {
                    CheckBox chkSelections = (CheckBox)dgBooks.Items[i].FindControl("chkSelection");
                    if (chkSelections.Checked)
                    {
                        string sSelectedID = this.dgBooks.Items[i].Cells[0].Text;
                        iSelections.Remove(int.Parse(sSelectedID));
                        if (this.ddlBooks.SelectedValue == sSelectedID)
                            this.ddlBooks.SelectedIndex = 0;
                        if (this.rdoBooks.SelectedValue == sSelectedID)
                            this.rdoBooks.SelectedIndex = 0;
                        foreach (ListItem item in chkBooks.Items)
                            if (item.Value == sSelectedID)
                                item.Selected = false;
                    }
                }
                UpdateSelection();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "btnRemoveSelected: " + ex.Message;
            }
        }

        protected void btnReset_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                this.lblSelection.Text = "RESET!";
                this.rdoBooks.ClearSelection();
                this.chkBooks.ClearSelection();
                this.ddlBooks.ClearSelection();
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "btnReset_Click: " + ex.Message;
            }
        }

        protected void chkBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];
                Books oBooks = new Books(sCnxn, sLogPath);
                this.lblSelection.Text = "You have selected:<br/>";
                foreach (ListItem item in chkBooks.Items)
                    if (item.Selected)
                        if (CanCovert(item.Value, typeof(int)))
                            this.lblSelection.Text += "\"" + oBooks[int.Parse(item.Value)].BookTitle + ",\" by " + oBooks[int.Parse(item.Value)].AuthorName + "<br/>";
                        else
                            this.lblSelection.Text += item.Value.ToString() + "<br/>";
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "chkBooks_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void clrCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                if (e.Day.Date > DateTime.Today ||
                    e.Day.Date < DateTime.Today ||
                    e.Day.Date.DayOfWeek.ToString() == "Saturday" ||
                    e.Day.Date.DayOfWeek.ToString() == "Sunday")
                {
                    e.Day.IsSelectable = false;
                }
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "clrCalendar_DayRender: " + ex.Message;
            }
        }

        protected void clrCalendar_SelectionChanged(object sender, EventArgs e)
        {
            this.lblCalendarLine1.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.clrCalendar.SelectedDate.Month);
            this.clrCalendar.SelectedDate = this.clrCalendar.SelectedDate.AddHours(10);
            this.lblCalendarLine2.Text = "Date & Time: " + this.clrCalendar.SelectedDate;
            this.clrCalendar.SelectedDate = this.clrCalendar.SelectedDate.AddHours(14);
            this.lblCalendarLine3.Text = "Next Day: " + this.clrCalendar.SelectedDate;
        }

        protected void rdoBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdoBooks.SelectedValue != "")
                {
                    int iSelectedID = int.Parse(rdoBooks.SelectedItem.Value);
                    Books oBooks = new Books(sCnxn, sLogPath);
                    this.lblSelection.Text = "You have selected \"" + oBooks[iSelectedID].BookTitle + ",\" by " + oBooks[iSelectedID].AuthorName + ".";
                    BindSelections();
                }
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "rdoBooks_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void ddlBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (CanCovert(ddlBooks.SelectedValue, typeof(int)))
                {
                    int iSelectedID = int.Parse(ddlBooks.SelectedItem.Value);
                    Books oBooks = new Books(sCnxn, sLogPath);
                    this.lblSelection.Text = "You have selected \"" + oBooks[iSelectedID].BookTitle + ",\" by " + oBooks[iSelectedID].AuthorName + ".";
                }
                else
                {
                    this.lblSelection.Text = "You have reset the drop-down list.";
                }
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "ddlBooks_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void ddlColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.chkBooks.Items.Remove("Stop Sign");
                this.chkBooks.Items.Remove("Firetruck");
                this.chkBooks.Items.Remove("Sky");
                this.chkBooks.Items.Remove("Blueberry");
                this.chkBooks.Items.Remove("Grass");
                this.chkBooks.Items.Remove("Money");

                if (this.ddlColor.Text == "Red")
                {
                    this.chkBooks.Items.Add("Stop Sign");
                    this.chkBooks.Items.Add("Firetruck");
                }
                if (this.ddlColor.Text == "Blue")
                {
                    this.chkBooks.Items.Add("Sky");
                    this.chkBooks.Items.Add("Blueberry");
                }
                if (this.ddlColor.Text == "Green")
                {
                    this.chkBooks.Items.Add("Grass");
                    this.chkBooks.Items.Add("Money");
                }
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "ddlColor_SelectedIndexChanged: " + ex.Message;
            }
        }
    }
}