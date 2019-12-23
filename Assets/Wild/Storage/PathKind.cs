using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wild.Storage
{
    public enum PathKind
    {
        Absolute = 0,
        RelativeStreamingAssets,
        RelativePersistentData
    }
}
