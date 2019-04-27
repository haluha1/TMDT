﻿using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RatingNcc : DomainEntity<int>
    {
        public int mancc { get; set; }

        public virtual Rating RatingBy { get; set; }
    }
}
