using System.ServiceModel;
using System.ServiceModel.MsmqIntegration;
using Acme.Shared.Contracts;

namespace Acme.OrderProcessor.Interfaces
{
    [ServiceContract]
    [ServiceKnownType(typeof(Order))]
    public interface IOrderInboundMessageHandlerService
    {
        [OperationContract(IsOneWay = true, Action = "*")]
        void ProcessIncomingMessage(MsmqMessage<Order> incomingOrderMessage);
    }
}
