using System.Data.Entity;
using Heat.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using log4net;
using System.Diagnostics;

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
            Database.Log = s => Debug.WriteLine(s);

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
		public IDbSet<Address> Addresses { get; set; }
			
		public IDbSet<AddressType> AddressTypes { get; set; }
		public DbSet<Contact> Contacts { get; set; }

		public DbSet<Plant> Plants { get; set; }
		public DbSet<PlantType> PlantTypes { get; set; }
		public DbSet<PlantClass> PlantClasses { get; set; }
		public IDbSet<Invoice> Invoices { get; set; }
		public IDbSet<InvoiceRow> InvoiceRows { get; set; }
		public IDbSet<Payment> Payments { get; set; }
		public DbSet<Fuel> Fuels { get; set; }
		public IDbSet<CausalDocument> CausalDocuments { get; set; }
		public DbSet<Numbering> Numberings { get; set; }
		public IDbSet<Models.DocumentType> DocumentTypes { get; set; }
		public IDbSet<Models.SerialScheme> SerialSchemes { get; set; }
		public IDbSet<Warehouse> Warehouses { get; set; }
		public IDbSet<CausalWarehouseGroup> CausalWarehouseGroups { get; set; }
		public IDbSet<CausalWarehouse> CausalWarehouses { get; set; }
		

		public IDbSet<Product> Products { get; set; }
		public IDbSet<DescriptiveInvoiceRow> DescriptiveInvoiceRows { get; set; }
		public IDbSet<ProductInvoiceRow> ProductInvoiceRows { get; set; }
		public IDbSet<Models.ActionType> ActionTypes { get; set; }
		public IDbSet<Models.WorkOperator> WorkOperators { get; set; }
		public IDbSet<WorkAction> WorkActions { get; set; }
		public IDbSet<Operation> Operations { get; set; }
		public DbSet<Manifacturer> Manifacturers { get; set; }
		public DbSet<ManifacturerModel> ManifacturerModels { get; set; }
		public IDbSet<HeatTransferFluid> HeatTransferFluids { get; set; }
		public DbSet<Models.ThermalUnit> ThermalUnits { get; set; }
		public IDbSet<ThermalUnitKind> ThermalUnitKinds { get; set; }
		public IDbSet<Heater> Heaters { get; set; }
		public IDbSet<Models.PlantService> PlantServices { get; set; }

		public IDbSet<Medium> Media { get; set; }
		public IDbSet<OutboundCall> OutboundCalls { get; set; }
		public  DbSet<ProposedOutBoundCall> ProposedOutboundCalls { get; set; }
        public  DbSet<AssignedOutboundCall> AssignedOutboundCalls { get; set; }
        public  DbSet<ProposedCallsGeneration> ProposedCallsGenerations {get; set;}

        public IDbSet<WarehouseMovement> WarehouseMovements { get; set; }
        
        public DbSet<PlantRole> PlantRoles { get; set; }

        public IDbSet<Seller> Sellers { get; set; }

        public override int SaveChanges()
		{
			return base.SaveChanges();
		}

        
    }

}


