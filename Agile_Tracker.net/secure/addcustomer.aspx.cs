using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class addcustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // save the data
            JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customerBll = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
            if (customerBll.Insert(txtCustomerName.Text,txtCompanyName.Text,txtCompanyAddress.Text,txtCompanyPostcode.Text,txtCompanyPhone.Text,txtMobile.Text,txtEmail.Text) == -1)
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