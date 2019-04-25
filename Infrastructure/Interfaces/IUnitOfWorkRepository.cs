using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IUnitOfWorkRepository<T>
	{
		void PersistCreationOf(DomainEntity<T> entity);
		void PersistUpdateOf(DomainEntity<T> entity);
		void PersistDeletionOf(DomainEntity<T> entity);
	}
}
