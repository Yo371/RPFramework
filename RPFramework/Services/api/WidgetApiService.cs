using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using RPFramework.Models.api.WigdetRelated;

namespace RPFramework.Services.api
{
    public class WidgetApiService
    {
        private readonly RestClient _client;

        public WidgetApiService(RestClient client)
        {
            _client = client;
            _client.Authenticator =
                new OAuth2AuthorizationRequestHeaderAuthenticator("...", "Bearer");
        }
        
        public Widget GetWidget(Widget widget)
        {
            var restRequest = new RestRequest($"/v1/TestProject/widget/{widget.id}");
            var restResponse =  _client.Execute(restRequest, Method.Get);

            return JsonConvert.DeserializeObject<Widget>(restResponse.Content);
        }
        
        public RestResponse PostWidget(Widget widget)
        {
            var restRequest = new RestRequest("/v1/TestProject/widget");
            restRequest.AddJsonBody(widget);
            var restResponse = _client.Execute(restRequest, Method.Post);
            
            widget.id = JsonConvert.DeserializeObject<Widget>(restResponse.Content).id;

            return restResponse;
        }
        
        public RestResponse DeleteWidget(Widget widget)
        {
            var request = new RestRequest($"/v1/TestProject/dashboard/14/{widget.id}");
            return _client.Execute(request, Method.Delete);
        }
        
        public RestResponse UpdateWidget(Widget widget)
        {
            var request = new RestRequest($"/v1/TestProject/widget/{widget.id}");
            
            request.AddJsonBody(widget);
            return _client.Execute(request, Method.Put);
        }
    }
}