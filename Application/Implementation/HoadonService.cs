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
    public class HoadonService : IHoadonService
    {
        private IRepository<Hoadon, int> _repository;
        private IUnitOfWork _unitOfWork;

        public HoadonService(IRepository<Hoadon, int> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public HoadonViewModel Add(HoadonViewModel hoadonVm)
        {
            var hd = Mapper.Map<HoadonViewModel, Hoadon>(hoadonVm);
            _repository.AddReturn(hd);
			hd.mahd = hd.KeyId;
            hoadonVm.KeyId = hd.KeyId;
			hoadonVm.mahd = hd.KeyId;
			//sanphamVm.Id = _convertFunction.Instance.Create_Code(true, sp.KeyId,
			//CommonConstants.defaultLengthNumberCode, const_AddressbookType.Employee);
			//sp.Id = HP_EmployeeVm.Id;
			//employee.UserBy.IsEmployee = true;
			return hoadonVm;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<HoadonViewModel> GetAll()
        {
            var query = _repository.FindAll(x=>x.Cthdons).OrderBy(x => x.KeyId);
            var data = new List<HoadonViewModel>();
            foreach (var item in query)
            {
                var _data = Mapper.Map<Hoadon, HoadonViewModel>(item);
                data.Add(_data);
            }
            return data;
        }

        public List<HoadonViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public HoadonViewModel GetById(int id)
        {
			var data = _repository.FindById(id);
			return Mapper.Map<Hoadon, HoadonViewModel>(data);
		}

        public HoadonViewModel GetBysId(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _unitOfWork.Commit();
        }

        public void Update(HoadonViewModel hoadonVm)
        {
			var sp = Mapper.Map<HoadonViewModel, Hoadon>(hoadonVm);

			_repository.Update(sp);
		}
    }
}
