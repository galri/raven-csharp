using SharpRaven.Core.Data;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using SharpRaven.Core.Config;
using SharpRaven.Core.Service.Models;

using Exception = System.Exception;

namespace SharpRaven.Core
{
    public static class Sentry
    {
        private static RavenClient client;

        public static RavenClient Client => client;


        public static void Init(Dsn dns)
        {
            var config = new TempConfig { CurrentDsn = dns };
            client = new RavenClient(config);
        }

        public static async Task<SentryServerResponse> Capture(SentryEvent sEvent)
        {
            return await Client.CaptureAsync(sEvent);
        }

        public static async Task<SentryServerResponse> Capture(Exception ex)
        {
            var eb = new SentryEvent(ex);
            return await Capture(eb);
        }
    }
}
