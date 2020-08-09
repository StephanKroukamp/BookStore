using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Entities.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseMySqlIdentityColumn();

            builder
                .Property(m => m.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(m => m.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Authors");
        }
    }
}