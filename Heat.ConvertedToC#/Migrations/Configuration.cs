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
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Heat.Repositories;
using System.Security.Claims;
using System.Data.Entity.Validation;

namespace Heat.Migrations
{

	public sealed class Configuration : DbMigrationsConfiguration<HeatDBContext>
	{

		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
			AutomaticMigrationDataLossAllowed = true;
			ContextKey = "Heat.HeatDBContext";
		}

		public void InitializeIdentity(HeatDBContext context)
		{
			HeatRoleManager rm = new HeatRoleManager(new RoleStore<HeatRole>(context));
			//( HttpContext.Current.GetOwinContext().Get(Of HeatRoleManager)()
			UserStore<HeatUser> us = new UserStore<HeatUser>(context);
			//Dim um As HeatUserManager = New HeatUserManager(New UserStore(Of HeatUser)(context)) 'context.GetUserManager(Of HeatUserManager)()
			HeatUserManager um = new HeatUserManager(us);
			//context.GetUserManager(Of HeatUserManager)()



			const string demoName = "demo";
			const string demoPassword = "demodemo";
			const string CAN_VIEW = "canView";

			const string adminName = "admin";
			const string adminPassword = "adminadmin";
			const string CAN_EDIT = "canEdit";

			const string CAN_VIEW_FUELS = "canViewFuels";


			var canViewRole = rm.FindByName(CAN_VIEW);
			if ((canViewRole == null)) {
				canViewRole = new HeatRole(CAN_VIEW, "Può visualizzare");
				var result = rm.Create(canViewRole);
			}

			var canViewFuelsRole = rm.FindByName(CAN_VIEW_FUELS);
			if ((canViewFuelsRole == null)) {
				canViewFuelsRole = new HeatRole(CAN_VIEW_FUELS, "Può visualizzare i carburanti");
				var result = rm.Create(canViewFuelsRole);
			}

			var demoUser = um.FindByName(demoName);
			if ((demoUser == null)) {
				demoUser = new HeatUser { UserName = demoName };
				var result = um.Create(demoUser, demoPassword);
				result = um.SetLockoutEnabled(demoUser.Id, false);
				Claim cl = new Claim("http://scheme.diegobrocchi.it/claims/2015/operation", ResourceOperations.Execute, "ResourceOperations");
				um.AddClaim(demoUser.Id, cl);
			}

			var RolesForUser = um.GetRoles(demoUser.Id);
			if (!RolesForUser.Contains(canViewRole.Name)) {
				var result = um.AddToRole(demoUser.Id, canViewRole.Name);

			}

			var canEditRole = rm.FindByName(CAN_EDIT);
			if ((canEditRole == null)) {
				canEditRole = new HeatRole(CAN_EDIT, "Può modificare");
				var result = rm.Create(canEditRole);
			}

			var admUser = um.FindByName(adminName);
			if ((admUser == null)) {
				admUser = new HeatUser { UserName = adminName };
				var result = um.Create(admUser, adminPassword);
				result = um.SetLockoutEnabled(admUser.Id, false);

				Claim cl1 = new Claim(ClaimTypes.Country, "italy");
				um.AddClaim(admUser.Id, cl1);
			}

			RolesForUser = um.GetRoles(admUser.Id);
			if (!RolesForUser.Contains(canEditRole.Name)) {
				var result = um.AddToRole(admUser.Id, canEditRole.Name);
				result = um.AddToRole(admUser.Id, canViewRole.Name);
			}
			if (!RolesForUser.Contains(canViewRole.Name)) {
				var result = um.AddToRole(admUser.Id, canEditRole.Name);
			}
			if (!RolesForUser.Contains(canViewFuelsRole.Name)) {
				var result = um.AddToRole(admUser.Id, canViewFuelsRole.Name);
			}






		}

		protected bool AddUserAndRole(HeatDBContext context)
		{
			IdentityResult ir = null;
			var rm = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
			ir = rm.Create(new HeatRole("canEdit", "Può Modificare 99"));
			var um = new HeatUserManager(new UserStore<HeatUser>(context));
			var user = new HeatUser { UserName = "demo" };

			ir = um.Create(user, "demo");
			if (ir.Succeeded == false) {
				return ir.Succeeded;
			}
			ir = um.AddToRole(user.Id, "canEdit");
			return ir.Succeeded;

		}

