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
using System.IO;
using System.Linq;
using System.Net;

using SharpRaven.Core.Utilities;
using SharpRaven.Core.Data;
using SharpRaven.Core.Service;
using System.Threading.Tasks;

using Newtonsoft.Json;

using SharpRaven.Core.Config;
using SharpRaven.Core.Service.Models;

namespace SharpRaven.Core
{
    /// <summary>
    /// The Raven Client, responsible for capturing exceptions and sending them to Sentry wif options from config.
    /// </summary>
    public class RavenClient : IRavenClient
    {
        public RavenClient(IConfig config)
        {
            if (config == null)
                throw new ArgumentNullException(nameof(config));

            Config = config;
            PacketFactory = new DefaultPacketFactory();
        }

        public IConfig Config { get; internal set; }

        public IJsonPacketFactory PacketFactory { get; internal set; }
        
        public async Task<SentryServerResponse> CaptureAsync(System.Exception ex)
        {
            var sentryEvent = new SentryEvent(ex);
           return await CaptureAsync(sentryEvent);
        }

        public async Task<SentryServerResponse> CaptureAsync(SentryEvent @event)
        {
            var client = new SentryHttpClient(Config);
            var packet = PacketFactory.Create(@event);
            return await client.SendAsync(packet);
        }
    }
}