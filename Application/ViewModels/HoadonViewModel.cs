using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class HoadonViewModel
	{
		public int KeyId { get; set; }
		public int mahd { get; set; }
		public int makh { get; set; }
		public double tongtien { get; set; }
		public string thoigian { get; set; }
		public ICollection<CthdViewModel> Cthdons { get; set; }
		public virtual KhachhangViewModel KhachHangNavigation { get; set; }
	}
}
