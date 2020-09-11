using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERCTestTusk.Context
{
    public class FileContext : DbContext 
    {

        public FileContext()
        { }
        public FileContext(DbContextOptions<FileContext> options) : base(options)
        { }
        public virtual DbSet<File> Files { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP - L4P4V05; Database = FileDb; User Id = login; password = qwerty12; Trusted_Connection = True; MultipleActiveResultSets = true; ");
            }
        }

    }
}
