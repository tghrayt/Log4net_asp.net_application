using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Utilities;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {

        [CustomExceptionHandling]
        public ActionResult Index()
        {
           
                throw new ArithmeticException();
                Log.Debug("Testing ");
                Log.Info("Info Testing");
           

            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [CustomExceptionHandling]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}