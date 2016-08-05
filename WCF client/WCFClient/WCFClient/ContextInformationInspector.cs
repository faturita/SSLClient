using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Description;
using System.ServiceModel.Channels;
using WCFClient;

namespace Bpf.Common.Service
{
    public class ContextInformationInspector : IClientMessageInspector, IEndpointBehavior
    {
        #region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            /// agrego la informacion del contexto al header del mensaje
            object value = new ServiceContext();
            MessageHeader header;

            header = MessageHeader.CreateHeader("ContextInformation", "http://www.w3.org/BaufestProductivityFramework", value, false);
            request.Headers.Add(header);

            if (TokenManager.Instance.RetrieveToken() != null)
            {
                MessageHeader tokenHeader = MessageHeader.CreateHeader("TokenInformation", "http://www.w3.org/BaufestProductivityFramework",
                                                                        TokenManager.Instance.RetrieveToken(), false);
                request.Headers.Add(tokenHeader);
            }

            return null;
        }

        #endregion

        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add((IClientMessageInspector)this);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            
        }

        public void Validate(ServiceEndpoint endpoint)
        {
           
        }

        #endregion
    }
}
