using Application.Interfaces;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utilities.Constants;

namespace PhukienDT.Controllers
{
	public class HomeController : Controller
	{
		private ILoaiSPService _loaiSPService;
		private IUserService _userService;

		public HomeController(ILoaiSPService loaiSPService, IUserService userService)
		{
			_loaiSPService = loaiSPService;
			_userService = userService;
		}

		public ActionResult Index()
		{
			return View();
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
		public JsonResult GetAllLoaiSP()
		{
			try
			{

				var data = _loaiSPService.GetAll();

				//JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
				//var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);

				return Json(data, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(ex.Message, JsonRequestBehavior.AllowGet);
			}
		}
		[HttpPost]
		public JsonResult Login(LoginViewModel LoginVm)
		{
			try
			{
				if (!ModelState.IsValid)
				{
					IEnumerable<ModelError> allErrors = ModelState.Values.SelectMany(v => v.Errors);
					return Json(allErrors, JsonRequestBehavior.AllowGet);
				}
				else
				{
					var result = _userService.Login(LoginVm);
					if (result)
					{
						var user = _userService.GetByEmail(LoginVm.Username);
						var userSession = new UserLoginViewModel();
						userSession.KeyId = user.KeyId;
						userSession.UserID = user.matk;
						userSession.Email = user.email;
						userSession.UserName = user.hoten;
						userSession.Avatar = user.avatar;
						Session.Add(CommonConstrants.USER_SESSION,userSession);
						return Json(userSession, JsonRequestBehavior.AllowGet);
					}
					else
					{
						return Json(const_Error.WRONG_LOGIN, JsonRequestBehavior.AllowGet);
					}
				}
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(ex.Message, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpPost]
		public JsonResult IsLogin()
		{
			try
			{
				if (Session[CommonConstrants.USER_SESSION]==null)
				{
					return Json("", JsonRequestBehavior.AllowGet);
					
				}
				else
				{
					return Json(Session[CommonConstrants.USER_SESSION], JsonRequestBehavior.AllowGet);
				}
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(ex.Message, JsonRequestBehavior.AllowGet);
			}
		}
	}
}