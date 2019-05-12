using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IRatingService : IDisposable
	{
		CtRatingViewModel Add(CtRatingViewModel CtRatingVm);

		void Update(CtRatingViewModel CtRatingVm);

		void Delete(int id);

		List<CtRatingViewModel> GetAll();

		List<CtRatingViewModel> GetAll(string keyword);

		CtRatingViewModel GetBysId(string keyword);

		CtRatingViewModel GetById(int id);


		bool Save();
	}
}
