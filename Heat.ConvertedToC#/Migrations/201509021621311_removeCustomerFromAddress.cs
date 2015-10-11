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
	public partial class removeCustomerFromAddress : DbMigration
	{

		public override void Up()
		{
			RenameColumn(table: "dbo.Addresses", name: "CustomerID", newName: "Customer_ID");
			RenameIndex(table: "dbo.Addresses", name: "IX_CustomerID", newName: "IX_Customer_ID");
		}

		public override void Down()
		{
			RenameIndex(table: "dbo.Addresses", name: "IX_Customer_ID", newName: "IX_CustomerID");
			RenameColumn(table: "dbo.Addresses", name: "Customer_ID", newName: "CustomerID");
		}
	}
}
