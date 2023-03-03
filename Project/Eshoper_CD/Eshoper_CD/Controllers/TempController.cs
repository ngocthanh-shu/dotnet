using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eshoper_CD.Controllers
{
    public class TempController : Controller
    {
        // GET: Temp
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getMenu()
        {
            var lstMenu = new MenuModel().ShowMenu();
            return PartialView(lstMenu);
        }
        public ActionResult getSlide()
        {
            var lstSlide = new SlideModel().ShowSlide();
            return PartialView(lstSlide);
        }
    }
}