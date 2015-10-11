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
	public partial class removeCustomerFromWorkAction : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers");
			DropIndex("dbo.WorkActions", new string[] { "CustomerID" });
			DropColumn("dbo.WorkActions", "CustomerID");
		}

		public override void Down()
		{
			AddColumn("dbo.WorkActions", "CustomerID", c => c.Int(nullable: false));
			CreateIndex("dbo.WorkActions", "CustomerID");
			AddForeignKey("dbo.WorkActions", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
		}
	}
}
