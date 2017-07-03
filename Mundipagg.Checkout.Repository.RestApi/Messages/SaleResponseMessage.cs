using System;
using System.Collections.Generic;
using System.Text;

namespace Mundipagg.Checkout.Repository.RestApi.Messages
{
    public class SaleResponseMessage
    {
		public object ErrorReport { get; set; }
		public int InternalTime { get; set; }
		public string MerchantKey { get; set; }
		public string RequestKey { get; set; }
		public List<object> BoletoTransactionResultCollection { get; set; }
		public string BuyerKey { get; set; }
		public List<CreditCardTransactionResultCollectionClass> CreditCardTransactionResultCollection { get; set; }
		public OrderResultClass OrderResult { get; set; }

		public class CreditCard
		{
			public string CreditCardBrand { get; set; }
			public string InstantBuyKey { get; set; }
			public bool IsExpiredCreditCard { get; set; }
			public string MaskedCreditCardNumber { get; set; }
		}

		public class CreditCardTransactionResultCollectionClass
		{
			public string AcquirerMessage { get; set; }
			public string AcquirerName { get; set; }
			public string AcquirerReturnCode { get; set; }
			public string AffiliationCode { get; set; }
			public int AmountInCents { get; set; }
			public string AuthorizationCode { get; set; }
			public int AuthorizedAmountInCents { get; set; }
			public int CapturedAmountInCents { get; set; }
			public string CapturedDate { get; set; }
			public CreditCard CreditCard { get; set; }
			public string CreditCardOperation { get; set; }
			public string CreditCardTransactionStatus { get; set; }
			public object DueDate { get; set; }
			public int ExternalTime { get; set; }
			public string PaymentMethodName { get; set; }
			public object RefundedAmountInCents { get; set; }
			public bool Success { get; set; }
			public string TransactionIdentifier { get; set; }
			public string TransactionKey { get; set; }
			public string TransactionKeyToAcquirer { get; set; }
			public string TransactionReference { get; set; }
			public string UniqueSequentialNumber { get; set; }
			public object VoidedAmountInCents { get; set; }
		}

		public class OrderResultClass
		{
			public string CreateDate { get; set; }
			public string OrderKey { get; set; }
			public string OrderReference { get; set; }
		}
	}
}
