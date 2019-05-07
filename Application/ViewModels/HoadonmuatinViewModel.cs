using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class HoadonmuatinViewModel
	{
		public int KeyId { get; set; }
		public int mahd { get; set; }
		public int mancc { get; set; }
		public int magiatin { get; set; }
		public string thoigian { get; set; }
		public virtual GiatinViewModel GiatinNavigation { get; set; }
		public virtual NccViewModel NccNavigation { get; set; }
	}
}
