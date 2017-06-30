using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Data
{
    public class SentryEvent
    {
        public Exception CapturedException { get; set; }

        public Guid id { get; internal set; }

        /// <summary>
        /// User-readable representation of this event.
        /// </summary>
        public String message { get; internal set; }

        /// <summary>
        /// Exact time when the logging occurred.
        /// </summary>
        public  DateTime timestamp { get; internal set; }

        /// <summary>
        /// The record severity.
        /// </summary>
        public Level level { get; internal set; }

        /// <summary>
        /// The name of the logger which created the record.
        /// </summary>
        public String logger { get; internal set; }

        /// <summary>
        /// A string representing the currently used platform (java/python).
        /// </summary>
        public String platform { get; internal set; }

        /// <summary>
        /// An  instance representing the version and integrations used to send the event.
        /// </summary>
        //TODO: private Sdk sdk; 

        /// <summary>
        /// Function call which was the primary perpetrator of this event.
        /// </summary>
        public String culprit { get; internal set; }

        /// <summary>
        /// A map or list of tags for this event. Automatically created with a Map that is made unmodifiable by the { @link EventBuilder }.
        /// </summary>
        public Dictionary<String, String> tags { get; internal set; } =  new Dictionary<string, string>();

        /// <summary>
        /// List of Breadcrumb objects related to the event.
        /// </summary>
        public List<Breadcrumb> breadcrumbs { get; internal set; } = new List<Breadcrumb>();

        /// <summary>
        /// Map of map of context objects related to the event.
        /// </summary>
        public Dictionary<String, Dictionary<String, Object>> contexts { get; internal set; } = new Dictionary<String, Dictionary<String, Object>>();

        /// <summary>
        /// Identifies the version of the application.
        /// </summary>
        public String release { get; internal set; }

        /// <summary>
        /// Identifies the distribution of the application.
        /// </summary>
        public String dist { get; internal set; }

        /// <summary>
        /// Identifies the environment the application is running in.
        /// </summary>
        public String environment { get; internal set; }

        /// <summary>
        /// Identifies the host client from which the event was recorded.
        /// </summary>
        public String serverName { get; internal set; }

        /// A map or list of additional properties for this event.
        /// Automatically created with a Map that is made unmodifiable by the {@link EventBuilder}.
        /// This transient map may contain objects which aren't serializable. They will be automatically be taken care of
        /// by {@link #readObject(ObjectInputStream)} and {@link #writeObject(ObjectOutputStream)}.
        public Dictionary<String, Object> extra { get; internal set; } = new Dictionary<String, Object>();

        /// <summary>
        /// Event fingerprint, a list of strings used to dictate the deduplicating for this event.
        /// </summary>
        public List<String> fingerprint { get; internal set; }

        /// <summary>
        /// Checksum for the event, allowing to group events with a similar checksum.
        /// </summary>
        public String checksum { get; internal set; }
        public SentryUser User { get; internal set; }


        /// Additional interfaces for other information and metadata.
        /// Automatically created with a Map that is made unmodifiable by the {@link EventBuilder}.
        public Dictionary<String, ISentryInterface> sentryInterfaces = new Dictionary<String, ISentryInterface>();


        public SentryEvent(Exception ex)
            : this(Guid.NewGuid())
        {
            CapturedException = ex;
        }

        /// Creates a new Event (should be called only through {@link EventBuilder} with the specified identifier.@param id unique identifier of the event.
        internal SentryEvent(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            this.id = id;
        }


        //    private void readObject(ObjectInputStream stream)
        //        throws IOException, ClassNotFoundException {
        //        stream.defaultReadObject();
        //        extra = (Map<String, Object>) stream.readObject();
        //}

        //private void writeObject(ObjectOutputStream stream)
        //        throws IOException
        //{
        //    stream.defaultWriteObject();
        //    stream.writeObject(convertToSerializable(extra));
        //}

        /**
         * Returns a serializable Map (HashMap) with the content of the parameter Map.
         * <p>
         * Serializable objects are kept as is in the Map, while the non serializable ones are converted into string
         * using the {@code toString()} method.
         *
         * @param objectMap original Map containing various Objects.
         * @return A serializable map which contains only serializable entries.
         */
        //CHECKSTYLE.OFF: IllegalType
        //private static HashMap<String, ? super Serializable> convertToSerializable(Map<String, Object> objectMap)
        //{
        //    HashMap < String, ? super Serializable> serializableMap = new HashMap<>(objectMap.size());
        //    for (Map.Entry<String, Object> objectEntry : objectMap.entrySet())
        //    {
        //        if (objectEntry.getValue() instanceof Serializable) {
        //        serializableMap.put(objectEntry.getKey(), (Serializable)objectEntry.getValue());
        //    } else {
        //        serializableMap.put(objectEntry.getKey(), objectEntry.getValue().toString());
        //    }
        //}
        //        return serializableMap;
        //    }
        //CHECKSTYLE.ON: IllegalType

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            return id.Equals(((SentryEvent)obj).id);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override String ToString()
        {
            return "Event{"
                + "level=" + level
                + ", message='" + message + '\''
                + ", logger='" + logger + '\''
                + '}';
        }

        /// <summary>
        /// Levels of log available in Sentry.
        /// </summary>
        public enum Level
        {
            /// <summary>
            /// Fatal is the highest form of log available, use it for unrecoverable issues.
            /// </summary>
            FATAL,

            /// <summary>
            /// Error denotes an unexpected behaviour that prevented the code to work properly.
            /// </summary>
            ERROR,

            /// <summary>
            ///  Warning should be used to define logs generated by expected and handled bad behaviour.
            /// </summary>
            WARNING,

            /// <summary>
            /// Info is used to give general details on the running application, usually only messages.
            /// </summary>
            INFO,

            /// <summary>
            /// Debug information to track every detail of the application execution process.
            /// </summary>
            DEBUG
        }
    }
}
