
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
		static PhukienDTDbContext()
		{
			Database.SetInitializer<PhukienDTDbContext>(null);
		}
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
			//Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhukienDTDbContext, Configuration>());
		}
		#region creare DbSet
		//public DbSet<Student> Students { get; set; }
		#endregion
		public DbSet<Cthd> Cthds { get; set; }
		public DbSet<CtRating> CtRatings { get; set; }
		public DbSet<Giatin> Giatins { get; set; }
		public DbSet<CtGiohang> CtGiohangs { get; set; }
		public DbSet<Giohang> Giohangs { get; set; }
		public DbSet<Hoadon> Hoadons { get; set; }
		public DbSet<Hoadonmuatin> Hoadonmuatins { get; set; }
		public DbSet<Khachhang> Khachhangs { get; set; }
		public DbSet<Loaisp> Loaisps { get; set; }
		public DbSet<Mucduytri> Mucduytris { get; set; }
		public DbSet<Ncc> Nccs { get; set; }
		
		public DbSet<Sanpham> Sanphams { get; set; }
		public DbSet<TaiKhoan> TaiKhoans { get; set; }
		public DbSet<Webmaster> Webmasters { get; set; }

		public DbSet<Function> Functions { get; set; }





		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

			modelBuilder.Entity<Cthd>().HasKey(e => e.KeyId).ToTable("CTHD");
			modelBuilder.Entity<Cthd>()
			.HasRequired<Hoadon>(s => s.HoadonNavigation)
			.WithMany(g => g.Cthdons)
			.HasForeignKey<int>(s => s.mahd);
			modelBuilder.Entity<Cthd>()
			.HasRequired<Sanpham>(s => s.SanphamNavigation)
			.WithMany(g => g.Cthds)
			.HasForeignKey<int>(s => s.masp);

			modelBuilder.Entity<CtRating>().HasKey(e => e.KeyId).ToTable("CtRating");
			modelBuilder.Entity<CtRating>()
			.HasRequired<Khachhang>(s => s.KhachhangNavigation)
			.WithMany(g => g.CtRatings)
			.HasForeignKey<int>(s => s.makh);




			modelBuilder.Entity<Giatin>().HasKey(e => e.KeyId).ToTable("GiaTin");

			modelBuilder.Entity<Giohang>().HasKey(e => e.KeyId).ToTable("GioHang");

			modelBuilder.Entity<CtGiohang>().HasKey(e => e.KeyId).ToTable("CtGioHang");
			modelBuilder.Entity<CtGiohang>()
			.HasRequired<Giohang>(s => s.GiohangNavigation)
			.WithMany(g => g.CtGiohangs)
			.HasForeignKey<int>(s => s.Giohang_FK);

			modelBuilder.Entity<CtGiohang>()
			.HasRequired<Sanpham>(s => s.SanphamNavigation)
			.WithMany(g => g.CtGiohangs)
			.HasForeignKey<int>(s => s.masp);


			modelBuilder.Entity<Hoadon>().HasKey(e => e.KeyId).ToTable("HoaDon");
			modelBuilder.Entity<Hoadon>()
			.HasRequired<Khachhang>(s => s.KhachHangNavigation)
			.WithMany(g => g.Hoadons)
			.HasForeignKey<int>(s => s.makh);

			modelBuilder.Entity<Hoadonmuatin>().HasKey(e => e.KeyId).ToTable("HoaDonMuaTin");
			modelBuilder.Entity<Hoadonmuatin>()
			.HasRequired<Giatin>(s => s.GiatinNavigation)
			.WithMany(g => g.Hoadonmuatins)
			.HasForeignKey<int>(s => s.magiatin);

			modelBuilder.Entity<Hoadonmuatin>()
			.HasRequired<Ncc>(s => s.NccNavigation)
			.WithMany(g => g.Hoadonmuatins)
			.HasForeignKey<int>(s => s.mancc);

			modelBuilder.Entity<Khachhang>().HasKey(e => e.User_FK).ToTable("KhachHang");
			modelBuilder.Entity<Khachhang>()
							.HasOptional(s => s.GiohangNavigation) // Mark Address property optional in Student entity
							.WithRequired(ad => ad.KhachHangBy);

			modelBuilder.Entity<Loaisp>().HasKey(e => e.KeyId).ToTable("LoaiSP");
			modelBuilder.Entity<Mucduytri>().HasKey(e => e.KeyId).ToTable("MucDuyTri");
			modelBuilder.Entity<Ncc>().HasKey(e => e.User_FK).ToTable("Ncc");
			
			

			modelBuilder.Entity<Sanpham>().HasKey(e => e.KeyId).ToTable("SanPham");

			modelBuilder.Entity<Sanpham>()
			.HasRequired<Loaisp>(s => s.LoaispNavigation)
			.WithMany(g => g.Sanphams)
			.HasForeignKey<int>(s => s.maloai);

			modelBuilder.Entity<Sanpham>()
			.HasMany<Khachhang>(s => s.KhachHangYeuThichs)
			.WithMany(g => g.SanPhamYeuThichs)
			.Map(cs =>
			{
				cs.MapLeftKey("SanPhamYeuThichRefId");
				cs.MapRightKey("KhachHangRefId");
				cs.ToTable("SanPhamYeuThich_KhachHang");
			});

			

			modelBuilder.Entity<TaiKhoan>().HasKey(e => e.KeyId).ToTable("TaiKhoan");
			modelBuilder.Entity<TaiKhoan>()
							.HasOptional(s => s.KhachhangNavigation) // Mark Address property optional in Student entity
							.WithRequired(ad => ad.TaiKhoanBy);
			modelBuilder.Entity<TaiKhoan>()
							.HasOptional(s => s.NccNavigation) // Mark Address property optional in Student entity
							.WithRequired(ad => ad.TaiKhoanBy);
			modelBuilder.Entity<TaiKhoan>()
							.HasOptional(s => s.WebmasterNavigation) // Mark Address property optional in Student entity
							.WithRequired(ad => ad.TaiKhoanBy);





			modelBuilder.Entity<Webmaster>().HasKey(e => e.User_FK).ToTable("WebMaster");
			base.OnModelCreating(modelBuilder);
		}
	}
}
