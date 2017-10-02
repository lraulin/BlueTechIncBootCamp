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
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];
        private static List<int> iSelections = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PopulateList();
        }

        protected void PopulateList()
        {
            Books oBooks = new Books(sCnxn, sLogPath);
            this.ddlBookEditor.DataSource = oBooks.Values;
            this.ddlBookEditor.DataTextField = "BookTitle";
            this.ddlBookEditor.DataValueField = "BookID";
            this.ddlBookEditor.DataBind();
            this.ddlBookEditor.Items.Insert(0, new ListItem("--Select--"));
        }

        private Boolean CanCovert(String value, Type type)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.IsValid(value);
        }

        protected void btnSaveRecord_Click(object sender, EventArgs e)
        {
            try
            {
                Book oBook = new BooksCompanion.Book();
                oBook.BookID = Int32.Parse(txtBookID.Text);
                oBook.AuthorName = this.txtAuthorName.Text;
                oBook.BookTitle = this.txtBookTitle.Text;
                oBook.IsOnAmazon = Boolean.Parse(drdIsOnAmazon.Text);
                oBook.Length = Int32.Parse(txtLength.Text);
                this.txtPrice.Text = this.txtPrice.Text.Replace("$", string.Empty);
                oBook.Price = decimal.Parse(txtPrice.Text);
                oBook.Save(sCnxn, sLogPath);
                this.lblRecordEditor.Text = "Save Successful!";
                PopulateList();
            }
            catch (Exception ex)
            {
                this.lblRecordEditor.Text = "btnSaveRecord_Click: " + ex.Message;
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
                    Book oBook = new Book(sCnxn, sLogPath, iSearchID);
                    if (Convert.ToBoolean(oBook.BookID))
                    {
                        this.txtAuthorName.Text = oBook.AuthorName;
                        this.txtBookID.Text = oBook.BookID.ToString();
                        this.txtBookTitle.Text = oBook.BookTitle;
                        this.txtDateCreated.Text = oBook.DateCreated;
                        this.drdIsOnAmazon.Text = oBook.IsOnAmazon.ToString();
                        this.txtLength.Text = oBook.Length.ToString();
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
                this.txtAuthorName.Text = "";
                this.txtBookID.Text = "0";
                this.txtBookTitle.Text = "";
                this.txtDateCreated.Text = "";
                this.drdIsOnAmazon.SelectedValue = "";
                this.txtLength.Text = "";
                this.txtPrice.Text = "";
                this.ddlBookEditor.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                this.lblRecordEditor.Text = "btnNewRecord: " + ex.Message;
            }
        }
    }
}