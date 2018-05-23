using LaGuineuData;
using LaGuineuService.Services;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LaGuineuApi.Handlers
{
    public class AuthorizationHandler : DelegatingHandler
    {
        public string Key { get; set; }
        ITokenService tokenService = new TokenService();

        public AuthorizationHandler()
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            var tsc = new TaskCompletionSource<HttpResponseMessage>();
            tsc.SetResult(response);
            if (request.RequestUri.Segments[request.RequestUri.Segments.Length - 1] != "login")
            {
                if(request.Headers.Authorization != null)
                {
                    var aux = tokenService.DecodingToken(request.Headers.Authorization.Parameter);
                    if (aux.GetType() == "".GetType())
                    {
                        return tsc.Task;
                    }
                    else
                    {
                        Token token = (Token)aux;
                        request.Properties.Add("token", token);
                        return base.SendAsync(request, cancellationToken);
                    }
                }
                else
                {
                    return tsc.Task;
                }
            }
            else
            {
                return base.SendAsync(request, cancellationToken);
            }
        }

    }
}
