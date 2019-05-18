using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public int ncc_FK { get; set; }
		public double tongtien { get; set; }
        public string thoigian { get; set; }

		[DefaultValue("Chờ xác nhận")]
		public string tinhtrang { get; set; }

		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string Note { get; set; }


		public ICollection<Cthd> Cthdons { get; set; }
		public virtual Khachhang KhachHangNavigation { get; set; }
		public virtual Ncc NccNavigation { get; set; }

	}
}
