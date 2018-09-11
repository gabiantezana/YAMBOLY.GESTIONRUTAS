using PagedList;
using System.Collections.Generic;
using System.Linq;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration;
using YAMBOLY.GESTIONRUTAS.EXCEPTION;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Rol;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.Administration
{
    public class RolLogic
    {
        public List<RolViewModel> GetList(DataContext dataContext)
        {
            var modelList = new List<RolViewModel>();

            IEnumerable<Roles> list = new RolDataAccess().Get(dataContext);
            list.ToList().ForEach(x => modelList.Add(GetRolViewModel(x)));

            return modelList;
        }

        private  RolViewModel GetRolViewModel(Roles rol)
        {
            var model = new RolViewModel();
            if (rol == null)
                return model;

            model = rol.ConvertTo(typeof(RolViewModel));
            return model;
        }

        public  RolListViewModel EditPermisosPorRoles(DataContext dataContext, int rolId)
        {
            var model = new RolListViewModel
            {
                RolId = rolId,
                 ViewGroupList= dataContext.context.ViewGroup.ToList(),
                ViewList = dataContext.context.Views.ToList(),
                RolesViewList = dataContext.context.RolesViews.Where(x => x.RolId == rolId).ToList()
            };
            return model;
        }

        public IPagedList<Roles> GetList(DataContext dataContext, string searchKey, int? page)
        {
            var query = new RolDataAccess().Get(dataContext).AsQueryable();
            var p = page ?? 1;
            if (!string.IsNullOrEmpty(searchKey))
            {
                foreach (var token in searchKey.Split(' '))
                    query = query.Where(x => x.RolName.Contains(token)
                                                || x.RolDescription.Contains(token));
            }

            return query.ToPagedList(p, ConstantHelper.DEFAULT_PAGE_SIZE);
        }

        public RolViewModel Get(DataContext dataContext, int? id)
        {
            return ConvertHelper.CopyAToB(new RolDataAccess().Get(dataContext, id), new RolViewModel()) as RolViewModel;
        }

        public List<JsonEntity> GetList(DataContext dataContext, string searchKey)
        {
            return GetList(dataContext, searchKey, null).Select(x => new JsonEntity() { id = x.RolId, text = x.RolName }).ToList();
        }

        public void AddUpdate(DataContext dataContext, RolViewModel model)
        {
            var exists = dataContext.context.Roles.FirstOrDefault(x => x.RolName == model.RolName && x.RolId != model.RolId) != null;
            if (exists)
                throw new CustomException("El nombre del rol especificado ya existe.");
            new RolDataAccess().AddUpdate(dataContext, model);
        }
    }
}
