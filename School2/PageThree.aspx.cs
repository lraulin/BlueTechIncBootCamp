using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using School1Companion;

namespace School2
{
    public partial class PageThree : System.Web.UI.Page
    {
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

        public void dgUsers_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            dgUsers.CurrentPageIndex = e.NewPageIndex;
            this.BindData();
        }

        private void dgUsers_SortCommand(object source, DataGridCommandEventArgs e)
        {

        }

        private void BindData()
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Users oUsers = new Users(sCnxn, sLogPath);

                //List<string> oSample = new List<string>();
                //oSample.Add("one");
                //oSample.Add("two");
                //oSample.Add("three");

                this.dgUsers.DataSource = oUsers.Values;
                this.dgUsers.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = "BindData:" + ex.Message;
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridItem oItem in dgUsers.Items)
                {
                    this.lblError.Text += oItem.Cells[0].Text;
                    CheckBox chkS = (CheckBox)oItem.FindControl("chkSelection");
                    this.lblError.Text += chkS.Checked.ToString() + "<br />";

                }
            }
            catch (Exception ex)
            {
                this.lblError.Text = "btnGo:" + ex.Message;
            }
        }
    }
}