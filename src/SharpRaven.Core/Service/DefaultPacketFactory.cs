using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using SharpRaven.Core.Data;
using SharpRaven.Core.Service.Models;

using Exception = SharpRaven.Core.Service.Models.Exception;

namespace SharpRaven.Core.Service
{
    class DefaultPacketFactory : IJsonPacketFactory
    {
        private static readonly Dictionary<string,string> modules = new Dictionary<string, string>();

        public List<IJsonPacketBuilderHelper> Helpers { get; } = new List<IJsonPacketBuilderHelper>();


        static DefaultPacketFactory()
        {
            GetMdoules();
        }

        public JsonPacket Create(SentryEvent sEvent)
        {
            var packet = new JsonPacket();

            switch (sEvent.level)
            {
                case SentryEvent.Level.FATAL:
                    packet.Level = "fatal";
                    break;
                case SentryEvent.Level.ERROR:
                    packet.Level = "error";
                    break;
                case SentryEvent.Level.WARNING:
                    packet.Level = "warning";
                    break;
                case SentryEvent.Level.INFO:
                    packet.Level = "info";
                    break;
                case SentryEvent.Level.DEBUG:
                    packet.Level = "debug";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //Attributes
            packet.Culprint = sEvent.culprit;
            packet.ServerName = sEvent.serverName;
            packet.Release = sEvent.release;
            packet.Tags = sEvent.tags;
            packet.Environment = sEvent.environment;
            packet.Modules = modules;
            packet.Extra = sEvent.extra;
            packet.FingerPrints = sEvent.fingerprint;
            packet.Message = sEvent.CapturedException?.Message;

            //interfaces
            packet.Exception = ExceptionFactory.Create(sEvent.CapturedException);
            //TODO:Message
            //TODO:stacktrace?
            //TODO:template?

            //TODO:breadcrumbs
            //TODO:context
            //TODO:http
            //TODO:threads
            //TODO:user

            //TODO:debug
            //TODO:repos
            //TODO:sdk

            foreach (var helper in Helpers)
            {
                helper.HelpBuildEvent(packet);
            }

            return packet;
        }


        private static void GetMdoules()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            foreach (var assembly in assemblies)
            {
                var version = assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute), false)
                   .OfType<AssemblyInformationalVersionAttribute>().SingleOrDefault()?.InformationalVersion;

                if (version == null)
                    version = assembly.GetCustomAttributes(typeof(AssemblyVersionAttribute), false)
                        .OfType<AssemblyVersionAttribute>().SingleOrDefault()?.Version;

                modules.Add(assembly.FullName,version);
            }
        }

    }
}
