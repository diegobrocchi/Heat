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
	public partial class manifacturermodelID : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.ManifacturerModels", "Manifacturer_ID", "dbo.Manifacturers");
			DropIndex("dbo.ManifacturerModels", new string[] { "Manifacturer_ID" });
			RenameColumn(table: "dbo.ManifacturerModels", name: "Manifacturer_ID", newName: "ManifacturerID");
			AlterColumn("dbo.ManifacturerModels", "ManifacturerID", c => c.Int(nullable: false));
			CreateIndex("dbo.ManifacturerModels", "ManifacturerID");
			AddForeignKey("dbo.ManifacturerModels", "ManifacturerID", "dbo.Manifacturers", "ID", cascadeDelete: true);
		}

		public override void Down()
		{
			DropForeignKey("dbo.ManifacturerModels", "ManifacturerID", "dbo.Manifacturers");
			DropIndex("dbo.ManifacturerModels", new string[] { "ManifacturerID" });
			AlterColumn("dbo.ManifacturerModels", "ManifacturerID", c => c.Int());
			RenameColumn(table: "dbo.ManifacturerModels", name: "ManifacturerID", newName: "Manifacturer_ID");
			CreateIndex("dbo.ManifacturerModels", "Manifacturer_ID");
			AddForeignKey("dbo.ManifacturerModels", "Manifacturer_ID", "dbo.Manifacturers", "ID");
		}
	}
}
