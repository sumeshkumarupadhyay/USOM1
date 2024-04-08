using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace USOM.Controllers
{
	public class BlogController : BaseController<BlogEntity, BlogViewModel>
	{
		public override ActionResult Index()
		{
			return View(Context.Blogs.Include(a => a.BlogCategory).ToList());
		}

		public override ActionResult Create()
		{
			ViewBag.BlogCategory = Context.BlogCategories.OrderByDescending(a => a.Id).ToList();
			return base.Create();
		}

		public override ActionResult Edit(int id)
		{
			ViewBag.BlogCategory = Context.BlogCategories.OrderByDescending(a => a.Id).ToList();
			return base.Edit(id);
		}
	}
}