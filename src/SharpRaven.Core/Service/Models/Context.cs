using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SharpRaven.Core.Service.Models
{
    public class Context
    {
        [JsonProperty("device")]
        public Device Device { get; set; } = new Device();

        [JsonProperty("os")]
        public Os Os { get; set; } = new Os();

        [JsonProperty("runtime")]
        public Runtime Runtime { get; set; } = new Runtime();
    }

    public class Device
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("family")]

        public string Family { get; set; }

        [JsonProperty("model")]

        public string Model { get; set; }

        [JsonProperty("model_id")]

        public string ModelId { get; set; }

        [JsonProperty("arch")]

        public string Architecture { get; set; }

        [JsonProperty("battery_level")]

        public string BaterryLevel { get; set; }

        [JsonProperty("orientation")]

        public string Orientation { get; set; }
    }

    public class Os
    {

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]

        public string Version { get; set; }

        [JsonProperty("build")]

        public string Build { get; set; }

        [JsonProperty("kernel_version")]

        public string KernelVersion { get; set; }

        [JsonProperty("rooted")]
        public string Rooted { get; set; }
    }

    public class Runtime
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}
