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
            model.ZoneList = new ZonaLogic().GetList(dataConext);
            model.RouteList = new RutaLogic().GetList(dataConext);
            model.ClientList = new AddressLogic().GetList(dataConext);
            model.ShapeList = GetShapeList(ref model);

            #region JsonList
            model.CanalJList = new CanalLogic().GetJList(dataConext);
            model.DepartamentoJList = new DepartamentoLogic().GetJList(dataConext);
            model.DistritoJList = new DistritoLogic().GetJList(dataConext, string.Empty);
            model.GiroJList = new GiroLogic().GetJList(dataConext);
            model.JefeVentasJList = new List<JsonEntityTwoString>();//TODO:
            model.ProvinciaJList = new ProvinciaLogic().GetJList(dataConext, string.Empty);
            model.RegionJList = new RegionLogic().GetJList(dataConext);
            model.ZonaJList = new ZonaLogic().GetJList(dataConext);
            model.RutaJList = new RutaLogic().GetJList(dataConext);
            model.SupervisorTerritorioJList = new SupervisorLogic().GetJList(dataConext);
            model.SupervisorZonaJList = new SupervisorLogic().GetJList(dataConext);
            model.TipoClienteJList = new List<JsonEntityTwoString>();//TODO:
            model.VendedorJList = new VendedorLogic().GetJList(dataConext);
            #endregion

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

                foreach (var route in model.RouteList.Where(x => x.ZoneId == zone.Id))
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
                        clientNode.text = client.Ruc + " - " + client.RazonSocial;
                        clientNode.ShapeType = ShapeType.Address;
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
            List<TreeViewNode> postedObjects = JsonConvert.DeserializeObject<List<TreeViewNode>>(model.PostedShapeList[0]);//TODO:

            var queries = new List<string>();
            foreach (var zone in postedObjects)
            {
                queries.Add(new ZonaLogic().GetQuery(dataContext, zone));
                foreach (var route in zone.nodes)
                {
                    queries.Add(new RutaLogic().GetQuery(dataContext, route));
                    foreach (var client in route.nodes)
                    {
                        queries.Add(new AddressLogic().GetQuery(dataContext, client));
                    }
                }
            }
            var finalQuery = string.Join(" ", queries);
            WebHelper.GetJsonPostResponse(Queries.GetUrlPath(), finalQuery);
        }

        public string GetCoordinatesArray(GeoOptions geoOptions, ShapeType polygonType)
        {
            var rootObject = new RootObject();
            double?[] coordinates = new double?[2];
            switch (polygonType)
            {
                case ShapeType.Zone:
                case ShapeType.Route:
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
                case ShapeType.Address:
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
                case ShapeType.Address:
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

        public dynamic GetShapeInfo(DataContext dataContext, string id, ShapeType shapeType)
        {
            dynamic shapeInfo;
            switch (shapeType)
            {
                case ShapeType.Zone:
                    shapeInfo = new ZonaLogic().Get(dataContext, id);
                    break;
                case ShapeType.Route:
                    shapeInfo = new RutaLogic().Get(dataContext, id);
                    break;
                case ShapeType.Address:
                    shapeInfo = new AddressLogic().Get(dataContext, id);
                    break;
                default:
                    throw new System.Exception("");//TODO:
            }
            return shapeInfo;
        }

        public List<string> GetFilteredClientList(DataContext dataContext, MapViewModel model)
        {
            var list = new AddressLogic().GetList(dataContext).AsQueryable();

            var cardCodeList = list.Where(x => string.IsNullOrEmpty(model.Region) | x.Region == model.Region
                                        && string.IsNullOrEmpty(model.Departamento) | x.Departamento == model.Departamento
                                        && string.IsNullOrEmpty(model.Provincia) | x.Provincia == model.Provincia
                                        && string.IsNullOrEmpty(model.Distrito) | x.Distrito == model.Distrito
                                        && string.IsNullOrEmpty(model.Zona) | x.ZonaId == model.Zona
                                        && string.IsNullOrEmpty(model.Ruta) | x.RutaId == model.Ruta
                                        && string.IsNullOrEmpty(model.Canal) | x.Canal == model.Canal
                                        && string.IsNullOrEmpty(model.Giro) | x.Giro == model.Giro
                                        && string.IsNullOrEmpty(model.Vendedor) | x.Vendedor == model.Vendedor
                                        && string.IsNullOrEmpty(model.SupervisorTerritorio) | x.SupervisorCampo == model.SupervisorTerritorio
                                        && string.IsNullOrEmpty(model.SupervisorZona) | x.SupervisorZona == model.SupervisorZona
                                        && string.IsNullOrEmpty(model.JefeVentas) | x.JefeDeVentas == model.JefeVentas)
                                    .Select(x => x.Codigo).ToList();
            return cardCodeList;
        }

    }
}
