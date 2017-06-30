using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Data
{
    public interface IEventBuilderHelper
    {
        /// <summary>
        /// Adds data to event.
        /// </summary>
        /// <param name="event"></param>
        void helpBuildingEvent(SentryEventBuilder @event);
    }
}
