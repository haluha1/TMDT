using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class TaiKhoan : DomainEntity<int>
    {
        public int matk { get; set; }
        public string hoten { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public string sotk { get; set; }
        public string matkhau { get; set; }
        public string thoigiandk { get; set; }
    }
}
