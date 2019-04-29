using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class GiatinViewModel
	{
		public int KeyId { get; set; }
		public int magiatin { get; set; }
		public int soluongtin { get; set; }
		public double gia { get; set; }
		public virtual ICollection<HoadonmuatinViewModel> Hoadonmuatins { get; set; }
	}
}
