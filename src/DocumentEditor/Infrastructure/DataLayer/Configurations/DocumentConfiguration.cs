using DocumentEditor.Models;
using System.Data.Entity.ModelConfiguration;

namespace DocumentEditor.Infrastructure.DataLayer.Configurations
{
    public class DocumentConfiguration : EntityTypeConfiguration<Document>
    {
        public DocumentConfiguration()
        {
            Property(doc => doc.Title)
                .HasMaxLength(255)
                .IsRequired();
        }
    }
}