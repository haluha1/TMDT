using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class KhachhangViewModel
	{
		public int User_FK { get; set; } // PK
		public string makh { get; set; }
		
		public virtual TaiKhoanViewModel TaiKhoanBy { get; set; }
		public virtual ICollection<CtRatingViewModel> CtRatings { get; set; }
	}
}
