using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Config
{
    public interface IConfig
    {
        /// <summary>
        /// Enable Gzip Compression?
        /// </summary>
        bool Compression { get; set; }

        /// <summary>
        /// The Dsn currently being used to log exceptions.
        /// </summary>
        Dsn CurrentDsn { get; set; }

        /// <summary>
        /// The environment (e.g. production)
        /// </summary>
        string Environment { get; set; }

        /// <summary>
        /// Not register the <see cref="Breadcrumb"/> for tracking.
        /// </summary>
        bool IgnoreBreadcrumbs { get; set; }

        /// <summary>
        /// Release.
        /// </summary>
        //string Release { get; set; }

        /// <summary>
        /// Default tags
        /// </summary>
        IReadOnlyDictionary<string, string> Tags { get; }

        /// <summary>
        /// Gets or sets the timeout value in milliseconds for the <see cref="System.Net.HttpWebRequest.GetResponse()"/>
        /// and <see cref="System.Net.HttpWebRequest.GetRequestStream()"/> methods.
        /// </summary>
        /// <value>
        /// The number of milliseconds to wait before the request times out. The default is 5,000 milliseconds (5 seconds).
        /// Valid values: a nonnegative integer or <see cref="System.Threading.Timeout.Infinite"/>
        /// </value>
        TimeSpan Timeout { get; set; }
    }
}
