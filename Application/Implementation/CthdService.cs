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
    public class CthdService: ICthdService
    {
        private IRepository<Cthd, int> _repository;
        private IUnitOfWork _unitOfWork;

        public CthdService(IRepository<Cthd, int> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }


        public CthdViewModel Add(CthdViewModel hoadonVm)
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

        public List<CthdViewModel> GetAll()
        {
            var query = _repository.FindAll();
            var data = new List<CthdViewModel>();
            foreach (var item in query)
            {
                var _data = Mapper.Map<Cthd, CthdViewModel>(item);
                data.Add(_data);
            }
            return data;
        }

        public List<CthdViewModel> GetAllByInvoiceId(int invoiceId)
        {
            var query = _repository.FindAll(x => x.mahd== invoiceId);
           
            var data = new List<CthdViewModel>();
            foreach (var item in query)
            {
                var _data = Mapper.Map<Cthd, CthdViewModel>(item);
                data.Add(_data);
            }
            return data;
        }

        public List<CthdViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public CthdViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CthdViewModel GetBysId(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _unitOfWork.Commit();
        }

        public void Update(CthdViewModel hoadonVm)
        {
            throw new NotImplementedException();
        }
    }
}
