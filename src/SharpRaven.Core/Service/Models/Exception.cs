using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Service.Models
{
    public class Exception
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("module")]
        public string Assembly { get; set; }

        [JsonProperty("thread_id")]
        public string ThreadId { get; set; }

        [JsonProperty("stacktrace")]
        public StackTrace StackTrace { get; set; }
    }
}
