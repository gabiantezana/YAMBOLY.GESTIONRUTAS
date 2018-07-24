using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.GeoLocation;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class OCRDLogic
    {
        private List<OCRDType> GetSAPList(DataContext dataContext)
        {
            return new OCRDDataAccess().GetList(dataContext);
        }

        public List<Cliente> GetList(DataContext dataContext)
        {
            return GetSAPList(dataContext).Select(x => new Cliente()
            {
                RazonSocial = x.CardName,
                Codigo = x.CardCode,
                RutaId = x.U_MSS_RUTA,
                GeoOptions = new MapLogic().GetGeoOptionsFromCoordinates(x.U_COORDINATESARRAY, ShapeType.Client)
            }).ToList();
        }

        public string GetQuery(DataContext dataContext, TreeViewNode client)
        {
            string coordinates = string.Empty;
            if (client.GeoOptions != null)
                coordinates = new MapLogic().GetCoordinatesArray(client.GeoOptions, PolygonType.Point);

            var query = Queries.GetStringContent(EmbebbedFileName.CRD1_Update);
            query = query.Replace("PARAM1", client.Id)
                         .Replace("PARAM2", coordinates);

            return query;
        }

    }
}
