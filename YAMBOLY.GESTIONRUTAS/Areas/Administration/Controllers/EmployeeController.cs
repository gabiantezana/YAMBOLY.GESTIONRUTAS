using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.EXCEPTION;
using YAMBOLY.GESTIONRUTAS.Filters;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.Administration;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Employee;

namespace YAMBOLY.GESTIONRUTAS.Areas.Administration.Controllers
{
    public class Employeecontroller : BaseController
    {
        [AppViewAuthorize(ConstantHelper.Views.Administration.Employee.REGISTERHOURS)]
        public ActionResult RegisterHours()
        {
            var model = new EmployeeLogic().GetRegisterHoursViewModel(GetDataContext());
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Views.Administration.User.LIST)]
        public ActionResult AddUpdate(int? id)
        {
            var model = new UserLogic().Get(GetDataContext(), id);
            return View(model);
        }

        #region JsonResult
        [AppViewAuthorize(ConstantHelper.Views.Administration.User.LIST)]
        public JsonResult GetJList(string searchString)
        {
            var jList = new UserLogic().GetJList(GetDataContext(), searchString);
            return Json(jList);
        }
        #endregion

        #region Post
        [HttpPost]
        [AppViewAuthorize(ConstantHelper.Views.Administration.Employee.REGISTERHOURS)]
        public ActionResult RegisterHours(RegisterHoursViewModel model)
        {
            return View(model);
        }
        #endregion

        #region PartialView
        [AppViewAuthorize(ConstantHelper.Views.Administration.User.LIST)]
        public ActionResult _ListPartialView(int? id, int? p)
        {
            var model = new UserLogic().GetList(GetDataContext(), null, id, p);
            return PartialView("PartialView/_ListPartialView", model);
        }
        #endregion
    }
}