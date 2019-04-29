using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class TaiKhoanViewModel
	{
		public int KeyId { get; set; }
		public int matk { get; set; }
		public string hoten { get; set; }
		public string email { get; set; }
		public string diachi { get; set; }
		public string sdt { get; set; }
		public string sotk { get; set; }
		public string matkhau { get; set; }
		public string thoigiandk { get; set; }


		
		public bool? IsCustomer { get; set; }
		
		public bool? IsMerchant { get; set; }
		
		public bool? IsWebmaster { get; set; }

		public virtual KhachhangViewModel KhachhangNavigation { get; set; }
		public virtual NccViewModel NccNavigation { get; set; }
		public virtual WebmasterViewModel WebmasterNavigation { get; set; }


		public virtual ICollection<HoadonmuatinViewModel> Hoadonmuatins { get; set; }
		public virtual ICollection<HoadonViewModel> Hoadons { get; set; }
		public virtual GiohangViewModel GiohangNavigation { get; set; }
	}
}
