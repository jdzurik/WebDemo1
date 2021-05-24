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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                if (System.Configuration.ConfigurationManager.ConnectionStrings["Demo1_dbo_ConStr"] != null) { optionsBuilder.UseSqlServer(System.Configuration.ConfigurationManager.ConnectionStrings["Demo1_dbo_ConStr"].ConnectionString); } else optionsBuilder.UseSqlServer("Data Source=99.133.184.235;Initial Catalog=Demo1;User Id=DemoUser;Password=DemoPass123;Connect Timeout=120;");
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

