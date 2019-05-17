using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class CtGiohangViewModel
	{
		public int KeyId { get; set; }
		public int masp { get; set; }
		public int User_FK { get; set; }
		public int soluong { get; set; }
		public virtual KhachhangViewModel KhachhangNavigation { get; set; }
		public virtual SanphamViewModel SanphamNavigation { get; set; }
	}
}
