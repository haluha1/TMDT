using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Khachhang
    {
		public int User_FK { get; set; } // PK
		public string makh { get; set; }
		
		public virtual TaiKhoan TaiKhoanBy { get; set; }
		public virtual ICollection<CtRating> CtRatings { get; set; }

	}
}
