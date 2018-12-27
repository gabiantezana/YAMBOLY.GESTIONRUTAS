using System.Collections.Generic;
using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.Filters;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.Administration;

namespace YAMBOLY.GESTIONRUTAS.Areas.Administration.Controllers
{
    public class ConfigController : BaseController
    {
        [AppViewAuthorize(ConstantHelper.Views.Administration.Config.VIEW)]
        public ActionResult Update()
        {
            var model = new ConfigLogic().GetList(GetDataContext());
            return View(model);
        }

        [HttpPost]
        [AppViewAuthorize(ConstantHelper.Views.Administration.User.UPDATE)]
        public ActionResult Update(FormCollection formCollection)
        {
            var list = new List<JsonEntityTwoString>();
            new ConfigLogic().Update(GetDataContext(), list);
            return RedirectToAction(nameof(Update));
        }
    }
}