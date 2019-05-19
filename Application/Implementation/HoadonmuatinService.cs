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
	public class HoadonmuatinService : IHoadonmuatinService
	{
		private IRepository<Hoadonmuatin, int> _repository;
		private IUnitOfWork _unitOfWork;

		public HoadonmuatinService(IRepository<Hoadonmuatin, int> repository, IUnitOfWork unitOfWork)
		{
			_repository = repository;
			_unitOfWork = unitOfWork;
		}

		public HoadonmuatinViewModel Add(HoadonmuatinViewModel hoadonVm)
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

		public List<HoadonmuatinViewModel> GetAll()
		{
			var query = _repository.FindAll(x => x.GiatinNavigation, x=>x.NccNavigation).OrderBy(x => x.KeyId);
			var data = new List<HoadonmuatinViewModel>();
			foreach (var item in query)
			{
				var _data = Mapper.Map<Hoadonmuatin, HoadonmuatinViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public List<HoadonmuatinViewModel> GetAll(string keyword)
		{
			throw new NotImplementedException();
		}

		public HoadonmuatinViewModel GetById(int id)
		{
			throw new NotImplementedException();
		}

		public HoadonmuatinViewModel GetBysId(string keyword)
		{
			throw new NotImplementedException();
		}

		public bool Save()
		{
			return _unitOfWork.Commit();
		}

		public void Update(HoadonmuatinViewModel hoadonVm)
		{
			throw new NotImplementedException();
		}
	}
}
