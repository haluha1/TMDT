using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Giohang
    {
        public int KeyId { get; set; }
        public int soluong { get; set; }
        public double thanhtien { get; set; }
		public virtual ICollection<Sanpham> Sanphams { get; set; }
		public virtual Khachhang KhachHangBy { get; set; }

	}
}
