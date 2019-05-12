using Application.ViewModels;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IUserService : IDisposable
	{
		bool Login(LoginViewModel LoginVm);

		TaiKhoan GetUser(int id);
		TaiKhoanViewModel GetById(int id);
		TaiKhoanViewModel Register(TaiKhoanViewModel TaiKhoanVm,string s);
		TaiKhoanViewModel GetByEmail(string email);

		bool Save();
	}
}
