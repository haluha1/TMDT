using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Mucduytri : DomainEntity<int>
    {
        public int mamuc { get; set; }
        public double dieukien { get; set; }
        public int thuong { get; set; }
    }
}
