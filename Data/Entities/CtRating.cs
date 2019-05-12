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
		public CtRating()
		{
		}

		public CtRating(int keyId, int makh, float diem, string comment, RatingType ratingFor, int? mancc, int? masp)
		{
			KeyId = keyId;
			this.makh = makh;
			this.diem = diem;
			this.comment = comment;
			RatingFor = ratingFor;
			this.mancc = mancc;
			this.masp = masp;
		}

		public int makh { get; set; }
        public float diem { get; set; }
        public string comment { get; set; }

		public RatingType RatingFor { get; set; }
		public int? mancc { get; set; }
		public int? masp { get; set; }

		public virtual Khachhang KhachhangNavigation { get; set; }
		


	}
}
