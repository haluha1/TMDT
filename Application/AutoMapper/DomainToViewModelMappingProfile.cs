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
			//CreateMap<Student, StudentViewModel>().AfterMap((src, dest) => {
			//	foreach (var i in dest.Enrollments)
			//		i.StudentNavigation = null;
			//}); ;
			//CreateMap<Enrollment, EnrollmentViewModel>();
			//CreateMap<Course, CourseViewModel>();
			////.ForMember(m => m.StudentNavigation, opt => opt.Ignore())

			CreateMap<Cthd, CthdViewModel>();
			CreateMap<CtRating, CtRatingViewModel>();
			CreateMap<Giatin, GiatinViewModel>();
			CreateMap<Giohang, GiohangViewModel>();
			CreateMap<Hoadon, HoadonViewModel>();
			CreateMap<Hoadonmuatin, HoadonmuatinViewModel>();
			CreateMap<Khachhang, KhachhangViewModel>();
			CreateMap<Loaisp, LoaispViewModel>().ForMember(m => m.Sanphams, opt => opt.Ignore());
			CreateMap<Mucduytri, MucduytriViewModel>();
			CreateMap<Ncc, NccViewModel>();
			CreateMap<Sanpham, SanphamViewModel>();
			CreateMap<TaiKhoan, TaiKhoanViewModel>();
			CreateMap<Webmaster, WebmasterViewModel>();

		}
	}
}
