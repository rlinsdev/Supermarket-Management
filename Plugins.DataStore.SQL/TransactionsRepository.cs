using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
	public class TransactionsRepository : ITransactionRepository
	{
		private readonly MarketContext db;

		public TransactionsRepository(MarketContext db)
		{
			this.db = db;
		}
		public IEnumerable<Transaction> Get(string cashierName)
		{
			if (string.IsNullOrEmpty(cashierName))
				return db.Transactions;
			//return db.Transactions.Where(x => string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
			return db.Transactions.Where(x => x.CashierName.ToLower() == cashierName.ToLower());
		}

		public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
		{
			if (string.IsNullOrEmpty(cashierName))
				return db.Transactions.Where(x => x.TimeStamp.Date == date.Date);
			return db.Transactions.Where(x => x.TimeStamp.Date == date.Date &&
				//string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
				x.CashierName.ToLower() == cashierName.ToLower());
		}

		public void Save(string casherName, int productId, Product product, int soldQty)
		{
			var tran = new Transaction {
				ProductId = product.ProductId,
				ProductName = product.Name,
				TimeStamp = DateTime.Now,
				Price  = product.Price,
				BeforeQty = product.Quantity.Value,
				SoldQty = soldQty,
				CashierName = casherName
			};

			db.Transactions.Add(tran);
			db.SaveChanges();
		}

		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
		{
			if (string.IsNullOrEmpty(cashierName))
				return db.Transactions.Where(x => x.TimeStamp.Date > startDate && x.TimeStamp < endDate.AddDays(1));

			return db.Transactions.Where(x => x.TimeStamp.Date > startDate && x.TimeStamp < endDate.AddDays(1) &&
				//string.Equals(x.CashierName, cashierName, StringComparison.OrdinalIgnoreCase));
				x.CashierName.ToLower() == cashierName.ToLower());
		}
	}
}
