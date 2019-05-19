using Application.Interfaces;
using Application.ViewModels;
using Data.Entities;
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
		private ICtGiohangService _ctGiohangService;
		private ISanphamService _sanphamService;

		public HoadonController(IHoadonService hoadonService, IUserService userService, ICthdService cthdService, ICtGiohangService ctGiohangService, ISanphamService sanphamService)
		{
			_hoadonService = hoadonService;
			_userService = userService;
			_cthdService = cthdService;
			_ctGiohangService = ctGiohangService;
			_sanphamService = sanphamService;
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

                    data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keysearch)).ToList();
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

                    data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keysearch)).ToList();
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

                    data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keysearch)).ToList();
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

                    data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keysearch)).ToList();
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

                    data = data.Where(x => x.KhachHangNavigation.TaiKhoanBy.hoten.ToUpper().Contains(keysearch)).ToList();
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


		[HttpPost]
		public JsonResult SaveAllEntity(HoadonViewModel Information,List<CtGiohangViewModel> Products)
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
					#region Add new invoice
					//Current Customer
					var kh = UserLoginViewModel.Current;
					//Get all ncc distinct
					List<int> ncc = new List<int>();
					List<SanphamViewModel> spVm = new List<SanphamViewModel>();
					foreach(var item in Products)
					{
						var sp = _sanphamService.GetById(item.masp);
						spVm.Add(sp);
						if (ncc.FirstOrDefault(x => x == sp.NccNavigation.User_FK)==0)
						{
							ncc.Add(sp.NccNavigation.User_FK);
						}
					}
					List<HoadonViewModel> hdVm = new List<HoadonViewModel>();
					//Create Invoice foreach ncc
					foreach(var i in ncc)
					{
						//var accountNcc = _userService.GetUser(i);
						HoadonViewModel hd = new HoadonViewModel();
						hd.KeyId = 0;
						hd.mahd = 0;
						hd.makh = kh.KeyId;
						hd.ncc_FK = i;
						hd.tongtien = 0;
						hd.thoigian = DateTime.Now.ToShortDateString();
						hd.Name = Information.Name;
						hd.Phone = Information.Phone;
						hd.Address = Information.Address;
						hd.Note = Information.Note;
						hd.Cthdons = new HashSet<CthdViewModel>();
						foreach(var item in Products)
						{
							var pro = spVm.FirstOrDefault(x => x.KeyId == item.masp);
							if (pro.NccNavigation.User_FK==i)
							{
								CthdViewModel cthd = new CthdViewModel();
								cthd.mahd = 0;
								cthd.masp = pro.KeyId;
								cthd.soluong = item.soluong;
								cthd.thanhtien = pro.dongia * (double)item.soluong;
								hd.Cthdons.Add(cthd);
								hd.tongtien += cthd.thanhtien;
								//Products.Remove(item);

								//Update Number of Product
								pro.conlai -= cthd.soluong;
								if (pro.conlai < 1)
								{
									pro.Status = Data.Enum.ProductStatus.Sold;
								}
								_sanphamService.Update(pro);
							}
							
						}
						hdVm.Add(_hoadonService.Add(hd));
					}
					#endregion

					#region Clear cart
					var Customer = _userService.GetUser(kh.KeyId);
					List<int> cart = new List<int>();

					foreach (var i in Customer.KhachhangNavigation.CtGiohangs) cart.Add(i.KeyId);
					foreach (var cartItem in cart)
					{
						_ctGiohangService.Delete(cartItem);
					}
					#endregion


					if (_hoadonService.Save()) return Json(new { Result = hdVm, Status = "OK" }, JsonRequestBehavior.AllowGet);

				}
				return Json(new { Result="Đã có lỗi xảy ra khi đặt hàng!", Status="FAIL"}, JsonRequestBehavior.AllowGet);
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