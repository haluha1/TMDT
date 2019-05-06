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
	public class ViewModelToDomainMappingProfile : Profile
	{
		public ViewModelToDomainMappingProfile()
		{
			CreateMap<SanphamViewModel, Sanpham>().ConstructUsing(c => new Sanpham(c.KeyId, c.masp, c.tensp, c.maloai, c.mancc, c.dongia, c.soluong, c.mota, c.tenhinh, c.khuyenmai));
			
			//CreateMap<EnrollmentViewModel, Enrollment>()
			//	.ConstructUsing(c => new Enrollment(c.EnrollmentID, c.CourseID, c.StudentID, c.Grade));
		}
	}
}
