using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Hoadon : DomainEntity<int>
    {
        public Hoadon()
        {
            Cthdons = new HashSet<Cthd>();
        }

        public int mahd { get; set; }
        public int makh { get; set; }
        public double tongtien { get; set; }
        public string thoigian { get; set; }
        public ICollection<Cthd> Cthdons { get; set; }
		public virtual Khachhang KhachHangNavigation { get; set; }

    }
}
