using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System.Collections.Generic;
using System.Linq;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class RutaLogic
    {
        public List<MSS_RUTAType> GetSAPList(DataContext dataContext)
        {
            return new RutaDataAccess().GetList(dataContext);
        }

        public List<Route> GetList(DataContext dataContext)
        {
            return GetSAPList(dataContext).Select(x => new Route()
            {
                ZoneId = x.U_MSS_ZONA,
                Id = x.Code,
                Name = x.Name,
                GeoOptions = new MapLogic().GetGeoOptionsFromCoordinates(x.U_COORDINATESARRAY, ShapeType.Route)
            }).ToList();
        }

        public Route Get(DataContext dataContext, string id)
        {
            return GetList(dataContext).FirstOrDefault(x => x.Id== id);
        }

        public string GetQuery(DataContext dataContext, TreeViewNode zone)
        {
            string coordinates = string.Empty;
            if (zone.GeoOptions != null)
                coordinates = new MapLogic().GetCoordinatesArray(zone.GeoOptions, ShapeType.Route);

            var query = Queries.GetStringContent(EmbebbedFileName.MSS_RUTA_Update);
            query = query.Replace("PARAM1", zone.Id)
                         .Replace("PARAM2", coordinates);

            return query;
        }

        public List<JsonEntityTwoString> GetJList(DataContext dataContext)
        {
            return GetSAPList(dataContext).Select(x => new JsonEntityTwoString()
            {
                id = x.Code,
                text = x.Name,
            }).ToList();
        }
    }
}
