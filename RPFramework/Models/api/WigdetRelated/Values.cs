using Newtonsoft.Json;

namespace RPFramework.Models.api.WigdetRelated
{
    public class Values
    {
        [JsonProperty("statistics$executions$total")]
        public string StatisticsExecutionsTotal { get; set; }

        public string delta { get; set; }
    }
}