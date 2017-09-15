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
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];



                Book oTestBook = new BooksCompanion.Book();

                oTestBook.BookTitle = "The Blank Slate";
                oTestBook.AuthorName = "Steven Pinker";
                oTestBook.Length = 300;
                oTestBook.IsOnAmazon = true;
                oTestBook.BookID = 0;

                oTestBook.SaveBook(sCnxn, sLogPath);


              
                //


                if (!IsPostBack)
                {
                    this.BindData();
                    Book oNewTestBook = new BooksCompanion.Book(sCnxn, sLogPath, 2);
                    lblTest.Text = "\"" + oNewTestBook.BookTitle + "\" by " + oNewTestBook.AuthorName;
                }


               

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }

        private void BindData()
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, sLogPath);

                this.dgBooks.DataSource = oBooks.Values;
                this.dgBooks.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = "BindData:" + ex.Message;
            }
        }
    }
}