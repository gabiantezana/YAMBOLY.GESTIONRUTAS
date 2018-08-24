using Newtonsoft.Json;
using System;
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
            model.ShapeList = GetShapeList(ref model, dataConext);

            #region JsonList
            model.CanalJList = new CanalLogic().GetJList(dataConext);
            model.DepartamentoJList = new DepartamentoLogic().GetJList(dataConext);
            model.DistritoJList = new DistritoLogic().GetJList(dataConext, string.Empty);
            model.GiroJList = new GiroLogic().GetJList(dataConext);
            model.JefeVentasJList = new JefeVentasLogic().GetJList(dataConext, null);
            model.ProvinciaJList = new ProvinciaLogic().GetJList(dataConext, string.Empty);
            model.RegionJList = new RegionLogic().GetJList(dataConext);
            model.ZonaJList = new ZonaLogic().GetJList(dataConext);
            model.RutaJList = new RutaLogic().GetJList(dataConext);
            model.SupervisorJList = new SupervisorLogic().GetJList(dataConext, null);
            model.TipoClienteJList = new List<JsonEntityTwoString>();//TODO:
            model.VendedorJList = new VendedorLogic().GetJList(dataConext);
            model.FrecuenciaVisitaJList = new UserDefinedValuesLogic().GetJList(dataConext, "CRD1", 7);
            #endregion

            return model;
        }

        private List<TreeViewNode> GetShapeList(ref MapViewModel model, DataContext dataContext)
        {
            List<TreeViewNode> treeViewNode = new List<TreeViewNode>();
            var zoneList = new ZonaLogic().GetList(dataContext);
            var routeList = new RutaLogic().GetList(dataContext);
            var clientList = new AddressLogic().GetList(dataContext);
            foreach (var zone in zoneList)
            {
                var zoneNode = new TreeViewNode();
                zoneNode.Id = zone.Id;
                zoneNode.text = zone.Name;
                zoneNode.ShapeType = ShapeType.Zone;
                zoneNode.GeoOptions = zone.GeoOptions;

                foreach (var route in routeList.Where(x => x.ZoneId == zone.Id))
                {
                    var routeNode = new TreeViewNode();
                    routeNode.Id = route.Id;
                    routeNode.text = route.Name;
                    routeNode.ShapeType = ShapeType.Route;
                    routeNode.GeoOptions = route.GeoOptions;
                    routeNode.ParentId = zoneNode.Id;
                    foreach (var client in clientList.Where(x => x.RutaId == route.Id && x.ZonaId == zone.Id))
                    {
                        var clientNode = new TreeViewNode();
                        clientNode.Id = client.CodigoInterno;
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
            if (postedObjects != null)
                foreach (var zone in postedObjects?.ToList())
                {
                    queries.Add(new ZonaLogic().GetQuery(dataContext, zone));
                    foreach (var route in zone.nodes)
                    {
                        queries.Add(new RutaLogic().GetUpdateQuery(dataContext, route));
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
                    throw new InvalidOperationException();
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
                    throw new InvalidOperationException();
            }
            return shapeInfo;
        }

        public List<string> GetFilteredClientList(DataContext dataContext, MapViewModel model)
        {
            var list = new AddressLogic().GetList(dataContext).AsQueryable();

            var addressList = list.Where(x => string.IsNullOrEmpty(model.Region) | x.Region == model.Region
                                        && string.IsNullOrEmpty(model.Departamento) | x.Departamento == model.Departamento
                                        && string.IsNullOrEmpty(model.Provincia) | x.Provincia == model.Provincia
                                        && string.IsNullOrEmpty(model.Distrito) | x.Distrito == model.Distrito
                                        && string.IsNullOrEmpty(model.Zona) | x.ZonaId == model.Zona
                                        && string.IsNullOrEmpty(model.Ruta) | x.RutaId == model.Ruta
                                        && string.IsNullOrEmpty(model.Canal) | x.Canal == model.Canal
                                        && string.IsNullOrEmpty(model.Giro) | x.Giro == model.Giro
                                        && x.ConActivos == model.ConActivos
                                        //TODO: TIPO CLIENTE (Clientes Yamboly, competencia, leads)
                                        //&& x.TipoCliente == model.TipoCliente
                                        && string.IsNullOrEmpty(model.Vendedor) | x.Vendedor == model.Vendedor
                                        && string.IsNullOrEmpty(model.Supervisor) | x.Supervisor == model.Supervisor
                                        && string.IsNullOrEmpty(model.JefeVentas) | x.JefeDeVentas == model.JefeVentas
                                        && x.DiaDeVisitaLunes == model.DiaDeVisitaLunes
                                        && x.DiaDeVisitaMartes == model.DiaDeVisitaMartes
                                        && x.DiaDeVisitaMiercoles == model.DiaDeVisitaMiercoles
                                        && x.DiaDeVisitaJueves == model.DiaDeVisitaJueves
                                        && x.DiaDeVisitaViernes == model.DiaDeVisitaViernes
                                        && x.DiaDeVisitaSabado == model.DiaDeVisitaSabado
                                        && x.DiaDeVisitaDomingo == model.DiaDeVisitaDomingo
                                        && x.FrecuenciaVisita == model.FrecuenciaVisita
                                        )
                                    .Select(x => x.CodigoInterno).ToList();

            //-------------------------------------------------------------Agrega Filtro de ventas//-------------------------------------------------------------
            var clientsInSalesRange = GetFilteredClientListBySales(dataContext, model.VentasMontoMinimo, model.VentasMontoMaximo, model.VentasFechaInicio, model.VentasFechaFin);
            var finalAddressList = new List<string>();
            foreach (var address in addressList)
            {
                if (clientsInSalesRange.Contains(address.Split('-')[0].ToSafeString().Trim()) && !finalAddressList.Contains(address))
                    finalAddressList.Add(address);
            }
            //-------------------------------------------------------------Fin filtro de ventas-------------------------------------------------------------

            return finalAddressList;
        }

        private List<string> GetFilteredClientListBySales(DataContext dataContext, decimal? montoInicial, decimal? montoFinal, DateTime? fechaInicial, DateTime? fechaFinal)
        {

            var _salesInDateRange = new VentasLogic().GetList(dataContext).Where(x => fechaInicial <= x.DocDate && x.DocDate <= fechaFinal
                                                                                               && montoInicial <= x.DocTotal && x.DocTotal <= montoFinal);


            var salesInDateRange = new VentasLogic().GetList(dataContext).Where(x => (fechaInicial ?? DateTime.MinValue) <= x.DocDate && x.DocDate <= (fechaFinal?? DateTime.MaxValue)
                                                                                   && (montoInicial?? decimal.MinValue) <= x.DocTotal && x.DocTotal <= (montoFinal?? decimal.MaxValue))
                                                                         .Select(x => x.CardCode).Distinct().ToList();
            return salesInDateRange;
        }

    }
}
