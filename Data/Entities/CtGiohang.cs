using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
	public class CtGiohang : DomainEntity<int>
	{
		public int masp { get; set; }
		public int User_FK { get; set; }
		public int soluong { get; set; }
		public virtual Khachhang KhachhangNavigation { get; set; }
		public virtual Sanpham SanphamNavigation { get; set; }
	}
}
