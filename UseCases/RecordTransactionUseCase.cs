using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
	public class RecordTransactionUseCase : IRecordTransactionUseCase
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

		public void Execute(string cashierName, int productId, int qty)
		{
			var product = getProductByIdUseCase.Execute(productId);
			transactionRepository.Save(cashierName, productId, product.Price.Value, product.Quantity.Value, qty);
		}
	}
}
