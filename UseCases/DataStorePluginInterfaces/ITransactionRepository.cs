using CoreBusiness;
using System;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
	public interface ITransactionRepository
	{
		public IEnumerable<Transaction> Get();
		public IEnumerable<Transaction> GetByDay(DateTime date);
		public void Save(string casherName, int productId, double? price, int qty);
	}
}
