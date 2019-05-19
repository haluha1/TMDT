using Application.Interfaces;
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

		public WebmasterController(IHoadonService hoadonService, IUserService userService, ICthdService cthdService, ICtGiohangService ctGiohangService, ISanphamService sanphamService, IHoadonmuatinService hoadonmuatinService)
		{
			_hoadonService = hoadonService;
			_userService = userService;
			_cthdService = cthdService;
			_ctGiohangService = ctGiohangService;
			_sanphamService = sanphamService;
			_hoadonmuatinService = hoadonmuatinService;
		}

		// GET: Webmaster
		public ActionResult Index()
        {
            return View();
        }
		public ActionResult PostInvoice()
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
		#endregion
	}
}