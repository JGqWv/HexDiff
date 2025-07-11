using System.Collections.ObjectModel;

namespace HexDiffNew.Models
{

    public class HexData    ///< changed to class, cause some stupid model binding cant understand structures
    {
        public byte DataBytes { get; set; }
        public uint Addr { get; set; }
    }
    public class HexFileModel
    {
        public required string FileName { get; set; }

        // change in collection of bytes and address for better changebility in controller

        public Collection<HexData>? HexDataCollection { get; set; }

        //public required uint Addr { get; set; }
        //public required byte[] DataBytes { get; set; }

    }
}
