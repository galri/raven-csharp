using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// https://docs.sentry.io/clientdev/interfaces/stacktrace/
    /// </summary>
    public class StackTrace
    {
        [JsonProperty("frames")]
        public List<Frame> Frames { get; set; } = new List<Frame>();

        [JsonProperty("frames_omitted")]
        public List<int> FramesOmitted { get; set; } = new List<int>();
    }
}
