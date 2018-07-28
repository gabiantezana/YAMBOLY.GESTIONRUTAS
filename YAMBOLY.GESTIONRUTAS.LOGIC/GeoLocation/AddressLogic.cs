using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using Newtonsoft.Json;
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
    public class AddressLogic
    {
        public List<Address> GetList(DataContext dataContext)
        {
            return new ClienteDataAccess().GetList(dataContext).Select(x => new Address()
            {
                Codigo = x.CardCode + " - " + x.Address,//TODO:
                Region = x.U_MSS_REGI,
                Departamento = x.State,
                Provincia = x.County,
                Distrito = x.City,
                ZonaId = x.U_MSS_ZONA,
                Canal = x.U_MSS_CANA,
                Giro = x.U_MSS_GIRO,
                Ruc = x.CardCode,
                RazonSocial = x.CardName,
                TipoCliente = string.Empty,//TODO:,
                Vendedor = x.U_MSS_COVE,
                SupervisorTerritorio = x.U_MSS_SUPE,
                SupervisorCampo = x.U_MSS_SUPE,
                SupervisorZona = x.U_MSS_SUPE,
                JefeDeVentas = x.U_MSS_JEVE,
                RutaId = x.U_MSS_RUTA,
                GeoOptions = (x.U_MSSM_LAT != null && x.U_MSSM_LON != null)? new GeoOptions() { coords = new Path() { lat = Convert.ToDouble(x.U_MSSM_LAT), lng = Convert.ToDouble(x.U_MSSM_LON) } } : null, //TODO:
            }).ToList();
        }

        public Address Get(DataContext dataContext, string id)
        {
            return GetList(dataContext).FirstOrDefault(x => x.Codigo == id);
        }

        public string GetQuery(DataContext dataContext, TreeViewNode node)
        {
            var geoOptions = new GeoOptions();
            if (node.GeoOptions?.coords != null)
            {
                var coordinates = new MapLogic().GetCoordinatesArray(node.GeoOptions, ShapeType.Address);
                geoOptions = new MapLogic().GetGeoOptionsFromCoordinates(coordinates, ShapeType.Address);
            }

            var query = Queries.GetStringContent(EmbebbedFileName.CRD1_Update);
            var name = node.Id.Split('-')[0].Trim();//TODO:
            var address = node.Id.Split('-')[1].Trim();//TODO:
            query = query.Replace("PARAM1", name)
                         .Replace("PARAM2", geoOptions?.coords?.lat.ToSafeString())
                         .Replace("PARAM3", geoOptions?.coords?.lng.ToSafeString())
                         .Replace("PARAM4", address);
            return query;
        }

    }
}
