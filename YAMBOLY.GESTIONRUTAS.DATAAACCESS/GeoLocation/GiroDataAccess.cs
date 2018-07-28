using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation
{
    public class GiroDataAccess
    {
        public List<MSS_GIROType> GetSAPList(DataContext dataContext)
        {
            return dataContext.oDataService.MSS_GIRO.ToList();
        }
    }
}
