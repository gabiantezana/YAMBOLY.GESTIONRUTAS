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
    public class RegionLogic
    {
        private List<MSS_REGIType> GetList(DataContext dataContext)
        {
            return new RegionDataAccess().GetSAPList(dataContext);
        }

        public List<JsonEntityTwoString> GetJList(DataContext dataContext)
        {
            return GetList(dataContext).Select(x => new JsonEntityTwoString()
            {
                id = x.Code,
                text = x.Name,
            }).ToList();
        }
    }
}
