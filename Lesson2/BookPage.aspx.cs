using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using BooksCompanion;

namespace Lesson2
{
    public partial class BookPage : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];

        protected void Page_Load(object sender, EventArgs e)
        {
      
        }

        protected void btnSearchID_Click(object sender, EventArgs e)
        {
            try
            {
                int iSearchID = Convert.ToInt32(this.txtSearchID.Text);
                lblSearch.Text = "Searching for book ID " + iSearchID.ToString();
                txtSearchID.Text = "";
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
                else
                {
                    txtAuthorName.Text = txtBookID.Text = txtBookTitle.Text
                        = txtDateCreated.Text = drdIsOnAmazon.Text = txtLength.Text = "No Record";
                }
            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message;
            }
        }

        protected void btnSaveRecord_Click(object sender, EventArgs e)
        {
            lblSearch.Text = "";
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

                lblMessage.Text = "Save successful.";

            }
            catch (Exception ex)
            {
                this.lblMessage.Text = ex.Message;
            }
        }
    }
}