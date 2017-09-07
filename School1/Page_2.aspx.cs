using System;
using System.Web.UI;

namespace School1
{
    public partial class Page_2 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Response.Write("Redirected  here");

            try
            {
                this.lbl8b.Text = this.Request.QueryString["ID"];
                this.lbl8b.Text = (int.Parse(this.Request.QueryString["ID"]) * 2).ToString();
                this.Response.Write("<br/>");
                this.Response.Write(Global.WorldID);
                this.lbl8d.Text = "<b>" + Global.WorldID / 2 + "</b>";
                this.lbl8f.Text = this.Cache["TeamName"].ToString();
            }
            catch (Exception ex)
            {
                this.Response.Write(ex.Message);
            }
        }
    }
}