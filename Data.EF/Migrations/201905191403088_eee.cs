namespace Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActiveCode",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        User_FK = c.Int(nullable: false),
                        code = c.String(),
                        DateCreate = c.DateTime(nullable: false),
                        CodeType = c.Int(nullable: false),
                        CodeStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.CtGioHang",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        masp = c.Int(nullable: false),
                        User_FK = c.Int(nullable: false),
                        soluong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId)
                .ForeignKey("dbo.KhachHang", t => t.User_FK, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.masp, cascadeDelete: true)
                .Index(t => t.masp)
                .Index(t => t.User_FK);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        User_FK = c.Int(nullable: false),
                        makh = c.String(),
                    })
                .PrimaryKey(t => t.User_FK)
                .ForeignKey("dbo.TaiKhoan", t => t.User_FK)
                .Index(t => t.User_FK);
            
            CreateTable(
                "dbo.CtRating",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        makh = c.Int(nullable: false),
                        diem = c.Single(nullable: false),
                        comment = c.String(),
                        RatingFor = c.Int(nullable: false),
                        mancc = c.Int(),
                        masp = c.Int(),
                    })
                .PrimaryKey(t => t.KeyId)
                .ForeignKey("dbo.KhachHang", t => t.makh, cascadeDelete: true)
                .Index(t => t.makh);
            
            CreateTable(
                "dbo.HoaDon",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        mahd = c.Int(nullable: false),
                        makh = c.Int(nullable: false),
                        ncc_FK = c.Int(nullable: false),
                        tongtien = c.Double(nullable: false),
                        thoigian = c.String(),
                        tinhtrang = c.String(),
                        Name = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Note = c.String(),
                        NccNavigation_User_FK = c.Int(),
                    })
                .PrimaryKey(t => t.KeyId)
                .ForeignKey("dbo.Ncc", t => t.NccNavigation_User_FK)
                .ForeignKey("dbo.KhachHang", t => t.makh, cascadeDelete: true)
                .Index(t => t.makh)
                .Index(t => t.NccNavigation_User_FK);
            
            CreateTable(
                "dbo.CTHD",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        mahd = c.Int(nullable: false),
                        masp = c.Int(nullable: false),
                        soluong = c.Int(nullable: false),
                        thanhtien = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId)
                .ForeignKey("dbo.HoaDon", t => t.mahd, cascadeDelete: true)
                .ForeignKey("dbo.SanPham", t => t.masp, cascadeDelete: true)
                .Index(t => t.mahd)
                .Index(t => t.masp);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        masp = c.String(),
                        tensp = c.String(),
                        maloai = c.Int(nullable: false),
                        mancc = c.Int(nullable: false),
                        dongia = c.Double(nullable: false),
                        soluong = c.Int(nullable: false),
                        conlai = c.Int(nullable: false),
                        mota = c.String(),
                        tenhinh = c.String(),
                        khuyenmai = c.Single(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId)
                .ForeignKey("dbo.LoaiSP", t => t.maloai, cascadeDelete: true)
                .ForeignKey("dbo.Ncc", t => t.mancc, cascadeDelete: true)
                .Index(t => t.maloai)
                .Index(t => t.mancc);
            
            CreateTable(
                "dbo.LoaiSP",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        maloai = c.Int(nullable: false),
                        tenloai = c.String(),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.Ncc",
                c => new
                    {
                        User_FK = c.Int(nullable: false),
                        tenncc = c.String(),
                        gioithieu = c.String(),
                        sltinton = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.User_FK)
                .ForeignKey("dbo.TaiKhoan", t => t.User_FK)
                .Index(t => t.User_FK);
            
            CreateTable(
                "dbo.HoaDonMuaTin",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        mahd = c.Int(nullable: false),
                        mancc = c.Int(nullable: false),
                        magiatin = c.Int(nullable: false),
                        thoigian = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId)
                .ForeignKey("dbo.GiaTin", t => t.magiatin, cascadeDelete: true)
                .ForeignKey("dbo.Ncc", t => t.mancc, cascadeDelete: true)
                .Index(t => t.mancc)
                .Index(t => t.magiatin);
            
            CreateTable(
                "dbo.GiaTin",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        magiatin = c.Int(nullable: false),
                        soluongtin = c.Int(nullable: false),
                        gia = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.TaiKhoan",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        matk = c.Int(nullable: false),
                        hoten = c.String(),
                        email = c.String(),
                        diachi = c.String(),
                        sdt = c.String(),
                        sotk = c.String(),
                        matkhau = c.String(),
                        thoigiandk = c.String(),
                        avatar = c.String(),
                        UserType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.WebMaster",
                c => new
                    {
                        User_FK = c.Int(nullable: false),
                        WebmasterID = c.String(),
                    })
                .PrimaryKey(t => t.User_FK)
                .ForeignKey("dbo.TaiKhoan", t => t.User_FK)
                .Index(t => t.User_FK);
            
            CreateTable(
                "dbo.Functions",
                c => new
                    {
                        KeyId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 128),
                        URL = c.String(nullable: false, maxLength: 250),
                        ParentId = c.String(maxLength: 128),
                        IconCss = c.String(),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.MucDuyTri",
                c => new
                    {
                        KeyId = c.Int(nullable: false, identity: true),
                        mamuc = c.Int(nullable: false),
                        dieukien = c.Double(nullable: false),
                        thuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeyId);
            
            CreateTable(
                "dbo.SanPhamYeuThich_KhachHang",
                c => new
                    {
                        SanPhamYeuThichRefId = c.Int(nullable: false),
                        KhachHangRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SanPhamYeuThichRefId, t.KhachHangRefId })
                .ForeignKey("dbo.SanPham", t => t.SanPhamYeuThichRefId, cascadeDelete: true)
                .ForeignKey("dbo.KhachHang", t => t.KhachHangRefId, cascadeDelete: true)
                .Index(t => t.SanPhamYeuThichRefId)
                .Index(t => t.KhachHangRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CtGioHang", "masp", "dbo.SanPham");
            DropForeignKey("dbo.CtGioHang", "User_FK", "dbo.KhachHang");
            DropForeignKey("dbo.HoaDon", "makh", "dbo.KhachHang");
            DropForeignKey("dbo.CTHD", "masp", "dbo.SanPham");
            DropForeignKey("dbo.SanPham", "mancc", "dbo.Ncc");
            DropForeignKey("dbo.WebMaster", "User_FK", "dbo.TaiKhoan");
            DropForeignKey("dbo.Ncc", "User_FK", "dbo.TaiKhoan");
            DropForeignKey("dbo.KhachHang", "User_FK", "dbo.TaiKhoan");
            DropForeignKey("dbo.HoaDon", "NccNavigation_User_FK", "dbo.Ncc");
            DropForeignKey("dbo.HoaDonMuaTin", "mancc", "dbo.Ncc");
            DropForeignKey("dbo.HoaDonMuaTin", "magiatin", "dbo.GiaTin");
            DropForeignKey("dbo.SanPham", "maloai", "dbo.LoaiSP");
            DropForeignKey("dbo.SanPhamYeuThich_KhachHang", "KhachHangRefId", "dbo.KhachHang");
            DropForeignKey("dbo.SanPhamYeuThich_KhachHang", "SanPhamYeuThichRefId", "dbo.SanPham");
            DropForeignKey("dbo.CTHD", "mahd", "dbo.HoaDon");
            DropForeignKey("dbo.CtRating", "makh", "dbo.KhachHang");
            DropIndex("dbo.SanPhamYeuThich_KhachHang", new[] { "KhachHangRefId" });
            DropIndex("dbo.SanPhamYeuThich_KhachHang", new[] { "SanPhamYeuThichRefId" });
            DropIndex("dbo.WebMaster", new[] { "User_FK" });
            DropIndex("dbo.HoaDonMuaTin", new[] { "magiatin" });
            DropIndex("dbo.HoaDonMuaTin", new[] { "mancc" });
            DropIndex("dbo.Ncc", new[] { "User_FK" });
            DropIndex("dbo.SanPham", new[] { "mancc" });
            DropIndex("dbo.SanPham", new[] { "maloai" });
            DropIndex("dbo.CTHD", new[] { "masp" });
            DropIndex("dbo.CTHD", new[] { "mahd" });
            DropIndex("dbo.HoaDon", new[] { "NccNavigation_User_FK" });
            DropIndex("dbo.HoaDon", new[] { "makh" });
            DropIndex("dbo.CtRating", new[] { "makh" });
            DropIndex("dbo.KhachHang", new[] { "User_FK" });
            DropIndex("dbo.CtGioHang", new[] { "User_FK" });
            DropIndex("dbo.CtGioHang", new[] { "masp" });
            DropTable("dbo.SanPhamYeuThich_KhachHang");
            DropTable("dbo.MucDuyTri");
            DropTable("dbo.Functions");
            DropTable("dbo.WebMaster");
            DropTable("dbo.TaiKhoan");
            DropTable("dbo.GiaTin");
            DropTable("dbo.HoaDonMuaTin");
            DropTable("dbo.Ncc");
            DropTable("dbo.LoaiSP");
            DropTable("dbo.SanPham");
            DropTable("dbo.CTHD");
            DropTable("dbo.HoaDon");
            DropTable("dbo.CtRating");
            DropTable("dbo.KhachHang");
            DropTable("dbo.CtGioHang");
            DropTable("dbo.ActiveCode");
        }
    }
}
