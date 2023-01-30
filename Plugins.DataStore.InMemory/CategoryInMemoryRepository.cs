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
				new Category {CategoryId = 2, Name = "Bakery", Description = "Bakery" },
				new Category {CategoryId = 3, Name = "Meat", Description = "Meat" },
			};
		}

		public void AddCategory(Category category)
		{
			//if (categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
			if (categories.Any(x => x.Name.ToLower() == category.Name.ToLower()))
				return;

			if (categories != null && categories.Count > 0)
			{
				var maxId = categories.Max(x => x.CategoryId);
				category.CategoryId = maxId + 1;
			}
			else
			{
				category.CategoryId = 1;
			}
			categories.Add(category);
		}

		public IEnumerable<Category> GetCategories()
		{
			return categories;
		}

		public void UpdateCategory(Category category)
		{
			var categoryToUpdate = GetCategoryById(category.CategoryId);
			if (categoryToUpdate != null)
			{
				categoryToUpdate.Name = category.Name;
				categoryToUpdate.Description = category.Description;
			}
		}

		public Category GetCategoryById(int categoryId)
		{
			return categories?.FirstOrDefault(x => x.CategoryId == categoryId);
		}

		public void DeleteCategory(int categoryId)
		{
			categories?.Remove(GetCategoryById(categoryId));
		}
	}
}
