using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Agile_Tracker.net
{
    public partial class LoggedInMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Label mpLabel = (Label)FindControl("lblUsername2");
                mpLabel.Text = "Username:" + Session["Username"];
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}