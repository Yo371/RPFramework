using RestSharp;
using RPFramework.Models.api;

namespace RPFramework.Services.api
{
    public static class SlackApiService
    {
        public static RestResponse SendMessage(string text)
        {    var client = new RestClient("https://hooks.slack.com/services/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");
            var request = new RestRequest();

            request.AddJsonBody(new SlackMessage()
            {
                Text = text
            });
            
            var response = client.Post(request);
            return response;
        }
    }
}