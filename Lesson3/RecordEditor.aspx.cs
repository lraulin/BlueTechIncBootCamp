using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Web.UI.WebControls;
using BooksCompanion;

namespace Lesson3
{
    public partial class RecordEditor : System.Web.UI.Page
    {
        private static string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private static string sLogPath = ConfigurationManager.AppSettings["LogPath"];
        private static Books oBooks = new Books(sCnxn, sLogPath);
        private static bool bDeleteClicked = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ListUpdate();
        }

        protected void ListUpdate()
        {
            this.ddlBookEditor.DataSource = oBooks.Values;
            this.ddlBookEditor.DataTextField = "BookTitle";
            this.ddlBookEditor.DataValueField = "BookID";
            this.ddlBookEditor.DataBind();
            this.ddlBookEditor.Items.Insert(0, new ListItem("--Select--"));
        }

        protected void FieldsClear()
        {
            this.txtAuthorName.Text = "";
            this.txtBookID.Text = "New Record";
            this.txtBookTitle.Text = "";
            this.txtDateCreated.Text = "Current Time";
            this.drdIsOnAmazon.SelectedValue = "";
            this.txtLength.Text = "";
            this.txtPrice.Text = "";
        }

        private Boolean CanCovert(String value, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.IsValid(value);
        }

        protected void btnSaveRecord_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    int iLength = 0;
                    if (CanCovert(this.txtLength.Text.Replace(",", string.Empty), typeof(int)))
                    {
                        iLength = int.Parse(this.txtLength.Text.Replace(",", string.Empty));
                        if (iLength > 1000000)
                        {
                            this.lblRecordEditor.Text = "Length out of range! Enter a value between 1 and 1,000,000.";
                            return;
                        }
                    }
                    else
                    {
                        this.lblRecordEditor.Text = "Length out of range! Enter a value between 1 and 1,000,000.";
                        return;
                    }

                    decimal dPrice = 0;
                    if (CanCovert((this.txtPrice.Text.Replace("$", string.Empty).Replace(",", string.Empty)), typeof(decimal)))
                    {
                        dPrice = decimal.Parse(this.txtPrice.Text.Replace("$", string.Empty).Replace(",", string.Empty));
                        if (dPrice > 1000000)
                        {
                            this.lblRecordEditor.Text = "Price out of range! Enter a value between $0.00 and $1,000,000.00.";
                            return;
                        }
                    }
                    else
                    {
                        this.lblRecordEditor.Text = "Price out of range! Enter a value between $0.00 and $1,000,000.00.";
                        return;
                    }

                    Book oBook = new Book();
                    if (this.txtBookID.Text == "New Record")
                        oBook.BookID = 0;
                    else
                        oBook.BookID = int.Parse(this.txtBookID.Text); 
                    oBook.AuthorName = this.txtAuthorName.Text;
                    oBook.BookTitle = this.txtBookTitle.Text;
                    oBook.IsOnAmazon = Boolean.Parse(this.drdIsOnAmazon.Text);
                    oBook.Length = iLength;
                    oBook.Price = dPrice;
                    oBook.Save(sCnxn, sLogPath);
                    this.lblRecordEditor.Text = "Save Successful!";
                    ListUpdate();
                    this.ddlBookEditor.SelectedIndex = this.ddlBookEditor.Items.Count - 1;
                    int iNewBookID = int.Parse(this.ddlBookEditor.SelectedValue);
                    Book oNewBook = new Book();
                    oNewBook = oBooks[iNewBookID];
                    this.txtBookID.Text = oBook.BookID.ToString();
                    this.txtLength.Text = String.Format("{0:n0}", oBook.Length);
                    this.txtPrice.Text = String.Format("{0:C}", oBook.Price);
                    this.txtDateCreated.Text = oNewBook.DateCreated.ToString();
                }
                catch (Exception ex)
                {
                    this.lblRecordEditor.Text = "btnSaveRecord_Click: " + ex.Message;
                    this.lblRecordEditor.Text += "\nRecord not saved!";
                } 
            } else
            {
                this.lblRecordEditor.Text = "Record not saved. Please fill all required fields.";
            }
        }

        protected void ddlBookEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblRecordEditor.Text = "";
                if (CanCovert(this.ddlBookEditor.SelectedItem.Value, typeof(int)))
                {
                    int iSearchID = Convert.ToInt32(this.ddlBookEditor.SelectedItem.Value);
                    Book oBook = new Book();
                    oBook = oBooks[iSearchID];

                    if (Convert.ToBoolean(oBook.BookID))
                    {
                        this.txtAuthorName.Text = oBook.AuthorName;
                        this.txtBookID.Text = oBook.BookID.ToString();
                        this.txtBookTitle.Text = oBook.BookTitle;
                        this.txtDateCreated.Text = oBook.DateCreated;
                        this.drdIsOnAmazon.Text = oBook.IsOnAmazon.ToString();
                        this.txtLength.Text = String.Format("{0:n0}", oBook.Length);
                        this.txtPrice.Text = String.Format("{0:C}", oBook.Price);
                    }
                }
            }
            catch (Exception ex)
            {
                this.lblRecordEditor.Text = "ddlBookEditor_SelectedIndexChanged: " + ex.Message;
            }
        }

        protected void btnNewRecord_Click(object sender, EventArgs e)
        {
            try
            {
                FieldsClear();
                this.ddlBookEditor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.lblRecordEditor.Text = "btnNewRecord: " + ex.Message;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (!bDeleteClicked)
            {
                if (this.txtBookID.Text != "New Record")
                {
                    this.lblRecordEditor.Text = "Preparing to delete \"" + txtBookTitle.Text + "\" by " + txtAuthorName.Text + "...";
                    this.btnDelete.CssClass = "btn btn-danger";
                    this.btnDelete.Text = "ARE YOU SURE???";
                    bDeleteClicked = true;
                }
                else
                    lblRecordEditor.Text = "No record selected! Delete operation cancelled.";
            }
            else
            {
                try
                {
                    int iSearchID = int.Parse(this.ddlBookEditor.SelectedItem.Value);
                    Book oBook = new Book();
                    oBook = oBooks[iSearchID];
                    oBook.Delete(sCnxn, sLogPath);
                    FieldsClear();
                    ListUpdate();
                    bDeleteClicked = false;
                    this.btnDelete.CssClass = "btn btn-warning";
                    this.btnDelete.Text = "Delete Record";
                    this.lblRecordEditor.Text = "Record deleted.";
                }
                catch (Exception ex)
                {
                    lblRecordEditor.Text = "btnDelete_Click: " + ex.Message;
                }
            }
        }
    }
}