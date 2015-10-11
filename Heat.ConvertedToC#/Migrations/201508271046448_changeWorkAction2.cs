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
	public partial class changeWorkAction2 : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.WorkActions", "Type_ID", "dbo.ActionTypes");
			DropIndex("dbo.WorkActions", new string[] { "Type_ID" });
			RenameColumn(table: "dbo.WorkActions", name: "Type_ID", newName: "TypeID");
			AlterColumn("dbo.WorkActions", "TypeID", c => c.Int(nullable: false));
			CreateIndex("dbo.WorkActions", "TypeID");
			AddForeignKey("dbo.WorkActions", "TypeID", "dbo.ActionTypes", "ID", cascadeDelete: true);
		}

		public override void Down()
		{
			DropForeignKey("dbo.WorkActions", "TypeID", "dbo.ActionTypes");
			DropIndex("dbo.WorkActions", new string[] { "TypeID" });
			AlterColumn("dbo.WorkActions", "TypeID", c => c.Int());
			RenameColumn(table: "dbo.WorkActions", name: "TypeID", newName: "Type_ID");
			CreateIndex("dbo.WorkActions", "Type_ID");
			AddForeignKey("dbo.WorkActions", "Type_ID", "dbo.ActionTypes", "ID");
		}
	}
}
