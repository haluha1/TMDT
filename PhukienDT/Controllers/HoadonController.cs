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
        public JsonResult GetAllHoadon()
        {
            try
            {

                var data = _hoadonService.GetAll();

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

        
        #endregion
    }
}