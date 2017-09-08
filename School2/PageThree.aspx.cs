using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace School2
{
    public partial class PageThree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                SqlConnection oCnxn = new SqlConnection(sCnxn);

                SqlCommand oCmd = new SqlCommand();
                oCmd.Connection = oCnxn;
                oCmd.CommandText = "spUserInfoFetchAll";

                DataTable dtUser = new DataTable();
                SqlDataAdapter daUser = new SqlDataAdapter();
                daUser.SelectCommand = oCmd;

                oCnxn.Open();
                daUser.SelectCommand.ExecuteNonQuery();
                daUser.Fill(dtUser);
                oCnxn.Close();

                this.dgUsers.DataSource = dtUser;
                this.dgUsers.DataBind();
            }
            catch (Exception ex)
            {
                this.lblError.Text = ex.Message;
            }
        }
    }
}