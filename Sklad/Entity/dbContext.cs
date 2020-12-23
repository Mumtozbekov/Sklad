using Sklad.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sklad.Entity
{
    class dbContext:DbContext
    {
        //   public static string EfCacheDirPath = Environment.CurrentDirectory;
        public dbContext() : base("SkladDB")
        {
            Database.SetInitializer<dbContext>(new CreateDatabaseIfNotExists<dbContext>());
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
        }
       
        public DbSet<Tovar> tovari { get; set; }
    }
}
