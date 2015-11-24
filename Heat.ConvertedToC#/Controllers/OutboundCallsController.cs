using System;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System.Net;
using System.Security.Principal;
using Heat.Models;
using Heat.ViewModels.OutboundCalls;
using System.Web.Routing;

namespace Heat.Controllers
{
    public class OutboundCallsController : System.Web.Mvc.Controller
    {

        private IHeatDBContext _db;
        private OutboundCallsModelViewBuilder _mb;
        private Manager.OutboundCallsManager _ocm;

        public OutboundCallsController(IHeatDBContext dbContext)
        {
            _db = dbContext;
            _mb = new OutboundCallsModelViewBuilder(_db);
            _ocm = new Manager.OutboundCallsManager(_db);
        }

        [HttpGet]
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

        [HttpPost]
        public ActionResult SetCriteria(CriteriaViewModel criteria, IPrincipal User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    OutboundCallsCriteria assignedCriteria = _ocm.ToCriteria(criteria);
                    assignedCriteria.Login = User.Identity.Name;

                    return RedirectToAction("GetNextProposed", new RouteValueDictionary(assignedCriteria));
                }
                else
                {
                    return View(_mb.GetCriteriaViewModel());
                }
            }
            catch (Exception ex)
            {
                ViewBag.message = ex.ToString();
                return View("error");
            }

        }

        [HttpGet()]
        public ActionResult GetNextProposed(OutboundCallsCriteria criteria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProposedOutboundCallsViewModel model;
                    model = _mb.GetNextProposed(criteria);
                    return View(model);
                }
                else
                {
                    return RedirectToAction("SetCriteria");
                }
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
