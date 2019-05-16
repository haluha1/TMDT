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
    public class GiatinService : IGiatinService
    {
        private IRepository<Giatin, int> _repository;
        private IUnitOfWork _unitOfWork;

        public GiatinService(IRepository<Giatin, int> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public List<GiatinViewModel> GetAll()
        {
            var query = _repository.FindAll();
            var data = new List<GiatinViewModel>();
            foreach (var item in query)
            {
                var _data = Mapper.Map<Giatin, GiatinViewModel>(item);
                data.Add(_data);
            }
            return data;
        }

        public bool Save()
        {
            return _unitOfWork.Commit();
        }
    }
}
