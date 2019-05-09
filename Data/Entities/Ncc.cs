using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Ncc
    {
		public int User_FK { get; set; } // PK
		public string tenncc { get; set; }
        public string gioithieu { get; set; }
        public int sltinton { get; set; }

		public virtual ICollection<Hoadonmuatin> Hoadonmuatins { get; set; }
		public virtual TaiKhoan TaiKhoanBy { get; set; }
    }
}
