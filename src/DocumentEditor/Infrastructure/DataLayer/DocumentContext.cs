using DocumentEditor.Infrastructure.DataLayer.Configurations;
using DocumentEditor.Models;
using System.Data.Entity;

namespace DocumentEditor.Infrastructure.DataLayer
{
    public class DocumentContext : DbContext
    {
        public DocumentContext() : base("name=DocumentDB")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DocumentConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}