using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TaiKhoan : DomainEntity<int>
    {
        public int matk { get; set; }
        public string hoten { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string sotk { get; set; }
        public string matkhau { get; set; }
        public string thoigiandk { get; set; }

		
		[DefaultValue(false)]
		public bool? IsCustomer { get; set; }
		[DefaultValue(false)]
		public bool? IsMerchant { get; set; }
		[DefaultValue(false)]
		public bool? IsWebmaster { get; set; }

		public virtual Khachhang KhachhangNavigation { get; set; }
		public virtual Ncc NccNavigation { get; set; }
		public virtual Webmaster WebmasterNavigation { get; set; }


		public virtual ICollection<Hoadonmuatin> Hoadonmuatins { get; set; }
		public virtual ICollection<Hoadon> Hoadons { get; set; }
		public virtual Giohang GiohangNavigation { get; set; }


	}
}
