using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Acme.Shared.Contracts;
using Acme.OrderProcessorWeb.Interfaces;

namespace Acme.OrderProcessorWeb
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single, ReleaseServiceInstanceOnTransactionComplete = false)]
    public class OrderInboundMessageHandlerService : IOrderInboundMessageHandlerService
    {
        #region IOrderInboundMessageHandlerService Members

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void ProcessIncomingMessage(MsmqMessage<Order> incomingOrderMessage)
        {
            var orderRequest = incomingOrderMessage.Body;
            var orderID = orderRequest.OrderID;
            var shipToAddress = orderRequest.ShipToAddress;
            var shipToCity = orderRequest.ShipToCity;
            var shipToCountry = orderRequest.ShipToCountry;
            var shipToZipCode = orderRequest.ShipToZipCode;
            var submittedOn = orderRequest.SubmittedOn;
        }

        #endregion
    }
}
