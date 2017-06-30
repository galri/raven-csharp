using NUnit.Framework;
using SharpRaven.Core.Config;
using SharpRaven.Core.Service;
using SharpRaven.Core.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRaven.Core.IntegrationTests
{
    [TestFixture]
    public class Serialization_send : TestBase
    {
        [Test]
        public async Task Serialize_and_send_with_minimum_attributes()
        {
            var packet = new JsonPacket();
            var client = GetClient();
            var serverResponse = await client.SendAsync(packet);
            Assert.IsNotNull(serverResponse);
        }

        [Test]
        public async Task Serialize_and_send_with_all_attributes()
        {
            var packet = new JsonPacket
            {
                Culprint = "Serialize_and_send_with_all_attributes",
                ServerName = "testest",
                Release = "1.0.4",
                Message = "my message",
            };
            packet.Tags = new Dictionary<string, string> { { "tag1", "tavalue1" }, { "tag2", "tagvalue2" } };
            packet.Environment = "Production";
            packet.Modules = new Dictionary<string, string> { { "modules1", "module1version" }, { "modules2", "module2version" } };
            packet.Extra = new Dictionary<string, object> { { "extra1", "extra1value" }, { "extra2", "extra2value" } };
            packet.FingerPrints = new List<string> { "daasd" };
            var client = GetClient();
            var serverResponse = await client.SendAsync(packet);
            Assert.IsNotNull(serverResponse);
        }

        [Test]
        public async Task Serialize_and_send_with_interface_context()
        {
            var packet = new JsonPacket
            {
                Culprint = "Serialize_and_send_with_interface_context",
            };

            //Environment.Version;
            //var runtimeInfo = PlatformServices.Default.Application.RuntimeFramework;
            packet.Context = new Context
            {
                Runtime =
                {
                    Version = "rutnimeversion",
                    Name = "rutnimename"
                },
                Device =
                {
                    Name = "navn",
                    Architecture = "architecture",
                    BaterryLevel = "baterrylevel",
                    Family = "fam",
                    Model = "model",
                    ModelId = "modelid",
                    Orientation = "orientation"
                },
                Os =
                {
                    Name = "name",
                    Build = "build",
                    KernelVersion = "kernel",
                    Rooted = "rooted",
                    Version = "version"
                }
            };



            var client = GetClient();
            var serverResponse = await client.SendAsync(packet);
            Assert.IsNotNull(serverResponse);
        }

        [Test]
        public async Task Serialize_and_send_with_interface_user()
        {
            var packet = new JsonPacket
            {
                User = new User
                {
                    Id = "id",
                    Email = "test@test.com",
                    IpAddress = "127.0.0.1",
                    Username = "testuser"
                }
            };

            var client = GetClient();
            var serverResponse = await client.SendAsync(packet);
            Assert.IsNotNull(serverResponse);
        }
    }
}
