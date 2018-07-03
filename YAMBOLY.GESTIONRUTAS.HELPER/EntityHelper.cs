using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YAMBOLY.GESTIONRUTAS.HELPER
{
    class EntityHelper
    {
    }
    public class JsonEntity
    {
        public Int32 id { get; set; }
        public String text { get; set; }
    }
    public class JsonEntityTwoString
    {
        public String id { get; set; }
        public String text { get; set; }
    }
    public class JsonEntityGroup
    {
        public List<JsonEntity2> children { get; set; }
        public Int32 id { get; set; }
        public String text { get; set; }
        public String search { get; set; }
    }
    public class JsonEntity2
    {
        public Int32 id { get; set; }
        public String text { get; set; }
        public Int32 type { get; set; }
    }
    public class TempDataEntity
    {
        public MessageType TipoMensaje { get; set; }
        public String Mensaje { get; set; }
    }



    public class Zone
    {
        #region GoogleMaps Properties
        public bool clickable { get; set; }
        public bool draggable { get; set; }
        public bool editable { get; set; }
        public string fillColor { get; set; }
        public double? fillOpacity { get; set; }
        public List<Path> paths { get; set; }
        public string strokeColor { get; set; }
        public int strokeOpacity { get; set; }
        public double? strokeWeight { get; set; }
        public bool visible { get; set; }
        public int zIndex { get; set; }
        #endregion

        #region Aditional Properties 
        public string id { get; set; }
        public string name { get; set; }
        #endregion
    }

    public class Route : Zone
    {
        public Zone zone { get; set; }
        public string zoneId { get; set; }
    }

    public class Map
    {
        public List<Zone> ZoneList { get; set; }
        public List<Route> RouteList { get; set; }
        public List<Cliente> ClientList { get; set; }
    }

    public class Cliente
    {
        public string rutaId { get; set; }
        public string zonaId { get; set; }
        public string region { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
        public Zone zona { get; set; }
        public Route ruta { get; set; }
        public string canal { get; set; }
        public string giro { get; set; }
        public string codigo { get; set; }
        public string razonSocial { get; set; }
        public string tipoCliente { get; set; }
        public string vendedor { get; set; }
        public string supervisorCampo { get; set; }
        public string supervisorTerritorio { get; set; }
        public string supervisorZona { get; set; }
        public string jefeDeVentas { get; set; }
        public Path coords { get; set; }
    }

    public class Path
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class TreeViewNode
    {
        public TreeViewNode()
        {
            this.nodes = new List<TreeViewNode>();
        }

        #region Required Properties
        public string text { get; set; }
        public List<TreeViewNode> nodes { get; set; }
        #endregion

        #region Aditional Properties
        public string Id { get; set; }
        public ShapeType ShapeType { get; set; }
        public dynamic Shape { get; set; }
        public Zone Zone { get; set; }
        public Route Route { get; set; }
        public Cliente Client { get; set; }
        #endregion
    }


}