		protected override void Seed(HeatDBContext context)
		{
			//If Not System.Diagnostics.Debugger.IsAttached Then
			//    System.Diagnostics.Debugger.Launch()
			//End If

			InitializeIdentity(context);

			Models.Fuel Fuel1 = new Models.Fuel();
			Models.Fuel Fuel2 = new Models.Fuel();
			Models.Fuel Fuel3 = new Models.Fuel();

			Models.CausalDocument CausalDocument1 = new Models.CausalDocument();
			Models.CausalDocument CausalDocument2 = new Models.CausalDocument();
			Models.CausalDocument CausalDocument3 = new Models.CausalDocument();

			Models.Payment Payment1 = new Models.Payment();
			Models.Payment Payment2 = new Models.Payment();
			Models.Payment Payment3 = new Models.Payment();

			Models.Seller DittaMC = new Models.Seller();

			Models.DocumentType FTC = new Models.DocumentType();

			Models.SerialScheme simpleSchema = new Models.SerialScheme();

			Models.Numbering number = new Models.Numbering();


			Models.Product product1 = new Models.Product();
			Models.Product product2 = new Models.Product();

			Models.AddressType addressType1 = new Models.AddressType();
			Models.AddressType addressType2 = new Models.AddressType();

			Models.Operation op1 = new Models.Operation();
			Models.Operation op2 = new Models.Operation();
			Models.Operation op3 = new Models.Operation();

			Models.WorkOperator wop1 = new Models.WorkOperator();
			Models.WorkOperator wop2 = new Models.WorkOperator();

			Models.Manifacturer manu1 = new Models.Manifacturer();
			Models.Manifacturer manu2 = new Models.Manifacturer();

			Models.ManifacturerModel manuModel1 = new Models.ManifacturerModel();
			Models.ManifacturerModel manuModel2 = new Models.ManifacturerModel();

			Models.HeatTransferFluid flu1 = new Models.HeatTransferFluid();
			Models.HeatTransferFluid flu2 = new Models.HeatTransferFluid();

			Models.ThermalUnitKind tuk1 = new Models.ThermalUnitKind();
			Models.ThermalUnitKind tuk2 = new Models.ThermalUnitKind();

			Models.PlantClass plc1 = new Models.PlantClass();
			Models.planttype pt1 = new Models.planttype();
			Models.Plant pl1 = new Models.Plant();


			Fuel1.Name = "Gasolio";
			Fuel2.Name = "Metano";
			Fuel3.Name = "Cippato";

			CausalDocument1.Code = "VEN";
			CausalDocument1.Description = "Vendita";

			CausalDocument2.Code = "SER";
			CausalDocument2.Description = "Servizi";

			CausalDocument3.Code = "ACQ";
			CausalDocument3.Description = "Acquisto";

			Payment1.Code = "RIBA30";
			Payment1.Description = "Ricevuta bancaria a 30 giorni";

			Payment2.Code = "RIBA60";
			Payment2.Description = "Ricevuta bancaria a 60 giorni";

			Payment3.Code = "RIBA90";
			Payment3.Description = "Ricevuta bancaria a 90 giorni";


			DittaMC.FiscalCode = "ABCDEFGHILMNOPQRSTUVZ";
			DittaMC.IBAN = "IT000000000000000";
			DittaMC.Logo = "LogoMC.jpg";
			DittaMC.Name = "MC Assistenza Srl di Mauro Cedro";
			DittaMC.Vat_Number = "1234567890";
			DittaMC.Address = new Models.Address {
				StreetNumber = "Via Rossi, 23",
				City = "Mandello",
				AddressType = addressType1
			};

			number.Code = "FTC";
			number.Description = "Numeratore FTC";
			number.TempSerialSchema = simpleSchema;
			number.FinalSerialSchema = simpleSchema;

			number.LastTempSerial = new Models.SerialNumber {
				SerialInteger = 0,
				SerialString = "0",
				IsValid = true
			};
			number.LastFinalSerial = new Models.SerialNumber {
				SerialInteger = 0,
				SerialString = "0",
				IsValid = true
			};

			simpleSchema.Description = "Schema semplice";
			simpleSchema.Increment = 1;
			simpleSchema.InitialValue = 1;
			simpleSchema.Period = Periodicity.None;
			simpleSchema.Name = "INC_1";


			FTC.Name = "FTC";
			FTC.Description = "Fattura Cliente";
			FTC.Numbering = number;

			product1.Cost = 3.56;
			product1.Description = "Ghiera modello XYZ";
			product1.ReorderLevel = 30;
			product1.SKU = "MCS_GH_XYZ";
			product1.UnitPrice = 7.76;

			product2.Cost = 3;
			product2.Description = "Tubo modello ABC";
			product2.ReorderLevel = 10;
			product2.SKU = "MCS_TU_ABC";
			product2.UnitPrice = 2.7;

			addressType1.Description = "Indirizzo impianto";
			addressType2.Description = "Indirizzo di fatturazione";

			op1.Code = "INT1";
			op1.Description = "Operazione di tipo 1";

			op2.Code = "INT2";
			op2.Description = "Operazione di tipo 2";

			op3.Code = "INT3";
			op3.Description = "Operazione di tipo 3";

			wop1.Name = "Diego Brocchi";
			wop2.Name = "Mario Rossi";

			manu1.Name = "Beretta";
			manu2.Name = "Vaillant";

			flu1.Name = "Acqua";
			flu2.Name = "Vapore";

			tuk1.Description = "Gruppo termico singolo";

			plc1.Name = "Classe 1";

			pt1.Name = "Climatizzazione";

			pl1.Code = 999;
			pl1.Name = "impianto XYZ";
			pl1.PlantClass = plc1;
			pl1.PlantType = pt1;
			pl1.BuildingAddress = new Models.PlantBuilding();

			//###################################
			//Aggiunta dati al DB
			//###################################

			context.CausalDocuments.AddOrUpdate(c => c.Code, CausalDocument1);
			context.CausalDocuments.AddOrUpdate(c => c.Code, CausalDocument2);
			context.CausalDocuments.AddOrUpdate(c => c.Code, CausalDocument3);

			context.Fuels.AddOrUpdate(f => f.Name, Fuel1);
			context.Fuels.AddOrUpdate(f => f.Name, Fuel2);
			context.Fuels.AddOrUpdate(f => f.Name, Fuel3);

			context.Payments.AddOrUpdate(p => p.Code, Payment1);
			context.Payments.AddOrUpdate(p => p.Code, Payment2);
			context.Payments.AddOrUpdate(p => p.Code, Payment3);

			context.Seller.AddOrUpdate(s => s.Name, DittaMC);

			context.SerialSchemes.AddOrUpdate(ss => ss.Name, simpleSchema);

			context.PlantClasses.AddOrUpdate(pc => pc.Name, plc1);
			context.PlantTypes.AddOrUpdate(pt => pt.Name, pt1);

			pl1.PlantClass = plc1;
			pl1.PlantType = pt1;
			context.Plants.AddOrUpdate(p => p.Name, pl1);



			//*****************
			//HACK HACK HACK
			//assegna il valore alla proprietà ID dello schema, atrimenti si arrabbia
			number.TempSerialSchemaID = simpleSchema.ID;
			number.FinalSerialSchemaID = simpleSchema.ID;
			//fine HACK

			context.Numberings.AddOrUpdate(n => n.Code, number);
			context.DocumentTypes.AddOrUpdate(dt => dt.Name, FTC);

			context.Products.AddOrUpdate(p => p.SKU, product1);
			context.Products.AddOrUpdate(p => p.SKU, product2);

			context.AddressTypes.AddOrUpdate(at => at.Description, addressType1);
			context.AddressTypes.AddOrUpdate(at => at.Description, addressType2);

			context.Operations.AddOrUpdate(o => o.Code, op1);
			context.Operations.AddOrUpdate(o => o.Code, op2);
			context.Operations.AddOrUpdate(o => o.Code, op3);

			context.WorkOperators.AddOrUpdate(wo => wo.Name, wop1);
			context.WorkOperators.AddOrUpdate(wo => wo.Name, wop2);

			context.Manifacturers.AddOrUpdate(m => m.Name, manu1);
			context.Manifacturers.AddOrUpdate(m => m.Name, manu2);

			//***********************************
			//HACK HACK HACK
			//altrimenti EF rompe con UPDATE e FOREIGN KEY
			manuModel1.Manifacturer = manu1;
			manuModel1.ManifacturerID = manu1.ID;
			manuModel1.Model = "ModelXYZ";

			manuModel2.Manifacturer = manu2;
			manuModel2.ManifacturerID = manu2.ID;
			manuModel2.Model = "ModelABC";

			//l'hack consiste nel valorizzare manifacturerID con il suo attuale valore, altrimenti è 0 si arrabbia.
			//FINE HACK

			context.ManifacturerModels.AddOrUpdate(m => m.Model, manuModel1);
			context.ManifacturerModels.AddOrUpdate(m => m.Model, manuModel2);

			context.HeatTransferFluids.AddOrUpdate(x => x.Name, flu1);
			context.HeatTransferFluids.AddOrUpdate(x => x.Name, flu2);

			context.ThermalUnitKinds.AddOrUpdate(x => x.Description, tuk1);

			context.SaveChanges();

			//################################

		}



	}

}
