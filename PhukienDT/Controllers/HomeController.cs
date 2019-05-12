using Application.Interfaces;
using Application.ViewModels;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
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
						var userSession = new UserLoginViewModel(user);
						Session.Add(CommonConstrants.USER_SESSION,userSession);
						return Json( new { Result = userSession, Status = "OK" }, JsonRequestBehavior.AllowGet);
					}
					else
					{
						return Json( new { Result = const_Error.WRONG_LOGIN, Status = "ERROR" }, JsonRequestBehavior.AllowGet);
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
					return Json(new { Result = "", Status = "FAIL" }, JsonRequestBehavior.AllowGet);
					
				}
				else
				{
					return Json(new { Result = Session[CommonConstrants.USER_SESSION], Status = "OK" }, JsonRequestBehavior.AllowGet);
				}
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}
		[HttpPost]
		public JsonResult ConfirmEmail(string toEmailAddress, string subject, string content)
		{
			try
			{
				string MailContent = System.IO.File.ReadAllText(Server.MapPath("/Models/template.html"));
				MailContent = MailContent.Replace("{{Code}}", "Active");

				new MailHelper().SendMail(toEmailAddress, "Register Code", MailContent);
				return Json("OK", JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}
    }
}