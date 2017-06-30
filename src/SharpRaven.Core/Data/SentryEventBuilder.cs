using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpRaven.Core.Data
{
    public class SentryEventBuilder
    {
        private SentryEvent _event;

        private const string DefaultPlatform = ".Net";
        private const string DefaultHostName = ".Net";

        public List<IEventBuilderHelper> BuildHelpers { get; internal set; }

        public SentryEventBuilder() : this(new SentryEvent(Guid.NewGuid()))
        {

        }

        public SentryEventBuilder(SentryEvent @event)
        {
            _event = @event;
        }

        /// <summary>
        /// Sets default values for each field that hasn't been provided manually.
        /// </summary>
        private void autoSetMissingValues()
        {
            // Ensure that a timestamp is set (to now at least!)
            if (_event.timestamp == null)
            {
                _event.timestamp = DateTime.Now;
            }

            // Ensure that a platform is set
            if (string.IsNullOrWhiteSpace(_event.platform))
            {
                _event.platform = DefaultPlatform;
            }
            
            // Ensure that a hostname is set
            if (string.IsNullOrWhiteSpace(_event.serverName))
            {
                _event.serverName = DefaultHostName;
            }

            // Ensure that an SDK is set
            //    if (_event.sdk== null) {
            //        event.setSdk(new Sdk(SentryEnvironment.SDK_NAME, SentryEnvironment.SDK_VERSION,
            //            sdkIntegrations));
            //}
        }

        public SentryEvent Build()
        {
            foreach (var buildhelper in BuildHelpers)
            {
                buildhelper.helpBuildingEvent(this);
            }

            autoSetMissingValues();

            return _event;
        }

        internal SentryUser GetEventUser()
        {
            if (_event.User == null)
            {
                _event.User = new SentryUser("");
            }

            return _event.User;
        }

        public void SetEventMessage(string message)
        {
            _event.message = message;
        }

        public void SetEventLevel(SentryEvent.Level level)
        {
            _event.level = level;
        }

        public void SetEventTimestamp(DateTime timestamp)
        {
            _event.timestamp = timestamp;
        }

        /// <summary>
        /// Sets application distribution version in the event.
        /// </summary>
        /// <param name="dist"></param>
        /// <returns></returns>
        public void SetEventDist(String dist)
        {
            _event.dist = dist;
        }
        /// <summary>
        ///Sets application environment in the event.
        /// </summary>
        public void SetEventEnviroment(String environment)
        {
            _event.environment = environment;
        }
        public void SetEventLogger(String logger)
        {
            _event.logger = logger;
        }

        public void SetEventPlatform(String platform)
        {
            _event.platform = platform;
        }

        //public void SetSdkIntegration(String integration)
        //{
        //    _event.sdk += integration;
        //}

        //public EventBuilder withCulprit(SentryStackTraceElement frame)
        //{
        //    return withCulprit(buildCulpritString(frame.getModule(), frame.getFunction(),
        //        frame.getFileName(), frame.getLineno()));
        //}


        //public EventBuilder withCulprit(StackTraceElement frame)
        //{
        //    return withCulprit(buildCulpritString(frame.getClassName(), frame.getMethodName(),
        //        frame.getFileName(), frame.getLineNumber()));
        //}

        //private String buildCulpritString(String className, String methodName, String fileName, int lineNumber)
        //{
        //    StringBuilder sb = new StringBuilder();

        //    sb.append(className)
        //        .append(".")
        //        .append(methodName);

        //    if (fileName != null && !fileName.isEmpty())
        //    {
        //        sb.append("(").append(fileName);
        //        if (lineNumber >= 0)
        //        {
        //            sb.append(":").append(lineNumber);
        //        }
        //        sb.append(")");
        //    }

        //    return sb.toString();
        //}

        //public EventBuilder withCulprit(String culprit)
        //{
        //    event.setCulprit(culprit);
        //    return this;
        //}



        /// <summary>
        ///Adds a tag to an event.
        ///This allows to set a tag value in different contexts.
        /// </summary>
        /// <param name="tagKey"></param>
        /// <param name="tagValue"></param>
        public void SetEventTag(String tagKey, String tagValue)
        {
            _event.tags.Add(tagKey, tagValue);
        }
        
        public void SetEventBreadcrumbs(List<Breadcrumb> breadcrumbs)
        {
                _event.breadcrumbs.AddRange(breadcrumbs);
        }

        public void SetEVentContext(Dictionary<String, Dictionary<String, Object>> contexts)
        {
             _event.contexts = contexts;
        }

        public void withServerName(String serverName)
        {
            _event.serverName = serverName;
        }
        
        public void SetEventExtra(String extraName, Object extraValue)
        {
            _event.extra.Add(extraName, extraValue);
        }
        
     
        public void withFingerprint(params String[] fingerprint)
        {
            _event.fingerprint = fingerprint.ToList();
        }

    //public EventBuilder withSentryInterface(SentryInterface sentryInterface)
    //{
    //    return withSentryInterface(sentryInterface, true);
    //}


    //public EventBuilder withSentryInterface(SentryInterface sentryInterface, boolean replace)
    //{
    //    if (replace || !event.getSentryInterfaces().containsKey(sentryInterface.getInterfaceName())) {
    //        event.getSentryInterfaces().put(sentryInterface.getInterfaceName(), sentryInterface);
    //    }
    //    return this;
    //}
    }
}
