using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using RPFramework.Models.api.DashboardRelated;
using RPFramework.Models.api.WigdetRelated;

namespace RPFramework.Services.api
{
    public class DashBoardApiService
    {
        private readonly RestClient _client;

        public DashBoardApiService(RestClient client)
        {
            _client = client;
            _client.Authenticator =
                new OAuth2AuthorizationRequestHeaderAuthenticator("...", "Bearer");
        }

        public Dashboard GetDashboard(Dashboard dashboard)
        {
            var restRequest = new RestRequest($"/v1/TestProject/dashboard/{dashboard.Id}");
            var restResponse = _client.Execute(restRequest, Method.Get);

            return JsonConvert.DeserializeObject<Dashboard>(restResponse.Content);
        }

        public RestResponse PostDashboard(Dashboard dashboard)
        {
            var restRequest = new RestRequest("/v1/TestProject/dashboard");
            restRequest.AddJsonBody(dashboard);
            var restResponse = _client.Execute(restRequest, Method.Post);
            var jObj = JObject.Parse(restResponse.Content);

            dashboard.Id = (int)jObj.SelectToken("id")?.Value<int>();

            return restResponse;
        }
        
        public RestResponse DeleteDashboard(Dashboard dashboard)
        {
            var request = new RestRequest($"/v1/TestProject/dashboard/{dashboard.Id}");
            return _client.Execute(request, Method.Delete);
        }
        
        public RestResponse UpdateDashboard(Dashboard dashboard)
        {
            var request = new RestRequest($"/v1/TestProject/dashboard/{dashboard.Id}");
            
            request.AddJsonBody(dashboard);
            return _client.Execute(request, Method.Put);
        }
        
        
    }
}
