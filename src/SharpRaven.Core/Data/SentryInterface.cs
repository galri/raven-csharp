using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Data
{
    /**
     * A SentryInterface is an additional structured data that can be provided with a message.
     */
    public interface ISentryInterface
    {
        String InterfaceName { get; }
    }
}
