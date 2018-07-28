using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation;
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

        /// <summary>
        /// El modelo no debe retornar zonas repetidas, ni rutas repetidas
        /// </summary>
        /// <returns></returns>

        public ActionResult Testing()
        {
            var model = new MapLogic().GetMapViewModel(GetDataContext());
            return View(model);
        }

        [HttpPost]
        public ActionResult Testing(MapViewModel model)
        {
            new MapLogic().AddUpdateMap(GetDataContext(), model);
            return RedirectToAction(nameof(Testing));

        }

        [HttpPost]
        public JsonResult GetShapeInfo(string id, ShapeType shapeType)
        {
            var shapeInfo = new MapLogic().GetShapeInfo(GetDataContext(), id, shapeType);
            return Json(shapeInfo);
        }

        public JsonResult SearchClient(MapViewModel model)
        {
            var data = new MapLogic().GetFilteredClientList(GetDataContext(), model);
            return Json(data);
        }

        #region JsonResult
        public JsonResult GetProvinciaJList(String CadenaBuscar)
        {
            var data = new ProvinciaLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }

        public JsonResult GetDistritoJList(String CadenaBuscar)
        {
            var data = new DistritoLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }
        #endregion

    }
}