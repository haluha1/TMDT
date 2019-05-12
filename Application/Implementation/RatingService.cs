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
	public class RatingService : IRatingService
	{
		private IRepository<CtRating, int> _repository;
		private IUnitOfWork _unitOfWork;

		public RatingService(IRepository<CtRating, int> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public CtRatingViewModel Add(CtRatingViewModel ratingVm)
		{
			var rating = Mapper.Map<CtRatingViewModel, CtRating>(ratingVm);
			_repository.AddReturn(rating);
			ratingVm.KeyId = rating.KeyId;
			//sanphamVm.Id = _convertFunction.Instance.Create_Code(true, sp.KeyId,
			//CommonConstants.defaultLengthNumberCode, const_AddressbookType.Employee);
			//sp.Id = HP_EmployeeVm.Id;
			//employee.UserBy.IsEmployee = true;
			_unitOfWork.Commit();
			return ratingVm;
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public List<CtRatingViewModel> GetAll()
		{
			var query = _repository.FindAll();
			var data = new List<CtRatingViewModel>();
			foreach (var item in query)
			{
				var _data = Mapper.Map<CtRating, CtRatingViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public List<CtRatingViewModel> GetAll(string keyword)
		{
			throw new NotImplementedException();
		}

		public CtRatingViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public CtRatingViewModel GetBysId(string keyword)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}

		public void Update(CtRatingViewModel ratingVm)
		{
			throw new NotImplementedException();
		}
	}
}
