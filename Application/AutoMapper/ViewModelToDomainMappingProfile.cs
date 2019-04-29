using AutoMapper;
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
			//CreateMap<StudentViewModel, Student>()
			//	.ConstructUsing(c => new Student(c.KeyId, c.LastName, c.FirstMidName, c.EnrollmentDate));
			//CreateMap<EnrollmentViewModel, Enrollment>()
			//	.ConstructUsing(c => new Enrollment(c.EnrollmentID, c.CourseID, c.StudentID, c.Grade));
		}
	}
}
