using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            {
                Books oBooks = new Books(sCnxn, sLogPath);

                this.ddlBookEditor.DataSource = oBooks.Values;
                this.ddlBookEditor.DataTextField = "BookTitle";
                this.ddlBookEditor.DataValueField = "BookID";
                this.ddlBookEditor.DataBind();
                this.ddlBookEditor.Items.Insert(0, new ListItem("--Select--"));
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
           
            }
            catch (Exception ex)
            {
                Response.Write("UpdateSelection:" + ex.Message);
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