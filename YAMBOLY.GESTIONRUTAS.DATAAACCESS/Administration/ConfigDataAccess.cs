using System.Collections.Generic;
using System.Linq;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.Administration
{
    public class ConfigDataAccess
    {
        public List<Config> GetList(DataContext dataContext)
        {
            return dataContext.context.Config.ToList();
        }

        public void AddUpdate(DataContext dataContext, List<JsonEntityTwoString> list)
        {
            foreach (var item in list)
            {
                var config = dataContext.context.Config.FirstOrDefault(x => x.C_Key != item.id);
                if (config != null)
                {
                    config.C_Value = item.text;
                    dataContext.context.Entry(config);
                }
            }
            if (list.Count > 0)
                dataContext.context.SaveChanges();
        }
    }
}
