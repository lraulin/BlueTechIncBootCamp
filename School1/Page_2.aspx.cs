using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School1
{
    public partial class Page_2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Redirected  here");

            try
            {
                lbl8b.Text = Request.QueryString["ID"];
                lbl8b.Text = (Int32.Parse(Request.QueryString["ID"]) * 2).ToString();
                Response.Write("<br/>");
                Response.Write(Global.WorldID);
                lbl8d.Text = "<b>" + (Global.WorldID / 2).ToString() + "</b>";
                lbl8f.Text = Cache["TeamName"].ToString();
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}