using System;
using System.Linq;
using System.Security.Claims;
using System.Data.Entity.Validation;
using System.Data.Entity.Migrations;
using Microsoft.AspNet.Identity; 
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Heat.Models;
using Heat.Repositories;
using System.Collections.Generic;


namespace Heat.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<Repositories.HeatDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HeatDBContext context)
        {

            InitializeIdentity(context );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
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


            HeatRole canViewRole = rm.FindByName(CAN_VIEW);
            if ((canViewRole == null))
            {
                canViewRole = new HeatRole(CAN_VIEW, "Può visualizzare");
                dynamic result = rm.Create(canViewRole);
            }

            HeatRole canViewFuelsRole = rm.FindByName(CAN_VIEW_FUELS);
            if ((canViewFuelsRole == null))
            {
                canViewFuelsRole = new HeatRole(CAN_VIEW_FUELS, "Può visualizzare i carburanti");
                dynamic result = rm.Create(canViewFuelsRole);
            }

            HeatUser demoUser = um.FindByName(demoName);
            if ((demoUser == null))
            {
                demoUser = new HeatUser { UserName = demoName };
                dynamic result = um.Create(demoUser, demoPassword);
                result = um.SetLockoutEnabled(demoUser.Id, false);
                Claim cl = new Claim("http://scheme.diegobrocchi.it/claims/2015/operation", ResourceOperations.Execute.ToString(), "ResourceOperations");
                um.AddClaim(demoUser.Id, cl);
            }

            IList<string> RolesForUser = um.GetRoles(demoUser.Id);
            if (!RolesForUser.Contains(canViewRole.Name))
            {
                dynamic result = um.AddToRole(demoUser.Id, canViewRole.Name);

            }

            HeatRole canEditRole = rm.FindByName(CAN_EDIT);
            if ((canEditRole == null))
            {
                canEditRole = new HeatRole(CAN_EDIT, "Può modificare");
                dynamic result = rm.Create(canEditRole);
            }

            HeatUser admUser = um.FindByName(adminName);
            if ((admUser == null))
            {
                admUser = new HeatUser { UserName = adminName };
                dynamic result = um.Create(admUser, adminPassword);
                result = um.SetLockoutEnabled(admUser.Id, false);

                Claim cl1 = new Claim(ClaimTypes.Country, "italy");
                um.AddClaim(admUser.Id, cl1);
            }

            RolesForUser = um.GetRoles(admUser.Id);
            if (!RolesForUser.Contains(canEditRole.Name))
            {
                dynamic result = um.AddToRole(admUser.Id, canEditRole.Name);
                result = um.AddToRole(admUser.Id, canViewRole.Name);
            }
            if (!RolesForUser.Contains(canViewRole.Name))
            {
                dynamic result = um.AddToRole(admUser.Id, canEditRole.Name);
            }
            if (!RolesForUser.Contains(canViewFuelsRole.Name))
            {
                dynamic result = um.AddToRole(admUser.Id, canViewFuelsRole.Name);
            }






        }

    }
}
