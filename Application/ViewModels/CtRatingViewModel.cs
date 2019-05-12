using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class CtRatingViewModel
	{
		public int KeyId { get; set; }
		
		public int makh { get; set; }
		public float diem { get; set; }
		public string comment { get; set; }
		public RatingType RatingFor { get; set; }
		public int? mancc { get; set; }
		public int? masp { get; set; }

		public virtual KhachhangViewModel KhachhangNavigation { get; set; }
	}
}
