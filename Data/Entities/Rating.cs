using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Rating : DomainEntity<int>
    {
        public int marating { get; set; }
        public int soluongrate { get; set; }
        public float diemtb { get; set; }
    }
}
