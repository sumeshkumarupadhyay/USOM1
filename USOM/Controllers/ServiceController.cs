using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USOM.Controllers
{
    public class ServiceController : BaseController<ServiceEntity, ServiceViewModel>
    {
        public override ActionResult Index()
        {
            return View(Context.Services.Include(a => a.ServiceCategory).OrderByDescending(a => a.Id).ToList());
        }

        public override ActionResult Create()
        {
            ViewBag.ServiceCategory = Context.ServiceCategories.OrderByDescending(a => a.Id).ToList();
            return base.Create();
        }

        public override ActionResult Edit(int id)
        {
            ViewBag.ServiceCategory = Context.ServiceCategories.OrderByDescending(a => a.Id).ToList();
            return base.Edit(id);
        }
    }
}