using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation
{
    public class CRD1DataAccess
    {
        public List<CRD1Type> GetList(DataContext dataContext)
        {
            return dataContext.oDataService.CRD1.ToList();
        }
    }
}
