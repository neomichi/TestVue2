using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace VuetifySpa.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
    {       
        public MyDbContext CreateDbContext(string[] args)
        {

            var index = Directory.GetCurrentDirectory().Length - "VuetifySpa.Data".Length;
            var path = Directory.GetCurrentDirectory().Substring(0, index) + "VuetifySpa.Web";


            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();
            var builder = new DbContextOptionsBuilder<MyDbContext>();
            var connectionString = configuration.GetConnectionString("PostgreSQL");
            builder.UseNpgsql(connectionString);
            return new MyDbContext(builder.Options);
        }
    }
}
