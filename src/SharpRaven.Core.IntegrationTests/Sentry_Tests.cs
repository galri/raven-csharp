using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

namespace SharpRaven.Core.IntegrationTests
{

    [TestFixture]
    public class Sentry_Tests : TestBase
    {
        [Test]
        public async Task Send_test()
        {
            Sentry.Init(Dsn);
            try
            {
                throw new DivideByZeroException();
            }
            catch (Exception exception)
            {
                var response = await Sentry.Capture(exception);
                Assert.IsNotNull(response);
            }
        }
    }
}
