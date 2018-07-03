using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YAMBOLY.GESTIONRUTAS.HELPER;

namespace YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation
{
    public class MapViewModel
    {
        public List<Zone> ZoneList { get; set; }
        public List<Route> RouteList { get; set; }
        public List<Cliente> ClientList { get; set; }

        public List<TreeViewNode> ShapeList { get; set; }
        public string JsonShapeList { get; set; }
    }
}