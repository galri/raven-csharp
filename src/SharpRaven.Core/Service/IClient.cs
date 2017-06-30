using SharpRaven.Core.Service.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SharpRaven.Core.Service
{
    public interface IClient
    {
        Task<SentryServerResponse> SendAsync(JsonPacket packet);
    }
}
