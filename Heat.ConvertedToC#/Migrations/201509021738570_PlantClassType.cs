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
	public partial class PlantClassType : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses");
			DropForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes");
			DropIndex("dbo.Plants", new string[] { "PlantClass_ID" });
			DropIndex("dbo.Plants", new string[] { "PlantType_ID" });
			RenameColumn(table: "dbo.Plants", name: "PlantClass_ID", newName: "PlantClassID");
			RenameColumn(table: "dbo.Plants", name: "PlantType_ID", newName: "PlantTypeID");
			AlterColumn("dbo.Plants", "PlantClassID", c => c.Int(nullable: false));
			AlterColumn("dbo.Plants", "PlantTypeID", c => c.Int(nullable: false));
			CreateIndex("dbo.Plants", "PlantClassID");
			CreateIndex("dbo.Plants", "PlantTypeID");
			AddForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses", "ID", cascadeDelete: true);
			AddForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes", "ID", cascadeDelete: true);
		}

		public override void Down()
		{
			DropForeignKey("dbo.Plants", "PlantTypeID", "dbo.PlantTypes");
			DropForeignKey("dbo.Plants", "PlantClassID", "dbo.PlantClasses");
			DropIndex("dbo.Plants", new string[] { "PlantTypeID" });
			DropIndex("dbo.Plants", new string[] { "PlantClassID" });
			AlterColumn("dbo.Plants", "PlantTypeID", c => c.Int());
			AlterColumn("dbo.Plants", "PlantClassID", c => c.Int());
			RenameColumn(table: "dbo.Plants", name: "PlantTypeID", newName: "PlantType_ID");
			RenameColumn(table: "dbo.Plants", name: "PlantClassID", newName: "PlantClass_ID");
			CreateIndex("dbo.Plants", "PlantType_ID");
			CreateIndex("dbo.Plants", "PlantClass_ID");
			AddForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes", "ID");
			AddForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses", "ID");
		}
	}
}
