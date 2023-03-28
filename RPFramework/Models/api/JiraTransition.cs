using Newtonsoft.Json;

namespace RPFramework.Models.api
{
    public class JiraTransition
    {
        [JsonProperty("transition")] public Transition Transition { get; set; }
    }

    public class Transition
    {
        [JsonProperty("id")] public string Id { get; set; }
    }
}