using System;
using System.Collections.Generic;
using System.Text;
using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Sistema_Nomina_v1._0.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee, IdentityRole<int>, int>
    {
        //DbSets
        public DbSet<Employee> Employees { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        /// <summary>
        /// Changes made to the models before the creation.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("EmployeeRole");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserToken");
        }


        /// <summary>
        /// set configuration
        /// </summary>
        public class OptionsBuild
        {
            public OptionsBuild()
            {
                appConfiguration = new AppConfiguration();
                
                optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                optionsBuilder.UseSqlServer(appConfiguration.sqlConnectionString);

                options = optionsBuilder.Options;
            }
            public DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder { get; set; }
            public DbContextOptions<ApplicationDbContext> options { get; set; }
            private AppConfiguration appConfiguration { get; set; }
        }
        public static OptionsBuild optionsBuild = new OptionsBuild();
    }
}
