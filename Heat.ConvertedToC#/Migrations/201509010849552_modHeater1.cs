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
	public partial class modHeater1 : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.Heaters", "Heater_ID", "dbo.Heaters");
			DropForeignKey("dbo.Heaters", "HeatTransferFluidID", "dbo.HeatTransferFluids");
			DropIndex("dbo.Heaters", new string[] { "HeatTransferFluidID" });
			DropIndex("dbo.Heaters", new string[] { "Heater_ID" });
			DropColumn("dbo.Heaters", "HeatTransferFluidID");
			DropColumn("dbo.Heaters", "ThermalEfficiencyPowerMax");
			DropColumn("dbo.Heaters", "Kind");
			DropColumn("dbo.Heaters", "Heater_ID");
		}

		public override void Down()
		{
			AddColumn("dbo.Heaters", "Heater_ID", c => c.Int());
			AddColumn("dbo.Heaters", "Kind", c => c.Int(nullable: false));
			AddColumn("dbo.Heaters", "ThermalEfficiencyPowerMax", c => c.Single(nullable: false));
			AddColumn("dbo.Heaters", "HeatTransferFluidID", c => c.Int(nullable: false));
			CreateIndex("dbo.Heaters", "Heater_ID");
			CreateIndex("dbo.Heaters", "HeatTransferFluidID");
			AddForeignKey("dbo.Heaters", "HeatTransferFluidID", "dbo.HeatTransferFluids", "ID", cascadeDelete: true);
			AddForeignKey("dbo.Heaters", "Heater_ID", "dbo.Heaters", "ID");
		}
	}
}
