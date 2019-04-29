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
	public class LoaiSPService : ILoaiSPService
	{
		private IRepository<Loaisp, int> _repository;
		private IUnitOfWork _unitOfWork;

		public LoaiSPService(IRepository<Loaisp, int> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public LoaispViewModel Add(LoaispViewModel loaispVm)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<LoaispViewModel> GetAll()
		{
			var query = _repository.FindAll();
			var data = new List<LoaispViewModel>();
			foreach (var item in query)
			{
				var _data = Mapper.Map<Loaisp, LoaispViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public List<LoaispViewModel> GetAll(string keyword)
		{
			throw new NotImplementedException();
		}
		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}
		public LoaispViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public LoaispViewModel GetBysId(string keyword)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}

		public void Update(LoaispViewModel loaispVm)
		{
			throw new NotImplementedException();
		}
	}
}
