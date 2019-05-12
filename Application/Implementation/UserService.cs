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
		private IRepository<ActiveCode, int> _repositoryCode;
		private IUnitOfWork _unitOfWork;

		public UserService(IRepository<TaiKhoan, int> repository, IUnitOfWork unitOfWork, IRepository<ActiveCode, int> repositoryCode)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
			_repositoryCode = repositoryCode;
	}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public TaiKhoan GetUser(int id)
		{
			return _repository.FindAll().SingleOrDefault(x => x.KeyId == id);

		}

		public TaiKhoanViewModel GetById(int id)
		{
			var item = _repository.FindAll().SingleOrDefault(x => x.KeyId == id);
			return Mapper.Map<TaiKhoan, TaiKhoanViewModel>(item);

		}

		public TaiKhoanViewModel GetByEmail(string email)
		{
			var item = _repository.FindAll().SingleOrDefault(x => x.email == email);
			return Mapper.Map<TaiKhoan, TaiKhoanViewModel>(item);

		}
		public TaiKhoanViewModel Register(TaiKhoanViewModel TaiKhoanVm, string s)
		{
			var taiKhoan = Mapper.Map<TaiKhoanViewModel, TaiKhoan>(TaiKhoanVm);
			var today = DateTime.Today.ToShortDateString();
			taiKhoan.thoigiandk = today;

			//_repository.FindAllNoTracking().Where(x => { x.email == TaiKhoanVm.email || x.sdt == TaiKhoanVm.sdt});

			_repository.AddReturn(taiKhoan);
			taiKhoan.matk = taiKhoan.KeyId;
			TaiKhoanVm.KeyId = taiKhoan.KeyId;

			ActiveCode newCode = new ActiveCode();
			newCode.code = s;
			newCode.CodeType = Data.Enum.CodeType.Active;
			newCode.DateCreate = DateTime.Now;
			newCode.User_FK = taiKhoan.KeyId;
			_repositoryCode.Add(newCode);

			//sanphamVm.Id = _convertFunction.Instance.Create_Code(true, sp.KeyId,
			//CommonConstants.defaultLengthNumberCode, const_AddressbookType.Employee);
			//sp.Id = HP_EmployeeVm.Id;
			//employee.UserBy.IsEmployee = true;
			_unitOfWork.Commit();
			return TaiKhoanVm;
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
