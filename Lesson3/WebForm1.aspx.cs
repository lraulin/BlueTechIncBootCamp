using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BooksCompanion;
using System.Data;

namespace Lesson3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];
        private static List<int> iSelections = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateWebControls();
            }
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

                this.ddlBookEditor.DataSource = oBooks.Values;
                this.ddlBookEditor.DataTextField = "BookTitle";
                this.ddlBookEditor.DataValueField = "BookID";
                this.ddlBookEditor.DataBind();
                this.ddlBookEditor.Items.Insert(0, new ListItem("--Select--"));

                ddlBooks.Items.Insert(0, new ListItem("--Select--"));

                ddl2.Items.Add("Red");
                ddl2.Items.Add("Blue");
                ddl2.Items.Add("Green");

                Response.Write(rdoBooks.SelectedValue.ToString());
            }
            catch (Exception ex)
            {
                Response.Write("PopulateWebControls: " + ex.Message);
            }
        }

        private Boolean CanCovert(String value, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.IsValid(value);
        }

        private void BindSelections()
        {
            try
            {
                iSelections.Clear();
                // Add dropdown list selection
                if (CanCovert(ddlBooks.SelectedValue, typeof(int)))
                    iSelections.Add(int.Parse(ddlBooks.SelectedValue));

                // Add radio list selection
                if (CanCovert(rdoBooks.SelectedValue, typeof(int)))
                    iSelections.Add(int.Parse(rdoBooks.SelectedValue));

                // Add checkbox list selection(s)
                foreach (ListItem item in chkBooks.Items)
                {
                    if (item.Selected && CanCovert(item.Value, typeof(int)))
                        iSelections.Add(int.Parse(item.Value));
                }

                Books oBooks = new Books(sCnxn, sLogPath);
                List<Book> oList = new List<Book>();
                List<Book> oListFiltered = new List<Book>();
                oList.AddRange(oBooks.Values);
                oListFiltered = oList.FindAll(delegate (Book b1) { return iSelections.Contains(b1.BookID); });
                this.dgBooks.DataSource = oListFiltered;
                this.dgBooks.DataBind();

                lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
            }
            catch (Exception ex)
            {
                Response.Write("BindSelections:" + ex.Message);
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

                lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
            }
            catch (Exception ex)
            {
                Response.Write("UpdateSelection:" + ex.Message);
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
                BindSelections();
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
                if (rdoBooks.SelectedValue != "")
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
                } else
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

        protected void ddl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                DataBind();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "ddl2_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
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
                this.lblSelection.Text = "Calendar1_DayRender: " + ex.Message;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                lblSelection.Text = "RESET!";
                lblRecordEditor.Text = "";
                rdoBooks.ClearSelection();
                chkBooks.ClearSelection();
                ddlBooks.ClearSelection();
                BindSelections();
            }
            catch (Exception ex)
            {
                this.lblSelection.Text = "ImageButton1_Click: " + ex.Message;
            }
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            try
            {
                iSelections = iSelections.Distinct<int>().ToList<int>();
                for (int i = dgBooks.Items.Count - 1; i >= 0; i--)
                {
                    CheckBox chkS = (CheckBox)dgBooks.Items[i].FindControl("chkSelection");
                    if (chkS.Checked)
                    {
                        string sSelectedID = dgBooks.Items[i].Cells[0].Text;
                        int iSelectedID = int.Parse(sSelectedID);
                        iSelections.Remove(int.Parse(sSelectedID));
                        Response.Write("ID: " + i);
                        if (ddlBooks.SelectedValue == sSelectedID)
                            ddlBooks.SelectedIndex = 0;
                        if (rdoBooks.SelectedValue == sSelectedID)
                            rdoBooks.SelectedIndex = 0;
                        foreach (ListItem item in chkBooks.Items)
                        {
                            if (item.Value == sSelectedID)
                                item.Selected = false;
                        }
                    }
                }
                UpdateSelection();
            }
            catch (Exception ex)
            {

                Response.Write("btnRemoveSelected: " + ex.Message);
            }
        }

        protected void btnSaveRecord_Click(object sender, EventArgs e)
        {
            Book oBook = new BooksCompanion.Book();
            try
            {
                oBook.BookID = Int32.Parse(txtBookID.Text);
                oBook.AuthorName = txtAuthorName.Text;
                oBook.BookTitle = txtBookTitle.Text;
                oBook.IsOnAmazon = Boolean.Parse(drdIsOnAmazon.Text);
                oBook.Length = Int32.Parse(txtLength.Text);
                txtPrice.Text = txtPrice.Text.Replace("$", string.Empty);
                oBook.Price = decimal.Parse(txtPrice.Text);
                oBook.Save(sCnxn, sLogPath);
                PopulateWebControls();
                BindSelections();
                lblRecordEditor.Text = "Save Successful!";
            }
            catch (Exception ex)
            {
                Response.Write("btnSaveRecord_Click: " + ex.Message);
            }
        }

        protected void ddlBookEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblRecordEditor.Text = "";
                if (CanCovert(this.ddlBookEditor.SelectedItem.Value, typeof(int)))
                {
                    int iSearchID = Convert.ToInt32(this.ddlBookEditor.SelectedItem.Value);
                    Book oBook = new Book(sCnxn, sLogPath, iSearchID);
                    if (Convert.ToBoolean(oBook.BookID))
                    {
                        txtAuthorName.Text = oBook.AuthorName;
                        txtBookID.Text = oBook.BookID.ToString();
                        txtBookTitle.Text = oBook.BookTitle;
                        txtDateCreated.Text = oBook.DateCreated;
                        drdIsOnAmazon.Text = oBook.IsOnAmazon.ToString();
                        txtLength.Text = oBook.Length.ToString();
                        txtPrice.Text = String.Format("{0:C}", oBook.Price);
                    }
                }
                else
                {
                    txtAuthorName.Text = txtBookID.Text = txtBookTitle.Text
                        = txtDateCreated.Text = txtLength.Text = "No Record";
                    this.drdIsOnAmazon.SelectedValue = "";
                }
            }
            catch (Exception ex)
            {
                Response.Write("ddlBookEditor_SelectedIndexChanged: " + ex.Message);
            }
        }

        protected void btnNewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                txtAuthorName.Text = "";
                txtBookID.Text = "0";
                txtBookTitle.Text = "";
                txtDateCreated.Text = "";
                drdIsOnAmazon.SelectedValue = "";
                txtLength.Text = "";
            }
            catch (Exception ex)
            {
                Response.Write("btnNewRecord: " + ex.Message);
            }
        }

    }
}