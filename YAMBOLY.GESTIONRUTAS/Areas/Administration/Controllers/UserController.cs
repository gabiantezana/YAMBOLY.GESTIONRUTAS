using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.Filters;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.Administration;

namespace YAMBOLY.GESTIONRUTAS.Areas.Administration.Controllers
{
    public class UserController : BaseController
    {
        [AppViewAuthorize(ConstantHelper.Administration.User.LIST)]
        public ActionResult Get()
        {
            var model = new UserLogic().Get(GetDataContext(), null);
            return View(model);
        }
    }
}