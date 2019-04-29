using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class RatingNccViewModel
	{
		public int KeyId { get; set; }
		public int mancc { get; set; }
		public int Rating_FK { get; set; }

		public virtual RatingViewModel RatingBy { get; set; }
	}
}
