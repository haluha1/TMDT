using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhukienDT.Controllers
{
    public class HoadonController : Controller
    {
        private IHoadonService _hoadonService;
        private IUserService _userService;

        public HoadonController(IHoadonService hoadonService, IUserService userService)
        {
            _hoadonService = hoadonService;
            _userService = userService;
        }

        // GET: Hoadon
        public ActionResult Index()
        {
            return View();
        }

        #region AjaxAPI
        public JsonResult GetAllHoadon(string keyword, int page, int pageSize)
        {
            try
            {
                var data = _hoadonService.GetAll();
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keyword)).ToList();
                }
                int totalRow = data.Count();
                data = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                //JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
                //var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);              
                return Json(new { Result = data, PageCount = totalRow }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        
        #endregion
    }
}