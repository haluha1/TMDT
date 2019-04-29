using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface ILoaiSPService
	{
		LoaispViewModel Add(LoaispViewModel loaispVm);

		void Update(LoaispViewModel loaispVm);

		void Delete(int id);

		List<LoaispViewModel> GetAll();

		List<LoaispViewModel> GetAll(string keyword);

		LoaispViewModel GetBysId(string keyword);

		LoaispViewModel GetById(int id);


		bool Save();
	}
}
