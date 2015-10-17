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
using System.Data.Entity;
using Heat.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using log4net;


namespace Heat.Repositories
{

	public class HeatDBContext : IdentityDbContext<HeatUser>, IHeatDBContext
	{


		private ILog _logger;
		public HeatDBContext() : base("DefaultConnection")
		{
			//Entity.Database.SetInitializer(Of HeatDBContext)(New DropCreateDatabaseIfModelChanges(Of HeatDBContext))
			//Entity.Database.SetInitializer(Of HeatDBContext)(Nothing)
			//Entity.Database.SetInitializer(Of HeatDBContext)(New HeatDBInitializer)
			//Me.Configuration.LazyLoadingEnabled = True

			//_logger = LogManager.GetLogger(GetType(HeatDBContext))
			//_logger.Debug("HeatDbContext created")
			//Database.Log = Sub(s) Debug.WriteLine(s)

		}


		public static HeatDBContext Create()
		{
			return new HeatDBContext();
		}

		public void SetModified(object entity)
		{
			Entry(entity).State = EntityState.Modified;
		}

		public DbSet<Customer> Customers { get; set; }
		public DbSet<Address> Address { get; set; }
		DbSet<Address> IHeatDBContext.Addresses {
			get { return Address; }
			set { Address = value; }
		}
		public DbSet<AddressType> AddressTypes { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<WarehouseMovement> WarehouseMovement { get; set; }
		DbSet<WarehouseMovement> IHeatDBContext.WarehouseMovements {
			get { return WarehouseMovement; }
			set { WarehouseMovement = value; }
		}
		public DbSet<Plant> Plants { get; set; }
		public DbSet<PlantType> PlantTypes { get; set; }
		public DbSet<PlantClass> PlantClasses { get; set; }
		public DbSet<Invoice> Invoices { get; set; }
		public DbSet<InvoiceRow> InvoiceRows { get; set; }
		public DbSet<Payment> Payments { get; set; }
		public DbSet<Fuel> Fuels { get; set; }
		public DbSet<CausalDocument> CausalDocuments { get; set; }
		public DbSet<Numbering> Numberings { get; set; }
		public DbSet<Models.DocumentType> DocumentTypes { get; set; }
		public DbSet<Models.SerialScheme> SerialSchemes { get; set; }
		public DbSet<Warehouse> Warehouses { get; set; }
		public DbSet<CausalWarehouseGroup> CausalWarehouseGroups { get; set; }
		public DbSet<CausalWarehouse> CausalWarehouses { get; set; }
		public DbSet<Seller> Seller { get; set; }
		DbSet<Seller> IHeatDBContext.Sellers {
			get { return Seller; }
			set { Seller = value; }
		}
		public DbSet<Product> Products { get; set; }
		public DbSet<DescriptiveInvoiceRow> DescriptiveInvoiceRows { get; set; }
		public DbSet<ProductInvoiceRow> ProductInvoiceRows { get; set; }
		public DbSet<Models.ActionType> ActionTypes { get; set; }
		public DbSet<Models.WorkOperator> WorkOperators { get; set; }
		public DbSet<WorkAction> WorkActions { get; set; }
		public DbSet<Operation> Operations { get; set; }
		public DbSet<Manifacturer> Manifacturers { get; set; }
		public DbSet<ManifacturerModel> ManifacturerModels { get; set; }
		public DbSet<HeatTransferFluid> HeatTransferFluids { get; set; }
		public DbSet<Models.ThermalUnit> ThermalUnits { get; set; }
		public DbSet<ThermalUnitKind> ThermalUnitKinds { get; set; }
		public DbSet<Heater> Heaters { get; set; }
		public DbSet<Models.PlantService> PlantServices { get; set; }

		public DbSet<Medium> Media { get; set; }
		public DbSet<OutboundCall> OutboundCalls { get; set; }
		public DbSet<ProposedOutBoundCall> ProposedOutboundCalls { get; set; }

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}

	}

}

