using HexDiffNew.Models;
using Microsoft.AspNetCore.Mvc;

namespace HexDiffNew.Controllers
{
    public class DiffController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Compare(IFormFile file1, IFormFile file2)
        //{
        //    var hexFile1 = new HexFileModel { FileName = file1.FileName, DataBytes = ReadFile(file1) };
        //    var hexFile2 = new HexFileModel { FileName = file2.FileName, DataBytes = ReadFile(file2) };

        //    var differences = FindDifferences(hexFile1.DataBytes, hexFile2.DataBytes);
            
        //    return View("Results", differences);
        //}

        private byte[] ReadFile(IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }

        /// <summary>
        /// Return List with differences in hex files
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <returns></returns>
        private List<HexDifference> FindDifferences(byte[] file1, byte[] file2)
        {
            var differences = new List<HexDifference>();
            int minLength = Math.Min(file1.Length, file2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (file1[i] != file2[i])
                    differences.Add(new HexDifference
                    {
                        Offset = i,
                        File1Byte = file1[i],
                        File2Byte = file2[i]
                    });
            }

            return differences;
        }
    }

}

