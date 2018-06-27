using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.Administration
{
    public class UserLogic
    {
        public IPagedList<Users> Get(DataContext dataContext, string searchKey, int? page)
        {
            var query = new UserDataAccess().Get(dataContext).AsQueryable();
            var p = page ?? 1;
            if (string.IsNullOrEmpty(searchKey))
            {
                foreach (var token in searchKey.Split(' '))
                    query = query.Where(x => x.UserName.Contains(token));
            }

            return query.ToPagedList(p, ConstantHelper.DEFAULT_PAGE_SIZE);
        }

        public UserViewModel Get(DataContext dataContext, int? id)
        {
            return ConvertHelper.CopyAToB(new UserDataAccess().Get(dataContext, id), null) as UserViewModel;
        }

        public void AddUpdate(DataContext dataContext, UserViewModel model)
        {
            new UserDataAccess().AddUpdate(dataContext, model);
        }
    }
}
