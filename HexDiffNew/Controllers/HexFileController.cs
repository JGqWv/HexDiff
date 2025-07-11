using HexDiffNew.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;

namespace HexDiffNew.Controllers
{
    public class HexFileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Open(IFormFile file1)
        {
            //var hexfile = new HexFileModel { FileName = file1.FileName, DataBytes = ReadFile(file1) };
            var hexFile1 = new HexFileModel { FileName = file1.FileName, HexDataCollection = ReadFileToCollection(file1)};


            return View("Results", hexFile1);
        }

        //[HttpPost]
        //public IActionResult Save()
        //{
        //    return View();
        //}

        [HttpPost]
        public IActionResult Save(HexFileModel model )
        {
            if(model == null||model.HexDataCollection==null||string.IsNullOrEmpty(model.FileName))
            {
                return BadRequest("Invalid data or file name");
            }

            var bytes = model.HexDataCollection.Select(h=>h.DataBytes).ToArray();

            var fileName = Path.GetFileName(model.FileName);
            //if(!fileName.EndsWith(".hex", StringComparison.OrdinalIgnoreCase))
            //{
            //    fileName += ".hex";
            //}

            return File(bytes, "application/octet-stream", fileName);

            //return View("Index");
        }

        //[HttpPost]
        //public IActionResult Edit(HexData hexData)
        //{

        //}

        private Collection<HexData> ReadFileToCollection(IFormFile file)
        {
           
            using var stream = new MemoryStream();

           file.CopyTo(stream);
            uint index = 0;
            Collection<HexData> hexDatas = new Collection<HexData>();
            foreach (byte item in stream.ToArray()) /// maybe we dont need second convertion
            {
                hexDatas.Add(new HexData {Addr=index, DataBytes  = item});
                index++;
            }
            return hexDatas;
        }

        private byte[] ReadFile(IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }
    }
}
