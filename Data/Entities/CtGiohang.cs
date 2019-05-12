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
		public int Giohang_FK { get; set; }
		public int soluong { get; set; }
		public virtual Giohang GiohangNavigation { get; set; }
		public virtual Sanpham SanphamNavigation { get; set; }
	}
}
