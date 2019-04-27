﻿using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Giohang : DomainEntity<int>
    {
        public int makh { get; set; }
        public int masp { get; set; }
        public int soluong { get; set; }
        public double thanhtien { get; set; }
    }
}