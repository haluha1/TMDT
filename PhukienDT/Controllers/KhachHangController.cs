using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utilities.Constants;

namespace PhukienDT.Controllers
{
    public class KhachHangController : Controller
    {
		private ISanphamService _sanphamService;
		private IUserService _userService;

		public KhachHangController(ISanphamService sanphamService, IUserService userService)
		{
			_sanphamService = sanphamService;
			_userService = userService;
		}

		// GET: KhachHang
		public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public JsonResult AddToCart(int id)
		{
			try
			{
				var spVm = _sanphamService.GetById(id);
				var user = _userService.GetUser(UserLoginViewModel.Current.KeyId);
				if (user!=null)
				{
					Sanpham sp = Mapper.Map<SanphamViewModel, Sanpham>(spVm);
					//user.KhachhangNavigation.GiohangNavigation.CtGiohangs.Add(sp);
					_userService.Save();
					return Json("Đã thêm vào giỏ hàng!", JsonRequestBehavior.AllowGet);
				}
				return Json(const_Error.NOT_LOGIN, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}
	}
}