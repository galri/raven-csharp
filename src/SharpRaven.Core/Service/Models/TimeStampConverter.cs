using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpRaven.Core.Service.Models
{
    /// <summary>
    /// https://stackoverflow.com/questions/18635599/specifying-a-custom-datetime-format-when-serializing-with-json-net
    /// </summary>
    class TimeStampConverter : IsoDateTimeConverter
    {
        public TimeStampConverter()
        {
            base.DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        }
    }
}
