using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Ncc
    {
		public Ncc()
		{
			Hoadonmuatins = new HashSet<Hoadonmuatin>();
			Sanphams = new HashSet<Sanpham>();
			Hoadons = new HashSet<Hoadon>();
		}

		public int User_FK { get; set; } // PK
		public string tenncc { get; set; }
        public string gioithieu { get; set; }
		[DefaultValue(0)]
		public int sltinton { get; set; }

		public virtual ICollection<Hoadon> Hoadons { get; set; }
		public virtual ICollection<Sanpham> Sanphams { get; set; }
		public virtual ICollection<Hoadonmuatin> Hoadonmuatins { get; set; }
		public virtual TaiKhoan TaiKhoanBy { get; set; }
    }
}
