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
        private static string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private static string sLogPath = ConfigurationManager.AppSettings["LogPath"];
        private static Books oBooks = new Books(sCnxn, sLogPath);
        private static Dictionary<int, Book> oBooksFiltered = new Dictionary<int, Book>();

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

        private void ListUpdate()
        {
            try
            {
                oBooksFiltered.Clear();

                if (CanCovert(this.ddlBooks.SelectedValue, typeof(int)))
                {
                    int iBookID = int.Parse(this.ddlBooks.SelectedValue);
                    oBooksFiltered[iBookID] = oBooks[iBookID];
                }

                if (CanCovert(this.rdoBooks.SelectedValue, typeof(int)))
                {
                    int iBookID = int.Parse(this.rdoBooks.SelectedValue);
                    oBooksFiltered[iBookID] = oBooks[iBookID];
                }

                foreach (ListItem item in this.chkBooks.Items)
                    if (item.Selected && CanCovert(item.Value, typeof(int)))
                    {
                        int iBookID = int.Parse(item.Value);
                        oBooksFiltered[iBookID] = oBooks[iBookID];
                    }
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
                this.dgBooks.DataSource = oBooksFiltered;
                this.dgBooks.DataBind();

                int iTotalLength = 0;
                int iAvgLength = 0;
                decimal dAvgPrice = 0;
                decimal dTotalPrice = 0;

                foreach (KeyValuePair<int, Book> kvp in oBooksFiltered)
                {
                    iTotalLength += kvp.Value.Length;
                    dTotalPrice += kvp.Value.Price;
                }
                if (oBooksFiltered.Count > 0)
                {
                    iAvgLength = iTotalLength / oBooksFiltered.Count;
                    dAvgPrice = dTotalPrice / oBooksFiltered.Count;
                }
                this.lblStats.Text = String.Format("Total Length: {0:n0} | Avg Length: {1:n0} | Total Price: {2:C} | Avg Price: {3:C}", iTotalLength, iAvgLength, dTotalPrice, dAvgPrice);
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
                for (int i = this.dgBooks.Items.Count - 1; i >= 0; i--)
                {
                    CheckBox chkSelections = (CheckBox)dgBooks.Items[i].FindControl("chkSelection");
                    if (chkSelections.Checked)
                    {
                        string sSelectedID = this.dgBooks.Items[i].Cells[0].Text;
                        oBooksFiltered.Remove(int.Parse(sSelectedID));
                        if (this.ddlBooks.SelectedValue == sSelectedID)
                            this.ddlBooks.ClearSelection();
                        if (this.rdoBooks.SelectedValue == sSelectedID)
                            this.rdoBooks.ClearSelection();
                        foreach (ListItem item in chkBooks.Items)
                            if (item.Value == sSelectedID)
                                item.Selected = false;
                    }
                }
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
                oBooksFiltered.Clear();
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
                this.lblSelection.Text = "You checked:<br/>";
                if (chkBooks.Items.Count > 0)
                {
                    foreach (ListItem item in chkBooks.Items)
                        if (item.Selected)
                            if (CanCovert(item.Value, typeof(int)))
                            {
                                this.lblSelection.Text += "\"" + oBooksFiltered[int.Parse(item.Value)].BookTitle + ",\" by " + oBooksFiltered[int.Parse(item.Value)].AuthorName + "<br/>";
                            }
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
                    this.lblSelection.Text = "You selected \"" + oBooksFiltered[iSelectedID].BookTitle + ",\" by " + oBooksFiltered[iSelectedID].AuthorName + " from the radio button list.";
                    ListUpdate();
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
                    this.lblSelection.Text = "You selected \"" + oBooksFiltered[iSelectedID].BookTitle + ",\" by " + oBooksFiltered[iSelectedID].AuthorName + " from the dropdown list.";
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
    }
}