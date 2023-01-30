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
			//return transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
			return transactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower());
		}

		public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
		{
			if (string.IsNullOrEmpty(cashierName))
				return transactions.Where(x => x.TimeStamp.Date == date.Date);
			return transactions.Where(x => x.TimeStamp.Date == date.Date &&
				//string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
				x.CashierName.ToLower() == cashierName.ToLower());
		}

		public void Save(string cashierName, int productId, Product product, int soldQty)
		{
			int maxId = 0;
			if (transactions != null && transactions.Count > 0)
				maxId = transactions.Max(x => x.TransactionId);
			maxId++;

			transactions.Add(new Transaction
			{
				TransactionId = maxId,
				ProductId = productId,
				ProductName = product.Name,
				TimeStamp = DateTime.Now,
				Price = product.Price.Value,
				SoldQty = soldQty,
				BeforeQty = product.Quantity.Value,
				CashierName = cashierName
			});
		}

		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
		{
			if (string.IsNullOrEmpty(cashierName))
				return transactions.Where(x => x.TimeStamp.Date > startDate && x.TimeStamp < endDate.AddDays(1));

			return transactions.Where(x => x.TimeStamp.Date > startDate && x.TimeStamp < endDate.AddDays(1) &&
				//string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
				x.CashierName.ToLower() == cashierName.ToLower());
		}
	}
}
