using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
	public interface IViewProductsByCategory
	{
		IEnumerable<Product> Execute(int categoryId);
	}
}