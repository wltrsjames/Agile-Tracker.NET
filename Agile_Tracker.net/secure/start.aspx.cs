using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddProject_Click(object sender, EventArgs e)
        {
            Response.Redirect("addnewproject.aspx");
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("adduser.aspx");
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            Response.Redirect("addcustomer.aspx");
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        // Retrieve the LinkButton control from the first column.
        //        Label customerid = (Label)e.Row.FindControl("lblCustomerId");
        //        Label customername = (Label)e.Row.FindControl("lblCustomerName");
        //        Label ownerid = (Label)e.Row.FindControl("lblOwnerId");
        //        Label ownername = (Label)e.Row.FindControl("lblOwnerName");

        //        if (customername != null)
        //        {
        //            // look up the customer name
        //            //customername.Text = GetCustomerName(Convert.ToInt32(customerid));
        //        }
        //    }
        //}

        //protected String GetCustomerName(Int32 CustomerId)
        //{
        //    String CustomerName = "";
        //    JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customersBLL = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
        //    List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef> customerslist = new List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef>();
        //    customerslist = customersBLL.GetCustomerById(CustomerId);
        //    if (customerslist.Count == 1) {
        //        return customerslist[0].CustomerName;
        //    }

        //    return CustomerName;
        //}
    }
}