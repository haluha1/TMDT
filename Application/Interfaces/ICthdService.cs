using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICthdService : IDisposable
    {
        CthdViewModel Add(CthdViewModel hoadonVm);

        void Update(CthdViewModel hoadonVm);

        void Delete(int id);

        List<CthdViewModel> GetAll();

        List<CthdViewModel> GetAll(string keyword);

        CthdViewModel GetBysId(string keyword);

        CthdViewModel GetById(int id);
        List<CthdViewModel> GetAllByInvoiceId(int invoiceId);

        bool Save();
    }
}
