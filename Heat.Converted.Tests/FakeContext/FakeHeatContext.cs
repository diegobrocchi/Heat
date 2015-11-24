using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heat.Converted.Tests.FakeContext
{
    class FakeHeatContext : IHeatDBContext
    {

        public FakeHeatContext()
        {
            this.Addresses = new FakeAddressDbSet();
            this.AddressTypes = new FakeAddressTypeDbSet();
            this.Customers = new FakeCustomerDbSet();
            this.Contacts = new FakeContactDbSet();
            this.Numberings = new FakeNumberingDbSet();
            this.SerialSchemes = new FakeSerialSchemeDbSet();
            this.CausalWarehouseGroups = new FakeCausalWarehouseGroupDbSet();
            this.Warehouses = new FakeWarehouseDbSet();
            this.WarehouseMovements = new FakeWarehouseMovementDbSet();
            this.Sellers = new FakeSellerDbSet();
            this.Invoices = new FakeInvoiceDbSet();
            this.DocumentTypes = new FakeDocumentTypeDbSet();
            this.Products = new FakeProductDbSet();
            this.Payments = new FakePaymentDbSet();
            this.ProductInvoiceRows = new FakeProductInvoiceRowDbSet();
            this.DescriptiveInvoiceRows = new FakeDescriptiveInvoiceRowDbSet();
            this.ActionTypes = new FakeActionTypeDbSet();
            this.WorkOperators = new FakeWorkOperatorDbSet();
            this.WorkActions = new FakeWorkActionDbSet();
            this.Operations = new FakeOperationDbSet();
            this.Manifacturers = new FakeManifacturerDbSet();
            this.ManifacturerModels = new FakeManifacturerModelDbSet();
            this.HeatTransferFluids = new FakeHeatTransferFluidDbSet();
            this.ThermalUnitKinds = new FakeThermalUnitKindDbSet();
            this.Plants = new FakePlantDbSet();
            this.PlantTypes = new FakePlantTypeDbSet();
            this.PlantClasses = new FakePlantClassDbSet();
            this.PlantServices = new FakePlantServiceDbSet();
            this.ThermalUnits = new FakeThermalUnitDbSet();
            this.Fuels = new FakeFuelDbSet();
            this.Heaters = new FakeHeaterDbSet();
            this.Media = new FakeMediumDbSet();
            this.OutboundCalls = new FakeOutboundCallDbSet();
            this.ProposedOutboundCalls = new FakeProposedOutboundCallDbSet();
            this.AssignedOutboundCalls = new FakeAssignedOutboundCallDbSet();
            this.ProposedCallsGenerations = new FakeProposedCallsGenerationDbSet();

        }

        #region Properties

        public System.Data.Entity.IDbSet<Models.Address> Addresses { get; set; }

        public System.Data.Entity.IDbSet<Models.AddressType> AddressTypes { get; set; }

        public System.Data.Entity.IDbSet<Models.Customer> Customers { get; set; }

        public System.Data.Entity.IDbSet<Models.Contact> Contacts { get; set; }

        public System.Data.Entity.IDbSet<Models.Numbering> Numberings { get; set; }

        public System.Data.Entity.IDbSet<Models.SerialScheme> SerialSchemes { get; set; }

        public System.Data.Entity.IDbSet<Models.CausalWarehouse> CausalWarehouses { get; set; }

        public System.Data.Entity.IDbSet<Models.CausalWarehouseGroup> CausalWarehouseGroups { get; set; }

        public System.Data.Entity.IDbSet<Models.Warehouse> Warehouses { get; set; }

        public System.Data.Entity.IDbSet<Models.WarehouseMovement> WarehouseMovements { get; set; }

        public System.Data.Entity.IDbSet<Models.Seller> Sellers { get; set; }

        public System.Data.Entity.IDbSet<Models.Invoice> Invoices { get; set; }

        public System.Data.Entity.IDbSet<Models.InvoiceRow> InvoiceRows { get; set; }

        public System.Data.Entity.IDbSet<Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.IDbSet<Models.Product> Products { get; set; }

        public System.Data.Entity.IDbSet<Models.Payment> Payments { get; set; }

        public System.Data.Entity.IDbSet<Models.ProductInvoiceRow> ProductInvoiceRows { get; set; }

        public System.Data.Entity.IDbSet<Models.DescriptiveInvoiceRow> DescriptiveInvoiceRows { get; set; }

        public System.Data.Entity.IDbSet<Models.ActionType> ActionTypes { get; set; }

        public System.Data.Entity.IDbSet<Models.WorkOperator> WorkOperators { get; set; }

        public System.Data.Entity.IDbSet<Models.WorkAction> WorkActions { get; set; }

        public System.Data.Entity.IDbSet<Models.Operation> Operations { get; set; }

        public System.Data.Entity.IDbSet<Models.Manifacturer> Manifacturers { get; set; }

        public System.Data.Entity.IDbSet<Models.ManifacturerModel> ManifacturerModels { get; set; }

        public System.Data.Entity.IDbSet<Models.HeatTransferFluid> HeatTransferFluids { get; set; }

        public System.Data.Entity.IDbSet<Models.ThermalUnitKind> ThermalUnitKinds { get; set; }

        public System.Data.Entity.IDbSet<Models.Plant> Plants { get; set; }

        public System.Data.Entity.IDbSet<Models.PlantType> PlantTypes { get; set; }

        public System.Data.Entity.IDbSet<Models.PlantClass> PlantClasses { get; set; }

        public System.Data.Entity.IDbSet<Models.PlantService> PlantServices { get; set; }

        public System.Data.Entity.IDbSet<Models.ThermalUnit> ThermalUnits { get; set; }

        public System.Data.Entity.IDbSet<Models.Fuel> Fuels { get; set; }

        public System.Data.Entity.IDbSet<Models.Heater> Heaters { get; set; }

        public System.Data.Entity.IDbSet<Models.Medium> Media { get; set; }

        public System.Data.Entity.IDbSet<Models.OutboundCall> OutboundCalls { get; set; }

        public System.Data.Entity.IDbSet<Models.ProposedOutBoundCall> ProposedOutboundCalls { get; set; }

        public System.Data.Entity.IDbSet<Models.AssignedOutboundCall> AssignedOutboundCalls { get; set; }

        public System.Data.Entity.IDbSet<Models.ProposedCallsGeneration> ProposedCallsGenerations { get; set; }

        #endregion


        public int SaveChanges()
        {
            return 0;
        }

        public void SetModified(object entity)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
