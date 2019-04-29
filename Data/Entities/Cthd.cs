using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Cthd : DomainEntity<int>
    {
        public Cthd(int Mahd, int Masp, int Soluong, double Thanhtien)
        {
            mahd = Mahd;
            masp = Masp;
            soluong = Soluong;
            thanhtien = Thanhtien;
        }

        public int mahd { get; set; }
        public int masp { get; set; }
        public int soluong { get; set; }
        public double thanhtien { get; set; }
		public virtual Sanpham SanphamNavigation { get; set; }
		public virtual Hoadon HoadonNavigation { get; set; }
	}
}
