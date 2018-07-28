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
    public class SupervisorLogic
    {
        private List<MSS_SUPEType> GetList(DataContext dataContext)
        {
            return new SupervisorDataAccess().GetSAPList(dataContext);
        }

        public List<JsonEntityTwoString> GetJList(DataContext dataContext)
        {
            return GetList(dataContext).Select(x => new JsonEntityTwoString()
            {
                id = x.Name,
                text = x.Name,
            }).ToList();
        }
    }
}
