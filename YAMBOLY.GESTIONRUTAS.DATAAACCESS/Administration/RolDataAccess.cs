using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Rol;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration
{
    public class RolDataAccess
    {
        public List<Roles> Get(DataContext dataContext)
        {
            return dataContext.context.Roles.Where(x => x.RolName != AppRol.SUPERADMINISTRATOR.ToString()).ToList();
        }

        public Roles Get(DataContext dataContext, int? id)
        {
            return dataContext.context.Roles.Find(id);
        }

        public void AddUpdate(DataContext dataContext, RolViewModel model)
        {
            var isUpdate = true;
            var rol = dataContext.context.Roles.Find(model.RolId);
            if (rol == null)
            {
                rol = new Roles();
                isUpdate = false;
            }

            rol.RolName = model.RolName;
            rol.RolDescription = model.RolDescription;
            if (isUpdate)
                dataContext.context.Entry(rol);
            else
                dataContext.context.Roles.Add(rol);
            dataContext.context.SaveChanges();
        }
    }
}
