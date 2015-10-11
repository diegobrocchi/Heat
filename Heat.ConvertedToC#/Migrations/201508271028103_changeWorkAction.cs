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
	public partial class changeWorkAction : DbMigration
	{

		public override void Up()
		{
			AddColumn("dbo.WorkActions", "Operation_ID", c => c.Int());
			CreateIndex("dbo.WorkActions", "Operation_ID");
			AddForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations", "ID");
		}

		public override void Down()
		{
			DropForeignKey("dbo.WorkActions", "Operation_ID", "dbo.Operations");
			DropIndex("dbo.WorkActions", new string[] { "Operation_ID" });
			DropColumn("dbo.WorkActions", "Operation_ID");
		}
	}
}
