using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class RecordTransactionUseCase
	{
		private readonly ITransactionRepository transactionRepository;
		private readonly IGetProductByIdUseCase getProductByIdUseCase;

		public RecordTransactionUseCase(
			ITransactionRepository TransactionRepository,
			IGetProductByIdUseCase GetProductByIdUseCase)
		{
			transactionRepository = TransactionRepository;
			getProductByIdUseCase = GetProductByIdUseCase;
		}

		public void Execute(int productId, int qty)
		{
			var price = getProductByIdUseCase.Execute(productId).Price;
			transactionRepository.Save(productId, price, qty);
		}
	}
}
