using Data.Enum;
using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CtRating : DomainEntity<int>
    {
        
        public int makh { get; set; }
        public float diem { get; set; }
        public string comment { get; set; }

		public RatingType RatingFor { get; set; }
		public int? mancc { get; set; }
		public int? masp { get; set; }

		public virtual Khachhang KhachhangNavigation { get; set; }
		


	}
}
