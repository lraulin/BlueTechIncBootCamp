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

                Books oBooks = new Books(sCnxn, sLogPath, 2);

                this.dgBooks.DataSource = oBooks.Values;
                this.dgBooks.DataBind();

            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }
    }
}