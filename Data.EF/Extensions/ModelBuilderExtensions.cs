//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Data.EF.Extensions
//{
//	public static class ModelBuilderExtensions
//	{
//		public static void AddConfiguration<TEntity>(
//		  this DbModelBuilder modelBuilder,
//		  DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
//		{
//			modelBuilder.Entity<TEntity>(entityConfiguration.Configure);
//		}
//	}

//	public abstract class DbEntityConfiguration<TEntity> where TEntity : class
//	{
//		public abstract void Configure(EntityTypeBuilder<TEntity> entity);
//	}
//}
