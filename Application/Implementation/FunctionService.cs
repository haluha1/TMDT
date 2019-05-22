using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using AutoMapper;
using Data.Entities;
using Infrastructure.Interfaces;

namespace Application.Implementation
{
	public class FunctionService : IFunctionService
	{
		private IRepository<Function, string> _repository;
		private IUnitOfWork _unitOfWork;

		public FunctionService(IRepository<Function, string> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public FunctionViewModel Add(FunctionViewModel functionVm)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public List<FunctionViewModel> GetAll()
		{
			var query = _repository.FindAll();
			var data = new List<FunctionViewModel>();
			foreach (var item in query)
			{
				FunctionViewModel _data = new FunctionViewModel(item);
				//var _data = Mapper.Map<Function, FunctionViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public List<FunctionViewModel> GetAll(string keyword)
		{
			throw new NotImplementedException();
		}

		public FunctionViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public FunctionViewModel GetBysId(string keyword)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}

		public void Update(FunctionViewModel functionVm)
		{
			throw new NotImplementedException();
		}
	}
}
