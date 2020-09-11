using ERCTestTusk.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCTestTusk.Manage
{
    public class FileManager : IFileManager
    {
        private readonly FileContext _FileContext;
        public FileManager(FileContext fileContext)
        {
            _FileContext = fileContext;
        }
        public List<File> GetAllFiles() {

            var files = _FileContext.Files.ToList();

            return files;
        }

        public List<File> GetFileByDate(DateTime dateFilter)
        {
            return _FileContext.Files.Where(_ => _.DateCreateFile.Date == dateFilter).ToList();
        }

        public void AddFile(File file)
        {
            _FileContext.Files.Add(file);
            _FileContext.SaveChanges();
        }
    }
}
