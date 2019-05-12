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
		public RatingViewModel(ICollection<CtRatingViewModel> ctRatings)
		{
			CtRatings = ctRatings;
		}

		public int soluongrate { get { return CtRatings.Count; } }
		public float diemtb { get {
				float tb = 0;
				foreach(CtRatingViewModel item in CtRatings)
				{
					tb += item.diem;
				}
				return tb/soluongrate; } }
		public RatingType RatingFor { get; set; }
		public virtual ICollection<CtRatingViewModel> CtRatings { get; set; }
	}
}
