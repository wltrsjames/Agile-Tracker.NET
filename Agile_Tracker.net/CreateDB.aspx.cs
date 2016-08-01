using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JWLTD.API.DatabaseLayer;

namespace Agile_Tracker.net
{
    public partial class CrteateDB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // create user database
            JWLTD.API.DatabaseLayer.TabUsers.DataAccessLayer userdb = new JWLTD.API.DatabaseLayer.TabUsers.DataAccessLayer();
            userdb.CreateTable();

            // add users
            JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer userBLL = new JWLTD.API.DatabaseLayer.TabUsers.BusinessLogicLayer();            
            List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef> userlist = new List<JWLTD.API.DatabaseLayer.TabUsers.RecordDef>();
            userlist = userBLL.GetAllUsers();
            if (userlist.Count == 0)
            {
                userBLL.Insert("James", "Walters", "wltrsjames@gmail.com", "test123", 1);
                userBLL.Insert("Nick", "Walters", "wltrsnick@gmail.com", "test1234", 2);
                userBLL.Insert("Bill", "Gates", "bill@microsoft.com", "gates", 2);
            }
            
            // create project database
            JWLTD.API.DatabaseLayer.TabProjects.DataAccessLayer projectdb = new JWLTD.API.DatabaseLayer.TabProjects.DataAccessLayer();
            projectdb.CreateTable();

            // add projects
            JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer projectBLL = new JWLTD.API.DatabaseLayer.TabProjects.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabProjects.RecordDef> projectlist = new List<JWLTD.API.DatabaseLayer.TabProjects.RecordDef>();
            projectlist = projectBLL.GetAllProjects();
            if (projectlist.Count == 0)
            {
                projectBLL.Insert("Rate a Trait", "An app to rate things", "The app will be used mainly for agriculture. Where livestock and other yield can be measured", 12,0);
                projectBLL.Insert("Crisp Packet", "a bag to hold crisps", "packet will be waterproof and hold nitrogen to keep the contents fresh", 12, 1);
                projectBLL.Insert("Metal Gear", "It's a gear or 'cog' to move other gears", "Will have 36 teeth and will turn anti-clockwise", 12, 2);
                projectBLL.Insert("Menus Count", "A website to present and plan dietary information", "Will be tailored for hospitals and care homes", 22, 1);
            }

            //create project milestones
            JWLTD.API.DatabaseLayer.TabProjectMilestones.DataAccessLayer projectmilestonedb = new JWLTD.API.DatabaseLayer.TabProjectMilestones.DataAccessLayer();
            projectmilestonedb.CreateTable();

            // add milestones
            JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer projectmilestoneBLL = new JWLTD.API.DatabaseLayer.TabProjectMilestones.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabProjectMilestones.RecordDef> projectmilestonelist = new List<JWLTD.API.DatabaseLayer.TabProjectMilestones.RecordDef>();
            projectmilestonelist = projectmilestoneBLL.GetAll();
            if (projectmilestonelist.Count == 0)
            {
                projectmilestoneBLL.Insert(1,"Create Prototype App", 12, 0, 2, 6);
                projectmilestoneBLL.Insert(1, "Document Prototype results", 4, 0, 2, 3);
                projectmilestoneBLL.Insert(2, "Evaluate already existing technology", 5, 0, 1, 7);
                projectmilestoneBLL.Insert(3, "Present Prototype to customer", 2, 0, 2, 0);
            }

            // create user stories
            JWLTD.API.DatabaseLayer.TabUserStories.DataAccessLayer userstorydb = new JWLTD.API.DatabaseLayer.TabUserStories.DataAccessLayer();
            userstorydb.CreateTable();

            // add milestones
            JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer userstoryBLL = new JWLTD.API.DatabaseLayer.TabUserStories.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabUserStories.RecordDef> userstorylist = new List<JWLTD.API.DatabaseLayer.TabUserStories.RecordDef>();
            userstorylist = userstoryBLL.GetAll();
            if (userstorylist.Count == 0)
            {
                userstoryBLL.Insert(1,"Farmer",  "Need the ability for the app to work with no Internet connection", "In rural areas there may be little to no signal", "Make the app work offline", 1);
                userstoryBLL.Insert(1, "Software analyst", "App dev environment needs to be portable ", "more than one developer may be working on this, or may need handover", "Make the app easily moveable", 1);
                userstoryBLL.Insert(2, "Crisp Professional", "Crisps need to be kept crunchy", "Soft crisps are bad", "Add nitrogen to keep them fresh", 0);
                userstoryBLL.Insert(4, "Care home resident", "Needs extra amount of calories in diet", "Some residents need a calorie heavy diet", "Allow functionality to add 'fortified' meals to the menu", 1);
            }

            // create customers
            JWLTD.API.DatabaseLayer.TabCustomers.DataAccessLayer customersdb = new JWLTD.API.DatabaseLayer.TabCustomers.DataAccessLayer();
            customersdb.CreateTable();

            // add customers
            JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer customersBLL = new JWLTD.API.DatabaseLayer.TabCustomers.BusinessLogicLayer();
            List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef> customerslist = new List<JWLTD.API.DatabaseLayer.TabCustomers.RecordDef>();
            customerslist = customersBLL.GetAll();
            if (customerslist.Count == 0)
            {
                customersBLL.Insert("Ben Williams", "Ben inc.", "Need 123 Ben Street", "NP4 8EN", "01495123456", "01495123456", "ben@beninc.com");
                customersBLL.Insert("Larry", "Tofaen Council", "Civic centre", "NP4123", "01495112345", "01495123476", "Larry@torfaen.com");
                customersBLL.Insert("Lucy", "Tofaen Council", "Civic centre", "NP4123", "01495112345", "01495123476", "Lucy@torfaen.com");
                customersBLL.Insert("James", "SRS", "SRS", "NP4155", "01495112355", "01495123475", "james@srs.com");
            }
        }
    }
}