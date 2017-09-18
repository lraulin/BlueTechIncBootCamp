using System;
using System.Configuration;
using BooksCompanion;

namespace Lesson2
{
    public partial class BooksGrid : System.Web.UI.Page
    {
        private string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
        private string sLogPath = ConfigurationManager.AppSettings["LogPath"];

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                if (!IsPostBack)
                {
                    this.BindData();
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
                Books oBooks = new Books(sCnxn, sLogPath);

                this.dgBooks.DataSource = oBooks.Values;
                this.dgBooks.DataBind();

                lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
            }
            catch (Exception ex)
            {
                this.lblError.Text = "BindData:" + ex.Message;
            }
        }

        protected void btnTitleSearch_Click(object sender, EventArgs e)
        {
            if (txtTitleSearch.Text == "")
            {
                this.BindData();
            }
            else
            {
                try
                {
                    Books oBooks = new Books(sCnxn, sLogPath, txtTitleSearch.Text);

                    this.dgBooks.DataSource = oBooks.Values;
                    this.dgBooks.DataBind();

                    lblTotalPrice.Text = "Total Price: $" + oBooks.TotalPrice.ToString("0.##");
                    lblAveragePrice.Text = "Average Price: $" + oBooks.AveragePrice.ToString("0.##");
                }
                catch (Exception ex)
                {
                    this.lblError.Text = "btnTitleSearch_Click:" + ex.Message;
                }
            }
        }
    }
}