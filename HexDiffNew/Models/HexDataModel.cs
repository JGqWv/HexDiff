using System.Collections.ObjectModel;
using System.Numerics;

namespace HexDiffNew.Models
{
    public class HexDataModel
    {
        public struct HexData
        {
            public required byte DataBytes { get; set; }
            public required uint Addr { get; set; }
        }

        public required Collection <HexData> HexDataCollection { get; set; }
       
    }
}
