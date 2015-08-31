﻿Imports System.Web.Optimization
Imports System.Web.Helpers
Imports System.Security.Claims
Imports System.IdentityModel.Services
Imports AutoMapper
Imports Heat.Models


Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Protected Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
        BundleConfig.RegisterBundles(BundleTable.Bundles)

        'http://www.codeproject.com/Articles/639458/Claims-Based-Authentication-and-Authorization
        AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name

        Mapper.CreateMap(Of SerialScheme, CreateSerialSchemeViewModel)().Bidirectional()
        Mapper.CreateMap(Of SerialScheme, IndexSerialSchemeViewModel)()

        Mapper.CreateMap(Of Numbering, CreateNumberingViewModel)().
            ForMember(Function(dest) dest.TempSerialSchemaList, Sub(opt) opt.Ignore()).
            ForMember(Function(dest) dest.FinalSerialSchemaList, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of CreateNumberingViewModel, Numbering)(). _
            ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.LastTempSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.LastFinalSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.FinalSerialSchema, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.TempSerialSchema, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Numbering, EditNumberingViewModel)().ForMember(Function(dest) dest.FinalSerialSchemaList, Sub(opt) opt.Ignore()).ForMember(Function(dest) dest.TempSerialSchemaList, Sub(opt) opt.Ignore())
        Mapper.CreateMap(Of EditNumberingViewModel, Numbering)(). _
            ForMember(Function(dest) dest.LastFinalSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.LastTempSerial, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.FinalSerialSchema, Sub(opt) opt.Ignore()). _
            ForMember(Function(dest) dest.TempSerialSchema, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of Numbering, IndexNumberingViewModel)(). _
            ForMember(Function(dest) dest.FinalSerialSchema, Sub(opt) opt.MapFrom(Function(source) source.FinalSerialSchema.Description)). _
            ForMember(Function(dest) dest.TempSerialSchema, Sub(opt) opt.MapFrom(Function(source) source.TempSerialSchema.Description))

        Mapper.CreateMap(Of Customer, ViewModels.Customers.IndexCustomerGridViewModel)()  

        Mapper.CreateMap(Of ViewModels.Customers.CreateCustomerViewModel, Customer)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Addresses, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.CreationDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DisableDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.EnableDate, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.Customers.EditCustomerViewModel, Customer)() _
            .ForMember(Function(dest) dest.Addresses, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.CreationDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DisableDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.EnableDate, Sub(opt) opt.Ignore()).Bidirectional()

        Mapper.CreateMap(Of ViewModels.ManifacturerModels.CreateManifacturerModelViewModel, ManifacturerModel)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Services, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.ManifacturerModels.EditManifacturerModelViewModel, ManifacturerModel)() _
            .ForMember(Function(dest) dest.Services, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore())

        Mapper.CreateMap(Of ViewModels.ThermalUnits.CreateThermalUnitViewModel, ThermalUnit)() _
            .ForMember(Function(dest) dest.ID, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.DismissDate, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Manifacturer, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Model, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.Fuel, Sub(opt) opt.Ignore()) _
            .ForMember(Function(dest) dest.HeatTransferFluid, Sub(opt) opt.Ignore())



        Mapper.AssertConfigurationIsValid()

        ModelBinders.Binders.Add(GetType(Decimal), New DecimalModelBinder())

    End Sub



End Class
