using Data.Enum;
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
		public TaiKhoan()
		{
		}

		public TaiKhoan(int keyId, int matk, string hoten, string email, string diachi, string sdt, string sotk, string matkhau, string thoigiandk, string avatar, UserType userType)
		{
			KeyId = keyId;
			this.matk = matk;
			this.hoten = hoten;
			this.email = email;
			this.diachi = diachi;
			this.sdt = sdt;
			this.sotk = sotk;
			this.matkhau = matkhau;
			this.thoigiandk = thoigiandk;
			this.avatar = avatar;
			UserType = userType;
		}

		public int matk { get; set; }
        public string hoten { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string sotk { get; set; }
        public string matkhau { get; set; }
        public string thoigiandk { get; set; }

		public string avatar { get; set; }

		public UserType UserType { get; set; }

        public virtual Khachhang KhachhangNavigation { get; set; }
		public virtual Ncc NccNavigation { get; set; }
		public virtual Webmaster WebmasterNavigation { get; set; }


		
		
		


	}
}
