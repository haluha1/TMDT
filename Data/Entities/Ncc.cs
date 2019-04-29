using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Ncc : DomainEntity<int>
    {
        public string tenncc { get; set; }
        public string gioithieu { get; set; }
        public int sltinton { get; set; }
		public int User_FK { get; set; }
		public virtual TaiKhoan TaiKhoanBy { get; set; }
    }
}
