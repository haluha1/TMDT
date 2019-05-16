using Data.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Utilities.Constants;

namespace Application.ViewModels
{
	public class UserLoginViewModel
	{
		public UserLoginViewModel(TaiKhoanViewModel TaiKhoanVm)
		{
			KeyId = TaiKhoanVm.KeyId;
			UserID = TaiKhoanVm.matk;
			Email = TaiKhoanVm.email;
			UserName = TaiKhoanVm.hoten;
			Avatar = TaiKhoanVm.avatar;
			UserType = TaiKhoanVm.UserType;
			Phone = TaiKhoanVm.sdt;
			Address = TaiKhoanVm.diachi;
		}

		private UserLoginViewModel() { }
		public static UserLoginViewModel Current
		{
			get
			{
				UserLoginViewModel session = (UserLoginViewModel)HttpContext.Current.Session[CommonConstrants.USER_SESSION];
				//if (session == null)
				//{
				//	session = new UserLoginViewModel();
				//	HttpContext.Current.Session[CommonConstrants.USER_SESSION] = session;
				//}
				return session;
			}
		}
		public int KeyId { get; set; }
		public int UserID { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Avatar { get; set; }
		public UserType UserType { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }

	}
}
