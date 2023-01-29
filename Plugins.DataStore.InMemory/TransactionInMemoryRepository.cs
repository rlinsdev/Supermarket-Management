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

		public IEnumerable<Transaction> Get(string cashierName)
		{
			if (string.IsNullOrEmpty(cashierName))
				return transactions;
			return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
		}

		public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
		{
			if (string.IsNullOrEmpty(cashierName))								 
				return transactions;
			return transactions.Where(x => x.TimeStamp.Date == date.Date &&
				string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
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
