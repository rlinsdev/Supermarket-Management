using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public interface IViewCategoriesUseCase
	{
		ICategoryRepository CategoryRepository { get; }

		IEnumerable<Category> Execute();
	}
}