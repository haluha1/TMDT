using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
	public class EFUnitOfWork<T> : IUnitOfWork<T>
	{
		public bool Commit()
		{
			try
			{
				PhukienDTDbContext.Instance.SaveChanges();
				return true;
			}
			catch (Exception ex)
			{
				//try
				//{
				//    // lưu lại log lỗi
				//    string file = $@"\Logs_test_102";
				//    string filePath = _hostingEnvironment.WebRootPath + file;

				//    if (!Directory.Exists(filePath))
				//    {
				//        Directory.CreateDirectory(filePath);
				//    }
				//    filePath += $@"\ErrorSaveDataToDB.txt";
				//    using (StreamWriter writer = new StreamWriter(filePath, true))
				//    {
				//        writer.WriteLine("-----------------------------------------------------------------------------");
				//        writer.WriteLine("Date : " + DateTime.Now.ToString());
				//        writer.WriteLine();
				//        while (ex != null)
				//        {
				//            writer.WriteLine(ex.GetType().FullName);
				//            writer.WriteLine("Message : " + ex.Message);
				//            writer.WriteLine("StackTrace : " + ex.StackTrace);
				//            ex = ex.InnerException;
				//        }
				//    }
				//}
				//catch { }
				return false;
			}
		}

		public void Dispose()
		{
			PhukienDTDbContext.Instance.Dispose();
		}

		public void RegisterAmended(Infrastructure.SharedKernel.DomainEntity<T> entity, IUnitOfWorkRepository<T> repository)
		{
			repository.PersistUpdateOf(entity);
		}

		public void RegisterNew(Infrastructure.SharedKernel.DomainEntity<T> entity, IUnitOfWorkRepository<T> repository)
		{
			repository.PersistCreationOf(entity);
		}

		public void RegisterRemoved(Infrastructure.SharedKernel.DomainEntity<T> entity, IUnitOfWorkRepository<T> repository)
		{
			repository.PersistDeletionOf(entity);
		}
	}
}
