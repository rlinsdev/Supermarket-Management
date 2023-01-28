using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class ViewProductsByCategory : IViewProductsByCategory
	{
		private readonly IProductRepository productRepository;

		public ViewProductsByCategory(IProductRepository ProductRepository)
		{
			productRepository = ProductRepository;
		}
		public IEnumerable<Product> Execute(int categoryId)
		{
			return productRepository.GetProductsByCategory(categoryId);
		}
	}
}
