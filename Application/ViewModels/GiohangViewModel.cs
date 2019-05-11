using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class GiohangViewModel
	{
		public int KeyId { get; set; }
		public int soluong { get; set; }
		public double thanhtien { get; set; }
		public virtual ICollection<SanphamViewModel> Sanphams { get; set; }
		public virtual KhachhangViewModel KhachHangBy { get; set; }
	}
}
