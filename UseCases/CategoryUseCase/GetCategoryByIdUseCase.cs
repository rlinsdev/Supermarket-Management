using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class GetCategoryByIdUseCase : IGetCategoryByIdUseCase
	{
		public ICategoryRepository CategoryRepository { get; }

		public GetCategoryByIdUseCase(ICategoryRepository categoryRepository)
		{
			CategoryRepository = categoryRepository;
		}

		public Category Execute(int categoryId)
		{
			return CategoryRepository.GetCategoryById(categoryId);

		}
	}
}
