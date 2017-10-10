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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];
                Books oBooks = new Books(sCnxn, sLogPath);
                Cache["oBooks"] = oBooks;
                List<Book> oListSelected = new List<Book>();
                oListSelected.AddRange(oBooks.Values);
                Cache["oListSelected"] = oListSelected;
                Cache["sSortExpression"] = "BOOKID";
                Cache["bReversed"] = false;
                PopulateWebControls();
            }
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
                Books oBooks = (Books)Cache["oBooks"];

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

                this.ddlFilter.Items.Add("Author Contains");
                this.ddlFilter.Items.Add("Title Contains");
                this.ddlFilter.Items.Add("Length Greater Than");
                this.ddlFilter.Items.Add("Length Less Than");
                this.ddlFilter.Items.Add("Price Greater Than");
                this.ddlFilter.Items.Add("Price Less Than");
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "PopulateWebControls: " + ex.Message;
            }
        }

        private void ListUpdate()
        {
            try
            {
                Books oBooks = (Books)Cache["oBooks"];
                List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
                oListSelected.Clear();

                if (CanCovert(this.ddlBooks.SelectedValue, typeof(int)))
                {
                    int iBookID = int.Parse(this.ddlBooks.SelectedValue);
                    oListSelected.Add(oBooks[iBookID]);
                }

                if (CanCovert(this.rdoBooks.SelectedValue, typeof(int)))
                {
                    int iBookID = int.Parse(this.rdoBooks.SelectedValue);
                    oListSelected.Add(oBooks[iBookID]);
                }

                foreach (ListItem item in this.chkBooks.Items)
                    if (item.Selected && CanCovert(item.Value, typeof(int)))
                    {
                        int iBookID = int.Parse(item.Value);
                        oListSelected.Add(oBooks[iBookID]);
                    }
                oListSelected = oListSelected.Distinct<Book>().ToList<Book>();
                Cache["oListSelected"] = oListSelected;
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "BindSelections:" + ex.Message;
            }
        }

        private void BindSelections()
        {
            try
            {
                List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
                int iMinLength = 0;
                int iMaxLength = 0;
                int iTotalLength = 0;
                int iAvgLength = 0;
                decimal dMinPrice = 0;
                decimal dMaxPrice = 0;
                decimal dTotalPrice = 0;
                decimal dAvgPrice = 0;

                if (oListSelected.Count > 0)
                {
                    iMinLength = oListSelected.Min((Book b1) => b1.Length);
                    iMaxLength = oListSelected.Max((Book b1) => b1.Length);
                    iTotalLength = oListSelected.Sum((Book b1) => b1.Length);
                    iAvgLength = (int)oListSelected.Average((Book b1) => b1.Length);
                    dMinPrice = oListSelected.Min((Book b1) => b1.Price);
                    dMaxPrice = oListSelected.Max((Book b1) => b1.Price);
                    dTotalPrice = oListSelected.Sum((Book b1) => b1.Length);
                    dAvgPrice = (decimal)oListSelected.Average((Book b1) => b1.Price);
                }
                this.lblStats.Text = String.Format("LENGTH Min: {0:n0}, Max {1:n0}, Total: {2:n0}, Avg: {3:n0} | PRICE Min: {4:C}, Max: {5:C}," +
                    "Total: {6:C} | Avg: {7:C}", iMinLength, iMaxLength, iTotalLength, iAvgLength, dMinPrice, dMaxPrice, dTotalPrice, dAvgPrice);
                SortBooks();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "BindSelection:" + ex.Message;
            }
        }

        public void SortBooks()
        {
            try
            {
                List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
                string sSortExpression = (string)Cache["sSortExpression"];

                if (sSortExpression == "BOOKID")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.BookID.CompareTo(b2.BookID); });
                if (sSortExpression == "BOOKTITLE")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.BookTitle.CompareTo(b2.BookTitle); });
                if (sSortExpression == "AUTHORNAME")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.AuthorName.CompareTo(b2.AuthorName); });
                if (sSortExpression == "LENGTH")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.Length.CompareTo(b2.Length); });
                if (sSortExpression == "ISONAMAZON")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.IsOnAmazon.CompareTo(b2.IsOnAmazon); });
                if (sSortExpression == "DATECREATED")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.DateCreated.CompareTo(b2.DateCreated); });
                if (sSortExpression == "PRICE")
                    oListSelected.Sort(delegate (Book b1, Book b2) { return b1.Price.CompareTo(b2.BookID); });

                if ((bool)Cache["bReversed"] == true)
                    oListSelected.Reverse();

                this.dgBooks.DataSource = oListSelected;
                this.dgBooks.DataBind();

                Cache["oListSelected"] = oListSelected;
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "SortBooks:" + ex.Message;
            }
        }

        protected void ddlBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Books oBooks = (Books)Cache["oBooks"];
                if (CanCovert(ddlBooks.SelectedValue, typeof(int)))
                {
                    int iSelectedID = int.Parse(ddlBooks.SelectedItem.Value);
                    this.lblSelection.Text = "You selected \"" + oBooks[iSelectedID].BookTitle + ",\" by " + oBooks[iSelectedID].AuthorName + " from the dropdown list.";
                }
                else
                    this.lblSelection.Text = "You have reset the drop-down list.";
                ListUpdate();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "ddlBooks_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void chkBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Books oBooks = (Books)Cache["oBooks"];
                this.lblSelection.Text = "You checked:<br/>";
                if (chkBooks.Items.Count > 0)
                {
                    foreach (ListItem item in chkBooks.Items)
                        if (item.Selected)
                            if (CanCovert(item.Value, typeof(int)))
                                this.lblSelection.Text += "\"" + oBooks[int.Parse(item.Value)].BookTitle + ",\" by " + oBooks[int.Parse(item.Value)].AuthorName + "<br/>";
                            else
                                this.lblSelection.Text += item.Value.ToString() + "<br/>";
                }
                else
                    this.lblSelection.Text = "All items have been unchecked.";
                ListUpdate();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "chkBooks_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void rdoBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Books oBooks = (Books)Cache["oBooks"];
                if (this.rdoBooks.SelectedValue != "")
                {
                    int iSelectedID = int.Parse(rdoBooks.SelectedItem.Value);
                    this.lblSelection.Text = "You selected \"" + oBooks[iSelectedID].BookTitle + ",\" by " + oBooks[iSelectedID].AuthorName + " from the radio button list.";
                    ListUpdate();
                }
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "rdoBooks_SelectedIndexChanged: " + ex.Message;
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
                    this.lblSelection.Text = "You selected 'Red' from the colors list. Red things were added to the checkbox list.";
                }
                if (this.ddlColor.Text == "Blue")
                {
                    this.chkBooks.Items.Add("Sky");
                    this.chkBooks.Items.Add("Blueberry");
                    this.lblSelection.Text = "You selected 'Blue' from the colors list. Blue things were added to the checkbox list.";
                }
                if (this.ddlColor.Text == "Green")
                {
                    this.chkBooks.Items.Add("Grass");
                    this.chkBooks.Items.Add("Money");
                    this.lblSelection.Text = "You selected 'Green' from the colors list. Green things added to the checkbox list.";
                }
                ListUpdate();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "ddlColor_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            try
            {
                List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
                for (int i = this.dgBooks.Items.Count - 1; i >= 0; i--)
                {
                    CheckBox chkSelections = (CheckBox)dgBooks.Items[i].FindControl("chkSelection");
                    if (chkSelections.Checked)
                    {
                        string sSelectedID = this.dgBooks.Items[i].Cells[0].Text;
                        oListSelected.RemoveAll((Book b1) => b1.BookID == int.Parse(sSelectedID));
                        if (this.ddlBooks.SelectedValue == sSelectedID)
                            this.ddlBooks.ClearSelection();
                        if (this.rdoBooks.SelectedValue == sSelectedID)
                            this.rdoBooks.ClearSelection();
                        foreach (ListItem item in chkBooks.Items)
                            if (item.Value == sSelectedID)
                                item.Selected = false;
                    }
                }
                Cache["oListSelected"] = oListSelected;
                BindSelections();
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
                List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
                oListSelected.Clear();
                Cache["oListSelected"] = oListSelected;
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "btnReset_Click: " + ex.Message;
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
            try
            {
                this.lblCalendarLine1.Text = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.clrCalendar.SelectedDate.Month);
                this.clrCalendar.SelectedDate = this.clrCalendar.SelectedDate.AddHours(10);
                this.lblCalendarLine2.Text = "Date & Time: " + this.clrCalendar.SelectedDate;
                this.clrCalendar.SelectedDate = this.clrCalendar.SelectedDate.AddHours(14);
                this.lblCalendarLine3.Text = "Next Day: " + this.clrCalendar.SelectedDate;
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "clrCalendar_SelectionChanged: " + ex.Message;
            }
        }

        public void dgBooks_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            try
            {
                Cache["bReversed"] = false;
                Cache["sSortExpression"] = e.SortExpression.ToUpper();
                SortBooks();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "dgBooks_SortCommand: " + ex.Message;
            }
        }

        protected void btnCheckAll_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListItem item in this.chkBooks.Items)
                    item.Selected = true;
                ListUpdate();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "btnCheckAll_Click: " + ex.Message;
            }
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
            if (this.ddlFilter.Text == "Author Contains")
                oListSelected = oListSelected.FindAll(delegate (Book b1) { return b1.AuthorName.ToUpper().Contains(this.txtFilter.Text.ToUpper()); });
            if (this.ddlFilter.Text == "Title Contains")
                oListSelected = oListSelected.FindAll(delegate (Book b1) { return b1.BookTitle.ToUpper().Contains(this.txtFilter.Text.ToUpper()); });
            if (this.ddlFilter.Text == "Length Greater Than")
                if (CanCovert(this.txtFilter.Text, typeof(int)))
                    oListSelected = oListSelected.FindAll((Book b1) => b1.Length > int.Parse(this.txtFilter.Text));
                else
                    this.lblSelection.Text = "Invalid input! Must be integer.";
            if (this.ddlFilter.Text == "Length Less Than")
                if (CanCovert(this.txtFilter.Text, typeof(int)))
                    oListSelected = oListSelected.FindAll((Book b1) => b1.Length < int.Parse(this.txtFilter.Text));
                else
                    this.lblSelection.Text = "Invalid input! Must be integer.";
            if (this.ddlFilter.Text == "Price Greater Than")
                if (CanCovert(this.txtFilter.Text, typeof(decimal)))
                    oListSelected = (from Book b1 in oListSelected where b1.Price > decimal.Parse(this.txtFilter.Text) select b1).ToList();
                else
                    this.lblSelection.Text = "Invalid input! Please enter a decimal number.";
            if (this.ddlFilter.Text == "Price Less Than")
                if (CanCovert(this.txtFilter.Text, typeof(decimal)))
                    oListSelected = (from Book b1 in oListSelected where b1.Price < decimal.Parse(this.txtFilter.Text) select b1).ToList();
                else
                    this.lblSelection.Text = "Invalid input! Please enter a decimal number.";
            Cache["oListSelected"] = oListSelected;
            BindSelections();
        }

        protected void btnReverseSort_Click(object sender, EventArgs e)
        {
            Cache["bReversed"] = true;
            List<Book> oListSelected = (List<Book>)Cache["oListSelected"];
            oListSelected.Reverse();
            dgBooks.DataSource = oListSelected;
            dgBooks.DataBind();
            Cache["oListSelected"] = oListSelected;
        }
    }
}