using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpRaven.Core.Config;
using SharpRaven.Core.Service;

namespace SharpRaven.Core.IntegrationTests
{
    public class TestBase
    {
        protected static  readonly Dsn Dsn = new Dsn("https://fc0977f53e6145ceb1c8173aa4b8df55:c3708fd5a68f443bbc7f77d312960e63@sentry.io/51300");

        protected static IClient GetClient()
        {
            var config = GetConfig();
            return new SentryHttpClient(config);
        }


        protected static IConfig GetConfig()
        {
            var config = new TempConfig
            {
                CurrentDsn = Dsn,
                Environment = "integration test"
            };
            return config;
        }
    }
    
}
