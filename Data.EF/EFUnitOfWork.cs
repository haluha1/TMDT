using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
	public class EFUnitOfWork : IUnitOfWork
	{
		private readonly PhukienDTDbContext _context;
		public EFUnitOfWork(PhukienDTDbContext context)
		{
			_context = context;
		}
		public bool Commit()
		{
			try
			{
				_context.SaveChanges();
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
			_context.Dispose();
		}

		//public void RegisterAmended(Infrastructure.SharedKernel.DomainEntity<T> entity, IUnitOfWorkRepository<T> repository)
		//{
		//	repository.PersistUpdateOf(entity);
		//}

		//public void RegisterNew(Infrastructure.SharedKernel.DomainEntity<T> entity, IUnitOfWorkRepository<T> repository)
		//{
		//	repository.PersistCreationOf(entity);
		//}

		//public void RegisterRemoved(Infrastructure.SharedKernel.DomainEntity<T> entity, IUnitOfWorkRepository<T> repository)
		//{
		//	repository.PersistDeletionOf(entity);
		//}
	}
}
