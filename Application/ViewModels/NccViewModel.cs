using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class NccViewModel
	{
		public int KeyId { get; set; }
		public string tenncc { get; set; }
		public string gioithieu { get; set; }
		public int sltinton { get; set; }
		public int User_FK { get; set; }
		public virtual TaiKhoanViewModel TaiKhoanBy { get; set; }
	}
}
