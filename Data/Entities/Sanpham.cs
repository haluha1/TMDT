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
        public int masp { get; set; }
        public string tensp { get; set; }
        public int maloai { get; set; }
        public int mancc { get; set; }
        public double dongia { get; set; }
        public int soluong { get; set; }
        public string mota { get; set; }
        public string tenhinh { get; set; }
        public float khuyenmai { get; set; }

    }
}
