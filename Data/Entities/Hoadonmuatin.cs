using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Hoadonmuatin : DomainEntity<int>
    {
        public int mahd { get; set; }
        public int mancc { get; set; }
        public int magiatin { get; set; }
        public string thoigian { get; set; }
		public virtual Giatin GiatinNavigation { get; set; }
		public virtual TaiKhoan TaiKhoanNavigation { get; set; }

	}
}
