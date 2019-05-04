using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhukienDT.Controllers
{
    public class SanphamController : Controller
    {
        private ISanphamService _sanphamService;

        public SanphamController(ISanphamService sanphamService)
        {
            _sanphamService = sanphamService;
        }

        public ActionResult Index()
        {
            return View();
        }
        
        // GET: Sanpham
        public ActionResult Ctsp()
        {
            return View();
        }
        

        #region AjaxAPI
        public JsonResult GetAllSanPham()
        {
            try
            {

                var data = _sanphamService.GetAll();

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