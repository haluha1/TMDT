﻿using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Giatin : DomainEntity<int>
    {
		public Giatin()
		{
			Hoadonmuatins = new HashSet<Hoadonmuatin>();
		}

		public int magiatin { get; set; }
        public int soluongtin { get; set; }
        public double gia { get; set; }
		public virtual ICollection<Hoadonmuatin> Hoadonmuatins { get; set; }

	}
}
