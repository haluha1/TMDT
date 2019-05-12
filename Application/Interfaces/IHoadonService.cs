using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHoadonService :IDisposable
    {
        HoadonViewModel Add(HoadonViewModel hoadonVm);

        void Update(HoadonViewModel hoadonVm);

        void Delete(int id);

        List<HoadonViewModel> GetAll();

        List<HoadonViewModel> GetAll(string keyword);

        HoadonViewModel GetBysId(string keyword);

        HoadonViewModel GetById(int id);


        bool Save();
    }
}
