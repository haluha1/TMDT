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
			return _repository.FindAll().FirstOrDefault(x => x.KeyId == id);

		}
		public TaiKhoanViewModel GetById(int id)
		{
			var item = _repository.FindAll().FirstOrDefault(x => x.KeyId == id);
			return Mapper.Map<TaiKhoan, TaiKhoanViewModel>(item);

		}

		public TaiKhoanViewModel GetByEmail(string email)
		{
			var item = _repository.FindAll().FirstOrDefault(x => x.email == email);
			return Mapper.Map<TaiKhoan, TaiKhoanViewModel>(item);

		}
		public TaiKhoanViewModel Register(TaiKhoanViewModel TaiKhoanVm, string s)
		{
			var taiKhoan = Mapper.Map<TaiKhoanViewModel, TaiKhoan>(TaiKhoanVm);
			var today = DateTime.Today.ToShortDateString();
			taiKhoan.thoigiandk = today;

			int checkEmail = _repository.FindAllNoTracking().Where(x =>  x.email == TaiKhoanVm.email).Count();
			if (checkEmail > 0) TaiKhoanVm.email = "";
			int checkSdt = _repository.FindAllNoTracking().Where(x => x.sdt == TaiKhoanVm.sdt).Count();
			if (checkSdt > 0) TaiKhoanVm.sdt = "";
			if (checkEmail < 1 && checkSdt < 1)
			{
				
				if (TaiKhoanVm.UserType == Data.Enum.UserType.Customer)
				{
					taiKhoan.KhachhangNavigation = new Khachhang();
					
				}
				if (TaiKhoanVm.UserType == Data.Enum.UserType.Merchant)
				{
					taiKhoan.NccNavigation = new Ncc();
				}
				
				_repository.AddReturn(taiKhoan);
				taiKhoan.matk = taiKhoan.KeyId;
				TaiKhoanVm.KeyId = taiKhoan.KeyId;



				ActiveCode newCode = new ActiveCode();
				newCode.KeyId = 0;
				newCode.code = s;
				newCode.CodeType = Data.Enum.CodeType.Active;
				newCode.DateCreate = DateTime.Now;
				newCode.User_FK = taiKhoan.KeyId;
				newCode.CodeStatus = Data.Enum.CodeStatus.UnActivated;
				_repositoryCode.Add(newCode);
				
			}
			

			//sanphamVm.Id = _convertFunction.Instance.Create_Code(true, sp.KeyId,
			//CommonConstants.defaultLengthNumberCode, const_AddressbookType.Employee);
			//sp.Id = HP_EmployeeVm.Id;
			//employee.UserBy.IsEmployee = true;
			
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

		public TaiKhoanViewModel ConfirmEmail(int id, string s)
		{
			ActiveCode Code = _repositoryCode.FindAll().Where(x => x.User_FK == id).SingleOrDefault();

			if (s == Code.code)
			{
				Code.CodeStatus = Data.Enum.CodeStatus.Activated;
				var item = _repository.FindById(id);
				return Mapper.Map<TaiKhoan, TaiKhoanViewModel>(item);
			}
			else
			{
				return new TaiKhoanViewModel();
			}
		}
	}
}
