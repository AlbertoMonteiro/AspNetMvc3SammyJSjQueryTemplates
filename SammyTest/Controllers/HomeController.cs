using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SammyTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Session["contador"] = 0;
            return View();
        }

        public JsonResult Start()
        {
            var valor = Convert.ToInt32(Session["contador"]);
            valor++;
            Session["contador"] = valor;
            var json = new { message = valor.ToString() };
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            var valor = Convert.ToInt32(Session["contador"]);
            valor++;
            Session["contador"] = valor;
            var json = new { message = valor.ToString() };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
