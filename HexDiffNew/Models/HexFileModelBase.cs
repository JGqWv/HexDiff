using System.Collections.ObjectModel;

namespace HexDiffNew.Models
{
    public class HexFileModelBase
    {

        public struct HexData
        {
            public required byte DataBytes { get; set; }
            public required uint Addr { get; set; }
        }

        public required Collection<HexData> HexDataCollection { get; set; }

    }
}