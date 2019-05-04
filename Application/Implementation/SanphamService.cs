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
	public class SanphamService : ISanphamService
	{
		private IRepository<Sanpham, int> _repository;
		private IUnitOfWork _unitOfWork;

		public SanphamService(IRepository<Sanpham, int> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public SanphamViewModel Add(SanphamViewModel loaispVm)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<SanphamViewModel> GetAll()
		{
			var query = _repository.FindAll();
			var data = new List<SanphamViewModel>();
			foreach (var item in query)
			{
				var _data = Mapper.Map<Sanpham, SanphamViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public List<SanphamViewModel> GetAll(string keyword)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public SanphamViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public SanphamViewModel GetBysId(string keyword)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}

		public void Update(SanphamViewModel loaispVm)
		{
			throw new NotImplementedException();
		}
	}
}
