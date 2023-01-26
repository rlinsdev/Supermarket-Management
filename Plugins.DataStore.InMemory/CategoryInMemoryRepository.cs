using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
	public class CategoryInMemoryRepository : ICategoryRepository
	{
		private List<Category> categories;
		public CategoryInMemoryRepository()
		{
			// MOCK Values
			categories = new List<Category>()
			{
				new Category {CategoryId = 1, Name = "Beverage", Description = "Beverage" },
				new Category {CategoryId = 1, Name = "Bakery", Description = "Bakery" },
				new Category {CategoryId = 1, Name = "Meat", Description = "Meat" },
			};
		}
		public IEnumerable<Category> GetCategories()
		{
			return categories;
		}
	}
}
