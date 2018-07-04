using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation;

namespace YAMBOLY.GESTIONRUTAS.Areas.GeoLocation.Controllers
{
    public class MapController : BaseController
    {
        // GET: GeoLocation/Zone
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return View();
        }

        public ActionResult AddUpdate()
        {
            var model = GetTestingViewModel();

            return View(model);
        }

        /// <summary>
        /// El modelo no debe retornar zonas repetidas, ni rutas repetidas
        /// </summary>
        /// <returns></returns>
        public MapViewModel GetTestingViewModel()
        {
            //All zones in SAP
            List<Zone> ZoneList = new List<Zone>()
            {
                new Zone()
                {
                    Id = "001",
                    Name = "Zona 001",
                    GeoOptions = new GeoOptions()
                    {
                        clickable = true,
                        draggable = true,
                        editable = true,
                        fillColor = "Yellow",
                        fillOpacity = 0.4,
                        strokeWeight = 0.5,
                        visible = true,
                        paths = new List<Path>
                        {
                             new Path(){ lat = -12.064407256468757, lng =-77.03325771926268 },
                             new Path(){ lat = -12.099825471103587, lng =-77.05420040725096 } ,
                             new Path(){ lat = -12.110567509649398, lng =-77.01506161330565 },
                             new Path(){ lat = -12.060881964600455, lng =-77.0071651899658 },
                        }
                    }
                }
            };

            //All routes in SAP
            List<Route> RouteList = new List<Route>()
            {
                new Route()
                {
                    Id = "002",
                    Name = "Ruta 001",
                    ZoneId  ="001",
                    GeoOptions =  new GeoOptions(){
                        clickable = true,
                        draggable = true,
                        editable = true,
                        fillColor = "HotPink",
                        fillOpacity = 0.4,
                        strokeWeight = 0.5,
                        visible = true,
                        paths = new List<Path>
                        {
                             new Path(){ lat = -12.067428898315784, lng =-77.08132290480955 },
                             new Path(){ lat = -12.076661481732883, lng =-77.08029293654783 },
                             new Path(){ lat = -12.084047319303908, lng =-77.06776165603026 },
                             new Path(){ lat = -12.07414353599431, lng =-77.06192516921385 },
                             new Path(){ lat = -12.06457512635387, lng =-77.07926296828612 },
                        }
                    },
                }
            };

            //All clients in SAP
            List<Cliente> ClientList = new List<Cliente>()
            {
                new Cliente()
                {
                    Codigo = "Cliente001",
                    RutaId = "002",
                    RazonSocial="Cliente 001",
                    GeoOptions = new GeoOptions() {
                    coords = new Path(){ lat = -12.067428898315784, lng =-77.08132290480955 }
                    }
                }
            };

            //Shape List
            List<TreeViewNode> treeViewNode = new List<TreeViewNode>();
            foreach (var zone in ZoneList)
            {
                var zoneNode = new TreeViewNode();
                zoneNode.Id = zone.Id;
                zoneNode.text = zone.Name;
                zoneNode.ShapeType = ShapeType.Zone;
                zoneNode.GeoOptions = zone.GeoOptions;

                foreach (var route in RouteList.Where(x => x.ZoneId == zone.Id))
                {
                    var routeNode = new TreeViewNode();
                    routeNode.Id = route.Id;
                    routeNode.text = route.Name;
                    routeNode.ShapeType = ShapeType.Route;
                    routeNode.GeoOptions = route.GeoOptions;

                    foreach (var client in ClientList.Where(x => x.RutaId == route.Id))
                    {
                        var clientNode = new TreeViewNode();
                        clientNode.Id = client.Codigo;
                        clientNode.text = client.RazonSocial;
                        clientNode.ShapeType = ShapeType.Client;
                        clientNode.GeoOptions = client.GeoOptions;

                        routeNode.nodes.Add(clientNode);
                    }
                    zoneNode.nodes.Add(routeNode);
                }
                treeViewNode.Add(zoneNode);
            };


            var model = new MapViewModel()
            {
                RouteList = RouteList,
                ZoneList = ZoneList,
                ClientList = ClientList,
                ShapeList = treeViewNode,
                JsonShapeList = new JavaScriptSerializer().Serialize(treeViewNode),
            };
            return model;
        }

        public List<TreeViewNode> GetJson()
        {
            var model = GetTestingViewModel();
            List<TreeViewNode> treeViewNode = new List<TreeViewNode>();
            foreach (var zone in model.ZoneList)
            {
                var zoneNode = new TreeViewNode();
                zoneNode.Id = zone.Id;
                zoneNode.text = zone.Name;
                foreach (var route in model.RouteList.Where(x => x.ZoneId == zone.Id))
                {
                    var routeNode = new TreeViewNode();
                    routeNode.Id = route.Id;
                    routeNode.text = route.Name;

                    foreach (var client in model.ClientList.Where(x => x.RutaId == route.Id))
                    {
                        var clientNode = new TreeViewNode();
                        clientNode.Id = client.Codigo;
                        clientNode.text = client.RazonSocial;
                        routeNode.nodes.Add(clientNode);
                    }
                    zoneNode.nodes.Add(routeNode);
                }
                treeViewNode.Add(zoneNode);
            };
            return treeViewNode;
        }

        public ActionResult Testing()
        {
            var model = GetTestingViewModel();
            return View(model);
        }
    }
}