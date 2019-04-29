using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class RatingViewModel
	{
		public int KeyId { get; set; }
		public int marating { get; set; }
		public int soluongrate { get; set; }
		public float diemtb { get; set; }
		public RatingType RatingFor { get; set; }
		public virtual RatingSpViewModel RatingSpNavigation { get; set; }
		public virtual RatingNccViewModel RatingNccNavigation { get; set; }
		public virtual ICollection<CtRatingViewModel> CtRatings { get; set; }
	}
}
