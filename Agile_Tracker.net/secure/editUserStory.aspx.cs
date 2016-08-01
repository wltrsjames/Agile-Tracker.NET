using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class editUserStory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Int32 UserStoryid = Convert.ToInt32(Request.QueryString["UserStoryid"]);

                if (UserStoryid != 0)
                {
                    JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer userStoryBLL = new JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer();
                    List<JWLTD.API.DatabaseLayer.TabUserStories.RecordDef> userStorylist = new List<JWLTD.API.DatabaseLayer.TabUserStories.RecordDef>();

                    userStorylist = userStoryBLL.GetUserStoryById(UserStoryid);
                    if (userStorylist.Count == 1)
                    {
                        txtAceptCriteria.Text = userStorylist[0].AcceptanceCriteria;
                        txtPurpose.Text = userStorylist[0].Purpose;
                        txtRequest.Text = userStorylist[0].Request;
                        txtUserRole.Text = userStorylist[0].UserRole;
                        chkMVP.Checked = Convert.ToBoolean(userStorylist[0].MVP);
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 UserStoryId = Convert.ToInt32(Request.QueryString["UserStoryId"]);
            Int32 ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer userStoryBll = new JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabUserStories.RecordDef> userStorylist = new List<JWLTD.API.DatabaseLayer.TabUserStories.RecordDef>();

            userStorylist = userStoryBll.GetUserStoryById(UserStoryId);
            if (userStorylist.Count == 1)
            {
                userStoryBll.Update(UserStoryId, ProjectId, txtUserRole.Text, txtRequest.Text, txtPurpose.Text, txtAceptCriteria.Text, Convert.ToInt32(chkMVP.Checked));
                Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
        }
    }
}