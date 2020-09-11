using ERCTestTusk.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCTestTusk.Manage
{
    public interface IFileManager
    {
        public List<File> GetAllFiles();
        public void AddFile(File file);
        public List<File> GetFileByDate(DateTime dateFilter);
    }
}
