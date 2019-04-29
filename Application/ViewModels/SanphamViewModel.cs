using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class SanphamViewModel
	{
		public int KeyId { get; set; }
		public int masp { get; set; }
		public string tensp { get; set; }
		public int maloai { get; set; }
		public int mancc { get; set; }
		public double dongia { get; set; }
		public int soluong { get; set; }
		public string mota { get; set; }
		public string tenhinh { get; set; }
		public float khuyenmai { get; set; }
		public virtual LoaispViewModel LoaispNavigation { get; set; }
		public virtual ICollection<CthdViewModel> Cthds { get; set; }
		public virtual NccViewModel NccNavigation { get; set; }
		public virtual ICollection<GiohangViewModel> Giohangs { get; set; }
	}
}
