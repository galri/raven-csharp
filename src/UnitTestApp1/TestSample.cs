using System;
using NUnit.Framework;
using SharpRaven;

namespace UnitTestApp1
{
    [TestFixture]
    public class TestsSample
    {
        [Test]
        public void Pass()
        {
            Sentry.Init(new SharpRaven.Core.Dsn(""));
            Sentry.Capture(new NullReferenceException("test"));
        }
    }
}