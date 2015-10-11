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
	public partial class foreignkey_schema_numbering : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.Numberings", "FinalSerialSchema_ID", "dbo.SerialSchemes");
			DropForeignKey("dbo.Numberings", "TempSerialSchema_ID", "dbo.SerialSchemes");
			DropIndex("dbo.Numberings", new string[] { "FinalSerialSchema_ID" });
			DropIndex("dbo.Numberings", new string[] { "TempSerialSchema_ID" });
			RenameColumn(table: "dbo.Numberings", name: "FinalSerialSchema_ID", newName: "FinalSerialSchemaID");
			RenameColumn(table: "dbo.Numberings", name: "TempSerialSchema_ID", newName: "TempSerialSchemaID");
			AlterColumn("dbo.Numberings", "FinalSerialSchemaID", c => c.Int(nullable: false));
			AlterColumn("dbo.Numberings", "TempSerialSchemaID", c => c.Int(nullable: false));
			CreateIndex("dbo.Numberings", "TempSerialSchemaID");
			CreateIndex("dbo.Numberings", "FinalSerialSchemaID");
			AddForeignKey("dbo.Numberings", "FinalSerialSchemaID", "dbo.SerialSchemes", "ID", cascadeDelete: false);
			AddForeignKey("dbo.Numberings", "TempSerialSchemaID", "dbo.SerialSchemes", "ID", cascadeDelete: false);
		}

		public override void Down()
		{
			DropForeignKey("dbo.Numberings", "TempSerialSchemaID", "dbo.SerialSchemes");
			DropForeignKey("dbo.Numberings", "FinalSerialSchemaID", "dbo.SerialSchemes");
			DropIndex("dbo.Numberings", new string[] { "FinalSerialSchemaID" });
			DropIndex("dbo.Numberings", new string[] { "TempSerialSchemaID" });
			AlterColumn("dbo.Numberings", "TempSerialSchemaID", c => c.Int());
			AlterColumn("dbo.Numberings", "FinalSerialSchemaID", c => c.Int());
			RenameColumn(table: "dbo.Numberings", name: "TempSerialSchemaID", newName: "TempSerialSchema_ID");
			RenameColumn(table: "dbo.Numberings", name: "FinalSerialSchemaID", newName: "FinalSerialSchema_ID");
			CreateIndex("dbo.Numberings", "TempSerialSchema_ID");
			CreateIndex("dbo.Numberings", "FinalSerialSchema_ID");
			AddForeignKey("dbo.Numberings", "TempSerialSchema_ID", "dbo.SerialSchemes", "ID");
			AddForeignKey("dbo.Numberings", "FinalSerialSchema_ID", "dbo.SerialSchemes", "ID");
		}
	}
}
