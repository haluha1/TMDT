using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
	public class FunctionViewModel
	{
		public FunctionViewModel(Function function)
		{
			KeyId = function.KeyId;
			Name = function.Name;
			URL = function.URL;
			ParentId = function.ParentId;
			IconCss = function.IconCss;
		}

		public string KeyId { get; set; }
		public string Name { set; get; }
		public string URL { set; get; }
		public string ParentId { set; get; }

		public string IconCss { get; set; }
		public int SortOrder { set; get; }
	}
}
