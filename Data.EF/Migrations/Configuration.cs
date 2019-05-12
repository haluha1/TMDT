﻿namespace Data.EF.Migrations
{
<<<<<<< HEAD
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
=======
	using Data.Entities;
	using Data.Enum;
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
>>>>>>> 9b06fd4ba401c8d3416cc9925bd2a8636cffb683
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Data.Entities;
    using Data.Enum;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.EF.PhukienDTDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.EF.PhukienDTDbContext context)
        {

<<<<<<< HEAD
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            //Loại sản phẩm
            var loaisps = new List<Loaisp>
            {
            new Loaisp{maloai=1,tenloai="Ốp lưng"},
            new Loaisp{maloai=2,tenloai="Bao Airpod"},
            new Loaisp{maloai=3,tenloai="Ring- Bóp"},
            new Loaisp{maloai=3,tenloai="Khác"}
            };
            loaisps.ForEach(s => context.Loaisps.AddOrUpdate(s));
            context.SaveChanges();

            //Tài khoản
            var taikhoans = new List<TaiKhoan>
            {
            new TaiKhoan{matk=1,hoten="Nguyễn Văn An", email="ann@gmail.com", diachi="123 An Dương Vương", sdt="0123456700", sotk="1111111111111", matkhau="123", thoigiandk="1/1/2019", avatar="", UserType=UserType.Merchant},
            new TaiKhoan{matk=2,hoten="Trần Ngọc Ngà", email="ngocnga@gmail.com", diachi="478 Lý Thái Tổ", sdt="0123456701", sotk="2222222222222", matkhau="123", thoigiandk="1/1/2019", avatar="", UserType=UserType.Webmaster},
            new TaiKhoan{matk=3,hoten="Lê Thị Mai", email="maile@gmail.com", diachi="333 Hai Bà Trưng", sdt="0123456702", sotk="3333333333333", matkhau="123", thoigiandk="1/1/2019", avatar="", UserType=UserType.Customer},
            };
            taikhoans.ForEach(s => context.TaiKhoans.AddOrUpdate(s));
            context.SaveChanges();

            //Nhà cung cấp
            var nccs = new List<Ncc>
            {
            new Ncc{tenncc="ABC", gioithieu="shop bán ốp", sltinton=3, User_FK=1}
            };
            nccs.ForEach(s => context.Nccs.AddOrUpdate(s));
            context.SaveChanges();

            //Webmaster
            var webmasters = new List<Webmaster>
            {
            new Webmaster{User_FK=2}
            };
            webmasters.ForEach(s => context.Webmasters.AddOrUpdate(s));
            context.SaveChanges();

            //Customer
            var khachhangs = new List<Khachhang>
            {
            new Khachhang{User_FK=3}
            };
            khachhangs.ForEach(s => context.Khachhangs.AddOrUpdate(s));
            context.SaveChanges();

            //Sản phẩm
            var sanphams = new List<Sanpham>
            {
                new Sanpham{masp="1",tensp="Ốp Chống Bẩn GIành Cho Iphone 6 6S - iphone 6/6s",maloai=1,mancc=1,dongia=49000,soluong=100,mota="ốp lưng iphone apple silicone case là là một sản phảm đột phá nhờ công nghệ chống bám bẩn bên ngoài và lớp nhung mềm mại bên trong. Bảo vệ chiếc iphone của bạn tránh bị trầy xước hoặc giảm thiểu tối đa lực tsac động, khi vô tình rơi rớt",tenhinh="1.png",khuyenmai=0},
                new Sanpham{masp="2",tensp="Ốp hoạt hình",maloai=1,mancc=1,dongia=40000,soluong=100,mota="Đây là sp thứ 2",tenhinh="2.png",khuyenmai=0},
                new Sanpham{masp="3",tensp="Ốp hình nước ngọt pepsi",maloai=1,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 3",tenhinh="3.png",khuyenmai=0},
                new Sanpham{masp="4",tensp="Ốp hình hàn quốc",maloai=1,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 4",tenhinh="4.png",khuyenmai=0},
                new Sanpham{masp="5",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="5.png",khuyenmai=0},
                new Sanpham{masp="6",tensp="Ốp hình hàn quốc",maloai=1,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="6.png",khuyenmai=0},
                new Sanpham{masp="7",tensp="Ốp thả tim",maloai=1,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="7.png",khuyenmai=0},
                new Sanpham{masp="8",tensp="Ốp hình Icebear",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="8.png",khuyenmai=0},
                new Sanpham{masp="9",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="9.png",khuyenmai=0},
                new Sanpham{masp="10",tensp="Ốp trơn",maloai=1,mancc=3,dongia=70000,soluong=100,mota="Đây là sp thứ 1",tenhinh="10.png",khuyenmai=0},
                new Sanpham{masp="11",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="11.png",khuyenmai=0},
                new Sanpham{masp="12",tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="12.png",khuyenmai=0},
                new Sanpham{masp="13",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=80000,soluong=100,mota="Đây là sp thứ 1",tenhinh="13.png",khuyenmai=0},
                new Sanpham{masp="14",tensp="Ốp trơn",maloai=1,mancc=2,dongia=19000,soluong=100,mota="Đây là sp thứ 1",tenhinh="14.png",khuyenmai=0},
                new Sanpham{masp="15",tensp="Ốp trơn",maloai=1,mancc=1,dongia=84000,soluong=100,mota="Đây là sp thứ 1",tenhinh="15.png",khuyenmai=0},
                new Sanpham{masp="16",tensp="Ốp họa tiết",maloai=1,mancc=3,dongia=30000,soluong=100,mota="Đây là sp thứ 1",tenhinh="16.png",khuyenmai=0},
                new Sanpham{masp="17",tensp="Ốp trơn",maloai=1,mancc=3,dongia=44000,soluong=100,mota="Đây là sp thứ 1",tenhinh="17.png",khuyenmai=0},
                new Sanpham{masp="18",tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=40000,soluong=100,mota="Đây là sp thứ 1",tenhinh="18.png",khuyenmai=0},
                new Sanpham{masp="19",tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="19.png",khuyenmai=0},
                new Sanpham{masp="20",tensp="Ốp trơn",maloai=1,mancc=2,dongia=25000,soluong=100,mota="Đây là sp thứ 1",tenhinh="20.png",khuyenmai=0},
                new Sanpham{masp="21",tensp="Ốp trơn",maloai=1,mancc=1,dongia=19000,soluong=100,mota="Đây là sp thứ 1",tenhinh="21.png",khuyenmai=0},
                new Sanpham{masp="22",tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="22.png",khuyenmai=0},
                new Sanpham{masp="23",tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="23.png",khuyenmai=0},
                new Sanpham{masp="24",tensp="Ốp trơn",maloai=1,mancc=2,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="24.png",khuyenmai=0},
                new Sanpham{masp="25",tensp="Ốp trơn",maloai=1,mancc=2,dongia=54000,soluong=100,mota="Đây là sp thứ 1",tenhinh="25.png",khuyenmai=0},
                new Sanpham{masp="26",tensp="Ốp trơn",maloai=1,mancc=1,dongia=54000,soluong=100,mota="Đây là sp thứ 1",tenhinh="26.png",khuyenmai=0},
                new Sanpham{masp="27",tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="27.png",khuyenmai=0},
                new Sanpham{masp="28",tensp="Ốp trơn",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="28.png",khuyenmai=0},
                new Sanpham{masp="29",tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="29.png",khuyenmai=0},
                new Sanpham{masp="30",tensp="Ốp trơn",maloai=1,mancc=3,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="30.png",khuyenmai=0},
                new Sanpham{masp="31",tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="31.png",khuyenmai=0},
                new Sanpham{masp="32",tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="32.png",khuyenmai=0},
                new Sanpham{masp="33",tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="33.png",khuyenmai=0},
                new Sanpham{masp="34",tensp="Ốp trơn",maloai=1,mancc=2,dongia=32000,soluong=100,mota="Đây là sp thứ 1",tenhinh="34.png",khuyenmai=0},
                new Sanpham{masp="35",tensp="Ốp trơn",maloai=1,mancc=2,dongia=22000,soluong=100,mota="Đây là sp thứ 1",tenhinh="35.png",khuyenmai=0},
                new Sanpham{masp="36",tensp="Ốp kính siêu nhân",maloai=1,mancc=3,dongia=66000,soluong=100,mota="Đây là sp thứ 1",tenhinh="36.png",khuyenmai=0},
                new Sanpham{masp="37",tensp="Ốp trơn",maloai=1,mancc=1,dongia=56000,soluong=100,mota="Đây là sp thứ 1",tenhinh="37.png",khuyenmai=0},
                new Sanpham{masp="38",tensp="Ốp trơn",maloai=1,mancc=1,dongia=65000,soluong=100,mota="Đây là sp thứ 1",tenhinh="38.png",khuyenmai=0},
                new Sanpham{masp="39",tensp="Ốp trơn",maloai=1,mancc=3,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="39.png",khuyenmai=0},
                new Sanpham{masp="40",tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="40.png",khuyenmai=0},
                new Sanpham{masp="41",tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="41.png",khuyenmai=0},
                new Sanpham{masp="42",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=85000,soluong=100,mota="Đây là sp thứ 1",tenhinh="42.png",khuyenmai=0},
                new Sanpham{masp="43",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="43.png",khuyenmai=0},
                new Sanpham{masp="44",tensp="Ốp hình hàn quốc",maloai=1,mancc=1,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="44.png",khuyenmai=0},
                new Sanpham{masp="45",tensp="Ốp hình hàn quốc",maloai=1,mancc=2,dongia=65000,soluong=100,mota="Đây là sp thứ 1",tenhinh="45.png",khuyenmai=0},
                new Sanpham{masp="46",tensp="Ốp hình hàn quốc",maloai=1,mancc=1,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="46.png",khuyenmai=0},
                new Sanpham{masp="47",tensp="Ốp kính siêu nhân",maloai=1,mancc=1,dongia=100000,soluong=100,mota="Đây là sp thứ 1",tenhinh="47.png",khuyenmai=0},
                new Sanpham{masp="48",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=90000,soluong=100,mota="Đây là sp thứ 1",tenhinh="48.png",khuyenmai=0},
                new Sanpham{masp="49",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="49.png",khuyenmai=0},
                new Sanpham{masp="50",tensp="Ốp nhám vô diện",maloai=1,mancc=1,dongia=70000,soluong=100,mota="Đây là sp thứ 1",tenhinh="50.png",khuyenmai=0},
                 new Sanpham{masp="r1",tensp="Ring Gấu Trúc ",maloai=3,mancc=1,dongia=90000,soluong=100,mota="Đây là sp thứ 1",tenhinh="r1.png",khuyenmai=0},
                new Sanpham{masp="r2",tensp="Ring Gà Con ",maloai=3,mancc=1,dongia=50000,soluong=100,mota="Đây là sp thứ 2",tenhinh="r2.png",khuyenmai=0},
                new Sanpham{masp="r3",tensp="Ring Gấu Đen Dễ Thương ",maloai=3,mancc=3,dongia=95000,soluong=100,mota="Đây là sp thứ 3",tenhinh="r3.png",khuyenmai=0},
                new Sanpham{masp="r4",tensp="Ring Gấu Hồng Kute ",maloai=3,mancc=1,dongia=80000,soluong=100,mota="Đây là sp thứ 4",tenhinh="r4.png",khuyenmai=0},
                new Sanpham{masp="r5",tensp="Ring Que Kem",maloai=3,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="r5.png",khuyenmai=0},
                new Sanpham{masp="r6",tensp="Ring Trái Tim ",maloai=3,mancc=1,dongia=50000,soluong=100,mota="Đây là sp thứ 6",tenhinh="r6.png",khuyenmai=0},
                new Sanpham{masp="r7",tensp="Ring Ốp La ",maloai=3,mancc=1,dongia=90000,soluong=100,mota="Đây là sp thứ 7",tenhinh="r7.png",khuyenmai=0},
                new Sanpham{masp="r8",tensp="Ring Shin Bút Chì ",maloai=3,mancc=2,dongia=100000,soluong=100,mota="Đây là sp thứ 8",tenhinh="r8.png",khuyenmai=0},
                new Sanpham{masp="r9",tensp="Ring Gấu Trắng  ",maloai=3,mancc=2,dongia=94000,soluong=100,mota="Đây là sp thứ 1",tenhinh="r9.png",khuyenmai=0},
                new Sanpham{masp="r10",tensp="Ring Gấu Nâu ",maloai=3,mancc=3,dongia=80000,soluong=100,mota="Đây là sp thứ 10",tenhinh="r10.png",khuyenmai=0},
                new Sanpham{masp="r11",tensp="Ring Kem Dưa Hấu ",maloai=3,mancc=1,dongia=70000,soluong=100,mota="Đây là sp thứ 11",tenhinh="r11.png",khuyenmai=0},
                new Sanpham{masp="r12",tensp="Ring Mèo Vàng ",maloai=3,mancc=1,dongia=90000,soluong=100,mota="Đây là sp thứ 12",tenhinh="r12.png",khuyenmai=0},
                new Sanpham{masp="r13",tensp="Ring Icon Đáng Yêu ",maloai=3,mancc=3,dongia=40000,soluong=100,mota="Đây là sp thứ 13",tenhinh="r13.png",khuyenmai=0},
                new Sanpham{masp="r14",tensp="Ring Mèo Meo ",maloai=3,mancc=2,dongia=70000,soluong=100,mota="Đây là sp thứ 14",tenhinh="r14.png",khuyenmai=0},
                new Sanpham{masp="r15",tensp="Ring Gấu Poodle ",maloai=3,mancc=1,dongia=60000,soluong=100,mota="Đây là sp thứ 15",tenhinh="r15.png",khuyenmai=0},
                new Sanpham{masp="r16",tensp="Ring Mặt Mèo ",maloai=3,mancc=2,dongia=90000,soluong=100,mota="Đây là sp thứ 16",tenhinh="r16.png",khuyenmai=0},
                new Sanpham{masp="r17",tensp="Ring Trái Tim có cánh ",maloai=3,mancc=3,dongia=90000,soluong=100,mota="Đây là sp thứ 17",tenhinh="r17.png",khuyenmai=0},
                new Sanpham{masp="r18",tensp="Ring Cầu Vồng ",maloai=3,mancc=3,dongia=140000,soluong=100,mota="Đây là sp thứ 18",tenhinh="r18.png",khuyenmai=0},
                new Sanpham{masp="r19",tensp="Ring Xương Rồng ",maloai=3,mancc=1,dongia=80000,soluong=100,mota="Đây là sp thứ 19",tenhinh="r19.png",khuyenmai=0},
                new Sanpham{masp="r20",tensp="Ring Gấu Trúc ",maloai=3,mancc=1,dongia=90000,soluong=100,mota="Đây là sp thứ 20",tenhinh="r20.png",khuyenmai=0},
                new Sanpham{masp="a1",tensp="Bao AirPod Jordan 23 ",maloai=2,mancc=1,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a1.png",khuyenmai=0},
                new Sanpham{masp="a2",tensp="Bao AirPod Trái Tim ",maloai=2,mancc=2,dongia=130000,soluong=100,mota="Đây là sp thứ 2",tenhinh="a2.png",khuyenmai=0},
                new Sanpham{masp="a3",tensp="Bao AirPod Doraemon ",maloai=2,mancc=1,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a3.png",khuyenmai=0},
                new Sanpham{masp="a4",tensp="Bao AirPod Caption ",maloai=2,mancc=2,dongia=140000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a4.png",khuyenmai=0},
                new Sanpham{masp="a5",tensp="Bao AirPod Khủng Long ",maloai=2,mancc=3,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a5.png",khuyenmai=0},
                new Sanpham{masp="a6",tensp="Bao AirPod Trái Tim  ",maloai=2,mancc=1,dongia=160000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a6.png",khuyenmai=0},
                new Sanpham{masp="a7",tensp="Bao AirPod Hoạt Hình ",maloai=2,mancc=2,dongia=180000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a7.png",khuyenmai=0},
                new Sanpham{masp="a8",tensp="Bao AirPod Mèo  ",maloai=2,mancc=3,dongia=210000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a8.png",khuyenmai=0},
                new Sanpham{masp="a9",tensp="Bao AirPod Vịt Donald ",maloai=2,mancc=1,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a9.png",khuyenmai=0},
                new Sanpham{masp="a10",tensp="Bao AirPod Voi Kute ",maloai=2,mancc=2,dongia=100000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a10.png",khuyenmai=0},
                new Sanpham{masp="a11",tensp="Bao AirPod Trái Tim  ",maloai=2,mancc=3,dongia=170000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a11.png",khuyenmai=0},
                new Sanpham{masp="a12",tensp="Bao AirPod Hoa  ",maloai=2,mancc=1,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a12.png",khuyenmai=0},
                new Sanpham{masp="a13",tensp="Bao AirPod Chim Cánh Cụt ",maloai=2,mancc=2,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a13.png",khuyenmai=0},
                new Sanpham{masp="a14",tensp="Bao AirPod BatMan ",maloai=2,mancc=3,dongia=130000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a14.png",khuyenmai=0},
                new Sanpham{masp="a15",tensp="Bao AirPod Hamburger",maloai=2,mancc=1,dongia=135000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a15.png",khuyenmai=0},
                new Sanpham{masp="a16",tensp="Bao AirPod Dâu ",maloai=2,mancc=2,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a16.png",khuyenmai=0},
                new Sanpham{masp="a17",tensp="Bao AirPod Pop Corn ",maloai=2,mancc=3,dongia=170000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a17.png",khuyenmai=0},
                new Sanpham{masp="a18",tensp="Bao AirPod Mac Donald ",maloai=2,mancc=1,dongia=160000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a18.png",khuyenmai=0},
                new Sanpham{masp="a19",tensp="Bao AirPod Ếch Ộp ",maloai=2,mancc=2,dongia=130000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a19.png",khuyenmai=0},
                new Sanpham{masp="a20",tensp="Bao AirPod Vịt Đáng Yêu ",maloai=2,mancc=3,dongia=125000,soluong=100,mota="Đây là sp thứ 1",tenhinh="a20.png",khuyenmai=0},
                new Sanpham{masp="p1",tensp="Pop Mèo Xám ",maloai=3,mancc=2,dongia=140000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p1.png",khuyenmai=0},
                new Sanpham{masp="p2",tensp="Pop Bánh Ngọt ",maloai=3,mancc=3,dongia=130000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p2.png",khuyenmai=0},
                new Sanpham{masp="p3",tensp="Pop Biểu Tượng  ",maloai=3,mancc=1,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p3.png",khuyenmai=0},
                new Sanpham{masp="p4",tensp="Pop Dễ Thương ",maloai=3,mancc=3,dongia=100000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p4.png",khuyenmai=0},
                new Sanpham{masp="p5",tensp="Pop Galaxy ",maloai=3,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p5.png",khuyenmai=0},
                new Sanpham{masp="p6",tensp="Pop Maruko  ",maloai=3,mancc=1,dongia=123000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p6.png",khuyenmai=0},
                new Sanpham{masp="p7",tensp="Pop Shin Cậu Bé Bút Chì ",maloai=3,mancc=3,dongia=135000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p7.png",khuyenmai=0},
                new Sanpham{masp="p8",tensp="Pop Icon Khủng Long  ",maloai=3,mancc=1,dongia=170000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p8.png",khuyenmai=0},
                new Sanpham{masp="p9",tensp="Pop Chuột Dễ Thương  ",maloai=3,mancc=2,dongia=140000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p9.png",khuyenmai=0},
                new Sanpham{masp="p10",tensp="Pop Hihi",maloai=3,mancc=3,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p10.png",khuyenmai=0},
                new Sanpham{masp="p11",tensp="Pop Haha ",maloai=3,mancc=1,dongia=140000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p11.png",khuyenmai=0},
                new Sanpham{masp="p12",tensp="Pop Hoho ",maloai=3,mancc=3,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p12.png",khuyenmai=0},
                new Sanpham{masp="p13",tensp="Pop Quái Vật Xanh ",maloai=3,mancc=4,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p13.png",khuyenmai=0},
                new Sanpham{masp="p14",tensp="Pop Khủng Long ",maloai=3,mancc=1,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p14.png",khuyenmai=0},
                new Sanpham{masp="p15",tensp="Pop Heo Đáng Yêu ",maloai=3,mancc=2,dongia=160000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p15.png",khuyenmai=0},
                new Sanpham{masp="p16",tensp="Pop Chị Ong Vàng ",maloai=3,mancc=3,dongia=170000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p16.png",khuyenmai=0},
                new Sanpham{masp="p17",tensp="Pop Iron Man ",maloai=3,mancc=2,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p17.png",khuyenmai=0},
                new Sanpham{masp="p18",tensp="Pop Batman ",maloai=3,mancc=3,dongia=140000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p18.png",khuyenmai=0},
                new Sanpham{masp="p19",tensp="Pop Gấu Hồng ",maloai=3,mancc=1,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p19.png",khuyenmai=0},
                new Sanpham{masp="p20",tensp="Pop Đầu Gấu ",maloai=3,mancc=2,dongia=160000,soluong=100,mota="Đây là sp thứ 1",tenhinh="p20.png",khuyenmai=0},
                new Sanpham{masp="k1",tensp="Dây Đeo Marvel ",maloai=4,mancc=2,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k1.png",khuyenmai=0},
                new Sanpham{masp="k2",tensp="Dây Đeo Con Mắt ",maloai=4,mancc=4,dongia=130000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k2.png",khuyenmai=0},
                new Sanpham{masp="k3",tensp="Dây Đeo Trái Dâu ",maloai=4,mancc=1,dongia=120000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k3.png",khuyenmai=0},
                new Sanpham{masp="k4",tensp="Dây Đeo Đầu Gấu ",maloai=4,mancc=2,dongia=140000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k4.png",khuyenmai=0},
                new Sanpham{masp="k5",tensp="Dây Đeo Mèo Con ",maloai=4,mancc=3,dongia=199000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k5.png",khuyenmai=0},
                new Sanpham{masp="k6",tensp="Dây Đeo Bò Sữa  ",maloai=4,mancc=6,dongia=158000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k6.png",khuyenmai=0},
                new Sanpham{masp="k7",tensp="Dây Đeo Stick  ",maloai=4,mancc=3,dongia=151000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k7.png",khuyenmai=0},
                new Sanpham{masp="k8",tensp="Dây Đeo Tororo ",maloai=4,mancc=5,dongia=144000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k8.png",khuyenmai=0},
                new Sanpham{masp="k9",tensp="Dây Đeo Love  ",maloai=4,mancc=3,dongia=123000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k9.png",khuyenmai=0},
                new Sanpham{masp="k10",tensp="Dây Đeo Người Nhện ",maloai=4,mancc=1,dongia=175000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k10.png",khuyenmai=0},
                new Sanpham{masp="k11",tensp="Dây Đeo Moschino ",maloai=4,mancc=2,dongia=182000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k11.png",khuyenmai=0},
                new Sanpham{masp="k12",tensp="Dây Đeo Captain ",maloai=4,mancc=3,dongia=191000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k12.png",khuyenmai=0},
                new Sanpham{masp="k13",tensp="Dây Đeo Trái Dâu ",maloai=4,mancc=2,dongia=114000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k13.png",khuyenmai=0},
                new Sanpham{masp="k14",tensp="Dây Đeo Cà Rốt ",maloai=4,mancc=1,dongia=150000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k14.png",khuyenmai=0},
                new Sanpham{masp="k15",tensp="Dây Đeo Mặt Cười  ",maloai=4,mancc=3,dongia=155000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k15.png",khuyenmai=0},
                new Sanpham{masp="k16",tensp="Dây Đeo Hoạt Hình ",maloai=4,mancc=4,dongia=113000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k16.png",khuyenmai=0},
                new Sanpham{masp="k17",tensp="Dây Đeo Hihi ",maloai=4,mancc=2,dongia=123000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k17.png",khuyenmai=0},
                new Sanpham{masp="k18",tensp="Dây Đeo Smile ",maloai=4,mancc=1,dongia=186000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k18.png",khuyenmai=0},
                new Sanpham{masp="k19",tensp="Dây Đeo Supreme ",maloai=4,mancc=2,dongia=123000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k19.png",khuyenmai=0},
                new Sanpham{masp="k20",tensp="Dây Đeo Trứng Gà ",maloai=4,mancc=3,dongia=191000,soluong=100,mota="Đây là sp thứ 1",tenhinh="k20.png",khuyenmai=0},
            };
            sanphams.ForEach(s => context.Sanphams.AddOrUpdate(s));
            context.SaveChanges();

            //Mức duy trì
            var mucduytris = new List<Mucduytri>
            {
                new Mucduytri{mamuc=1, dieukien=100000, thuong= 1 },
                new Mucduytri{mamuc=2, dieukien=300000, thuong= 4 },
                new Mucduytri{mamuc=2, dieukien=500000, thuong= 7 }
            };
            mucduytris.ForEach(s => context.Mucduytris.AddOrUpdate(s));
            context.SaveChanges();

            //Giá tin
            var giatins = new List<Giatin>
            {
                new Giatin{magiatin=1, soluongtin=5, gia=50000 },
                new Giatin{magiatin=2, soluongtin=10, gia=90000 },
                new Giatin{magiatin=3, soluongtin=15, gia=13000 }
            };
            giatins.ForEach(s => context.Giatins.AddOrUpdate(s));
            context.SaveChanges();

        }
    }
=======

			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data.
			var loaisps = new List<Loaisp>
			{
			new Loaisp{maloai=1,tenloai="Ốp lưng"},
			new Loaisp{maloai=2,tenloai="Bao Airpod"},
			new Loaisp{maloai=3,tenloai="Ring- Bóp"},
			new Loaisp{maloai=3,tenloai="Khác"}
			};
			loaisps.ForEach(s => context.Loaisps.AddOrUpdate(s));
			context.SaveChanges();

			//Tài khoản
			var taikhoans = new List<TaiKhoan>
			{
			new TaiKhoan{matk=1,hoten="Nguyễn Văn An", email="ann@gmail.com", diachi="123 An Dương Vương", sdt="0123456700", sotk="1111111111111", matkhau="123", thoigiandk="1/1/2019", avatar="", UserType=UserType.Merchant},
			new TaiKhoan{matk=2,hoten="Trần Ngọc Ngà", email="ngocnga@gmail.com", diachi="478 Lý Thái Tổ", sdt="0123456701", sotk="2222222222222", matkhau="123", thoigiandk="1/1/2019", avatar="", UserType=UserType.Webmaster},
			new TaiKhoan{matk=3,hoten="Lê Thị Mai", email="maile@gmail.com", diachi="333 Hai Bà Trưng", sdt="0123456702", sotk="3333333333333", matkhau="123", thoigiandk="1/1/2019", avatar="", UserType=UserType.Customer},
			};
			taikhoans.ForEach(s => context.TaiKhoans.AddOrUpdate(s));
			context.SaveChanges();

			//Nhà cung cấp
			var nccs = new List<Ncc>
			{
			new Ncc{tenncc="ABC", gioithieu="shop bán ốp", sltinton=3, User_FK=1}
			};
			nccs.ForEach(s => context.Nccs.AddOrUpdate(s));
			context.SaveChanges();

			//Webmaster
			var webmasters = new List<Webmaster>
			{
			new Webmaster{User_FK=2}
			};
			webmasters.ForEach(s => context.Webmasters.AddOrUpdate(s));
			context.SaveChanges();

			//Customer
			var khachhangs = new List<Khachhang>
			{
			new Khachhang{User_FK=3}
			};
			khachhangs.ForEach(s => context.Khachhangs.AddOrUpdate(s));
			context.SaveChanges();

			//Sản phẩm
			var sanphams = new List<Sanpham>
			{
				new Sanpham{masp="1",tensp="Ốp Chống Bẩn GIành Cho Iphone 6 6S - iphone 6/6s",maloai=1,mancc=1,dongia=49000,soluong=100,mota="ốp lưng iphone apple silicone case là là một sản phảm đột phá nhờ công nghệ chống bám bẩn bên ngoài và lớp nhung mềm mại bên trong. Bảo vệ chiếc iphone của bạn tránh bị trầy xước hoặc giảm thiểu tối đa lực tsac động, khi vô tình rơi rớt",tenhinh="1.png",khuyenmai=0},
				new Sanpham{masp="2",tensp="Ốp hoạt hình",maloai=1,mancc=1,dongia=40000,soluong=100,mota="Đây là sp thứ 2",tenhinh="2.png",khuyenmai=0},
				new Sanpham{masp="3",tensp="Ốp hình nước ngọt pepsi",maloai=1,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 3",tenhinh="3.png",khuyenmai=0},
				new Sanpham{masp="4",tensp="Ốp hình hàn quốc",maloai=1,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 4",tenhinh="4.png",khuyenmai=0},
				new Sanpham{masp="5",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="5.png",khuyenmai=0},
				new Sanpham{masp="6",tensp="Ốp hình hàn quốc",maloai=1,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="6.png",khuyenmai=0},
				new Sanpham{masp="7",tensp="Ốp thả tim",maloai=1,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="7.png",khuyenmai=0},
				new Sanpham{masp="8",tensp="Ốp hình Icebear",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="8.png",khuyenmai=0},
				new Sanpham{masp="9",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="9.png",khuyenmai=0},
				new Sanpham{masp="10",tensp="Ốp trơn",maloai=1,mancc=3,dongia=70000,soluong=100,mota="Đây là sp thứ 1",tenhinh="10.png",khuyenmai=0},
				new Sanpham{masp="11",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="11.png",khuyenmai=0},
				new Sanpham{masp="12",tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="12.png",khuyenmai=0},
				new Sanpham{masp="13",tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=80000,soluong=100,mota="Đây là sp thứ 1",tenhinh="13.png",khuyenmai=0},
				new Sanpham{masp="14",tensp="Ốp trơn",maloai=1,mancc=2,dongia=19000,soluong=100,mota="Đây là sp thứ 1",tenhinh="14.png",khuyenmai=0},
				new Sanpham{masp="15",tensp="Ốp trơn",maloai=1,mancc=1,dongia=84000,soluong=100,mota="Đây là sp thứ 1",tenhinh="15.png",khuyenmai=0},
				new Sanpham{masp="16",tensp="Ốp họa tiết",maloai=1,mancc=3,dongia=30000,soluong=100,mota="Đây là sp thứ 1",tenhinh="16.png",khuyenmai=0},
				new Sanpham{masp="17",tensp="Ốp trơn",maloai=1,mancc=3,dongia=44000,soluong=100,mota="Đây là sp thứ 1",tenhinh="17.png",khuyenmai=0},
				new Sanpham{masp="18",tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=40000,soluong=100,mota="Đây là sp thứ 1",tenhinh="18.png",khuyenmai=0},
				new Sanpham{masp="19",tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="19.png",khuyenmai=0},
				new Sanpham{masp="20",tensp="Ốp trơn",maloai=1,mancc=2,dongia=25000,soluong=100,mota="Đây là sp thứ 1",tenhinh="20.png",khuyenmai=0},
				new Sanpham{masp="21",tensp="Ốp trơn",maloai=1,mancc=1,dongia=19000,soluong=100,mota="Đây là sp thứ 1",tenhinh="21.png",khuyenmai=0},
				new Sanpham{masp="22",tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="22.png",khuyenmai=0},
				new Sanpham{masp="23",tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="23.png",khuyenmai=0},
				new Sanpham{masp="24",tensp="Ốp trơn",maloai=1,mancc=2,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="24.png",khuyenmai=0},
				new Sanpham{masp="25",tensp="Ốp trơn",maloai=1,mancc=2,dongia=54000,soluong=100,mota="Đây là sp thứ 1",tenhinh="25.png",khuyenmai=0},
				new Sanpham{masp="26",tensp="Ốp trơn",maloai=1,mancc=1,dongia=54000,soluong=100,mota="Đây là sp thứ 1",tenhinh="26.png",khuyenmai=0},
				new Sanpham{masp="27",tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="27.png",khuyenmai=0},
				new Sanpham{masp="28",tensp="Ốp trơn",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="28.png",khuyenmai=0},
				new Sanpham{masp="29",tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="29.png",khuyenmai=0},
				new Sanpham{masp="30",tensp="Ốp trơn",maloai=1,mancc=3,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="30.png",khuyenmai=0},
				new Sanpham{masp="31",tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="31.png",khuyenmai=0},
				new Sanpham{masp="32",tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="32.png",khuyenmai=0},
				new Sanpham{masp="33",tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="33.png",khuyenmai=0},
				new Sanpham{masp="34",tensp="Ốp trơn",maloai=1,mancc=2,dongia=32000,soluong=100,mota="Đây là sp thứ 1",tenhinh="34.png",khuyenmai=0},
				new Sanpham{masp="35",tensp="Ốp trơn",maloai=1,mancc=2,dongia=22000,soluong=100,mota="Đây là sp thứ 1",tenhinh="35.png",khuyenmai=0},
				new Sanpham{masp="36",tensp="Ốp kính siêu nhân",maloai=1,mancc=3,dongia=66000,soluong=100,mota="Đây là sp thứ 1",tenhinh="36.png",khuyenmai=0},
				new Sanpham{masp="37",tensp="Ốp trơn",maloai=1,mancc=1,dongia=56000,soluong=100,mota="Đây là sp thứ 1",tenhinh="37.png",khuyenmai=0},
				new Sanpham{masp="38",tensp="Ốp trơn",maloai=1,mancc=1,dongia=65000,soluong=100,mota="Đây là sp thứ 1",tenhinh="38.png",khuyenmai=0},
				new Sanpham{masp="39",tensp="Ốp trơn",maloai=1,mancc=3,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="39.png",khuyenmai=0},
				new Sanpham{masp="40",tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="40.png",khuyenmai=0},
				new Sanpham{masp="41",tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="41.png",khuyenmai=0},
				new Sanpham{masp="42",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=85000,soluong=100,mota="Đây là sp thứ 1",tenhinh="42.png",khuyenmai=0},
				new Sanpham{masp="43",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="43.png",khuyenmai=0},
				new Sanpham{masp="44",tensp="Ốp hình hàn quốc",maloai=1,mancc=1,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="44.png",khuyenmai=0},
				new Sanpham{masp="45",tensp="Ốp hình hàn quốc",maloai=1,mancc=2,dongia=65000,soluong=100,mota="Đây là sp thứ 1",tenhinh="45.png",khuyenmai=0},
				new Sanpham{masp="46",tensp="Ốp hình hàn quốc",maloai=1,mancc=1,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="46.png",khuyenmai=0},
				new Sanpham{masp="47",tensp="Ốp kính siêu nhân",maloai=1,mancc=1,dongia=100000,soluong=100,mota="Đây là sp thứ 1",tenhinh="47.png",khuyenmai=0},
				new Sanpham{masp="48",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=90000,soluong=100,mota="Đây là sp thứ 1",tenhinh="48.png",khuyenmai=0},
				new Sanpham{masp="49",tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="49.png",khuyenmai=0},
				new Sanpham{masp="50",tensp="Ốp nhám vô diện",maloai=1,mancc=1,dongia=70000,soluong=100,mota="Đây là sp thứ 1",tenhinh="50.png",khuyenmai=0},
			};
			sanphams.ForEach(s => context.Sanphams.AddOrUpdate(s));
			context.SaveChanges();

			//Mức duy trì
			var mucduytris = new List<Mucduytri>
			{
				new Mucduytri{mamuc=1, dieukien=100000, thuong= 1 },
				new Mucduytri{mamuc=2, dieukien=300000, thuong= 4 },
				new Mucduytri{mamuc=2, dieukien=500000, thuong= 7 }
			};
			mucduytris.ForEach(s => context.Mucduytris.AddOrUpdate(s));
			context.SaveChanges();

			//Giá tin
			var giatins = new List<Giatin>
			{
				new Giatin{magiatin=1, soluongtin=5, gia=50000 },
				new Giatin{magiatin=2, soluongtin=10, gia=90000 },
				new Giatin{magiatin=3, soluongtin=15, gia=13000 }
			};
			giatins.ForEach(s => context.Giatins.AddOrUpdate(s));
			context.SaveChanges();

		}
	}
>>>>>>> 9b06fd4ba401c8d3416cc9925bd2a8636cffb683
}
