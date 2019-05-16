using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.Interfaces
{
    public interface ICtGiohangService:IDisposable
    {
        CtGiohangViewModel Add(CtGiohangViewModel loaispVm);

        void Update(CtGiohangViewModel loaispVm);

        void Delete(int id);

        List<CtGiohangViewModel> GetAll();

        List<CtGiohangViewModel> GetAll(string keyword);

        CtGiohangViewModel GetBysId(string keyword);

        CtGiohangViewModel GetById(int id);


        bool Save();
    }
}
