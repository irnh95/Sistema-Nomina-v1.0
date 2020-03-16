using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<Employee<int>, IdentityRole<int>, int>
    {
        //DbSets
        public DbSet<Employee<int>> Employees { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
            modelBuilder.Entity<Employee<int>>().ToTable("Employee");
            modelBuilder.Entity<IdentityRole<int>>().ToTable("Role");
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
