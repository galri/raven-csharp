using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Config
{
    class TempConfig : IConfig
    {
        public bool Compression { get; set; }

        public Dsn CurrentDsn { get ; set ; }

        public string Environment { get ; set ; }

        public bool IgnoreBreadcrumbs { get ; set; }

        public IReadOnlyDictionary<string, string> Tags { get; } = new Dictionary<string, string>();

        public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(5);
    }
}
