using System;
using System.Configuration;
using School1Companion;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace School2
{
    public partial class PageTwo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                    string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                    Users oUsers = new Users(sCnxn, sLogPath);

                    this.drdUsers.DataSource = oUsers.Values;
                    this.drdUsers.DataTextField = "LastName";
                    this.drdUsers.DataValueField = "UserID";
                    this.drdUsers.DataBind();

                    this.chkUsers.DataSource = oUsers.Values;
                    this.chkUsers.DataTextField = "LastName";
                    this.chkUsers.DataValueField = "UserID";
                    this.chkUsers.DataBind();

                    this.lstUsers.DataSource = oUsers.Values;
                    this.lstUsers.DataTextField = "LastName";
                    this.lstUsers.DataValueField = "UserID";
                    this.lstUsers.DataBind();

                    foreach (User oUser in oUsers.Values)
                    {
                        ListItem i = new ListItem();
                        i.Text = oUser.LastName + ", " + oUser.FirstName;
                        i.Value = oUser.UserID.ToString();
                        this.rdUsers.Items.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {

                this.lblResult.Text = ex.Message;
            }
        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblResult.Text = "";
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Users oUsers = new Users(sCnxn, sLogPath);
                List<User> oList = new List<School1Companion.User>();
                List<User> oListFiltered = new List<School1Companion.User>();
                oList.AddRange(oUsers.Values);

                oListFiltered = oList.FindAll(delegate (User u1) { return u1.LastName.ToUpper().Contains(this.txtSearch.Text.ToUpper()); });

                this.lstUsers.DataSource = oListFiltered;
                this.lstUsers.DataTextField = "LastName";
                this.lstUsers.DataValueField = "UserID";
                this.lstUsers.DataBind();

                foreach (ListItem oItem in this.chkUsers.Items)
                {
                    if (oItem.Selected)
                    {
                        this.lblResult.Text += oItem.Text;
                    }
                }
            }
            catch (Exception ex)
            {

                this.lblResult.Text = ex.Message;
            }
        }
    }
}