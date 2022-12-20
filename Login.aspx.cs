using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Yuan.DA;
using Yuan.BL;
using System.Web.Script.Serialization;

namespace Yuan
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    txtUserName.Value = Request.Cookies["UserName"].Value;
                    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                }
            }
        }

       
        protected void btnSave_ServerClick(object sender, EventArgs e)
        {
            if (txtUserName.Value.ToString() != "" && txtPassword.Value.ToString() != "")
            {
                try
                {
                    if (remember.Checked)
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
                    }
                    else
                    {
                        Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
                    }

                    if (GlobalFunctions.chkAdminLogin(txtUserName.Value, txtPassword.Value))
                    {
                        if (Session["UserID"] != null)
                        {
                            //ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), "BindMenu(" + Session["UserID"] + ");", true);
                            Response.Redirect("Dashboard.aspx");
                        }
                        else
                        {
                            // clear();
                            Response.Redirect("login.aspx");
                        }
                    }
                    else
                    {
                        pnlError.Visible = true;
                        ltrError.InnerText = "Authentication failed! Not a Valid User";
                    }

                }
                catch (System.Threading.ThreadAbortException)
                {

                }
                catch (Exception ex)
                {
                    pnlError.Visible = true;
                    ltrError.InnerText = ex.Message;
                }

            }
        }
    }
}