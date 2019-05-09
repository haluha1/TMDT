using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Data.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation
{
	public class UserService : IUserService
	{
		private IRepository<TaiKhoan, int> _repository;
		private IUnitOfWork _unitOfWork;

		public UserService(IRepository<TaiKhoan, int> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public TaiKhoanViewModel GetByEmail(string email)
		{
			var item = _repository.FindAll().SingleOrDefault(x => x.email == email);
			return Mapper.Map<TaiKhoan, TaiKhoanViewModel>(item);

		}

		public bool Login(LoginViewModel LoginVm)
		{
			var user = _repository.FindAll().Where(x => (x.email == LoginVm.Username) && (x.matkhau == LoginVm.Password));
			if (user.Count() > 0) return true;
			return false;
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}
	}
}
