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
    public class RolLogic
    {
        public IPagedList<Roles> Get(DataContext dataContext, string searchKey, int? page)
        {
            var query = new RolDataAccess().Get(dataContext).AsQueryable();
            var p = page ?? 1;
            if (string.IsNullOrEmpty(searchKey))
            {
                foreach (var token in searchKey.Split(' '))
                    query = query.Where(x => x.RolName.Contains(token) 
                                                || x.RolDescription.Contains(token));
            }

            return query.ToPagedList(p, ConstantHelper.DEFAULT_PAGE_SIZE);
        }

        public RolViewModel Get(DataContext dataContext, int? id)
        {
            return ConvertHelper.CopyAToB(new RolDataAccess().Get(dataContext, id), null) as RolViewModel;
        }

    }
}
