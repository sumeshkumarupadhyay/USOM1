using AutoMapper;
using USOM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace USOM
{
	[Authorize(Roles = "Admin")]
	public class BaseController<T, VM> : Controller, IBaseController<T, VM>
		where T : BaseEntity where VM : BaseViewModel
	{
		protected readonly ApplicationDbContext Context = new ApplicationDbContext();
		protected MapperConfiguration _config;
		protected IMapper _mapper;
		public BaseController()
		{
			_config = new MapperConfiguration(cfg =>
			{
				cfg.CreateMap<T, VM>();
				cfg.CreateMap<VM, T>();
			});
			_mapper = _config.CreateMapper();
		}

		public virtual ActionResult Index() => View(GetAll(string.Empty));

		public virtual ActionResult Create() => View();


		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Create(VM viewModel)
		{
			if (!ModelState.IsValid)
			{
				TempData["message"] = "Data is not correct! Check data and try again!";
				TempData["success"] = true;
				return View(viewModel);
			}

			await AddAsync(viewModel);
			return RedirectToAction("index");
		}


		public virtual ActionResult Edit(int id)
		{
			return View(_mapper.Map<T, VM>(GetDataById(id)));
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public virtual async Task<ActionResult> Edit(VM viewModel)
		{
			string currentImageFile = GetDataById(viewModel.Id).FilePath;
			if (viewModel.File != null && viewModel.File[0] != null)
			{
				viewModel.FilePath = FileUpload(viewModel.File[0]);
				currentImageFile = viewModel.FilePath;
			}

			T entity = _mapper.Map<VM, T>(viewModel);
			entity.FilePath = currentImageFile;

			await EditAsync(entity);
			return RedirectToAction("index");
		}

		public virtual async Task<ActionResult> Remove(int id)
		{
			try
			{
				await RemoveAsyc(id);

				return RedirectToAction("index");
			}
			catch (Exception ex)
			{
				TempData["message"] = ex.Message.ToString();
				TempData["success"] = false;
				return RedirectToAction("Index");
			}

		}


		public async virtual Task AddAsync(VM viewModel)
		{
			//assuming that viewModel.File contains only one file. 
			//if you need more than one file then override this method
			string filePath = string.Empty;
			if (viewModel.File != null && viewModel.File.Length > 0)
			{
				filePath = FileUpload(viewModel.File[0]);
			}

			viewModel.FilePath = filePath;
			T model = _mapper.Map<VM, T>(viewModel);

			model.CreationDate = DateTime.UtcNow.GetLocal();
			model.LastModificationDate = DateTime.UtcNow.GetLocal();
			model.IsDeleted = false;
			Context.Set<T>().Add(model);
			await Context.SaveChangesAsync();
			TempData["message"] = "Data Saved Successfully";
			TempData["success"] = true;
		}



		public async virtual Task EditAsync(T model)
		{
			model.LastModificationDate = DateTime.UtcNow.GetLocal();
			Context.Entry<T>(model).State = EntityState.Modified;
			await Context.SaveChangesAsync();
			TempData["message"] = "Data edited Successfully";
			TempData["success"] = true;
		}

		public async virtual Task RemoveAsyc(int id)
		{
			T model = Context.Set<T>().Find(id);

			if (model == null)
			{
				throw new ValidationException("Data not available");
			}

			Context.Set<T>().Remove(model);
			await Context.SaveChangesAsync();
			TempData["message"] = "Data deleted Successfully";
			TempData["success"] = true;
		}

		public virtual IList<VM> GetAll(string resolvedPropertyList)
		{


			var query = Context.Set<T>().AsQueryable().AsNoTracking();
			if (!string.IsNullOrEmpty(resolvedPropertyList))
			{
				query = query.Include(resolvedPropertyList).OrderByDescending(a => a.Id);
			}

			return _mapper.Map<IList<T>, IList<VM>>(query.ToList()) ?? new List<VM>();
		}

		public virtual T GetDataById(int id)
		{
			var result = Context.Set<T>().Find(id);
			Context.Entry(result).State = EntityState.Detached;
			return result;
		}

		public string FileUpload(HttpPostedFileBase file)
		{
			if (file == null)
			{
				return string.Empty;
			}
			string tableName = (typeof(T).GetCustomAttributes(typeof(TableAttribute), true)
									.FirstOrDefault() as TableAttribute).Name;

			string folderPath = Server.MapPath($"~/uploads/{tableName}");

			return FileHandler.UploadFile(folderPath, file);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Context.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}