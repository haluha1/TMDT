using Data.Enum;
using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Sanpham : DomainEntity<int>
    {
		public Sanpham()
		{
			Cthds = new HashSet<Cthd>();
			CtGiohangs = new HashSet<CtGiohang>();
			KhachHangYeuThichs = new HashSet<Khachhang>();
		}

		public Sanpham(int keyId, string masp, string tensp, int maloai, int mancc, double dongia, int soluong, int conlai, string mota, string tenhinh, float khuyenmai, ProductStatus status)
		{
			KeyId = keyId;
			this.masp = masp;
			this.tensp = tensp;
			this.maloai = maloai;
			this.mancc = mancc;
			this.dongia = dongia;
			this.soluong = soluong;
			this.conlai = conlai;
			this.mota = mota;
			this.tenhinh = tenhinh;
			this.khuyenmai = khuyenmai;
			Status = status;
		}

		public string masp { get; set; }
        public string tensp { get; set; }
        public int maloai { get; set; }
        public int mancc { get; set; }
        public double dongia { get; set; }
        public int soluong { get; set; }
		public int conlai { get; set; }
		public string mota { get; set; }
        public string tenhinh { get; set; }
        public float khuyenmai { get; set; }
		[DefaultValue(ProductStatus.Processing)]
		public ProductStatus Status { get; set; }
		public virtual Loaisp LoaispNavigation { get; set; }
		public virtual ICollection<Cthd> Cthds { get; set; }
		public virtual Ncc NccNavigation { get; set; }
		public virtual ICollection<CtGiohang> CtGiohangs { get; set; }
		public virtual ICollection<Khachhang> KhachHangYeuThichs { get; set; }
		

	}
}
