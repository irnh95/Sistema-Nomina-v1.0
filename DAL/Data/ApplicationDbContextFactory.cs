using Sistema_Nomina_v1._0.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            AppConfiguration appConfiguration = new AppConfiguration();
            
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(appConfiguration.sqlConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
