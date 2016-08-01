using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JWLTD.API.DatabaseLayer;
using System.Web.Security;

namespace Agile_Tracker.net
{
    public partial class Login1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer userdb = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef> userlist = new List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef>();
            userlist = userdb.GetUserByEmail(txtUsername.Text, txtPassword.Text);

            if (userlist.Count == 1)
            {
                lblError.Visible = false;
                Session["Username"] = txtUsername.Text;
                FormsAuthentication.RedirectFromLoginPage(txtUsername.Text, true);
            }
            else
            {
                lblError.Visible = true;
                lblError.Text= "* Username or password incorrect";
            }
        }
    }
}