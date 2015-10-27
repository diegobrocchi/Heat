namespace Heat.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActionTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AddressTypeID = c.Int(nullable: false),
                        Street = c.String(),
                        StreetNumber = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        District = c.String(),
                        State = c.String(),
                        Note = c.String(),
                        Customer_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AddressTypes", t => t.AddressTypeID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .Index(t => t.AddressTypeID)
                .Index(t => t.Customer_ID);
            
            CreateTable(
                "dbo.AddressTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CausalDocuments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CausalWarehouseGroups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.CausalWarehouses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Sign = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        Transaction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Phone = c.String(),
                        CellPhone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        URL = c.String(),
                        Address_ID = c.Int(),
                        Plant_ID = c.Int(),
                        ProposedOutBoundCall_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .ForeignKey("dbo.Plants", t => t.Plant_ID)
                .ForeignKey("dbo.ProposedOutBoundCalls", t => t.ProposedOutBoundCall_ID)
                .Index(t => t.Address_ID)
                .Index(t => t.Plant_ID)
                .Index(t => t.ProposedOutBoundCall_ID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.String(),
                        District = c.String(),
                        Telephone1 = c.String(),
                        Telephone2 = c.String(),
                        Telephone3 = c.String(),
                        Taxcode = c.String(),
                        VAT_Number = c.String(),
                        IBAN = c.String(),
                        EMail = c.String(),
                        Website = c.String(),
                        IsEnabled = c.Boolean(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        EnableDate = c.DateTime(),
                        DisableDate = c.DateTime(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.InvoiceRows",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RowID = c.Int(nullable: false),
                        ItemOrder = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        VAT_Rate = c.Double(nullable: false),
                        RateDiscount1 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RateDiscount2 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RateDiscount3 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RowDescription = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Invoice_ID = c.Int(),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoices", t => t.Invoice_ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.Invoice_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InsertedNumber_SerialInteger = c.Int(nullable: false),
                        InsertedNumber_SerialString = c.String(),
                        InsertedNumber_IsValid = c.Boolean(nullable: false),
                        InsertedNumber_InvalidError = c.String(),
                        ConfirmedNumber_SerialInteger = c.Int(nullable: false),
                        ConfirmedNumber_SerialString = c.String(),
                        ConfirmedNumber_IsValid = c.Boolean(nullable: false),
                        ConfirmedNumber_InvalidError = c.String(),
                        State = c.Int(nullable: false),
                        InvoiceDate = c.DateTime(nullable: false),
                        TaxableAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TaxesAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SelfBilling = c.Boolean(nullable: false),
                        IsTaxExempt = c.Boolean(nullable: false),
                        TaxExemption = c.String(),
                        Customer_ID = c.Int(),
                        Payment_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.Customer_ID)
                .ForeignKey("dbo.Payments", t => t.Payment_ID)
                .Index(t => t.Customer_ID)
                .Index(t => t.Payment_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SKU = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ReorderLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Numbering_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Numberings", t => t.Numbering_ID)
                .Index(t => t.Numbering_ID);
            
            CreateTable(
                "dbo.Numberings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        TempSerialSchemaID = c.Int(nullable: false),
                        FinalSerialSchemaID = c.Int(nullable: false),
                        LastTempSerial_SerialInteger = c.Int(nullable: false),
                        LastTempSerial_SerialString = c.String(),
                        LastTempSerial_IsValid = c.Boolean(nullable: false),
                        LastTempSerial_InvalidError = c.String(),
                        LastFinalSerial_SerialInteger = c.Int(nullable: false),
                        LastFinalSerial_SerialString = c.String(),
                        LastFinalSerial_IsValid = c.Boolean(nullable: false),
                        LastFinalSerial_InvalidError = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.SerialSchemes", t => t.FinalSerialSchemaID, cascadeDelete: true)
                .ForeignKey("dbo.SerialSchemes", t => t.TempSerialSchemaID, cascadeDelete: true)
                .Index(t => t.TempSerialSchemaID)
                .Index(t => t.FinalSerialSchemaID);
            
            CreateTable(
                "dbo.SerialSchemes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        InitialValue = c.Int(nullable: false),
                        Increment = c.Int(nullable: false),
                        MinValue = c.Int(),
                        MaxValue = c.Int(),
                        FormatMask = c.String(),
                        ExpiryDate = c.DateTime(),
                        RecycleWhenExpired = c.Boolean(nullable: false),
                        Period = c.Int(),
                        RecycleWhenMaxIsReached = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Fuels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Heaters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        MinimumPowerKW = c.Single(nullable: false),
                        MaximumPowerKW = c.Single(nullable: false),
                        InstallationDate = c.DateTime(nullable: false),
                        Type = c.String(),
                        FuelID = c.Int(nullable: false),
                        DismissDate = c.DateTime(),
                        Manifacturer_ID = c.Int(),
                        Model_ID = c.Int(),
                        ThermalUnit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fuels", t => t.FuelID, cascadeDelete: true)
                .ForeignKey("dbo.Manifacturers", t => t.Manifacturer_ID)
                .ForeignKey("dbo.ManifacturerModels", t => t.Model_ID)
                .ForeignKey("dbo.ThermalUnits", t => t.ThermalUnit_ID)
                .Index(t => t.FuelID)
                .Index(t => t.Manifacturer_ID)
                .Index(t => t.Model_ID)
                .Index(t => t.ThermalUnit_ID);
            
            CreateTable(
                "dbo.Manifacturers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ManifacturerModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManifacturerID = c.Int(nullable: false),
                        Model = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Manifacturers", t => t.ManifacturerID, cascadeDelete: true)
                .Index(t => t.ManifacturerID);
            
            CreateTable(
                "dbo.BoilerServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PreviousServiceDate = c.DateTime(nullable: false),
                        Periodicity = c.Int(nullable: false),
                        LegalExpirationDate = c.DateTime(nullable: false),
                        PlannedServiceDate = c.DateTime(nullable: false),
                        Boiler_ID = c.Int(),
                        Type_ID = c.Int(),
                        ManifacturerModel_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Boilers", t => t.Boiler_ID)
                .ForeignKey("dbo.BoilerServiceTypes", t => t.Type_ID)
                .ForeignKey("dbo.ManifacturerModels", t => t.ManifacturerModel_ID)
                .Index(t => t.Boiler_ID)
                .Index(t => t.Type_ID)
                .Index(t => t.ManifacturerModel_ID);
            
            CreateTable(
                "dbo.Boilers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        InstallationDate = c.DateTime(nullable: false),
                        FirstStartUp = c.DateTime(nullable: false),
                        Warranty = c.String(),
                        WarrantyExpiration = c.DateTime(nullable: false),
                        Manifacturer_ID = c.Int(),
                        Model_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Manifacturers", t => t.Manifacturer_ID)
                .ForeignKey("dbo.ManifacturerModels", t => t.Model_ID)
                .Index(t => t.Manifacturer_ID)
                .Index(t => t.Model_ID);
            
            CreateTable(
                "dbo.BoilerServiceTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ThermalUnits",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ManifacturerId = c.Int(nullable: false),
                        ModelID = c.Int(nullable: false),
                        SerialNumber = c.String(),
                        InstallationDate = c.DateTime(nullable: false),
                        FirstStartUp = c.DateTime(),
                        Warranty = c.String(),
                        WarrantyExpiration = c.DateTime(),
                        FuelID = c.Int(nullable: false),
                        NominalThermalPowerMax = c.Single(nullable: false),
                        DismissDate = c.DateTime(),
                        HeatTransferFluidID = c.Int(nullable: false),
                        ThermalEfficiencyPowerMax = c.Single(nullable: false),
                        Kind = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Fuels", t => t.FuelID, cascadeDelete: true)
                .ForeignKey("dbo.HeatTransferFluids", t => t.HeatTransferFluidID, cascadeDelete: true)
                .ForeignKey("dbo.Manifacturers", t => t.ManifacturerId, cascadeDelete: true)
                .ForeignKey("dbo.ManifacturerModels", t => t.ModelID, cascadeDelete: true)
                .Index(t => t.ManifacturerId)
                .Index(t => t.ModelID)
                .Index(t => t.FuelID)
                .Index(t => t.HeatTransferFluidID);
            
            CreateTable(
                "dbo.HeatTransferFluids",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OriginalFileName = c.String(),
                        UploadFileName = c.String(),
                        RelativePath = c.String(),
                        AbsolutePath = c.String(),
                        Lenght = c.Int(nullable: false),
                        Extension = c.String(),
                        ContentType = c.String(),
                        Description = c.String(),
                        Tags = c.String(),
                        Plant_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Plants", t => t.Plant_ID)
                .Index(t => t.Plant_ID);
            
            CreateTable(
                "dbo.Operations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.OutboundCalls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CallDate = c.DateTime(nullable: false),
                        ContactID = c.Int(nullable: false),
                        ResultID = c.Int(nullable: false),
                        Login = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Contacts", t => t.ContactID, cascadeDelete: true)
                .Index(t => t.ContactID);
            
            CreateTable(
                "dbo.PlantClasses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Plants",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.Int(nullable: false),
                        Name = c.String(),
                        PlantDistinctCode = c.String(),
                        BuildingAddress_Address = c.String(),
                        BuildingAddress_StreetNumber = c.String(),
                        BuildingAddress_Building = c.String(),
                        BuildingAddress_Stair = c.String(),
                        BuildingAddress_Apartment = c.String(),
                        BuildingAddress_City = c.String(),
                        BuildingAddress_PostalCode = c.String(),
                        BuildingAddress_Area = c.String(),
                        BuildingAddress_Zone = c.String(),
                        BuildingAddress_District = c.String(),
                        BuildingAddress_IsSingleUnit = c.Boolean(nullable: false),
                        BuildingAddress_EnergyCategory = c.Int(nullable: false),
                        BuildingAddress_GrossHeatedVolumeM3 = c.Single(nullable: false),
                        BuildingAddress_GrossCooledVolumeM3 = c.Single(nullable: false),
                        PlantClass_ID = c.Int(),
                        PlantType_ID = c.Int(),
                        Service_ID = c.Int(),
                        ThermalUnit_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.PlantClasses", t => t.PlantClass_ID)
                .ForeignKey("dbo.PlantTypes", t => t.PlantType_ID)
                .ForeignKey("dbo.PlantServices", t => t.Service_ID)
                .ForeignKey("dbo.ThermalUnits", t => t.ThermalUnit_ID)
                .Index(t => t.PlantClass_ID)
                .Index(t => t.PlantType_ID)
                .Index(t => t.Service_ID)
                .Index(t => t.ThermalUnit_ID);
            
            CreateTable(
                "dbo.PlantTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PlantServices",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PreviousServiceDate = c.DateTime(),
                        Periodicity = c.Int(nullable: false),
                        LegalExpirationDate = c.DateTime(nullable: false),
                        PlannedServiceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProposedOutBoundCalls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        User = c.String(),
                        PlantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Plants", t => t.PlantID, cascadeDelete: true)
                .Index(t => t.PlantID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FiscalCode = c.String(),
                        IBAN = c.String(),
                        Logo = c.String(),
                        Name = c.String(),
                        Vat_Number = c.String(),
                        Address_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_ID)
                .Index(t => t.Address_ID);
            
            CreateTable(
                "dbo.ThermalUnitKinds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.WarehouseMovements",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        ExecDate = c.DateTime(nullable: false),
                        Note = c.String(),
                        SourceID = c.Int(nullable: false),
                        DestinationID = c.Int(nullable: false),
                        CausalWarehouseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CausalWarehouses", t => t.CausalWarehouseID, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.DestinationID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.Warehouses", t => t.SourceID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.SourceID)
                .Index(t => t.DestinationID)
                .Index(t => t.CausalWarehouseID);
            
            CreateTable(
                "dbo.Warehouses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Description = c.String(),
                        HasValue = c.Boolean(nullable: false),
                        CheckStockBefore = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.WorkActions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ActionDate = c.DateTime(nullable: false),
                        OperationID = c.Int(nullable: false),
                        AssignedOperatorID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        PlantID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.WorkOperators", t => t.AssignedOperatorID, cascadeDelete: true)
                .ForeignKey("dbo.Operations", t => t.OperationID, cascadeDelete: true)
                .ForeignKey("dbo.Plants", t => t.PlantID, cascadeDelete: true)
                .ForeignKey("dbo.ActionTypes", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.OperationID)
                .Index(t => t.AssignedOperatorID)
                .Index(t => t.TypeID)
                .Index(t => t.PlantID);
            
            CreateTable(
                "dbo.WorkOperators",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WorkActions", "TypeID", "dbo.ActionTypes");
            DropForeignKey("dbo.WorkActions", "PlantID", "dbo.Plants");
            DropForeignKey("dbo.WorkActions", "OperationID", "dbo.Operations");
            DropForeignKey("dbo.WorkActions", "AssignedOperatorID", "dbo.WorkOperators");
            DropForeignKey("dbo.WarehouseMovements", "SourceID", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseMovements", "ProductID", "dbo.Products");
            DropForeignKey("dbo.WarehouseMovements", "DestinationID", "dbo.Warehouses");
            DropForeignKey("dbo.WarehouseMovements", "CausalWarehouseID", "dbo.CausalWarehouses");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sellers", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProposedOutBoundCalls", "PlantID", "dbo.Plants");
            DropForeignKey("dbo.Contacts", "ProposedOutBoundCall_ID", "dbo.ProposedOutBoundCalls");
            DropForeignKey("dbo.Plants", "ThermalUnit_ID", "dbo.ThermalUnits");
            DropForeignKey("dbo.Plants", "Service_ID", "dbo.PlantServices");
            DropForeignKey("dbo.Plants", "PlantType_ID", "dbo.PlantTypes");
            DropForeignKey("dbo.Plants", "PlantClass_ID", "dbo.PlantClasses");
            DropForeignKey("dbo.Media", "Plant_ID", "dbo.Plants");
            DropForeignKey("dbo.Contacts", "Plant_ID", "dbo.Plants");
            DropForeignKey("dbo.OutboundCalls", "ContactID", "dbo.Contacts");
            DropForeignKey("dbo.ThermalUnits", "ModelID", "dbo.ManifacturerModels");
            DropForeignKey("dbo.ThermalUnits", "ManifacturerId", "dbo.Manifacturers");
            DropForeignKey("dbo.ThermalUnits", "HeatTransferFluidID", "dbo.HeatTransferFluids");
            DropForeignKey("dbo.Heaters", "ThermalUnit_ID", "dbo.ThermalUnits");
            DropForeignKey("dbo.ThermalUnits", "FuelID", "dbo.Fuels");
            DropForeignKey("dbo.Heaters", "Model_ID", "dbo.ManifacturerModels");
            DropForeignKey("dbo.BoilerServices", "ManifacturerModel_ID", "dbo.ManifacturerModels");
            DropForeignKey("dbo.BoilerServices", "Type_ID", "dbo.BoilerServiceTypes");
            DropForeignKey("dbo.BoilerServices", "Boiler_ID", "dbo.Boilers");
            DropForeignKey("dbo.Boilers", "Model_ID", "dbo.ManifacturerModels");
            DropForeignKey("dbo.Boilers", "Manifacturer_ID", "dbo.Manifacturers");
            DropForeignKey("dbo.ManifacturerModels", "ManifacturerID", "dbo.Manifacturers");
            DropForeignKey("dbo.Heaters", "Manifacturer_ID", "dbo.Manifacturers");
            DropForeignKey("dbo.Heaters", "FuelID", "dbo.Fuels");
            DropForeignKey("dbo.DocumentTypes", "Numbering_ID", "dbo.Numberings");
            DropForeignKey("dbo.Numberings", "TempSerialSchemaID", "dbo.SerialSchemes");
            DropForeignKey("dbo.Numberings", "FinalSerialSchemaID", "dbo.SerialSchemes");
            DropForeignKey("dbo.Invoices", "Payment_ID", "dbo.Payments");
            DropForeignKey("dbo.InvoiceRows", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.InvoiceRows", "Invoice_ID", "dbo.Invoices");
            DropForeignKey("dbo.Invoices", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Addresses", "Customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Contacts", "Address_ID", "dbo.Addresses");
            DropForeignKey("dbo.Addresses", "AddressTypeID", "dbo.AddressTypes");
            DropIndex("dbo.WorkActions", new[] { "PlantID" });
            DropIndex("dbo.WorkActions", new[] { "TypeID" });
            DropIndex("dbo.WorkActions", new[] { "AssignedOperatorID" });
            DropIndex("dbo.WorkActions", new[] { "OperationID" });
            DropIndex("dbo.WarehouseMovements", new[] { "CausalWarehouseID" });
            DropIndex("dbo.WarehouseMovements", new[] { "DestinationID" });
            DropIndex("dbo.WarehouseMovements", new[] { "SourceID" });
            DropIndex("dbo.WarehouseMovements", new[] { "ProductID" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Sellers", new[] { "Address_ID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProposedOutBoundCalls", new[] { "PlantID" });
            DropIndex("dbo.Plants", new[] { "ThermalUnit_ID" });
            DropIndex("dbo.Plants", new[] { "Service_ID" });
            DropIndex("dbo.Plants", new[] { "PlantType_ID" });
            DropIndex("dbo.Plants", new[] { "PlantClass_ID" });
            DropIndex("dbo.OutboundCalls", new[] { "ContactID" });
            DropIndex("dbo.Media", new[] { "Plant_ID" });
            DropIndex("dbo.ThermalUnits", new[] { "HeatTransferFluidID" });
            DropIndex("dbo.ThermalUnits", new[] { "FuelID" });
            DropIndex("dbo.ThermalUnits", new[] { "ModelID" });
            DropIndex("dbo.ThermalUnits", new[] { "ManifacturerId" });
            DropIndex("dbo.Boilers", new[] { "Model_ID" });
            DropIndex("dbo.Boilers", new[] { "Manifacturer_ID" });
            DropIndex("dbo.BoilerServices", new[] { "ManifacturerModel_ID" });
            DropIndex("dbo.BoilerServices", new[] { "Type_ID" });
            DropIndex("dbo.BoilerServices", new[] { "Boiler_ID" });
            DropIndex("dbo.ManifacturerModels", new[] { "ManifacturerID" });
            DropIndex("dbo.Heaters", new[] { "ThermalUnit_ID" });
            DropIndex("dbo.Heaters", new[] { "Model_ID" });
            DropIndex("dbo.Heaters", new[] { "Manifacturer_ID" });
            DropIndex("dbo.Heaters", new[] { "FuelID" });
            DropIndex("dbo.Numberings", new[] { "FinalSerialSchemaID" });
            DropIndex("dbo.Numberings", new[] { "TempSerialSchemaID" });
            DropIndex("dbo.DocumentTypes", new[] { "Numbering_ID" });
            DropIndex("dbo.Invoices", new[] { "Payment_ID" });
            DropIndex("dbo.Invoices", new[] { "Customer_ID" });
            DropIndex("dbo.InvoiceRows", new[] { "Product_ID" });
            DropIndex("dbo.InvoiceRows", new[] { "Invoice_ID" });
            DropIndex("dbo.Contacts", new[] { "ProposedOutBoundCall_ID" });
            DropIndex("dbo.Contacts", new[] { "Plant_ID" });
            DropIndex("dbo.Contacts", new[] { "Address_ID" });
            DropIndex("dbo.Addresses", new[] { "Customer_ID" });
            DropIndex("dbo.Addresses", new[] { "AddressTypeID" });
            DropTable("dbo.WorkOperators");
            DropTable("dbo.WorkActions");
            DropTable("dbo.Warehouses");
            DropTable("dbo.WarehouseMovements");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ThermalUnitKinds");
            DropTable("dbo.Sellers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProposedOutBoundCalls");
            DropTable("dbo.PlantServices");
            DropTable("dbo.PlantTypes");
            DropTable("dbo.Plants");
            DropTable("dbo.PlantClasses");
            DropTable("dbo.OutboundCalls");
            DropTable("dbo.Operations");
            DropTable("dbo.Media");
            DropTable("dbo.HeatTransferFluids");
            DropTable("dbo.ThermalUnits");
            DropTable("dbo.BoilerServiceTypes");
            DropTable("dbo.Boilers");
            DropTable("dbo.BoilerServices");
            DropTable("dbo.ManifacturerModels");
            DropTable("dbo.Manifacturers");
            DropTable("dbo.Heaters");
            DropTable("dbo.Fuels");
            DropTable("dbo.SerialSchemes");
            DropTable("dbo.Numberings");
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Payments");
            DropTable("dbo.Products");
            DropTable("dbo.Invoices");
            DropTable("dbo.InvoiceRows");
            DropTable("dbo.Customers");
            DropTable("dbo.Contacts");
            DropTable("dbo.CausalWarehouses");
            DropTable("dbo.CausalWarehouseGroups");
            DropTable("dbo.CausalDocuments");
            DropTable("dbo.AddressTypes");
            DropTable("dbo.Addresses");
            DropTable("dbo.ActionTypes");
        }
    }
}
