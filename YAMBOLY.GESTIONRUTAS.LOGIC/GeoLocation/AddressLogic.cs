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
using static YAMBOLY.GESTIONRUTAS.HELPER.ConstantHelper;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class AddressLogic
    {
        public List<Address> GetList(DataContext dataContext)
        {
            return new DireccionesDataAccess().GetList(dataContext).Select(x => new Address()
            {
                Codigo = GetCodeForAddress(x),
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
                GeoOptions = (!string.IsNullOrEmpty( x.U_MSSM_LAT) && string.IsNullOrEmpty( x.U_MSSM_LON)) ? new GeoOptions() { coords = new Path() { lat = Convert.ToDouble(x.U_MSSM_LAT), lng = Convert.ToDouble(x.U_MSSM_LON) } } : null, //TODO:
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
            query = query.Replace(QueryParameters.PARAM1, GetCardCodeAndAddressFromCode(node.Id)[0])
                         .Replace(QueryParameters.PARAM2, geoOptions?.coords?.lat.ToSafeString())
                         .Replace(QueryParameters.PARAM3, geoOptions?.coords?.lng.ToSafeString())
                         .Replace(QueryParameters.PARAM4, GetCardCodeAndAddressFromCode(node.Id)[1]);
            return query;
        }

        public string GetCodeForAddress(OCRDType address)
        {
            return address.CardCode + "-" + address.Address;
        }

        public string[] GetCardCodeAndAddressFromCode(string code)
        {
            string[] values = new string[2] { string.Empty, string.Empty };
            var items = code.Split('-');
            if (items?.Length > 1 && items?.Length == 2)
                values = items;
            return values;
        }

    }
}
