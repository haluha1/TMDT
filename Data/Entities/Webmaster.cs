using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Webmaster
    {
		public int User_FK { get; set; } // PK
		public string WebmasterID { get; set; }
		
		public virtual TaiKhoan TaiKhoanBy { get; set; }
    }
}
