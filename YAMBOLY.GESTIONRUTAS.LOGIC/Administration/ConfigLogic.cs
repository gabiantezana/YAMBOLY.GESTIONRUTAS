using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Config;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.Administration
{
    public class ConfigLogic
    {
        public List<ConfigViewModel> GetList(DataContext dataContext)
        {
            var list = new ConfigDataAccess().GetList(dataContext).Select(x => new ConfigViewModel()
            {
                Id = x.ConfigId,
                Key = x.C_Key,
                Name = x.C_Name,
                Description = x.C_Description,
                Value = x.C_Value
            }).ToList();
            return list;
        }
        public void Update(DataContext dataContext, List<JsonEntityTwoString> list)
        {
            new ConfigDataAccess().AddUpdate(dataContext, list);
        }
    }
}
