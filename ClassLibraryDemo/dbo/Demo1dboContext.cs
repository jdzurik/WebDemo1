using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClassLibraryDemo.dbo
{
    public partial class Demo1dboContext : DbContext
    {
        public Demo1dboContext()
        {
        }

        public Demo1dboContext(DbContextOptions<Demo1dboContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TestTable1> TestTable1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                if (System.Configuration.ConfigurationManager.ConnectionStrings["Demo1_dbo_ConStr"] != null) { optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["Demo1_dbo_ConStr"].ConnectionString); } 
                else optionsBuilder.UseSqlServer("Data Source=data01;Initial Catalog=Demo1;User Id=DemoUser;Password=DemoPass321;Connect Timeout=120;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TestTable1>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.InsertDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

