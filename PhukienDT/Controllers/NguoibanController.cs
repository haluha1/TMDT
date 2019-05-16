using Application.ViewModels;
using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhukienDT.Controllers
{
    public class NguoibanController : Controller
    {
        // GET: Nguoiban
        public ActionResult Index()
        {
			if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home", new { area = "" });
			}
        }
        public ActionResult Sanpham()
        {
            return View();
        }
        public ActionResult Doanhthu()
        {
            return View();
        }
        public ActionResult Muatin()
        {
            return View();
        }
        public ActionResult Donban()
        {
            return View();
        }
    }
}