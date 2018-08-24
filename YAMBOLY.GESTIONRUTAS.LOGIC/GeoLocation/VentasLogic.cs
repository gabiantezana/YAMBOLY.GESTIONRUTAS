using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class VentasLogic
    {
        public List<OINVType> GetList(DataContext dataContext)
        {
            return new VentasDataAccess().GetList(dataContext);
        }
    }
}
