using Data.Enum;
using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Rating : DomainEntity<int>
    {
		//public Rating()
		//{
		//}

		//public Rating(int keyId, int marating, int soluongrate, float diemtb, RatingType ratingFor)
		//{
		//	KeyId = keyId;
		//	this.marating = marating;
		//	this.soluongrate = soluongrate;
		//	this.diemtb = diemtb;
		//	RatingFor = ratingFor;
		//}

		public int marating { get; set; }
        public int soluongrate { get; set; }
        public float diemtb { get; set; }
		public RatingType RatingFor { get; set; }
		public virtual RatingSp RatingSpNavigation { get; set; }
		public virtual RatingNcc RatingNccNavigation { get; set; }
		public virtual ICollection<CtRating> CtRatings { get; set; }


	}
}
