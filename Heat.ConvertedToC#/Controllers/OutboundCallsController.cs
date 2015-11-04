using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Security.Principal;
using Heat.Models;
using Heat.ViewModels.OutboundCalls;

namespace Heat.Controllers
{
    public class OutboundCallsController : System.Web.Mvc.Controller
    {

        private IHeatDBContext _db;
        private OutboundCallsModelViewBuilder _mb;

        public OutboundCallsController(IHeatDBContext dbContext)
        {
            _db = dbContext;
            _mb = new OutboundCallsModelViewBuilder(_db);
        }


        public ActionResult Index(IPrincipal user)
        {
            try
            {
                var model = _mb.GetIndexViewModel(user.Identity.Name);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.ToString();
                return View("error");
            }
        }

        [HttpGet]
        public ActionResult SetCriteria()
        {
            CriteriaViewModel model;
            model = _mb.GetCriteriaViewModel();
            return View(model);
        }

        [HttpGet()]
        public ActionResult GetNextProposed(IPrincipal login)
        {
            try
            {
                ProposedOutboundCallsViewModel model;
                model = _mb.GetNextProposed(login.Identity.Name);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.ToString();
                return View("error");
            }

        }

        protected override void Dispose(bool disposing)
        {
            if ((disposing))
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
