using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Utilities
{
    public class CustomExceptionHandling : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled)
            {
                string controllerName = (string)exceptionContext.RouteData.Values["controller"];
                string actionName = (string)exceptionContext.RouteData.Values["action"];

                Exception custException = new Exception("There is some error");



                var model = new HandleErrorInfo(custException, controllerName, actionName);

                exceptionContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = exceptionContext.Controller.TempData
                };

                exceptionContext.ExceptionHandled = true;

            }
        }
    }

    public class Constants
    {
        public const string CUSTOM_ERROR1 = "System Error";
        public const string CUSTOM_ERROR2 = "Contact Administrator";
    }


}
