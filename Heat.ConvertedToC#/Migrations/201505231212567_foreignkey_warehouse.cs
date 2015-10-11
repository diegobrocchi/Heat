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
	public partial class foreignkey_warehouse : DbMigration
	{

		public override void Up()
		{
			DropForeignKey("dbo.WarehouseMovements", "Destination_ID", "dbo.Warehouses");
			DropForeignKey("dbo.WarehouseMovements", "Product_ID", "dbo.Products");
			DropForeignKey("dbo.WarehouseMovements", "Source_ID", "dbo.Warehouses");
			DropIndex("dbo.WarehouseMovements", new string[] { "Destination_ID" });
			DropIndex("dbo.WarehouseMovements", new string[] { "Product_ID" });
			DropIndex("dbo.WarehouseMovements", new string[] { "Source_ID" });
			RenameColumn(table: "dbo.WarehouseMovements", name: "Destination_ID", newName: "DestinationID");
			RenameColumn(table: "dbo.WarehouseMovements", name: "Product_ID", newName: "ProductID");
			RenameColumn(table: "dbo.WarehouseMovements", name: "Source_ID", newName: "SourceID");
			AlterColumn("dbo.WarehouseMovements", "DestinationID", c => c.Int(nullable: false));
			AlterColumn("dbo.WarehouseMovements", "ProductID", c => c.Int(nullable: false));
			AlterColumn("dbo.WarehouseMovements", "SourceID", c => c.Int(nullable: false));
			CreateIndex("dbo.WarehouseMovements", "ProductID");
			CreateIndex("dbo.WarehouseMovements", "SourceID");
			CreateIndex("dbo.WarehouseMovements", "DestinationID");
			AddForeignKey("dbo.WarehouseMovements", "DestinationID", "dbo.Warehouses", "ID", cascadeDelete: false);
			AddForeignKey("dbo.WarehouseMovements", "ProductID", "dbo.Products", "ID", cascadeDelete: false);
			AddForeignKey("dbo.WarehouseMovements", "SourceID", "dbo.Warehouses", "ID", cascadeDelete: false);
		}

		public override void Down()
		{
			DropForeignKey("dbo.WarehouseMovements", "SourceID", "dbo.Warehouses");
			DropForeignKey("dbo.WarehouseMovements", "ProductID", "dbo.Products");
			DropForeignKey("dbo.WarehouseMovements", "DestinationID", "dbo.Warehouses");
			DropIndex("dbo.WarehouseMovements", new string[] { "DestinationID" });
			DropIndex("dbo.WarehouseMovements", new string[] { "SourceID" });
			DropIndex("dbo.WarehouseMovements", new string[] { "ProductID" });
			AlterColumn("dbo.WarehouseMovements", "SourceID", c => c.Int());
			AlterColumn("dbo.WarehouseMovements", "ProductID", c => c.Int());
			AlterColumn("dbo.WarehouseMovements", "DestinationID", c => c.Int());
			RenameColumn(table: "dbo.WarehouseMovements", name: "SourceID", newName: "Source_ID");
			RenameColumn(table: "dbo.WarehouseMovements", name: "ProductID", newName: "Product_ID");
			RenameColumn(table: "dbo.WarehouseMovements", name: "DestinationID", newName: "Destination_ID");
			CreateIndex("dbo.WarehouseMovements", "Source_ID");
			CreateIndex("dbo.WarehouseMovements", "Product_ID");
			CreateIndex("dbo.WarehouseMovements", "Destination_ID");
			AddForeignKey("dbo.WarehouseMovements", "Source_ID", "dbo.Warehouses", "ID");
			AddForeignKey("dbo.WarehouseMovements", "Product_ID", "dbo.Products", "ID");
			AddForeignKey("dbo.WarehouseMovements", "Destination_ID", "dbo.Warehouses", "ID");
		}
	}
}
