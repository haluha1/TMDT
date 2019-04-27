using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CtRating : DomainEntity<int>
    {
        public int marating { get; set; }
        public int makh { get; set; }
        public float diem { get; set; }
        public string comment { get; set; }
    }
}
