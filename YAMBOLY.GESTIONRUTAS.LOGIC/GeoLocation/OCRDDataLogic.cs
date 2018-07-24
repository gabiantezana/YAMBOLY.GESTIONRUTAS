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
                Region = x.U_MSS_REGI,
                Departamento = x.State,
                Provincia = x.Country,
                Distrito = x.Country,//TODO:
                ZonaId = x.U_MSS_ZONA,
                Canal = string.Empty, //TODO:
                Giro = string.Empty,//TODO:
                Codigo = x.CardCode,
                RazonSocial = x.CardName,
                TipoCliente = string.Empty,
                Vendedor = string.Empty,
                SupervisorTerritorio = string.Empty,
                SupervisorCampo = string.Empty,
                SupervisorZona = string.Empty,
                JefeDeVentas = string.Empty,
                RutaId = x.U_MSS_RUTA,
                GeoOptions = new MapLogic().GetGeoOptionsFromCoordinates(x.U_COORDINATESARRAY, ShapeType.Client)
            }).ToList();
        }

        public Cliente Get(DataContext dataContext, string id)
        {
            return GetList(dataContext).FirstOrDefault(x => x.Codigo == id);
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
