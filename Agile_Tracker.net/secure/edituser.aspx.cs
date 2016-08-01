using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Agile_Tracker.net.secure
{
    public partial class edituser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                Int32 UserId = Convert.ToInt32(Request.QueryString["UserId"]);

                if (UserId != 0) { 
                    JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer userBLL = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();
                    List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef> userlist = new List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef>();
                    userlist = userBLL.GetUserByUserId(UserId);
                    if (userlist.Count == 1)
                    {
                        txtFirstname.Text = userlist[0].Firstname;
                        txtLastName.Text = userlist[0].Lastname;
                        txtEmail.Text = userlist[0].Email;
                        txtUserLevel.Text = userlist[0].Userlevel.ToString();                        
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            Int32 UserId = Convert.ToInt32(Request.QueryString["UserId"]);

            // save the data
            JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer userBll = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef> userlist = new List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef>();
            userlist = userBll.GetUserByUserId(UserId);
            if (userlist.Count == 1)
            {
                userBll.Update(UserId, txtFirstname.Text, txtLastName.Text, txtEmail.Text, userlist[0].Password, Convert.ToInt32(txtUserLevel.Text));
                Response.Redirect("start");                
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("start");
        }
    }
}