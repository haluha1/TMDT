using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class GHViewModel
	{
		public GHViewModel(TaiKhoanViewModel taiKhoanVm)
		{
			KeyId = taiKhoanVm.KeyId;
			CtGiohangs = taiKhoanVm.KhachhangNavigation.GiohangNavigation.CtGiohangs;
			foreach(var i in CtGiohangs)
			{
				i.GiohangNavigation = null;
				i.SanphamNavigation.CtGiohangs = null;
				i.SanphamNavigation.KhachHangYeuThichs = null;
				i.SanphamNavigation.LoaispNavigation.Sanphams = null;
			}
		}

		public int KeyId { get; set; }
		public int soluong { get { return CtGiohangs.Count; } }
		public double thanhtien
		{
			get
			{
				double tong = 0;
				foreach (CtGiohangViewModel item in CtGiohangs)
				{
					tong += item.soluong * item.SanphamNavigation.dongia;
				}
				return tong;
			}
		}
		public virtual ICollection<CtGiohangViewModel> CtGiohangs { get; set; }
		public virtual KhachhangViewModel KhachHangBy { get; set; }
	}
}
