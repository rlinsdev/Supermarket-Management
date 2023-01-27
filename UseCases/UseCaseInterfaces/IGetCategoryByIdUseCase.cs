using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public interface IGetCategoryByIdUseCase
	{
		ICategoryRepository CategoryRepository { get; }

		Category Execute(int categoryId);
	}
}