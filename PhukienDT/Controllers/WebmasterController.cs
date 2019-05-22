using Application.Interfaces;
using Application.ViewModels;
using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhukienDT.Controllers
{
    public class WebmasterController : Controller
    {
		private IHoadonService _hoadonService;
		private IUserService _userService;
		private ICthdService _cthdService;
		private ICtGiohangService _ctGiohangService;
		private ISanphamService _sanphamService;
		private IHoadonmuatinService _hoadonmuatinService;
		private IFunctionService _functionService;

		public WebmasterController(IHoadonService hoadonService, IUserService userService, ICthdService cthdService, ICtGiohangService ctGiohangService, ISanphamService sanphamService, IHoadonmuatinService hoadonmuatinService, IFunctionService functionService)
		{
			_hoadonService = hoadonService;
			_userService = userService;
			_cthdService = cthdService;
			_ctGiohangService = ctGiohangService;
			_sanphamService = sanphamService;
			_hoadonmuatinService = hoadonmuatinService;
			_functionService = functionService;
		}




		// GET: Webmaster
		public ActionResult Index()
        {
			var user = UserLoginViewModel.Current;
			if (user != null && user.UserType == Data.Enum.UserType.Webmaster)
			{
				List<FunctionViewModel> data = _functionService.GetAll();
				return View(data);
			}
			else
			{
				return RedirectToAction("Login", "Webmaster");
			}
        }
		public ActionResult PostInvoice()
		{
			var user = UserLoginViewModel.Current;
			if (user != null && user.UserType == Data.Enum.UserType.Webmaster)
			{
				List<FunctionViewModel> data = _functionService.GetAll();
				return View(data);
			}
			else
			{
				return RedirectToAction("Login", "Webmaster");
			}
		}

		public ActionResult PostProduct()
		{
			var user = UserLoginViewModel.Current;
			if (user != null && user.UserType == Data.Enum.UserType.Webmaster)
			{
				List<FunctionViewModel> data = _functionService.GetAll();
				return View(data);
			}
			else
			{
				return RedirectToAction("Login", "Webmaster");
			}
		}

		public ActionResult Login()
		{
			return View();
		}

		#region Ajax API
		public JsonResult GetAllHoadonmuatin(string keyword, int page, int pageSize)
		{
			try
			{
				var data = _hoadonmuatinService.GetAll();
				if (!string.IsNullOrEmpty(keyword))
				{
					var keysearch = keyword.Trim().ToUpper();

					data = data.Where(x => x.NccNavigation.tenncc.ToUpper().Contains(keysearch)).ToList();
				}
				int totalRow = data.Count();
				data = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
				//JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
				//var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);              
				return Json(new { Result = data, PageCount = totalRow, Status="OK" }, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetAllTin(string keyword, int page, int pageSize)
		{
			try
			{
				var data = _sanphamService.GetAll();
				if (!string.IsNullOrEmpty(keyword))
				{
					var keysearch = keyword.Trim().ToUpper();

					data = data.Where(x => x.NccNavigation.tenncc.ToUpper().Contains(keysearch)).ToList();
				}
				int totalRow = data.Count();
				data = data.OrderByDescending(x=>x.KeyId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
				//JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
				//var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);              
				return Json(new { Result = data, PageCount = totalRow, Status = "OK" }, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpPost]
		public JsonResult DuyetPostInvoice(int id)
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
					var hd = _hoadonmuatinService.GetById(id);
					hd.Status = Data.Enum.PostInvoiceStatus.Processed;
					var user = _userService.GetUser(hd.mancc);
					user.NccNavigation.sltinton += hd.GiatinNavigation.soluongtin;
					_hoadonmuatinService.Update(hd);
					if (_hoadonmuatinService.Save()) return Json(new { Result = hd, Status = "OK" }, JsonRequestBehavior.AllowGet);
				}
				
				
				return Json(new {Result="", Status="FAIL" }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpPost]
		public JsonResult DuyetPostTin(int id, ProductStatus status)
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
					var sp = _sanphamService.GetById(id);
					sp.Status = status;
					_sanphamService.Update(sp);
					if (_sanphamService.Save()) return Json(new { Result = sp, Status = "OK" }, JsonRequestBehavior.AllowGet);
				}


				return Json(new { Result = "", Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}
		#endregion
	}
}