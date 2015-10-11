using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using System.Web.SessionState;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.Entity.Migrations;

namespace Heat.Migrations
{
	public partial class PlantService_key : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.PlantServices", "ID", "dbo.Plants");
			DropIndex("dbo.PlantServices", new string[] { "ID" });
			DropPrimaryKey("dbo.PlantServices");
			AddColumn("dbo.Plants", "Service_ID", c => c.Int());
			AlterColumn("dbo.PlantServices", "ID", c => c.Int(nullable: false, identity: true));
			AddPrimaryKey("dbo.PlantServices", "ID");
			CreateIndex("dbo.Plants", "Service_ID");
			AddForeignKey("dbo.Plants", "Service_ID", "dbo.PlantServices", "ID");
			DropColumn("dbo.PlantServices", "PlantID");
		}

		public override void Down()
		{
			AddColumn("dbo.PlantServices", "PlantID", c => c.Int(nullable: false));
			DropForeignKey("dbo.Plants", "Service_ID", "dbo.PlantServices");
			DropIndex("dbo.Plants", new string[] { "Service_ID" });
			DropPrimaryKey("dbo.PlantServices");
			AlterColumn("dbo.PlantServices", "ID", c => c.Int(nullable: false));
			DropColumn("dbo.Plants", "Service_ID");
			AddPrimaryKey("dbo.PlantServices", "ID");
			CreateIndex("dbo.PlantServices", "ID");
			AddForeignKey("dbo.PlantServices", "ID", "dbo.Plants", "ID");
		}
	}
}
