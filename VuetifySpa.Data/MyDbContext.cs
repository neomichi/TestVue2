using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using VuetifySpa.Data.Model;
using VuetifySpa.Data.Models;


namespace VuetifySpa.Data
{



    public class MyDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>

    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
            

        }



        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);
            builder.HasPostgresExtension("uuid-ossp");
            builder.Entity<Car>().HasIndex(u => u.Title).IsUnique();

            base.OnModelCreating(builder);





            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<ApplicationRole>().ToTable("Roles");


            


            //select uuid_generate_v4();

            //WTF????
            //var converter = new ValueConverter<string, Guid>(
            //   v => new Guid(v),
            //   v => v.ToString(),
            //   new ConverterMappingHints(valueGeneratorFactory: (p, t) => new GuidStringGenerator()));

            //builder.Entity<Car>().Property(e => e.Id).HasConversion(converter);
        }
    }

    //https://github.com/aspnet/EntityFrameworkCore/issues/11867
    //public class GuidStringGenerator : ValueGenerator<string>
    //{
    //    private readonly SequentialGuidValueGenerator _guidGenerator
    //        = new SequentialGuidValueGenerator();

    //    public override string Next(EntityEntry entry)
    //        => _guidGenerator.Next(entry).ToString();

    //    public override bool GeneratesTemporaryValues
    //        => false;
    //}
}
