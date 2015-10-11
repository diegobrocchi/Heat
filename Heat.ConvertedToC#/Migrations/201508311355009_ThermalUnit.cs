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
	public partial class ThermalUnit : DbMigration
	{


		public override void Up()
		{

			//DropForeignKey("dbo.ThermalUnits", "Fuel_ID", "dbo.Fuels")
			//DropForeignKey("dbo.ThermalUnits", "HeatTransferFluid_ID", "dbo.HeatTransferFluids")
			//DropForeignKey("dbo.ThermalUnits", "Manifacturer_ID", "dbo.Manifacturers")
			//DropForeignKey("dbo.ThermalUnits", "Model_ID", "dbo.ManifacturerModels")
			//DropIndex("dbo.ThermalUnits", New String() {"Fuel_ID"})
			//DropIndex("dbo.ThermalUnits", New String() {"HeatTransferFluid_ID"})
			//DropIndex("dbo.ThermalUnits", New String() {"Manifacturer_ID"})
			//DropIndex("dbo.ThermalUnits", New String() {"Model_ID"})
			//'RenameColumn(table:="dbo.ThermalUnits", name:="Fuel_ID", newName:="FuelID")
			//'RenameColumn(table:="dbo.ThermalUnits", name:="HeatTransferFluid_ID", newName:="HeatTransferFluidID")
			//'RenameColumn(table:="dbo.ThermalUnits", name:="Manifacturer_ID", newName:="ManifacturerId")
			//'RenameColumn(table:="dbo.ThermalUnits", name:="Model_ID", newName:="ModelID")
			//AlterColumn("dbo.ThermalUnits", "FuelID", Function(c) c.Int(nullable:=False))
			//AlterColumn("dbo.ThermalUnits", "HeatTransferFluidID", Function(c) c.Int(nullable:=False))
			//AlterColumn("dbo.ThermalUnits", "ManifacturerId", Function(c) c.Int(nullable:=False))
			//AlterColumn("dbo.ThermalUnits", "ModelID", Function(c) c.Int(nullable:=False))
			//CreateIndex("dbo.ThermalUnits", "ManifacturerId")
			//CreateIndex("dbo.ThermalUnits", "ModelID")
			//CreateIndex("dbo.ThermalUnits", "FuelID")
			//CreateIndex("dbo.ThermalUnits", "HeatTransferFluidID")
			//AddForeignKey("dbo.ThermalUnits", "FuelID", "dbo.Fuels", "ID", cascadeDelete:=True)
			//AddForeignKey("dbo.ThermalUnits", "HeatTransferFluidID", "dbo.HeatTransferFluids", "ID", cascadeDelete:=True)
			//AddForeignKey("dbo.ThermalUnits", "ManifacturerId", "dbo.Manifacturers", "ID", cascadeDelete:=True)
			//AddForeignKey("dbo.ThermalUnits", "ModelID", "dbo.ManifacturerModels", "ID", cascadeDelete:=False)
		}

		public override void Down()
		{
			DropForeignKey("dbo.ThermalUnits", "ModelID", "dbo.ManifacturerModels");
			DropForeignKey("dbo.ThermalUnits", "ManifacturerId", "dbo.Manifacturers");
			DropForeignKey("dbo.ThermalUnits", "HeatTransferFluidID", "dbo.HeatTransferFluids");
			DropForeignKey("dbo.ThermalUnits", "FuelID", "dbo.Fuels");
			DropIndex("dbo.ThermalUnits", new string[] { "HeatTransferFluidID" });
			DropIndex("dbo.ThermalUnits", new string[] { "FuelID" });
			DropIndex("dbo.ThermalUnits", new string[] { "ModelID" });
			DropIndex("dbo.ThermalUnits", new string[] { "ManifacturerId" });
			AlterColumn("dbo.ThermalUnits", "ModelID", c => c.Int());
			AlterColumn("dbo.ThermalUnits", "ManifacturerId", c => c.Int());
			AlterColumn("dbo.ThermalUnits", "HeatTransferFluidID", c => c.Int());
			AlterColumn("dbo.ThermalUnits", "FuelID", c => c.Int());
			RenameColumn(table: "dbo.ThermalUnits", name: "ModelID", newName: "Model_ID");
			RenameColumn(table: "dbo.ThermalUnits", name: "ManifacturerId", newName: "Manifacturer_ID");
			RenameColumn(table: "dbo.ThermalUnits", name: "HeatTransferFluidID", newName: "HeatTransferFluid_ID");
			RenameColumn(table: "dbo.ThermalUnits", name: "FuelID", newName: "Fuel_ID");
			CreateIndex("dbo.ThermalUnits", "Model_ID");
			CreateIndex("dbo.ThermalUnits", "Manifacturer_ID");
			CreateIndex("dbo.ThermalUnits", "HeatTransferFluid_ID");
			CreateIndex("dbo.ThermalUnits", "Fuel_ID");
			AddForeignKey("dbo.ThermalUnits", "Model_ID", "dbo.ManifacturerModels", "ID");
			AddForeignKey("dbo.ThermalUnits", "Manifacturer_ID", "dbo.Manifacturers", "ID");
			AddForeignKey("dbo.ThermalUnits", "HeatTransferFluid_ID", "dbo.HeatTransferFluids", "ID");
			AddForeignKey("dbo.ThermalUnits", "Fuel_ID", "dbo.Fuels", "ID");
		}
	}
}
