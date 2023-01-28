using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class EditProductUseCase : IEditProductUseCase
	{
		private readonly IProductRepository productRepository;

		public EditProductUseCase(IProductRepository ProductRepository)
		{
			productRepository = ProductRepository;
		}

		public void Execute(Product product)
		{
			productRepository.Update(product);

		}
	}
}
