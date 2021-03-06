﻿using Application.Interfaces;
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
using System.Web.Script.Serialization;
using Utilities.Constants;

namespace PhukienDT.Controllers
{
    public class SanphamController : Controller
    {
        private ISanphamService _sanphamService;
        private ICtGiohangService _ctGiohangService;
        private IUserService _userService;

        public SanphamController(ICtGiohangService ctGiohangService, ISanphamService sanphamService, IUserService userService)
        {
            _sanphamService = sanphamService;
            _userService = userService;
            _ctGiohangService = ctGiohangService;

        }

        public ActionResult Index(int? id)
        {
            if (id == null)
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
            if (UserLoginViewModel.Current == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

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


        #region AjaxAPI

        public JsonResult GetGioHang()

        {
            try
            {
                if (UserLoginViewModel.Current.KeyId == 0)
                {
                    return Json(new { Result = "Vui lòng đăng nhập!", Status = "FAIL" }, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    var user = _userService.GetById(UserLoginViewModel.Current.KeyId);
                    GHViewModel gh = new GHViewModel(user);

                    //var ghh = Mapper.Map<GHViewModel, GHViewModel>(gh);
                    return Json(new { Result = gh, Status = "OK" }, JsonRequestBehavior.AllowGet);


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
        public JsonResult GetAllSanPham(string keyword, int page, int pageSize)
        {
            try
            {
                var ncc = UserLoginViewModel.Current.KeyId;

                var data = _sanphamService.GetAll().Where(x => x.NccNavigation != null && x.NccNavigation.User_FK == ncc);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keysearch)).ToList();
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
                var data = _sanphamService.GetAll().Where(x => x.conlai == 0 && x.NccNavigation != null && x.NccNavigation.User_FK == ncc);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keysearch)).ToList();
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
                var data = _sanphamService.GetAll().Where(x => x.conlai > 0 && x.NccNavigation != null && x.NccNavigation.User_FK == ncc);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keysearch)).ToList();
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

                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keysearch)).ToList();
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

                var data = _sanphamService.GetAll().Where(x=>x.Status == Data.Enum.ProductStatus.Activated).OrderByDescending(x => x.KeyId).Skip((page - 1) * pageSize).Take(pageSize);


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

                var data = _sanphamService.GetAll().Where(x => x.LoaispNavigation.KeyId == id && x.Status == Data.Enum.ProductStatus.Activated);
                if (!string.IsNullOrEmpty(keyword))
                {
                    var keysearch = keyword.Trim().ToUpper();
                    data = data.Where(x => (x.masp + x.tensp + x.mota + (x.NccNavigation == null ? "" : x.NccNavigation.tenncc)).ToUpper().Contains(keysearch));
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
        public JsonResult AddToCart(CtGiohangViewModel ctGiohangVm)
        {
            try
            {
                if (Session[CommonConstrants.USER_SESSION] != null)
                {
                    var user = _userService.GetUser(UserLoginViewModel.Current.KeyId);
                    ctGiohangVm.User_FK = user.KeyId;
                    CtGiohang ct = Mapper.Map<CtGiohangViewModel, CtGiohang>(ctGiohangVm);
					var temp = user.KhachhangNavigation.CtGiohangs.FirstOrDefault(x => x.masp == ct.masp);

					if (temp==null)
					{
						user.KhachhangNavigation.CtGiohangs.Add(ct);
					}
					else
					{
						temp.soluong += ct.soluong;
					}
                    
                    if (_userService.Save())
                        return Json(new { Result = Notification.LIKE_PRODUCT, Status = "OK" }, JsonRequestBehavior.AllowGet);
                    return Json(new { Result = Notification.NOT_ADD_TO_CART, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
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

		

		public JsonResult DeleteItem(int id)
        {
            try
            {

                _ctGiohangService.Delete(id);
                _ctGiohangService.Save();
                return Json("true", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        

		[HttpPost]
		public JsonResult Upload()
		{
			var file = Request.Files["UploadedImage"];
			var type = Request["Type"];
			var srcType = "/img";
			switch (type)
			{
				case "2":
					srcType = "/img/Bao";
					break;
				case "3":
					srcType = "/img/Ring";
					break;
				case "4":
					srcType = "/img/Khac";
					break;
				default:
					srcType = "/img";
					break;
			}

			if (file != null && file.ContentLength > 0)
			{
				//getting the name of the file
				var fileName = Path.GetFileName(file.FileName);
				var s = fileName.Split('.');
				var ext = s[s.Count() - 1].ToLower();
				List<string> extValid = new List<string>(new string[] { "png", "jpg", "jpeg" });
				if (s.Count() >= 2 && extValid.Contains(ext))
				{
					//var newFileName = DateTime.Now.ToFileTime().ToString();
					var newFileName = $"Product_{DateTime.Now:yyyyMMddhhmmss}." + "png";
					var path = Path.Combine(Server.MapPath(srcType), newFileName);
					try
					{
						file.SaveAs(path);
					}
					catch (Exception ex)
					{
						return Json(new { Result="", Status="FAIL" }, JsonRequestBehavior.AllowGet);
					}
					return Json(new { Result = newFileName, Status = "OK" }, JsonRequestBehavior.AllowGet);
				}
				else
				{
					return Json(new { Result = "", Status = "INVALID" }, JsonRequestBehavior.AllowGet);
				}
					
				
			}
			return Json(new { Result = "", Status = "FAIL" }, JsonRequestBehavior.AllowGet);
		}

		[HttpPost]
		public JsonResult SaveAllEntity(SanphamViewModel sanphamVm)
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
					var user = UserLoginViewModel.Current;
					var ncc = _userService.GetUser(user.KeyId);
					ncc.NccNavigation.sltinton -= 1;
					sanphamVm.mancc = user.KeyId;
					_sanphamService.Add(sanphamVm);

				}
				if (_sanphamService.Save()) return Json(new { Result = sanphamVm, Status = "OK" }, JsonRequestBehavior.AllowGet);

				return Json(new {Result = "", Status="FAIL" }, JsonRequestBehavior.AllowGet);
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