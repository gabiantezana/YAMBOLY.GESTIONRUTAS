using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.Controllers;
using YAMBOLY.GESTIONRUTAS.Filters;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.Administration;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.Administration.Rol;
using System.Transactions;
using YAMBOLY.GESTIONRUTAS.EXCEPTION;

namespace YAMBOLY.GESTIONRUTAS.Areas.Administration.Controllers
{
    public class RolController : BaseController
    {
        #region Get
        [AppViewAuthorize(ConstantHelper.Views.Administration.Rol.LIST)]
        public ActionResult List()
        {
            var model = new RolLogic().GetList(GetDataContext());
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Views.Administration.Rol.LIST)]
        public ActionResult EditPermisosPorRoles(int rolId)
        {
            var model = new RolLogic().EditPermisosPorRoles(GetDataContext(), rolId);
            return View(model);
        }

        [AppViewAuthorize(ConstantHelper.Views.Administration.Rol.LIST)]
        public ActionResult AddUpdate(int? rolId)
        {
            var model = new RolLogic().Get(GetDataContext(), rolId);
            return View(model);
        }

        #endregion

        #region Post

        [HttpPost]
        [AppViewAuthorize(ConstantHelper.Views.Administration.Rol.CREATE, ConstantHelper.Views.Administration.Rol.UPDATE)]
        public ActionResult List(RolListViewModel model, FormCollection collection)
        {
            try
            {
                var logic = new RolLogic();
                var rolId = model.RolId;

                List<RolesViews> vistasRoles = context.RolesViews.Where(x => x.RolId == rolId).ToList();

                using (var transaction = new TransactionScope())
                {
                    foreach (var vistaRol in vistasRoles)
                    {
                        vistaRol.RolesViewsState = false;
                        context.SaveChanges();
                    }
                    transaction.Complete();
                }

                var vistasUsariosKey = collection.AllKeys.Where(x => x.StartsWith("chk-"));
                using (var transaction = new TransactionScope())
                {
                    foreach (var vistaUsuarioKey in vistasUsariosKey)
                    {
                        var value = collection[vistaUsuarioKey.ToString()] == "on" || collection[vistaUsuarioKey.ToString()] == "true" ? true : false;

                        var vistaCodigo = vistaUsuarioKey.Split('-')[1];
                        RolesViews vistaRol = context.RolesViews.FirstOrDefault(x => x.RolId == rolId && x.Views.ViewName.Equals(vistaCodigo));

                        if (vistaRol == null)
                        {
                            Views vista = context.Views.FirstOrDefault(x => x.ViewCode.Equals(vistaCodigo));
                            vistaRol = new RolesViews
                            {
                                RolId = rolId.Value,
                                ViewId = vista.ViewId,
                                RolesViewsState = value
                            };
                            context.RolesViews.Add(vistaRol);
                        }
                        else
                        {
                            vistaRol.RolesViewsState = value;
                        }
                        context.SaveChanges();

                    }
                    transaction.Complete();
                    PostMessage(MessageType.Success);
                }
            }
            catch (CustomException ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }

            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [AppViewAuthorize(ConstantHelper.Views.Administration.Rol.CREATE, ConstantHelper.Views.Administration.Rol.UPDATE)]
        public ActionResult AddUpdate(RolViewModel model)
        {
            try
            {
                new RolLogic().AddUpdate(GetDataContext(), model);
                PostMessage(MessageType.Success);
            }
            catch (CustomException ex)
            {
                PostMessage(MessageType.Error, ex.Message);
            }
            return RedirectToAction(nameof(List));
        }
        #endregion
    }
}