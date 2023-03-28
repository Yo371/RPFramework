using Newtonsoft.Json;

namespace RPFramework.Models.api
{
    public class SlackMessage
    {
        [JsonProperty("text")] public string Text { get; set; }
    }
}