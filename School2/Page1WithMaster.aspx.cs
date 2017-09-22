using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BooksCompanion;

namespace School2
{
    public partial class Page1WithMaster : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Books oBooks = new Books(sCnxn, sLogPath);


            }
            catch (Exception ex)
            {
                Response.Write("BindData:" + ex.Message);
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            this.lblDate.Text = this.Calendar1.SelectedDate.ToShortDateString();
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

        }
    }
}