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
	public partial class plantBuilding : DbMigration
	{

		public override void Up()
		{
			AddColumn("dbo.Plants", "BuildingAddress_Address", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_StreetNumber", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_Building", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_Stair", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_Apartment", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_City", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_PostalCode", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_Area", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_Zone", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_District", c => c.String());
			AddColumn("dbo.Plants", "BuildingAddress_IsSingleUnit", c => c.Boolean(nullable: false));
			AddColumn("dbo.Plants", "BuildingAddress_EnergyCategory", c => c.Int(nullable: false));
			AddColumn("dbo.Plants", "BuildingAddress_GrossHeatedVolumeM3", c => c.Single(nullable: false));
			AddColumn("dbo.Plants", "BuildingAddress_GrossCooledVolumeM3", c => c.Single(nullable: false));
		}

		public override void Down()
		{
			DropColumn("dbo.Plants", "BuildingAddress_GrossCooledVolumeM3");
			DropColumn("dbo.Plants", "BuildingAddress_GrossHeatedVolumeM3");
			DropColumn("dbo.Plants", "BuildingAddress_EnergyCategory");
			DropColumn("dbo.Plants", "BuildingAddress_IsSingleUnit");
			DropColumn("dbo.Plants", "BuildingAddress_District");
			DropColumn("dbo.Plants", "BuildingAddress_Zone");
			DropColumn("dbo.Plants", "BuildingAddress_Area");
			DropColumn("dbo.Plants", "BuildingAddress_PostalCode");
			DropColumn("dbo.Plants", "BuildingAddress_City");
			DropColumn("dbo.Plants", "BuildingAddress_Apartment");
			DropColumn("dbo.Plants", "BuildingAddress_Stair");
			DropColumn("dbo.Plants", "BuildingAddress_Building");
			DropColumn("dbo.Plants", "BuildingAddress_StreetNumber");
			DropColumn("dbo.Plants", "BuildingAddress_Address");
		}
	}
}
