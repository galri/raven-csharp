using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// https://docs.sentry.io/clientdev/attributes/
    /// </summary>
    public class Sdk
    {
        [JsonProperty("name")]
        public string Name { get; set; } = "SharpRaven";

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("integrations")]
        public List<string> Integrations { get; set; }

        public Sdk()
        {
            Version = GetType().Assembly.GetName().Version.ToString();
        }
    }
}
