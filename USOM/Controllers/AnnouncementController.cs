using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace USOM.Controllers
{
	public class AnnouncementController : BaseController<AnnouncementEntity, AnnouncementViewModel>
	{
		public override ActionResult Index()
		{
			return View(Context.Announcements.Include(a => a.AnnouncementCategory).OrderByDescending(a => a.Id).ToList());
		}

		public override ActionResult Create()
		{
			ViewBag.AnnouncementCategory = Context.AnnouncementCategories.OrderByDescending(a => a.Id).ToList();
			return base.Create();
		}

		public override ActionResult Edit(int id)
		{
			ViewBag.AnnouncementCategory = Context.AnnouncementCategories.OrderByDescending(a => a.Id).ToList();
			return base.Edit(id);
		}
	}
}