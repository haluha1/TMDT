using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Loaisp : DomainEntity<int>
    {
        public int maloai { get; set; }
        public string tenloai { get; set; }
    }
}
