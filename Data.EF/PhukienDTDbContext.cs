using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
	public class PhukienDTDbContext : DbContext
	{
		private static PhukienDTDbContext _context;
		public static PhukienDTDbContext Instance
		{
			get
			{
				if (_context == null)
				{
					_context = new PhukienDTDbContext();
				}
				return _context;
			}
		}
		public PhukienDTDbContext() : base("PhukienDTDbContext")
		{

		}
		#region creare DbSet
		//public DbSet<Student> Students { get; set; }
		#endregion
		public DbSet<Student> Students { get; set; }
		public DbSet<Enrollment> Enrollments { get; set; }
		public DbSet<Course> Courses { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			//modelBuilder.Entity<ArAccountsReceivable>(entity =>
			//{
			//	entity.HasKey(e => e.KeyId);

			//	entity.ToTable("AR_AccountsReceivable");

			//	entity.HasIndex(e => e.ProjectId)
			//		.HasName("IX_ProjectId");

			//	// entity.Property(e => e.Amount).HasColumnType("decimal(65,30)");

			//	entity.Property(e => e.ArNo)
			//		.HasColumnName("AR_No")
			//		.HasMaxLength(15)
			//		.IsUnicode(false);

			//	entity.Property(e => e.CustomerFk).HasColumnName("Customer_FK");

			//	entity.Property(e => e.Department)
			//		.HasMaxLength(15)
			//		.IsUnicode(false);

			//	entity.Property(e => e.Description).HasMaxLength(255);

			//	entity.Property(e => e.PoNo).HasColumnName("PO_No");

			//	entity.Property(e => e.RecordCode)
			//		.HasColumnName("Record_Code")
			//		.HasColumnType("char(2)");

			//	entity.Property(e => e.TransactNo).HasColumnName("Transact_No");

			//	entity.Property(e => e.WarehouseFk)
			//		.HasColumnName("Warehouse_FK")
			//		.HasMaxLength(15)
			//		.IsUnicode(false);

			//	entity.HasOne(d => d.Project)
			//		.WithMany(p => p.ArAccountsReceivable)
			//		.HasForeignKey(d => d.ProjectId)
			//		.HasConstraintName("FK_dbo.AR_AccountsReceivable_dbo.GNProject_ProjectId");
			//});
		}
	}
}
