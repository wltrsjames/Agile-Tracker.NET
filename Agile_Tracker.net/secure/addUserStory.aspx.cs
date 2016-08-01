using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class addUserStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 ProjectId = Convert.ToInt32(Request.QueryString["Projectid"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer userStoriesBll = new JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer();

            if (userStoriesBll.Insert(ProjectId, txtUserRole.Text, txtRequest.Text, txtPurpose.Text, txtAceptCriteria.Text,Convert.ToInt32(chkMVP.Checked)) == -1)
            {
                // error here
            }
            else
            {
                Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
        }
    }
}