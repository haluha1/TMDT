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
		private IRepository<Rating, int> _repository;
		private IUnitOfWork _unitOfWork;

		public RatingService(IRepository<Rating, int> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public RatingViewModel Add(RatingViewModel ratingVm)
		{
			var rating = Mapper.Map<RatingViewModel, Rating>(ratingVm);
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

		public List<RatingViewModel> GetAll()
		{
			var query = _repository.FindAll();
			var data = new List<RatingViewModel>();
			foreach (var item in query)
			{
				var _data = Mapper.Map<Rating, RatingViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public List<RatingViewModel> GetAll(string keyword)
		{
			throw new NotImplementedException();
		}

		public RatingViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public RatingViewModel GetBysId(string keyword)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}

		public void Update(RatingViewModel ratingVm)
		{
			throw new NotImplementedException();
		}
	}
}
