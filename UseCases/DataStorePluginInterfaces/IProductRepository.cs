using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetProducts();
		void AddProduct(Product product);
		void Update(Product product);
		Product GetProductById(int productId);
		void Delete(int productId);
		IEnumerable<Product> GetProductsByCategory(int categoryId);
	}
}
