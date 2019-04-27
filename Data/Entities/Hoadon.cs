using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Hoadon : DomainEntity<int>
    {
        public Hoadon()
        {
            Cthdon = new HashSet<Cthd>();
        }

        public int mahd { get; set; }
        public int makh { get; set; }
        public double tongtien { get; set; }
        public string thoigian { get; set; }
        public ICollection<Cthd> Cthdon { get; set; }
    }
}
