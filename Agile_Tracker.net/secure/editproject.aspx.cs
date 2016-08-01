using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class editproject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {

            }
        }

        protected void btnEditProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("editprojectdata.aspx?ProjectId="+Request.QueryString["ProjectId"]);
        }

        protected void btnAddMilestone_Click(object sender, EventArgs e)
        {
            Response.Redirect("addmilestone.aspx?ProjectId="+Request.QueryString["ProjectId"]);
        }

        protected void btnAddUserStory_Click(object sender, EventArgs e)
        {
            Response.Redirect("adduserstory.aspx?ProjectId="+Request.QueryString["ProjectId"]);
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("start");
        }
    }
}