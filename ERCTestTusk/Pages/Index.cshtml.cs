using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ERCTestTusk.Context;
using ERCTestTusk.Manage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ERCTestTusk.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IFileManager _fileManager;

        public IndexModel(ILogger<IndexModel> logger,
            IFileManager fileManager)
        {
            _logger = logger;
            _fileManager = fileManager;
        }

        public List<File> fileModels { get; set; }
        public File file { get; set; }
        public IActionResult OnGet()
        {
            fileModels = GetAllRecords();
            return Page();
        }
        public IActionResult OnPost(File file)
        {
            _fileManager.AddFile(file);

            fileModels = GetAllRecords();
            return Page();
        }

        public List<File> GetAllRecords()
        {
            var files = _fileManager.GetAllFiles();
            if (files == null)
            {
                File emptyRecord = new File()
                {
                    FileId = 0,
                    DateCreateFile = DateTime.Now,
                    FileName = "----------"
                };
                fileModels.Add(emptyRecord);
            }
            return files;
        }
    }
}