using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using Yuan.BL;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace Yuan
{
    public partial class Site : System.Web.UI.MasterPage
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Session["UserID"] as string))
                {
                    //ltrRole.Text = Session["UserType"].ToString().Trim();
                    //ltUserName.Text = Session["UName"].ToString().Trim();
                    
                    //ltrRole.Text = Session["UserRole"].ToString().Trim();
                    //ltrUserRole.Text = Session["UserRole"].ToString().Trim();
                    //lnkProfile.ImageUrl = "/img/faces/fase1.jpg";//"AddUser.aspx?ID=" + Session["UserID"].ToString();
                    //lnkProfile2.HRef = "AddUser.aspx?ID=" + Session["UserID"].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "BindMenu(" + Session["UserID"] + ");", true);
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        protected void lnklogout_ServerClick(object sender, EventArgs e)
        {
            Logout();
        }
        private void Logout()
        {
            Session.Abandon();
            Session.Remove("UserID");
            Session.Remove("UserName");
            Session.Remove("UserType");
            Session.Remove("UserRole");
            Session.Clear();
            Response.Redirect("login.aspx");
        }

    }
}