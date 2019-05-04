using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface ISanphamService
	{
		SanphamViewModel Add(SanphamViewModel loaispVm);

		void Update(SanphamViewModel loaispVm);

		void Delete(int id);

		List<SanphamViewModel> GetAll();

		List<SanphamViewModel> GetAll(string keyword);

		SanphamViewModel GetBysId(string keyword);

		SanphamViewModel GetById(int id);


		bool Save();
	}
}
