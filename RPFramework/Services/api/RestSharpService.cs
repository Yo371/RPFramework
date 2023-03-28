using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators.OAuth2;

namespace RPFramework.Services.api
{
    public class RestSharpService
    {
        private readonly RestClient _client;

        public RestSharpService(RestClient client)
        {
            _client = client;
            _client.Authenticator =
                new OAuth2AuthorizationRequestHeaderAuthenticator("...", "Bearer");
        }
        
        public RestResponse PerformPostRequest(
            string fullUrl,
            Dictionary<string, string> headers = null,
            Dictionary<string, string> parameters = null)
        {
            var client = new RestClient(fullUrl);
            var request = new RestRequest();
            if (headers != null)
            {
                foreach(var header in headers)
                {
                    request.AddHeader(header.Key, header.Value);
                }
            }
            if (headers != null)
            {
                foreach(var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value);
                }
            }
            var response = client.Post(request);
            return response;
        }
    }
}