using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class UserDefinedValuesLogic
    {
        public List<JsonEntityTwoString> GetJList(DataContext dataContext, string tableName, int? index)
        {
            return new UserDefinedValuesDataAccess().GetList(dataContext).Where(x => x.FieldID == index && x.TableID == tableName)
                                                    .Select(x => new JsonEntityTwoString() { id = x.FldValue, text = x.Descr }).ToList();
        }
    }
}
