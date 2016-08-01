using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class addnewproject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack==false)
            {
                FillUserDropDown();
                FillCustomerDropDown();
            }
        }

        protected void FillUserDropDown()
        {
            int x;
            drpProjectOwner.Items.Clear();
            drpProjectOwner.Items.Add(new ListItem("Unassigned","-1"));

            JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer userBLL = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef> userlist = new List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef>();
            userlist = userBLL.GetAllUsers();
            if (userlist.Count != 0)
            {
                for (x = 0; x < userlist.Count; x++)
                {
                    drpProjectOwner.Items.Add(new ListItem(userlist[x].Firstname + " " + userlist[x].Lastname, userlist[x].pkUserId.ToString()));
                }
            }
        }

        protected void FillCustomerDropDown()
        {
            int x;
            drpCustomer.Items.Clear();
            drpCustomer.Items.Add(new ListItem("Unassigned", "-1"));

            JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customerBLL = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef> customerlist = new List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef>();
            customerlist = customerBLL.GetAll();
            if (customerlist.Count != 0)
            {
                for (x = 0; x < customerlist.Count; x++)
                {
                    drpCustomer.Items.Add(new ListItem(customerlist[x].CustomerName, customerlist[x].CustomerId.ToString()));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // save the data
            JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer projBll = new JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer();
            if (projBll.Insert(txtProjectName.Text, txtDefinition.Text, txtOutline.Text, Convert.ToInt32(drpCustomer.SelectedValue), Convert.ToInt32(drpProjectOwner.SelectedValue)) == -1)
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