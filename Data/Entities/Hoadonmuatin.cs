using Data.Enum;
using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		[DefaultValue(PostInvoiceStatus.Processing)]
		public PostInvoiceStatus Status { get; set; }
		public virtual Giatin GiatinNavigation { get; set; }
		public virtual Ncc NccNavigation { get; set; }

	}
}
