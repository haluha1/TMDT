using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Utilities.Constants;

namespace PhukienDT.Controllers
{
    public class RatingController : Controller
    {
		/*private IRatingService _ratingService;
		private IUserService _userService;
		private ISanphamService _sanphamService;

		public RatingController(IRatingService ratingService, IUserService userService, ISanphamService sanphamService)
		{
			_ratingService = ratingService;
			_userService = userService;
			_sanphamService = sanphamService;
		}

		// GET: Rating
		public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public JsonResult Rating(CtRatingViewModel ctRatingVm)
		{
			try
			{

				var RatingVm = _ratingService.Add(ctRatingVm);
				
				return Json(new { Result = CommonConstrants.RATING_OK, Status = "OK" }, JsonRequestBehavior.AllowGet);


			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}

		public JsonResult GetSanPhamRating(int masp)
		{
			try
			{

				var RatingVm = _ratingService.GetAll().Where(x=>x.masp==1);
				RatingViewModel RVm = Mapper.Map<RatingViewModel, RatingViewModel>(new RatingViewModel(RatingVm.ToList()));

				return Json(new { Result = RVm, Status = "OK" }, JsonRequestBehavior.AllowGet);


			}
			catch (Exception ex)
			{
				Response.StatusCode = (int)HttpStatusCode.BadRequest;
				return Json(new { Result = ex.Message, Status = "FAIL" }, JsonRequestBehavior.AllowGet);
			}
		}*/
	}
}