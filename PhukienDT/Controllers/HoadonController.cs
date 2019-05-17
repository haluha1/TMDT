using Application.Interfaces;
using Application.ViewModels;
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
        private ICthdService _cthdService;

        public HoadonController(IHoadonService hoadonService, IUserService userService, ICthdService cthdService)
        {
            _hoadonService = hoadonService;
            _userService = userService;
            _cthdService = cthdService;
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
                var ncc = UserLoginViewModel.Current.KeyId;
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

        public JsonResult GetAllHoadonChoxacnhan(string keyword, int page, int pageSize)
        {
            try
            {
                var data = _hoadonService.GetAll().Where(x=>x.tinhtrang == "Chờ xác nhận");
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
        public JsonResult GetAllHoadonGiaohang(string keyword, int page, int pageSize)
        {
            try
            {
                var data = _hoadonService.GetAll().Where(x => x.tinhtrang == "Giao hàng");
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
        public JsonResult GetAllHoadonHoanthanh(string keyword, int page, int pageSize)
        {
            try
            {
                var data = _hoadonService.GetAll().Where(x => x.tinhtrang == "Hoàn thành");
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
        public JsonResult GetAllHoadonHuy(string keyword, int page, int pageSize)
        {
            try
            {
                var data = _hoadonService.GetAll().Where(x => x.tinhtrang == "Hủy");
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

        public JsonResult GetById(int id)
        {
            try
            {
                _hoadonService.GetById(id);
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllCthdById(int id)
        {
            try
            {
                List<CthdViewModel> res = _cthdService.GetAllByInvoiceId(id);
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        
        //public JsonResult GetAllCthd(string keyword, int page, int pageSize)
        //{
        //    try
        //    {
        //        var ncc = UserLoginViewModel.Current.KeyId;
        //        var data = _cthdService.GetAll();
        //        if (!string.IsNullOrEmpty(keyword))
        //        {
        //            var keysearch = keyword.Trim().ToUpper();

        //            data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keyword)).ToList();
        //        }
        //        int totalRow = data.Count();
        //        data = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //        //JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
        //        //var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);              
        //        return Json(new { Result = data, PageCount = totalRow }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json(ex.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}

        #endregion
    }
}