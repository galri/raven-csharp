#region License

// Copyright (c) 2014 The Sentry Team and individual contributors.
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
//     1. Redistributions of source code must retain the above copyright notice, this list of
//        conditions and the following disclaimer.
// 
//     2. Redistributions in binary form must reproduce the above copyright notice, this list of
//        conditions and the following disclaimer in the documentation and/or other materials
//        provided with the distribution.
// 
//     3. Neither the name of the Sentry nor the names of its contributors may be used to
//        endorse or promote products derived from this software without specific prior written
//        permission.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR
// IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
// DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY,
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// Represents the JSON packet that is transmitted to Sentry.
    /// see https://docs.sentry.io/clientdev/attributes/ for more info
    /// </summary>
    public class JsonPacket
    {
        [JsonProperty("event_id")]
        public string Id { get; set; } = Guid.NewGuid().ToString("n");

        /// <remarks>
        /// Must use utcnow, now is rejected even if formatted correctly when later then now, because of time check server side
        /// https://forum.sentry.io/t/discarded-invalid-value-for-parameter-timestamp/1410/5
        /// </remarks>
        [JsonProperty("timestamp")]
        [JsonConverter(typeof(TimeStampConverter))]
        public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

        [JsonProperty("logger")]
        public string LoggerName { get; set; } = "default";

        [JsonProperty("platform")]
        public string Platform { get; set; } = "csharp";

        [JsonProperty("sdk")]
        public Sdk Sdk { get; set; } = new Sdk();

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("culprit")]
        public string Culprint { get; set; }

        [JsonProperty("server_name")]
        public string ServerName { get; set; }

        [JsonProperty("release")]
        public string Release { get; set; }

        [JsonProperty("tags")]
        public Dictionary<string,string> Tags { get; set; } 

        [JsonProperty("environment")]
        public string Environment { get; set; }

        [JsonProperty("modules")]
        public Dictionary<string,string> Modules { get; set; } 

        [JsonProperty("extra")]
        public Dictionary<string,object> Extra { get; set; } 

        [JsonProperty("fingerprint", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FingerPrints { get; set; }

        [JsonProperty("exception")]
        public List<Exception> Exception { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("contexts")]
        public Context Context { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
    }
}
