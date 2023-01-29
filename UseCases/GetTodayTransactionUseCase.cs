using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class GetTodayTransactionUseCase : IGetTodayTransactionUseCase
	{
		public GetTodayTransactionUseCase(ITransactionRepository transactionRepository)
		{
			TransactionRepository = transactionRepository;
		}

		public ITransactionRepository TransactionRepository { get; }

		public IEnumerable<Transaction> Execute(string cashierName)
		{
			return TransactionRepository.GetByDay(cashierName, DateTime.Now);
		}
	}
}
