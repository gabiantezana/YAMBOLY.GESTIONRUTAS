using System;
using System.Linq;
using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.HELPER;
using YAMBOLY.GESTIONRUTAS.LOGIC.Administration;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.VIEWMODEL.General;
using System.Data.Entity;
using System.Data;

namespace YAMBOLY.GESTIONRUTAS.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                Users entity = context.Users.Include(x => x.Roles.RolesViews.Select(y => y.Views)).FirstOrDefault(x => x.UserName == model.Codigo);
                var hasChangePassword = true;
                if (entity != null)
                {
                    var byteArrayPassword = EncryptionHelper.EncryptTextToMemory(model.Password, ConstantHelper.ENCRIPT_KEY, ConstantHelper.ENCRIPT_METHOD);

                    if (!byteArrayPassword.SequenceEqual(entity.Pass))
                    {
                        PostMessage(MessageType.Error, "Contraseña incorrecta");
                        return RedirectToAction(nameof(Login));
                    }
                    if (entity.isActive ?? false)
                    {
                        PostMessage(MessageType.Error, "Su usuario no se encuentra activo");
                        return RedirectToAction(nameof(Login));
                    }

                    var basePasswordEncryp = EncryptionHelper.EncryptTextToMemory(ConstantHelper.PASSWORD_DEFAULT, ConstantHelper.ENCRIPT_KEY, ConstantHelper.ENCRIPT_METHOD);

                    if (entity.Pass.SequenceEqual(basePasswordEncryp) || entity.Pass.ToSafeString().Equals(String.Empty))
                        hasChangePassword = false;

                    //TODO:
                    Session.Set(SessionKey.UserNames, "TEST USERNAMESS");
                    Session.Set(SessionKey.UserName, entity.UserName);

                    Session.Set(SessionKey.Views, entity.Roles.RolesViews.Where(x => x.RolesViewsState == true).Select(x => x.Views.ViewName).ToArray());
                    Session.Set(SessionKey.UserId, entity.UserId);

                    var appRol = Enum.Parse(typeof(AppRol), entity.Roles.RolDescription);
                    Session.Set(SessionKey.Rol, entity.Roles.RolDescription);
                    switch (appRol)
                    {
                        case AppRol.Administrator:
                            Session.Set(SessionKey.Views, context.Views.Select(x => x.ViewName).ToArray());
                            break;
                    }
                    
                    if (!hasChangePassword)
                        return RedirectToAction(nameof(ChangePassword));
                    else
                        return RedirectToAction(nameof(Index));
                }
                else
                {
                    PostMessage(MessageType.Error, "Su usuario no existe");
                    return RedirectToAction(nameof(Login));
                }
            }
            catch (Exception ex)
            {
                PostMessage(MessageType.Error, "Ocurrió un error inesperado: " + ex.ToString());
            }

            return RedirectToAction(nameof(Login));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult TestMap01()
        {
            return View();
        }

        public ActionResult TestMap02()
        {
            return View();
        }

        public ActionResult TestMap03()
        {
            return View();
        }

        public ActionResult TestMap04()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                new UserLogic().ChangePassword(GetDataContext(), model);
                PostMessage(MessageType.Success, "Su contraseña se cambio exitosamente");
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Session.Clear();
                PostMessage(MessageType.Error, ex.ToString());
                return RedirectToAction(nameof(Login));
            }
        }

        public ActionResult PermisoInsuficiente()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        public ContentResult KeepAlive()
        {
            return Content(String.Empty);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        public ActionResult EditComentario()
        {
            var viewmodel = new LoginViewModel();
            return View(viewmodel);
        }

        [HttpPost]
        public JsonResult EditComentario(LoginViewModel model)
        {
            return Json(new { success = true });
        }


    }
}