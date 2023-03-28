using System.Reflection.Metadata;
using RestSharp;
using RPFramework.Core.Utils;

namespace RPFramework.Core
{
    public class RestSharpClientFactory
    {
        public static RestClient RestSharpReportPortalClient => new RestClient(Constants.ReportPortalBaseUrl);
    }
}