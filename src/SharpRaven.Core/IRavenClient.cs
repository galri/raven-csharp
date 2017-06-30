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
using System.Threading.Tasks;

using SharpRaven.Core.Data;
using SharpRaven.Core.Config;
using SharpRaven.Core.Service.Models;

namespace SharpRaven.Core
{
    /// <summary>
    /// Raven client interface.
    /// </summary>
    public interface IRavenClient
    {
        /// <summary>
        /// Gets or sets the <see cref="Action"/> to execute to manipulate or extract data from
        /// the <see cref="Requester"/> object before it is used in the <see cref="RavenClient.Send"/> method.
        /// </summary>
        /// <value>
        /// The <see cref="Action"/> to execute to manipulate or extract data from the
        /// <see cref="Requester"/> object before it is used in the <see cref="RavenClient.Send"/> method.
        /// </value>
        //Func<Requester, Requester> BeforeSend { get; set; }

        /// <summary>
        /// Logger. Default is "root"
        /// </summary>
        //string Logger { get; set; }

        /// <summary>
        /// Interface for providing a 'log scrubber' that removes
        /// sensitive information from exceptions sent to sentry.
        /// </summary>
        //IScrubber LogScrubber { get; set; }

        IConfig Config { get; }

        /// <summary>
        /// Captures the <see cref="Breadcrumb"/> for tracking.
        /// </summary>
        /// <param name="breadcrumb">The <see cref="Breadcrumb" /> to capture.</param>
        //void AddTrail(Breadcrumb breadcrumb);

        /// <summary>
        /// Restart the capture of the <see cref="Breadcrumb"/> for tracking.
        /// </summary>
        //void RestartTrails();
        
        /// <summary>Captures the specified <paramref name="event"/>.</summary>
        /// <param name="event">The event to capture.</param>
        /// <returns>
        /// The <see cref="JsonPacket.Id" /> of the successfully captured <paramref name="event" />, or <c>null</c> if it fails.
        /// </returns>
        //string Capture(SentryEvent @event);

        /// <summary>Captures the event.</summary>
        /// <param name="event">The event to capture.</param>
        /// <returns>
        /// The <see cref="JsonPacket.Id" /> of the successfully captured <paramref name="event" />, or <c>null</c> if it fails.
        /// </returns>
        Task<SentryServerResponse> CaptureAsync(SentryEvent @event);
    }
}