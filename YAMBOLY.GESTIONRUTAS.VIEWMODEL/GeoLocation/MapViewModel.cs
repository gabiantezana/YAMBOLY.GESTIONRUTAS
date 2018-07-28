using MSS_YAMBOLY_GEOLOCATION.Services.ODataService;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using YAMBOLY.GESTIONRUTAS.HELPER;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation
{
    public class MapViewModel
    {
        public List<Zone> ZoneList { get; set; }
        public List<Route> RouteList { get; set; }
        public List<Address> ClientList { get; set; }

        public List<TreeViewNode> ShapeList { get; set; }

        /// <summary>
        /// Lista de ítems modificados en el mapa. Tipo: List<TreeViewNode>
        /// </summary>
        public dynamic PostedShapeList { get; set; }

        #region Campos de búsqueda de cliente

        public List<JsonEntityTwoString> RegionJList { get; set; }
        public string Region { get; set; }

        public List<JsonEntityTwoString> DepartamentoJList { get; set; }
        [Display(Name ="Depart.")]
        public string Departamento { get; set; }

        public List<JsonEntityTwoString> ProvinciaJList { get; set; }
        public string Provincia { get; set; }

        public List<JsonEntityTwoString> DistritoJList { get; set; }
        public string Distrito { get; set; }

        public List<JsonEntityTwoString> ZonaJList { get; set; }
        public string Zona { get; set; }

        public List<JsonEntityTwoString> RutaJList { get; set; }
        public string Ruta { get; set; }

        public List<JsonEntityTwoString> CanalJList { get; set; }
        public string Canal { get; set; }

        public List<JsonEntityTwoString> GiroJList { get; set; }
        public string Giro { get; set; }

        public string Codigo { get; set; }

        public string RazonSocial { get; set; }

        public string ConActivos { get; set; }

        public List<JsonEntityTwoString> TipoClienteJList { get; set; }
        public string TipoCliente { get; set; }

        public List<JsonEntityTwoString> VendedorJList { get; set; }
        public string Vendedor { get; set; }

        public List<JsonEntityTwoString> SupervisorTerritorioJList { get; set; }
        public string SupervisorTerritorio { get; set; }

        public List<JsonEntityTwoString> SupervisorZonaJList { get; set; }
        public string SupervisorZona { get; set; }

        public List<JsonEntityTwoString> JefeVentasJList { get; set; }
        public string JefeVentas { get; set; }

        [Display(Name = "Monto mín.")]
        public double VentasMontoMinimo { get; set; }

        [Display(Name = "Monto máx.")]
        public double VentasMontoMaximo { get; set; }
        #endregion

    }
}