using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class WebmasterViewModel
	{
		public int User_FK { get; set; } // Key ID
		public string WebmasterID { get; set; }
		
		public virtual TaiKhoanViewModel TaiKhoanBy { get; set; }
	}
}
