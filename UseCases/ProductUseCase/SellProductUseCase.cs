using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class SellProductUseCase : ISellProductUseCase
	{
		private readonly IProductRepository productRepository;
		private readonly IRecordTransactionUseCase recordTransactionUseCase;

		public SellProductUseCase(
			IProductRepository productRepository,
			IRecordTransactionUseCase recordTransactionUseCase)
		{
			this.productRepository = productRepository;
			this.recordTransactionUseCase = recordTransactionUseCase;
		}

		public void Execute(string cashiername, int productId, int qtyToSell)
		{
			var product = productRepository.GetProductById(productId);
			if (product == null) return;
			product.Quantity -= qtyToSell;
			productRepository.Update(product);
			recordTransactionUseCase.Execute(cashiername,productId, qtyToSell);
		}
	}
}
