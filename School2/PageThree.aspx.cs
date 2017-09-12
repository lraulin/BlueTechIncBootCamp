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

        public void dgUsers_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                // // One way to sort:
                //Users oUsers = new Users(sCnxn, sLogPath);
                //List<User> oUserList = new List<User>();

                //oUserList.AddRange(oUsers.Values);

                //if (e.SortExpression.ToUpper() == "FIRSTNAME")
                //    oUserList.Sort(delegate (User u1, User u2) { return u1.FirstName.CompareTo(u2.FirstName); });
                //if (e.SortExpression.ToUpper() == "LASTNAME")
                //    oUserList.Sort(delegate (User u1, User u2) { return u1.LastName.CompareTo(u2.LastName); });
                //if (e.SortExpression.ToUpper() == "USERID")
                //    oUserList.Sort(delegate (User u1, User u2) { return u1.UserID.CompareTo(u2.UserID); });


                // // Another way to sort:
                Users oUsers = new Users();
                DataTable dtUsers = oUsers.UsersList(sCnxn, sLogPath);
                DataView dvUsers = dtUsers.DefaultView;

                dvUsers.Sort = e.SortExpression;

                this.dgUsers.DataSource = dvUsers; //oUserList;
                this.dgUsers.DataBind();
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