using System.Collections.Generic;
using RestSharp;
using RPFramework.Core.Enums;
using RPFramework.Models.api;

namespace RPFramework.Services.api
{
    public class JiraApiService
    {
        public static void MoveJiraTicket(string ticketName, JiraStatus jiraStatus)
        {
            var url = $"https://testprotestpro.atlassian.net/rest/api/3/issue/{ticketName}/transitions";

            var headers = new Dictionary<string, string>()
            {
                { "Authorization", "Basic ..." },
                { "Content-Type", "application/json" }
            };

            var id = (int)jiraStatus;

            var jiraTransition = new JiraTransition()
            {
                Transition = new Transition()
                {
                    Id = id.ToString()
                }
            };

            PerformPostRequest(fullUrl: url, headers: headers, jiraTransition: jiraTransition);
        }
        
        private static RestResponse PerformPostRequest(
            string fullUrl, JiraTransition jiraTransition = null,
            Dictionary<string, string> headers = null,
            Dictionary<string, string> parameters = null
            )
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
            if (parameters != null)
            {
                foreach(var parameter in parameters)
                {
                    request.AddParameter(parameter.Key, parameter.Value);
                }
            }

            if (jiraTransition != null)
            {
                request.AddJsonBody(jiraTransition);
            }
            var response = client.Post(request);
            return response;
        }
    }
}