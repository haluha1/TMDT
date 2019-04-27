using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Khachhang : DomainEntity<int>
    {
        public virtual TaiKhoan TaiKhoanBy { get; set; }
    }
}
