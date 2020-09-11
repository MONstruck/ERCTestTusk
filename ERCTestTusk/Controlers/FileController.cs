using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ERCTestTusk.Context;
using ERCTestTusk.Manage;
using Microsoft.AspNetCore.Mvc;

namespace ERCTestTusk.Controlers
{
    public class FileController : Controller
    {

        private readonly IFileManager _fileManager;

        public FileController(IFileManager fileManager)
        {
            _fileManager = fileManager;
        }

        public ActionResult Index()
        
        {
            return View();
        }
        
        public IActionResult ExportToXML(string dateFilter)
        {
            List<File> fileList = new List<File>();
            if (string.IsNullOrEmpty(dateFilter))
            {
                fileList = _fileManager.GetAllFiles();
            }
            else {
                DateTime newDate = DateTime.Parse(dateFilter);
                fileList = _fileManager.GetFileByDate(newDate);             
            }

            if (fileList.Count == 0 )
            {
                return new JsonResult("");
            }
            var branchesXml = new XElement("Files",
                            from file in fileList
                            select new XElement("File",

                new XAttribute("NumberFile", file.FileId),

                new XElement("FileName", file.FileName),

                new XElement("DateCreate", file.DateCreateFile)
                ));

            var stringXML = branchesXml.ToString();

            return new JsonResult(stringXML);
        }
    }
}
