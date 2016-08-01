using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class adduser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // save the data
            JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer usersBll = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();
            if (usersBll.Insert(txtFirstname.Text, txtLastName.Text, txtEmail.Text, txtPassword.Text, Convert.ToInt32(txtUserLevel.Text)) == -1)
            {
                // error here
            }
            else
            {
                Response.Redirect("start");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("start");
        }
    }
}