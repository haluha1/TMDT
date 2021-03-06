﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class CthdViewModel
	{
		public int KeyId { get; set; }
		public int mahd { get; set; }
		public int masp { get; set; }
		public int soluong { get; set; }
		public double thanhtien { get; set; }
		public virtual SanphamViewModel SanphamNavigation { get; set; }
		public virtual HoadonViewModel HoadonNavigation { get; set; }
	}
}
