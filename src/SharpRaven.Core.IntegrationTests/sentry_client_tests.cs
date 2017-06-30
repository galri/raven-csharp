using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using SharpRaven.Core.Data;

namespace SharpRaven.Core.IntegrationTests
{
    [TestFixture]
    public class sentry_client_tests : TestBase
    {
        [Test]
        public async Task Send_simple()
        {
            var config = GetConfig();
            var client = new RavenClient(config);
            var se = new SentryEvent(Guid.NewGuid())
            {
                message = "Test",

            };
            var serverResponse = await client.CaptureAsync(se);

            Assert.IsNotNull(serverResponse);
        }
    }
}
