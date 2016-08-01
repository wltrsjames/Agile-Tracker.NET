using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class editMilestone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Int32 MilestoneId = Convert.ToInt32(Request.QueryString["MilestoneId"]);

                if (MilestoneId != 0)
                {
                    JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer milestoneBLL = new JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer();
                    List<JWLTD.API.DatabaseLayer.TabProjectMilestones.RecordDef> milestonelist = new List<JWLTD.API.DatabaseLayer.TabProjectMilestones.RecordDef>();
                    milestonelist = milestoneBLL.GetMilestoneById(MilestoneId);
                    if (milestonelist.Count == 1)
                    {
                        txtEstCost.Text = Convert.ToString(milestonelist[0].EstimatedCost);
                        txtEstHours.Text = Convert.ToString(milestonelist[0].EstimatedHours);
                        txtHoursSpent.Text = Convert.ToString(milestonelist[0].HoursSpent);
                        txtMileDesc.Text = milestonelist[0].MilestoneDescription;
                        txtStatus.Text = Convert.ToString(milestonelist[0].Status);
                        
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
           Int32 MilestoneId = Convert.ToInt32(Request.QueryString["MilestoneId"]);
           Int32 ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer milestonesBll = new JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabProjectMilestones.RecordDef> milestoneslist = new List<JWLTD.API.DatabaseLayer.TabProjectMilestones.RecordDef>();

            milestoneslist = milestonesBll.GetMilestoneById(MilestoneId);
            if (milestoneslist.Count == 1)
            {
                milestonesBll.Update(MilestoneId, ProjectId, txtMileDesc.Text, Convert.ToInt32(txtEstHours.Text), Convert.ToInt32(txtEstCost.Text), Convert.ToInt32(txtStatus.Text), Convert.ToInt32(txtHoursSpent.Text));
                Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
        }
    }
}