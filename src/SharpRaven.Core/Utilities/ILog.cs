using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Utilities
{
    /// <summary>
    /// Logger used by RavenClient to report status.
    /// </summary>
    interface ILog
    {
        void Error(string v);
    }
}
