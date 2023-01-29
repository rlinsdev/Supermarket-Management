using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public interface IGetTodayTransactionUseCase
	{
		ITransactionRepository TransactionRepository { get; }

		IEnumerable<Transaction> Execute(string cashierName);
	}
}