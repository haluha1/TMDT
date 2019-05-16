using Application.ViewModels;
using AutoMapper;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
	public class DomainToViewModelMappingProfile : Profile
	{
		public DomainToViewModelMappingProfile()
		{
			//CreateMap<Student, StudentViewModel>().AfterMap((src, dest) =>
			//{
			//    foreach (var i in dest.Enrollments)
			//        i.StudentNavigation = null;
			//}); ;
			//CreateMap<Enrollment, EnrollmentViewModel>();
			//CreateMap<Course, CourseViewModel>();
			////.ForMember(m => m.StudentNavigation, opt => opt.Ignore())
			
			CreateMap<Cthd, CthdViewModel>();
			CreateMap<CtRating, CtRatingViewModel>();
			CreateMap<Giatin, GiatinViewModel>().ForMember(m=>m.Hoadonmuatins, opt=>opt.Ignore());
			
			CreateMap<Hoadon, HoadonViewModel>().MaxDepth(1).AfterMap((src, dest) =>
            {
                dest.KhachHangNavigation.Hoadons = null;
                
                foreach (var i in dest.Cthdons)
                {
                    i.HoadonNavigation = null;
                    i.SanphamNavigation.CtGiohangs = null;
                    i.SanphamNavigation.KhachHangYeuThichs = null;
                }
                dest.KhachHangNavigation.TaiKhoanBy.KhachhangNavigation = null;

            });
            CreateMap<Hoadonmuatin, HoadonmuatinViewModel>().ForMember(m=>m.NccNavigation, opt=>opt.Ignore());
            CreateMap<CtGiohang, CtGiohangViewModel>();
			
			CreateMap<Khachhang, KhachhangViewModel>().ForMember(m=>m.Hoadons, opt=>opt.Ignore())
													  .ForMember(m=>m.CtRatings, opt=>opt.Ignore());
			CreateMap<Loaisp, LoaispViewModel>().ForMember(m => m.Sanphams, opt => opt.Ignore());
			CreateMap<Mucduytri, MucduytriViewModel>();
			CreateMap<Ncc, NccViewModel>().ForMember(m=>m.Sanphams, opt=>opt.Ignore())
										  .ForMember(m=>m.TaiKhoanBy, opt=>opt.Ignore());

			CreateMap<Sanpham, SanphamViewModel>().ForMember(m => m.Cthds, opt => opt.Ignore())
												  .ForMember(m => m.CtGiohangs, opt => opt.Ignore())
												  .ForMember(m => m.KhachHangYeuThichs, opt => opt.Ignore());



            CreateMap<TaiKhoan, TaiKhoanViewModel>();
			CreateMap<Webmaster, WebmasterViewModel>();

			
			CreateMap<RatingViewModel, RatingViewModel>().AfterMap((src, dest) =>
			{
				if (dest.CtRatings != null)
				{
					foreach (var i in dest.CtRatings)
					{
						i.KhachhangNavigation.CtRatings = null;
						i.KhachhangNavigation.SanPhamYeuThichs = null;
						i.KhachhangNavigation.TaiKhoanBy.KhachhangNavigation = null;
					}
						
				}
			});
		}
	}
}
