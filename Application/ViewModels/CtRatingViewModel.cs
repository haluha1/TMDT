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
		public int RatingFK { get; set; }
		public int makh { get; set; }
		public float diem { get; set; }
		public string comment { get; set; }
		public virtual RatingViewModel RatingNavigation { get; set; }
		public virtual KhachhangViewModel KhachhangNavigation { get; set; }
	}
}
