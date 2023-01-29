using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
	public interface ITransactionRepository
	{
		public IEnumerable<Transaction> Get(string cashierName);
		public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date);
		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate);
		public void Save(string casherName, int productId, Product product, int soldQty);
	}
}
