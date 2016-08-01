using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class editProjectData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Int32 ProjectId = Convert.ToInt32( Request.QueryString["ProjectId"]);

                if (ProjectId != 0)
                {
                    JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer projectBLL = new JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer();
                    List<JWLTD.API.DatabaseLayer.TabProjects.RecordDef> projectlist = new List<JWLTD.API.DatabaseLayer.TabProjects.RecordDef>();
                    projectlist = projectBLL.GetProjectById(ProjectId);
                    if (projectlist.Count == 1)
                    {
                        txtProjectName.Text = projectlist[0].ProjectName;
                        txtDefinition.Text = projectlist[0].Definition;
                        txtOutline.Text = projectlist[0].Outline;

                        FillUserDropDown();
                        FillCustomerDropDown();
                    }
                }
            }
        }

        protected void FillUserDropDown()
        {
            int x;
            DropDownOwner.Items.Clear();
            DropDownOwner.Items.Add(new ListItem("Unassigned", "-1"));

            JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer userBLL = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef> userlist = new List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef>();
            userlist = userBLL.GetAllUsers();
            if (userlist.Count != 0)
            {
                for (x = 0; x < userlist.Count; x++)
                {
                    DropDownOwner.Items.Add(new ListItem(userlist[x].Firstname + " " + userlist[x].Lastname, userlist[x].pkUserId.ToString()));
                }
            }
        }

        protected void FillCustomerDropDown()
        {
            int x;
            DropDownCustomer.Items.Clear();
            DropDownCustomer.Items.Add(new ListItem("Unassigned", "-1"));

            JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customerBLL = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef> customerlist = new List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef>();
            customerlist = customerBLL.GetAll();
            if (customerlist.Count != 0)
            {
                for (x = 0; x < customerlist.Count; x++)
                {
                    DropDownCustomer.Items.Add(new ListItem(customerlist[x].CustomerName, customerlist[x].CustomerId.ToString()));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 ProjectId = Convert.ToInt32(Request.QueryString["ProjectId"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer projectBll = new JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabProjects.RecordDef> projectlist = new List<JWLTD.API.DatabaseLayer.TabProjects.RecordDef>();
            projectlist = projectBll.GetProjectById(ProjectId);
            if (projectlist.Count == 1)
            {
                projectBll.Update(ProjectId, txtProjectName.Text, txtDefinition.Text, txtOutline.Text, Convert.ToInt32(DropDownCustomer.SelectedValue), Convert.ToInt32(DropDownOwner.SelectedValue));
                Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("editProject.aspx?ProjectId=" + Request.QueryString["Projectid"]);
        }
    }
}