using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class ViewCategoriesUseCase : IViewCategoriesUseCase
	{
		public ViewCategoriesUseCase(ICategoryRepository categoryRepository)
		{
			CategoryRepository = categoryRepository;
		}

		public ICategoryRepository CategoryRepository { get; }

		public IEnumerable<Category> Execute()
		{
			return CategoryRepository.GetCategories();
		}
	}
}
