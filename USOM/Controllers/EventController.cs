using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace USOM.Controllers
{
	public class EventController : BaseController<EventEntity, EventViewModel>
	{
		public override ActionResult Index()
		{
			return View(Context.Events.Include(a => a.EventType).ToList());
		}

		public override ActionResult Create()
		{
			ViewBag.EventCategory = Context.EventTypes.OrderByDescending(a => a.Id).ToList();
			return base.Create();
		}

		public override ActionResult Edit(int id)
		{
			ViewBag.EventCategory = Context.EventTypes.OrderByDescending(a => a.Id).ToList();
			return base.Edit(id);
		}
	}
}