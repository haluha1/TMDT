using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class HoadonViewModel
	{
		public int KeyId { get; set; }
		public int mahd { get; set; }
		public int makh { get; set; }
		public int ncc_FK { get; set; }
		public double tongtien { get; set; }
		public string thoigian { get; set; }
        public string tinhtrang { get; set; }

		public string Name { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string Note { get; set; }

		public ICollection<CthdViewModel> Cthdons { get; set; }
		public virtual KhachhangViewModel KhachHangNavigation { get; set; }
		public virtual NccViewModel NccNavigation { get; set; }
	}
}
