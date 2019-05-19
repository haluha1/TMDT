using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Data.Entities;
using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utilities.Constants;

namespace PhukienDT.Controllers
{
    public class NguoibanController : Controller
    {
        private IGiatinService _giatinService;
        private IUserService _userService;

        public NguoibanController(IGiatinService giatinService, IUserService userService)
        {
            _giatinService = giatinService;
            _userService = userService;
        }


        // GET: Nguoiban
        public ActionResult Index()
        {
			if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
			{
				return View();
			}
			else
			{
				return RedirectToAction("Index", "Home", new { area = "" });
			}
        }
        public ActionResult Sanpham()
        {
            if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        public ActionResult Doanhthu()
        {
            if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        public ActionResult Muatin()
        {
            if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        public ActionResult Donban()
        {
            if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }
        public ActionResult Thongtinnguoiban()
        {
            if (UserLoginViewModel.Current != null && UserLoginViewModel.Current.UserType == UserType.Merchant)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
        }

        #region AjaxAPI
        public JsonResult GetAllGiatin()
        {
            try
            {
                var data = _giatinService.GetAll();
                              
                return Json(new { Result = data}, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetThongtinNguoiban()
        {
            try
            {

                var ncc = _userService.GetById(UserLoginViewModel.Current.KeyId);

                return Json(new { Result = ncc }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetThongtinHdMuatin()
        //{
        //    try
        //    {

        //        var hdmt = _userService.GetById(UserLoginViewModel.Current.KeyId);

        //        return Json(new { Result = hdmt }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        return Json(ex.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}

        [HttpPost]
        public JsonResult Muatin(int id)
        {
            try
            {
                
                var user = _userService.GetUser(UserLoginViewModel.Current.KeyId);
                HoadonmuatinViewModel hdVm = new HoadonmuatinViewModel();
                hdVm.KeyId = 0;
                hdVm.mahd = 0;
                hdVm.mancc = user.KeyId;
                hdVm.magiatin = id;
                hdVm.thoigian = DateTime.Now.ToShortDateString();
                Hoadonmuatin hd = Mapper.Map<HoadonmuatinViewModel, Hoadonmuatin>(hdVm);
                user.NccNavigation.Hoadonmuatins.Add(hd);
                _userService.Save();
				hd.mahd = hd.KeyId;
				_userService.Save();
				return Json(new { Result = Notification.BUYSUCCESS, Status = "OK" }, JsonRequestBehavior.AllowGet);
                

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