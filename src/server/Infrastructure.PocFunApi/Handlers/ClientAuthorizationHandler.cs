using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Infrastructure.PocFunApi.Messages;
using Infrastructure.PocFunApi.Utilities;

namespace Infrastructure.PocFunApi.Handlers
{
    public class ClientAuthorizationHandler : DelegatingHandler
    {
        private string _tokenHeader = "PF-Api-Token";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if(!request.Headers.Contains(_tokenHeader))
                return FailedResponse();

            var token = request.Headers.GetValues(_tokenHeader).FirstOrDefault();

            if (string.IsNullOrEmpty(token))
                return FailedResponse();

            var clientAuthorizationRequest = new TokenValidationRequest();
            clientAuthorizationRequest.IpAddress = GetClientIp(request);
            clientAuthorizationRequest.Token = token;

            var tokenService = new TokenServiceProxy();

            if (!tokenService.TokenIsValid(clientAuthorizationRequest))
                return FailedResponse();

            return base.SendAsync(request, cancellationToken);
        }

        private Task<HttpResponseMessage> FailedResponse()
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized)
                {
                    Content = new StringContent("Sorry, bro.  You know you can't see me!")
                };

            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);

            return tsc.Task;
        }

        private string GetClientIp(HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey("MS_HttpContext"))
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;

            if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name))
            {
                RemoteEndpointMessageProperty prop;
                prop = (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }

            return null;
        }
    }
}