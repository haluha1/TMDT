using Data.Entities;
using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
	public class DbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<PhukienDTDbContext>
	{
		protected override void Seed(PhukienDTDbContext context)
		{
            //Loại sản phẩm
			var loaisps = new List<Loaisp>
			{
			new Loaisp{maloai=1,tenloai="Ốp lưng"},
			new Loaisp{maloai=2,tenloai="Bao Airpod"},
			new Loaisp{maloai=3,tenloai="Ring- Bóp"},
            new Loaisp{maloai=3,tenloai="Khác"}
            };
			loaisps.ForEach(s => context.Loaisps.Add(s));
			context.SaveChanges();

            //Tài khoản
            var taikhoans = new List<TaiKhoan>
            {
            new TaiKhoan{matk=1,hoten="Nguyễn Văn An", email="ann@gmail.com", diachi="123 An Dương Vương", sdt="0123456700", sotk="1111111111111", matkhau="123", thoigiandk="1/1/2019", UserType=RatingType.Merchant},
            new TaiKhoan{matk=2,hoten="Trần Ngọc Ngà", email="ngocnga@gmail.com", diachi="478 Lý Thái Tổ", sdt="0123456701", sotk="2222222222222", matkhau="123", thoigiandk="1/1/2019", UserType=RatingType.Webmaster},
            new TaiKhoan{matk=3,hoten="Lê Thị Mai", email="maile@gmail.com", diachi="333 Hai Bà Trưng", sdt="0123456702", sotk="3333333333333", matkhau="123", thoigiandk="1/1/2019", UserType=RatingType.Customer},
            };
            taikhoans.ForEach(s => context.TaiKhoans.Add(s));
            context.SaveChanges();

            //Nhà cung cấp
            var nccs = new List<Ncc>
            {
            new Ncc{tenncc="ABC", gioithieu="shop bán ốp", sltinton=3, User_FK=1}
            };
            nccs.ForEach(s => context.Nccs.Add(s));
            context.SaveChanges();

            //Webmaster
            var webmasters = new List<Webmaster>
            {
            new Webmaster{User_FK=2}
            };
            webmasters.ForEach(s => context.Webmasters.Add(s));
            context.SaveChanges();

            //Customer
            var khachhangs = new List<Khachhang>
            {
            new Khachhang{User_FK=3}
            };
            khachhangs.ForEach(s => context.Khachhangs.Add(s));
            context.SaveChanges();

            //Sản phẩm
            var sanphams = new List<Sanpham>
            {
                new Sanpham{masp=1,tensp="Ốp Chống Bẩn GIành Cho Iphone 6 6S - iphone 6/6s",maloai=1,mancc=1,dongia=49000,soluong=100,mota="ốp lưng iphone apple silicone case là là một sản phảm đột phá nhờ công nghệ chống bám bẩn bên ngoài và lớp nhung mềm mại bên trong. Bảo vệ chiếc iphone của bạn tránh bị trầy xước hoặc giảm thiểu tối đa lực tsac động, khi vô tình rơi rớt",tenhinh="1.png",khuyenmai=0},
                new Sanpham{masp=2,tensp="Ốp hoạt hình",maloai=1,mancc=1,dongia=40000,soluong=100,mota="Đây là sp thứ 2",tenhinh="2.png",khuyenmai=0},
                new Sanpham{masp=3,tensp="Ốp hình nước ngọt pepsi",maloai=1,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 3",tenhinh="3.png",khuyenmai=0},
                new Sanpham{masp=4,tensp="Ốp hình hàn quốc",maloai=1,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 4",tenhinh="4.png",khuyenmai=0},
                new Sanpham{masp=5,tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="5.png",khuyenmai=0},
                new Sanpham{masp=6,tensp="Ốp hình hàn quốc",maloai=1,mancc=2,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="6.png",khuyenmai=0},
                new Sanpham{masp=7,tensp="Ốp thả tim",maloai=1,mancc=3,dongia=60000,soluong=100,mota="Đây là sp thứ 1",tenhinh="7.png",khuyenmai=0},
                new Sanpham{masp=8,tensp="Ốp hình Icebear",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="8.png",khuyenmai=0},
                new Sanpham{masp=9,tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="9.png",khuyenmai=0},
                new Sanpham{masp=10,tensp="Ốp trơn",maloai=1,mancc=3,dongia=70000,soluong=100,mota="Đây là sp thứ 1",tenhinh="10.png",khuyenmai=0},
                new Sanpham{masp=11,tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="11.png",khuyenmai=0},
                new Sanpham{masp=12,tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="12.png",khuyenmai=0},
                new Sanpham{masp=13,tensp="Ốp hình Icebear",maloai=1,mancc=1,dongia=80000,soluong=100,mota="Đây là sp thứ 1",tenhinh="13.png",khuyenmai=0},
                new Sanpham{masp=14,tensp="Ốp trơn",maloai=1,mancc=2,dongia=19000,soluong=100,mota="Đây là sp thứ 1",tenhinh="14.png",khuyenmai=0},
                new Sanpham{masp=15,tensp="Ốp trơn",maloai=1,mancc=1,dongia=84000,soluong=100,mota="Đây là sp thứ 1",tenhinh="15.png",khuyenmai=0},
                new Sanpham{masp=16,tensp="Ốp họa tiết",maloai=1,mancc=3,dongia=30000,soluong=100,mota="Đây là sp thứ 1",tenhinh="16.png",khuyenmai=0},
                new Sanpham{masp=17,tensp="Ốp trơn",maloai=1,mancc=3,dongia=44000,soluong=100,mota="Đây là sp thứ 1",tenhinh="17.png",khuyenmai=0},
                new Sanpham{masp=18,tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=40000,soluong=100,mota="Đây là sp thứ 1",tenhinh="18.png",khuyenmai=0},
                new Sanpham{masp=19,tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="19.png",khuyenmai=0},
                new Sanpham{masp=20,tensp="Ốp trơn",maloai=1,mancc=2,dongia=25000,soluong=100,mota="Đây là sp thứ 1",tenhinh="20.png",khuyenmai=0},
                new Sanpham{masp=21,tensp="Ốp trơn",maloai=1,mancc=1,dongia=19000,soluong=100,mota="Đây là sp thứ 1",tenhinh="21.png",khuyenmai=0},
                new Sanpham{masp=22,tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="22.png",khuyenmai=0},
                new Sanpham{masp=23,tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="23.png",khuyenmai=0},
                new Sanpham{masp=24,tensp="Ốp trơn",maloai=1,mancc=2,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="24.png",khuyenmai=0},
                new Sanpham{masp=25,tensp="Ốp trơn",maloai=1,mancc=2,dongia=54000,soluong=100,mota="Đây là sp thứ 1",tenhinh="25.png",khuyenmai=0},
                new Sanpham{masp=26,tensp="Ốp trơn",maloai=1,mancc=1,dongia=54000,soluong=100,mota="Đây là sp thứ 1",tenhinh="26.png",khuyenmai=0},
                new Sanpham{masp=27,tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="27.png",khuyenmai=0},
                new Sanpham{masp=28,tensp="Ốp trơn",maloai=1,mancc=1,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="28.png",khuyenmai=0},
                new Sanpham{masp=29,tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="29.png",khuyenmai=0},
                new Sanpham{masp=30,tensp="Ốp trơn",maloai=1,mancc=3,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="30.png",khuyenmai=0},
                new Sanpham{masp=31,tensp="Ốp trơn",maloai=1,mancc=3,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="31.png",khuyenmai=0},
                new Sanpham{masp=32,tensp="Ốp họa tiết",maloai=1,mancc=1,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="32.png",khuyenmai=0},
                new Sanpham{masp=33,tensp="Ốp trơn",maloai=1,mancc=2,dongia=10000,soluong=100,mota="Đây là sp thứ 1",tenhinh="33.png",khuyenmai=0},
                new Sanpham{masp=34,tensp="Ốp trơn",maloai=1,mancc=2,dongia=32000,soluong=100,mota="Đây là sp thứ 1",tenhinh="34.png",khuyenmai=0},
                new Sanpham{masp=35,tensp="Ốp trơn",maloai=1,mancc=2,dongia=22000,soluong=100,mota="Đây là sp thứ 1",tenhinh="35.png",khuyenmai=0},
                new Sanpham{masp=36,tensp="Ốp kính siêu nhân",maloai=1,mancc=3,dongia=66000,soluong=100,mota="Đây là sp thứ 1",tenhinh="36.png",khuyenmai=0},
                new Sanpham{masp=37,tensp="Ốp trơn",maloai=1,mancc=1,dongia=56000,soluong=100,mota="Đây là sp thứ 1",tenhinh="37.png",khuyenmai=0},
                new Sanpham{masp=38,tensp="Ốp trơn",maloai=1,mancc=1,dongia=65000,soluong=100,mota="Đây là sp thứ 1",tenhinh="38.png",khuyenmai=0},
                new Sanpham{masp=39,tensp="Ốp trơn",maloai=1,mancc=3,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="39.png",khuyenmai=0},
                new Sanpham{masp=40,tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="40.png",khuyenmai=0},
                new Sanpham{masp=41,tensp="Ốp trơn",maloai=1,mancc=1,dongia=35000,soluong=100,mota="Đây là sp thứ 1",tenhinh="41.png",khuyenmai=0},
                new Sanpham{masp=42,tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=85000,soluong=100,mota="Đây là sp thứ 1",tenhinh="42.png",khuyenmai=0},
                new Sanpham{masp=43,tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="43.png",khuyenmai=0},
                new Sanpham{masp=44,tensp="Ốp hình hàn quốc",maloai=1,mancc=1,dongia=110000,soluong=100,mota="Đây là sp thứ 1",tenhinh="44.png",khuyenmai=0},
                new Sanpham{masp=45,tensp="Ốp hình hàn quốc",maloai=1,mancc=2,dongia=65000,soluong=100,mota="Đây là sp thứ 1",tenhinh="45.png",khuyenmai=0},
                new Sanpham{masp=46,tensp="Ốp hình hàn quốc",maloai=1,mancc=1,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="46.png",khuyenmai=0},
                new Sanpham{masp=47,tensp="Ốp kính siêu nhân",maloai=1,mancc=1,dongia=100000,soluong=100,mota="Đây là sp thứ 1",tenhinh="47.png",khuyenmai=0},
                new Sanpham{masp=48,tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=90000,soluong=100,mota="Đây là sp thứ 1",tenhinh="48.png",khuyenmai=0},
                new Sanpham{masp=49,tensp="Ốp kính siêu nhân",maloai=1,mancc=2,dongia=55000,soluong=100,mota="Đây là sp thứ 1",tenhinh="49.png",khuyenmai=0},
                new Sanpham{masp=50,tensp="Ốp nhám vô diện",maloai=1,mancc=1,dongia=70000,soluong=100,mota="Đây là sp thứ 1",tenhinh="50.png",khuyenmai=0},
            };
            sanphams.ForEach(s => context.Sanphams.Add(s));
            context.SaveChanges();

            //Mức duy trì
            var mucduytris = new List<Mucduytri>
            {
                new Mucduytri{mamuc=1, dieukien=100000, thuong= 1 },
                new Mucduytri{mamuc=2, dieukien=300000, thuong= 4 },
                new Mucduytri{mamuc=2, dieukien=500000, thuong= 7 }
            };
            mucduytris.ForEach(s => context.Mucduytris.Add(s));
            context.SaveChanges();

            //Giá tin
            var giatins = new List<Giatin>
            {
                new Giatin{magiatin=1, soluongtin=5, gia=50000 },
                new Giatin{magiatin=2, soluongtin=10, gia=90000 },
                new Giatin{magiatin=3, soluongtin=15, gia=13000 }
            };
            giatins.ForEach(s => context.Giatins.Add(s));
            context.SaveChanges();

            //var courses = new List<Course>
            //{
            //new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            //new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            //new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            //new Course{CourseID=1045,Title="Calculus",Credits=4,},
            //new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            //new Course{CourseID=2021,Title="Composition",Credits=3,},
            //new Course{CourseID=2042,Title="Literature",Credits=4,}
            //};
            //courses.ForEach(s => context.Courses.Add(s));
            //context.SaveChanges();
            //var enrollments = new List<Enrollment>
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050,},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //enrollments.ForEach(s => context.Enrollments.Add(s));
            //context.SaveChanges();
        }
	}
}
