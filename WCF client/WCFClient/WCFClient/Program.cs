using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bpf.Security.Common;
using Bpf.Common.Exceptions;
using System.ServiceModel;
using System.ServiceModel.Description;
using Bpf.Common.Service;


namespace WCFClient
{
    class Program
    {
        public static void DoLogin()
        {
            UserPassCredential credential = new UserPassCredential();
            credential.userName = "sancor";
            credential.password = "PortalProductores";

            AuthenticationServiceClient client = new AuthenticationServiceClient();
            try
            {
                ContextInformationInspector behavior = new ContextInformationInspector();
                client.Endpoint.Behaviors.Add((IEndpointBehavior)behavior);

                AuthenticatedToken token = client.LogInUserPass(credential);
                TokenManager.Instance.LoadToken(token);
                client.Close();
            }
            catch (Exception ex)
            {
                client.Abort();
            }
        }

        static void Main(string[] args)
        {
            DoLogin();


            PolicyServiceClient client = new PolicyServiceClient();
            ContextInformationInspector behavior = new ContextInformationInspector();
            client.Endpoint.Behaviors.Add((IEndpointBehavior)behavior);
            
            SST.PortalProd.AdmCartera.Common.Entities.Currency[] currencies = client.GetCurrencyList();

            System.Console.In.ReadLine();
        }
    }
}
