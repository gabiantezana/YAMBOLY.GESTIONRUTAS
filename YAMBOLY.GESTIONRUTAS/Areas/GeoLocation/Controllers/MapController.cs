using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.EXCEPTION;
using YAMBOLY.GESTIONRUTAS.Filters;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation;

namespace YAMBOLY.GESTIONRUTAS.Areas.GeoLocation.Controllers
{
    public class MapController : BaseController
    {
        // GET: GeoLocation/Zone
        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public ActionResult Index()
        {
            try
            {
                var model = new MapLogic().GetMapViewModel(GetDataContext());
                return View(model);
            }
            catch (CustomException ex)
            {
                PostMessage(ex);
                return View(new MapViewModel());
            }
        }

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public ActionResult List()
        {
            return View();
        }

        /// <summary>
        /// El modelo no debe retornar zonas repetidas, ni rutas repetidas
        /// </summary>
        /// <returns></returns>

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.UPDATE)]
        [HttpPost]
        public ActionResult Index(MapViewModel model)
        {
            new MapLogic().AddUpdateMap(GetDataContext(), model);
            PostMessage(MessageType.Success);
            return RedirectToAction(nameof(Index));

        }

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        [HttpPost]
        public JsonResult GetShapeInfo(string id, ShapeType shapeType)
        {
            var shapeInfo = new MapLogic().GetShapeInfo(GetDataContext(), id, shapeType);
            return Json(shapeInfo);
        }

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public JsonResult SearchClient(MapViewModel model)
        {
            var data = new MapLogic().GetFilteredClientList(GetDataContext(), model);
            return Json(data);
        }

        #region JsonResult
        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public JsonResult GetProvinciaJList(String CadenaBuscar)
        {
            var data = new ProvinciaLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public JsonResult GetDistritoJList(String CadenaBuscar)
        {
            var data = new DistritoLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }
        #endregion

    }
}