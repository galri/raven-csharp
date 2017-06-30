using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// https://docs.sentry.io/clientdev/interfaces/user/
    /// </summary>
    /// <remarks>
    /// extra fields can be added by extending class, may be processed by sentry
    /// </remarks>
    public class User
    {
        [JsonProperty(PropertyName = "email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        
        [JsonProperty(PropertyName = "id", NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        
        [JsonProperty(PropertyName = "ip_address", NullValueHandling = NullValueHandling.Ignore)]
        public string IpAddress { get; set; }
        
        [JsonProperty(PropertyName = "username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }
        
    }
}
