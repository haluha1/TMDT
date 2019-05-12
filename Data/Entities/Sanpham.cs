using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Sanpham : DomainEntity<int>
    {
		public Sanpham()
		{
		}

		public Sanpham(int keyId, int masp, string tensp, int maloai, int mancc, double dongia, int soluong, string mota, string tenhinh, float khuyenmai)
		{
			KeyId = keyId;
			this.masp = masp;
			this.tensp = tensp;
			this.maloai = maloai;
			this.mancc = mancc;
			this.dongia = dongia;
			this.soluong = soluong;
			this.mota = mota;
			this.tenhinh = tenhinh;
			this.khuyenmai = khuyenmai;
		}

		public int masp { get; set; }
        public string tensp { get; set; }
        public int maloai { get; set; }
        public int mancc { get; set; }
        public double dongia { get; set; }
        public int soluong { get; set; }
        public string mota { get; set; }
        public string tenhinh { get; set; }
        public float khuyenmai { get; set; }
		public virtual Loaisp LoaispNavigation { get; set; }
		public virtual ICollection<Cthd> Cthds { get; set; }
		public virtual Ncc NccNavigation { get; set; }
		public virtual ICollection<CtGiohang> CtGiohangs { get; set; }
		public virtual ICollection<Khachhang> KhachHangYeuThichs { get; set; }
		

	}
}
