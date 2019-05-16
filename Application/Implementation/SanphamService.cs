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

		public SanphamViewModel Add(SanphamViewModel sanphamVm)
		{
			var sp = Mapper.Map<SanphamViewModel, Sanpham>(sanphamVm);
			_repository.AddReturn(sp);
			sanphamVm.KeyId = sp.KeyId;
			//sanphamVm.Id = _convertFunction.Instance.Create_Code(true, sp.KeyId,
			//CommonConstants.defaultLengthNumberCode, const_AddressbookType.Employee);
			//sp.Id = HP_EmployeeVm.Id;
			//employee.UserBy.IsEmployee = true;
			_unitOfWork.Commit();
			return sanphamVm;
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<SanphamViewModel> GetAll()
		{
			var query = _repository.FindAll(x=>x.NccNavigation);
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
			var query = _repository.FindAll().OrderBy(x => x.KeyId);
			var data = new List<SanphamViewModel>();
			foreach (var item in query)
			{
				var _data = Mapper.Map<Sanpham, SanphamViewModel>(item);
				data.Add(_data);
			}
			return data;
		}

		public void Dispose()
		{
			GC.SuppressFinalize(this);
		}

		public SanphamViewModel GetById(int id)
		{
			//var data = _repository.FindById(id, p => p.UserBy.WardFKNavigation, p => p.LastupdatedBy, p => p.UserBy, p => p.DepartmentFkNavigation, p => p.PositionFkNavigation);
			var data = _repository.FindById(id);
			return Mapper.Map<Sanpham, SanphamViewModel>(data);
		}

        public NccViewModel GetThongtinNguoiban()
        {
            //var data = _repository.FindById(id, p => p.UserBy.WardFKNavigation, p => p.LastupdatedBy, p => p.UserBy, p => p.DepartmentFkNavigation, p => p.PositionFkNavigation);
            //var data = _repository.FindById(id);
            //return Mapper.Map<Ncc, NccViewModel>(data);
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

		public void Update(SanphamViewModel sanphamVm)
		{
			var sp = Mapper.Map<SanphamViewModel, Sanpham>(sanphamVm);

			_repository.Update(sp);
		}
	}
}
