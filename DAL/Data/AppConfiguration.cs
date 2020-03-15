using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DAL.Data
{
    class AppConfiguration
    {
        public AppConfiguration()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");

            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(path, false);

            IConfigurationRoot root = configurationBuilder.Build();
            IConfigurationSection appSettings = root.GetSection("ConnectionStrings:DefaultConnection");

            sqlConnectionString = appSettings.Value;
        }
        public string sqlConnectionString { get; set; }
    }
}
