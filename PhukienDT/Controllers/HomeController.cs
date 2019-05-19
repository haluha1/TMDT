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
using Utilities;
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
        public ActionResult ttcn()
        {
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
		public JsonResult Register(TaiKhoanViewModel TaikhoanVm)
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
					var s = UtilityFunction.RandomString(6, false);
					_userService.Register(TaikhoanVm,s);
					if (TaikhoanVm.KeyId == 0)
					{
						if (TaikhoanVm.email == "") return Json(new { Result = const_Error.EXISTED_EMAIL, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
						if (TaikhoanVm.sdt == "") return Json(new { Result = const_Error.EXISTED_SDT, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
					}
					else
					{
						
						string MailContent = System.IO.File.ReadAllText(Server.MapPath("/Models/template.html"));
						MailContent = MailContent.Replace("{{Code}}", s);

						new MailHelper().SendMail(TaikhoanVm.email, "Register Code", MailContent);
						if (_userService.Save()) return Json(new { Result = TaikhoanVm, Status = "OK" }, JsonRequestBehavior.AllowGet);
					}
					


				}
				

				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = Response, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}

		public ActionResult LogOut()
		{
			Session.Clear();
			return RedirectToAction("Index", "Home");
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
				if (Session[CommonConstrants.USER_SESSION]==null || UserLoginViewModel.Current.KeyId==0)
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
		public JsonResult ConfirmCode(int id, string Code)
		{
			try
			{
				var userVm = _userService.ConfirmEmail(id, Code);
				if (userVm.KeyId == null || userVm.KeyId == 0)
				{
					return Json(new { Result = "Mã kích hoạt sai!", Status = "FAIL" }, JsonRequestBehavior.AllowGet);
				}
				else
				{
					var userSession = new UserLoginViewModel(userVm);
					Session.Add(CommonConstrants.USER_SESSION, userSession);
					return Json(new { Result = userSession, Status = "OK" }, JsonRequestBehavior.AllowGet);
				}
				
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}
        public JsonResult GetPassword(int id)
        {
            try
            {
                if (Session[CommonConstrants.USER_SESSION] == null || UserLoginViewModel.Current.KeyId == 0)
                {
                    return Json(new { Result = "", Status = "FAIL" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var pass =_userService.GetUser(id).matkhau;

                    return Json(pass, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult UpdatePassword(string mk)
        {
            try
            {
                //var id = UserLoginViewModel.Current.KeyId;
                //var omk = UserLoginViewModel.Current.Password;
                if (Session[CommonConstrants.USER_SESSION] == null || UserLoginViewModel.Current.KeyId == 0)
                {
                    return Json(new { Result = "", Status = "FAIL" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    var user = _userService.GetUser(UserLoginViewModel.Current.KeyId);
                    user.matkhau = mk;
                    _userService.Save();
                    return Json(new { Result = Session[CommonConstrants.USER_SESSION], Status = "OK" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}