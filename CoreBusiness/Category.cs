using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CoreBusiness
{
	public class Category
	{
		public int CategoryId { get; set; }
		[Required]
		public string Name { get; set; }

		public string Description { get; set; }

		// Navigation propert to EF
		public List<Product> Products { get; set; }
	}
}
