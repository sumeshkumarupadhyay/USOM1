using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;

namespace USOM
{
	public interface IBaseController<T, VM>
		where T : BaseEntity where VM : BaseViewModel
	{
		Task AddAsync(VM model);

		Task EditAsync(T model);

		Task RemoveAsyc(int id);

		IList<VM> GetAll(string resolvedPropertyList);

		T GetDataById(int id);

		string FileUpload(HttpPostedFileBase file);
	}
}