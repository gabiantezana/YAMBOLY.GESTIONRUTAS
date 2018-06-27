using System.Web;
using System.Web.Mvc;
using YAMBOLY.GESTIONRUTAS.MODEL;
using YAMBOLY.GESTIONRUTAS.HELPER;
using System.Web.Routing;
using System.Collections.Generic;
using YAMBOLY.GESTIONRUTAS.EXCEPTION;

namespace YAMBOLY.GESTIONRUTAS.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        private DataContext DataContext;
        public YAMBOLY_GESTIONRUTASEntities context { get; set; }
        public string currentCulture { get; set; }
        protected HttpBrowserCapabilitiesBase Browser { get; set; }

        public BaseController()
        {
            if (context == null)
                context = new YAMBOLY_GESTIONRUTASEntities();
            currentCulture = System.Threading.Thread.CurrentThread.CurrentUICulture.ToString();
        }

        public DataContext GetDataContext()
        {
            if (DataContext == null)
                DataContext = new DataContext
                {
                    context = context,
                    session = Session,
                    currentCulture = currentCulture,
                    Browser = this.Request.Browser
                };
            return DataContext;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var context = GetDataContext();
            System.Exception ex = filterContext.Exception;
            var action = "Index";
            var controller = "Home";

            ExceptionHelper.LogException(ex, context);
            filterContext.ExceptionHandled = true;
            filterContext.Result = new RedirectToRouteResult(
                                   new RouteValueDictionary
                                   {
                                       { "action", action },
                                       { "controller", controller },
                                       { "area", ""}
                                   });
            base.OnException(filterContext);
            PostMessage(MessageType.Error, ConstantHelper.EXCEPTION_MESSAGE + " " + filterContext.Exception.Message);
            //TODO:
            //PostMessage(MessageType.Warning, filterContext.Exception.Message);
        }

        public void PostMessage(MessageType messageType)
        {
            TempDataEntity model = new TempDataEntity();
            model.TipoMensaje = messageType;
            switch (messageType)
            {
                case MessageType.Success: model.Mensaje = ConstantHelper.SUCCESS_MESSAGE; break;
                case MessageType.Error: model.Mensaje = ConstantHelper.ERROR_MESSAGE; break;
            }

            var lastList = (List<TempDataEntity>)(TempData["Message"] ?? new List<TempDataEntity>());
            lastList.Add(model);

            TempData["Message"] = lastList;
        }

        public void PostMessage(MessageType messageType, string body = null)
        {
            TempDataEntity model = new TempDataEntity();
            model.TipoMensaje = messageType;
            model.Mensaje = body;

            var lastList = (List<TempDataEntity>)(TempData["Message"] ?? new List<TempDataEntity>());
            lastList.Add(model);

            TempData["Message"] = lastList;
        }

        public void PostMessage(CustomException exception)
        {
            CustomException model = new CustomException();

            var lastList = (List<CustomException>)(TempData["Exception"] ?? new List<CustomException>());
            lastList.Add(exception);
            TempData["Exception"] = lastList;
        }

    }
}