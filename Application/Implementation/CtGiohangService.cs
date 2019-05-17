using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.ViewModels;
using Data.Entities;
using Infrastructure.Interfaces;

namespace Application.Implementation
{
    public class CtGiohangService : ICtGiohangService
    {
        private IRepository<CtGiohang, int> _repository;
        private IUnitOfWork _unitOfWork;

        public CtGiohangService(IRepository<CtGiohang, int> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public CtGiohangViewModel Add(CtGiohangViewModel loaispVm)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            _repository.Remove(id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<CtGiohangViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CtGiohangViewModel> GetAll(string keyword)
        {
            throw new NotImplementedException();
        }

        public CtGiohangViewModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public CtGiohangViewModel GetBysId(string keyword)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _unitOfWork.Commit();
        }

        public void Update(CtGiohangViewModel loaispVm)
        {
            throw new NotImplementedException();
        }
    }
}
