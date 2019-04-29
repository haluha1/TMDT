using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class WebmasterViewModel
	{
		public int KeyId { get; set; }
		public string WebmasterID { get; set; }
		public int User_FK { get; set; }
		public virtual TaiKhoanViewModel TaiKhoanBy { get; set; }
	}
}
