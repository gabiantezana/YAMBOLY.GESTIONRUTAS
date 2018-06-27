using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration
{
    public class RolDataAccess
    {
        public List<Roles> Get(DataContext dataContext)
        {
            return dataContext.context.Roles.ToList();
        }

        public Roles Get(DataContext dataContext, int? id)
        {
            return dataContext.context.Roles.Find(id);
        }
    }
}
