using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
	public interface IUnitOfWork
	{
		/// <summary>
		/// Call save change from db context,  Nó đảm bảo sự toàn vẹn của các kết nối.
		/// </summary>
		bool Commit();
		//void RegisterNew(DomainEntity<T> entity, IUnitOfWorkRepository<T> repository);
		//void RegisterAmended(DomainEntity<T> entity, IUnitOfWorkRepository<T> repository);
		//void RegisterRemoved(DomainEntity<T> entity, IUnitOfWorkRepository<T> repository);
	}
}
