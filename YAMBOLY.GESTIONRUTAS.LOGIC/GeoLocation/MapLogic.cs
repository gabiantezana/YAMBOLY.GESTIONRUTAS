using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using YAMBOLY.GESTIONRUTAS.DATAAACCESS.Queries;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation;

namespace YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation
{
    public class MapLogic
    {
        public MapViewModel GetMapViewModel(DataContext dataConext)
        {
            var model = new MapViewModel();
            model.ZoneList = new @MSS_ZONALogic().GetList(dataConext);
            model.RouteList = new @MSS_RUTALogic().GetList(dataConext);
            model.ClientList = new OCRDLogic().GetList(dataConext);
            model.ShapeList = GetShapeList(ref model);
            return model;
        }

        private List<TreeViewNode> GetShapeList(ref MapViewModel model)
        {
            List<TreeViewNode> treeViewNode = new List<TreeViewNode>();
            foreach (var zone in model.ZoneList)
            {
                var zoneNode = new TreeViewNode();
                zoneNode.Id = zone.Id;
                zoneNode.text = zone.Name;
                zoneNode.ShapeType = ShapeType.Zone;
                zoneNode.GeoOptions = zone.GeoOptions;

                foreach (var route in model.RouteList.Where(x => x.ZoneId == zone.Name))
                {
                    var routeNode = new TreeViewNode();
                    routeNode.Id = route.Id;
                    routeNode.text = route.Name;
                    routeNode.ShapeType = ShapeType.Route;
                    routeNode.GeoOptions = route.GeoOptions;
                    routeNode.ParentId = zoneNode.Id;
                    foreach (var client in model.ClientList.Where(x => x.RutaId == route.Id))
                    {
                        var clientNode = new TreeViewNode();
                        clientNode.Id = client.Codigo;
                        clientNode.text = client.RazonSocial;
                        clientNode.ShapeType = ShapeType.Client;
                        clientNode.GeoOptions = client.GeoOptions;
                        clientNode.ParentId = routeNode.Id;
                        routeNode.nodes.Add(clientNode);
                    }
                    zoneNode.nodes.Add(routeNode);
                }
                treeViewNode.Add(zoneNode);
            };
            return treeViewNode;
        }

        public void AddUpdateMap(DataContext dataContext, MapViewModel model)
        {
            List<TreeViewNode> postedObjects = JsonConvert.DeserializeObject<List<TreeViewNode>>(model.PostedShapeList[0]);

            var queries = new List<string>();
            foreach (var zone in postedObjects)
            {
                queries.Add(new MSS_ZONALogic().GetQuery(dataContext, zone));
                foreach (var route in zone.nodes)
                {
                    queries.Add(new MSS_RUTALogic().GetQuery(dataContext, route));
                    foreach (var client in route.nodes)
                    {
                        queries.Add(new OCRDLogic().GetQuery(dataContext, client));
                    }
                }
            }
            var finalQuery = string.Join(" ", queries);
            WebHelper.GetJsonPostResponse(Queries.GetUrlPath(), finalQuery);
        }

        public string GetCoordinatesArray(GeoOptions geoOptions, PolygonType polygonType)
        {
            var rootObject = new RootObject();
            double[] coordinates = new double[2];
            switch (polygonType)
            {
                case PolygonType.Zone:
                case PolygonType.Route:
                    if (geoOptions.paths != null)
                    {
                        foreach (var item in geoOptions.paths)
                        {
                            coordinates[0] = item.lat;
                            coordinates[1] = item.lng;
                            //var coordinate = new List<double> { item.lat, item.lng };
                            rootObject.coords.Add(coordinates.ToList());
                        }
                        return JsonConvert.SerializeObject(rootObject);
                    }

                    break;
                case PolygonType.Point:
                    if (geoOptions.coords != null)
                    {
                        coordinates[0] = geoOptions.coords.lat;
                        coordinates[1] = geoOptions.coords.lng;
                        rootObject.coords.Add(coordinates.ToList());
                        return JsonConvert.SerializeObject(rootObject);
                    }
                    break;
                default:
                    throw new System.Exception("Polygon Type nulo"); //TODO:
            }
            return string.Empty;
        }

        public GeoOptions GetGeoOptionsFromCoordinates(string coordinates, ShapeType shapeType)
        {
            if (string.IsNullOrEmpty(coordinates)) return null;
            RootObject obj = JsonConvert.DeserializeObject<RootObject>(coordinates);
            var geoOptions = new GeoOptions();

            switch (shapeType)
            {
                case ShapeType.Zone:
                case ShapeType.Route:
                    foreach (var item in obj.coords)
                    {
                        geoOptions.paths.Add(new Path() { lat = item[0], lng = item[1] });
                    }
                    break;
                case ShapeType.Client:
                    foreach (var item in obj.coords)
                    {
                        geoOptions.coords = new Path() { lat = item[0], lng = item[1] };
                    }
                    break;
                default:
                    throw new System.Exception("Error");//TODO:
            }
            return geoOptions;
        }
    }
}
