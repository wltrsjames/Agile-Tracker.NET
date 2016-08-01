using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class editcustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Int32 CustomerId = Convert.ToInt32(Request.QueryString["CustomerId"]);

                if (CustomerId != 0)
                {
                    JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customerBLL = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
                    List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef> customerlist = new List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef>();
                    customerlist = customerBLL.GetCustomerById(CustomerId);
                    if (customerlist.Count == 1)
                    {
                        txtCustomerName.Text = customerlist[0].CustomerName;
                        txtCompanyName.Text = customerlist[0].CompanyName;
                        txtCompanyAddress.Text = customerlist[0].CompanyAddress;
                        txtCompanyPostcode.Text = customerlist[0].CompanyPostcode;
                        txtCompanyPhone.Text = customerlist[0].CompanyPhone;
                        txtMobile.Text = customerlist[0].Mobile;
                        txtEmail.Text = customerlist[0].Email;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 CustomerId = Convert.ToInt32(Request.QueryString["CustomerId"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customerBll = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef> customerlist = new List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef>();
            customerlist = customerBll.GetCustomerById(CustomerId);
            if (customerlist.Count == 1)
            {
                customerBll.Update(CustomerId, txtCustomerName.Text, txtCompanyName.Text,txtCompanyAddress.Text,txtCompanyPostcode.Text,txtCompanyPhone.Text,txtMobile.Text,txtEmail.Text);
                Response.Redirect("start");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("start");
        }
    }
}