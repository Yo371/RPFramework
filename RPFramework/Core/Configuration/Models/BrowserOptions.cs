﻿using Newtonsoft.Json;

namespace RPFramework.Core.Configuration.Models
{
    public class BrowserOptions
    {
        [JsonProperty(nameof(BrowserType))]
        public string BrowserType { get; set; }

        [JsonProperty(nameof(PageLoadTimeOutMs))]
        public int PageLoadTimeOutMs { get; set; }

        [JsonProperty(nameof(AsyncJsTimeoutMs))]
        public int AsyncJsTimeoutMs { get; set; }

        [JsonProperty(nameof(ImplicitWaitTimeOutMs))]
        public int ImplicitWaitTimeOutMs { get; set; }

        [JsonProperty(nameof(SeleniumGridAddress))]
        public string SeleniumGridAddress { get; set; }
    }
}