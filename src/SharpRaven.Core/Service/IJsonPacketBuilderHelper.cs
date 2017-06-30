using System;
using System.Collections.Generic;
using System.Text;

using SharpRaven.Core.Data;
using SharpRaven.Core.Service.Models;

namespace SharpRaven.Core.Service
{
    public interface IJsonPacketBuilderHelper
    {
        void HelpBuildEvent(JsonPacket packet);
    }
}
