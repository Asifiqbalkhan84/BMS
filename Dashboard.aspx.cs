using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yuan
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["UserID"] as string))
                {
                    ltrUserName.Text = Session["UName"].ToString().Trim();
                    DateTime today = DateTime.Today;
                    ltrDate.Text = today.ToString("dddd, dd MMMM yyyy");
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}