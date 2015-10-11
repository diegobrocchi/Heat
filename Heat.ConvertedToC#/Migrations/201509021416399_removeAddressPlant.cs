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
	public partial class removeAddressPlant : DbMigration
	{

		public override void Up()
		{
			DropColumn("dbo.Plants", "Address");
			DropColumn("dbo.Plants", "StreetNumber");
			DropColumn("dbo.Plants", "City");
			DropColumn("dbo.Plants", "PostalCode");
			DropColumn("dbo.Plants", "Area");
			DropColumn("dbo.Plants", "Zone");
		}

		public override void Down()
		{
			AddColumn("dbo.Plants", "Zone", c => c.String());
			AddColumn("dbo.Plants", "Area", c => c.String());
			AddColumn("dbo.Plants", "PostalCode", c => c.String());
			AddColumn("dbo.Plants", "City", c => c.String());
			AddColumn("dbo.Plants", "StreetNumber", c => c.String());
			AddColumn("dbo.Plants", "Address", c => c.String());
		}
	}
}
