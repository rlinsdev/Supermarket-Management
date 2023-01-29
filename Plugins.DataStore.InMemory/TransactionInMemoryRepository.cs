using CoreBusiness;
using System;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;
using System.Linq;

namespace Plugins.DataStore.InMemory
{
	public class TransactionInMemoryRepository : ITransactionRepository
	{
		private List<Transaction> transactions;

		public TransactionInMemoryRepository()
		{
			transactions = new List<Transaction>();
		}


		public IEnumerable<Transaction> GetByDay(DateTime date)
		{
			throw new NotImplementedException();
		}

		public void Save(string cashierName, int productId, double? price, int qty)
		{
			int maxId = 0;
			if (transactions != null && transactions.Count > 0)
				maxId = transactions.Max(x => x.TransactionId);
			maxId++;

			transactions.Add(new Transaction
			{
				TransactionId = maxId,
				ProductId = productId,
				TimeStamp = DateTime.Now,
				Price = price,
				Qty = qty,
				CashierName = cashierName
			});
		}
	}
}
