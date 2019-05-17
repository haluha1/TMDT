using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Data.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utilities.Constants;

namespace PhukienDT.Controllers
{
    public class SanphamController : Controller
    {
        private ISanphamService _sanphamService;
		private IUserService _userService;

		public SanphamController(ISanphamService sanphamService, IUserService userService)
		{
			_sanphamService = sanphamService;
			_userService = userService;
		}

		public ActionResult Index(int? id)
        {
			if (id==null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			else
			{
				var model = _sanphamService.GetAll().Where(x => x.maloai == id).ToList();
				IEnumerable<SanphamViewModel> sp;
				sp = model;
				return View(model);

			}
            
        }
        
        // GET: Sanpham
        public ActionResult ctsp()
        {
            return View();
        }
        public ActionResult Rating()
        {
            return View();
        }

        public ActionResult Sanphamyt()
        {
            return View();
        }
        public ActionResult Giohang()
        {
            return View();
        }
        public ActionResult Theosanpham()
        {
            return View();
        }
        public JsonResult GetCTSP(int id)
        {
            try
            {
                var data = _sanphamService.GetById(id);
                return Json(new { Result = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetGioHang()
        {
            try
            {
				if (UserLoginViewModel.Current.KeyId == 0)
				{
					return Json(new { Result = "Vui lòng đăng nhập!", Status="FAIL" }, JsonRequestBehavior.AllowGet);
				}
				else
				{

					var user = _userService.GetById(UserLoginViewModel.Current.KeyId);
					GHViewModel gh = new GHViewModel(user);
					//var gh = Mapper.Map<GHViewModel, GHViewModel>(ghh);
					return Json(new { Result = gh, Status="OK" }, JsonRequestBehavior.AllowGet);
				}

                
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult GetSPYT(int id)
        {
            try
            {
                var data = _sanphamService.GetById(id);
                return Json(new { Result = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        #region AjaxAPI
        public JsonResult GetAllSanPham(string keyword, int page, int pageSize)
        {
            try
            {
                var ncc = UserLoginViewModel.Current.KeyId;

                var data = _sanphamService.GetAll().Where(x=>x.NccNavigation !=null && x.NccNavigation.User_FK == ncc);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();
                    
                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keyword)).ToList();
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

        public JsonResult GetAllSanPhamHet(string keyword, int page, int pageSize)
        {
            try
            {
                var ncc = UserLoginViewModel.Current.KeyId;
                var data = _sanphamService.GetAll().Where(x=>x.soluong == 0 && x.NccNavigation != null && x.NccNavigation.User_FK == ncc);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keyword)).ToList();
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

        public JsonResult GetAllSanPhamCon(string keyword, int page, int pageSize)
        {
            try
            {
                var ncc = UserLoginViewModel.Current.KeyId;
                var data = _sanphamService.GetAll().Where(x => x.soluong > 0 && x.NccNavigation != null && x.NccNavigation.User_FK == ncc);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keyword)).ToList();
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

        public JsonResult GetAllSanPhamKhoa(string keyword, int page, int pageSize)
        {
            try
            {
                var data = _sanphamService.GetAll().Where(x => x.soluong == 0);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keyword)).ToList();
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

        public JsonResult GetNewProduct(int page, int pageSize)
		{
			try
			{

				var data = _sanphamService.GetAll().OrderByDescending(x=>x.KeyId).Skip((page - 1) * pageSize).Take(pageSize);

				
				//JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
				//var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);

				return Json(new { Result = data }, JsonRequestBehavior.AllowGet);

			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(ex.Message, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetByType(int id, string keyword, int page, int pageSize)
		{
			try
			{

				var data = _sanphamService.GetAll().Where(x=>x.LoaispNavigation.KeyId==id);
				if (!string.IsNullOrEmpty(keyword))
				{
					var keysearch = keyword.Trim().ToUpper();
					data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keyword));
				}
				int totalRow = data.Count();
				data = data.Skip((page - 1) * pageSize).Take(pageSize);
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
		[HttpPost]
		public JsonResult Like(int id)
		{
			try
			{
				if (Session[CommonConstrants.USER_SESSION] != null)
				{
					var spVm = _sanphamService.GetById(id);
					var user = _userService.GetUser(UserLoginViewModel.Current.KeyId);
					Sanpham sp = Mapper.Map<SanphamViewModel, Sanpham>(spVm);
					user.KhachhangNavigation.SanPhamYeuThichs.Add(sp);
					_sanphamService.Save();
					return Json(new { Result = Notification.LIKE_PRODUCT, Status = "OK" }, JsonRequestBehavior.AllowGet);
				}
				else
				{
					return Json(new { Result = Notification.LIKE_NOT_LOGIN, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
				}
				
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}

		[HttpPost]
		public JsonResult SaveEntity(SanphamViewModel sanphamVm)
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
					if (sanphamVm.KeyId == 0) _sanphamService.Add(sanphamVm);
					else _sanphamService.Update(sanphamVm);
				}
				if (_sanphamService.Save()) return Json(sanphamVm, JsonRequestBehavior.AllowGet);

				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(Response, JsonRequestBehavior.AllowGet);
			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(ex.Message, JsonRequestBehavior.AllowGet);
			}
		}

        [HttpPost]
        public JsonResult upload(HttpPostedFileBase file)
        {
            //verify that the file is selected and not empty
            if (file != null && file.ContentLength > 0)
            {
                //getting the name of the file
                var fileName = Path.GetFileName(file.FileName);

                //store file in the Books folder
                var path = Path.Combine(Server.MapPath("/img"), fileName);
                try
                {
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {

                }
                return Json(path, JsonRequestBehavior.AllowGet);
            }
            return Json("error", JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}