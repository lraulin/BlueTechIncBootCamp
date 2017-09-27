using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using BooksCompanion;
using System.Configuration;
using System.ComponentModel;

namespace Lesson3
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];
        private List<int> iSelections = new List<int>();

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
            }
            catch (Exception ex)
            {
                Response.Write("BindData: " + ex.Message);
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
                if (CanCovert(ddlBooks.SelectedValue, typeof(int)))
                {
                    iSelections.Add(int.Parse(ddlBooks.SelectedValue));
                }
                if (CanCovert(rdoBooks.SelectedValue, typeof(int)))
                {
                    iSelections.Add(int.Parse(rdoBooks.SelectedValue));
                }

                foreach (ListItem item in chkBooks.Items)
                {
                    if (item.Selected)
                    {
                        if (CanCovert(item.Value, typeof(int)))
                        {
                            iSelections.Add(int.Parse(item.Value));
                        }
                    }
                }

                Books oBooks = new Books(sCnxn, sLogPath, iSelections);

                this.dgBooks.DataSource = oBooks.Values;
                this.dgBooks.DataBind();

                lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
            }
            catch (Exception ex)
            {
                Response.Write("BindData:" + ex.Message);
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

                this.lblSelection.Text = ex.Message;
            }
        }

        protected void rdoBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                Books oBooks = new Books(sCnxn, sLogPath);

                this.lblSelection.Text = "You have selected \"" + oBooks[int.Parse(rdoBooks.SelectedItem.Value)].BookTitle + ",\" by " + oBooks[int.Parse(rdoBooks.SelectedItem.Value)].AuthorName + ".";
                BindSelections();
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
                Books oBooks = new Books(sCnxn, sLogPath);

                this.lblSelection.Text = "You have selected \"" + oBooks[int.Parse(ddlBooks.SelectedItem.Value)].BookTitle + ",\" by " + oBooks[int.Parse(ddlBooks.SelectedItem.Value)].AuthorName + ".";
                BindSelections();
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
            DataBind();
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            lblSelection.Text = "RESET!";
            rdoBooks.ClearSelection();
            chkBooks.ClearSelection();
            ddlBooks.ClearSelection();
            BindSelections();
        }

        protected void btnRemoveSelected_Click(object sender, EventArgs e)
        {

        }

        protected void btnSaveRecord_Click(object sender, EventArgs e)
        {
            Book oBook = new BooksCompanion.Book();
            try
            {
                if (txtBookID.Text == "")
                {
                    oBook.BookID = 0;
                }
                else
                {
                    oBook.BookID = Int32.Parse(txtBookID.Text);
                }
                oBook.AuthorName = txtAuthorName.Text;
                oBook.BookTitle = txtBookTitle.Text;
                oBook.IsOnAmazon = Boolean.Parse(drdIsOnAmazon.Text);
                oBook.Length = Int32.Parse(txtLength.Text);
                oBook.Save(sCnxn, sLogPath);
                PopulateWebControls();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void ddlBookEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CanCovert(this.ddlBookEditor.SelectedItem.Value, typeof(int)))
            {
                int iSearchID = Convert.ToInt32(this.ddlBookEditor.SelectedItem.Value);
                Book oBook = new Book(sCnxn, sLogPath, iSearchID);
                Response.Write(oBook.BookID);
                if (Convert.ToBoolean(oBook.BookID))
                {
                    txtAuthorName.Text = oBook.AuthorName;
                    txtBookID.Text = oBook.BookID.ToString();
                    txtBookTitle.Text = oBook.BookTitle;
                    txtDateCreated.Text = oBook.DateCreated;
                    drdIsOnAmazon.Text = oBook.IsOnAmazon.ToString();
                    txtLength.Text = oBook.Length.ToString();
                }
            }
            else
            {
                txtAuthorName.Text = txtBookID.Text = txtBookTitle.Text
                    = txtDateCreated.Text = txtLength.Text = "No Record";
                this.drdIsOnAmazon.SelectedValue = "";
            }
        }

        protected void btnNewRecord_Click(object sender, EventArgs e)
        {
            txtAuthorName.Text = "";
            txtBookID.Text = "0";
            txtBookTitle.Text = "";
            txtDateCreated.Text = "";
            drdIsOnAmazon.SelectedValue = "";
            txtLength.Text = "";
        }
    }
}