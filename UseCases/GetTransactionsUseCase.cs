using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class GetTransactionsUseCase : IGetTransactionsUseCase
	{
		private readonly ITransactionRepository transactionRepository;

		public IEnumerable<Transaction> Execute(string cashierName, DateTime startDate, DateTime endDate)
		{
			return transactionRepository.Search(cashierName, startDate, endDate);
		}

		public GetTransactionsUseCase(ITransactionRepository transactionRepository)
		{
			this.transactionRepository = transactionRepository;
		}
	}
}
