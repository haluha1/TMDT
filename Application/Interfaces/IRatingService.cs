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
		RatingViewModel Add(RatingViewModel ratingVm);

		void Update(RatingViewModel ratingVm);

		void Delete(int id);

		List<RatingViewModel> GetAll();

		List<RatingViewModel> GetAll(string keyword);

		RatingViewModel GetBysId(string keyword);

		RatingViewModel GetById(int id);


		bool Save();
	}
}
