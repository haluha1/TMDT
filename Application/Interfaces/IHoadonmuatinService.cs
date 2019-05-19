using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IHoadonmuatinService : IDisposable
	{
		HoadonmuatinViewModel Add(HoadonmuatinViewModel hoadonVm);

		void Update(HoadonmuatinViewModel hoadonVm);

		void Delete(int id);

		List<HoadonmuatinViewModel> GetAll();

		List<HoadonmuatinViewModel> GetAll(string keyword);

		HoadonmuatinViewModel GetBysId(string keyword);

		HoadonmuatinViewModel GetById(int id);


		bool Save();
	}
}
