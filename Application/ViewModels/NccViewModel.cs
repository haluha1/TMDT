using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class NccViewModel
	{
		public int User_FK { get; set; } // PK
		public string tenncc { get; set; }
		public string gioithieu { get; set; }
		public int sltinton { get; set; }
		
		public virtual TaiKhoanViewModel TaiKhoanBy { get; set; }
		public virtual ICollection<HoadonmuatinViewModel> Hoadonmuatins { get; set; }
	}
}
