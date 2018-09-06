using OfficeOpenXml;
using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.EXCEPTION;
using YAMBOLY.GESTIONRUTAS.Filters;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.GeoLocation;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.GeoLocation;
using static System.Net.WebRequestMethods;

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

        [HttpPost]
        public virtual ActionResult SaveReport(MapViewModel model)
        {
            string[] filePathsCreatedInServer = { };
            try
            {
                var bytes = new MapLogic().GetReportBytes(GetDataContext(), model, out filePathsCreatedInServer);
                switch (model.ReportType)
                {
                    case ReportType.Excel:
                        return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
                    case ReportType.Pdf:
                        return File(bytes, System.Net.Mime.MediaTypeNames.Application.Pdf);
                    default://TODO
                        throw new Exception();
                }
            }
            finally
            {
                foreach (var item in filePathsCreatedInServer)
                    if (Directory.Exists(System.IO.Path.GetDirectoryName(item)))
                        System.IO.File.Delete(item);
            }
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

        #region JsonResult Select2
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

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public JsonResult GetRutaByZoneJList(string CadenaBuscar)
        {
            var data = new RutaLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public JsonResult GetSupervisorJList(int CadenaBuscar)
        {
            var data = new SupervisorLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }

        [AppViewAuthorize(ConstantHelper.Views.GeoLocation.Map.VIEW)]
        public JsonResult GetJefeVentasJList(int CadenaBuscar)
        {
            var data = new JefeVentasLogic().GetJList(GetDataContext(), CadenaBuscar);
            return Json(data);
        }


        #endregion

    }
}