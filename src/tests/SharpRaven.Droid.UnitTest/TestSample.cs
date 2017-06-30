using System;
using NUnit.Framework;

using SharpRaven.Data;

namespace SharpRaven.Droid.UnitTest
{
    [TestFixture]
    public class TestsSample
    {

        [SetUp]
        public void Setup() { }


        [TearDown]
        public void Tear() { }

        [Test]
        public void TrySend()
        {
            var ravenClient = new RavenClient("https://af83be3545d249c5a4f59553bc6dea60:97f0ca1e45604460a2702344fe9ec060@sentry.io/159585");
            ravenClient.Capture(new SentryEvent(new ArgumentException("Test")));
        }
    }
}