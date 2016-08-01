﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class AddMilestone : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 ProjectId = Convert.ToInt32(Request.QueryString["Projectid"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer mileBll = new JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer();

            if (mileBll.Insert(ProjectId, txtMileDesc.Text, Convert.ToInt32(txtHoursSpent.Text), Convert.ToInt32(txtEstCost.Text), Convert.ToInt32(txtStatus.Text), Convert.ToInt32(txtHoursSpent.Text)) == -1)
            {
                // error here
            }
            else
            {
                Response.Redirect("editProject.aspx?ProjectId="+ Request.QueryString["Projectid"]);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
        }
    }
}