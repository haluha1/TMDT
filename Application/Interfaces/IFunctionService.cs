using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
	public interface IFunctionService : IDisposable
	{
		FunctionViewModel Add(FunctionViewModel functionVm);

		void Update(FunctionViewModel functionVm);

		void Delete(int id);

		List<FunctionViewModel> GetAll();

		List<FunctionViewModel> GetAll(string keyword);

		FunctionViewModel GetBysId(string keyword);

		FunctionViewModel GetById(int id);


		bool Save();
	}
}
