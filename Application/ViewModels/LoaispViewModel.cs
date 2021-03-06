﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class LoaispViewModel
	{
		public int KeyId { get; set; }
		public int maloai { get; set; }
		[Display(Name = "tên loại")]
		public string tenloai { get; set; }
		public virtual ICollection<SanphamViewModel> Sanphams { get; set; }
	}
}
