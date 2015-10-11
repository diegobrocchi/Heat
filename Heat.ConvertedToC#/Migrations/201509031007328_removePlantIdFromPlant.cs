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
	public partial class removePlantIdFromPlant : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses");
			DropForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes");
			DropIndex("dbo.Plants", new string[] { "PlantClassID" });
			DropIndex("dbo.Plants", new string[] { "PlantTypeID" });
			RenameColumn(table: "dbo.Plants", name: "PlantClassID", newName: "PlantClass_ID");
			RenameColumn(table: "dbo.Plants", name: "PlantTypeID", newName: "PlantType_ID");
			AlterColumn("dbo.Plants", "PlantClass_ID", c => c.Int());
			AlterColumn("dbo.Plants", "PlantType_ID", c => c.Int());
			CreateIndex("dbo.Plants", "PlantClass_ID");
			CreateIndex("dbo.Plants", "PlantType_ID");
			AddForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses", "ID");
			AddForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes", "ID");
		}

		public override void Down()
		{
			DropForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes");
			DropForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses");
			DropIndex("dbo.Plants", new string[] { "PlantType_ID" });
			DropIndex("dbo.Plants", new string[] { "PlantClass_ID" });
			AlterColumn("dbo.Plants", "PlantType_ID", c => c.Int(nullable: false));
			AlterColumn("dbo.Plants", "PlantClass_ID", c => c.Int(nullable: false));
			RenameColumn(table: "dbo.Plants", name: "PlantType_ID", newName: "PlantTypeID");
			RenameColumn(table: "dbo.Plants", name: "PlantClass_ID", newName: "PlantClassID");
			CreateIndex("dbo.Plants", "PlantTypeID");
			CreateIndex("dbo.Plants", "PlantClassID");
			AddForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes", "ID", cascadeDelete: true);
			AddForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses", "ID", cascadeDelete: true);
		}
	}
}
