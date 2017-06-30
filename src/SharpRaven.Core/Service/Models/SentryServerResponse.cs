using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// https://docs.sentry.io/clientdev/overview/#reading-the-response
    /// </summary>
    public class SentryServerResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
