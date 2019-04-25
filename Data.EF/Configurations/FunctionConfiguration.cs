//using Data.EF.Extensions;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Data.EF.Configurations
//{
//	public class FunctionConfiguration : DbEntityConfiguration<Function>
//	{
//		public override void Configure(EntityTypeBuilder<Function> entity)
//		{
//			entity.HasKey(c => c.KeyId);
//			entity.Property(c => c.KeyId).IsRequired()
//			.HasColumnType("varchar(128)");
//			// etc.
//		}

//	}
//}
