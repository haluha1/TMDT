using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class RatingSpViewModel
	{
		public int KeyId { get; set; }
		public int masp { get; set; }
		public int Rating_FK { get; set; }

		public virtual RatingViewModel RatingBy { get; set; }
	}
}
