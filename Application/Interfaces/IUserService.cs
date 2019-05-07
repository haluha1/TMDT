using Application.ViewModels;
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

		TaiKhoanViewModel GetByEmail(string email);

		bool Save();
	}
}
