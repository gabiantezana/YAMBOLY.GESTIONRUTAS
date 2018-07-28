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
    public class CanalLogic
    {
        private List<MSS_CANAType> GetList(DataContext dataContext)
        {
            return new CanalDataAccess().GetList(dataContext);
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
