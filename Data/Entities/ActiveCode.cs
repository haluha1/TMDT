using Data.Enum;
using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
	public class ActiveCode : DomainEntity<int>
	{
		public int User_FK { get; set; }
		public string code { get; set; }
		public DateTime DateCreate { get; set; }
		public CodeType CodeType { get; set; }
		public CodeStatus CodeStatus { get; set; }


	}
}
