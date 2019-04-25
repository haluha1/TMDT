using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SharedKernel
{
	public abstract class DomainEntity<T>
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public T KeyId { get; set; }

		/// <summary>
		/// True if domain entity has an identity
		/// </summary>
		/// <returns></returns>
		public bool IsTransient()
		{
			return KeyId.Equals(default(T));
		}
	}
}
